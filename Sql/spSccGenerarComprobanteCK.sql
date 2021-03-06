USE [DBHerrera]
GO
/****** Object:  StoredProcedure [dbo].[spSccGenerarComprobanteCK]    Script Date: 05/29/2012 09:06:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================
-- Author:		Yesenia Gutiérrez
-- Create date: 14-11-2007
-- Description:	Este procedimiento tiene como finalidad grabar Comprobante
--				de Cheque basado en una Solicitud de Cheque Autorizada.
-- ==========================================================================
ALTER PROCEDURE [dbo].[spSccGenerarComprobanteCK]
	@nSccSolicitudID INT, -- ID de la Solicitud de Cheque o de la FNC
	@nScnFuenteFinanciamientoID INT, -- ID de la Fuente de Financiamiento
	@nStbDelegacionProgramaID INT, -- ID de la Delegación
	@sConceptoPago VARCHAR(300), -- Concepto del Comprobante
	@dFechaSolicitudCheque DATETIME, -- Fecha de la Solicitud de Cheque
	@dFechaTipoCambio DATETIME, -- Fecha de Tipo de Cambio
	@nStbPersonaBeneficiariaID INT, -- ID de la persona Beneficiaria (Null en Solicitudes Ck Socias)
	@nUsuarioID INT, -- ID Login del Usuario
	@sTipoDocumento VARCHAR(2), -- CK, CE
	@sNumeroCk VARCHAR(60) -- Si es Cero encontrar No. de CK.
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	DECLARE @nStbEstadoTransaccionID INT -- ID del Estado de la Transacción
	DECLARE @nStbTipoDocContableID INT -- ID del Tipo de Documento
	DECLARE @nTasaCambio FLOAT -- Valor de Tasa de Cambio
	DECLARE @nScnTransaccionContableID INT -- Id de Documento Contable a generar
	
	DECLARE @sNoTransaccion VARCHAR(60)
	DECLARE @nConsecutivo AS INT
	DECLARE @sNoCuentaBancaria VARCHAR(30)
	DECLARE @nNumeroInicialCheque SMALLINT
	
	-- DATOS DEL CURSOR:
	DECLARE @nMontoS NUMERIC(18, 2) -- Monto en C$ de cada detalle de Solicitud
	DECLARE @nDebito TINYINT -- Indicador de movimiento de cada detalle
	DECLARE @nScnCatalogoContableID INT -- Cuenta Contable de cada detalle
	
	-- Encuentra Estado Mayorizada para la Transacción:
	SELECT @nStbEstadoTransaccionID = ISNULL(a.nStbValorCatalogoID, 0)
	FROM   StbValorCatalogo a
	       INNER JOIN StbCatalogo b
	            ON  a.nStbCatalogoID = b.nStbCatalogoID
	WHERE  a.sCodigoInterno = '2'
	       AND b.sNombre = 'EstadoTransaccionContable'
	
	-- Encuentra Tipo de Documento Contable según 'CK' (Cheque a Socias) o 'CE' (Otros Cheques):
	SELECT @nStbTipoDocContableID = ISNULL(a.nStbValorCatalogoID, 0)
	FROM   StbValorCatalogo a
	       INNER JOIN StbCatalogo b
	            ON  a.nStbCatalogoID = b.nStbCatalogoID
	WHERE  a.sCodigoInterno = @sTipoDocumento
	       AND b.sNombre = 'TipoDocumentoContable'
	
	-- Encuentra No. de Cuenta Bancaria (Corriente) en el Detalle de la Solicitud:
	SELECT @sNoCuentaBancaria = ISNULL(a.sNumeroCuenta, 0)
	FROM   SteCuentaBancaria AS a
	       INNER JOIN StbValorCatalogo AS b
	            ON  a.nStbTipoCuentaID = b.nStbValorCatalogoID
	       INNER JOIN ScnCatalogoContable AS c
	            ON  a.nSteCuentaBancariaID = c.nSteCuentaBancariaID
	       INNER JOIN SccSolicitudChequeDetalle AS d
	            ON  c.nScnCatalogoContableID = d.nScnCatalogoContableID
	WHERE  (b.sCodigoInterno = '2')
	       AND (d.nSccSolicitudChequeID = @nSccSolicitudID)
	
	-- Encuentra No. Inicial de Cheque de la Cuenta Bancaria (Corriente):
	SELECT @nNumeroInicialCheque = ISNULL(a.nNumeroInicialCheque, 0)
	FROM   SteCuentaBancaria AS a
	       INNER JOIN StbValorCatalogo AS b
	            ON  a.nStbTipoCuentaID = b.nStbValorCatalogoID
	       INNER JOIN ScnCatalogoContable AS c
	            ON  a.nSteCuentaBancariaID = c.nSteCuentaBancariaID
	       INNER JOIN SccSolicitudChequeDetalle AS d
	            ON  c.nScnCatalogoContableID = d.nScnCatalogoContableID
	WHERE  (b.sCodigoInterno = '2')
	       AND (d.nSccSolicitudChequeID = @nSccSolicitudID)
	
	-- Obtener Monto de la Tasa de Cambio de la Fecha de Desembolso de la Solicitud de Cheque
	SELECT @nTasaCambio = nMontoTCambio
	FROM   StbParidadCambiaria
	WHERE  dFechaTCambio = @dFechaTipoCambio
	       AND nStbMonedaBaseID = (
	               SELECT sValorParametro
	               FROM   StbValorParametro
	               WHERE  nStbValorParametroID = 17
	           )
	       AND nStbMonedaCambioID = (
	               SELECT sValorParametro
	               FROM   StbValorParametro
	               WHERE  nStbValorParametroID = 18
	           )
	
	-- Si el ID de Persona Beneficiaria trae 0 se le asigna Null
	IF @nStbPersonaBeneficiariaID = 0
	    SELECT @nStbPersonaBeneficiariaID = NULL
	
	
	
	IF @sNumeroCk = '0'
	BEGIN
	    -- Obtener máximo Consecutivo para la Cuenta Bancaria:
	    SELECT @nConsecutivo = ISNULL(MAX(No), 0)
	    FROM   (
	               SELECT SUBSTRING(
	                          ScnTransaccionContable.sNumeroTransaccion,
	                          LEN(@sNoCuentaBancaria) + 1,
	                          LEN(ScnTransaccionContable.sNumeroTransaccion) - 
	                          LEN(@sNoCuentaBancaria)
	                      ) AS No
	               FROM   ScnTransaccionContable
	                      INNER JOIN StbValorCatalogo
	                           ON  ScnTransaccionContable.nStbTipoDocContableID = 
	                               StbValorCatalogo.nStbValorCatalogoID
	               WHERE  (
	                          SUBSTRING(
	                              ScnTransaccionContable.sNumeroTransaccion,
	                              1,
	                              LEN(@sNoCuentaBancaria)
	                          ) = @sNoCuentaBancaria
	                      )
	                      AND (
	                              StbValorCatalogo.sCodigoInterno = 'CK'
	                              OR StbValorCatalogo.sCodigoInterno = 'CE'
	                          )
	           ) a 
	    -- Formatear el Código del consecutivo del Número de Transacción Contable
	    IF @nConsecutivo = 0
	    BEGIN
	        SELECT @nConsecutivo = @nNumeroInicialCheque
	    END
	    ELSE
	    BEGIN
	        SELECT @nConsecutivo = @nConsecutivo + 1
	    END
	    -- Encuentra Número de Transacción del Comprobante de Diario
	    SELECT @sNoTransaccion = CONVERT(VARCHAR(30), @sNoCuentaBancaria) +
	           CONVERT(VARCHAR(30), @nConsecutivo)
	END
	ELSE
	BEGIN
	    -- Asigna Número de Transacción del Comprobante de Diario
	    -- =====================================================
	    -- A partir de asignación de chequera por Tesorería 09/Febrero/2009
	    -- El número de cheque es el asignado por tesoreria sin calcular el
	    -- mismo.
	    SELECT @sNoTransaccion = @sNumeroCk
	    PRINT '0'
	END
	
	DECLARE @condicion BIT = 1
	
	IF @sTipoDocumento = 'CK'
	BEGIN
		
		-- Si es cheque y la transaccion no esta repetida
		SELECT @condicion = 0
		FROM   ScnTransaccionContable stc
		       INNER JOIN StbValorCatalogo svc
		            ON  svc.nStbValorCatalogoID = stc.nStbEstadoTransaccionID
		WHERE  svc.sCodigoInterno <> '3'
		       AND stc.sNumeroTransaccion = @sNoTransaccion
               
        SET @condicion = ISNULL(@condicion,1)      
               
	END
	
	IF @condicion = 1
	BEGIN
		
		BEGIN TRAN
		
	    -- *************************************************************************************
	    -- 1. Insertar Registro de la nueva Transacción Contable:
	    -- *************************************************************************************
	    INSERT INTO ScnTransaccionContable
	      (
	        nStbDelegacionProgramaID,
	        nScnFuenteFinanciamientoID,
	        nStbTipoDocContableID,
	        nStbEstadoTransaccionID,
	        dFechaTransaccion,
	        dFechaTipoCambio,
	        sDescripcion,
	        sNumeroTransaccion,
	        nUsuarioCreacionID,
	        dFechaCreacion,
	        nSccSolicitudChequeID,
	        nStbPersonaBeneficiariaID
	      )
	    VALUES
	      (
	        @nStbDelegacionProgramaID,
	        @nScnFuenteFinanciamientoID,
	        @nStbTipoDocContableID,
	        @nStbEstadoTransaccionID,
	        @dFechaSolicitudCheque,
	        @dFechaTipoCambio,
	        @sConceptoPago,
	        @sNoTransaccion,
	        @nUsuarioID,
	        GETDATE(),
	        @nSccSolicitudID,
	        @nStbPersonaBeneficiariaID
	      )
	    
	    -- Valida si ocurre cualquier Error, deshace todas las operaciones
	    IF @@Error <> 0
	    BEGIN
	        PRINT '1'
	        ROLLBACK TRAN
	        SELECT @nScnTransaccionContableID = 0
	        SELECT @nScnTransaccionContableID
	        RETURN
	    END
	    
	    -- Asigna el ID de la nueva Transacción Contable
	    SELECT @nScnTransaccionContableID = @@IDENTITY
	    
	    -- *************************************************************************************
	    -- 2. Insertar Registro de los detalles de nueva Transacción Contable
	    -- *************************************************************************************
	    DECLARE SolicitudCK CURSOR  
	    FOR
	        -- Detalles de la Solicitud de Cheque:
	        SELECT nScnCatalogoContableID,
	               nDebito,
	               nMonto
	        FROM   SccSolicitudChequeDetalle
	        WHERE  (nSccSolicitudChequeID = @nSccSolicitudID)
	    
	    -- Accesar a los datos del Cursor creado
	    OPEN SolicitudCK 
	    FETCH NEXT
	    FROM SolicitudCK
	    INTO @nScnCatalogoContableID, @nDebito, @nMontoS 
	    
	    WHILE @@FETCH_STATUS = 0 -- Mientras existan registros en el Cursor
	    BEGIN
	        -- BEGIN del WHILE
	        
	        -- Insertar Registro del detalle de la nueva Transacción Contable:
	        INSERT INTO ScnTransaccionContableDetalle
	          (
	            nScnTransaccionContableID,
	            nScnCatalogoContableID,
	            nDebito,
	            nMontoC,
	            nMontoD,
	            nUsuarioCreacionID,
	            dFechaCreacion
	          )
	        VALUES
	          (
	            @nScnTransaccionContableID,
	            @nScnCatalogoContableID,
	            @nDebito,
	            @nMontoS,
	            ROUND(@nMontoS / @nTasaCambio, 2),
	            @nUsuarioID,
	            GETDATE()
	          )
	        
	        FETCH NEXT
	        FROM SolicitudCK
	        INTO @nScnCatalogoContableID, @nDebito, @nMontoS
	    END -- END del BEGIN del WHILE
	    
	    CLOSE SolicitudCK 
	    DEALLOCATE SolicitudCK
	    
	    -- Valida si ocurre cualquier Error, deshace todas las operaciones
	    IF @@Error <> 0
	    BEGIN
	        PRINT '2'
	        ROLLBACK TRAN
	        SELECT @nScnTransaccionContableID = 0
	        SELECT @nScnTransaccionContableID
	        RETURN
	    END
	    
	    -- *************************************************************************************
	    -- 3. Cambiar estado de la Solicitud de Cheque a Autorizada con CK Emitido:
	    -- *************************************************************************************
	    UPDATE SccSolicitudCheque
	    SET    nUsuarioModificacionID = @nUsuarioID,
	           dFechaModificacion = GETDATE(),
	           nStbEstadoSolicitudID = (
	               SELECT a.nStbValorCatalogoID
	               FROM   StbValorCatalogo a
	                      INNER JOIN StbCatalogo b
	                           ON  a.nStbCatalogoID = b.nStbCatalogoID
	               WHERE  a.sCodigoInterno = '6'
	                      AND b.sNombre = 'EstadoSolicitudCheque'
	           )
	    WHERE  nSccSolicitudChequeID = @nSccSolicitudID
	    
	    -- Valida si ocurre cualquier Error, deshace todas las operaciones
	    IF @@Error <> 0
	    BEGIN
	        PRINT '3'
	        ROLLBACK TRAN
	        SELECT @nScnTransaccionContableID = 0
	        SELECT @nScnTransaccionContableID
	        RETURN
	    END
	    
	    -- ***********************************************************************
	    -- 4. Ejecuta Procedimiento Almancenado para Mayorización de la Transacción
	    -- ***********************************************************************
	    EXEC spScnAplicaAnulaTransaccion @nScnTransaccionContableID,
	         1,
	         @nUsuarioID
	    
	    -- Valida si ocurre cualquier Error, deshace todas las operaciones
	    IF @@Error <> 0
	    BEGIN
	        PRINT '4'
	        ROLLBACK TRAN
	        SELECT @nScnTransaccionContableID = 0
	        SELECT @nScnTransaccionContableID
	        RETURN
	    END
	    
	    -- Finaliza Transacción:
	    COMMIT TRAN
	    SELECT @nScnTransaccionContableID 
	    
	    RETURN
	END
END

































