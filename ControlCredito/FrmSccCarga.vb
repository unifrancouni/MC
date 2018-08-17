Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.OleDb
'Imports Microsoft.SqlServer.Dts.Tasks.XMLTask.DTSXMLSaveResultTo
Imports System.Xml


Public Class FrmSccCarga

    Dim XdtTabla As BOSistema.Win.XDataSet.xDataTable

    Dim XdsGenera As BOSistema.Win.XDataSet
    Dim XdsCaja As BOSistema.Win.XDataSet
    Dim XCajaId As Integer
    Dim CarpetaGenera As String
    Dim XCarpetaTempoUSBCopia As String
    Dim XEstadoEnvio As Integer
    Dim XBaseTemporal As String
    Dim XCarpetaTxtFisica, XCarpetaTxtLogica, XCarpetaRespaldoCarga As String
    Dim XSubCarpeta As String
    Dim CarpetaAbrir As String
    Dim XMaxItem As Integer
    Dim IntPermiteConsultar As Integer
    ' When using events, we must declare the variable as a global or
    ' class member WithEvents
    ' Once it is declared, we can select the "zip" object from 
    ' the VB.NET IDE to see the events.  If you select the event
    ' from the dropdown, Visual Studio will create the callback
    ' subroutine for you.
    Dim WithEvents zip As New Chilkat.Zip()

    Dim mNomRep As String

    Public Property ColorVentana() As String
        Get
            Return mNomRep
        End Get
        Set(ByVal value As String)
            mNomRep = value
        End Set
    End Property
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

    '-------------------------------------------------------------------------
    Private Sub CargarCaja(ByVal intCaja As Integer)
        Try
            Dim Strsql As String

            Me.cboCaja.ClearFields()

            If intCaja = 0 Then
                If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                    Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden " &
                                             " FROM         dbo.StbPersona INNER JOIN " &
                                              "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " &
                                              "  INNER Join          dbo.SttProcesarCajaParametroES ON dbo.SteCaja.nSteCajaID = dbo.SttProcesarCajaParametroES.nSteCajaID " &
                                              " WHERE(dbo.SteCaja.nCerrada = 0) "  ' And  dbo.SteCaja.nSteCajaID Not in (Select nSteCajaID From SttProgramasExternosCajas Where nCerrada=0 ) Order By dbo.SteCaja.sDescripcionCaja "
                Else
                    'Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden " & _
                    '                         " FROM         dbo.StbPersona INNER JOIN " & _
                    '                          "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " & _
                    '                          "  INNER Join          dbo.SttProcesarCajaParametroES ON dbo.SteCaja.nSteCajaID = dbo.SttProcesarCajaParametroES.nSteCajaID " & _
                    '                          " WHERE(dbo.SteCaja.nCerrada = 0)  and  dbo.SteCaja.nStbDelegacionProgramaID =  " & InfoSistema.IDDelegacion  ' And  dbo.SteCaja.nSteCajaID Not in (Select nSteCajaID From SttProgramasExternosCajas Where nCerrada=0 ) Order By dbo.SteCaja.sDescripcionCaja "

                    Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden   " &
                            " FROM         dbo.StbPersona INNER JOIN   dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID    " &
                            " INNER Join          dbo.SttProcesarCajaParametroES ON dbo.SteCaja.nSteCajaID = dbo.SttProcesarCajaParametroES.nSteCajaID   " &
                            " WHERE(dbo.SteCaja.nCerrada = 0)  " &
                            " and  dbo.SteCaja.nStbDelegacionProgramaID =  " & InfoSistema.IDDelegacion & "" &
                            " UNION all " &
                            " SELECT nSteCajaID, sDescripcionCaja, 1 AS Orden FROM vwSteCaja  " &
                            " WHERE nStbMunicipioID IN ( " &
                            " SELECT ma.nStbMunicipioID FROM StbMunicipioAtendidoDepartamentoAlterno ma  " &
                            " WHERE ma.nStbDepartamentoAtiendeID = " &
                            " (SELECT dbo.StbDepartamento.nStbDepartamentoID " &
                            " FROM dbo.StbDelegacionPrograma INNER JOIN " &
                            " dbo.StbMunicipio ON dbo.StbDelegacionPrograma.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " &
                            " dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID " &
                            " WHERE (dbo.StbDelegacionPrograma.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) AND (ma.nActivo = 1))  " &
                            " AND (vwSteCaja.nCerrada = 0) "
                End If


            Else

                Strsql = "SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja,1 As Orden " &
                         " FROM         dbo.StbPersona INNER JOIN " &
                         "  dbo.SteCaja ON dbo.StbPersona.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID " &
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

            If Me.cboCaja.ListCount > 0 Then
                Strsql = " SELECT dbo.SttProcesarEnvioES.nSteCajaid, dbo.SteCaja.sDescripcionCaja,    dbo.SttProcesarEnvioES.NoEnvio,   " & _
                         " dbo.SttProcesarEnvioES.EstadoEnvio, " & _
                         "CASE WHEN NoEnvio = 0 AND EstadoEnvio = 0 THEN 'Carga Inicial Generada' WHEN NoEnvio = 0 AND " & _
                         " EstadoEnvio = 1 THEN 'Carga Inicial Enviada' WHEN NoEnvio = 0 AND EstadoEnvio = 2 THEN 'Carga Inicial Recepcionada' WHEN NoEnvio <> 0 AND " & _
                         " EstadoEnvio = 0 THEN 'Generada' WHEN NoEnvio <> 0 AND EstadoEnvio = 1 THEN ' Enviada' WHEN NoEnvio <> 0 AND " & _
                         " EstadoEnvio = 2 THEN 'Recepcionada En Central' END AS DesEstadoEnvio," & _
                         "  dbo.SttProcesarEnvioES.FechaGenera, dbo.SsgCuenta.Login ,dbo.SttProcesarEnvioES.AplicadoEnCentral, Case When AplicadoEnCentral =1 Then 'SI' Else 'NO' End as DesAplicadoEnCentral" & _
                         " FROM dbo.SttProcesarEnvioES INNER JOIN " & _
                         " dbo.SteCaja ON dbo.SttProcesarEnvioES.nSteCajaId = dbo.SteCaja.nSteCajaID INNER JOIN " & _
                         " dbo.SsgCuenta ON dbo.SttProcesarEnvioES.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID " & _
                         " Where dbo.SttProcesarEnvioES.nSteCajaId =  " & Me.cboCaja.Columns("nSteCajaId").Value & _
                         " Order By NoEnvio Desc  "
            Else
                Strsql = " SELECT dbo.SttProcesarEnvioES.nSteCajaid, dbo.SteCaja.sDescripcionCaja,    dbo.SttProcesarEnvioES.NoEnvio,   " & _
                         " dbo.SttProcesarEnvioES.EstadoEnvio, " & _
                         "CASE WHEN NoEnvio = 0 AND EstadoEnvio = 0 THEN 'Carga Inicial Generada' WHEN NoEnvio = 0 AND " & _
                         " EstadoEnvio = 1 THEN 'Carga Inicial Enviada' WHEN NoEnvio = 0 AND EstadoEnvio = 2 THEN 'Carga Inicial Recepcionada' WHEN NoEnvio <> 0 AND " & _
                         " EstadoEnvio = 0 THEN 'Generada' WHEN NoEnvio <> 0 AND EstadoEnvio = 1 THEN ' Enviada' WHEN NoEnvio <> 0 AND " & _
                         " EstadoEnvio = 2 THEN 'Recepcionada En Central' END AS DesEstadoEnvio," & _
                         "  dbo.SttProcesarEnvioES.FechaGenera, dbo.SsgCuenta.Login,dbo.SttProcesarEnvioES.AplicadoEnCentral, Case When AplicadoEnCentral =1 Then 'SI' Else 'NO' End as DesAplicadoEnCentral " & _
                         " FROM dbo.SttProcesarEnvioES INNER JOIN " & _
                         " dbo.SteCaja ON dbo.SttProcesarEnvioES.nSteCajaId = dbo.SteCaja.nSteCajaID INNER JOIN " & _
                         " dbo.SsgCuenta ON dbo.SttProcesarEnvioES.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID " & _
                         " Where dbo.SttProcesarEnvioES.nSteCajaId =  -1" & _
                         " Order By NoEnvio Desc  "

            End If

            If XdsGenera.ExistTable("Lote") Then
                XdsGenera("Lote").ExecuteSql(Strsql)
            Else
                XdsGenera.NewTable(Strsql, "Lote")
                XdsGenera("Lote").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.gridGenerados.DataSource = XdsGenera("Lote").Source


            'Actualizando el caption de los GRIDS
            Me.gridGenerados.Caption = " Listado de Cargas de Base de Datos Ejecutadas(" + Me.gridGenerados.RowCount.ToString + " registros)"
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
            RegPar = 0
            XGeneradosTotal = 0
            XGeneradosTotal = XcomUpdate.ExecuteScalar(" Select count(*)As Total From  SttProcesarEnvioES Where EstadoEnvio<>2 And NoEnvio<>0")
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
                XEstadoEnvio = lectorDatos("EstadoEnvio") 'Es el estado de envio
                XCarpetaTempoUSBCopia = lectorDatos("CarpetaTempoUSBCopia")
                XBaseTemporal = lectorDatos("BaseTemporal")
                XCarpetaTxtFisica = lectorDatos("CarpetaTxtFisica")
                XCarpetaTxtLogica = lectorDatos("CarpetaTxtLogica")
                XCarpetaRespaldoCarga = IIf(IsDBNull(lectorDatos("CarpetaRespaldoCarga")), "", lectorDatos("CarpetaRespaldoCarga"))
                RegPar = RegPar + 1
            End While
            lectorDatos.Close()
            'If XCajaId = -1 Then
            '   PanPrincipal.Enabled = False
            'End If
            If RegPar > 1 Then
                MsgBox("Debe existir solo un registro en la tabla SttProcesarParametroES.", MsgBoxStyle.Information)
                grpGenera.Enabled = False
            End If

            If XEstadoEnvio <> 0 And XCajaId <> 0 And XCajaId <> -1 Then ' No aplica para central 
                'MsgBox("El Ultimo  lote generado o no ha sido guardado o no ha sido indicado como recepcionado en Central ", MsgBoxStyle.Information)
                'cmbProcesar.Enabled = False
                'Else
                'cmbProcesar.Enabled = True
            Else
                Dim ComandoCargaIni As New SqlCommand("Select * From  SttProcesarEnvioES Where NoEnvio=0 And nSteCajaId=" & XCajaId, conexion)
                lectorDatos.Close()
                lectorDatos = ComandoB.ExecuteReader
                If XCajaId <> 0 And XCajaId = -1 And lectorDatos.HasRows = False Then
                    MsgBox("Esta sera la carga inicial de informacion enviada por la Central. Asegurese que es la información correcta ", MsgBoxStyle.Information)
                End If
            End If




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
            Me.gridGenerados.Splits(0).DisplayColumns("nSteCajaid").Visible = False
            Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").Visible = False
            Me.gridGenerados.Splits(0).DisplayColumns("AplicadoEnCentral").Visible = False



            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").Width = 80
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").Width = 120
            Me.gridGenerados.Splits(0).DisplayColumns("Login").Width = 200            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").Width = 80
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").Width = 240

            Me.gridGenerados.Splits(0).DisplayColumns("DesAplicadoEnCentral").Width = 80

            'Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").Width = 160

            ''Me.grdCierre.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.gridGenerados.Columns("NoEnvio").Caption = "No"
            Me.gridGenerados.Columns("FechaGenera").Caption = "Generado el "
            Me.gridGenerados.Columns("Login").Caption = "Login"
            'Me.gridGenerados.Columns("FechaEnvio").Caption = "Guardado"
            Me.gridGenerados.Columns("DesEstadoEnvio").Caption = "Estado"
            'Me.gridGenerados.Columns("sDescripcionCaja").Caption = "Caja"
            Me.gridGenerados.Columns("DesAplicadoEnCentral").Caption = "Aplicado en Central"

            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("Login").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesAplicadoEnCentral").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            Me.gridGenerados.Splits(0).DisplayColumns("NoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("FechaGenera").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("FechaEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesEstadoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.gridGenerados.Splits(0).DisplayColumns("DesAplicadoEnCentral").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.gridGenerados.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarArchivo()
        Dim XDirInicial As String
        Dim XSubCarpetaFuente As String = ""





        Dim XNumEnvio, XEstadoEnvioUltimo As Integer

        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
        'Dim myConnectionStringTemporal As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & XBaseTemporal & ";Data Source=" & Conex.ServerName
        'Dim myConnectionStringTemporalOLEDB As String = "Provider=SQLOLEDB;User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & XBaseTemporal & ";Data Source=" & Conex.ServerName

        'Dim XcUsuario As New BOSistema.Win.XComando
        'Dim XComando As New BOSistema.Win.XComando



        Dim myXMLfile As String = ""
        'Dim myXMLfile As String = "c:\mySchema.xml"

        'Dim myFileStream As System.IO.FileStream
        '           (myXMLfile, System.IO.FileMode.Open)
        'Dim MyXmlTextWriter As New System.Xml.XmlTextWriter _
        '   (myFileStream, System.Text.Encoding.Unicode)


        ' Crea el comando

        conexion.ConnectionString = myConnectionString
        'Dim comando As New SqlCommand(mySelectQuery, conexion)


        ' Crea el DataReader
        Dim lectorDatos As SqlDataReader

        ' Conecta con la Base de Datos
        conexion.Open()



        'Dim con As New SqlConnection(myConnectionString)
        'Dim conBaseTemporal As New SqlConnection(myConnectionStringTemporal)
        'Dim daCust As New SqlDataAdapter("", "")
        'Dim daTabla As New SqlDataAdapter("", "")
        'Dim daTablaDestino As New SqlDataAdapter("", "")
        'Dim XTiempoInicial, XTiempoFinal As Date
        'Dim XMinutosDescargaZip, XMinutosBorradoBdTemporal, XMinutosCargaBdTemporal As Integer

        'Dim IdUsuario As Integer
        'Dim CargarXML As Integer = 0
        'Dim CargarTXT As Integer = 0
        'Dim XError As String = ""









        '        Dim mySelectQuery As String _
        '                      = "Select * From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoImportar=1   " & IIf(XCajaId = 0, " And nProcesarCentralImportar= 1 ", "")
        '       Dim mySelectQueryCount As String _
        '                 = "Select Count(*) AS TotalT From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoImportar=1   " & IIf(XCajaId = 0, " And nProcesarCentralImportar= 1 ", "")
        '    Dim comando As New SqlCommand(mySelectQuery, conexion)






        XNumEnvio = -1
        XEstadoEnvioUltimo = -1
        Dim XOperActualizarOAgregar As Integer
        Dim CadNEnvioM As String
        '' Se supone que si no existe un solo proceso de recepcion envio. entonces listcount = 0 
        If cboCaja.ListCount > 0 Then
            CadNEnvioM = "Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = " & Me.cboCaja.Columns("nSteCajaId").Value & "    Order by  NoEnvio desc   "
        Else
            CadNEnvioM = "Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = -1 Order by  NoEnvio desc   "
        End If
        Dim ComandoBRegId As New SqlCommand(CadNEnvioM, conexion)
        'lectorDatos.Close()
        lectorDatos = ComandoBRegId.ExecuteReader
        XOperActualizarOAgregar = 1
        While lectorDatos.Read
            XNumEnvio = lectorDatos("NoEnvio")
            XEstadoEnvioUltimo = lectorDatos("EstadoEnvio")
        End While








        CargarUnidades()
        If Me.cboUnidad.Items.Count = 0 Then
            MsgBox("No existe unidad de USB instalada", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XCajaId = 0 Then
            XSubCarpetaFuente = "CargarEnCentral"
        Else
            XSubCarpetaFuente = "CargarEnLocal"
        End If
        If Me.cboUnidad.Items.Count > 0 Then

            'cboUnidad.Text = "C:\"

            If System.IO.Directory.Exists(cboUnidad.Text & XCarpetaTempoUSBCopia & "\" & XSubCarpetaFuente) Then
                XDirInicial = cboUnidad.Text & XCarpetaTempoUSBCopia & "\" & XSubCarpetaFuente
            Else
                If System.IO.Directory.Exists(cboUnidad.Text & XCarpetaTempoUSBCopia) Then
                    XDirInicial = cboUnidad.Text & XCarpetaTempoUSBCopia
                Else
                    XDirInicial = cboUnidad.Text
                End If
            End If
        Else
            XDirInicial = "C:\"
        End If
        Me.ArchivoLocacion.InitialDirectory = XDirInicial
        If XCajaId = 0 Then
            Me.ArchivoLocacion.FileName = XDirInicial & "\" & Me.cboCaja.Columns("sDescripcionCaja").Value & "_EnvioLocal(" & XNumEnvio + 1 & ").zip"
        Else
            If XCajaId <> -1 Then
                Me.ArchivoLocacion.FileName = XDirInicial & "\" & Me.cboCaja.Columns("sDescripcionCaja").Value & "_EnvioCentral(" & XNumEnvio & ").zip"
            Else
                Me.ArchivoLocacion.FileName = XDirInicial & "CargarArchivo.zip"
            End If

        End If

        Me.ArchivoLocacion.Filter = "zip files (*.zip)|*.ZIP"
        LblArchivoAbierto.Text = "Archivo Abierto Zip"
        Me.ArchivoLocacion.ShowDialog()
        TxtArchivoAbierto.Text = IIf(IsDBNull(Me.ArchivoLocacion.FileName), "", Me.ArchivoLocacion.FileName)

        'TxtArchivoAbierto.Text = ArchivoLocacion.FileName().Substring(ArchivoLocacion.FileName().LastIndexOf("\") + 1)

        'TxtArchivoAbierto.Text = ArchivoLocacion.FileName
    End Sub
    Private Function DescarcarArchivosZip() As Integer
        Dim success As Boolean
        Dim zip As New Chilkat.Zip()
        Dim unlocked As Boolean

        Dim XNombreArchivo, XNombreCarpeta As String
        Dim dsTablas, dsTablasDestino As New DataSet
        Dim DsDirectorioZip As New DataSet
        Dim Contador As Integer
        Dim oRead As System.IO.StreamWriter


        unlocked = zip.UnlockComponent("ZIP-TEAMBEAN_3988ED58913G")
        If (Not unlocked) Then
            MsgBox("Fallo al intentar abrir el componente de libreria Zip")
            Return 0
            Exit Function
        End If


        XNombreArchivo = ArchivoLocacion.FileName().Substring(ArchivoLocacion.FileName().LastIndexOf("\") + 1)
        XNombreCarpeta = ArchivoLocacion.FileName().Substring(1, Len(ArchivoLocacion.FileName) - (ArchivoLocacion.FileName().LastIndexOf("\") + 1))

        'If Trim(XCarpetaTxtLogica) = "" Then ' Se supone cuando es la primera vez a insertar
        '    XCarpetaTxtLogica = "\\Usura-cero\documentacion smusura0\Cargas"
        '    XCarpetaTxtFisica = "d:\documentacion smusura0\Cargas"

        'End If

        TxtArchivoAbierto.Text = ArchivoLocacion.FileName

        If XCajaId = 0 Then
            CarpetaAbrir = CarpetaGenera & "\" & XSubCarpeta ' My.Application.Info.DirectoryPath & "\TmpProcesoCarga\" & XSubCarpeta
        Else
            CarpetaAbrir = XCarpetaTxtLogica & "\" & XSubCarpeta
        End If


        If System.IO.Directory.Exists(CarpetaAbrir) Then
            System.IO.Directory.Delete(CarpetaAbrir, True)
        End If
        System.IO.Directory.CreateDirectory(CarpetaAbrir)



        If Not System.IO.File.Exists(TxtArchivoAbierto.Text) Then
            MsgBox("El archivo Zip. no se encuentra disponible. Vuelva a cargar el archivo")
            Return 0
            Exit Function
        End If



        System.IO.File.Copy(Me.ArchivoLocacion.FileName, CarpetaAbrir & "\" & XNombreArchivo)


        success = zip.OpenZip(CarpetaAbrir & "\" & XNombreArchivo)
        If (success <> True) Then
            MsgBox(zip.LastErrorText)
            Return 0
            Exit Function
        End If


        '  Set the password needed to unzip.
        '  This password must match the password used when the zip
        '  was created.
        zip.SetPassword("MCBDTRNS732985")


        Dim unzipCount As Long

        lBlProcesoZip.Text = "Desempaquetando archivo Zip"
        lBlProcesando.Text = ""
        Me.Refresh()
        oRead = New StreamWriter(CarpetaAbrir & "\ListadoArchivos.Xml", False, System.Text.Encoding.Unicode)
        oRead.Write(zip.GetDirectoryAsXML())
        oRead.Close()
        '  Returns the number of files and directories unzipped.
        DsDirectorioZip.ReadXml(CarpetaAbrir & "\ListadoArchivos.Xml")
        XMaxItem = DsDirectorioZip.Tables(0).Rows.Count * 2
        PrBarProceso.Minimum = 0
        PrBarProceso.Maximum = XMaxItem
        PrBarProceso.Value = 0
        For Contador = 0 To DsDirectorioZip.Tables(0).Rows.Count - 1
            PrBarProceso.Value = PrBarProceso.Value + 1
            lBlProcesando.Text = "Extrayendo archivo " & DsDirectorioZip.Tables(0).Rows(Contador).Item(0)
            Me.PrBarProceso.Refresh()
            Me.Refresh()

            unzipCount = zip.UnzipMatching(CarpetaAbrir, DsDirectorioZip.Tables(0).Rows(Contador).Item(0), False)
            Me.PrBarProceso.Refresh()
            Me.Refresh()
            If (unzipCount < 0) Then
                MsgBox("Error al abrir el archivo Zip" & Chr(13) & "No se pudo Desempaquetar el archivo " & DsDirectorioZip.Tables(0).Rows(Contador).Item(0))
                Return 0
            End If


        Next Contador

        Return 1


    End Function
    'Revisa si existen los archivos Txt en la carpeta donde se debio haber desempaquetado
    'y de acuerdo a la información de la tabla
    '''
    Private Function ExistenArchivosTxt() As Boolean
        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName
        conexion.ConnectionString = myConnectionString
        conexion.Open()
        Dim lectorDatos As SqlDataReader

        Dim mySelectQuery As String _
                                = "Select * From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoImportar=1   " & IIf(XCajaId = 0, " And nProcesarCentralImportar= 1 ", "")
        Dim mySelectQueryCount As String _
                    = "Select Count(*) AS TotalT From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoImportar=1   " & IIf(XCajaId = 0, " And nProcesarCentralImportar= 1 ", "")
        Dim comando As New SqlCommand(mySelectQuery, conexion)

        lectorDatos = comando.ExecuteReader
        While lectorDatos.Read
            If XCajaId <> 0 Then
                If Not System.IO.File.Exists(CarpetaAbrir & "\" & lectorDatos("sNombreTablaDestino") & ".txt") Then
                    MsgBox("No Existe el archivo " & lectorDatos("sNombreTablaDestino") & ".txt" & "  en los recibidos ", MsgBoxStyle.Critical, NombreSistema)
                    Return False
                End If
            Else
                If Not System.IO.File.Exists(CarpetaAbrir & "\" & lectorDatos("sNombreTablaDestino") & ".xml") Then
                    MsgBox("No Existe el archivo " & lectorDatos("sNombreTablaDestinoTmp") & ".xml" & "  en los recibidos ", MsgBoxStyle.Critical, NombreSistema)
                    Return False
                End If

            End If
        End While

        Return True
    End Function


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
            Dim rows() As DataRow = dataSet.Tables(0).Select(Nothing, Nothing, DataViewRowState.Added)
            'adapter.Fill(dataSet.Tables(0))
            builder.GetUpdateCommand()
            'i = adapter.Update(dataSet.Tables(0))

            i = adapter.Update(rows)

            Return i

        End Using
    End Function

    Public Function CreateCommandAndUpdate( _
        ByVal connectionString As String, _
        ByVal queryString As String, ByVal XmlFile As String) As DataSet

        Dim dataSet As DataSet = New DataSet






        'myFileStream = New System.IO.FileStream _
        '   (myXMLfile, System.IO.FileMode.Open)

        'dsTablas.ReadXml(myFileStream, XmlReadMode.ReadSchema)
        dataSet.ReadXml(XmlFile, XmlReadMode.ReadSchema)

        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Dim adapter As New OleDbDataAdapter()

            adapter.SelectCommand = New OleDbCommand( _
                queryString, connection)

            Dim builder As OleDbCommandBuilder = _
                New OleDbCommandBuilder(adapter)

            adapter.AcceptChangesDuringFill = True

            adapter.Fill(dataSet)

            ' Code to modify the data in the DataSet here.  

            ' Without the OleDbCommandBuilder this line would fail.
            builder.GetUpdateCommand()
            adapter.AcceptChangesDuringFill = True
            adapter.Update(dataSet)
        End Using
        Return dataSet
    End Function

    Private Sub btnReader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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




    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar Reiniciar Caja Contador:
            If Seg.HasPermission("ReiniciarContadorCajaDesconectada") Then
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




    Private Sub FrmCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)

            If Me.ColorVentana = "Verde" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Recepción de Información de Socias")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Recepción de Información de Recibos")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            Seguridad()
            InicializaVariables()
            grpPresentaProceso.Visible = False
            CargarParametros()
            EncuentraParametros()
            If XCajaId <> -1 Then
                CargarCaja(XCajaId)
            End If
            CargarUnidades()
            CargarGenerados()
            If XCajaId = 0 Then
                RadCentral.Checked = True
                'CmdReporteDuplicados.Visible = True
                'CmdReporteDuplicadosCentral.Visible = True
            Else
                RadLocal.Checked = True
                cboCaja.Enabled = False
                'CmdReporteDuplicados.Visible = False
                'CmdReporteDuplicadosCentral.Visible = False
            End If


            If XCajaId = 0 Then
                Me.Text = "Recepción de Información de Recibos"
            Else
                Me.Text = "Recepcion de Información de Socias"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Function CargaPathVarIniciales() As Boolean
        Dim XNombreMaquina As String = ""
        'Dim XUnidadLogica As String = "f:"
        Dim XUnidadLogica As String = "C:"
        Dim XCadMaq As String
        Dim XCarpetaDirRed As String
        'Localiza ID de Usuario:

        Dim Conex As New DSSistema.DSSistema

        Try



            ' Configuración del FolderBrowserDialog  
            With DirUnidadBDLocal

                .RootFolder = Environment.SpecialFolder.Desktop
                If My.Computer.Network.IsAvailable Then
                    .SelectedPath = "\\" + Conex.ServerName
                Else
                    .SelectedPath = "c:"
                End If
                .Description = "Seleccione la Carpeta donde se hara las Cargas y Descargas"
                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then
                    XCarpetaDirRed = .SelectedPath
                Else
                    XCarpetaDirRed = ""
                End If

                .Dispose()




            End With


            'OJO Cambios para no en RED  
            'Ver que se esté sobre una RED 
            ''If XCarpetaDirRed.Contains("\\") = False Then
            ''    MsgBox("No ha seleccionado una carpeta de la RED ", MsgBoxStyle.Critical, NombreSistema)
            ''    Return False
            ''End If
            XCadMaq = Mid(XCarpetaDirRed, XCarpetaDirRed.IndexOf("\\") + 3)
            XNombreMaquina = Mid(XCadMaq, 1, XCadMaq.IndexOf("\"))
            'If Not ExisteServidorSql(XNombreMaquina) Then
            '    MsgBox("No existe un servidor de Sql Server en esa máquina", MsgBoxStyle.Critical, NombreSistema)
            '    Return False
            'End If
            'If UCase(Conex.ServerName) <> UCase(XNombreMaquina) Then
            '    MsgBox("La Carpeta debe estar sobre el mismo servidor Sql Actual", MsgBoxStyle.Critical, NombreSistema)
            '    Return False
            'End If
            '------Ojo Temporal

            CarpetaGenera = "C:\ExportarCajas"
            XCarpetaTxtLogica = Me.DirUnidadBDLocal.SelectedPath & "\Cargas"  '"\\Svmg01itc004\documentacion smusura0\Cargas"

            XCarpetaTxtFisica = Replace(XCarpetaTxtLogica, "\\" & XNombreMaquina, XUnidadLogica)   '"f:\documentacion smusura0\Cargas"
            XCarpetaTempoUSBCopia = "TransferenciaBases"
            XCarpetaRespaldoCarga = Me.DirUnidadBDLocal.SelectedPath & "\RespaldoTxtLocales" '"\\Svmg01itc004\documentacion smusura0\RespaldoTxtLocales"
            'Me.Container.Remove(Me.DirUnidadBDLocal)

            Return True
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
        'XCarpetaTxtLogica = "\\Svmg01itc004\documentacion smusura0\Cargas"
        'XCarpetaTxtFisica = "f:\documentacion smusura0\Cargas"
        'XCarpetaTempoUSBCopia = "TransferenciaBases"
        'XCarpetaRespaldoCarga = "\\Svmg01itc004\documentacion smusura0\RespaldoTxtLocales"
    End Function
    Public Function ExisteServidorSql(ByVal XNombreServer As String) As Boolean
        Dim Dta As System.Data.DataTable
        Dim Contador As Integer

        Dta = New System.Data.DataTable
        Dta = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources
        Contador = 0

        While Contador < Dta.Rows.Count


            If UCase(Trim(Dta.Rows(Contador)(0))) = UCase(Trim(XNombreServer)) Then
                Return True
            End If
            Contador = Contador + 1
        End While
        Return False



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

    Private Sub CargarBase()
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
        Dim XTiempoInicial, XTiempoFinal, XTiempoIniciaProceso As Date
        Dim XMinutosDescargaZip, XMinutosBorradoBdTemporal, XMinutosCargaBdTemporal As Integer
        Dim XCarpetaRespaldoCargaDirLocal As String

        Dim IdUsuario As Integer
        Dim CargarXML As Integer = 0
        Dim CargarTXT As Integer = 0
        Dim XError As String = ""
        Dim XCajaCentralIndex As Integer

        ' NombreCaja = Me.cboCaja.Columns("sDescripcionCaja").Value
        Try
            If Trim(ArchivoLocacion.FileName) = "" Then
                MsgBox("Debe indicar Seleccionar el Archivo Zip para cargar en la Base de Datos ", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If
            cmdCancelar.Enabled = False
            XNombreArchivo = ArchivoLocacion.FileName().Substring(ArchivoLocacion.FileName().LastIndexOf("\") + 1)
            XNombreCarpeta = ArchivoLocacion.FileName().Substring(1, Len(ArchivoLocacion.FileName) - (ArchivoLocacion.FileName().LastIndexOf("\") + 1))
            TxtArchivoAbierto.Text = ArchivoLocacion.FileName



            If XCajaId <> 0 Then ' No es la central es local entonces cargara los txt
                CargarTXT = 1
            Else
                CargarXML = 1  ' Es la central entonces cargar los archivos XML. seguramente los recibos digitados
                XCajaCentralIndex = cboCaja.SelectedIndex
            End If

            XTiempoInicial = Now
            XTiempoIniciaProceso = Now
            IdUsuario = XcUsuario.ExecuteScalar("SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')")



            Dim mySelectQuery As String _
                            = "Select * From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoImportar=1   " & IIf(XCajaId = 0, " And nProcesarCentralImportar= 1 ", "")
            Dim mySelectQueryCount As String _
                        = "Select Count(*) AS TotalT From SttProcesarTablasES Where nProcesar= 1 And nTipoProcesoImportar=1   " & IIf(XCajaId = 0, " And nProcesarCentralImportar= 1 ", "")
            Dim comando As New SqlCommand(mySelectQuery, conexion)






            XNumEnvio = -1
            XEstadoEnvioUltimo = -1
            Dim XOperActualizarOAgregar As Integer
            Dim CadNEnvioM As String
            '' Se supone que si no existe un solo proceso de recepcion envio. entonces listcount = 0 
            If cboCaja.ListCount > 0 Then
                CadNEnvioM = "Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = " & Me.cboCaja.Columns("nSteCajaId").Value & "    Order by  NoEnvio desc   "
            Else
                CadNEnvioM = "Select Top 1 * From  SttProcesarEnvioES Where nSteCajaId = -1 Order by  NoEnvio desc   "
            End If
            Dim ComandoBRegId As New SqlCommand(CadNEnvioM, conexion)
            'lectorDatos.Close()
            lectorDatos = ComandoBRegId.ExecuteReader
            XOperActualizarOAgregar = 1
            While lectorDatos.Read
                XNumEnvio = lectorDatos("NoEnvio")
                XEstadoEnvioUltimo = lectorDatos("EstadoEnvio")
            End While
            If XEstadoEnvioUltimo = 2 And XCajaId <> 0 Then
                MsgBox("El envio " & XNumEnvio & " indica que ya fue recepcionado por central  ", MsgBoxStyle.Critical, NombreSistema)
                cmdCancelar.Enabled = True
                Exit Sub
            End If
            grpPresentaProceso.Visible = True
            grpPresentaProceso.BringToFront()
            XTiempoInicial = Now
            'lBlProcesoZip.Text = "PROCESANDO DESEMPAQUETAR ARCHIVO ZIP"
            'lBlProcesando.Text = " "
            'XSubCarpeta

            Me.ChkUnZip.Checked = False
            Me.ChkCopiarTmp.Checked = False
            Me.ChkCopiarFinal.Checked = False


            lBlProcesoZip.Text = "Desempaquetando archivo Zip"
            lBlProcesando.Text = ""

            lBlProcesoBaseTmp.Text = "Esperando archivos desempaquetados"
            lBlProcesoBaseFinal.Text = "Esperando Transferencia de la base Temporal"



            XSubCarpeta = "Importar_Caja_" & XCajaId & "_" & XNumEnvio
            'Es la carga cero
            If XCajaId = -1 Then
                If CargaPathVarIniciales() = False Then
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub ' Es para saber donde estan las carpetas para los procesos temporales de carga y transferencia  en la carga cero 0 
                End If

            End If

            If DescarcarArchivosZip() = 0 Then
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If

            Me.ChkUnZip.Checked = True
            lBlProcesoZip.Text = "Archivo Zip fue desempaquetado"
            lBlProcesando.Text = ""




            Me.Refresh()


            'Incluye la informacion del encabezado 
            If Not System.IO.File.Exists(CarpetaAbrir & "\SteCaja.Xml") Then
                MsgBox("No Existe el archivo SteCaja.Xml en los recibidos ", MsgBoxStyle.Critical, NombreSistema)
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If
            If Not System.IO.File.Exists(CarpetaAbrir & "\SttProcesarEnvioES.Xml") Then
                MsgBox("No Existe el archivo SttProcesarEnvioES.Xml en los recibidos ", MsgBoxStyle.Critical, NombreSistema)
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If
            If Not System.IO.File.Exists(CarpetaAbrir & "\SttProcesarParametroES.Xml") Then
                MsgBox("No Existe el archivo SttProcesarParametroES.Xml en los recibidos ", MsgBoxStyle.Critical, NombreSistema)
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If




            dsTablaCaja.ReadXml(CarpetaAbrir & "\SteCaja.Xml")
            If XCajaId <> 0 And XCajaId <> -1 Then ' -1 Indica que es la primera vez a insertar 
                If dsTablaCaja.Tables(0).Rows(0).Item("nSteCajaId") <> XCajaId Then
                    MsgBox("Archivo SteCaja.Xml indica un numero de caja diferente : " & dsTablaCaja.Tables(0).Rows(0).Item("nSteCajaId") & "(" & dsTablaCaja.Tables(0).Rows(0).Item("SDescripcionCaja") & ")", MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
            End If
            dsTablaParametros.ReadXml(CarpetaAbrir & "\SttProcesarParametroES.Xml")
            If XCajaId <> 0 Then
                If dsTablaParametros.Tables(0).Rows(0).Item("nSteCajaId") <> 0 Then
                    MsgBox("Archivo SttProcesarParametroES.Xml No indica que sea enviado por la Central ", MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
            End If



            dsTablaEnvio.ReadXml(CarpetaAbrir & "\SttProcesarEnvioES.Xml")
            If XCajaId = -1 Then ' Es la primera vez carga inicial en los locales
                If MsgBox("Archivo SttProcesarEnvioES.Xml indica la Siguiente Información " & Chr(13) & " Caja :" & dsTablaCaja.Tables(0).Rows(0).Item("nSteCajaId") & "(" & dsTablaCaja.Tables(0).Rows(0).Item("SDescripcionCaja") & ")" & Chr(13) & "Esta seguro de cargar esta información", MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If

                XCajaId = dsTablaCaja.Tables(0).Rows(0).Item("nSteCajaId")
                NombreCaja = dsTablaCaja.Tables(0).Rows(0).Item("SDescripcionCaja")
                XNumEnvio = 0

                If XNumEnvio = 0 And dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") > 0 Then
                    MsgBox("Archivo SttProcesarEnvioES.Xml indica que no  es el numero de envio de apertura de caja " & Chr(13) & " Probablemente este archivo esta fuera del cronologico", MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    XCajaId = -1
                    Exit Sub
                End If

                'If CargaPathVarIniciales() = False Then
                '    grpPresentaProceso.Visible = False
                '    Exit Sub ' Es para saber donde estan las carpetas para los procesos temporales de carga y transferencia  
                'End If


                'XCarpetaTxtLogica = "\\Usura-cero\documentacion smusura0\Cargas"
                'XCarpetaTxtFisica = "f:\documentacion smusura0\Cargas"
                'CarpetaGenera = "C:\ExportarCajas"
                'XCarpetaTempoUSBCopia = "TransferenciaBases"
                'XCarpetaRespaldoCarga = "\\Usura-cero\documentacion smusura0\RespaldoTxtLocales"
            Else
                If XCajaId <> 0 Then
                    If XNumEnvio = 0 And dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") = 0 Then
                        MsgBox("Archivo SttProcesarEnvioES.Xml indica que es el numero de envio de apertura de caja " & Chr(13) & "Sin embargo esta ya se encuentra cargada en la base local" & Chr(13) & " Probablemente este archivo esta fuera del cronologico", MsgBoxStyle.Critical, NombreSistema)
                        grpPresentaProceso.Visible = False
                        cmdCancelar.Enabled = True
                        Exit Sub
                    End If
                    If XNumEnvio > dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") And XNumEnvio > 0 Then
                        MsgBox("Archivo SttProcesarEnvioES.Xml indica que es el numero de envio " & dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") & Chr(13) & "Sin embargo el ultimo envio hecho en la base local es el " & XNumEnvio & " Probablemente este archivo esta fuera del cronologico", MsgBoxStyle.Critical, NombreSistema)
                        grpPresentaProceso.Visible = False
                        cmdCancelar.Enabled = True
                        Exit Sub
                    End If

                ElseIf XCajaId = 0 Then
                    If dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") <= XNumEnvio Then
                        MsgBox("Archivo SttProcesarEnvioES.Xml indica un numero de envio  (" & dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") & ")" & Chr(13) & "Sin embargo se espera al menos un envio numero (" & XNumEnvio + 1 & ")" & Chr(13) & " Probablemente este archivo esta fuera del cronologico", MsgBoxStyle.Critical, NombreSistema)
                        grpPresentaProceso.Visible = False
                        cmdCancelar.Enabled = True
                        Exit Sub
                    End If

                    If dsTablaCaja.Tables(0).Rows(0).Item("nSteCajaId") <> Me.cboCaja.Columns("nSteCajaid").Value Then
                        MsgBox("Archivo SteCaja.Xml indica una Caja Diferente a la seleccionada en  el combo", MsgBoxStyle.Critical, NombreSistema)
                        grpPresentaProceso.Visible = False
                        cmdCancelar.Enabled = True
                        Exit Sub
                    End If


                End If
            End If



            If ExistenArchivosTxt() = False Then
                grpPresentaProceso.Visible = False
                cmdCancelar.Enabled = True
                Exit Sub
            End If



            XTiempoFinal = Now

            XMinutosDescargaZip = DateDiff(DateInterval.Second, XTiempoFinal, XTiempoInicial)




            'XNombreArchivo = ArchivoLocacion.FileName().Substring(ArchivoLocacion.FileName().LastIndexOf("\") + 1)
            'XNombreCarpeta = ArchivoLocacion.FileName().Substring(1, Len(ArchivoLocacion.FileName) - (ArchivoLocacion.FileName().LastIndexOf("\") + 1))


            'TxtArchivoAbierto.Text = ArchivoLocacion.FileName








            lectorDatos.Close()
            lectorDatos = comando.ExecuteReader

            XTotalTablas = XcUsuario.ExecuteScalar(mySelectQueryCount)

            '        Dim comandoTablasBorrarTmp As New SqlCommand(mySelectQuery & " Order By nOrdenImportar Desc ", conexion)
            Dim comandoTablasCopiarTmp As New SqlCommand(mySelectQuery & " Order By nOrdenImportar Asc ", conexion)


            '      lectorDatos.Close()
            '     lectorDatos = comandoTablasBorrarTmp.ExecuteReader
            conBaseTemporal.Open()

            XTiempoInicial = Now

            'PrBarProceso.Visible = True
            'PrBarProceso.Maximum = 2 * (XTotalTablas + 2)
            'PrBarProceso.Minimum = 0

            'lBlProcesoZip.Text = "PROCESANDO ELIMINAR DE BASE TEMPORAL " & XBaseTemporal
            'lBlProcesando.Text = "BORRANDO TABLAS "
            lBlProcesoBaseTmp.Text = "Procesando transferencia a base temporal (Borrando registros)"
            lBlProcesoBaseFinal.Text = "Esperando Transferencia de la base Temporal"
            Me.Refresh()

            'Dim Xcomando As New SqlCommand("EXEC spSttBorrarBaseTemporal", conexion)
            'XError = ".."
            ''Dim reader As SqlDataReader = Xcomando.ExecuteReader()
            'Xcomando.ExecuteReader()
            'XError = reader(0)
            'XError = XComando.ExecuteScalar("EXEC spSttBorrarBaseTemporal")

            If CargarTXT = 1 Then
                XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttBorrarBaseTemporalLocal")
                If Trim(XError) <> "" Then
                    MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
            End If

            If CargarXML = 1 Then
                XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttBorrarBaseTemporalCentral " & Me.cboCaja.Columns("nSteCajaid").Value)
                If Trim(XError) <> "" Then
                    MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
            End If


            'Dim ComBorrar As New SqlCommand("EXEC spSttBorrarBaseTemporal", conexion)
            'ComBorrar.ExecuteNonQuery()

            Me.Refresh()

            'If CargarXML = 1 Then
            '    While lectorDatos.Read ' Primero Borar las tablas de la base temporal
            '        'lBlProcesoZip.Text = "PROCESANDO ELIMINAR DE BASE TEMPORAL " & XBaseTemporal
            '        'lBlProcesando.Text = "BORRANDO TABLA " & lectorDatos("sNombreTablaDestinoTmp")
            '        Dim ComBorrar As New SqlCommand("DELETE FROM " & lectorDatos("sNombreTablaDestinoTmp"), conBaseTemporal)
            '        ComBorrar.ExecuteNonQuery()
            '        'Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas
            '        'Me.LblArchivo.Text = ""
            '        PrBarProceso.Value = Contador
            '        PrBarProceso.Refresh()
            '        Contador = Contador + 1
            '        Me.Refresh()
            '    End While
            'End If
            XTiempoFinal = Now
            PrBarProceso.Value = (XMaxItem / 2) + ((XMaxItem / 2) * 1) / 3
            PrBarProceso.Refresh()
            XMinutosBorradoBdTemporal = DateDiff(DateInterval.Second, XTiempoFinal, XTiempoInicial)
            lBlProcesoBaseTmp.Text = "Procesando transferencia a base temporal (Copiando registros de los archivos recibidos)"
            lBlProcesoBaseFinal.Text = "Esperando Transferencia de la base Temporal"

            Me.Refresh()


            lectorDatos.Close()




            lectorDatos = comandoTablasCopiarTmp.ExecuteReader

            Contador = 0
            XTiempoInicial = Now
            If CargarXML = 1 Then ' Esto es la carga de los recibos

                While lectorDatos.Read  ' And Contador < 1
                    'lBlProcesoZip.Text = "PROCESANDO COPIAR EN BASE TEMPORAL " & XBaseTemporal
                    'lBlProcesando.Text = "COPIANDO EN  TABLA " & lectorDatos("sNombreTablaDestino")

                    myXMLfile = CarpetaAbrir & "\" & lectorDatos("sNombreTablaOrigen") & ".Xml"
                    'If Me.cboCaja.Columns("nSteCajaId").Value = 0 Then
                    '    daCust = New SqlDataAdapter(lectorDatos("sQueryTodos"), con)
                    'Else
                    '    daCust = New SqlDataAdapter(lectorDatos("sQueryFiltrado"), con)
                    'End If
                    dsTablasDestino = New DataSet()
                    daTablaDestino = New SqlDataAdapter(lectorDatos("sQueryTodosTmp"), conBaseTemporal)
                    'daTablaDestino = New SqlDataAdapter(lectorDatos("sQueryTodos"), conBaseTemporal)
                    dsTablas = New DataSet()





                    'myFileStream = New System.IO.FileStream _
                    '   (myXMLfile, System.IO.FileMode.Open)

                    'dsTablas.ReadXml(myFileStream, XmlReadMode.ReadSchema)
                    dsTablas.ReadXml(myXMLfile, XmlReadMode.ReadSchema)






                    'daTablaDestino.Fill(dsTablas, lectorDatos("sNombreTablaDestino"))




                    'CreateCmdsAndUpdate(dsTablas, myConnectionStringTemporalOLEDB, lectorDatos("sQueryTodos"), lectorDatos("sNombreTablaDestino"))





                    CreateCmdsAndUpdate(dsTablas, myConnectionStringTemporalOLEDB, lectorDatos("sQueryTodosTmp"), lectorDatos("sNombreTablaDestino"))
                    'CreateCommandAndUpdate(myConnectionStringTemporalOLEDB, lectorDatos("sQueryTodosTmp"), myXMLfile)


                    'Me.LblConteo.Text = "Archivo Xml " & Contador & " de un total de   " & XTotalTablas + 1
                    'Me.LblArchivo.Text = "Archivo Guardando : " & myXMLfile
                    'PrBarProceso.Value = Contador + XTotalTablas + 2
                    'PrBarProceso.Refresh()
                    Contador = Contador + 1
                    Me.Refresh()

                End While
            End If

            'System.Environment.MachineName


            If CargarTXT = 1 Then  ' Cargar para las bases locales 
                'lBlProcesoZip.Text = "PROCESANDO COPIAR EN BASE TEMPORAL " & XBaseTemporal
                'lBlProcesando.Text = "COPIANDO TABLAS "
                'Dim ComCopy As New SqlCommand("EXEC spSttCopiarBaseTemporal", conexion)
                'ComCopy.ExecuteNonQuery()
                XError = ""

                'Dim Xcomando2 As New SqlCommand("EXEC spSttCopiarBaseTemporal '" & Trim(XCarpetaTxtFisica) & "\" & XSubCarpeta & "'", conexion)
                'XError = XComando.ExecuteScalar("EXEC spSttCopiarBaseTemporal '" & Trim(XCarpetaTxtFisica) & "\" & XSubCarpeta & "'")
                'XError = Xcomando2.ExecuteScalar
                XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttCopiarBaseTemporal '" & Trim(XCarpetaTxtFisica) & "\" & XSubCarpeta & "'")
                If Trim(XError) <> "" Then
                    MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If
            End If
            PrBarProceso.Value = (XMaxItem / 2) + ((XMaxItem / 2) * 2) / 3

            lBlProcesoBaseTmp.Text = "Transferencia a base temporal Completada "
            lBlProcesoBaseFinal.Text = "Ejecutando Transferencia de la base Temporal a la Final"
            ChkCopiarTmp.Checked = True
            ChkCopiarTmp.Refresh()
            PrBarProceso.Refresh()
            Me.Refresh()



            If CargarTXT = 1 Then
                Me.Refresh()
                'Dim Xcomando3 As New SqlCommand("EXEC spSttActualizacionBasesLocales " & XCajaId & "," & XNumEnvio & "," & IdUsuario & ",'" & Trim(CarpetaGenera) & "','" & Trim(XCarpetaTempoUSBCopia) & "','" & Trim(XCarpetaTxtFisica) & "','" & Trim(XCarpetaTxtLogica) & "'", conexion)
                'XError = XComando.ExecuteScalar("EXEC spSttActualizacionBasesLocales " & XCajaId & "," & XNumEnvio & "," & IdUsuario & ",'" & Trim(CarpetaGenera) & "','" & Trim(XCarpetaTempoUSBCopia) & "','" & Trim(XCarpetaTxtFisica) & "','" & Trim(XCarpetaTxtLogica) & "'")
                'XError = Xcomando3.ExecuteScalar
                'XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttActualizacionBasesLocales " & XCajaId & "," & XNumEnvio & "," & IdUsuario & ",'" & Trim(CarpetaGenera) & "','" & Trim(XCarpetaTempoUSBCopia) & "','" & Trim(XCarpetaTxtFisica) & "','" & Trim(XCarpetaTxtLogica) & "'")
                'If Trim(XError) <> "" And Not IsNumeric(XError) Then
                '    MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                '    grpPresentaProceso.Visible = False
                '    cmdCancelar.Enabled = True
                '    Exit Sub
                'End If
                'Me.Refresh()
            End If
            If CargarXML = 1 Then ' Central
                'Dim XtotalRecibos As Long
                'XtotalRecibos = XComando.ExecuteScalar("Select Count(*) AS TotalRecibos From vwSttExpSccReciboOficialCajaRepetidosRevisar ")
                'Dim Xcomando4 As New SqlCommand("EXEC spSttActualizacionBasesLocalesRecibos  " & Me.cboCaja.Columns("nSteCajaId").Value & "," & dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") & "," & IdUsuario, conexion)
                'XError = Xcomando4.ExecuteScalar
                'XError = XComando.ExecuteScalar("EXEC spSttActualizacionBasesLocalesRecibos  " & Me.cboCaja.Columns("nSteCajaId").Value & "," & dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") & "," & IdUsuario)
                XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttActualizacionBasesLocalesRecibos  " & Me.cboCaja.Columns("nSteCajaId").Value & "," & dsTablaEnvio.Tables(0).Rows(0).Item("NoEnvio") & "," & IdUsuario)
                If Trim(XError) <> "" And Not IsNumeric(XError) Then
                    MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                    grpPresentaProceso.Visible = False
                    cmdCancelar.Enabled = True
                    Exit Sub
                End If

            End If

            PrBarProceso.Value = XMaxItem
            'lBlProcesoBaseFinal.Text = "Transferencia de la base Temporal a la Final ha sido ejecutada con exito"
            ChkCopiarFinal.Checked = True
            ChkCopiarFinal.Refresh()
            PrBarProceso.Refresh()
            Me.Refresh()
            XTiempoFinal = Now
            XMinutosCargaBdTemporal = DateDiff(DateInterval.Second, XTiempoFinal, XTiempoInicial)
            CargarParametros()
            If XCajaId <> -1 Then
                CargarCaja(XCajaId)
            End If
            CargarUnidades()
            CargarGenerados()

            If System.IO.Directory.Exists(CarpetaAbrir) Then
                System.IO.Directory.Delete(CarpetaAbrir, True)
            End If

            'If XCajaId <> 0 Then
            '   System.IO.File.Delete(ArchivoLocacion.FileName)
            'Else
            If XCajaId = 0 Then
                XCarpetaRespaldoCargaDirLocal = XCarpetaRespaldoCarga & "\" & NombreCaja

                'XCarpetaRespaldoCarga = "\\Usura-cero\documentacion smusura0\RespaldoTxtLocales"
                If Not System.IO.Directory.Exists(XCarpetaRespaldoCargaDirLocal) Then
                    System.IO.Directory.CreateDirectory(XCarpetaRespaldoCargaDirLocal)
                End If
                System.IO.File.Copy(ArchivoLocacion.FileName, XCarpetaRespaldoCargaDirLocal & "\" & XNombreArchivo, True)
                cboCaja.SelectedIndex = XCajaCentralIndex
            End If
            System.IO.File.Delete(ArchivoLocacion.FileName)
            'End If

            MsgBox("Transferencia realizada  en " & DateDiff(DateInterval.Second, XTiempoIniciaProceso, Now) & " Segundos ", MsgBoxStyle.Information, NombreSistema)
            grpPresentaProceso.Visible = False
            cmdCancelar.Enabled = True

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


    Private Sub CmbRefrescarUnidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbRefrescarUnidar.Click
        CargarUnidades()
    End Sub


    Private Sub CmbCargarArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCargarArchivo.Click
        CargarArchivo()
    End Sub


    Private Sub CmbCargarBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCargarBase.Click
        CargarBase()
    End Sub


    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CmdReporteDuplicados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReporteDuplicados.Click
        Dim frmVisor As New frmCRVisorReporte

        frmVisor.NombreReporte = "RepStt1.rpt"
        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
        frmVisor.Formulas("NombreCaja") = "' Caja: " & cboCaja.Columns("sDescripcionCaja").Value & "'"
        frmVisor.ShowDialog()
    End Sub

    Private Sub CmdReporteDuplicadosCentral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReporteDuplicadosCentral.Click
        Dim frmVisor As New frmCRVisorReporte

        frmVisor.NombreReporte = "RepStt2.rpt"
        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
        frmVisor.Formulas("NombreCaja") = "' Caja: " & cboCaja.Columns("sDescripcionCaja").Value & "'"
        frmVisor.Parametros("@nSteCajaID") = cboCaja.Columns("nSteCajaID").Value
        frmVisor.ShowDialog()
    End Sub

    Private Sub GrpBPrincipal_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrpBPrincipal.Enter

    End Sub

    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        CargarGenerados()
    End Sub


    Private Sub DirUnidadBDLocal_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirUnidadBDLocal.HelpRequest

    End Sub

    Private Sub CmbAplicarCarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAplicarCarga.Click
        Dim ObjFrmSccCargaAplicar As New FrmSccCargaAplicar
        'Dim StrSql As String
        Try

            'Imposible si no existen envios:
            If Me.gridGenerados.RowCount = 0 Then
                MsgBox("No existen Envios registrados", MsgBoxStyle.Information)
                Exit Sub
            End If

            If XdsGenera("Lote").ValueField("NoEnvio") = 0 Then
                MsgBox("El Envío de carga inicial solo se utiliza para envío.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'If XdsGenera("Lote").ValueField("AplicadoEnCentral") = 1 Then
            '    MsgBox("Ya se encuentra aplicado en central. No se puede volver a aplicar.", MsgBoxStyle.Information)
            '    'Exit Sub
            'End If
            ObjFrmSccCargaAplicar.NoEnvio = XdsGenera("Lote").ValueField("NoEnvio")
            ObjFrmSccCargaAplicar.nSteCajaId = XdsGenera("Lote").ValueField("nSteCajaId")
            ObjFrmSccCargaAplicar.sNombreCaja = XdsGenera("Lote").ValueField("sDescripcionCaja")

            ObjFrmSccCargaAplicar.ShowDialog()
            CargarGenerados()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccCargaAplicar.Close()
            ObjFrmSccCargaAplicar = Nothing
        End Try
    End Sub

    Private Sub ReiniciarContador()
        'Dim XNumEnvio, XEstadoEnvioUltimo As Integer
        'Dim success As Boolean
        Dim zip As New Chilkat.Zip()
        'Dim unlocked As Boolean
        Dim NombreCaja As String = ""
        'Dim XNombreArchivo, XNombreCarpeta As String
        Dim dsTablas, dsTablasDestino As New DataSet
        Dim dsTablaEnvio, dsTablaCaja, dsTablaParametros As New DataSet
        Dim Conex As New DSSistema.DSSistema
        Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"
        Dim myConnectionStringTemporal As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & XBaseTemporal & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"
        Dim myConnectionStringTemporalOLEDB As String = "Provider=SQLOLEDB;User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & XBaseTemporal & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"

        Dim XcUsuario As New BOSistema.Win.XComando
        'Dim XComando As New BOSistema.Win.XComando



        'Dim XTotalTablas, Contador As Integer
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
        'Dim lectorDatos As SqlDataReader

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

            xTotalNoAplicadoCentral = XComando.ExecuteScalar(sqlcad)
            If xTotalNoAplicadoCentral > 0 Then
                MsgBox("Existe al menos una recepción de recibos en temporal no aplicado a la base definitiva ", MsgBoxStyle.Information)
                Exit Sub
            End If



            IdUsuario = XcUsuario.ExecuteScalar("SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')")


            If MsgBox(" Esta Seguro de Reiniciar el Contador para la Caja " & cboCaja.Text & Chr(13) & "Recuerde este procedimiento se implementa si eventualmente la maquina de la caja local tuvo fallo de hardware/software", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If










            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

           
            XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttReiniciarContador " & Me.cboCaja.Columns("nSteCajaid").Value & ",'" & Me.TxtMotivoReinicio.Text.Trim() & "'," & IdUsuario)
            If Trim(XError) <> "" Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If



            'Dim ComBorrar As New SqlCommand("EXEC spSttBorrarBaseTemporal", conexion)
            'ComBorrar.ExecuteNonQuery()

            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
           
           
            MsgBox("Se reinicio el Contador en Cero para la Caja  " & Me.cboCaja.Text, MsgBoxStyle.Information, NombreSistema)
     
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

            ReiniciarContador()


            grpGenera.Enabled = True
            gridGenerados.Enabled = True
            GrpReiniciar.Visible = False
            Seguridad()
        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub
End Class