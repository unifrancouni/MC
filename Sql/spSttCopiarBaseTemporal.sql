USE [SMUSURA0-E3]
GO
/****** Object:  StoredProcedure [dbo].[spSttCopiarBaseTemporal]    Script Date: 12/17/2009 17:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Edgard Delgado
-- Create date: 2008-02-13
-- Description:	Actualizacion de Bases Locales
-- =============================================
CREATE PROCEDURE [dbo].[spSttCopiarBaseTemporal]
@CarpetaTxt as nvarchar(1000) 

AS
BEGIN
	SET NOCOUNT ON

    
	DECLARE @TablaDestino varchar(100)
	DECLARE @column_name varchar(4000), @delimiter char(2)
	DECLARE @SQLCmd varchar(8000)
    DECLARE @FileExists Int
    DECLARE @FileNameCompleto varchar(1000)



  




	SET @delimiter = ', '
   

   

    

	

    

	-- Deletes Data From Tables In Local DB
	DECLARE DeleteTableProcess CURSOR FOR 
	Select sNombreTablaDestino From SttProcesarTablasES 
	Where nProcesar = 1
	Order By nOrdenImportar asc;

	OPEN DeleteTableProcess

	FETCH NEXT FROM DeleteTableProcess
	INTO @TablaDestino

	WHILE @@FETCH_STATUS = 0
	BEGIN





SET @SQLCmd ='
BULK INSERT [SMCU0-EXPORTACION]..' + @TablaDestino + '
From '''+@CarpetaTxt  +  '\' + @TablaDestino + '.txt''
WITH 
    (   
		DATAFILETYPE = ''widechar'',
        FIELDTERMINATOR = ''|'', 
        ROWTERMINATOR = ''\n''
        
    )
'

		
        BEGIN TRY 
			EXEC (@SQLCmd)
PRINT @SQLCmd

        END TRY
        BEGIN CATCH
			SELECT  'Error al ingresar la Tabla [SMCU0-Exportacion]..' + @TablaDestino +' ' + ERROR_MESSAGE() --@nStbTablaId
			RETURN 


        END CATCH
		FETCH NEXT FROM DeleteTableProcess
		INTO @TablaDestino
        print @TablaDestino
	END
	CLOSE DeleteTableProcess
	DEALLOCATE DeleteTableProcess
    SELECT ''
	RETURN
END
