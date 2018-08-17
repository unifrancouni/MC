USE [DbGutierrez]
GO

/****** Object:  StoredProcedure [dbo].[spSccGenerarTablaAmortizacionPDIBA]    Script Date: 04/18/2013 16:22:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[spSccGenerarTablaAmortizacionPDIBA] 
	@nSclFichaNotificacionCreditoID int,
	@sUsuarioCreacion varchar(30),	-- Login del Usuario
    @SCodigoPlazo varchar(1),
	@nTasaInteresAnual float,
	@nTasaMantValor float,
	@nComenzarQuincena int
	--0 Indica que Comienza la siguiente quincena correspondiente a la fecha  @dFechaHoraEntregaCK
	                       --1 Indica que comenzaria pagando el 16 , 2 Indica que comenzaria pagando el dia 1   		
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @nSclFichaNotificacionDetalleID int
	DECLARE @nPlazoAprobado numeric(18,0)  -- Consecutivo de Ficha de una socia para un mismo grupo
	DECLARE @nMontoCreditoAprobado numeric(18,2)		-- ID del Estado de la Ficha
	DECLARE @dFechaPrimerCuota datetime				-- Para formatear código
	DECLARE @nNumCuota int		-- ID del Grupo Solidario
	DECLARE @nNumTotalCuota int
	DECLARE @nIntereses   numeric(18,2)
	DECLARE @nDiasTranscurridos int
--	DECLARE @nTasaInteresAnual float
--	DECLARE @nTasaMantValor float
	DECLARE @nMantValor   numeric(18,2)
	DECLARE @nSaldo     numeric(18,2)
    DECLARE @nSaldoPresentar numeric(18,2)
	DECLARE @nAmortizacion  numeric(18,2)
	DECLARE @nStbTipoPlazoCuotaID int
	DECLARE @nMontoCuota  numeric(18,2)
	DECLARE @dFechaHoraEntregaCK datetime
	DECLARE @dFechaVencimiento datetime
	DECLARE @dFechaInicial datetime
	DECLARE @nStbEstadoPagoID int
--    DECLARE @SCodigoPlazo char(1)
    
	--SELECT @nDiasTranscurridos = 7
--	SELECT @nTasaInteresAnual = 4
--	SELECT @nTasaMantValor = 6
    DECLARE @Divisor int

DECLARE @FechaDia datetime

DECLARE @FechaDiaStr varchar(15)
DECLARE @CadDia varchar(10)
DECLARE @dFechaPrimerCuotaPrevio as datetime 



	SELECT @dFechaVencimiento = b.dFechaHoraEntregaCK
	FROM SclFichaNotificacionCredito b
	WHERE b.nSclFichaNotificacionID = @nSclFichaNotificacionCreditoID


IF Not object_id ('tempdb.dbo.#TmpTablaAmortizacion') is null
	BEGIN
		Drop Table  #TmpTablaAmortizacion
	END


CREATE TABLE #TmpTablaAmortizacion (
  nSclFichaNotificacionDetalleID [int]  NOT NULL,
  nNumCuota [int]  NOT NULL,
  dFechaPago [Datetime]  NOT NULL,
  nAmortizacion [numeric ] (18,2)  NOT NULL  ,
  nMantValor [numeric]  (18,2) NOT NULL,
  nIntereses [numeric](18,2)  NOT NULL,
  nStbTipoPlazoCuotaID [int] NOT NULL,
  nCuota [numeric ] (18,2) NOT NULL,
  nSaldo [numeric ] (18,2) NOT NULL,
  nSaldoPresentar [numeric ](18,2)  NOT NULL,
  nStbEstadoPagoID [int] NOT NULL

  
)



--SELECT @SCodigoPlazo	= 
--dbo.StbValorCatalogo.sCodigoInterno
--FROM         dbo.SccSolicitudDesembolsoCredito INNER JOIN
--                      dbo.StbValorCatalogo ON dbo.SccSolicitudDesembolsoCredito.nStbTipoPlazoPagosID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN
--                      dbo.SclFichaNotificacionDetalle ON 
--                      dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID
--GROUP BY dbo.StbValorCatalogo.sCodigoInterno, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID
--HAVING      (dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = @nSclFichaNotificacionCreditoID )
--

Select @nDiasTranscurridos= Case 

When  @SCodigoPlazo='S' Then 
		7 --Para Agregar 7 dias

When  @SCodigoPlazo='Q' Then 
		15 --Para Agregar 15 dias puede ser 14,15,16  depende del mes 
		
 When  @SCodigoPlazo='M' Then
  
1 --Para Agregar un mes
end


Select @Divisor= 

Case When  @SCodigoPlazo='S' Then 
	360
	
	 When  @SCodigoPlazo='Q' Then 
	360
 --Para Agregar 7 dias
 When  @SCodigoPlazo='M' Then
  
12 --Para Agregar un mes
end

Select @dFechaInicial= Case When  @SCodigoPlazo='S' Then 

@dFechaVencimiento + 7 --Agregar una semana
 When  @SCodigoPlazo='M' Then
  DATEADD(m, 1, @dFechaVencimiento)  --Agregar un mes

end



 ----------AQUI QUICENAL


 IF @SCodigoPlazo='Q'  --Quincenal 
	BEGIN
			--0 Indica que Comienza la siguiente quincena correspondiente a la fecha  @dFechaHoraEntregaCK
	                       --1 Indica que comenzaria pagando el 16 , 2 Indica que comenzaria pagando el dia 1   		
  IF @nComenzarQuincena =0   --Comienza la siguiente quincena del desembolso
	BEGIN
		IF day(@dFechaInicial)<=15  --Primer quincena
			BEGIN ---Cae en la segunda quincena 
		            set @FechaDiaStr = '16-'+CAST( MONTH(@dFechaVencimiento) as varchar(2))+'-'+CAST( year(@dFechaVencimiento) as varchar(4))
				    --set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
				    set @dFechaInicial  = CONVERT(datetime,@FechaDiaStr,103)
			
			END
		ELSE
			BEGIN --Del 16 en adelante cae en la primer quincena del siguiente mes
					IF MONTH(@dFechaVencimiento)<12 
						BEGIN --Hasta noviembre siempre queda en el mismo año
			
								set @FechaDiaStr = '01-'+CAST( MONTH(@dFechaVencimiento) +1  as varchar(2))+'-'+CAST( year(@dFechaVencimiento) as varchar(4))
								--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
								set @dFechaInicial  = CONVERT(datetime,@FechaDiaStr,103)
				    
						END
					ELSE 
						BEGIN  --Del 16 de diciembre al 31 de diciembre entonces 1 dia del año siguiente
								set @FechaDiaStr = '01-'+CAST( 1  as varchar(2))+'-'+CAST( year(@dFechaVencimiento)+1 as varchar(4))
								--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
								set @dFechaInicial  = CONVERT(datetime,@FechaDiaStr,103)	
						
						END 	
				    
				    
				    
			END	
		
		
		--Select @dFechaInicial =DATEADD(m, 1, @dFechaVencimiento)  --Agregar un mes
		
		
	END  -- IF @nComenzarQuincena =0 
	
	ELSE
		BEGIN
			IF @nComenzarQuincena =1 OR  @nComenzarQuincena =2  --1 Indica que comenzaria pagando el 16 , 2 Indica que comenzaria pagando el dia 1   		
				BEGIN
					IF @nComenzarQuincena =1
						BEGIN
							SET @CadDia='16-'
						END		
					ELSE
						BEGIN
							SET @CadDia='01-'
						END		
					
					
					
				
					IF MONTH(@dFechaVencimiento)<12 
									BEGIN --Hasta noviembre siempre queda en el mismo año
						
											set @FechaDiaStr = @CadDia+CAST( MONTH(@dFechaVencimiento) +1  as varchar(2))+'-'+CAST( year(@dFechaVencimiento) as varchar(4))
											--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
											set @dFechaInicial  = CONVERT(datetime,@FechaDiaStr,103)
							    
									END
								ELSE 
									BEGIN  --Del 16 de diciembre al 31 de diciembre entonces 1 dia del año siguiente
											set @FechaDiaStr = @CadDia+CAST( 1  as varchar(2))+'-'+CAST( year(@dFechaVencimiento)+1 as varchar(4))
											--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
											set @dFechaInicial  = CONVERT(datetime,@FechaDiaStr,103)	
									
									END 	
												
									
									
									
												
				END  --IF @nComenzarQuincena =1 
		
		END --ELSE F @nComenzarQuincena =1

END








----------FIN AQUI QUINCENAL





























	--SELECT @dFechaInicial = @dFechaVencimiento + 7


	-- Tipo de Plazo: Semanal
	--SELECT @nStbTipoPlazoCuotaID = isnull(a.nStbValorCatalogoID,0) FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = 'S' And b.sNombre = 'TipoPlazo'
--SELECT @nStbTipoPlazoCuotaID = isnull(a.nStbValorCatalogoID,0) FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = 'S' And b.sNombre = 'TipoPlazo'
SELECT @nStbTipoPlazoCuotaID = isnull(a.nStbValorCatalogoID,0) FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = @SCodigoPlazo And b.sNombre = 'TipoPlazo'

	-- Estado "Pendiente de Pago" para cada registro de la Tabla de Amortización
	SELECT @nStbEstadoPagoID = isnull(a.nStbValorCatalogoID,0) FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoPagoAmortizacion'

--Select @nNumTotalCuota   = Case When  @SCodigoPlazo='S' Then 
--
--@nPlazoAprobado * 4
-- When  @SCodigoPlazo='M' Then
--  @nPlazoAprobado 
--
--end



BEGIN TRAN

	DELETE SccTablaAmortizacion 
	WHERE nSclFichaNotificacionDetalleID IN (SELECT     dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID
FROM         dbo.SclFichaNotificacionCredito INNER JOIN
                      dbo.SclFichaNotificacionDetalle ON 
                      dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID
WHERE     (dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = @nSclFichaNotificacionCreditoID) 
AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0))


	DECLARE FichaNotificacion CURSOR FOR 

	SELECT a.nSclFichaNotificacionDetalleID,a.nPlazoAprobado,nMontoCreditoAprobado,b.dFechaHoraEntregaCK
	FROM SclFichaNotificacionDetalle a INNER JOIN SclFichaNotificacionCredito b
	ON a.nSclFichaNotificacionID = b.nSclFichaNotificacionID
	WHERE a.nSclFichaNotificacionID = @nSclFichaNotificacionCreditoID
	AND a.nCreditoRechazado = 0 

	-- Accesar a los datos del Cursor creado
	OPEN FichaNotificacion  
	FETCH NEXT
	FROM FichaNotificacion
	INTO @nSclFichaNotificacionDetalleID,@nPlazoAprobado,@nMontoCreditoAprobado,@dFechaHoraEntregaCK

	WHILE @@FETCH_STATUS = 0  -- Mientras existan registros en el Cursor
	BEGIN    -- BEGIN del WHILE
		PRINT '***************************'
		PRINT 'EN FICHA nSclFichaNotificacionDetalleID'
		PRINT @nSclFichaNotificacionDetalleID
		PRINT '***************************'

		--DELETE SccTablaAmortizacion WHERE nSclFichaNotificacionDetalleID = @nSclFichaNotificacionDetalleID

Select @nNumTotalCuota   = Case 
When  @SCodigoPlazo='S' Then 

@nPlazoAprobado * 4

When  @SCodigoPlazo='Q' Then 

@nPlazoAprobado * 2



 When  @SCodigoPlazo='M' Then
  @nPlazoAprobado 

end

--PRINT @nSclFichaNotificacionDetalleID
		 --SELECT @nNumTotalCuota = @nPlazoAprobado * 4
--PRINT @dFechaHoraEntregaCK 
		SELECT @nNumCuota = 1

		--SELECT @dFechaPrimerCuota = @dFechaHoraEntregaCK + 7

Select @dFechaPrimerCuota   = Case When  @SCodigoPlazo='S' Then 

@dFechaHoraEntregaCK + 7
 When  @SCodigoPlazo='M' Then
  
DATEADD(m, 1, @dFechaHoraEntregaCK)  --Agregar un mes
end











 ----------AQUI QUICENAL


 IF @SCodigoPlazo='Q'  --Quincenal 
	BEGIN
			--0 Indica que Comienza la siguiente quincena correspondiente a la fecha  @dFechaHoraEntregaCK
	                       --1 Indica que comenzaria pagando el 16 , 2 Indica que comenzaria pagando el dia 1   		
	                       
	                       
	                       
	                       
	                       
	           --PRINT '@dFechaInicial EN Q'            
	           --PRINT @dFechaInicial
	                       
	                       
  IF @nComenzarQuincena =0   --Comienza la siguiente quincena del desembolso
	BEGIN
		IF day(@dFechaHoraEntregaCK)<=15  --Primer quincena
			BEGIN ---Cae en la segunda quincena 
		            set @FechaDiaStr = '16-'+CAST( MONTH(@dFechaHoraEntregaCK) as varchar(2))+'-'+CAST( year(@dFechaHoraEntregaCK) as varchar(4))
				    --set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
				    set @dFechaPrimerCuota  = CONVERT(datetime,@FechaDiaStr,103)
			
			END
		ELSE
			BEGIN --Del 16 en adelante cae en la primer quincena del siguiente mes
					IF MONTH(@dFechaHoraEntregaCK)<12 
						BEGIN --Hasta noviembre siempre queda en el mismo año
			
								set @FechaDiaStr = '01-'+CAST( MONTH(@dFechaHoraEntregaCK) +1  as varchar(2))+'-'+CAST( year(@dFechaHoraEntregaCK) as varchar(4))
								PRINT '@FechaDiaStr'
								PRINT @FechaDiaStr
								
								--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
								set @dFechaPrimerCuota  = CONVERT(datetime,@FechaDiaStr,103)
				    
						END
					ELSE 
						BEGIN  --Del 16 de diciembre al 31 de diciembre entonces 1 dia del año siguiente
								set @FechaDiaStr = '01-01-'+CAST( year(@dFechaHoraEntregaCK)+1 as varchar(4))
								--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
								set @dFechaPrimerCuota  = CONVERT(datetime,@FechaDiaStr,103)	
								--PRINT 'AQUI ANIO NEX'
						
						END 	
				    
				    
				    
			END	
		
		
		--Select @dFechaInicial =DATEADD(m, 1, @dFechaVencimiento)  --Agregar un mes
		
		
	END  -- IF @nComenzarQuincena =0 
	
	ELSE
		BEGIN
			IF @nComenzarQuincena =1 OR  @nComenzarQuincena =2  --1 Indica que comenzaria pagando el 16 , 2 Indica que comenzaria pagando el dia 1   		
				BEGIN
					IF @nComenzarQuincena =1
						BEGIN
							SET @CadDia='16-'
						END		
					ELSE
						BEGIN
							SET @CadDia='01-'
						END		
					
					
					
				
					IF MONTH(@dFechaHoraEntregaCK)<12 
									BEGIN --Hasta noviembre siempre queda en el mismo año
						
											set @FechaDiaStr = @CadDia+CAST( MONTH(@dFechaHoraEntregaCK) +1  as varchar(2))+'-'+CAST( year(@dFechaVencimiento) as varchar(4))
											--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
											set @dFechaPrimerCuota  = CONVERT(datetime,@FechaDiaStr,103)
							    
									END
								ELSE 
									BEGIN  --Del 16 de diciembre al 31 de diciembre entonces 1 dia del año siguiente
											set @FechaDiaStr = @CadDia+'01-'+CAST( year(@dFechaHoraEntregaCK)+1 as varchar(4))
											--set @FechaDia  = CONVERT(datetime,@FechaDiaStr,103)
											set @dFechaPrimerCuota  = CONVERT(datetime,@FechaDiaStr,103)	
									
									END 	
												
									
									
									
												
				END  --IF @nComenzarQuincena =1 
		
		END --ELSE F @nComenzarQuincena =1

END








----------FIN AQUI QUINCENAL






















































--		SELECT @nMontoCuota = nMontoCuota 
--		FROM StbTablaAmortizacion
--		WHERE nMonto = @nMontoCreditoAprobado
--		AND nPlazo = @nPlazoAprobado

      SELECT @nMontoCuota = dbo.CalculaCuota(@nTasaInteresAnual,@nTasaMantValor,@nMontoCreditoAprobado,@nNumTotalCuota,@SCodigoPlazo)

		SELECT @nSaldo = @nMontoCreditoAprobado

  --PRINT @nNumTotalCuota 
  
   
   
   
		IF @SCodigoPlazo='Q' --Quincenal
			BEGIN --Encontrar la primer cantidad de dias entre la fecha de emision del cheque y la primer fecha de pago
				SET @dFechaPrimerCuotaPrevio=@dFechaHoraEntregaCK	
				SET @nDiasTranscurridos = DATEDIFF(d,@dFechaHoraEntregaCK,@dFechaPrimerCuota)
				
						--PRINT '@dFechaPrimerCuota Aqu1 '
						--	print @dFechaPrimerCuota
						--	print '@nDiasTranscurridos'
						--	print @nDiasTranscurridos
							
			END
  
		WHILE @nNumTotalCuota >= @nNumCuota 
		BEGIN
			PRINT '@nDiasTranscurridos'
			PRINT @nDiasTranscurridos  
            PRINT '@nNumCuota' 
            PRINT @nNumCuota
            

			--SELECT @nIntereses = @nSaldo * @nDiasTranscurridos  * @nTasaInteresAnual / 360
            SELECT @nIntereses =  ROUND( @nSaldo *( (@nTasaInteresAnual/100  )/ @Divisor) * @nDiasTranscurridos ,2)
            print '@nIntereses'
            print @nIntereses
			--SELECT @nMantValor = @nSaldo * @nDiasTranscurridos * @nTasaMantValor / 360
            SELECT @nMantValor = ROUND(@nSaldo  *((@nTasaMantValor/100  )/ @Divisor) * @nDiasTranscurridos ,2) 
            print '@nMantValor'
            print @nMantValor
			--SELECT @nAmortizacion = @nMontoCuota - (@nSaldo * @nDiasTranscurridos * @nTasaInteresAnual / 360) - (@nSaldo * @nDiasTranscurridos * @nTasaMantValor / 360)
            SELECT @nAmortizacion = ROUND (@nMontoCuota,2 )- ROUND(@nIntereses ,2)- ROUND(@nMantValor ,2)
            print '@nAmortizacion'
            print @nAmortizacion
			--SELECT @nSaldo = @nSaldo - (@nMontoCuota - (@nSaldo * @nDiasTranscurridos * @nTasaInteresAnual / 360) - (@nSaldo * @nDiasTranscurridos * @nTasaMantValor / 360)) - (@nSaldo * @nDiasTranscurridos * @nTasaMantValor / 360)
            --SELECT @nSaldo = @nSaldo - @nAmortizacion

			IF @nNumTotalCuota = @nNumCuota 
               BEGIN
                IF @nSaldo <> @nAmortizacion
                    BEGIN
                      SELECT @nAmortizacion = ROUND(@nSaldo,2)
                      SELECT @nMontoCuota  = ROUND(@nAmortizacion,2) +ROUND(@nIntereses,2) +ROUND(@nMantValor,2)
                    END 
               END 
           SELECT @nSaldo = @nSaldo - @nAmortizacion
           IF @nNumTotalCuota = @nNumCuota 
               SELECT @nSaldo = 0

			--INSERT INTO SccTablaAmortizacion (nStbEstadoPagoID,nStbTipoPlazoCuotaID,nAmortizacion,nCuota,nSclFichaNotificacionDetalleID,nNumCuota,dFechaPago,nIntereses,nMantValor,nSaldo,sUsuarioCreacion,dFechaCreacion)            	--VALUES(@nStbEstadoPagoID,@nStbTipoPlazoCuotaID,@nAmortizacion,@nMontoCuota,@nSclFichaNotificacionDetalleID,@nNumCuota,@dFechaPrimerCuota,@nIntereses,@nMantValor,@nSaldo,@sUsuarioCreacion,getdate())
            
            INSERT INTO #TmpTablaAmortizacion  (nStbEstadoPagoID,nStbTipoPlazoCuotaID,nAmortizacion,nCuota,nSclFichaNotificacionDetalleID,nNumCuota,dFechaPago,nIntereses,nMantValor,nSaldo,nSaldoPresentar)            	VALUES(@nStbEstadoPagoID,@nStbTipoPlazoCuotaID,@nAmortizacion,@nMontoCuota,@nSclFichaNotificacionDetalleID,@nNumCuota,@dFechaPrimerCuota,@nIntereses,@nMantValor,@nSaldo,0)
           	
           	PRINT '-------------------------------------------------------'
           	PRINT '@nNumCuota'
           	PRINT @nNumCuota
           	PRINT '-------------------------------------------------------' 

			-- Valida si ocurre cualquier Error, deshace todas las operaciones
			If @@Error <> 0 
			BEGIN
				ROLLBACK TRAN
				SELECT @nSclFichaNotificacionCreditoID = 0
				SELECT @nSclFichaNotificacionCreditoID
				RETURN
			END
		PRINT '@dFechaPrimerCuota....'
		print @dFechaPrimerCuota

			--SELECT @dFechaPrimerCuota = @dFechaPrimerCuota + @nDiasTranscurridos

			SELECT @nNumCuota = @nNumCuota + 1




		IF @SCodigoPlazo='S' OR @SCodigoPlazo='M'
			BEGIN

					Select @dFechaPrimerCuota= Case When  @SCodigoPlazo='S' Then 

					@dFechaPrimerCuota + @nDiasTranscurridos --Para Agregar 7 dias
					 When  @SCodigoPlazo='M' Then
					  
					DATEADD(m, @nNumCuota, @dFechaHoraEntregaCK) --Para Agregar  mes a mes, para que se mantenga el mismo dia de pago con la fecha de entrega del cheque
					end
			END

---QUINCENAL 
PRINT '@dFechaPrimerCuotaAntes-->'
		print @dFechaPrimerCuota


if @SCodigoPlazo='Q' --Quincenal
	BEGIN
		SET @dFechaPrimerCuotaPrevio=@dFechaPrimerCuota		
	
		PRINT '@dFechaPrimerCuota<><><>'
		print @dFechaPrimerCuota
		IF day(@dFechaPrimerCuota)= 1
			BEGIN
				Set @dFechaPrimerCuota  =@dFechaPrimerCuota + 15 --Caeria el 16 la siguiente
				
				PRINT 'DIA 1'
			END
		ELSE
			BEGIN --Hacer que caiga en el primer dia del siguiente mes
				PRINT 'DIA 16'
				IF MONTH(@dFechaPrimerCuota)<12 --Hasta Noviembre 
					BEGIN
						PRINT 'DIA 16 HASTA NOVIEMBRE'
						set @FechaDiaStr = '01-'+CAST(month(@dFechaPrimerCuota)  +1  as varchar(2))+'-'+CAST( year(@dFechaPrimerCuota) as varchar(4))
						set @dFechaPrimerCuota= CONVERT(datetime,@FechaDiaStr,103)	
					
					END
				ELSE
					BEGIN --Diciembre pasa a enero del siguiente
						set @FechaDiaStr = '01-01-'+CAST( year(@dFechaPrimerCuota)+1 as varchar(4))
						set @dFechaPrimerCuota = CONVERT(datetime,@FechaDiaStr,103)						
					END	
			END	 --Hacer que caiga en el primer dia del siguiente mes
			
		SET @nDiasTranscurridos = DATEDIFF(d,@dFechaPrimerCuotaPrevio,@dFechaPrimerCuota)
	END --if @SCodigoPlazo='Q' --Quincenal








---QUINCENAL 


			IF @nNumTotalCuota >= @nNumCuota 
			BEGIN
				IF @dFechaPrimerCuota > @dFechaVencimiento
				BEGIN
					SELECT @dFechaVencimiento = @dFechaPrimerCuota
				END
			END
		END   --WHILE @nNumTotalCuota >= @nNumCuota 
        --Obtener El Saldo a presentar de la suma del total de los montos de las cuotas
        SELECT @nSaldoPresentar = SUM(nCuota)  From  #TmpTablaAmortizacion
                Where  nSclFichaNotificacionDetalleID= @nSclFichaNotificacionDetalleID

		DECLARE ActualizaSaldoAPresentar CURSOR FOR 

			SELECT  nCuota,nNumCuota
			FROM #TmpTablaAmortizacion 
			WHERE  nSclFichaNotificacionDetalleID= @nSclFichaNotificacionDetalleID
			Order By  nNumCuota

--			-- Accesar a los datos del Cursor creado
			OPEN ActualizaSaldoAPresentar  
			FETCH NEXT
			FROM ActualizaSaldoAPresentar
			INTO @nMontoCuota,@nNumCuota 
--
			WHILE @@FETCH_STATUS = 0  -- Mientras existan registros en el Cursor
				BEGIN	
					 SELECT @nSaldoPresentar =  @nSaldoPresentar-@nMontoCuota
                     UPDATE  #TmpTablaAmortizacion Set nSaldoPresentar= @nSaldoPresentar
                         Where   nSclFichaNotificacionDetalleID = @nSclFichaNotificacionDetalleID And  nNumCuota= @nNumCuota
                         
					FETCH NEXT
					FROM ActualizaSaldoAPresentar
					INTO @nMontoCuota,@nNumCuota 
				END
			CLOSE ActualizaSaldoAPresentar
	        DEALLOCATE ActualizaSaldoAPresentar
        

		FETCH NEXT
		FROM  FichaNotificacion
		INTO @nSclFichaNotificacionDetalleID,@nPlazoAprobado,@nMontoCreditoAprobado,@dFechaHoraEntregaCK
	END -- END del BEGIN del WHILE

	CLOSE FichaNotificacion 
	DEALLOCATE FichaNotificacion







     INSERT INTO  SccTablaAmortizacion (nStbEstadoPagoID,nStbTipoPlazoCuotaID,nAmortizacion,nCuota,nSclFichaNotificacionDetalleID,nNumCuota,dFechaPago,nIntereses,nMantValor,nSaldo,nSaldoPresentar, sUsuarioCreacion,dFechaCreacion)            SELECT                       nStbEstadoPagoID,nStbTipoPlazoCuotaID,nAmortizacion,nCuota,nSclFichaNotificacionDetalleID,nNumCuota,dFechaPago,nIntereses,nMantValor,nSaldo,nSaldoPresentar, @sUsuarioCreacion,getdate()                 From  #TmpTablaAmortizacion             

	UPDATE SclFichaNotificacionCredito
	SET dFechaPrimerCuota = @dFechaInicial,
		dFechaUltimaCuota = @dFechaVencimiento
	WHERE nSclFichaNotificacionID = @nSclFichaNotificacionCreditoID

	-- Valida si ocurre cualquier Error, deshace todas las operaciones
	If @@Error <> 0 
	BEGIN
		ROLLBACK TRAN
		SELECT @nSclFichaNotificacionCreditoID = 0
		SELECT @nSclFichaNotificacionCreditoID
		RETURN
	END


	COMMIT TRAN


	--SELECT @nSclFichaSociaID 

RETURN
END





















GO

