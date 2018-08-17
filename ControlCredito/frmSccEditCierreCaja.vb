' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditCierreCaja.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Cierre.
'-------------------------------------------------------------------------
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.OleDb
Public Class frmSccEditCierreCaja

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSccCierreDiarioCaja As Integer
    Dim dFechaCierre As Date

    '-- Clases para procesar la informacion de los combos
    Dim XdsCierre As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjCierredt As BOSistema.Win.SccEntCartera.SccCierreDiarioCajaDataTable
    Dim ObjCierredr As BOSistema.Win.SccEntCartera.SccCierreDiarioCajaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean
    Dim sColor As String

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property
    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property FechaCierre() As Date
        Get
            FechaCierre = dFechaCierre
        End Get
        Set(ByVal value As Date)
            dFechaCierre = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdCierreDiarioCaja() As Integer
        Get
            IdCierreDiarioCaja = IdSccCierreDiarioCaja
        End Get
        Set(ByVal value As Integer)
            IdSccCierreDiarioCaja = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSccEditCierreCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditCierreCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjCierredt.Close()
                ObjCierredt = Nothing

                ObjCierredr.Close()
                ObjCierredr = Nothing

                XdsCierre.Close()
                XdsCierre = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSccEditCierreCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditDetalleCierre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarFuenteF(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarCierre()
                InhabilitarControles()
                Me.cdeFecha.Select()
            Else
                Me.cdeFecha.Value = Me.dFechaCierre
                Me.cboFuenteF.Select()
            End If

            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try

            'Me.grpLocalizacion.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Cierre Diario de Cartera"
            Else
                Me.Text = "Modificar Cierre Diario de Cartera"
            End If

            ObjCierredt = New BOSistema.Win.SccEntCartera.SccCierreDiarioCajaDataTable
            ObjCierredr = New BOSistema.Win.SccEntCartera.SccCierreDiarioCajaRow

            XdsCierre = New BOSistema.Win.XDataSet

            If ModoFrm = "ADD" Then
                ObjCierredr = ObjCierredt.NewRow
                'Inicializar los Length de los campos (Strings?)
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCierre()
        Try
            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjCierredt.Filter = "nSccCierreDiarioCajaID = " & Me.IdSccCierreDiarioCaja
            ObjCierredt.Retrieve()

            If ObjCierredt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjCierredr = ObjCierredt.Current 'Cierre actual.

            'Fecha de Recibo 
            If Not ObjCierredr.IsFieldNull("dFechaCierre") Then
                Me.cdeFecha.Value = ObjCierredr.dFechaCierre
            Else
                Me.cdeFecha.Value = Me.cdeFecha.ValueIsDbNull
            End If

            'Fuente Financiamiento
            If Not ObjCierredr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFuenteF(ObjCierredr.nScnFuenteFinanciamientoID)
                If Me.cboFuenteF.ListCount > 0 Then
                    Me.cboFuenteF.SelectedIndex = 0
                    XdsCierre("FuenteF").SetCurrentByID("nScnFuenteFinanciamientoID", ObjCierredr.nScnFuenteFinanciamientoID)
                End If
            Else
                Me.cboFuenteF.Text = ""
                Me.cboFuenteF.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCierre()

                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpCierre As New BOSistema.Win.SccEntCartera.SccCierreDiarioCajaDataTable
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim dFechaCierre As Date
            Dim strSQL As String = ""

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Fecha de Recibo
            If Me.cdeFecha.ValueIsDbNull Then
                MsgBox("La Fecha de Cierre NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFecha, "La Fecha de Cierre NO DEBE quedar vacía.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            dFechaCierre = Me.cdeFecha.Value

            'Fecha del Cierre no mayor que la Fecha del Servidor
            If dFechaCierre.Date > FechaServer.Date Then
                MsgBox("Fecha de Cierre (" & dFechaCierre.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Cierre (" & dFechaCierre.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento
            If Me.cboFuenteF.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Fuente de Financiamiento válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboFuenteF, "Debe seleccionar una Fuente de Financiamiento válida.")
                Me.cboFuenteF.Focus()
                Exit Function
            End If

            'Determinar duplicados en la Fecha del Cierre para una misma Fuente de Financiamiento
            If ModoFrm = "UPD" Then
                ObjTmpCierre.Filter = " nScnFuenteFinanciamientoID = " & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID") & " and dFechaCierre = '" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "' And nSccCierreDiarioCajaID <> " & Me.IdSccCierreDiarioCaja & " 	AND nStbEstadoCierreID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoCierreCartera')"

            Else
                ObjTmpCierre.Filter = " nScnFuenteFinanciamientoID = " & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID") & " And dFechaCierre = '" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "' AND nStbEstadoCierreID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoCierreCartera')"
            End If

            ObjTmpCierre.Retrieve()

            If ObjTmpCierre.Count > 0 Then
                MsgBox("La Fecha de Cierre NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFecha, "La Fecha de Cierre NO DEBE repetirse. ")
                Me.cdeFecha.SelectAll()
                Me.cdeFecha.Focus()
                Exit Function
            End If

            If ModoFrm = "ADD" Then
                strSQL = " SELECT a.nSccTablaAmortizacionPagosID " & _
                         " FROM SccTablaAmortizacionPagos a INNER JOIN SccReciboOficialCaja b " & _
                      " ON a.nSccReciboOficialCajaID = b.nSccReciboOficialCajaID " & _
                      " INNER JOIN SccSolicitudCheque c " & _
                      " ON b.nSccSolicitudChequeID = c.nSccSolicitudChequeID " & _
                      " WHERE b.dFechaRecibo = '" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "'" & _
                      " AND b.nStbEstadoReciboID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1') And b.sNombre = 'EstadoReciboOficialCaja')" & _
                      " AND c.nScnFuenteFinanciamientoID = " & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID")

                XdtDatos.ExecuteSql(strSQL)

                If XdtDatos.Count <= 0 Then
                    MsgBox("No existen Recibos para la Fuente Seleccionada en la Fecha ingresada.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errRecibo.SetError(Me.cdeFecha, "No existen Recibos para la Fuente Seleccionada en la Fecha ingresada.")
                    Me.cdeFecha.Focus()
                    Exit Function
                End If
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(dFechaCierre) = False Then
                MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFecha, "El Mes Contable se encuentra Cerrado.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjTmpCierre.Close()
            ObjTmpCierre = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCierre()
        Dim XcDatos As New BOSistema.Win.XComando
        'Dim XNum As Integer
        Try
            Dim strSQL As String
            Dim dFechaCierre As Date

            Dim Conex As New DSSistema.DSSistema
            Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"



            'Actualiza usuario y fecha de creación:
            'If ModoForm = "ADD" Then
            '    ObjCierredr.nUsuarioCreacionID = InfoSistema.IDCuenta
            '    ObjCierredr.dFechaCreacion = FechaServer()
            'Else
            '    ObjCierredr.nUsuarioModificacionID = InfoSistema.IDCuenta
            '    ObjCierredr.dFechaModificacion = FechaServer()
            'End If

            dFechaCierre = Me.cdeFecha.Value

            strSQL = " EXEC spSccGrabarCierreDiario " & Me.IdSccCierreDiarioCaja & "," & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID") & ",'" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "','" & Me.ModoFrm & "'," & InfoSistema.IDCuenta

            'Asignar el Id de la Socia a la variable publica del formulario
            'Me.IdSccCierreDiarioCaja = XcDatos.ExecuteScalar(strSQL)


            Me.IdSccCierreDiarioCaja = EjecutarComandoPasar(myConnectionString, strSQL)

            '--------------------------------

            '-- Buscar la ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjCierredt.Filter = "nSccCierreDiarioCajaID = " & Me.IdSccCierreDiarioCaja
            ObjCierredt.Retrieve()
            If ObjCierredt.Count = 0 Then
                Exit Sub
            End If
            ObjCierredr = ObjCierredt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdSccCierreDiarioCaja = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    Call GuardarAuditoria(2, 23, "Modificación de Cierre Diario de Cartera ID: " & IdSccCierreDiarioCaja & ".")
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarCierre()
                            AccionUsuario = AccionBoton.BotonAceptar
                            Me.Close()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case vbNo
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.Close()

                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarRepresentante
    ' Descripción:          Este procedimiento permite cargar el listado de Empleados
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarFuenteF(ByVal intFuenteFID As Integer)
        Try
            Dim Strsql As String

            Me.cboFuenteF.ClearFields()
            If intFuenteFID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID,a.sCodigo,a.sNombre " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " WHERE a.nActiva = 1 " & _
                         " Order by a.sCodigo "
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID,a.sCodigo,a.sNombre " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " WHERE (a.nActiva = 1) " & _
                         " Or a.nScnFuenteFinanciamientoID = " & intFuenteFID & _
                         " Order by a.sCodigo "
            End If

            If XdsCierre.ExistTable("FuenteF") Then
                XdsCierre("FuenteF").ExecuteSql(Strsql)
            Else
                XdsCierre.NewTable(Strsql, "FuenteF")
                XdsCierre("FuenteF").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboFuenteF.DataSource = XdsCierre("FuenteF").Source
            Me.cboFuenteF.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboFuenteF.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            'Configurar el combo
            Me.cboFuenteF.Splits(0).DisplayColumns("sCodigo").Width = 60
            Me.cboFuenteF.Splits(0).DisplayColumns("sNombre").Width = 350

            Me.cboFuenteF.Columns("sCodigo").Caption = "Código"
            Me.cboFuenteF.Columns("sNombre").Caption = "Descripción"

            Me.cboFuenteF.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuenteF.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class