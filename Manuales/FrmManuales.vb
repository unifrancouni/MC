Imports system.IO
Imports System.Data

Public Class FrmManuales
    Dim strPath As String
    Dim objParametros As BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

    Private Sub FrmManuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "General")
            inicializarvariables()
            ObtenerSubDirectorios(strPath)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Sub inicializarvariables()
        'objParametros = New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        'objParametros.Filter = "nStbParametroId = 38" 'Manuales del Sistema.
        'objParametros.Retrieve()
        'If objParametros.Count > 0 Then
        '    strPath = objParametros("sValorParametro") 'Ruta de Manuales en el Servidor.
        'Else
        '    strPath = ""
        'End If
        strPath = My.Application.Info.DirectoryPath & "\Manuales"
    End Sub

    Sub ObtenerSubDirectorios(ByVal strPath As String)
        Try
            'Declaracion de variables
            'Variables tipo archivos y directorios
            Dim objArchivoInfo As FileInfo
            Dim objDirectorioInfo As DirectoryInfo

            'Variables tipo datatable y datorow
            Dim objSubDirectoriosDT As DataTable
            Dim objSubDirectorioDR As DataRow

            Dim objArchivosDT As New DataTable
            Dim objArchivosDR As DataRow

            'Variable tipo dataset
            Dim dsManuales As New Data.DataSet

            Dim i As Integer = 0
            If strPath.Trim = "" Then
                MsgBox("El Path a los Manules no esta Registrado en la Base de Datos " & _
                InfoSistema.DBName, MsgBoxStyle.Critical)
                Exit Sub
            End If

            'Agregando columnas
            With objArchivosDT.Columns
                .Add(New DataColumn("ObjSubDirID"))
                .Add(New DataColumn("Archivos"))
                .Add(New DataColumn("Path"))
            End With

            objDirectorioInfo = New DirectoryInfo(strPath)
            If Not objDirectorioInfo.Exists Then
                MsgBox("El Path a los Manules no es válido ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objSubDirectoriosDT = New DataTable

            With objSubDirectoriosDT.Columns
                .Add(New DataColumn("SubDirID"))
                .Add(New DataColumn("Manuales"))
                .Add(New DataColumn("Path"))

            End With

            'Recorriendo el directorio Manuales para obtener los 
            'subdirectorios
            For Each objDirectorioInfo In objDirectorioInfo.GetDirectories("*.*")
                Dim AuxArrDirs() As String
                AuxArrDirs = Split(objDirectorioInfo.FullName, "\")
                objSubDirectorioDR = objSubDirectoriosDT.NewRow
                objSubDirectorioDR("SubDirID") = i + 1
                objSubDirectorioDR("Manuales") = AuxArrDirs(UBound(AuxArrDirs))
                objSubDirectorioDR("Path") = objDirectorioInfo.FullName

                objSubDirectoriosDT.Rows.Add(objSubDirectorioDR)

                '---------------------
                objDirectorioInfo = New DirectoryInfo(objDirectorioInfo.FullName)
                'recorriendo los archivos de contenidos por subdirectorio
                For Each objArchivoInfo In objDirectorioInfo.GetFiles("*.*")
                    Dim AuxArrArchs() As String
                    AuxArrArchs = Split(objArchivoInfo.FullName, "\")
                    objArchivosDR = objArchivosDT.NewRow
                    objArchivosDR("ObjSubDirID") = i + 1
                    objArchivosDR("Archivos") = AuxArrArchs(UBound(AuxArrArchs))
                    objArchivosDR("Path") = objArchivoInfo.FullName

                    objArchivosDT.Rows.Add(objArchivosDR)

                Next
                i += 1
            Next

            'Definiendo nombres a los datatables
            objSubDirectoriosDT.TableName = "objSubDirectoriosDT"
            objArchivosDT.TableName = "objArchivosDT"

            'Agregando datatables al dataset
            If dsManuales.Tables.Contains("objSubDirectoriosDT") Then
                dsManuales.Tables("objSubDirectoriosDT").Clear()
            End If
            dsManuales.Tables.Add(objSubDirectoriosDT)

            If dsManuales.Tables.Contains("objArchivosDT") Then
                dsManuales.Tables("objArchivosDT").Clear()
            End If
            dsManuales.Tables.Add(objArchivosDT)
            'dsManuales.Tables("objArchivosDT").Merge("objArchivosDT")

            'Estableciendo relacion entre las tablas 
            If dsManuales.Relations.Contains("RelSubArchs") = False Then
                dsManuales.Relations.Add("RelSubArchs", _
                dsManuales.Tables("objSubDirectoriosDT").Columns("SubDirID"), _
                dsManuales.Tables("objArchivosDT").Columns("ObjSubDirID"), False)
            End If

            'Asignando al DataSource la Fuente de Datos
            Me.grdManuales.DataSource = dsManuales.Tables("objSubDirectoriosDT")
            Me.grdManHijos.DataSource = dsManuales.Tables("objSubDirectoriosDT")
            Me.grdManHijos.DataMember = dsManuales.Relations("RelSubArchs").RelationName
            Me.grdManHijos.Splits(0).ExtendRightColumn = True
            Me.grdManHijos.Splits(0).DisplayColumns("ObjSubDirID").Visible = False
            Me.grdManHijos.Splits(0).DisplayColumns("Path").Visible = False
            'Me.grdManHijos.Splits(0).DisplayColumns("Nombre").Width = 150

            Me.grdManuales.Splits(0).ExtendRightColumn = True
            Me.grdManuales.Splits(0).DisplayColumns("SubDirID").Visible = False
            Me.grdManuales.Splits(0).DisplayColumns("Path").Visible = False

            Me.grdManuales.Columns("Archivos").SortDirection = C1.Win.C1TrueDBGrid.SortDirEnum.Ascending
            'Me.grdManuales.Splits(0).DisplayColumns("Path").Style.
            'Me.grdManuales.Splits(0).DisplayColumns("Nombre").Width = 150

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdManHijos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdManHijos.DoubleClick
        Try
            Dim procProceso As New Process
            procProceso.Start(Me.grdManHijos.Columns("Path").Value)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolCerrar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolRefrescar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolRefrescar.Click
        Try
            ObtenerSubDirectorios(strPath)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class
