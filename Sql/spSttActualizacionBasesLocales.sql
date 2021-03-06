USE [SMUSURA0-E3]
GO
/****** Object:  StoredProcedure [dbo].[spSttActualizacionBasesLocales]    Script Date: 12/17/2009 17:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Edgard Delgado
-- Create date: 2008-02-13
-- Description:	Actualizacion de Bases Locales
-- =============================================
CREATE PROCEDURE [dbo].[spSttActualizacionBasesLocales]
@nSteCajaId int,
@nNoEnvioUltimo int,
 
@SsgCuentaID int,
@CarpetaTempo varchar(1000),
@CarpetaTempoUSBCopia varchar(1000),
@CarpetaTxtFisica varchar(1000),
@CarpetaTxtLogica varchar(1000)

AS
BEGIN
	SET NOCOUNT OFF

    DECLARE @AgregarRegistroParametro int -- Es para ver si existe el registro de la tabla parametros
	DECLARE @TablaOrigen varchar(100), @TablaDestino varchar(100)
    DECLARE @column_name varchar(4000), @delimiter char(2)
	DECLARE @SQLCmd varchar(8000)



  SET @AgregarRegistroParametro = 0
--  BEGIN TRY	
--		SELECT nSteCajaId From SttProcesarParametroES 
----		IF @@ERROR <> 0
----		BEGIN
----			RETURN
----		END
--
--   END TRY
--    BEGIN CATCH
--		SELECT 'Error al obtener la información de la tabla SttProcesarParametroES ' + ERROR_MESSAGE()
--        RETURN
--    END CATCH
--
--
-- IF @@ROWCOUNT = 0  --No existe registro de la tabla parametros
--      BEGIN
--        SET @AgregarRegistroParametro= 1 --Agregarlo es la primera vez
--      END
--



	SET @delimiter = ', '
   

   

    
--Ojo
	BEGIN TRANSACTION UpdateLocal

    

	-- Deletes Data From Tables In Local DB
	DECLARE DeleteTableProcess CURSOR FOR 
	Select sNombreTablaDestino From SttProcesarTablasES 
	Where nProcesar = 1
	Order By nOrdenImportar Desc;
    

    BEGIN TRY ----***********************
----***********************
	OPEN DeleteTableProcess
	

----***********************
    END TRY
    BEGIN CATCH
--Ojo
		ROLLBACK TRANSACTION UpdateLocal
		SELECT 'Error al obtener la información de la tabla SttProcesarTablasES ' + ERROR_MESSAGE()
        RETURN
    END CATCH

----***********************

	FETCH NEXT FROM DeleteTableProcess
	INTO @TablaDestino

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @SQLCmd = '
		DELETE FROM ' + @TablaDestino + ';
		'
--       IF @nNoEnvioUltimo = 0 Or (@nNoEnvioUltimo >0 And @TablaDestino<>'SteCaja')
--          BEGIN  
				PRINT @TablaDestino 
    BEGIN TRY 
				EXEC (@SQLCmd)
                 
----------------				IF @@ERROR <> 0
----------------				BEGIN
----------------					ROLLBACK TRANSACTION UpdateLocal
----------------					RETURN
----------------				END
		  --END	


----***********************
    END TRY
    BEGIN CATCH
--Ojo
		ROLLBACK TRANSACTION UpdateLocal
		SELECT 'Error al borrar registros de la tabla ' + @TablaDestino +' ' + ERROR_MESSAGE()
        RETURN
    END CATCH

----***********************






		FETCH NEXT FROM DeleteTableProcess
		INTO @TablaDestino
	END
	CLOSE DeleteTableProcess
	DEALLOCATE DeleteTableProcess

	-- Inserts Data From SMCU0-Exportacion Structure To Local DB
	DECLARE InsertTablesProcess CURSOR FOR 
	Select sNombreTablaOrigen, sNombreTablaDestino FROM SttProcesarTablasES 
	Where nProcesar = 1
	Order By nOrdenImportar Asc;
    --*********************
    BEGIN TRY 
		OPEN InsertTablesProcess

    ---************************
    END TRY
    BEGIN CATCH
--Ojo
	ROLLBACK TRANSACTION UpdateLocal
		SELECT 'Error al Borrar registros de la tabla ' + @TablaDestino +' ' + ERROR_MESSAGE()
        RETURN
    END CATCH
    ---*******************************************

	FETCH NEXT FROM InsertTablesProcess
	INTO @TablaOrigen, @TablaDestino

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @column_name = NULL

		SELECT @column_name = COALESCE(@column_name + @delimiter, '') + column_name  
		FROM INFORMATION_SCHEMA.COLUMNS 
		WHERE table_name = @TablaDestino
		ORDER BY ordinal_position ASC

		
				SET @SQLCmd = '
				SET IDENTITY_INSERT ' + @TablaDestino + ' ON;
				INSERT INTO ' + @TablaDestino + ' (' + @column_name + ') SELECT * FROM [SMCU0-Exportacion].dbo.' + @TablaOrigen + ' ORDER BY 1;
				SET IDENTITY_INSERT ' + @TablaDestino + ' OFF;
				'
--		IF @nNoEnvioUltimo = 0 Or (@nNoEnvioUltimo >0 And @TablaDestino<>'SteCaja')
--			  BEGIN    
PRINT @SQLCmd
    BEGIN TRY      
					EXEC (@SQLCmd)

--					IF @@ERROR <> 0
--					BEGIN
--						ROLLBACK TRANSACTION UpdateLocal
--						RETURN
--					END
--			  END 

    END TRY
    BEGIN CATCH
--Ojo
		ROLLBACK TRANSACTION UpdateLocal
		SELECT 'Error al intentar insertar registros en la tabla ' + @TablaDestino + ' ' + ERROR_MESSAGE()
        RETURN
    END CATCH

		FETCH NEXT FROM InsertTablesProcess
		INTO @TablaOrigen, @TablaDestino
	END
	CLOSE InsertTablesProcess
	DEALLOCATE InsertTablesProcess
    --Actualiza la tabla que indica que se hizo la carga SttProcesarEnvioES
    --y se indica en la tabla parametros que se puede disponer del acceso
    --a Pagos recibidos


--    IF @AgregarRegistroParametro =1
--      BEGIN
--          INSERT INTO SttProcesarParametroES(CarpetaTempo,CarpetaTempoUSBCopia,nSteCajaId,EstadoEnvio,NoEnvioUltimo,ExportarnSteCajaId,BaseTemporal,CarpetaTxtFisica,CarpetaTxtLogica)
--          VALUES(@CarpetaTempo,@CarpetaTempoUSBCopia,@nSteCajaId,0,0,@nSteCajaId,'SMCU0-Exportacion',@CarpetaTxtFisica,@CarpetaTxtLogica)            
--		IF @@ERROR <> 0
--		BEGIN
--			ROLLBACK TRANSACTION UpdateLocal
--			RETURN
--		END
--
--      END
 
    


   --En la base local sobre la que trabaja este procedimiento
   --se considera si el numero de envio es el cero entonces
   --se ingresa. Pues es la inicializacion de la base
   --si es uno o mayor entonces se actualiza pues significa la recepción
   --del recibido de la central.

    IF @nNoEnvioUltimo = 0 
       BEGIN
           --**********************************************
			BEGIN TRY           
			  INSERT INTO   SttProcesarEnvioES(NoEnvio,nSteCajaId,EstadoEnvio,SsgCuentaID,FechaGenera)  
			  VALUES (@nNoEnvioUltimo,@nSteCajaId,2,@SsgCuentaID,GETDATE())




--			IF @@ERROR <> 0
--			BEGIN
--				ROLLBACK TRANSACTION UpdateLocal
--				RETURN
--			END
---***************************************
			END TRY
			BEGIN CATCH
--Ojo
--				ROLLBACK TRANSACTION UpdateLocal
				SELECT 'Error al intentar guardar el número de envio en la tabla SttProcesarEnvioES  ' + ERROR_MESSAGE()
				RETURN
			END CATCH
-----*********************************************************
            BEGIN TRY
				  INSERT INTO SttProcesarParametroES(CarpetaTempo,CarpetaTempoUSBCopia,nSteCajaId,EstadoEnvio,NoEnvioUltimo,ExportarnSteCajaId,BaseTemporal,CarpetaTxtFisica,CarpetaTxtLogica)
				  VALUES(@CarpetaTempo,@CarpetaTempoUSBCopia,@nSteCajaId,0,0,@nSteCajaId,'SMCU0-Exportacion',@CarpetaTxtFisica,@CarpetaTxtLogica)            
--		IF @@ERROR <> 0
--		BEGIN
--			ROLLBACK TRANSACTION UpdateLocal
--			RETURN
--		END
---***************************************
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION UpdateLocal
				SELECT 'Error al intentar guardar los datos de parámetros en la tabla SttProcesarParametroES ' + ERROR_MESSAGE()
				RETURN
			END CATCH
-----*********************************************************

			

       END 
    IF @nSteCajaId> 0  --Actualiza como recibido para local 
      BEGIN
        BEGIN TRY 
    		UPDATE SttProcesarEnvioES Set EstadoEnvio=2 Where nSteCajaId =@nSteCajaId And NoEnvio = @nNoEnvioUltimo 
---***************************************
		END TRY
		BEGIN CATCH
--Ojo
				ROLLBACK TRANSACTION UpdateLocal
				SELECT 'Error al intentar el estado de envio a recibido (EstadoEnvio=2) en la tabla SttProcesarEnvioES ' + ERROR_MESSAGE()
				RETURN
		END CATCH
-----*********************************************************
			


--			IF @@ERROR <> 0
--			BEGIN
--				ROLLBACK TRANSACTION UpdateLocal
--				RETURN
--			END
    ----*******************************
		BEGIN TRY   
			UPDATE SttProcesarParametroES Set EstadoEnvio=0 Where nSteCajaId= @nSteCajaId 
--			IF @@ERROR <> 0
--			BEGIN
--				ROLLBACK TRANSACTION UpdateLocal
--				RETURN
--			END
        
    		
---***************************************
		END TRY
		BEGIN CATCH
--Ojo
				ROLLBACK TRANSACTION UpdateLocal
				SELECT 'Error al intentar el estado de envio a recibido (EstadoEnvio=2) en la tabla SttProcesarEnvioES ' + ERROR_MESSAGE()
				RETURN
		END CATCH
-----*********************************************************

      END
    
































IF @nNoEnvioUltimo > 0  --Actualiza steCierreTrasladoValor en 1 el nProcesado 
      BEGIN
        BEGIN TRY 
    		UPDATE SteCierreTrasladoValor Set nAplicado=1 --Where nSteCajaId =@nSteCajaId 
---***************************************
		END TRY
		BEGIN CATCH
--Ojo
				ROLLBACK TRANSACTION UpdateLocal
				SELECT 'Error al intentar poner en 1 a  nAplicado en la tabla  SteCierreTrasladoValor' + ERROR_MESSAGE()
				RETURN
		END CATCH
    		

      END









--Ojo
	COMMIT TRANSACTION UpdateLocal
    SELECT '' 
    RETURN
END
