USE [SMUSURA0-E3]
GO
/****** Object:  StoredProcedure [dbo].[spSttBorrarBasesLocales]    Script Date: 12/17/2009 17:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Edgard Delgado
-- Create date: 2008-02-13
-- Description:	Actualizacion de Bases Locales
-- =============================================
CREATE PROCEDURE [dbo].[spSttBorrarBasesLocales]
@NoEnvio as int
AS
BEGIN
	SET NOCOUNT ON

    DECLARE @AgregarRegistroParametro int -- Es para ver si existe el registro de la tabla parametros
	DECLARE @TablaOrigen varchar(100), @TablaDestino varchar(100)
	DECLARE @column_name varchar(4000), @delimiter char(2)
	DECLARE @SQLCmd varchar(8000)



  SET @AgregarRegistroParametro = 0
  SELECT nSteCajaId From SttProcesarParametroES 
		IF @@ERROR <> 0
		BEGIN
			RETURN
		END

 IF @@ROWCOUNT = 0  --No existe registro de la tabla parametros
      BEGIN
        SET @AgregarRegistroParametro= 1 --Agregarlo es la primera vez
      END




	SET @delimiter = ', '
   

   

    

	BEGIN TRANSACTION UpdateLocal

    
    DELETE FROM SttProcesarParametroES
    DELETE FROM SttProcesarEnvioES
	-- Deletes Data From Tables In Local DB
	DECLARE DeleteTableProcess CURSOR FOR 
	Select sNombreTablaDestino From SttProcesarTablasES 
	Where nProcesar = 1
	Order By nOrdenImportar Desc;

	OPEN DeleteTableProcess

	FETCH NEXT FROM DeleteTableProcess
	INTO @TablaDestino

	WHILE @@FETCH_STATUS = 0
	BEGIN

     
		SET @SQLCmd = '
		DELETE FROM ' + @TablaDestino + ';
		'

--Esto es para no borrar la tabla de SteCaja puesto que esta se relaciona con 
--la tabla SttProcesarEnvioES en la base local
       IF @NoEnvio =0  Or (@NoEnvio>0 and @TablaDestino<>'SteCaja') 
        BEGIN
			EXEC (@SQLCmd)
			IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION UpdateLocal
						RETURN
					END

			
        END 

		

		FETCH NEXT FROM DeleteTableProcess
		INTO @TablaDestino
	END
	CLOSE DeleteTableProcess
	DEALLOCATE DeleteTableProcess

    



	COMMIT TRANSACTION UpdateLocal

          --EXEC spSttCreaLoginDesarrollo 
END
