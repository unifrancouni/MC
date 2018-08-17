Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmSccDescarga
    Dim XdtTabla As BOSistema.Win.XDataSet.xDataTable
    Dim XdsGenera As BOSistema.Win.XDataSet
    Dim XdsCaja As BOSistema.Win.XDataSet
    Dim XBaseTemporal As String
    Dim XCajaId As Integer
    Dim CarpetaGenera As String
    Dim XCarpetaTempoUSBCopia As String
    Dim XEstadoEnvio As Integer
    Dim XtiempoInicial, XtiempoFinal, XtiempoZip As Date
    Dim TotalFichasGeneradas As Integer
    Dim XdsCajero As BOSistema.Win.XDataSet
    Dim mNomRep As String
    Dim IntPermiteConsultar As Integer

    Public Property ColorVentana() As String
        Get
            Return mNomRep
        End Get
        Set(ByVal value As String)
            mNomRep = value
        End Set
    End Property
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

    Private Sub cmbBuscarCarpeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)


        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    Private Sub FrmDescarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)

            If Me.ColorVentana = "Verde" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Envío de Información de Recibos")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Envío de Información de Socias")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            EncuentraParametros()
            InicializaVariables()
            grpPresentaProceso.Visible = False
            CargarParametros()
            If XCajaId <> -1 Then
                CargarCaja(XCajaId)
            End If
            CargarUnidades()
            CargarGenerados()





            Me.cdeFechaGenera.Value = Now
            Me.cdeFechaGenera.Enabled = False
            If XCajaId = 0 Then
                RadCentral.Checked = True
            Else
                RadLocal.Checked = True
                cboCaja.Enabled = False
            End If
            If XCajaId = 0 Then
                Me.Text = "Envío de Información de Socias"
            Else
                Me.Text = "Envío de Información de Recibos"
            End If
            Seguridad()


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

    '-------------------------------------------------------------------------
    Private Sub CargarCaja(ByVal intCaja As Integer)
        Try
            Dim Strsql As String

            Me.cboCaja.ClearFields()

            If intCaja = 0 Then
                If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                    Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden,nPonerZipModoLectura " & _
                                             " FROM         dbo.StbPersona INNER JOIN " & _
                                              "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " & _
                                              "  INNER Join          dbo.SttProcesarCajaParametroES ON dbo.SteCaja.nSteCajaID = dbo.SttProcesarCajaParametroES.nSteCajaID " & _
                                              " WHERE(dbo.SteCaja.nCerrada = 0) "  ' And  dbo.SteCaja.nSteCajaID Not in (Select nSteCajaID From SttProgramasExternosCajas Where nCerrada=0 ) Order By dbo.SteCaja.sDescripcionCaja "
                Else
                    Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden,nPonerZipModoLectura " & _
                                             " FROM         dbo.StbPersona INNER JOIN " & _
                                              "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " & _
                                              "  INNER Join          dbo.SttProcesarCajaParametroES ON dbo.SteCaja.nSteCajaID = dbo.SttProcesarCajaParametroES.nSteCajaID " & _
                                              " WHERE(dbo.SteCaja.nCerrada = 0)  and  dbo.SteCaja.nStbDelegacionProgramaID =  " & InfoSistema.IDDelegacion  ' And  dbo.SteCaja.nSteCajaID Not in (Select nSteCajaID From SttProgramasExternosCajas Where nCerrada=0 ) Order By dbo.SteCaja.sDescripcionCaja "
                End If

                
            Else

                Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden ,0 as nPonerZipModoLectura " & _
                         " FROM         dbo.StbPersona INNER JOIN " & _
                         "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " & _
                         " WHERE(dbo.SteCaja.nCerrada = 0) And   dbo.SteCaja.nSteCajaID =" & intCaja '& _
                '" And  dbo.SteCaja.nSteCajaID Not in (Select nSteCajaID From SttProgramasExternosCajas Where nCerrada=0 )  Order By dbo.SteCaja.sDescripcionCaja "

            End If

                '" WHERE (a.nActivo = 1 And a.sCodCargo = '04') " & _

                If XdsCaja.ExistTable("Caja") Then
                    XdsCaja("Caja").ExecuteSql(Strsql)
                Else
                    XdsCaja.NewTable(Strsql, "Caja")
                    XdsCaja("Caja").Retrieve()
                End If

                'Asignando a las fuentes de datos
                Me.cboCaja.DataSource = XdsCaja("Caja").Source
                Me.cboCaja.Rebind()

                'Ubicarse en el primer registro
                'If XdsComprobante("TipoMoneda").Count > 0 Then
                '    Me.cboTipoMoneda.SelectedIndex = 0
                'End If

                Me.cboCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nPonerZipModoLectura").Visible = False

                'Configurar el combo
                Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 60

                Me.cboCaja.Columns("sDescripcionCaja").Caption = "Caja"

                Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                If Me.cboCaja.ListCount > 0 Then
                    Me.cboCaja.SelectedIndex = 0
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

            Strsql = " SELECT dbo.SttProcesarEnvioES.nSteCajaid, dbo.SteCaja.sDescripcionCaja,    dbo.SttProcesarEnvioES.NoEnvio,   " & _
                     " dbo.SttProcesarEnvioES.EstadoEnvio, " & _
                     "CASE WHEN NoEnvio = 0 AND EstadoEnvio = 0 THEN 'Carga Inicial Generada' WHEN NoEnvio = 0 AND " & _
                     " EstadoEnvio = 1 THEN 'Carga Inicial Enviada' WHEN NoEnvio = 0 AND EstadoEnvio = 2 THEN 'Carga Inicial Recepcionada' WHEN NoEnvio <> 0 AND " & _
                     " EstadoEnvio = 0 THEN 'Generada' WHEN NoEnvio <> 0 AND EstadoEnvio = 1 THEN ' Enviada' WHEN NoEnvio <> 0 AND " & _
                     " EstadoEnvio = 2 THEN 'Recepcionada En Central' END AS DesEstadoEnvio," & _
                     "  dbo.SttProcesarEnvioES.FechaGenera, dbo.SsgCuenta.Login " & _
                     " FROM dbo.SttProcesarEnvioES INNER JOIN " & _
                     " dbo.SteCaja ON dbo.SttProcesarEnvioES.nSteCajaId = dbo.SteCaja.nSteCajaID INNER JOIN " & _
                     " dbo.SsgCuenta ON dbo.SttProcesarEnvioES.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID " & _
                     " Where dbo.SttProcesarEnvioES.nSteCajaId =  " & Me.cboCaja.Columns("nSteCajaId").Value & _
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

            Me.ChkEnOtroMunicipio.Checked = False
            Me.ChkFaltanArqueos.Checked = False
            Me.ChkRecibosEnArqueoNocredito.Checked = False
            Me.ChkRecibosEnProceso.Checked = False
            Me.ChkSinUltimaCuota.Checked = False
            Me.ChkSociasnoAutorizadas.Checked = False

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
            XGeneradosTotal = XcomUpdate.ExecuteScalar(" Select count(*)As Total From  SttProcesarEnvioES Where EstadoEnvio<>2")
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
                XCajaId = lectorDatos("nSteCajaId")
                CarpetaGenera = lectorDatos("CarpetaTempo")
                XCarpetaTempoUSBCopia = lectorDatos("CarpetaTempoUSBCopia")
                XEstadoEnvio = lectorDatos("EstadoEnvio") 'Es el estado de envio
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
            XdsCajero = New BOSistema.Win.XDataSet
            Me.gridGenerados.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FormatoLote()
        Try
            ''Configuracion del Grid Lote

            Me.gridGenerados.Splits(0).DisplayColumns("EstadoEnvio").Visible = False
            Me.gridGenerados.Splits(0).DisplayColumns("nSteCajaid").Visible = False
            Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").Visible = False


            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").Width = 80
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").Width = 140
            Me.gridGenerados.Columns("FechaGenera").NumberFormat = "dd/MM/yyyy HH:mm:ss"
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
            Me.gridGenerados.Columns("sDescripcionCaja").Caption = "Caja"

            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("Login").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center



            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    'Private Sub DeleteFiles(ByVal sDirectory As String, ByVal sFilter As String)
    '    Try
    '        For Each strFile As String In Directory.GetFiles(sDirectory, sFilter)
    '            IO.File.Delete(strFile)
    '        Next
    '    Catch Ex As Exception
    '        ' Normally File Already Open Error or FileIOPermission Error
    '        MessageBox.Show(Ex.ToString)
    '    End Try
    'End Sub

    Private Sub GuardarArchivoZipBD()
        Dim XcomUpdate As New BOSistema.Win.XComando
        Dim NombreZipOrigen, NombreZipDestino As String
        Dim XUltimoEnvio As Integer
        Dim lectorDatos As SqlDataReader

        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
        NombreZipDestino = ""
        Try
            conexion.ConnectionString = myConnectionString


            If Me.gridGenerados.RowCount = 0 Then
                MsgBox("No existe ningun numero de envio para guardar ", MsgBoxStyle.Information)
                Exit Sub
            End If


            conexion.Open()


            Dim ComandoBRegId As New SqlCommand("Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = " & Me.cboCaja.Columns("nSteCajaId").Value & "    Order by  NoEnvio desc   ", conexion)
            'lectorDatos.Close()
            lectorDatos = ComandoBRegId.ExecuteReader

            While lectorDatos.Read
                XUltimoEnvio = lectorDatos("NoEnvio")
            End While

            If XCajaId <> 0 And XUltimoEnvio = 0 Then
                MsgBox("Base Local no puede volver a enviar la carga inicial. Genera y envie de nuevo ", MsgBoxStyle.Information)
                Exit Sub
            End If



            If Me.cboUnidad.Items.Count < 1 Then
                MsgBox("No se encuentra ningun USB conectado ", MsgBoxStyle.Information)
                Exit Sub
            End If


            If Trim(Me.cboUnidad.Text) = "" Then
                MsgBox("Seleccione el USB donde hara el guardado del archivo Zip", MsgBoxStyle.Information)
                Exit Sub
            End If


            NombreZipOrigen = CarpetaGenera & "\ExportarCaja_" & Me.cboCaja.Columns("nSteCajaId").Value & "_" & XUltimoEnvio & ".zip"   'Me.gridGenerados.Columns("NoEnvio").Value & ".zip"
            If Not System.IO.File.Exists(NombreZipOrigen) Then
                MsgBox("No se encontro el archivo zip " & NombreZipOrigen & " Elimine y vuelva a generar  ", MsgBoxStyle.Information)
                Exit Sub
            End If


            If XCajaId = 0 Then 'Si se esta generando desde la base central
                NombreZipDestino = Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\" & Me.cboCaja.Columns("sDescripcionCaja").Value & "_EnvioCentral(" & XUltimoEnvio & ").zip"
                If Not System.IO.Directory.Exists(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\") Then
                    System.IO.Directory.CreateDirectory(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal\")
                End If
            Else
                NombreZipDestino = Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\" & Me.cboCaja.Columns("sDescripcionCaja").Value & "_EnvioLocal(" & XUltimoEnvio & ").zip"
                If Not System.IO.Directory.Exists(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\") Then
                    System.IO.Directory.CreateDirectory(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnCentral\")
                End If
            End If


            'System.IO.File.Delete(NombreZipDestino)

            Dim InfoArchivo As New System.IO.FileInfo(NombreZipOrigen)
            If InfoArchivo.Length > TamanoUnidad(Me.cboUnidad.Text) Then
                MsgBox("No Existe el suficiente espacio en " & Trim(Me.cboUnidad.Text) & " Elimine archivos de su dispositivo de almacenamiento y vuelva a generar  ", MsgBoxStyle.Information)
                Exit Sub
            End If
            Me.LblConteo.Text = "Copiando en Dispositivo USB"
            Me.LblArchivo.Text = ""
            Me.Refresh()

            '            DeleteFiles(Me.cboUnidad.Text & "\" & XCarpetaTempoUSBCopia & "\CargarEnLocal", "*.*")

            If System.IO.File.Exists(NombreZipDestino) Then

                'Se agrego para lo del ReadOnly
                My.Computer.FileSystem.DeleteFile(NombreZipDestino, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)


                'Esta Linea antes solo era para borrar
                'System.IO.File.Delete(NombreZipDestino)



            End If
            System.IO.File.Copy(NombreZipOrigen, NombreZipDestino)
            PrBarProceso.Value = (PrBarProceso.Maximum * 2) / 3

            Me.LblConteo.Text = "Eliminando carpeta temporal"
            Me.LblArchivo.Text = ""
            Me.Refresh()
            If System.IO.Directory.Exists(CarpetaGenera) = True Then
                'Borrar los archivos  
                BorrarArchivosCarpeta(CarpetaGenera)

                'Dos lineas antes para limpiar la carpeta pero ahora con el zip readonly    
                'System.IO.Directory.Delete(CarpetaGenera, True)
                'System.IO.Directory.CreateDirectory(CarpetaGenera)







                'XcomUpdate.ExecuteScalar("Delete from dbo.SttCentralFichaNotificacionCreditoEnviadas Where   nSteCajaIDLocal=" & Me.cboCaja.Columns("nSteCajaId").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)


                'Insertar los que no esten ingresados.
                XcomUpdate.ExecuteScalar("Insert Into  dbo.SttCentralFichaNotificacionCreditoEnviadas(nSclFichaNotificacionID,nSteCajaIDLocal,nStbEstadoCreditoID ,dFechaPrimerCuota)  SELECT     dbo.vwSttExpSclFichaNotificacionCredito.nSclFichaNotificacionID, dbo.vwSttExpFiltroLlaves.nSteCajaID ,dbo.vwSttExpSclFichaNotificacionCredito.nStbEstadoCreditoID ,dbo.vwSttExpSclFichaNotificacionCredito.dFechaPrimerCuota FROM         dbo.vwSttExpSclFichaNotificacionCredito INNER JOIN dbo.vwSttExpFiltroLlaves ON  dbo.vwSttExpSclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.vwSttExpFiltroLlaves.nSclFichaNotificacionID  LEFT OUTER JOIN dbo.SttCentralFichaNotificacionCreditoEnviadas ON  dbo.vwSttExpSclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SttCentralFichaNotificacionCreditoEnviadas.nSclFichaNotificacionID WHERE dbo.vwSttExpFiltroLlaves.nSteCajaID =  " & Me.cboCaja.Columns("nSteCajaId").Value & " AND (dbo.SttCentralFichaNotificacionCreditoEnviadas.nSclFichaNotificacionID IS NULL) GROUP BY dbo.vwSttExpSclFichaNotificacionCredito.nSclFichaNotificacionID, dbo.vwSttExpFiltroLlaves.nSteCajaID,   dbo.vwSttExpSclFichaNotificacionCredito.nStbEstadoCreditoID, dbo.vwSttExpSclFichaNotificacionCredito.dFechaPrimerCuota ")

            End If


            If XCajaId <> 0 Then ' Si es local indica que ha sido guardada 
                XcomUpdate.ExecuteScalar("Update SttProcesarEnvioES Set  EstadoEnvio = 1 Where NoEnvio=" & XUltimoEnvio & " And nSteCajaId=" & Me.cboCaja.Columns("nSteCajaId").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)
            Else ' Si es Central No hace nada solo cuando es el codigo cero
                If XUltimoEnvio = 0 Then
                    XcomUpdate.ExecuteScalar("Update SttProcesarEnvioES Set  EstadoEnvio = 1 Where NoEnvio=" & XUltimoEnvio & " And nSteCajaId=" & Me.cboCaja.Columns("nSteCajaId").Value) '& Me.gridGenerados.Columns("nSteCajaId").Value)   
                End If
            End If
            PrBarProceso.Value = PrBarProceso.Maximum
            'MsgBox("Generación de Lote completada Tiempo de ejecución:" & DateDiff(DateInterval.Second, Now, XtiempoInicial) & " Segundos " & Chr(13) & " Tiempo de Empaquetado  " & DateDiff(DateInterval.Second, XtiempoZip, Now) & " Segundos ", MsgBoxStyle.Information)
            MsgBox("Se guardo en el usb el lote para envio indicado como No : " & XUltimoEnvio & IIf(XUltimoEnvio = 0, " Carga Inicial", "") & Chr(13) & " Caja : " & Me.cboCaja.Text & Chr(13) & " En la carpeta (" & NombreZipDestino & ")" & Chr(13) & "Total de Fichas(Grupos) " & TotalFichasGeneradas & Chr(13) & "Tiempo de la descarga :" & DateDiff(DateInterval.Second, XtiempoInicial, Now) & " Segundos ", MsgBoxStyle.Information)
            CargarParametros()
            CargarGenerados()

        Catch ex As Exception
            'Borrar el zip ante un error
            If System.IO.File.Exists(NombreZipDestino) Then
                System.IO.File.Delete(NombreZipDestino)
            End If

            Control_Error(ex)
        End Try
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
                ' Always call Close when done reading.+
                reader.Close()
            End Try
        End Using
        Return XResult
    End Function
    'Private Function EjecutarComandoDataSet(ByVal connectionString As String, ByVal queryString As String) As DataSet
    '    'Dim queryString As String = _
    '    '    "SELECT OrderID, CustomerID FROM dbo.Orders;"
    '    Dim XResult As String
    '    Using connection As New SqlConnection(connectionString)
    '        Dim command As New SqlCommand(queryString, connection)
    '        connection.Open()
    '        'command.ResetCommandTimeout()
    '        command.CommandTimeout = 0
    '        Dim reader As SqlDataReader = command.ExecuteReader()
    '        Try
    '            Return reader.it
    '            'Return reader. 'XResult
    '            'XResult = reader(0)
    '        Finally
    '            ' Always call Close when done reading.+
    '            'reader.Close()
    '        End Try
    '    End Using
    '    'Return reader 'XResult
    'End Function
    'Public Function FillDataSet(ByVal dataSet As DataSet, ByVal queryString As String) As DataSet
    '    Using connection As New SqlConnection("Data Source=SQL;Initial Catalog=database; User ID=user;Password=password;")
    '     Using adapter As New SqlDataAdapter() With {.SelectCommand = New SqlCommand(queryString, connection)}
    '            adapter.Fill(DataSet)
    '        End Using
    '        Return DataSet
    '    End Using
    'End Function

    Private Function GetDataSet(ByVal CadSql As String, ByVal CadConexion As String, ByVal TimeOut As Integer) As DataSet
        Try
            
            Dim con As New SqlConnection(CadConexion)
            Dim daCust As New SqlDataAdapter("", "")
            Dim dsTablas As New DataSet

            daCust = New SqlDataAdapter(CadSql, con)
            daCust.SelectCommand.CommandTimeout = TimeOut
            dsTablas = New DataSet()
            'daCust.Fill(dsTablas, lectorDatos("sNombreTablaOrigen"))
            daCust.Fill(dsTablas)
            Return dsTablas
        Finally
            ' Always call Close when done reading.+
            'reader.Close()
        End Try
    End Function
    Private Sub cmbProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcesar.Click
        Dim zip As New Chilkat.Zip()
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
        Dim XdtTabla As BOSistema.Win.XDataSet.xDataTable

        Dim XdtRegistro As New BOSistema.Win.XDataSet.xDataTable

        'Dim mySelectQuery As String _
        '    = "Select * From SttProcesarTablasES Where nProcesar=1 "
        'Dim mySelectQueryCount As String _
        '            = "Select Count(*) AS TotalT  From SttProcesarTablasES Where nProcesar=1 And nTipoProceso=1"


        Dim myXMLfile As String = ""
        Dim myTXTfile As String = ""
        Dim myDelimita As String = "|"
        Dim myFileStream As System.IO.FileStream ' _
        '("", System.IO.FileMode.Create)
        Dim MyXmlTextWriter As System.Xml.XmlTextWriter  ' _
        '(myFileStream, System.Text.Encoding.Unicode)
        Dim EnviarXML As Integer = 0
        Dim EnviarTXT As Integer = 0
        Dim XError As String = ""

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        CargarUnidades()
        If Me.cboUnidad.Items.Count < 1 Then
            MsgBox("No se encuentra ningun USB conectado ", MsgBoxStyle.Information)
            cmdCancelar.Enabled = True
            Exit Sub
        End If

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
        Dim xTotalCajeros As Integer
        Dim XEstadoEnvioUltimoAplicadoCentral As Integer
        Dim MunicipioIdCaja As Integer
        Dim MunicipioNombreCaja As String
        Dim SegundosConexion As Integer = 120



        Try
            cmdCancelar.Enabled = False
            XtiempoInicial = Now
            IdUsuario = XcUsuario.ExecuteScalar("SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')") 
            'XComando.Execute("Update  SttProcesarParametroES  Set ExportarnSteCajaId=" & Me.cboCaja.Columns("nSteCajaId").Value)
            Dim XCajaIngresada As Integer
            XCajaIngresada = XComando.ExecuteScalar("Select Count(*) As TablaIngresada FROM  dbo.SttProcesarCajaParametroES  WHERE     nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value)
            If XCajaIngresada < 1 Then
                XComando.ExecuteScalar("Insert into SttProcesarCajaParametroES(nSteCajaId) values( " & Me.cboCaja.Columns("nSteCajaId").Value & ")")
            End If



            Dim mySelectQuery As String _
                = "Select * From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoExportar=1   And nProcesarCentralImportar=0" & IIf(XCajaId <> 0, " And nProcesarLocalExportar= 1 ", "")
            Dim mySelectQueryCount As String _
                        = "Select Count(*) AS TotalT From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoExportar=1   And nProcesarCentralImportar=0 " & IIf(XCajaId <> 0, " And nProcesarLocalExportar= 1 ", "")
            Dim comando As New SqlCommand(mySelectQuery, conexion)



            XNumEnvio = -1
            XEstadoEnvioUltimo = -1
            XEstadoEnvioUltimoAplicadoCentral = -1
            Dim XOperActualizarOAgregar As Integer
            Dim ComandoBRegId As New SqlCommand("Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = " & Me.cboCaja.Columns("nSteCajaId").Value & "    Order by  NoEnvio desc   ", conexion)


            Dim DsBusca As New DataSet
            'lectorDatos.Close()
            lectorDatos = ComandoBRegId.ExecuteReader
            XOperActualizarOAgregar = 1

            While lectorDatos.Read
                XNumEnvio = lectorDatos("NoEnvio")
                XEstadoEnvioUltimo = lectorDatos("EstadoEnvio")
                XEstadoEnvioUltimoAplicadoCentral = lectorDatos("AplicadoEnCentral")
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
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
                EnviarXML = 1
            Else
                EnviarTXT = 1
            End If





            If XCajaId = 0 Then 'Central solo puede exportar si ya se hizo el proceso de aplicacion de recibos


                'Dim TotalRecibosNoProcesados As Long
                ''TotalRecibosNoProcesados = XComando.ExecuteScalar("Select Count(*) As TotalRecibosNoProcesados FROM  dbo.SccReciboOficialCaja WHERE     (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (nAplicado = 0) ")
                'TotalRecibosNoProcesados = XComando.ExecuteScalar("Select Count(*) As TotalRecibosNoProcesados FROM  dbo.SccReciboOficialCaja WHERE     nAplicado = 0  And nSteCajaID=" & Me.cboCaja.Columns("nSteCajaId").Value)
                'If TotalRecibosNoProcesados > 0 Then
                '    MsgBox("Existen " & TotalRecibosNoProcesados & " Recibos que no han sido Aplicados . Corra el Proceso de Aplicacion de Recibos ", MsgBoxStyle.Information)
                '    cmdCancelar.Enabled = True
                '    Exit Sub
                'End If
                If XNumEnvio > 0 And XEstadoEnvioUltimoAplicadoCentral = 0 Then
                    MsgBox("No se ha generado el proceso de aplicación en central", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If



                xTotalCajeros = XComando.ExecuteScalar(" SELECT     isnull(count(*),0) as TotalCajeros  FROM         vwSttExpSteCajaCajeros Where nSteCajaID  in (Select nSteCajaID From vwSttExpFiltroLlaves Where nSteCajaId=" & Me.cboCaja.Columns("nSteCajaId").Value & ")")
                If xTotalCajeros = 0 Then
                    MsgBox("No existen cajeros asignados para esa caja o No existen Fichas en estado Activa para Enviar", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If

                'No ha sido aplicado en central el ultimo envio de la local  
                If XNumEnvio > 0 And XEstadoEnvioUltimoAplicadoCentral <> 1 And Me.gridGenerados.RowCount > 0 Then
                    MsgBox("No ha sido aplicado el ultimo envio" & Chr(13) & "Primero aplique el envio en central", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
                'Ver si al menos un cajero tiene asignado para Exportar Recibos
                Dim SqlCad As String




                'SqlCad = "EXEC SpSttFichasUltimasPagadas  " & Me.cboCaja.Columns("nSteCajaId").Value


                ''XdtRegistro.ExecuteSql(SqlCad)


                'DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                'If DsBusca.Tables(0).Rows.Count > 0 Then


                '    'If XdtRegistro.Count > 0 Then
                '    If MsgBox(" Existen Socias que no han pagado su ultima cuota correspondiente : Cédula:" & DsBusca.Tables(0).Rows(0).Item("sNumeroCedula").ToString() & " Con fecha de la cuota ultima a pagar el : " & Trim(DsBusca.Tables(0).Rows(0).Item("dFechaPago").ToString()) & "  " & Trim(DsBusca.Tables(0).Rows(0).Item("sNombre1").ToString()) & " " & Trim(DsBusca.Tables(0).Rows(0).Item("sApellido1").ToString()) & Chr(13) & "Verifique si es que no pagaron o es que no se ingresaron los recibos " & Chr(13) & "Proceder si ya se ingresaron todos los recibos", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                '        cmdCancelar.Enabled = True
                '        Me.Cursor = System.Windows.Forms.Cursors.Default
                '        Exit Sub
                '    End If
                'End If


                'Ver si hay Arqueos Abiertos para la caja.

                SqlCad = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, dbo.SteCaja.sDescripcionCaja, dbo.SteCaja.nSteCajaID,  dbo.SteArqueoCaja.dFechaArqueo, dbo.SteArqueoCaja.nCodigo FROM         dbo.SteArqueoCaja INNER JOIN                       dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER JOIN                       dbo.StbValorCatalogo ON dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE     (dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '1') "



                'XdtRegistro.ExecuteSql(SqlCad)
                DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                If DsBusca.Tables(0).Rows.Count > 0 Then
                    'If XdtRegistro.Count > 0 Then
                    MsgBox("Existen " & DsBusca.Tables(0).Rows.Count & " Arqueos Abiertos en Tesoreria. El primero indicado es " & Chr(13) & "Codigo No.  " & DsBusca.Tables(0).Rows(0).Item("nCodigo").ToString() & " Con fecha: " & DsBusca.Tables(0).Rows(0).Item("dFechaArqueo").ToString(), MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub

                    'End If

                End If






                'If XNumEnvio = 0 Or XNumEnvio = -1 Then  'Es la primera vez

                'SqlCad = "SELECT     dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID, dbo.vwSteRecibosArqueadosNoIngresados.nStbDepartamentoID, " & _
                '" dbo.vwSteRecibosArqueadosNoIngresados.Serie, dbo.vwSteRecibosArqueadosNoIngresados.sNombreColor, " & _
                '        " dbo.vwSteRecibosArqueadosNoIngresados.Departamento, dbo.vwSteRecibosArqueadosNoIngresados.nStbMunicipioID,  " & _
                '      " dbo.vwSteRecibosArqueadosNoIngresados.Municipio, dbo.vwSteRecibosArqueadosNoIngresados.nCodigo, " & _
                '      " dbo.vwSteRecibosArqueadosNoIngresados.EstadoArqueo, dbo.vwSteRecibosArqueadosNoIngresados.dFechaArqueo,  " & _
                '      " dbo.vwSteRecibosArqueadosNoIngresados.NoRecibo, dbo.vwSteRecibosArqueadosNoIngresados.NombrePrograma,  " & _
                '      " dbo.vwSteRecibosArqueadosNoIngresados.nStbTipoProgramaID, dbo.vwSteRecibosArqueadosNoIngresados.CodPrograma, " & _
                '" dbo.vwSteRecibosArqueadosNoIngresados.nCodigoTalonario, dbo.SteCaja.nSteCajaID " & _
                '"FROM         dbo.vwSteRecibosArqueadosNoIngresados INNER JOIN dbo.SteArqueoCaja ON dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID = dbo.SteArqueoCaja.nSteArqueoCajaID INNER JOIN dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID " & _
                '" WHERE     dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value

                'XdtRegistro.ExecuteSql(SqlCad)
                'If XdtRegistro.Count > 0 Then
                '    MsgBox("Existen " & XdtRegistro.Count & " Recibos Manuales en Arqueo sin Ingresar en Crédito. El primero indicado es " & Chr(13) & "Recibo No.  " & XdtRegistro.ValueField("NoRecibo") & " Con fecha: " & XdtRegistro.ValueField("dFechaArqueo"), MsgBoxStyle.Information)
                '    cmdCancelar.Enabled = True
                '    Me.Cursor = System.Windows.Forms.Cursors.Default
                '    Exit Sub

                'End If

                'End If





                'lectorDatos.Close()

                'Dim ComandoB1 As New SqlCommand("EXEC SpSttRecibosArqueadosNoEnCreditos  " & Me.cboCaja.Columns("nSteCajaId").Value, con)
                ''lectorDatos.Close()

                'lectorDatos = ComandoB1.ExecuteReader



                'Dim DsBusca As New DataSet
                'XOperActualizarOAgregar = 1

                'While lectorDatos.Read
                '    XNumEnvio = lectorDatos("NoEnvio")
                '    XEstadoEnvioUltimo = lectorDatos("EstadoEnvio")
                '    XEstadoEnvioUltimoAplicadoCentral = lectorDatos("AplicadoEnCentral")
                'End While

                'If XNumEnvio = 0 Or XNumEnvio = -1 Then  'Es la primera vez Que existan arqueos
                '    SqlCad = "EXEC SpSttRecibosArqueadosNoEnCreditos  " & Me.cboCaja.Columns("nSteCajaId").Value

                '    DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                '    If DsBusca.Tables(0).Rows.Count > 0 Then
                '        MsgBox("Existen " & DsBusca.Tables(0).Rows.Count & " Recibos Manuales en Arqueo sin Ingresar en Crédito. El primero indicado es " & Chr(13) & "Recibo No.  " & DsBusca.Tables(0).Rows(0).Item("NoRecibo") & " Con fecha: " & DsBusca.Tables(0).Rows(0).Item("dFechaArqueo"), MsgBoxStyle.Information)
                '        cmdCancelar.Enabled = True
                '        Me.Cursor = System.Windows.Forms.Cursors.Default
                '        Exit Sub


                '    End If

                'End If










                If XNumEnvio > 0 Then ' Si es envio mayor que cero validar que existan los cierres para los cajeros fechas de la caja.



                    SqlCad = "SELECT     ListaCajerosLocal.nSteCajaIDLocal, ListaCajerosLocal.nSrhEmpleadoID, ListaCajerosLocal.sNombre, ListaCajerosLocal.dFechaRecibo " & _
                             "    FROM         (SELECT     dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.SrhEmpleado.nSrhEmpleadoID, dbo.vwStbPersona.sNombre, " & _
                             " dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nPrincipal) AS nPrincipal,  " & _
                             "                     SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nMantenimientoValor) AS nMantenimientoValor, " & _
                             "                     SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesCorrientes) AS nInteresesCorrientes, " & _
                             "                     SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesMoratorios) AS nInteresesMoratorios, " & _
                             "                     SUM(dbo.SttLocalSccReciboOficialCaja.nValor) AS nValor " & _
                             " FROM          dbo.SttLocalSccReciboOficialCaja INNER JOIN    dbo.SttLocalSccReciboOficialCajaDetalle ON  " & _
                             " dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccReciboOficialCajaDetalle.nSccReciboOficialCajaID INNER JOIN " & _
                             " dbo.SrhEmpleado ON dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                             " dbo.vwStbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID " & _
                             " WHERE      (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = " & XNumEnvio & ") " & _
                             " GROUP BY dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.vwStbPersona.sNombre, dbo.SrhEmpleado.nSrhEmpleadoID,  " & _
                             " dbo.SttLocalSccReciboOficialCaja.dFechaRecibo) AS ListaCajerosLocal LEFT OUTER JOIN  (SELECT     SrhEmpleado_1.nSrhEmpleadoID, dbo.SteArqueoCaja.dFechaArqueo, dbo.SteArqueoCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja, " & _
                             " dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion " & _
                             "   FROM          dbo.StbPersona INNER JOIN " & _
                             "   dbo.SrhEmpleado AS SrhEmpleado_1 ON dbo.StbPersona.nStbPersonaID = SrhEmpleado_1.nStbPersonaID INNER JOIN " & _
                             " dbo.SteCajero ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteCajero.nSrhEmpleadoID INNER JOIN " & _
                             " dbo.SteArqueoCaja ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteArqueoCaja.nSrhCajeroId INNER JOIN " & _
                             " dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER JOIN " & _
                             " dbo.StbValorCatalogo ON dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                             "   WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2')) AS ArqueoCerrado ON  " & _
                             " ListaCajerosLocal.nSrhEmpleadoID = ArqueoCerrado.nSrhEmpleadoID AND ListaCajerosLocal.nSteCajaIDLocal = ArqueoCerrado.nSteCajaID AND " & _
                             " ListaCajerosLocal.dFechaRecibo = ArqueoCerrado.dFechaArqueo  WHERE(ArqueoCerrado.nSrhEmpleadoID Is NULL) "

                    'XdtRegistro.ExecuteSql(SqlCad)
                    'If XdtRegistro.Count > 0 Then
                    DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                    If DsBusca.Tables(0).Rows.Count > 0 Then

                        MsgBox("Falta Arqueo Caja Cerrado para : " & DsBusca.Tables(0).Rows(0).Item("sNombre") & " Con fecha: " & DsBusca.Tables(0).Rows(0).Item("dFechaRecibo"), MsgBoxStyle.Information)
                        cmdCancelar.Enabled = True
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                        Exit Sub
                    Else
                        SqlCad = " SELECT     SttCentralArqueoRecuperacion_1.dFechaArqueo, ListaArqueoFn.TotalCajeros, SttCentralArqueoRecuperacion_1.nObligado " & _
                                    " FROM         (SELECT     nSteCajaID, EnvioNumero, dFechaArqueo, COUNT(nSrhCajeroId) AS TotalCajeros " & _
                                    "  FROM          (SELECT     ArqueoTodos.nSrhCajeroId, ArqueoTodos.nSteCajaID, ArqueoTodos.dFechaArqueo, ArqueoTodos.nSteArqueoCajaID,  " & _
                                                                           "  ArqueoTodos.EnvioNumero, ArqueoNormal.nSteArqueoCajaID AS Expr1 " & _
                                                      " FROM          (SELECT     TOP (100) PERCENT dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, " & _
                                                                                                     " dbo.SteArqueoCaja.nSrhCajeroId, dbo.SteArqueoCaja.nSteCajaID, dbo.SteArqueoCaja.dFechaArqueo, " & _
                                                                                                     " dbo.SteArqueoCaja.nSteArqueoCajaID, dbo.SttCentralArqueoRecuperacion.EnvioNumero, " & _
                                                        "  dbo.SttCentralArqueoRecuperacion.nObligado FROM          dbo.SteArqueoCaja INNER JOIN dbo.StbValorCatalogo ON                                                                                             dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                                        " dbo.SttCentralArqueoRecuperacion ON  dbo.SteArqueoCaja.nSteCajaID = dbo.SttCentralArqueoRecuperacion.nSteCajaID AND  dbo.SteArqueoCaja.dFechaArqueo = dbo.SttCentralArqueoRecuperacion.dFechaArqueo  WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2') " & _
                                                        "AND (dbo.SteArqueoCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND  (dbo.SttCentralArqueoRecuperacion.EnvioNumero = " & XNumEnvio & ") AND (dbo.SttCentralArqueoRecuperacion.nObligado = 1) " & _
                                                                             " ORDER BY dbo.SteArqueoCaja.dFechaArqueo DESC) AS ArqueoTodos LEFT OUTER JOIN " & _
                                                                               "  (SELECT     LIstaRec.nSteCajaIDLocal, LIstaRec.nSrhEmpleadoCajeroID, LIstaRec.dFechaRecibo, Arqueo.nSrhCajeroId,  " & _
                                                       " Arqueo.nSteArqueoCajaID FROM          (SELECT     nSteCajaIDLocal, nSrhEmpleadoCajeroID, dFechaRecibo  FROM dbo.SttLocalSccReciboOficialCaja " & _
                                                       " WHERE      (nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (EnvioNumero = " & XNumEnvio & ") " & _
                                                       " GROUP BY nSrhEmpleadoCajeroID, dFechaRecibo, nSteCajaIDLocal) AS LIstaRec INNER JOIN  (SELECT     TOP (100) PERCENT StbValorCatalogo_1.sCodigoInterno, StbValorCatalogo_1.sDescripcion, SteArqueoCaja_1.nSrhCajeroId, SteArqueoCaja_1.nSteCajaID, SteArqueoCaja_1.dFechaArqueo,SteArqueoCaja_1.nSteArqueoCajaID FROM          dbo.SteArqueoCaja AS SteArqueoCaja_1 INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  SteArqueoCaja_1.nStbEstadoArqueoID = StbValorCatalogo_1.nStbValorCatalogoID WHERE      (StbValorCatalogo_1.sCodigoInterno = '2') " & _
                                                       "AND (SteArqueoCaja_1.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") " & _
                                                       " ORDER BY SteArqueoCaja_1.dFechaArqueo DESC) AS Arqueo ON  LIstaRec.nSteCajaIDLocal = Arqueo.nSteCajaID AND LIstaRec.dFechaRecibo = Arqueo.dFechaArqueo AND                                                                                                    LIstaRec.nSrhEmpleadoCajeroID = Arqueo.nSrhCajeroId) AS ArqueoNormal ON " & _
                                                       " ArqueoTodos.nSteArqueoCajaID = ArqueoNormal.nSteArqueoCajaID  WHERE         (ArqueoNormal.nSteArqueoCajaID IS NULL)) AS ListaArqueos  GROUP BY dFechaArqueo, nSteCajaID, EnvioNumero) AS ListaArqueoFn RIGHT OUTER JOIN  dbo.SttCentralArqueoRecuperacion AS SttCentralArqueoRecuperacion_1 ON   ListaArqueoFn.nSteCajaID = SttCentralArqueoRecuperacion_1.nSteCajaID AND   ListaArqueoFn.EnvioNumero = SttCentralArqueoRecuperacion_1.EnvioNumero AND   ListaArqueoFn.dFechaArqueo = SttCentralArqueoRecuperacion_1.dFechaArqueo WHERE     (ListaArqueoFn.TotalCajeros IS NULL) AND (SttCentralArqueoRecuperacion_1.nObligado = 1) AND (SttCentralArqueoRecuperacion_1.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") And (SttCentralArqueoRecuperacion_1.EnvioNumero = " & XNumEnvio & ")   "


                        'XdtRegistro.ExecuteSql(SqlCad)
                        'If XdtRegistro.Count > 0 Then
                        DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                        If DsBusca.Tables(0).Rows.Count > 0 Then


                            MsgBox("Falta Arqueo Por Recuperación Cerrado  Con fecha: " & DsBusca.Tables(0).Rows(0).Item("dFechaArqueo") & Chr(13) & " o que Indiquen en Recepción  de recibos que no es necesario arqueo por recuperación para esa fecha. ", MsgBoxStyle.Information)
                            cmdCancelar.Enabled = True
                            Me.Cursor = System.Windows.Forms.Cursors.Default
                            Exit Sub
                        End If

                    End If
                End If


                'Revisar  Que los Recibos manuales en los arqueos esten ingresados en Credito'






                SqlCad = "SELECT     ListaFi.nSteArqueoCajaID, dbo.vwSteRecibosArqueadosNoIngresados.nCodigo, dbo.vwSteRecibosArqueadosNoIngresados.NoRecibo,                      dbo.vwSteRecibosArqueadosNoIngresados.dFechaArqueo " & _
                         " FROM         (SELECT     nSteArqueoCajaID " & _
                       " FROM          (SELECT     TOP (100) PERCENT ArqueoCerrado.nSteArqueoCajaID " & _
                                             "  FROM          (SELECT     dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.SrhEmpleado.nSrhEmpleadoID, dbo.vwStbPersona.sNombre, " & _
                " dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nPrincipal) " & _
                " AS nPrincipal, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nMantenimientoValor) AS nMantenimientoValor, " & _
                " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesCorrientes) AS nInteresesCorrientes,  " & _
                " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesMoratorios) AS nInteresesMoratorios,  " & _
                " SUM(dbo.SttLocalSccReciboOficialCaja.nValor) AS nValor " & _
                " FROM          dbo.SttLocalSccReciboOficialCaja INNER JOIN " & _
                " dbo.SttLocalSccReciboOficialCajaDetalle ON  " & _
                " dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccReciboOficialCajaDetalle.nSccReciboOficialCajaID INNER Join " & _
                " dbo.SrhEmpleado ON dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN dbo.vwStbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID " & _
                " WHERE      (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = " & XNumEnvio & ") " & _
                " GROUP BY dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.vwStbPersona.sNombre,dbo.SrhEmpleado.nSrhEmpleadoID, dbo.SttLocalSccReciboOficialCaja.dFechaRecibo)  AS ListaCajerosLocal INNER JOIN  (SELECT     SrhEmpleado_1.nSrhEmpleadoID, dbo.SteArqueoCaja.dFechaArqueo, dbo.SteArqueoCaja.nSteCajaID, " & _
                " dbo.SteCaja.sDescripcionCaja, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, dbo.SteArqueoCaja.nSteArqueoCajaID  FROM          dbo.StbPersona INNER JOIN dbo.SrhEmpleado AS SrhEmpleado_1 ON  dbo.StbPersona.nStbPersonaID = SrhEmpleado_1.nStbPersonaID INNER JOIN " & _
                " dbo.SteCajero ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteCajero.nSrhEmpleadoID INNER JOIN dbo.SteArqueoCaja ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteArqueoCaja.nSrhCajeroId INNER JOIN dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER JOIN dbo.StbValorCatalogo ON " & _
                " dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2')) AS ArqueoCerrado ON   ListaCajerosLocal.nSrhEmpleadoID = ArqueoCerrado.nSrhEmpleadoID AND  ListaCajerosLocal.nSteCajaIDLocal = ArqueoCerrado.nSteCajaID AND " & _
                " ListaCajerosLocal.dFechaRecibo = ArqueoCerrado.dFechaArqueo  ORDER BY ListaCajerosLocal.dFechaRecibo, ListaCajerosLocal.nSrhEmpleadoID) AS ListaArqueo GROUP BY nSteArqueoCajaID) AS ListaFi INNER JOIN dbo.vwSteRecibosArqueadosNoIngresados ON ListaFi.nSteArqueoCajaID = dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID "

                'XdtRegistro.ExecuteSql(SqlCad)
                'If XdtRegistro.Count > 0 Then
                DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                If DsBusca.Tables(0).Rows.Count > 0 Then
                    MsgBox("Existen " & DsBusca.Tables(0).Rows.Count & " Recibos Manuales en Arqueo sin Ingresar en Crédito. El primero indicado es " & Chr(13) & "Recibo No.  " & DsBusca.Tables(0).Rows(0).Item("NoRecibo") & " Con fecha: " & DsBusca.Tables(0).Rows(0).Item("dFechaArqueo"), MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Exit Sub

                End If


                If XNumEnvio > 0 Then
                    'Buscar los posteriores esto aplica para cuando no se envio el archivo y en la caja local hicieron otros dias
                    'al ultimo que se tiene de la caja desconectada en la base.
                    'Por ejemplo se olvido generar el archivo para enviar a la local.
                    'Entonces lo hacen manual, el revisa que los arqueos posteriores esten ingresados los recibos en creditos que
                    'esten indicados en la base central.








                    SqlCad = "  SELECT     UltimoArqueoRevisado.nSteArqueoCajaID, UltimoArqueoRevisado.nSteCajaIDLocal, SteArqueoCaja_1.nSteCajaID, " & _
                                            " SteArqueoCaja_1.nSteArqueoCajaID AS nSteArqueoCajaIDPosterior, dbo.vwSteRecibosArqueadosNoIngresados.Serie, " & _
                                          " dbo.vwSteRecibosArqueadosNoIngresados.sNombreColor, dbo.vwSteRecibosArqueadosNoIngresados.Departamento, " & _
                                          " dbo.vwSteRecibosArqueadosNoIngresados.Municipio, dbo.vwSteRecibosArqueadosNoIngresados.nCodigo, " & _
                                          " dbo.vwSteRecibosArqueadosNoIngresados.dFechaArqueo, dbo.vwSteRecibosArqueadosNoIngresados.NoRecibo, " & _
                    " dbo.vwSteRecibosArqueadosNoIngresados.nCodigoTalonario " & _
                   " FROM         (SELECT     TOP (1) ArqueoCerrado.nSteArqueoCajaID, ListaCajerosLocal.nSteCajaIDLocal " & _
                                          " FROM          (SELECT     dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.SrhEmpleado.nSrhEmpleadoID, dbo.vwStbPersona.sNombre,  " & _
                                                                                        "  dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nPrincipal) AS nPrincipal, " & _
                                                                                         " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nMantenimientoValor) AS nMantenimientoValor, " & _
                                                                                         " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesCorrientes) AS nInteresesCorrientes, " & _
                                                                                         "  SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesMoratorios) AS nInteresesMoratorios, " & _
                                                                                         " SUM(dbo.SttLocalSccReciboOficialCaja.nValor) AS nValor " & _
                                                                 "  FROM          dbo.SttLocalSccReciboOficialCaja INNER JOIN " & _
                                                                 "                         dbo.SttLocalSccReciboOficialCajaDetalle ON " & _
                                                                                      "    dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccReciboOficialCajaDetalle.nSccReciboOficialCajaID INNER Join  dbo.SrhEmpleado ON dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN  dbo.vwStbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID " & _
                                                                 "  WHERE      (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & " ) AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = " & XNumEnvio & ") " & _
                                                                  " GROUP BY dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.vwStbPersona.sNombre, dbo.SrhEmpleado.nSrhEmpleadoID, " & _
                                                                                       "   dbo.SttLocalSccReciboOficialCaja.dFechaRecibo) AS ListaCajerosLocal INNER JOIN " & _
                                                                     " (SELECT     SrhEmpleado_1.nSrhEmpleadoID, dbo.SteArqueoCaja.dFechaArqueo, dbo.SteArqueoCaja.nSteCajaID, " & _
                                                                                             "  dbo.SteCaja.sDescripcionCaja, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, " & _
                                                                         " dbo.SteArqueoCaja.nSteArqueoCajaID  FROM          dbo.StbPersona INNER JOIN  dbo.SrhEmpleado AS SrhEmpleado_1 ON dbo.StbPersona.nStbPersonaID = SrhEmpleado_1.nStbPersonaID INNER JOIN  dbo.SteCajero ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteCajero.nSrhEmpleadoID INNER JOIN  dbo.SteArqueoCaja ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteArqueoCaja.nSrhCajeroId INNER JOIN  dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER JOIN  dbo.StbValorCatalogo ON dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID  " & _
                                                       " WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2')) AS ArqueoCerrado ON  ListaCajerosLocal.nSrhEmpleadoID = ArqueoCerrado.nSrhEmpleadoID AND ListaCajerosLocal.nSteCajaIDLocal = ArqueoCerrado.nSteCajaID AND  ListaCajerosLocal.dFechaRecibo = ArqueoCerrado.dFechaArqueo ORDER BY ArqueoCerrado.nSteArqueoCajaID) AS UltimoArqueoRevisado " & _
                                                       "INNER JOIN  dbo.SteArqueoCaja AS SteArqueoCaja_1 ON UltimoArqueoRevisado.nSteArqueoCajaID < SteArqueoCaja_1.nSteArqueoCajaID INNER JOIN  dbo.vwSteRecibosArqueadosNoIngresados ON  SteArqueoCaja_1.nSteArqueoCajaID = dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID " & _
                                                       " WHERE(SteArqueoCaja_1.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") "















                    'XdtRegistro.ExecuteSql(SqlCad)
                    'If XdtRegistro.Count > 0 Then
                    DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                    If DsBusca.Tables(0).Rows.Count > 0 Then
                        MsgBox("Existen " & DsBusca.Tables(0).Rows.Count & " Recibos Manuales en Arqueo sin Ingresar en Crédito. El primero indicado es " & Chr(13) & "Recibo No.  " & DsBusca.Tables(0).Rows(0).Item("NoRecibo") & " Con fecha: " & DsBusca.Tables(0).Rows(0).Item("dFechaArqueo"), MsgBoxStyle.Information)
                        cmdCancelar.Enabled = True
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                        Exit Sub

                    End If


                End If



                MunicipioIdCaja = 0
                'Obtener la ubicacion del municipio de la caja a traves del barrio
                SqlCad = " SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.nCodigo, dbo.SteCaja.sDescripcionCaja, dbo.vwStbUbicacionGeografica.Departamento,  dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbMunicipioID FROM         dbo.SteCaja INNER JOIN  dbo.vwStbUbicacionGeografica ON dbo.SteCaja.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID WHERE dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value
                XdtRegistro.ExecuteSql(SqlCad)
                If XdtRegistro.Count > 0 Then
                    MunicipioNombreCaja = XdtRegistro.ValueField("Municipio")
                    MunicipioIdCaja = XdtRegistro.ValueField("nStbMunicipioID")
                End If




                SqlCad = "SELECT  NombreGrupo, sNumeroCedula,  CodFicha, DesEstadoFicha, CodCred, DesEstadoCred, nCreditoRechazado, CodigoUbicacion, Departamento, Municipio, Distrito, Barrio, nStbDepartamentoID, nStbMunicipioID, nStbDistritoID, nStbPersonaLugarPagosID, nCerrada, nStbPersonaLugarPagosIDCaja, nStbMunicipioIDCaja,  DepartamentoCaja, MunicipioCaja, DistritoCaja, nSclFichaNotificacionID, nCodigo FROM dbo.vwSttFichasEnOtroMunicipioCaja WHERE nStbMunicipioID = " & MunicipioIdCaja


                'XdtRegistro.ExecuteSql(SqlCad)
                'If XdtRegistro.Count > 0 Then
                DsBusca = Me.GetDataSet(SqlCad, myConnectionString, SegundosConexion)

                If DsBusca.Tables(0).Rows.Count > 0 Then

                    If MsgBox("Existen " & DsBusca.Tables(0).Rows.Count & "  Socias que estan En el Municipio de ." & MunicipioNombreCaja & " Pero que estan asignados en una caja en otro municipio  " & Chr(13) & "Grupo: " & DsBusca.Tables(0).Rows(0).Item("NombreGrupo") & "Cédula:  " & DsBusca.Tables(0).Rows(0).Item("sNumeroCedula") & Chr(13) & "ESTA SEGURO DE GENERAR", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If


                End If


                SqlCad = " SELECT     ISNULL(COUNT(*), 0) AS TotalCajeros " & _
                                       " FROM         (SELECT     SsgCuentaID, SUM(mnuControlCredito) AS mnuControlCredito, SUM(MantExportarRecibosCajero) AS  MantExportarRecibosCajero" & _
                                       " FROM          (SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID, dbo.SsgAccion.CodInterno, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'mnuControlCredito' THEN 1 ELSE 0 END AS mnuControlCredito, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'MantExportarRecibosCajero' THEN 1 ELSE 0 END AS MantExportarRecibosCajero " & _
                                       " FROM          dbo.vwSttExpSteCajaCajeros INNER JOIN " & _
                                       " dbo.SteCajero ON dbo.vwSttExpSteCajaCajeros.nSteCajeroID = dbo.SteCajero.nSteCajeroID INNER JOIN " & _
                                       " dbo.SrhEmpleado ON dbo.SteCajero.nSrhEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                                       " dbo.SsgCuenta ON dbo.SrhEmpleado.nSrhEmpleadoID = dbo.SsgCuenta.objEmpleadoID INNER JOIN " & _
                                       " dbo.SsgCuentaRol ON dbo.SsgCuenta.SsgCuentaID = dbo.SsgCuentaRol.objCuentaID INNER JOIN " & _
                                       " dbo.SsgRol ON dbo.SsgCuentaRol.objRolID = dbo.SsgRol.SsgRolID INNER JOIN " & _
                                       " dbo.SsgRolAccion ON dbo.SsgRol.SsgRolID = dbo.SsgRolAccion.objRolID INNER JOIN " & _
                                       " dbo.SsgAccion ON dbo.SsgRolAccion.objAccionID = dbo.SsgAccion.SsgAccionID " & _
                                       " WHERE      (dbo.vwSttExpSteCajaCajeros.nSteCajaID IN " & _
                                       " (SELECT     nSteCajaID   FROM dbo.vwSttExpFiltroLlaves " & _
                                       " WHERE      (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & "))) " & _
                                       " AND (dbo.vwSttExpSteCajaCajeros.nActiva = 1)" & _
                                       " ORDER BY dbo.vwSttExpSteCajaCajeros.nSteCajeroID, dbo.SsgAccion.CodInterno) AS A " & _
                                       " GROUP BY SsgCuentaID) AS Lista WHERE     (mnuControlCredito > 0) AND  (MantExportarRecibosCajero> 0) "


















                xTotalCajeros = XComando.ExecuteScalar(SqlCad)
                If xTotalCajeros = 0 Then
                    MsgBox("No existe al menos un cajero con la opcion de exportar recibos", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If

                'Ver si al menos un cajero tiene asignado para Importar Informacion de Socias
                'SqlCad = "SELECT     isnull(count(*),0) as TotalCajeros " & _
                '         " FROM         (SELECT     SsgCuentaID, SUM(mnuControlCredito) AS mnuControlCredito, SUM(mnuExportarRecibos) AS mnuExportarRecibos, " & _
                '         "                     SUM(mnuImportarInformacion) AS mnuImportarInformacion " & _
                '         " FROM          (SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID, dbo.SsgAccion.CodInterno,  " & _
                '         "  CASE WHEN dbo.SsgAccion.CodInterno = 'mnuControlCredito' THEN 1 ELSE 0 END AS mnuControlCredito, " & _
                '         " CASE WHEN dbo.SsgAccion.CodInterno = 'mnuExportarRecibos' THEN 1 ELSE 0 END AS mnuExportarRecibos, " & _
                '         " CASE WHEN dbo.SsgAccion.CodInterno = 'mnuImportarInformacion' THEN 1 ELSE 0 END AS mnuImportarInformacion " & _
                '         " FROM          dbo.vwSttExpSteCajaCajeros INNER JOIN " & _
                '         "   dbo.SteCajero ON dbo.vwSttExpSteCajaCajeros.nSteCajeroID = dbo.SteCajero.nSteCajeroID INNER JOIN " & _
                '         "   dbo.SrhEmpleado ON dbo.SteCajero.nSrhEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                '         "   dbo.SsgCuenta ON dbo.SrhEmpleado.nSrhEmpleadoID = dbo.SsgCuenta.objEmpleadoID INNER JOIN  " & _
                '         "   dbo.SsgCuentaRol ON dbo.SsgCuenta.SsgCuentaID = dbo.SsgCuentaRol.objCuentaID INNER JOIN " & _
                '         "   dbo.SsgRol ON dbo.SsgCuentaRol.objRolID = dbo.SsgRol.SsgRolID INNER JOIN " & _
                '         "   dbo.SsgRolAccion ON dbo.SsgRol.SsgRolID = dbo.SsgRolAccion.objRolID INNER JOIN " & _
                '         "   dbo.SsgAccion ON dbo.SsgRolAccion.objAccionID = dbo.SsgAccion.SsgAccionID " & _
                '         " WHERE      (dbo.vwSttExpSteCajaCajeros.nSteCajaID IN  (SELECT     nSteCajaID FROM(dbo.vwSttExpFiltroLlaves)" & _
                '         " WHERE      (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ")))" & _
                '         " ORDER BY dbo.vwSttExpSteCajaCajeros.nSteCajeroID, dbo.SsgAccion.CodInterno) AS A " & _
                '         "  GROUP BY SsgCuentaID) AS Lista " & _
                '         " WHERE     (mnuControlCredito > 0) AND (mnuImportarInformacion > 0) "







                SqlCad = " SELECT     ISNULL(COUNT(*), 0) AS TotalCajeros " & _
                                       " FROM         (SELECT     SsgCuentaID, SUM(mnuControlCredito) AS mnuControlCredito, SUM(MantImportarInformacionCajero) AS  MantImportarInformacionCajero " & _
                                       " FROM          (SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID, dbo.SsgAccion.CodInterno, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'mnuControlCredito' THEN 1 ELSE 0 END AS mnuControlCredito, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'MantImportarInformacionCajero' THEN 1 ELSE 0 END AS MantImportarInformacionCajero " & _
                                       " FROM          dbo.vwSttExpSteCajaCajeros INNER JOIN " & _
                                       " dbo.SteCajero ON dbo.vwSttExpSteCajaCajeros.nSteCajeroID = dbo.SteCajero.nSteCajeroID INNER JOIN " & _
                                       " dbo.SrhEmpleado ON dbo.SteCajero.nSrhEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                                       " dbo.SsgCuenta ON dbo.SrhEmpleado.nSrhEmpleadoID = dbo.SsgCuenta.objEmpleadoID INNER JOIN " & _
                                       " dbo.SsgCuentaRol ON dbo.SsgCuenta.SsgCuentaID = dbo.SsgCuentaRol.objCuentaID INNER JOIN " & _
                                       " dbo.SsgRol ON dbo.SsgCuentaRol.objRolID = dbo.SsgRol.SsgRolID INNER JOIN " & _
                                       " dbo.SsgRolAccion ON dbo.SsgRol.SsgRolID = dbo.SsgRolAccion.objRolID INNER JOIN " & _
                                       " dbo.SsgAccion ON dbo.SsgRolAccion.objAccionID = dbo.SsgAccion.SsgAccionID " & _
                                       " WHERE      (dbo.vwSttExpSteCajaCajeros.nSteCajaID IN " & _
                                       " (SELECT     nSteCajaID   FROM dbo.vwSttExpFiltroLlaves " & _
                                       " WHERE      (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & "))) " & _
                                       " AND (dbo.vwSttExpSteCajaCajeros.nActiva = 1)" & _
                                       " ORDER BY dbo.vwSttExpSteCajaCajeros.nSteCajeroID, dbo.SsgAccion.CodInterno) AS A " & _
                                       " GROUP BY SsgCuentaID) AS Lista WHERE     (mnuControlCredito > 0) AND  (MantImportarInformacionCajero> 0) "








                xTotalCajeros = XComando.ExecuteScalar(SqlCad)
                If xTotalCajeros = 0 Then
                    MsgBox("No existe al menos un cajero con la opcion de importar información de socias", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
                'Ver si los cajeros tienen al menos la opcion de
                'mnuControlCredito
                'AgregarReciboAutomatico
                'BuscarGrupoSocia
                'SqlCad = " SELECT     ISNULL(COUNT(*), 0) AS TotalCajeros " & _
                '       " FROM         (SELECT     SsgCuentaID, SUM(mnuControlCredito) AS mnuControlCredito, SUM(AgregarReciboAutomatico) AS AgregarReciboAutomatico, " & _
                '       " SUM(BuscarGrupoSocia) AS BuscarGrupoSocia " & _
                '       " FROM          (SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID, dbo.SsgAccion.CodInterno, " & _
                '       " CASE WHEN dbo.SsgAccion.CodInterno = 'mnuControlCredito' THEN 1 ELSE 0 END AS mnuControlCredito, " & _
                '       " CASE WHEN dbo.SsgAccion.CodInterno = 'AgregarReciboAutomatico' THEN 1 ELSE 0 END AS AgregarReciboAutomatico, " & _
                '       " CASE WHEN dbo.SsgAccion.CodInterno = 'BuscarGrupoSocia' THEN 1 ELSE 0 END AS BuscarGrupoSocia " & _
                '       " FROM          dbo.vwSttExpSteCajaCajeros INNER JOIN " & _
                '       " dbo.SteCajero ON dbo.vwSttExpSteCajaCajeros.nSteCajeroID = dbo.SteCajero.nSteCajeroID INNER JOIN " & _
                '       " dbo.SrhEmpleado ON dbo.SteCajero.nSrhEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                '       " dbo.SsgCuenta ON dbo.SrhEmpleado.nSrhEmpleadoID = dbo.SsgCuenta.objEmpleadoID INNER JOIN " & _
                '       " dbo.SsgCuentaRol ON dbo.SsgCuenta.SsgCuentaID = dbo.SsgCuentaRol.objCuentaID INNER JOIN " & _
                '       " dbo.SsgRol ON dbo.SsgCuentaRol.objRolID = dbo.SsgRol.SsgRolID INNER JOIN " & _
                '       " dbo.SsgRolAccion ON dbo.SsgRol.SsgRolID = dbo.SsgRolAccion.objRolID INNER JOIN " & _
                '       " dbo.SsgAccion ON dbo.SsgRolAccion.objAccionID = dbo.SsgAccion.SsgAccionID " & _
                '       " WHERE      (dbo.vwSttExpSteCajaCajeros.nSteCajaID IN " & _
                '       " (SELECT     nSteCajaID   FROM dbo.vwSttExpFiltroLlaves " & _
                '       " WHERE      (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & "))) " & _
                '       " ORDER BY dbo.vwSttExpSteCajaCajeros.nSteCajeroID, dbo.SsgAccion.CodInterno) AS A " & _
                '       " GROUP BY SsgCuentaID) AS Lista WHERE     (mnuControlCredito = 0) OR  (AgregarReciboAutomatico = 0) OR (BuscarGrupoSocia = 0)"

                SqlCad = " SELECT     ISNULL(COUNT(*), 0) AS TotalCajeros " & _
                                       " FROM         (SELECT     SsgCuentaID, SUM(mnuControlCredito) AS mnuControlCredito, SUM(AgregarReciboAutomatico) AS  AgregarReciboAutomatico ,SUM(BuscarGrupoSocia) AS  BuscarGrupoSocia " & _
                                       " FROM          (SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID, dbo.SsgAccion.CodInterno, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'mnuControlCredito' THEN 1 ELSE 0 END AS mnuControlCredito, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'AgregarReciboAutomatico' THEN 1 ELSE 0 END AS AgregarReciboAutomatico, " & _
                                       " CASE WHEN dbo.SsgAccion.CodInterno = 'BuscarGrupoSocia' THEN 1 ELSE 0 END AS BuscarGrupoSocia " & _
                                       " FROM          dbo.vwSttExpSteCajaCajeros INNER JOIN " & _
                                       " dbo.SteCajero ON dbo.vwSttExpSteCajaCajeros.nSteCajeroID = dbo.SteCajero.nSteCajeroID INNER JOIN " & _
                                       " dbo.SrhEmpleado ON dbo.SteCajero.nSrhEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                                       " dbo.SsgCuenta ON dbo.SrhEmpleado.nSrhEmpleadoID = dbo.SsgCuenta.objEmpleadoID INNER JOIN " & _
                                       " dbo.SsgCuentaRol ON dbo.SsgCuenta.SsgCuentaID = dbo.SsgCuentaRol.objCuentaID INNER JOIN " & _
                                       " dbo.SsgRol ON dbo.SsgCuentaRol.objRolID = dbo.SsgRol.SsgRolID INNER JOIN " & _
                                       " dbo.SsgRolAccion ON dbo.SsgRol.SsgRolID = dbo.SsgRolAccion.objRolID INNER JOIN " & _
                                       " dbo.SsgAccion ON dbo.SsgRolAccion.objAccionID = dbo.SsgAccion.SsgAccionID " & _
                                       " WHERE      (dbo.vwSttExpSteCajaCajeros.nSteCajaID IN " & _
                                       " (SELECT     nSteCajaID   FROM dbo.vwSttExpFiltroLlaves " & _
                                       " WHERE      (nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & "))) " & _
                                       " ORDER BY dbo.vwSttExpSteCajaCajeros.nSteCajeroID, dbo.SsgAccion.CodInterno) AS A " & _
                                       " GROUP BY SsgCuentaID) AS Lista WHERE     (mnuControlCredito >0) AND  (AgregarReciboAutomatico> 0) AND (BuscarGrupoSocia>0) "



                xTotalCajeros = XComando.ExecuteScalar(SqlCad)
                If xTotalCajeros = 0 Then
                    MsgBox("Existe al menos un cajero que no tiene definidas las opciones de accesar a credito,agregar recibo,buscar grupo socia", MsgBoxStyle.Information)
                    cmdCancelar.Enabled = True
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If

            End If




            XdtTabla = New BOSistema.Win.XDataSet.xDataTable


            XdtTabla.ExecuteSql("SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS TotalFichas ,MIN(dbo.SclFichaNotificacionCredito.dFechaPrimerCuota)  As dFechaPrimerCuota  FROM         dbo.SclFichaNotificacionDetalle INNER JOIN  dbo.SclFichaNotificacionCredito ON  dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN dbo.SccSolicitudDesembolsoCredito INNER JOIN dbo.SccSolicitudCheque ON  dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID ON  dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN dbo.StbValorCatalogo ON dbo.SccSolicitudCheque.nStbEstadoSolicitudID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN dbo.SteCaja ON dbo.SclFichaNotificacionCredito.nStbPersonaLugarPagosID = dbo.SteCaja.nStbPersonaLugarPagosID WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '3') AND (dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") GROUP BY dbo.SteCaja.sDescripcionCaja, dbo.SteCaja.nSteCajaID, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion ")

            If XdtTabla.Count > 0 Then

                If MsgBox("Existen " & XdtTabla.ValueField("TotalFichas") & "  Socias que estan revisadas por contabilidad. Pero no Autorizadas." & Chr(13) & "Su Fecha Mínima para iniciar a pagar es al  " & Format(XdtTabla.ValueField("dFechaPrimerCuota"), "dd/MM/yyyy") & Chr(13) & "ESTA SEGURO DE GENERAR", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If


            End If






            If MsgBox("Esta seguro de generar el archivo para envío. Recuerde si ya en Creditos movieron las fichas del lugar de pago en esa caja" & Chr(13) & "ESTA SEGURO", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If







            lectorDatos.Close()
            lectorDatos = comando.ExecuteReader

            XTotalTablas = XcUsuario.ExecuteScalar(mySelectQueryCount)

            CarpetaGenera = XcUsuario.ExecuteScalar("SELECT CarpetaTempo From SttProcesarParametroES ")
            If IsDBNull(CarpetaGenera) Then
                CarpetaGenera = "C:\TmpPasarArchivosXML"
            End If

            If System.IO.Directory.Exists(CarpetaGenera) = True Then


                'para validar borrar archivos todos aunque tenga permiso de lectura.
                'Esta se anexo para hacer el readonly borrado
                BorrarArchivosCarpeta(CarpetaGenera)

                ' Antes estaba estas dos ultimas lineas
                'System.IO.Directory.Delete(CarpetaGenera, True)
                'System.IO.Directory.CreateDirectory(CarpetaGenera)
            Else
                System.IO.Directory.CreateDirectory(CarpetaGenera)
            End If




            'For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.MyDocuments, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            '    My.Computer.FileSystem.DeleteFile(foundFile, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            'Next



            Contador = 1

            grpPresentaProceso.Visible = True
            grpPresentaProceso.BringToFront()

            PrBarProceso.Visible = True
            PrBarProceso.Maximum = 2 * (XTotalTablas + 2)
            PrBarProceso.Minimum = 0
            'Abrir la conexion 
            'con.Open()
            'Ayuda a buscar el mejor plan para la consulta
            Dim OptionForce As String

            OptionForce = ""



            'XdtRegistro.ExecuteSql(SqlCad)
            'If XdtRegistro.Count > 0 Then
            DsBusca = Me.GetDataSet("SELECT     sValorParametro  FROM         dbo.StbValorParametro  WHERE     (nStbParametroID = 93) AND (sValorParametro = '1')", myConnectionString, SegundosConexion)

            If DsBusca.Tables(0).Rows.Count > 0 Then
                OptionForce = " OPTION(FORCE ORDER) "
            End If



            While lectorDatos.Read
                myXMLfile = CarpetaGenera & "\" & lectorDatos("sNombreTablaOrigen") & ".Xml"
                myTXTfile = CarpetaGenera & "\" & lectorDatos("sNombreTablaOrigen") & ".Txt"
                If Me.cboCaja.Columns("nSteCajaId").Value = 0 Then
                    daCust = New SqlDataAdapter(lectorDatos("sQueryTodos"), con)
                Else
                    daCust = New SqlDataAdapter(lectorDatos("sQueryFiltrado") + " " + Replace(lectorDatos("sQueryFiltradoCondicion"), "#ValorSustituir#", Me.cboCaja.Columns("nSteCajaId").Value) & OptionForce, con)
                End If
                daCust.SelectCommand.CommandTimeout = 120
                dsTablas = New DataSet()
                daCust.Fill(dsTablas, lectorDatos("sNombreTablaOrigen"))


                'daCust.Dispose()
                'DESDE AQUI PROBLEMA ANCHO DE BANDO
                'SE PODRIA HACER UNO A UNO LOS REGISTROS
                'dsTablas.Tables(0).m()




                'dsTablas.Tables(0).LoadDataRow(, True)

                'FIN 
                'DESDE AQUI PROBLEMA ANCHO DE BANDO

                If EnviarXML = 1 Then
                    myFileStream = New System.IO.FileStream _
                       (myXMLfile, System.IO.FileMode.Create)

                    MyXmlTextWriter = New System.Xml.XmlTextWriter _
               (myFileStream, System.Text.Encoding.Unicode)
                    Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
                    Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
                    Me.Refresh()

                    dsTablas.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
                    MyXmlTextWriter.Close()
                    myFileStream.Close()

                End If
                '' Escribe el txt del dataset Para 
                If EnviarTXT = 1 Then
                    Me.LblConteo.Text = "Archivo txt " & Contador & " de un total de   " & XTotalTablas + 2
                    Me.LblArchivo.Text = "Archivo Generando : " & myTXTfile
                    Me.Refresh()
                    EscribirDataSetToTxt(dsTablas, myTXTfile, myDelimita)
                    If lectorDatos("sNombreTablaOrigen") = "SclFichaNotificacionCredito" Then
                        TotalFichasGeneradas = dsTablas.Tables(0).Rows.Count
                    End If
                End If


                PrBarProceso.Value = Contador
                Contador = Contador + 1
                PrBarProceso.Value = Contador
                PrBarProceso.Refresh()
                Me.Refresh()

            End While


            myXMLfile = CarpetaGenera & "\SttProcesarParametroES.Xml"
            myTXTfile = CarpetaGenera & "\SttProcesarParametroES.Txt"
            daCust = New SqlDataAdapter("Select * From SttProcesarParametroES ", con)
            daCust.Fill(dsParam, "SttProcesarParametroES")

            'If EnviarXML = 1 Then
            myFileStream = New System.IO.FileStream _
               (myXMLfile, System.IO.FileMode.Create)

            MyXmlTextWriter = New System.Xml.XmlTextWriter _
       (myFileStream, System.Text.Encoding.Unicode)

            Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
            Me.Refresh()


            dsParam.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            MyXmlTextWriter.Close()
            myFileStream.Close()
            'End If
            '' Escribe el txt del dataset Para 

            If EnviarTXT = 1 Then
                Me.LblConteo.Text = "Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
                Me.LblArchivo.Text = "Archivo Generando : " & myTXTfile
                Me.Refresh()
                EscribirDataSetToTxt(dsParam, myTXTfile, myDelimita)
            End If



            PrBarProceso.Value = Contador
            Contador = Contador + 1

            PrBarProceso.Refresh()
            Me.Refresh()




            If XCajaId <> 0 Then  'PARA BASES LOCALES 'Solo pueden generar registros en SttProcesarEnvioES las cajas locales.
                ' La central solo los carga con el Numero de Envio de las cajas locales.
                'Eso se debe hacer en el proceso de importacion cuando es la Central que lo hace.

                If XNumEnvio = -1 Then ' Se Supone que debe existir al menos el registro NoEnvio= 0
                    MsgBox("Base Local no ha sido inicializada. No se encuentra el NoEnvio=0")
                    cmdCancelar.Enabled = True
                    Exit Sub
                    XNumEnvio = 1 'Es la primera vez que se genera un lote para ser enviado.
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
                    XComando.Execute("Insert Into SttProcesarEnvioES(NoEnvio,FechaGenera,EstadoEnvio,SsgCuentaID,nSteCajaId) values(" & XNumEnvio & ",'" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd HH:mm:ss") & "' ,0," & IdUsuario & "," & Me.cboCaja.Columns("nSteCajaId").Value & ")")
                Else
                    XComando.Execute("Update SttProcesarEnvioES Set FechaGenera = '" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd HH:mm:ss") & "' ,EstadoEnvio=0, SsgCuentaID=" & IdUsuario & " Where NoEnvio=" & XNumEnvio & " And nSteCajaId =" & Me.cboCaja.Columns("nSteCajaId").Value)

                End If
            Else 'PARA BASE CENTRAL 
                'En este caso solamente puede generar el registro con NoEnvio= 0 para luego mandarse a la base local  

                If XNumEnvio = -1 Then ' En este caso  NoEnvio= 0 para inicializar el envio a una base local de una caja
                    XNumEnvio = 0 'Es la primera vez que se genera un lote para ser enviado.
                    XEstadoEnvioUltimo = 1
                    XComando.Execute("Insert Into SttProcesarEnvioES(NoEnvio,FechaGenera,EstadoEnvio,SsgCuentaID,nSteCajaId) values(" & XNumEnvio & ",'" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd HH:mm:ss") & "' ,0," & IdUsuario & "," & Me.cboCaja.Columns("nSteCajaId").Value & ")")
                End If

                XComando.Execute("Update SttProcesarEnvioES Set FechaGenera = '" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd HH:mm:ss") & "' ,EstadoEnvio=0, SsgCuentaID=" & IdUsuario & " Where NoEnvio=" & XNumEnvio & " And nSteCajaId =" & Me.cboCaja.Columns("nSteCajaId").Value)
            End If

            'Copiar el ultimo estado de recibos 




            'XComando.Execute("Exec spSttActualizacionBasesLocalesUltimoReciboOficialCajaID " & Me.cboCaja.Columns("nSteCajaId").Value & "," & XNumEnvio)



            XError = EjecutarComandoPasar(myConnectionString, "Exec spSttActualizacionBasesLocalesUltimoReciboOficialCajaID " & Me.cboCaja.Columns("nSteCajaId").Value & "," & XNumEnvio)
            If Trim(XError) <> "" And Not IsNumeric(XError) Then
                MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If












            '            Dim ComandoG As New SqlCommand("Insert Into SttProcesarEnvioES(NoEnvio,FechaGenera,EstadoEnvio,SsgCuentaID ) values(" & XNumEnvio & ",'" & Format(Me.cdeFechaGenera.Value, "yyyy-MM-dd") & "' ,0," & IdUsuario & ")", conexion)


            '           lectorDatos.Close()
            '          lectorDatos = ComandoG.ExecuteReader()


            'Guardar el ultimo registro de envio de la tabla sttProcesarEnvioEs para que ya sea en central se 
            'sepa el ultimo numero de envio para la localidad de caja

            ''Este archivo se usa como cabecera al momento de la carga inicial saber cual es la caja que se envia
            myXMLfile = CarpetaGenera & "\SteCaja.Xml"
            daCust = New SqlDataAdapter("Select Top 1 * From SteCaja " & " Where nSteCajaId =" & Me.cboCaja.Columns("nSteCajaId").Value & " Order By nSteCajaId Desc ", con)
            daCust.Fill(dsCaja, "SteCaja")
            'If EnviarXML = 1 Then
            myFileStream = New System.IO.FileStream _
               (myXMLfile, System.IO.FileMode.Create)

            MyXmlTextWriter = New System.Xml.XmlTextWriter _
       (myFileStream, System.Text.Encoding.Unicode)

            Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
            Me.Refresh()


            dsCaja.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            MyXmlTextWriter.Close()
            myFileStream.Close()
            'End If
            PrBarProceso.Refresh()
            Me.Refresh()





            myXMLfile = CarpetaGenera & "\SttProcesarEnvioES.Xml"
            myTXTfile = CarpetaGenera & "\SttProcesarEnvioES.Txt"
            daCust = New SqlDataAdapter("Select Top 1 * From SttProcesarEnvioES " & " Where nSteCajaId =" & Me.cboCaja.Columns("nSteCajaId").Value & " Order By NoEnvio Desc ", con)
            daCust.Fill(dsEnvio, "SttProcesarEnvioES")
            'If EnviarXML = 1 Then
            myFileStream = New System.IO.FileStream _
               (myXMLfile, System.IO.FileMode.Create)

            MyXmlTextWriter = New System.Xml.XmlTextWriter _
       (myFileStream, System.Text.Encoding.Unicode)

            Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 2
            Me.LblArchivo.Text = "Archivo Generando : " & myXMLfile
            Me.Refresh()


            dsEnvio.WriteXml(MyXmlTextWriter, XmlWriteMode.WriteSchema)
            MyXmlTextWriter.Close()
            myFileStream.Close()
            'End If
            If EnviarTXT = 1 Then
                Me.LblConteo.Text = "Archivo Txt " & Contador & " de un total de   " & XTotalTablas + 2
                Me.LblArchivo.Text = "Archivo Generando : " & myTXTfile
                Me.Refresh()
                EscribirDataSetToTxt(dsEnvio, myTXTfile, myDelimita)
            End If

            PrBarProceso.Value = Contador
            Contador = Contador + 1

            PrBarProceso.Refresh()
            Me.Refresh()





            'Aqui comienza la generación del archivo Zip
            XtiempoZip = Now
            NombreZip = CarpetaGenera & "\ExportarCaja_" & Me.cboCaja.Columns("nSteCajaId").Value & "_" & XNumEnvio & ".zip"
            Me.LblConteo.Text = "Generando empaquetamiento  Archivo  :" & NombreZip
            Me.LblArchivo.Text = " "


            unlocked = zip.UnlockComponent("ZIP-TEAMBEAN_3988ED58913G")
            If (Not unlocked) Then
                MsgBox("Fallo al desenllavar libreria Zip ")
                cmdCancelar.Enabled = True
                Exit Sub
            End If

            zip.NewZip(NombreZip)

            zip.PasswordProtect = True
            'zip.Encryption = 4
            'zip.EncryptKeyLength = 256
            zip.SetPassword("MCBDTRNS732985")

            ' Append files to the AES Encrypted Zip.
            Dim success As Boolean
            zip.AppendFromDir = CarpetaGenera  '"C:\TemporalPasaXML"
            ' Add the entire directory tree.
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

            'Poner ReadOnly si se indica en la tabla  SttProcesarCajaParametroES 0 no se pone en modo readonly, mayor si se pone, por defecto se crea en 0.


            If Me.cboCaja.Columns("nPonerZipModoLectura").Value > 0 Then
                Dim attribute As System.IO.FileAttributes = IO.FileAttributes.ReadOnly
                System.IO.File.SetAttributes(NombreZip, attribute)
            End If






            lectorDatos.Close()
            lectorDatos = comando.ExecuteReader






            PrBarProceso.Refresh()
            Me.Refresh()
            Me.LblConteo.Text = ""
            Me.LblArchivo.Text = "Salvando a dispositivo USB"
            CargarGenerados()
            GuardarArchivoZipBD()


            'MsgBox("Generación de Lote completada Tiempo de ejecución:" & DateDiff(DateInterval.Second, Now, XtiempoInicial) & " Segundos " & Chr(13) & " Tiempo de Empaquetado  " & DateDiff(DateInterval.Second, XtiempoZip, Now) & " Segundos ", MsgBoxStyle.Information)

            grpPresentaProceso.Visible = False
            PrBarProceso.Visible = False
            CargarParametros()
            cmdCancelar.Enabled = True

            'Cerrar la conexion 
            'con.Close()
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            grpPresentaProceso.Visible = False
            PrBarProceso.Visible = False
            cmdCancelar.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Finally
            'MyXmlTextWriter.Close()
            'myFileStream.Close()
        End Try
    End Sub

    Private Sub BorrarArchivosCarpeta(ByVal CarpetaGenera As String)
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(CarpetaGenera, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            My.Computer.FileSystem.DeleteFile(foundFile, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Next
    End Sub
    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        CargarGenerados()
        CargarCajeros()
    End Sub
    Private Sub CargarCajeros()
        Try
            Dim Strsql As String

            'Maestro (Cajeros):

            Strsql = "SELECT     dbo.vwSteCajero.sNombre FROM         dbo.vwSteCajeroCajas INNER JOIN  dbo.vwSteCajero ON dbo.vwSteCajeroCajas.nSteCajeroID = dbo.vwSteCajero.nSteCajeroID WHERE     (dbo.vwSteCajeroCajas.nActiva = 1) And  (dbo.vwSteCajeroCajas.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ")  "
            

            If XdsCajero.ExistTable("Cajeros") Then
                XdsCajero("Cajeros").ExecuteSql(Strsql)
            Else
                XdsCajero.NewTable(Strsql, "Cajeros")
                XdsCajero("Cajeros").Retrieve()
            End If






            Me.grdCajas.DataSource = XdsCajero("Cajeros").Source

            'Actualizando el caption de los GRIDS:

            Me.grdCajas.Caption = " Listado de Cajeros asignadas a la Caja (" + Me.grdCajas.RowCount.ToString + " registros)"
            FormatoCajeros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoCajeros()
        Try

            '-- Configuración del Grid Cajeros:
    
            Me.grdCajas.Splits(0).DisplayColumns("sNombre").Width = 400
            Me.grdCajas.Columns("sNombre").Caption = "Nombre"
            
            Me.grdCajas.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            
            'Estado Cajero Activo como checkbox y centrado:

            Me.grdCajas.Splits(0).DisplayColumns("sNombre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub CmbListaEnOtrosMunicipios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbListaEnOtrosMunicipios.Click
        Dim XdtRegistro As New BOSistema.Win.XDataSet.xDataTable
        Dim SqlCad As String
        Dim frmVisor As New frmCRVisorReporte
        Try

            frmVisor.NombreReporte = "RepStt1.rpt"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            SqlCad = " SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.nCodigo, dbo.SteCaja.sDescripcionCaja, dbo.vwStbUbicacionGeografica.Departamento,  dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbMunicipioID FROM         dbo.SteCaja INNER JOIN  dbo.vwStbUbicacionGeografica ON dbo.SteCaja.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID WHERE dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value
            XdtRegistro.ExecuteSql(SqlCad)
            If XdtRegistro.Count > 0 Then
                frmVisor.CRVReportes.SelectionFormula = "{vwSttFichasEnOtroMunicipioCaja.nStbMunicipioID}=" & XdtRegistro.ValueField("nStbMunicipioID")
            End If
            frmVisor.ShowDialog()
      
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CmbNoHanPagado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNoHanPagado.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.Parametros("@nSteCajaID") = Me.cboCaja.Columns("nSteCajaId").Value
            frmVisor.NombreReporte = "RepStt2.rpt"
            frmVisor.Text = "Listado de Socias que no tienen pagado o ingresado su ultima cuota correspondiente"
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.ShowDialog()
            'If grdRecibo.RowCount > 0 Then
            '    frmVisor.SQLQuery = "Select * From vwSccReciboOficialCajaDetalle Where nSccReciboOficialCajaID = " & grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID") & " Order by nSccReciboOficialCajaID,nNumeroCuota "
            '    frmVisor.ShowDialog()
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub CmbNoHanCerrado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNoHanCerrado.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.Parametros("@nSteCajaID") = Me.cboCaja.Columns("nSteCajaId").Value
            frmVisor.NombreReporte = "RepStt3.rpt"
            frmVisor.Text = "Listado de Socias con recibos que no han sido dado en estado cerrado diario."
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.ShowDialog()
            'If grdRecibo.RowCount > 0 Then
            '    frmVisor.SQLQuery = "Select * From vwSccReciboOficialCajaDetalle Where nSccReciboOficialCajaID = " & grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID") & " Order by nSccReciboOficialCajaID,nNumeroCuota "
            '    frmVisor.ShowDialog()
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub


    Private Sub cmbRevisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRevisar.Click
        Dim zip As New Chilkat.Zip()
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
        Dim XdtTabla As BOSistema.Win.XDataSet.xDataTable

        Dim XdtRegistro As New BOSistema.Win.XDataSet.xDataTable

        'Dim mySelectQuery As String _
        '    = "Select * From SttProcesarTablasES Where nProcesar=1 "
        'Dim mySelectQueryCount As String _
        '            = "Select Count(*) AS TotalT  From SttProcesarTablasES Where nProcesar=1 And nTipoProceso=1"


        Dim myXMLfile As String = ""
        Dim myTXTfile As String = ""
        Dim myDelimita As String = "|"
        Dim myFileStream As System.IO.FileStream ' _
        '("", System.IO.FileMode.Create)
        Dim MyXmlTextWriter As System.Xml.XmlTextWriter  ' _
        '(myFileStream, System.Text.Encoding.Unicode)
        Dim EnviarXML As Integer = 0
        Dim EnviarTXT As Integer = 0


   

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
        Dim xTotalCajeros As Integer
        Dim XEstadoEnvioUltimoAplicadoCentral As Integer
        Dim MunicipioIdCaja As Integer
        Dim MunicipioNombreCaja As String
        Dim SqlCad As String


        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            XNumEnvio = -1
            XEstadoEnvioUltimo = -1
            XEstadoEnvioUltimoAplicadoCentral = -1
            Dim XOperActualizarOAgregar As Integer
            Dim ComandoBRegId As New SqlCommand("Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = " & Me.cboCaja.Columns("nSteCajaId").Value & "    Order by  NoEnvio desc   ", conexion)
            'lectorDatos.Close()
            lectorDatos = ComandoBRegId.ExecuteReader
            XOperActualizarOAgregar = 1
            While lectorDatos.Read
                XNumEnvio = lectorDatos("NoEnvio")
                XEstadoEnvioUltimo = lectorDatos("EstadoEnvio")
                XEstadoEnvioUltimoAplicadoCentral = lectorDatos("AplicadoEnCentral")
            End While

            SqlCad = ""
            SqlCad = "EXEC SpSttFichasUltimasPagadas  " & Me.cboCaja.Columns("nSteCajaId").Value
            XdtRegistro.ExecuteSql(SqlCad)
            If XdtRegistro.Count > 0 Then
                ChkSinUltimaCuota.Checked = True
            End If






            SqlCad = "EXEC SpSttRecibosEnProceso  " & Me.cboCaja.Columns("nSteCajaId").Value
            XdtRegistro.ExecuteSql(SqlCad)
            If XdtRegistro.Count > 0 Then
                ChkRecibosEnProceso.Checked = True
            End If




            If XNumEnvio = 0 Then  'Es la primera vez

                SqlCad = "SELECT     dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID, dbo.vwSteRecibosArqueadosNoIngresados.nStbDepartamentoID, " & _
                " dbo.vwSteRecibosArqueadosNoIngresados.Serie, dbo.vwSteRecibosArqueadosNoIngresados.sNombreColor, " & _
                        " dbo.vwSteRecibosArqueadosNoIngresados.Departamento, dbo.vwSteRecibosArqueadosNoIngresados.nStbMunicipioID,  " & _
                      " dbo.vwSteRecibosArqueadosNoIngresados.Municipio, dbo.vwSteRecibosArqueadosNoIngresados.nCodigo, " & _
                      " dbo.vwSteRecibosArqueadosNoIngresados.EstadoArqueo, dbo.vwSteRecibosArqueadosNoIngresados.dFechaArqueo,  " & _
                      " dbo.vwSteRecibosArqueadosNoIngresados.NoRecibo, dbo.vwSteRecibosArqueadosNoIngresados.NombrePrograma,  " & _
                      " dbo.vwSteRecibosArqueadosNoIngresados.nStbTipoProgramaID, dbo.vwSteRecibosArqueadosNoIngresados.CodPrograma, " & _
                " dbo.vwSteRecibosArqueadosNoIngresados.nCodigoTalonario, dbo.SteCaja.nSteCajaID " & _
                "FROM         dbo.vwSteRecibosArqueadosNoIngresados INNER JOIN dbo.SteArqueoCaja ON dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID = dbo.SteArqueoCaja.nSteArqueoCajaID INNER JOIN dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID " & _
                " WHERE     dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value

                XdtRegistro.ExecuteSql(SqlCad)
                If XdtRegistro.Count > 0 Then
                    ChkRecibosEnArqueoNocredito.Checked = True

                End If

            End If

            If XNumEnvio > 0 Then ' Si es envio mayor que cero validar que existan los cierres para los cajeros fechas de la caja.



                SqlCad = "SELECT     ListaCajerosLocal.nSteCajaIDLocal, ListaCajerosLocal.nSrhEmpleadoID, ListaCajerosLocal.sNombre, ListaCajerosLocal.dFechaRecibo " & _
                         "    FROM         (SELECT     dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.SrhEmpleado.nSrhEmpleadoID, dbo.vwStbPersona.sNombre, " & _
                         " dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nPrincipal) AS nPrincipal,  " & _
                         "                     SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nMantenimientoValor) AS nMantenimientoValor, " & _
                         "                     SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesCorrientes) AS nInteresesCorrientes, " & _
                         "                     SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesMoratorios) AS nInteresesMoratorios, " & _
                         "                     SUM(dbo.SttLocalSccReciboOficialCaja.nValor) AS nValor " & _
                         " FROM          dbo.SttLocalSccReciboOficialCaja INNER JOIN    dbo.SttLocalSccReciboOficialCajaDetalle ON  " & _
                         " dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccReciboOficialCajaDetalle.nSccReciboOficialCajaID INNER JOIN " & _
                         " dbo.SrhEmpleado ON dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                         " dbo.vwStbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID " & _
                         " WHERE      (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = " & XNumEnvio & ") " & _
                         " GROUP BY dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.vwStbPersona.sNombre, dbo.SrhEmpleado.nSrhEmpleadoID,  " & _
                         " dbo.SttLocalSccReciboOficialCaja.dFechaRecibo) AS ListaCajerosLocal LEFT OUTER JOIN  (SELECT     SrhEmpleado_1.nSrhEmpleadoID, dbo.SteArqueoCaja.dFechaArqueo, dbo.SteArqueoCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja, " & _
                         " dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion " & _
                         "   FROM          dbo.StbPersona INNER JOIN " & _
                         "   dbo.SrhEmpleado AS SrhEmpleado_1 ON dbo.StbPersona.nStbPersonaID = SrhEmpleado_1.nStbPersonaID INNER JOIN " & _
                         " dbo.SteCajero ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteCajero.nSrhEmpleadoID INNER JOIN " & _
                         " dbo.SteArqueoCaja ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteArqueoCaja.nSrhCajeroId INNER JOIN " & _
                         " dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER JOIN " & _
                         " dbo.StbValorCatalogo ON dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                         "   WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2')) AS ArqueoCerrado ON  " & _
                         " ListaCajerosLocal.nSrhEmpleadoID = ArqueoCerrado.nSrhEmpleadoID AND ListaCajerosLocal.nSteCajaIDLocal = ArqueoCerrado.nSteCajaID AND " & _
                         " ListaCajerosLocal.dFechaRecibo = ArqueoCerrado.dFechaArqueo  WHERE(ArqueoCerrado.nSrhEmpleadoID Is NULL) "
                XdtRegistro.ExecuteSql(SqlCad)
                If XdtRegistro.Count > 0 Then
                    ChkFaltanArqueos.Checked = True
                Else  'No faltan arqueos cerrados ver si existen para cada fecha los arqueos aparte de recuperacion
                    SqlCad = " SELECT     SttCentralArqueoRecuperacion_1.dFechaArqueo, ListaArqueoFn.TotalCajeros, SttCentralArqueoRecuperacion_1.nObligado " & _
                                " FROM         (SELECT     nSteCajaID, EnvioNumero, dFechaArqueo, COUNT(nSrhCajeroId) AS TotalCajeros " & _
                                "  FROM          (SELECT     ArqueoTodos.nSrhCajeroId, ArqueoTodos.nSteCajaID, ArqueoTodos.dFechaArqueo, ArqueoTodos.nSteArqueoCajaID,  " & _
                                                                       "  ArqueoTodos.EnvioNumero, ArqueoNormal.nSteArqueoCajaID AS Expr1 " & _
                                                  " FROM          (SELECT     TOP (100) PERCENT dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, " & _
                                                                                                 " dbo.SteArqueoCaja.nSrhCajeroId, dbo.SteArqueoCaja.nSteCajaID, dbo.SteArqueoCaja.dFechaArqueo, " & _
                                                                                                 " dbo.SteArqueoCaja.nSteArqueoCajaID, dbo.SttCentralArqueoRecuperacion.EnvioNumero, " & _
                                                    "  dbo.SttCentralArqueoRecuperacion.nObligado FROM          dbo.SteArqueoCaja INNER JOIN dbo.StbValorCatalogo ON                                                                                             dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                                    " dbo.SttCentralArqueoRecuperacion ON  dbo.SteArqueoCaja.nSteCajaID = dbo.SttCentralArqueoRecuperacion.nSteCajaID AND  dbo.SteArqueoCaja.dFechaArqueo = dbo.SttCentralArqueoRecuperacion.dFechaArqueo  WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2') " & _
                                                    "AND (dbo.SteArqueoCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND  (dbo.SttCentralArqueoRecuperacion.EnvioNumero = " & XNumEnvio & ") AND (dbo.SttCentralArqueoRecuperacion.nObligado = 1) " & _
                                                                         " ORDER BY dbo.SteArqueoCaja.dFechaArqueo DESC) AS ArqueoTodos LEFT OUTER JOIN " & _
                                                                           "  (SELECT     LIstaRec.nSteCajaIDLocal, LIstaRec.nSrhEmpleadoCajeroID, LIstaRec.dFechaRecibo, Arqueo.nSrhCajeroId,  " & _
                                                   " Arqueo.nSteArqueoCajaID FROM          (SELECT     nSteCajaIDLocal, nSrhEmpleadoCajeroID, dFechaRecibo  FROM dbo.SttLocalSccReciboOficialCaja " & _
                                                   " WHERE      (nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (EnvioNumero = " & XNumEnvio & ") " & _
                                                   " GROUP BY nSrhEmpleadoCajeroID, dFechaRecibo, nSteCajaIDLocal) AS LIstaRec INNER JOIN  (SELECT     TOP (100) PERCENT StbValorCatalogo_1.sCodigoInterno, StbValorCatalogo_1.sDescripcion, SteArqueoCaja_1.nSrhCajeroId, SteArqueoCaja_1.nSteCajaID, SteArqueoCaja_1.dFechaArqueo,SteArqueoCaja_1.nSteArqueoCajaID FROM          dbo.SteArqueoCaja AS SteArqueoCaja_1 INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  SteArqueoCaja_1.nStbEstadoArqueoID = StbValorCatalogo_1.nStbValorCatalogoID WHERE      (StbValorCatalogo_1.sCodigoInterno = '2') " & _
                                                   "AND (SteArqueoCaja_1.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") " & _
                                                   " ORDER BY SteArqueoCaja_1.dFechaArqueo DESC) AS Arqueo ON  LIstaRec.nSteCajaIDLocal = Arqueo.nSteCajaID AND LIstaRec.dFechaRecibo = Arqueo.dFechaArqueo AND                                                                                                    LIstaRec.nSrhEmpleadoCajeroID = Arqueo.nSrhCajeroId) AS ArqueoNormal ON " & _
                                                   " ArqueoTodos.nSteArqueoCajaID = ArqueoNormal.nSteArqueoCajaID  WHERE      (ArqueoNormal.nSteArqueoCajaID IS NULL)) AS ListaArqueos  GROUP BY dFechaArqueo, nSteCajaID, EnvioNumero) AS ListaArqueoFn RIGHT OUTER JOIN  dbo.SttCentralArqueoRecuperacion AS SttCentralArqueoRecuperacion_1 ON   ListaArqueoFn.nSteCajaID = SttCentralArqueoRecuperacion_1.nSteCajaID AND   ListaArqueoFn.EnvioNumero = SttCentralArqueoRecuperacion_1.EnvioNumero AND   ListaArqueoFn.dFechaArqueo = SttCentralArqueoRecuperacion_1.dFechaArqueo WHERE     (ListaArqueoFn.TotalCajeros IS NULL) AND (SttCentralArqueoRecuperacion_1.nObligado = 1) AND (SttCentralArqueoRecuperacion_1.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") "

                    XdtRegistro.ExecuteSql(SqlCad)
                    If XdtRegistro.Count > 0 Then
                        ChkFaltanArqueosRecuperacion.Checked = True


                    End If


                End If
            End If


            'Revisar  Que los Recibos manuales en los arqueos esten ingresados en Credito'






            SqlCad = "SELECT     ListaFi.nSteArqueoCajaID, dbo.vwSteRecibosArqueadosNoIngresados.nCodigo, dbo.vwSteRecibosArqueadosNoIngresados.NoRecibo,                      dbo.vwSteRecibosArqueadosNoIngresados.dFechaArqueo " & _
                     " FROM         (SELECT     nSteArqueoCajaID " & _
                   " FROM          (SELECT     TOP (100) PERCENT ArqueoCerrado.nSteArqueoCajaID " & _
                                         "  FROM          (SELECT     dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.SrhEmpleado.nSrhEmpleadoID, dbo.vwStbPersona.sNombre, " & _
            " dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nPrincipal) " & _
            " AS nPrincipal, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nMantenimientoValor) AS nMantenimientoValor, " & _
            " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesCorrientes) AS nInteresesCorrientes,  " & _
            " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesMoratorios) AS nInteresesMoratorios,  " & _
            " SUM(dbo.SttLocalSccReciboOficialCaja.nValor) AS nValor " & _
            " FROM          dbo.SttLocalSccReciboOficialCaja INNER JOIN " & _
            " dbo.SttLocalSccReciboOficialCajaDetalle ON  " & _
            " dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccReciboOficialCajaDetalle.nSccReciboOficialCajaID INNER Join " & _
            " dbo.SrhEmpleado ON dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN dbo.vwStbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID " & _
            " WHERE      (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.cboCaja.Columns("nSteCajaId").Value & ") AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = " & XNumEnvio & ") " & _
            " GROUP BY dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, dbo.vwStbPersona.sNombre,dbo.SrhEmpleado.nSrhEmpleadoID, dbo.SttLocalSccReciboOficialCaja.dFechaRecibo)  AS ListaCajerosLocal INNER JOIN  (SELECT     SrhEmpleado_1.nSrhEmpleadoID, dbo.SteArqueoCaja.dFechaArqueo, dbo.SteArqueoCaja.nSteCajaID, " & _
            " dbo.SteCaja.sDescripcionCaja, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, dbo.SteArqueoCaja.nSteArqueoCajaID  FROM          dbo.StbPersona INNER JOIN dbo.SrhEmpleado AS SrhEmpleado_1 ON  dbo.StbPersona.nStbPersonaID = SrhEmpleado_1.nStbPersonaID INNER JOIN " & _
            " dbo.SteCajero ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteCajero.nSrhEmpleadoID INNER JOIN dbo.SteArqueoCaja ON SrhEmpleado_1.nSrhEmpleadoID = dbo.SteArqueoCaja.nSrhCajeroId INNER JOIN dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER JOIN dbo.StbValorCatalogo ON " & _
            " dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID WHERE      (dbo.StbValorCatalogo.sCodigoInterno = '2')) AS ArqueoCerrado ON   ListaCajerosLocal.nSrhEmpleadoID = ArqueoCerrado.nSrhEmpleadoID AND  ListaCajerosLocal.nSteCajaIDLocal = ArqueoCerrado.nSteCajaID AND " & _
            " ListaCajerosLocal.dFechaRecibo = ArqueoCerrado.dFechaArqueo  ORDER BY ListaCajerosLocal.dFechaRecibo, ListaCajerosLocal.nSrhEmpleadoID) AS ListaArqueo GROUP BY nSteArqueoCajaID) AS ListaFi INNER JOIN dbo.vwSteRecibosArqueadosNoIngresados ON ListaFi.nSteArqueoCajaID = dbo.vwSteRecibosArqueadosNoIngresados.nSteArqueoCajaID "

            XdtRegistro.ExecuteSql(SqlCad)
            If XdtRegistro.Count > 0 Then
                ChkRecibosEnArqueoNocredito.Checked = True

            End If
















            MunicipioIdCaja = 0
            'Obtener la ubicacion del municipio de la caja a traves del barrio
            SqlCad = " SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.nCodigo, dbo.SteCaja.sDescripcionCaja, dbo.vwStbUbicacionGeografica.Departamento,  dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbMunicipioID FROM         dbo.SteCaja INNER JOIN  dbo.vwStbUbicacionGeografica ON dbo.SteCaja.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID WHERE dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value
            XdtRegistro.ExecuteSql(SqlCad)
            If XdtRegistro.Count > 0 Then
                MunicipioNombreCaja = XdtRegistro.ValueField("Municipio")
                MunicipioIdCaja = XdtRegistro.ValueField("nStbMunicipioID")
            End If




            SqlCad = "SELECT  NombreGrupo, sNumeroCedula,  CodFicha, DesEstadoFicha, CodCred, DesEstadoCred, nCreditoRechazado, CodigoUbicacion, Departamento, Municipio, Distrito, Barrio, nStbDepartamentoID, nStbMunicipioID, nStbDistritoID, nStbPersonaLugarPagosID, nCerrada, nStbPersonaLugarPagosIDCaja, nStbMunicipioIDCaja,  DepartamentoCaja, MunicipioCaja, DistritoCaja, nSclFichaNotificacionID, nCodigo FROM dbo.vwSttFichasEnOtroMunicipioCaja WHERE nStbMunicipioID = " & MunicipioIdCaja


            XdtRegistro.ExecuteSql(SqlCad)
            If XdtRegistro.Count > 0 Then
                ChkEnOtroMunicipio.Checked = True


            End If






            XdtTabla = New BOSistema.Win.XDataSet.xDataTable


            XdtTabla.ExecuteSql("SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS TotalFichas FROM         dbo.SclFichaNotificacionDetalle INNER JOIN  dbo.SclFichaNotificacionCredito ON  dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN dbo.SccSolicitudDesembolsoCredito INNER JOIN dbo.SccSolicitudCheque ON  dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID ON  dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN dbo.StbValorCatalogo ON dbo.SccSolicitudCheque.nStbEstadoSolicitudID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN dbo.SteCaja ON dbo.SclFichaNotificacionCredito.nStbPersonaLugarPagosID = dbo.SteCaja.nStbPersonaLugarPagosID WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '3') AND (dbo.SteCaja.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaId").Value & ") GROUP BY dbo.SteCaja.sDescripcionCaja, dbo.SteCaja.nSteCajaID, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion ")

            If XdtTabla.Count > 0 Then

                ChkSociasnoAutorizadas.Checked = True


            End If




            Me.Cursor = System.Windows.Forms.Cursors.Default




            MsgBox("Proceso de revisado Finalizado.", MsgBoxStyle.Information)


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Finally
            'MyXmlTextWriter.Close()
            'myFileStream.Close()
        End Try
    End Sub


    Private Sub CmbReiniciarContador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbReiniciarContador.Click
        Try
            'ReiniciarContador()
            grpGenera.Enabled = False
            gridGenerados.Enabled = False
            GrpReiniciar.Visible = True

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub CmbCancelarReinicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCancelarReinicio.Click
        Try
            grpGenera.Enabled = True
            gridGenerados.Enabled = True
            GrpReiniciar.Visible = False
            Seguridad()
        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub CmbAplicarReinico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAplicarReinico.Click
        Try

            LiberarFichas()


            grpGenera.Enabled = True
            gridGenerados.Enabled = True
            GrpReiniciar.Visible = False
            Seguridad()
        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub LiberarFichas()
        Dim XNumEnvio, XEstadoEnvioUltimo As Integer
        'Dim success As Boolean
        Dim zip As New Chilkat.Zip()
        'Dim unlocked As Boolean
        Dim NombreCaja As String = ""
        Dim XNombreArchivo, XNombreCarpeta As String
        Dim dsTablas, dsTablasDestino As New DataSet
        Dim dsTablaEnvio, dsTablaCaja, dsTablaParametros As New DataSet
        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"
        Dim myConnectionStringTemporal As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & XBaseTemporal & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"
        Dim myConnectionStringTemporalOLEDB As String = "Provider=SQLOLEDB;User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & XBaseTemporal & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"

        Dim XcUsuario As New BOSistema.Win.XComando
        'Dim XComando As New BOSistema.Win.XComando



        Dim XTotalTablas, Contador As Integer
        Dim myXMLfile As String = ""
        'Dim myXMLfile As String = "c:\mySchema.xml"

        'Dim myFileStream As System.IO.FileStream
        '           (myXMLfile, System.IO.FileMode.Open)
        'Dim MyXmlTextWriter As New System.Xml.XmlTextWriter _
        '   (myFileStream, System.Text.Encoding.Unicode)


        ' Crea el comando

        conexion.ConnectionString = myConnectionString
        'Dim comando As New SqlCommand(mySelectQuery, conexion)
        'Dim Xcomando As New SqlCommand(mySelectQuery, conexion)

        ' Crea el DataReader
        Dim lectorDatos As SqlDataReader

        ' Conecta con la Base de Datos
        conexion.Open()



        Dim con As New SqlConnection(myConnectionString)
        Dim conBaseTemporal As New SqlConnection(myConnectionStringTemporal)
        Dim daCust As New SqlDataAdapter("", "")
        Dim daTabla As New SqlDataAdapter("", "")
        Dim daTablaDestino As New SqlDataAdapter("", "")
        Dim XComando As New BOSistema.Win.XComando

        Dim IdUsuario As Integer
        Dim CargarXML As Integer = 0
        Dim CargarTXT As Integer = 0
        Dim XError As String = ""

        Dim xTotalNoAplicadoCentral As Integer
        Dim SqlCad As String

        ' NombreCaja = Me.cboCaja.Columns("sDescripcionCaja").Value
        Try

            If Me.TxtMotivoReinicio.Text.Trim() = "" Then
                MsgBox("Debe indicar el Motivo " & Me.cboCaja.Text, MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            SqlCad = "SELECT     NoEnvio, nSteCajaId, EstadoEnvio, SsgCuentaID, FechaGenera, AplicadoEnCentral             FROM dbo.SttProcesarEnvioES WHERE     (AplicadoEnCentral = 0) and (NoEnvio>0) And  nSteCajaId=" & Me.cboCaja.Columns("nSteCajaid").Value

            xTotalNoAplicadoCentral = XComando.ExecuteScalar(SqlCad)
            If xTotalNoAplicadoCentral > 0 Then
                MsgBox("Existe al menos una recepción de recibos en temporal no aplicado a la base definitiva ", MsgBoxStyle.Information)
                Exit Sub
            End If



            IdUsuario = XcUsuario.ExecuteScalar("SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')")


            If MsgBox(" Esta Seguro de Liberar las Fichas para la Caja " & cboCaja.Text & Chr(13) & "Recuerde este procedimiento se implementa generalment si el archivo no pudo ser cargado en la base local. Pero esta base sigue activa.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If










            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttLiberarFichas " & Me.cboCaja.Columns("nSteCajaid").Value & ",'" & Me.TxtMotivoReinicio.Text.Trim() & "'," & IdUsuario)
            If Trim(XError) <> "" Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If



            'Dim ComBorrar As New SqlCommand("EXEC spSttBorrarBaseTemporal", conexion)
            'ComBorrar.ExecuteNonQuery()

            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default


            MsgBox("Se Liberaron las Fichas para la Caja  " & Me.cboCaja.Text, MsgBoxStyle.Information, NombreSistema)

            CargarGenerados()
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
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar Reiniciar Caja Contador:
            If Seg.HasPermission("LiberarFichasCajaDesconectada") Then
                Me.CmbReiniciarContador.Enabled = True
                Me.CmbReiniciarContador.Visible = True
            Else
                Me.CmbReiniciarContador.Enabled = False
                Me.CmbReiniciarContador.Visible = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class