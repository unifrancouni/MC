Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.OleDb

Public Class FrmSccDescargaPorFuente
    Dim XdtTabla As BOSistema.Win.XDataSet.xDataTable
    Dim XdsGenera As BOSistema.Win.XDataSet
    Dim XdsCaja As BOSistema.Win.XDataSet

    Dim XCajaId As Integer
    Dim CarpetaGenera As String
    Dim XCarpetaTempoUSBCopia As String
    Dim XEstadoEnvio As Integer
    Dim XtiempoInicial, XtiempoFinal, XtiempoZip As Date

    Dim mNomRep As String
    Dim XCarpetaRespaldoCarga As String
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum
    Public Property ColorVentana() As String
        Get
            Return mNomRep
        End Get
        Set(ByVal value As String)
            mNomRep = value
        End Set
    End Property
    Public AccionUsuario As AccionBoton
    Private Sub CmbCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim XcUsuario As New BOSistema.Win.XComando
        Dim strSQL As String = ""


        'Localiza ID de Usuario:

        Dim Conex As New DSSistema.DSSistema
        Dim myConnectionString As String


        myConnectionString = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName

        'Dim myConnectionString As String _
        '     = "User ID=sa;password=sa;Initial Catalog=Northwind;Data Source=mySQLServer"
        Dim mySelectQuery As String _
            = "Select * From SclFichaNotificacionDetallePrueba Where nSclFichaNotificacionDetalleID=0"
        Dim myXMLfile As String = "c:\mySchema.xml"

        Dim con As New SqlConnection(myConnectionString)
        Dim daCust As New SqlDataAdapter(mySelectQuery, con)
        Dim ds As New DataSet()
        daCust.Fill(ds, "Cust")


        'Dim myFileStream As New System.IO.FileStream _
        '(myXMLfile, System.IO.FileMode.Open)
        'Dim MyXmlTextWriter As New System.Xml.XmlTextWriter _
        '   (myFileStream, System.Text.Encoding.Unicode)
        Try
            'Write the XML along with the inline schema (default).


            'ds.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            ds.ReadXml(myXMLfile)

            daCust.Fill(ds)

            'DataGridView1.DataSource = ds
            'DataGridView1.DataMember = "Cust"

            'Write the XML only.
            'ds.WriteXml(MyXmlTextWriter, XmlWriteMode.IgnoreSchema)
            'Write the XML as a DiffGram.
            'ds.WriteXml(MyXmlTextWriter, XmlWriteMode.DiffGram)
            MsgBox("Load complete")


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            'MyXmlTextWriter.Close()
            'myFileStream.Close()
        End Try
    End Sub

    Private Sub FrmSccDescargaPorFuente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                'ObjFuenteFRdr.Close()
                'ObjFuenteFRdr = Nothing
            Else
                e.Cancel = True
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    

    Private Sub FrmDescarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            AccionUsuario = AccionBoton.BotonNinguno
            InicializaVariables()
            grpPresentaProceso.Visible = False
            CargarParametros()
            If XCajaId <> -1 Then
                CargarPrograma(XCajaId)
            End If
            CargarUnidades()
            CargarGenerados()





            Me.cdeFechaGenera.Value = Now
            Me.cdeFechaGenera.Enabled = False
            Me.Text = "Envío de Información de Créditos CARUNA"


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub




    Private Sub CargarUnidades()
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()

        Dim d As DriveInfo
        Me.cboUnidad.Items.Clear()
        For Each d In allDrives
            If d.DriveType = DriveType.Removable And Trim(d.Name) <> "A:\" And Trim(d.Name) <> "B:\" Then ' And d.IsReady Then
                Me.cboUnidad.Items.Add(d.Name)
            End If
        Next
        If Me.cboUnidad.Items.Count > 0 Then
            Me.cboUnidad.SelectedIndex = 0
        End If
    End Sub
    Private Function TamanoUnidad(ByVal NombreUnidad As String)
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()

        Dim d As DriveInfo
        For Each d In allDrives
            If Trim(d.Name) = Trim(NombreUnidad) Then
                Return d.TotalFreeSpace
            End If
        Next
        Return -1
    End Function

    '----------------------------------------------------------------------------------------------
    'Permite la carga en el combo de los programas que se encuentran configurados para enviar la
    'información de las socias 
    '------------------------------------------------------------------------------------------------
    Private Sub CargarPrograma(ByVal intPrograma As Integer)
        Try
            Dim Strsql As String

            Me.cbFuente.ClearFields()
            Strsql = "SELECT     nScnFuenteFinanciamientoID, sCodigo, sNombre                FROM  dbo.ScnFuenteFinanciamiento  Where nScnFuenteFinanciamientoID= 5 Order By SNombre"
            'If intPrograma = 0 Then
            '    'Strsql = "SELECT     nSttProgramasExternosID, sDescripcionPrograma,1 As Orden FROM dbo.SttProgramasExternos WHERE(nCerrada = 0)"
            '    Strsql = "SELECT     nScnFuenteFinanciamientoID, sCodigo, sNombre                FROM  dbo.ScnFuenteFinanciamiento Order By SNombre"

            'Else
            '    Strsql = "SELECT     nSttProgramasExternosID, sDescripcionPrograma,1 As Orden FROM dbo.SttProgramasExternos WHERE(nCerrada = 0) And "

            '    Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden " & _
            '             " FROM         dbo.StbPersona INNER JOIN " & _
            '             "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " & _
            '             " WHERE(dbo.SteCaja.nCerrada = 0) And   dbo.SteCaja.nSteCajaID =" & intPrograma & _
            '             " And  dbo.SteCaja.nSteCajaID Not in (Select nSteCajaID From SttProgramasExternosCajas Where nCerrada=0 )  Order By dbo.SteCaja.sDescripcionCaja "

            'End If

            '" WHERE (a.nActivo = 1 And a.sCodCargo = '04') " & _

            If XdsCaja.ExistTable("Caja") Then
                XdsCaja("Caja").ExecuteSql(Strsql)
            Else
                XdsCaja.NewTable(Strsql, "Caja")
                XdsCaja("Caja").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cbFuente.DataSource = XdsCaja("Caja").Source
            Me.cbFuente.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cbFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            'Me.cbFuente.Splits(0).DisplayColumns("Orden").Visible = False
            'Configurar el combo
            Me.cbFuente.Splits(0).DisplayColumns("sNombre").Width = 60

            Me.cbFuente.Columns("sNombre").Caption = "Fuente"

            Me.cbFuente.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            If Me.cbFuente.ListCount > 0 Then
                Me.cbFuente.SelectedIndex = 0
            End If
            'If Me.cboCaja.ListCount > 0 And intCaja = 0 Then
            '    Me.XdsCaja("Caja").AddRow()
            '    Me.XdsCaja("Caja").ValueField("sDescripcionCaja") = "Todos"
            '    Me.XdsCaja("Caja").ValueField("nSteCajaID") = 0
            '    Me.XdsCaja("Caja").ValueField("Orden") = 0
            '    Me.XdsCaja("Caja").UpdateLocal()
            '    Me.XdsCaja("Caja").Sort = "Orden,nSteCajaID asc"
            '    Me.cboCaja.SelectedIndex = 0
            'Else
            '    Me.cboCaja.SelectedIndex = 0
            '    Me.cboCaja.Enabled = False
            'End If




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub




    Private Sub CargarGenerados()
        Try
            Dim Strsql As String

            Strsql = " SELECT dbo.SttProcesarEnvioESCARUNA.nScnFuenteFinanciamientoID, dbo.ScnFuenteFinanciamiento.sNombre ,    dbo.SttProcesarEnvioESCARUNA.NoEnvio,   " & _
                     " dbo.SttProcesarEnvioESCARUNA.EstadoEnvio, " & _
                     " CASE WHEN  EstadoEnvio = 1 THEN 'Generada' WHEN  EstadoEnvio = 2 THEN ' Enviada'  END AS DesEstadoEnvio ," & _
                     "  dbo.SttProcesarEnvioESCARUNA.FechaGenera, dbo.SsgCuenta.Login " & _
                     " FROM dbo.SttProcesarEnvioESCARUNA INNER JOIN " & _
                     " dbo.ScnFuenteFinanciamiento ON dbo.SttProcesarEnvioESCARUNA.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID INNER JOIN " & _
                     " dbo.SsgCuenta ON dbo.SttProcesarEnvioESCARUNA.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID " & _
                     " Where dbo.SttProcesarEnvioESCARUNA.nScnFuenteFinanciamientoID=  " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & _
                     " Order By NoEnvio Desc  "

            If XdsGenera.ExistTable("Lote") Then
                XdsGenera("Lote").ExecuteSql(Strsql)
            Else
                XdsGenera.NewTable(Strsql, "Lote")
                XdsGenera("Lote").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.gridGenerados.DataSource = XdsGenera("Lote").Source


            'Actualizando el caption de los GRIDS
            Me.gridGenerados.Caption = " Listado de Envios(" + Me.gridGenerados.RowCount.ToString + " registros)"
            FormatoLote()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarParametros()
        Try

            Dim XcomUpdate As New BOSistema.Win.XComando
            Dim XGeneradosTotal As Integer






            Dim Conex As New DSSistema.DSSistema
            Dim conexion As New SqlConnection()
            Dim RegPar As Integer
            Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
            conexion.ConnectionString = myConnectionString

            XEstadoEnvio = -1

            XCajaId = -1
            CarpetaGenera = ""
            XCarpetaTempoUSBCopia = ""
            RegPar = 0
            XGeneradosTotal = 0
            XGeneradosTotal = XcomUpdate.ExecuteScalar(" Select count(*)As Total From  SttProcesarEnvioESCARUNA Where EstadoEnvio<>2")
            If XGeneradosTotal > 0 Then
                XcomUpdate.ExecuteScalar(" Update SttProcesarParametroES Set EstadoEnvio=1")
            Else
                XcomUpdate.ExecuteScalar(" Update SttProcesarParametroES Set EstadoEnvio=0")
            End If

            Dim lectorDatos As SqlDataReader
            conexion.Open()
            Dim ComandoB As New SqlCommand("Select * From  SttProcesarParametroES", conexion)
            lectorDatos = ComandoB.ExecuteReader


            While lectorDatos.Read
                XCajaId = IIf(IsDBNull(lectorDatos("nScnFuenteFinanciamientoID")), 0, lectorDatos("nScnFuenteFinanciamientoID")) 'lectorDatos("nSteCajaId")
                CarpetaGenera = lectorDatos("CarpetaTempo")
                XCarpetaTempoUSBCopia = lectorDatos("CarpetaTempoUSBCopia")
                XEstadoEnvio = lectorDatos("EstadoEnvio") 'Es el estado de envio
                XCarpetaRespaldoCarga = IIf(IsDBNull(lectorDatos("CarpetaRespaldoCarga")), "", lectorDatos("CarpetaRespaldoCarga"))
                RegPar = RegPar + 1
            End While
            lectorDatos.Close()
            If XCajaId = -1 Then
                grpGenera.Enabled = False
            End If
            If RegPar > 1 Then
                MsgBox("Debe existir solo un registro en la tabla SttProcesarParametroES.", MsgBoxStyle.Information)
                grpGenera.Enabled = False
            End If

            'If XEstadoEnvio <> 0 And XCajaId <> 0 Then ' No aplica para central 
            'MsgBox("El Ultimo  lote generado o no ha sido guardado o no ha sido indicado como recepcionado en Central ", MsgBoxStyle.Information)
            'cmbProcesar.Enabled = False
            'Else
            'cmbProcesar.Enabled = True
            'End If




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub InicializaVariables()
        Try
            XdsGenera = New BOSistema.Win.XDataSet
            XdsCaja = New BOSistema.Win.XDataSet
            Me.gridGenerados.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FormatoLote()
        Try
            ''Configuracion del Grid Lote

            Me.gridGenerados.Splits(0).DisplayColumns("EstadoEnvio").Visible = False
            Me.gridGenerados.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.gridGenerados.Splits(0).DisplayColumns("sNombre").Visible = False


            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").Width = 80
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").Width = 140
            Me.gridGenerados.Splits(0).DisplayColumns("Login").Width = 200
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").Width = 80
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").Width = 220


            'Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").Width = 220

            ''Me.grdCierre.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.gridGenerados.Columns("NoEnvio").Caption = "No"
            Me.gridGenerados.Columns("FechaGenera").Caption = "Generado el "
            Me.gridGenerados.Columns("Login").Caption = "Login"
            'Me.gridGenerados.Columns("FechaEnvio").Caption = "Guardado"
            Me.gridGenerados.Columns("DesEstadoEnvio").Caption = "Estado"
            Me.gridGenerados.Columns("sNombre").Caption = "Fuente"

            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("Login").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("sNombre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center



            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim zip As New Chilkat.Zip()

        'Dim unlocked As Boolean
        'unlocked = zip.UnlockComponent("ZIP-TEAMBEAN_3988ED58913G")
        'If (Not unlocked) Then
        '    MsgBox("Failed to unlock Zip library")
        '    Exit Sub
        'End If

        'zip.NewZip("C:\TemporalPasaXML\test.zip")

        'zip.PasswordProtect = True
        'zip.SetPassword("MCBDTRNS732985")

        '' Append files to the AES Encrypted Zip.
        'Dim success As Boolean
        'zip.AppendFromDir = "C:\TemporalPasaXML"
        '' Add the entire directory tree.
        'success = zip.AppendFiles("*", True)
        'If (Not success) Then
        '    MsgBox(zip.LastErrorText)
        '    Exit Sub
        'End If

        '' Write the AES Encrypted Zip file.
        'success = zip.WriteZipAndClose()
        'If (Not success) Then
        '    MsgBox(zip.LastErrorText)
        'Else
        '    MsgBox("Zip OK!")
        'End If





        'success = zip.OpenZip("C:\TemporalPasaXML\test.zip")
        'If (success <> True) Then
        '    MsgBox(zip.LastErrorText)
        '    Exit Sub
        'End If


        ''  Set the password needed to unzip.
        ''  This password must match the password used when the zip
        ''  was created.
        'zip.SetPassword("MCBDTRNS732985")


        'Dim unzipCount As Long

        ''  Returns the number of files and directories unzipped.
        'unzipCount = zip.Unzip("c:\temp\aesUnzippedDir\")
        'If (unzipCount < 0) Then
        '    MsgBox(zip.LastErrorText)
        'Else
        '    MsgBox("Success!")
        'End If


    End Sub


    Private Sub GuardarArchivoZipBD()
        Dim XcomUpdate As New BOSistema.Win.XComando
        Dim NombreZipOrigen, NombreZipDestino, NombreArchivoRar As String
        Dim XUltimoEnvio As Integer
        Dim lectorDatos As SqlDataReader
        Dim XCmd As String

        Dim Xerror As String
        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
        conexion.ConnectionString = myConnectionString


        If Me.gridGenerados.RowCount = 0 Then
            MsgBox("No existe ningun numero de envio para guardar ", MsgBoxStyle.Information)
            Exit Sub
        End If


        conexion.Open()


        Dim ComandoBRegId As New SqlCommand("Select Top 1 * From  SttProcesarEnvioESCARUNA Where nScnFuenteFinanciamientoID= " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & "    Order by  NoEnvio desc   ", conexion)
        'lectorDatos.Close()
        lectorDatos = ComandoBRegId.ExecuteReader

        While lectorDatos.Read
            XUltimoEnvio = lectorDatos("NoEnvio")
        End While

        If XCajaId <> 0 And XUltimoEnvio = 0 Then
            MsgBox("Base Local no puede volver a enviar la carga inicial. Genera y envie de nuevo ", MsgBoxStyle.Information)
            Exit Sub
        End If



        'If Me.cboUnidad.Items.Count < 1 Then
        '    MsgBox("No se encuentra ningun USB conectado ", MsgBoxStyle.Information)
        '    Exit Sub
        'End If


        'If Trim(Me.cboUnidad.Text) = "" Then
        '    MsgBox("Seleccione el USB donde hara el guardado del archivo Zip", MsgBoxStyle.Information)
        '    Exit Sub
        'End If


        NombreZipOrigen = CarpetaGenera & "\ExportarCaja_" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & "_" & XUltimoEnvio & ".zip"   'Me.gridGenerados.Columns("NoEnvio").Value & ".zip"
        If Not System.IO.File.Exists(NombreZipOrigen) Then
            MsgBox("No se encontro el archivo zip " & NombreZipOrigen & " Elimine y vuelva a generar  ", MsgBoxStyle.Information)
            Exit Sub
        End If


        If XCajaId = 0 Then 'Si se esta generando desde la base central
            'NombreZipDestino = Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\" & Me.cbFuente.Columns("sNombre").Value & "_EnvioCentral(" & XUltimoEnvio & ").zip"

            'NombreZipDestino = XCarpetaRespaldoCarga & "\" & Me.cbFuente.Columns("sNombre").Value & Format(Day(Now), "##") & Format(Month(Now), "##") & Format(Year(Now), "####") & "_" & Format(Hour(Now), "##") & "_" & Format(Minute(Now), "##") & "_ENVIO_" & XUltimoEnvio & ".zip"
            NombreArchivoRar = "CARUNA_" & Format(Day(Now), "00") & Format(Month(Now), "00") & Format(Year(Now), "0000") & "_" & Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Now, "tt") & "_ENVIO_" & XUltimoEnvio & ".zip"
            NombreZipDestino = XCarpetaRespaldoCarga & "\CARUNA\" & NombreArchivoRar

            If Not System.IO.Directory.Exists(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\") Then
                System.IO.Directory.CreateDirectory(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\")
            End If
        Else





            'NombreZipDestino = Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\" & Me.cbFuente.Columns("sNombre").Value & "_EnvioLocal(" & XUltimoEnvio & ").zip"

            'NombreZipDestino = XCarpetaRespaldoCarga & "\" & Me.cbFuente.Columns("sNombre").Value & Format(Day(Now), "##") & Format(Month(Now), "##") & Format(Year(Now), "####") & "_" & Format(Hour(Now), "##") & ":" & Format(Minute(Now), "##") & "_ENVIO_" & XUltimoEnvio & ".zip"
            'NombreZipDestino = XCarpetaRespaldoCarga & "\CARUNA_" & Format(Day(Now), "00") & Format(Month(Now), "00") & Format(Year(Now), "0000") & "_" & Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Now, "tt") & "_ENVIO_" & XUltimoEnvio & ".rar"

            NombreArchivoRar = "CARUNA_" & Format(Day(Now), "00") & Format(Month(Now), "00") & Format(Year(Now), "0000") & "_" & Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Now, "tt") & "_ENVIO_" & XUltimoEnvio & ".zip"
            NombreZipDestino = XCarpetaRespaldoCarga & "\CARUNA\" & NombreArchivoRar

            If Not System.IO.Directory.Exists(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\") Then
                System.IO.Directory.CreateDirectory(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\")
            End If
        End If


        'System.IO.File.Delete(NombreZipDestino)

        Dim InfoArchivo As New System.IO.FileInfo(NombreZipOrigen)
        'If InfoArchivo.Length > TamanoUnidad(Me.cboUnidad.Text) Then
        '    MsgBox("No Existe el suficiente espacio en " & Trim(Me.cboUnidad.Text) & " Elimine archivos de su dispositivo de almacenamiento y vuelva a generar  ", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        Me.LblConteo.Text = "Copiando en el Servidor"
        Me.LblArchivo.Text = ""
        Me.Refresh()

        'XCarpetaRespaldoCarga
        If System.IO.File.Exists(NombreZipDestino) Then
            System.IO.File.Delete(NombreZipDestino)
        End If


        System.IO.File.Copy(NombreZipOrigen, NombreZipDestino)
        PrBarProceso.Value = (PrBarProceso.Maximum * 2) / 3

        Me.LblConteo.Text = "Eliminando carpeta temporal"
        Me.LblArchivo.Text = ""
        Me.Refresh()
        If System.IO.Directory.Exists(CarpetaGenera) = True Then
            System.IO.Directory.Delete(CarpetaGenera, True)
            System.IO.Directory.CreateDirectory(CarpetaGenera)
        End If


        If XCajaId <> 0 Then ' Si es local indica que ha sido guardada 
            XcomUpdate.ExecuteScalar("Update SttProcesarEnvioESCARUNA Set  EstadoEnvio = 1,  ArchivoRar='" & Trim(NombreArchivoRar) & "'    Where NoEnvio=" & XUltimoEnvio & " And nScnFuenteFinanciamientoID=" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)
        Else ' Si es Central No hace nada solo cuando es el codigo cero
            If XUltimoEnvio >= 0 Then
                XcomUpdate.ExecuteScalar("Update SttProcesarEnvioESCARUNA Set  EstadoEnvio = 1  ,ArchivoRar='" & Trim(NombreArchivoRar) & "'  Where NoEnvio=" & XUltimoEnvio & " And nScnFuenteFinanciamientoID=" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)   
            End If
        End If
        PrBarProceso.Value = PrBarProceso.Maximum
        'MsgBox("Generación de Lote completada Tiempo de ejecución:" & DateDiff(DateInterval.Second, Now, XtiempoInicial) & " Segundos " & Chr(13) & " Tiempo de Empaquetado  " & DateDiff(DateInterval.Second, XtiempoZip, Now) & " Segundos ", MsgBoxStyle.Information)

        XError = ""

        'Dim Xcomando2 As New SqlCommand("EXEC spSttCopiarBaseTemporal '" & Trim(XCarpetaTxtFisica) & "\" & XSubCarpeta & "'", conexion)
        'XError = XComando.ExecuteScalar("EXEC spSttCopiarBaseTemporal '" & Trim(XCarpetaTxtFisica) & "\" & XSubCarpeta & "'")
        'XError = Xcomando2.ExecuteScalar
        XCmd = Chr(34) & "Update SttProcesarEnvioESCARUNA Set EstadoEnvio=1,ArchivoRar='" & Trim(NombreArchivoRar) & "' Where NoEnvio= " & XUltimoEnvio & Chr(34)
        Xerror = EjecutarComandoPasar(myConnectionString, "EXEC spSttEjecutarEnvioCARUNA " & XUltimoEnvio & "," & Trim(XCmd))
        If Trim(XError) <> "" Then
            MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
            grpPresentaProceso.Visible = False
            cmdCancelar.Enabled = True
            Exit Sub
        End If

        MsgBox("Se guardo en la carpeta del servidor indicado como No : " & XUltimoEnvio & IIf(XUltimoEnvio = 0, " Carga Inicial", "") & Chr(13) & " Caja : " & Me.cbFuente.Text & Chr(13) & " En la carpeta (" & NombreZipDestino & ")" & Chr(13) & "Tiempo de la descarga :" & DateDiff(DateInterval.Second, XtiempoInicial, Now) & " Segundos ", MsgBoxStyle.Information)
        'CargarParametros()
        CargarGenerados()

    End Sub
    Private Sub EnviarArchivoCARUNA()
        Dim XcomUpdate As New BOSistema.Win.XComando
        Dim NombreZipOrigen, NombreZipDestino, NombreArchivoRar As String
        Dim XUltimoEnvio As Integer
        Dim lectorDatos As SqlDataReader

        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
        Dim Xerror As String
        conexion.ConnectionString = myConnectionString


        If Me.gridGenerados.RowCount = 0 Then
            MsgBox("No existe ningun numero de envio para guardar ", MsgBoxStyle.Information)
            Exit Sub
        End If


        conexion.Open()


        Dim ComandoBRegId As New SqlCommand("Select Top 1 * From  SttProcesarEnvioESCARUNA Where nScnFuenteFinanciamientoID= " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & "    Order by  NoEnvio desc   ", conexion)
        'lectorDatos.Close()
        lectorDatos = ComandoBRegId.ExecuteReader
        NombreArchivoRar = ""
        While lectorDatos.Read
            XUltimoEnvio = lectorDatos("NoEnvio")
            NombreArchivoRar = lectorDatos("ArchivoRar")
        End While

        If XCajaId <> 0 And XUltimoEnvio = 0 Then
            MsgBox("Base Local no puede volver a enviar la carga inicial. Genera y envie de nuevo ", MsgBoxStyle.Information)
            Exit Sub
        End If



        'If Me.cboUnidad.Items.Count < 1 Then
        '    MsgBox("No se encuentra ningun USB conectado ", MsgBoxStyle.Information)
        '    Exit Sub
        'End If


        'If Trim(Me.cboUnidad.Text) = "" Then
        '    MsgBox("Seleccione el USB donde hara el guardado del archivo Zip", MsgBoxStyle.Information)
        '    Exit Sub
        'End If


        NombreZipOrigen = XCarpetaRespaldoCarga & "\CARUNA\" & NombreArchivoRar  'CarpetaGenera & "\ExportarCaja_" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & "_" & XUltimoEnvio & ".rar"   'Me.gridGenerados.Columns("NoEnvio").Value & ".zip"
        If Not System.IO.File.Exists(NombreZipOrigen) Then
            MsgBox("No se encontro el archivo zip " & NombreZipOrigen & " Vuelva a generar  ", MsgBoxStyle.Information)
            Exit Sub
        End If


        If XCajaId = 0 Then 'Si se esta generando desde la base central
            'NombreZipDestino = Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\" & Me.cbFuente.Columns("sNombre").Value & "_EnvioCentral(" & XUltimoEnvio & ").zip"

            'NombreZipDestino = XCarpetaRespaldoCarga & "\" & Me.cbFuente.Columns("sNombre").Value & Format(Day(Now), "##") & Format(Month(Now), "##") & Format(Year(Now), "####") & "_" & Format(Hour(Now), "##") & "_" & Format(Minute(Now), "##") & "_ENVIO_" & XUltimoEnvio & ".zip"
            'NombreArchivoRar = "CARUNA_" & Format(Day(Now), "00") & Format(Month(Now), "00") & Format(Year(Now), "0000") & "_" & Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Now, "tt") & "_ENVIO_" & XUltimoEnvio & ".rar"
            NombreZipDestino = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CARUNA\" & NombreArchivoRar

            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\CARUNA\") Then
                System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & "\CARUNA\")
                'Else
                '    System.IO.Directory.Delete(My.Computer.FileSystem.SpecialDirectories.Desktop & "\CARUNA\", True)
                '    System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & "\CARUNA\")
            End If
        Else





            'NombreZipDestino = Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\" & Me.cbFuente.Columns("sNombre").Value & "_EnvioLocal(" & XUltimoEnvio & ").zip"

            'NombreZipDestino = XCarpetaRespaldoCarga & "\" & Me.cbFuente.Columns("sNombre").Value & Format(Day(Now), "##") & Format(Month(Now), "##") & Format(Year(Now), "####") & "_" & Format(Hour(Now), "##") & ":" & Format(Minute(Now), "##") & "_ENVIO_" & XUltimoEnvio & ".zip"
            'NombreZipDestino = XCarpetaRespaldoCarga & "\CARUNA_" & Format(Day(Now), "00") & Format(Month(Now), "00") & Format(Year(Now), "0000") & "_" & Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Now, "tt") & "_ENVIO_" & XUltimoEnvio & ".rar"

            NombreArchivoRar = "CARUNA_" & Format(Day(Now), "00") & Format(Month(Now), "00") & Format(Year(Now), "0000") & "_" & Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Now, "tt") & "_ENVIO_" & XUltimoEnvio & ".rar"
            'NombreZipDestino = XCarpetaRespaldoCarga & "\" & NombreArchivoRar
            NombreZipDestino = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & NombreArchivoRar
            If Not System.IO.Directory.Exists(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\") Then
                System.IO.Directory.CreateDirectory(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\")
            End If
        End If


        If System.IO.File.Exists(NombreZipDestino) Then
            System.IO.File.Delete(NombreZipDestino)
        End If


        System.IO.File.Copy(NombreZipOrigen, NombreZipDestino)

        'If System.IO.Directory.Exists(CarpetaGenera) = True Then
        '    System.IO.Directory.Delete(CarpetaGenera, True)
        '    System.IO.Directory.CreateDirectory(CarpetaGenera)
        'End If


        If XCajaId = 0 Then ' Si es local indica que ha sido guardada 
            Xerror = EjecutarComandoPasar(myConnectionString, "EXEC spSttEjecutarEnvioRecepcionCARUNA " & XUltimoEnvio)
            If Trim(XError) <> "" Then
                MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If

            '    XcomUpdate.ExecuteScalar("Update SttProcesarEnvioESCARUNA Set  EstadoEnvio = 2 Where NoEnvio=" & XUltimoEnvio & " And nScnFuenteFinanciamientoID=" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)
            'Else ' Si es Central No hace nada solo cuando es el codigo cero
            '    If XUltimoEnvio = 0 Then
            '        XcomUpdate.ExecuteScalar("Update SttProcesarEnvioESCARUNA Set  EstadoEnvio = 2   Where NoEnvio=" & XUltimoEnvio & " And nScnFuenteFinanciamientoID=" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)   
            '    End If
        End If
        'PrBarProceso.Value = PrBarProceso.Maximum
        'MsgBox("Generación de Lote completada Tiempo de ejecución:" & DateDiff(DateInterval.Second, Now, XtiempoInicial) & " Segundos " & Chr(13) & " Tiempo de Empaquetado  " & DateDiff(DateInterval.Second, XtiempoZip, Now) & " Segundos ", MsgBoxStyle.Information)
        MsgBox("Se guardo en el escritorio el envio número :" & XUltimoEnvio & IIf(XUltimoEnvio = 0, " Carga Inicial", "") & Chr(13) & " Fuente : " & Me.cbFuente.Text, MsgBoxStyle.Information)
        CargarParametros()
        CargarGenerados()

    End Sub
    Private Sub CmbGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GuardarArchivoZipBD()
    End Sub
    Private Sub LeerXmlVers2()
        Dim Node As System.Xml.XmlNode
        'Dim objXMLDoc As Object = CreateObject("Microsoft.XMLDOM")
        Dim objXMLDoc As New System.Xml.XmlDocument
        'objXMLDoc.async = False
        objXMLDoc.Load("C:\vwSttExpSccTablaAmortizacion.Xml")

        Dim NodeList As System.Xml.XmlNodeList = objXMLDoc.DocumentElement.SelectNodes("Customers")
        objXMLDoc.DocumentElement.GetElementsByTagName("Customers")
        For Each Node In NodeList
            MsgBox(Node.InnerText)
        Next
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'GenerarXml()
        EscribirXmlToTxt("C:\SMUSURA0 21122007\SMUSURA0 21122007\SMUSURA0\bin\Debug\TmpProcesoCarga\StbDepartamento.Xml", "C:\SMUSURA0 21122007\SMUSURA0 21122007\SMUSURA0\bin\Debug\TmpProcesoCarga\StbDepartamento.txt", "StbDepartamento", "|")
    End Sub
    Private Sub EscribirXmlToTxt(ByVal FileXml As String, ByVal FileTxt As String, ByVal Nodo As String, ByVal Delimitador As String)
        Dim oXmlDocument As New System.Xml.XmlDocument
        Dim oRead As System.IO.StreamWriter
        Dim TiempoEscritura As Date
        Dim ColumnaNum, TotalColumnas As Integer


        'declara un nodo


        oXmlDocument.Load(FileXml)


        Dim oXmlNodeList As System.Xml.XmlNodeList = oXmlDocument.DocumentElement.SelectNodes(Nodo)
        Dim oXmlnode As System.Xml.XmlNode
        Dim oXmlElement As System.Xml.XmlElement

        'Console.WriteLine("El número de registros del conjunto de resultado es " & _
        'oXmlNodeList.Count.ToString & "." & vbCrLf)
        'System.IO.File.CreateText(FileTxt)

        oRead = New StreamWriter(FileTxt)


        'Dim out As String
        TotalColumnas = 0
        'For Each oXmlnode In oXmlNodeList

        '    For Each oXmlElement In oXmlnode
        '        TotalColumnas = TotalColumnas + 1
        '    Next
        '    Exit For
        'Next

        'oRead.AutoFlush = True
        TiempoEscritura = Now
        For Each oXmlnode In oXmlNodeList
            ColumnaNum = 1
            For Each oXmlElement In oXmlnode
                If ColumnaNum = 1 Then 'Or ColumnaNum = TotalColumnas Then
                    oRead.Write(oXmlElement.InnerText)
                Else
                    oRead.Write(Trim(Delimitador) & oXmlElement.InnerText)
                End If

                ColumnaNum = ColumnaNum + 1

            Next
            oRead.Write(Microsoft.VisualBasic.vbCrLf)
        Next
        oRead.Close()

        MsgBox("Tiempo de escritura archivo " & FileTxt & " Es " & DateDiff(DateInterval.Second, Now, TiempoEscritura))


    End Sub
    Private Sub EscribirDataSetToTxt(ByVal dsFuente As DataSet, ByVal FileTxt As String, ByVal Delimitador As String)




        Dim oRead As System.IO.StreamWriter
        Dim TiempoEscritura As Date
        Dim Fila As Long
        Dim Columna, ColumnaNum As Integer


        Try

            oRead = New StreamWriter(FileTxt, False, System.Text.Encoding.Unicode)




            TiempoEscritura = Now
            For Fila = 0 To dsFuente.Tables(0).Rows.Count - 1
                ColumnaNum = 0
                For Columna = 0 To dsFuente.Tables(0).Columns.Count - 1

                    If ColumnaNum = 0 Then 'Or ColumnaNum = TotalColumnas Then

                        If dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).GetType().ToString = "System.DateTime" Then
                            oRead.Write(Format(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum), "yyyy-MM-dd HH:mm:ss") & "." & _
                                PadRight(Format(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum), "fff"), 3, "0"))

                        ElseIf dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).GetType().ToString = "System.Boolean" Then
                            If dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum) Is Nothing Then
                                oRead.Write(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum))
                            Else
                                oRead.Write(IIf(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum) = True, 1, 0))
                            End If

                        Else
                            oRead.Write(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum))
                        End If



                        'If dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).GetType System.DateTime Then
                        'oRead.Write(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).ToString)
                        'oRead.Write(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).ToString)
                        'Else

                        'End If

                    Else

                        If dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).GetType().ToString = "System.DateTime" Then
                            oRead.Write(Trim(Delimitador) & Format(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum), "yyyy-MM-dd HH:mm:ss") & "." & _
                            PadRight(Format(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum), "fff"), 3, "0"))

                        ElseIf dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).GetType().ToString = "System.Boolean" Then
                            If dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum) Is Nothing Then
                                oRead.Write(Trim(Delimitador) & dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum))
                            Else
                                oRead.Write(Trim(Delimitador) & IIf(dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum) = True, 1, 0))
                            End If

                        Else
                            oRead.Write(Trim(Delimitador) & dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum))
                        End If
                        'oRead.Write(Trim(Delimitador) & dsFuente.Tables(0).Rows(Fila).Item(ColumnaNum).ToString)
                    End If

                    ColumnaNum = ColumnaNum + 1
                Next
                oRead.Write(Microsoft.VisualBasic.vbCrLf)
            Next
            oRead.Close()

        Catch ex As Exception
            Debug.Print("d")
        Finally
            Debug.Print("d")
        End Try

        'MsgBox("Tiempo de escritura archivo " & FileTxt & " Es " & DateDiff(DateInterval.Second, Now, TiempoEscritura))


    End Sub

    'Private Sub GenerarXml()

    '    'Creando la cadena de conexión
    '    Dim Conex As New DSSistema.DSSistema
    '    Dim cnnString As String = "Provider=SQLOLEDB;User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName

    '    'creamos un objeto SqlXmlcommand
    '    Dim cmd As Microsoft.Data.SqlXml.SqlXmlCommand = New Microsoft.Data.SqlXml.SqlXmlCommand(cnnString)

    '    'definimos la raíz de nuestro documento XML
    '    cmd.RootTag = "Customers"

    '    'establecemos el tipo de sentencia como un origen SQL
    '    cmd.CommandType = Microsoft.Data.SqlXml.SqlXmlCommandType.Sql

    '    'declaramos el origen del objeto SqlXmlCommand
    '    cmd.CommandText = "select * from vwSttExpSccTablaAmortizacion for xml auto"

    '    'creamos un objeto Stream para el XML a crear
    '    Dim MyFileStream As FileStream = New FileStream("C:\vwSttExpSccTablaAmortizacion.xml", FileMode.Create)

    '    'ejecutamos la sentencia, y lo almacenamos en el objeto MyFileStream
    '    cmd.ExecuteToStream(MyFileStream)

    '    'cerramos el stream
    '    MyFileStream.Close()

    '    'inicializamo un proceso para mostrar los resultados
    '    Dim proceso As Process = New Process

    '    'visualizamos los resultados en nuestro explorador de internet.
    '    'proceso.Start("IExplore.exe", "C:\QueryXMLCustomers.xml")

    '    'Emitimos un mensaje alertando la finalización 
    '    Console.WriteLine("proceso terminado...")
    'End Sub

    Private Function PadRight(ByVal sText As String, ByVal iSize As Integer, ByVal sChar As String) As String
        Dim sNew As String

        If Len(sText) > iSize Then                          'If the text is larger than the size
            sNew = sText                                    'Just return the text
        Else                                                'Text is smaller than the desired length
            sNew = StrDup(iSize, sChar)                    'Pad the temp string with the char
            sNew = sText & sNew.Substring(1, iSize - Len(sText))  'Build the new string
        End If

        PadRight = sNew                                     'Return the result

    End Function

    Private Function PadLeft(ByVal sText As String, ByVal iSize As Integer, ByVal sChar As String) As String
        Dim sNew As String

        If Len(sText) > iSize Then                          'If the text is larger than the size
            sNew = sText                                    'Just return the text
        Else                                                'Text is smaller than the desired length
            sNew = StrDup(iSize, sChar)                     'Pad the temp string with the char
            sNew = sNew.Substring(1, iSize - Len(sText)) & sText 'Build the new string
        End If

        PadLeft = sNew                                      'Return the result
    End Function
    Private Sub CmbRefrescarUnidar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbRefrescarUnidar.Click
        CargarUnidades()
    End Sub

    Private Sub cmbProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcesar.Click
        Dim zip As New Chilkat.Zip()
        'Dim zip As New Chilkat.Rar()
        Dim unlocked As Boolean
        Dim NombreZip As String
        Dim XNumEnvio As Integer
        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
        Dim XcUsuario As New BOSistema.Win.XComando
        Dim XComando As New BOSistema.Win.XComando
        Dim XTotalTablas As Integer
        Dim IdUsuario As Integer
        Dim myConnectionStringTemporalOLEDB As String = "Provider=SQLOLEDB;User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"



        'Dim mySelectQuery As String _
        '    = "Select * From SttProcesarTablasES Where nProcesar=1 "
        'Dim mySelectQueryCount As String _
        '            = "Select Count(*) AS TotalT  From SttProcesarTablasES Where nProcesar=1 And nTipoProceso=1"


        Dim myXMLfile As String = ""
        Dim myTXTfile As String = ""
        Dim myDelimita As String = "|"
        'Dim myFileStream As System.IO.FileStream ' _
        '("", System.IO.FileMode.Create)
        'Dim MyXmlTextWriter As System.Xml.XmlTextWriter  ' _
        '(myFileStream, System.Text.Encoding.Unicode)
        Dim EnviarXML As Integer = 0
        Dim EnviarTXT As Integer = 0


        'CargarUnidades()

        'If Me.cboUnidad.Items.Count < 1 Then
        '    MsgBox("No se encuentra ningun USB conectado ", MsgBoxStyle.Information)
        '    cmdCancelar.Enabled = True
        '    Exit Sub
        'End If

        conexion.ConnectionString = myConnectionString
        'Dim comando As New SqlCommand(mySelectQuery, conexion)


        ' Crea el DataReader
        Dim lectorDatos As SqlDataReader

        ' Conecta con la Base de Datos
        conexion.Open()



        Dim con As New SqlConnection(myConnectionString)
        Dim daCust As New SqlDataAdapter("", "")
        Dim daTabla As New SqlDataAdapter("", "")

        Dim ds As New DataSet()
        Dim dsTablas As New DataSet
        Dim dsParam As New DataSet
        Dim dsEnvio As New DataSet
        Dim dsCaja As New DataSet
        Dim Contador As Integer
        Dim XEstadoEnvioUltimo As Integer



        Try
            AccionUsuario = AccionBoton.BotonNinguno
            cmdCancelar.Enabled = False
            XtiempoInicial = Now
            IdUsuario = XcUsuario.ExecuteScalar("SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')")

            'XComando.Execute("Update  SttProcesarParametroES  Set ExportarnSteCajaId=" & Me.cboCaja.Columns("nSteCajaId").Value)
            Dim XCajaIngresada As Integer
            XCajaIngresada = XComando.ExecuteScalar("Select Count(*) As TablaIngresada FROM  dbo.SttProcesarFuentesParametroES  WHERE     nScnFuenteFinanciamientoID = " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value)
            If XCajaIngresada < 1 Then

                'XComando.ExecuteScalar("Insert into SttProcesarFuentesParametroES(nScnFuenteFinanciamientoID) values( " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & ")")
            End If


            XCajaIngresada = XComando.ExecuteScalar("Select Count(*) As TablaIngresada FROM  dbo.vwSttExpCARUNACredito ")
            If XCajaIngresada < 1 Then
                MsgBox("No existen Fichas Marcadas para generar.", MsgBoxStyle.Information)
                'XComando.ExecuteScalar("Insert into SttProcesarFuentesParametroES(nScnFuenteFinanciamientoID) values( " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & ")")
                Exit Sub
            End If



            Dim mySelectQuery As String _
                = "Select * From SttProcesarTablasESCARUNA Where nProcesar= 1 And nTipoProcesoExportar=1   " & IIf(XCajaId <> 0, " And nProcesarLocalExportar= 1 ", "")
            Dim mySelectQueryCount As String _
                        = "Select Count(*) AS TotalT From SttProcesarTablasESCARUNA Where nProcesar= 1 And nTipoProcesoExportar=1   " & IIf(XCajaId <> 0, " And nProcesarLocalExportar= 1 ", "")
            Dim comando As New SqlCommand(mySelectQuery, conexion)





            XNumEnvio = -1
            XEstadoEnvioUltimo = -1
            Dim XOperActualizarOAgregar As Integer
            Dim ComandoBRegId As New SqlCommand("Select Top 1 * From  SttProcesarEnvioESCARUNA Where nScnFuenteFinanciamientoID = " & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & "    Order by  NoEnvio desc   ", conexion)
            'lectorDatos.Close()
            lectorDatos = ComandoBRegId.ExecuteReader
            XOperActualizarOAgregar = 1
            While lectorDatos.Read
                XNumEnvio = lectorDatos("NoEnvio")
                XEstadoEnvioUltimo = lectorDatos("EstadoEnvio")
            End While




            ' El Numero de Envio 0 es la apertura de la base local. La que es mandada por la Central
            ' Se supone que solo debe comenzar a generar una vez que se ha agregado el registro 0 de la central a la local
            '  La Central solemente hace insert en este proceso una vez que es cuando se inicializa para cada caja local.
            If XCajaId <> 0 Then  'PARA BASES LOCALES 'Solo pueden generar registros en SttProcesarEnvioES las cajas locales.
                ' La central solo los carga con el Numero de Envio de las cajas locales.
                'Eso se debe hacer en el proceso de importacion cuando es la Central que lo hace.

                If XNumEnvio = -1 Then ' Se Supone que debe existir al menos el registro NoEnvio= 0
                    MsgBox("Base Local no ha sido inicializada. No se encuentra el NoEnvio=0. Solicite el acuse de Central de la Base de Datos Inicial")
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
                EnviarXML = 1
            Else
                EnviarTXT = 1
            End If





            If XCajaId = 0 Then 'Central solo puede exportar si ya se hizo el proceso de aplicacion de recibos
                'Dim TotalRecibosNoProcesados As Long
                'TotalRecibosNoProcesados = XComando.ExecuteScalar("Select Count(*) As TotalRecibosNoProcesados FROM  dbo.SccReciboOficialCaja WHERE     (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (nAplicado = 0) ")
                'TotalRecibosNoProcesados = XComando.ExecuteScalar("Select Count(*) As TotalRecibosNoProcesados FROM  dbo.SccReciboOficialCaja WHERE     nAplicado = 0 ")
                Dim ComandoBusca As New SqlCommand("Select Top 1 sNumSesion From  vwSttExpCARUNAFaltanAsignar ", conexion)
                Dim ComandoBusca2 As New SqlCommand("Select Top 1 sNumSesion From  dbo.SclFichaNotificacionCredito INNER JOIN dbo.SclFichaNotificacionDetalle ON dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoEnvioID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo_1.nStbValorCatalogoID WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '1') AND (StbValorCatalogo_1.sCodigoInterno <> '1') ", conexion)
                Dim ComandoBusca3 As New SqlCommand("Select Top 1 nSclFichaNotificacionID From  vwSttExpCARUNAMarcadasEnviadasAntes Where TotalEnviadas= TotalFichas", conexion)
                'lectorDatos.Close()
                lectorDatos.Close()
                lectorDatos = ComandoBusca.ExecuteReader




                'TotalRecibosNoProcesados = XComando.Execute("Select Count(*) As TotalRecibosNoProcesados FROM  vwSttExpCARUNAFaltanAsignar  ")

                If lectorDatos.HasRows Then
                    lectorDatos.Read()
                    MsgBox("Existen Fichas  en el Acta " + lectorDatos("sNumSesion") + " Modifique la información ", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If

                'TotalRecibosNoProcesados = XComando.ExecuteScalar("Select Count(*) As TotalRecibosNoProcesados   FROM         dbo.SclFichaNotificacionCredito INNER JOIN dbo.SclFichaNotificacionDetalle ON dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoEnvioID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo_1.nStbValorCatalogoID WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '1') AND (StbValorCatalogo_1.sCodigoInterno <> '1')")
                lectorDatos.Close()
                lectorDatos = ComandoBusca2.ExecuteReader

                If lectorDatos.HasRows Then
                    'MsgBox("Existen " & TotalRecibosNoProcesados & " Fichas  indicadas en el detalle para enviar pero que no han sido marcada para enviar en su maestro. Modifique la información ", MsgBoxStyle.Information)
                    MsgBox("Existen Fichas  en el Acta " + lectorDatos("sNumSesion") + " Modifique la información ", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
                lectorDatos.Close()
                lectorDatos = ComandoBusca3.ExecuteReader

                If lectorDatos.HasRows Then
                    'MsgBox("Existen " & TotalRecibosNoProcesados & " Fichas  indicadas en el detalle para enviar pero que no han sido marcada para enviar en su maestro. Modifique la información ", MsgBoxStyle.Information)
                    MsgBox("La Ficha con Código  " + lectorDatos("nSclFichaNotificacionID") + " Modifique la información ", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If



            End If












            lectorDatos.Close()
            lectorDatos = comando.ExecuteReader

            XTotalTablas = XcUsuario.ExecuteScalar(mySelectQueryCount)

            CarpetaGenera = XcUsuario.ExecuteScalar("SELECT CarpetaTempo From SttProcesarParametroES ")
            If IsDBNull(CarpetaGenera) Then
                CarpetaGenera = "C:\TmpPasarArchivosXML"
            End If

            If System.IO.Directory.Exists(CarpetaGenera) = True Then
                System.IO.Directory.Delete(CarpetaGenera, True)
                System.IO.Directory.CreateDirectory(CarpetaGenera)
            Else
                System.IO.Directory.CreateDirectory(CarpetaGenera)
            End If




            Contador = 1

            grpPresentaProceso.Visible = True
            grpPresentaProceso.BringToFront()

            PrBarProceso.Visible = True
            PrBarProceso.Maximum = 2 * (XTotalTablas + 2)
            PrBarProceso.Minimum = 0


            XComando.Execute("DELETE FROM SttListaCreditosEnviadosCARUNATMP")
            XComando.Execute("INSERT  INTO SttListaCreditosEnviadosCARUNATMP  SELECT     nCreditoId, sCodDepto, sDepto, SCodMunicipio, sMunicipio, sNumSesion, sNumeroCedula, dFechaDesembolso, nMontoCreditoAprobado,nPlazoAprobado, nTasaInteresCorrienteAnual, nTasaMoraAnual, sEstadoCredito, nFichaId, sObservaciones,nSclSociaID FROM         vwSttExpCARUNACredito  ")


            While lectorDatos.Read

                myXMLfile = CarpetaGenera & "\" & lectorDatos("sNombreTablaOrigen") & ".Xml"
                myTXTfile = CarpetaGenera & "\" & lectorDatos("sNombreTablaOrigen") & ".Txt"
                If Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value = 0 Then
                    daCust = New SqlDataAdapter(lectorDatos("sQueryTodos"), con)
                Else
                    daCust = New SqlDataAdapter(lectorDatos("sQueryFiltrado") + " " + Replace(lectorDatos("sQueryFiltradoCondicion"), "#ValorSustituir#", Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value), con)
                End If
                dsTablas = New DataSet()
                daCust.Fill(dsTablas, lectorDatos("sNombreTablaOrigen"))

                'If lectorDatos("sNombreTablaOrigen") = "Credito" Then
                '     myFileStream = New System.IO.FileStream _
                '        (myXMLfile, System.IO.FileMode.Create)

                '     MyXmlTextWriter = New System.Xml.XmlTextWriter _
                '(myFileStream, System.Text.Encoding.Unicode)
                '     Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
                '     Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
                '     Me.Refresh()

                '     dsTablas.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
                '     MyXmlTextWriter.Close()
                '     myFileStream.Close()

                'CreateCmdsAndUpdate(dsTablas, myConnectionStringTemporalOLEDB, "SELECT     nCreditoId, sCodDepto, sDepto, SCodMunicipio, sMunicipio, sNumSesion, sNumeroCedula, dFechaDesembolso, nMontoCreditoAprobado,nPlazoAprobado, nTasaInteresCorrienteAnual, nTasaMoraAnual, sEstadoCredito, nFichaId, sObservaciones FROM         vwSttExpCARUNACredito ", "SttListaCreditosEnviadosCARUNATMP")
                'End If


                '' Escribe el txt del dataset Para 
                If EnviarTXT = 1 Then
                    Me.LblConteo.Text = "Archivo txt " & Contador & " de un total de   " & XTotalTablas + 2
                    Me.LblArchivo.Text = "Archivo Generando : " & myTXTfile
                    Me.Refresh()
                    EscribirDataSetToTxt(dsTablas, myTXTfile, myDelimita)
                End If


                PrBarProceso.Value = Contador
                Contador = Contador + 1
                PrBarProceso.Value = Contador
                PrBarProceso.Refresh()
                Me.Refresh()

            End While


            '' '' ''     myXMLfile = CarpetaGenera & "\SttProcesarParametroES.Xml"
            '' '' ''     myTXTfile = CarpetaGenera & "\SttProcesarParametroES.Txt"
            '' '' ''     daCust = New SqlDataAdapter("Select * From SttProcesarParametroES ", con)
            '' '' ''     daCust.Fill(dsParam, "SttProcesarParametroES")

            '' '' ''     'If EnviarXML = 1 Then
            '' '' ''     myFileStream = New System.IO.FileStream _
            '' '' ''        (myXMLfile, System.IO.FileMode.Create)

            '' '' ''     MyXmlTextWriter = New System.Xml.XmlTextWriter _
            '' '' ''(myFileStream, System.Text.Encoding.Unicode)

            '' '' ''     Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            '' '' ''     Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
            '' '' ''     Me.Refresh()



            '' '' ''     dsParam.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            '' '' ''     MyXmlTextWriter.Close()
            '' '' ''     myFileStream.Close()
            'End If
            '' Escribe el txt del dataset Para 

            ' '' ''If EnviarTXT = 1 Then
            ' '' ''    Me.LblConteo.Text = "Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
            ' '' ''    Me.LblArchivo.Text = "Archivo Generando : " & myTXTfile
            ' '' ''    Me.Refresh()
            ' '' ''    EscribirDataSetToTxt(dsParam, myTXTfile, myDelimita)
            ' '' ''End If



            ' '' ''PrBarProceso.Value = Contador
            ' '' ''Contador = Contador + 1

            ' '' ''PrBarProceso.Refresh()
            ' '' ''Me.Refresh()




            If XCajaId = 0 Then  'PARA BASE CENTRAL  'Solo pueden generar registros en SttProcesarEnvioES las cajas locales.
                ' La central solo los carga con el Numero de Envio de las cajas locales.
                'Eso se debe hacer en el proceso de importacion cuando es la Central que lo hace.

                If XNumEnvio = -1 Then ' Se Supone que debe existir al menos el registro NoEnvio= 0
                    'MsgBox("Base Local no ha sido inicializada. No se encuentra el NoEnvio=0")
                    'cmdCancelar.Enabled = True
                    'Exit Sub
                    XNumEnvio = 0 'Es la primera vez que se genera un lote para ser enviado.
                    XEstadoEnvioUltimo = 0
                Else
                    If XNumEnvio <> 0 And XNumEnvio <> -1 Then
                        If XEstadoEnvioUltimo <> 2 Then ' No ha sido dado por recepcionado entonces se puede solo actualizar el estado del envio como generado de nuevo
                            XOperActualizarOAgregar = 2
                        Else
                            XNumEnvio = XNumEnvio + 1
                        End If
                    Else
                        XNumEnvio = XNumEnvio + 1
                    End If
                End If



                If XOperActualizarOAgregar = 1 Then 'Agregar
                    XComando.Execute("Insert Into SttProcesarEnvioESCARUNA(NoEnvio,FechaGenera,EstadoEnvio,SsgCuentaID,nScnFuenteFinanciamientoID) values(" & XNumEnvio & ",'" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd") & "' ,0," & IdUsuario & "," & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & ")")
                Else
                    XComando.Execute("Update SttProcesarEnvioESCARUNA Set FechaGenera = '" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd") & "' ,EstadoEnvio=0, SsgCuentaID=" & IdUsuario & " Where NoEnvio=" & XNumEnvio & " And nScnFuenteFinanciamientoID=" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value)

                End If
                ''Else 'PARA BASE CENTRAL 
                ''    'En este caso solamente puede generar el registro con NoEnvio= 0 para luego mandarse a la base local  

                ''    If XNumEnvio = -1 Then ' En este caso  NoEnvio= 0 para inicializar el envio a una base local de una caja
                ''        XNumEnvio = 0 'Es la primera vez que se genera un lote para ser enviado.
                ''        XEstadoEnvioUltimo = 1
                ''        XComando.Execute("Insert Into SttProcesarEnvioESCARUNA(NoEnvio,FechaGenera,EstadoEnvio,SsgCuentaID,nScnFuenteFinanciamientoID) values(" & XNumEnvio & ",'" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd") & "' ,0," & IdUsuario & "," & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & ")")
                ''    End If

            End If


            '            Dim ComandoG As New SqlCommand("Insert Into SttProcesarEnvioES(NoEnvio,FechaGenera,EstadoEnvio,SsgCuentaID ) values(" & XNumEnvio & ",'" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd") & "' ,0," & IdUsuario & ")", conexion)


            '           lectorDatos.Close()
            '          lectorDatos = ComandoG.ExecuteReader()


            'Guardar el ultimo registro de envio de la tabla sttProcesarEnvioEs para que ya sea en central se 
            'sepa el ultimo numero de envio para la localidad de caja

            ''Este archivo se usa como cabecera al momento de la carga inicial saber cual es la caja que se envia



            ' '' ''     myXMLfile = CarpetaGenera & "\ScnFuenteFinanciamiento.Xml"
            ' '' ''     daCust = New SqlDataAdapter("Select Top 1 * From ScnFuenteFinanciamiento " & " Where nScnFuenteFinanciamientoID =" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & " Order By nScnFuenteFinanciamientoID Desc ", con)
            ' '' ''     daCust.Fill(dsCaja, "SteCaja")
            ' '' ''     'If EnviarXML = 1 Then
            ' '' ''     myFileStream = New System.IO.FileStream _
            ' '' ''        (myXMLfile, System.IO.FileMode.Create)

            ' '' ''     MyXmlTextWriter = New System.Xml.XmlTextWriter _
            ' '' ''(myFileStream, System.Text.Encoding.Unicode)

            ' '' ''     Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            ' '' ''     Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
            ' '' ''     Me.Refresh()


            ' '' ''     dsCaja.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            ' '' ''     MyXmlTextWriter.Close()
            ' '' ''     myFileStream.Close()
            ' '' ''     'End If
            ' '' ''     PrBarProceso.Refresh()
            ' '' ''     Me.Refresh()





            ' '' ''     myXMLfile = CarpetaGenera & "\SttProcesarEnvioESFuentes.Xml"
            ' '' ''     myTXTfile = CarpetaGenera & "\SttProcesarEnvioESFuentes.Txt"
            ' '' ''     daCust = New SqlDataAdapter("Select Top 1 * From SttProcesarEnvioESFuentes " & " Where nScnFuenteFinanciamientoId =" & Me.cbFuente.Columns("nScnFuenteFinanciamientoID").Value & " Order By nScnFuenteFinanciamientoId Desc ", con)
            ' '' ''     daCust.Fill(dsEnvio, "SttProcesar")
            ' '' ''     'If EnviarXML = 1 Then
            ' '' ''     myFileStream = New System.IO.FileStream _
            ' '' ''        (myXMLfile, System.IO.FileMode.Create)

            ' '' ''     MyXmlTextWriter = New System.Xml.XmlTextWriter _
            ' '' ''(myFileStream, System.Text.Encoding.Unicode)

            ' '' ''     Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            ' '' ''     Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
            ' '' ''     Me.Refresh()


            ' '' ''     dsEnvio.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            ' '' ''     MyXmlTextWriter.Close()
            ' '' ''     myFileStream.Close()
            ' '' ''     'End If
            ' '' ''     If EnviarTXT = 1 Then
            ' '' ''         Me.LblConteo.Text = "Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
            ' '' ''         Me.LblArchivo.Text = "Archivo Generando : " & myTXTfile
            ' '' ''         Me.Refresh()
            ' '' ''         EscribirDataSetToTxt(dsEnvio, myTXTfile, myDelimita)
            ' '' ''     End If

            ' '' ''     PrBarProceso.Value = Contador
            ' '' ''     Contador = Contador + 1

            PrBarProceso.Refresh()
            Me.Refresh()





            'Aqui comienza la generación del archivo Zip
            XtiempoZip = Now
            NombreZip = CarpetaGenera & "\ExportarCaja_" & Me.cbFuente.Columns("nScnFuenteFinanciamientoId").Value & "_" & XNumEnvio & ".zip"
            Me.LblConteo.Text = "Generando empaquetamiento  Archivo  :" & NombreZip
            Me.LblArchivo.Text = " "


            unlocked = zip.UnlockComponent("ZIP-TEAMBEAN_3988ED58913G")
            If (Not unlocked) Then
                MsgBox("Fallo al desenllavar libreria Zip ")
                cmdCancelar.Enabled = True
                Exit Sub
            End If

            zip.NewZip(NombreZip)

            zip.PasswordProtect = False
            'zip.Encryption = 4
            'zip.EncryptKeyLength = 256
            'zip.SetPassword("MCBDTRNS732985")

            ' Append files to the AES Encrypted Zip.
            Dim success As Boolean
            zip.AppendFromDir = CarpetaGenera  '"C:\TemporalPasaXML"

            'Add the entire directory tree.
            success = zip.AppendFiles("*", True)


            If (Not success) Then
                MsgBox(zip.LastErrorText)
                cmdCancelar.Enabled = True
                Exit Sub
            End If

            ' Write the AES Encrypted Zip file.
            success = zip.WriteZipAndClose()
            If (Not success) Then
                MsgBox(zip.LastErrorText)
                cmdCancelar.Enabled = True
                Exit Sub
                'Else
                'MsgBox("Zip OK!")
            End If
            'Process.Start("cmd ", " cd " & CarpetaGenera)
            'Process.Start("cd ", " C:\ ")
            'Process.Start("c:\Archivos de programa\winrar\rar", " a -ep " & NombreZip & " " & CarpetaGenera & "\*.txt")


            'Dim myProcess As Process = System.Diagnostics.Process.Start("c:\Archivos de programa\winrar\rar", " a -ep " & NombreZip & " " & CarpetaGenera & "\*.txt")
            'myProcess.WaitForExit()
            'myProcess.Close()
            'Process.Start("c:\Archivos de programa\winrar\rar")
            lectorDatos.Close()
            lectorDatos = comando.ExecuteReader







            'Contador = 1
            'While lectorDatos.Read
            '    myTXTfile = CarpetaGenera & "\" & lectorDatos("sNombreTablaOrigen") & ".Txt"
            '    If EnviarXML = 1 Then
            '        myXMLfile = CarpetaGenera & "\" & lectorDatos("sNombreTablaOrigen") & ".Xml"
            '        Me.LblConteo.Text = " Borrando Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            '        Me.LblArchivo.Text = "Archivo Eliminado: " & myXMLfile
            '        System.IO.File.Delete(myXMLfile)
            '    End If
            '    If EnviarTXT = 1 Then
            '        Me.LblConteo.Text = " Borrando Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
            '        Me.LblArchivo.Text = "Archivo Eliminado: " & myTXTfile
            '        System.IO.File.Delete(myTXTfile)
            '    End If

            '    PrBarProceso.Value = Contador + XTotalTablas + 2
            '    Contador = Contador + 1
            '    PrBarProceso.Refresh()
            '    Me.Refresh()

            'End While
            'myXMLfile = CarpetaGenera & "\SttProcesarParametroES.Txt"
            'If EnviarXML = 1 Then
            '    myXMLfile = CarpetaGenera & "\SttProcesarParametroES.Xml"
            '    Me.LblConteo.Text = " Borrando Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            '    Me.LblArchivo.Text = "Archivo Eliminado: " & myXMLfile
            '    System.IO.File.Delete(myXMLfile)
            'End If
            'If EnviarTXT = 1 Then
            '    Me.LblConteo.Text = " Borrando Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
            '    Me.LblArchivo.Text = "Archivo Eliminado: " & myTXTfile
            '    System.IO.File.Delete(myTXTfile)
            'End If
            'PrBarProceso.Value = Contador + XTotalTablas + 2
            'Contador = Contador + 1
            'Me.Refresh()
            'myTXTfile = CarpetaGenera & "\SttProcesarEnvioES.Txt"
            'If EnviarXML = 1 Then
            '    myXMLfile = CarpetaGenera & "\SttProcesarEnvioES.Xml"
            '    Me.LblConteo.Text = " Borrando Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            '    Me.LblArchivo.Text = "Archivo Eliminado: " & myXMLfile
            '    System.IO.File.Delete(myXMLfile)
            'End If
            'If EnviarTXT = 1 Then
            '    myXMLfile = CarpetaGenera & "\SttProcesarEnvioES.Txt"
            '    Me.LblConteo.Text = " Borrando Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
            '    Me.LblArchivo.Text = "Archivo Eliminado: " & myTXTfile
            '    System.IO.File.Delete(myTXTfile)
            'End If








            'PrBarProceso.Value = Contador + XTotalTablas + 2
            'Contador = Contador + 1
            PrBarProceso.Refresh()
            Me.Refresh()
            Me.LblConteo.Text = ""
            Me.LblArchivo.Text = "Salvando a   Carpeta en el servidor"
            CargarGenerados()
            GuardarArchivoZipBD()


            'MsgBox("Generación de Lote completada Tiempo de ejecución:" & DateDiff(DateInterval.Second, Now, XtiempoInicial) & " Segundos " & Chr(13) & " Tiempo de Empaquetado  " & DateDiff(DateInterval.Second, XtiempoZip, Now) & " Segundos ", MsgBoxStyle.Information)

            grpPresentaProceso.Visible = False
            PrBarProceso.Visible = False
            CargarParametros()
            cmdCancelar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            grpPresentaProceso.Visible = False
            PrBarProceso.Visible = False
            cmdCancelar.Enabled = True
        Finally
            'MyXmlTextWriter.Close()
            'myFileStream.Close()
        End Try
    End Sub

    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFuente.TextChanged
        CargarGenerados()
    End Sub


    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            
            AccionUsuario = AccionBoton.BotonCancelar
            Me.Close()


        Catch ex As Exception
            Control_Error(ex)
        End Try
        'Try
        '    Me.Close()
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub GrpBPrincipal_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrpBPrincipal.Enter

    End Sub

    
    Private Sub CmbEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEnviar.Click
        EnviarArchivoCARUNA()
    End Sub
    Public Function CreateCmdsAndUpdate(ByVal dataSet As DataSet, _
        ByVal connectionString As String, ByVal queryString As String, _
        ByVal tableName As String) As Integer 'DataSet

        Using connection As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter()
            connection.Open()

            adapter.TableMappings.Add(tableName, dataSet.DataSetName)


            adapter.SelectCommand = New OleDbCommand(queryString, connection)
            Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(adapter)

            Dim i As Integer

            ' Insert new records from DataSet
            'Dim rows() As DataRow = dataSet.Tables(0).Select(Nothing, Nothing, DataViewRowState.Added)
            i = adapter.Update(dataSet.Tables(0))

            'i = adapter.Update(rows)

            Return i

        End Using
    End Function
    Private Function EjecutarComandoPasar(ByVal connectionString As String, ByVal queryString As String) As String
        'Dim queryString As String = _
        '    "SELECT OrderID, CustomerID FROM dbo.Orders;"
        Dim XResult As String
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()
            'command.ResetCommandTimeout()
            command.CommandTimeout = 0
            Dim reader As SqlDataReader = command.ExecuteReader()
            Try
                reader.Read()
                XResult = reader(0)
            Finally
                ' Always call Close when done reading.
                reader.Close()
            End Try
        End Using
        Return XResult
    End Function

    Private Sub cboUnidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidad.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub grpGenera_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpGenera.Enter

    End Sub
End Class