' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                14/11/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditCierreDiarioCaja.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Cierres Diarios de Caja.
'-------------------------------------------------------------------------
Public Class frmSteEditCierreDiarioCaja

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteCierre As Integer
    Dim IntStePermiteEditar As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsCaja As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjCierredt As BOSistema.Win.SteEntTesoreria.SteCierreDiarioCajaDataTable
    Dim ObjCierredr As BOSistema.Win.SteEntTesoreria.SteCierreDiarioCajaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Recibo.
    Public Property IdCierre() As Integer
        Get
            IdCierre = IdSteCierre
        End Get
        Set(ByVal value As Integer)
            IdSteCierre = value
        End Set
    End Property

    'Propiedad utilizada para obtener si el Usuario puede adicionar cierres de otra delegacion.
    Public Property IntPermiteEditar() As Integer
        Get
            IntPermiteEditar = IntStePermiteEditar
        End Get
        Set(ByVal value As Integer)
            IntStePermiteEditar = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       frmSteEditCierreDiarioCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCierreDiarioCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjCierredt.Close()
                ObjCierredt = Nothing

                ObjCierredr.Close()
                ObjCierredr = Nothing

                XdsCaja.Close()
                XdsCaja = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       frmSteEditCierreDiarioCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCierreDiarioCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarCaja(0)

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoForm = "UPD" Then
                CargarCierreDiario()
            Else
                Me.cboCaja.Select()
            End If
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Cierre Diario de Caja"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Cierre Diario de Caja"
            End If

            ObjCierredt = New BOSistema.Win.SteEntTesoreria.SteCierreDiarioCajaDataTable
            ObjCierredr = New BOSistema.Win.SteEntTesoreria.SteCierreDiarioCajaRow
            XdsCaja = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboCaja.ClearFields()
            If ModoForm = "ADD" Then
                ObjCierredr = ObjCierredt.NewRow
                Me.txtObservaciones.MaxLength = ObjCierredr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       CargarCierreDiario
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Cierre Diario de Caja.
    '-------------------------------------------------------------------------
    Public Sub CargarCierreDiario()
        Try

            '-- Buscar el recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjCierredt.Filter = "nSteCierreDiarioCajaID = " & IdCierre
            ObjCierredt.Retrieve()
            If ObjCierredt.Count = 0 Then
                Exit Sub
            End If
            ObjCierredr = ObjCierredt.Current

            'Debe seleccionar una Caja: 
            If Not ObjCierredr.IsFieldNull("nSteCajaID") Then
                CargarCaja(ObjCierredr.nSteCajaID)
                If Me.cboCaja.ListCount > 0 Then
                    Me.cboCaja.SelectedIndex = 0
                End If
                XdsCaja("Caja").SetCurrentByID("nSteCajaID", ObjCierredr.nSteCajaID)
            Else
                Me.cboCaja.Text = ""
                Me.cboCaja.SelectedIndex = -1
            End If

            'Fecha de Cierre:
            If Not ObjCierredr.IsFieldNull("dFechaCierre") Then
                Me.cdeFechaCierre.Value = ObjCierredr.dFechaCierre
            Else
                Me.cdeFechaCierre.Value = FechaServer()
            End If

            'Observaciones:
            If Not ObjCierredr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjCierredr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjCierredr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCierreDiario()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errCierre.Clear()

            'Caja:
            If Me.cboCaja.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Caja válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                Me.cboCaja.Focus()
                Exit Function
            End If

            'Imposible si la Caja no es de su Delegación y no tiene permisos de edición:
            If Me.IntStePermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> cboCaja.Columns("nStbDelegacionProgramaID").Value Then
                    MsgBox("Imposible Cerrar Caja de otra Delegación.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errCierre.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                    Me.cboCaja.Focus()
                    Exit Function
                End If
            End If

            'Fecha de Cierre:
            If Me.cdeFechaCierre.ValueIsDbNull Then
                MsgBox("La Fecha del Cierre NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "La Fecha del Cierre NO DEBE quedar vacía.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Fecha Cierre no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Cierre NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "La Fecha del Cierre NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Fecha Cierre no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Cierre NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "La Fecha del Cierre NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Fecha del Cierre no mayor que la Fecha del Servidor:
            If Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") > FechaServer.Date Then
                MsgBox("Fecha de Cierre NO DEBE ser Mayor que la Fecha del día.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "Fecha de Cierre NO DEBE ser Mayor que la Fecha del día.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'No debe repetirse un Cierre para la misma Caja y Fecha:
            strSQL = " SELECT * From SteCierreDiarioCaja " & _
                     " WHERE (nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (dFechaCierre = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) AND (nSteCierreDiarioCajaID <> " & Me.IdSteCierre & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya existe un Cierre para la Caja y Fecha.", MsgBoxStyle.Critical, NombreSistema)
                Me.errCierre.SetError(Me.cboCaja, "Existe un Cierre para la Caja y Fecha.")
                Me.cboCaja.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si no existen Recibos Oficiales de Caja Automaticos ACTIVOS para la Caja y Fecha:
            strSQL = " SELECT SccReciboOficialCaja.nSccReciboOficialCajaID " & _
                     " FROM SccReciboOficialCaja INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE  (SccReciboOficialCaja.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (SccReciboOficialCaja.nManual = 0) AND (SccReciboOficialCaja.dFechaRecibo> = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) AND (SccReciboOficialCaja.dFechaRecibo< = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd hh:mm:ss") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existen Recibos Oficiales de Caja automáticos" & Chr(13) & "y ACTIVOS para la Caja y Fecha indicada.", MsgBoxStyle.Critical, NombreSistema)
                Me.errCierre.SetError(Me.cboCaja, "No existen Recibos Oficiales de Caja.")
                Me.cboCaja.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       SalvarCierreDiario
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCierreDiario()
        Try

            If ModoForm = "ADD" Then
                ObjCierredr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCierredr.dFechaCreacion = FechaServer()
            Else
                ObjCierredr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCierredr.dFechaModificacion = FechaServer()
            End If

            ObjCierredr.nCerrada = 1
            ObjCierredr.nSteCajaID = XdsCaja("Caja").ValueField("nSteCajaID")
            ObjCierredr.dFechaCierre = Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")

            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjCierredr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjCierredr.SetFieldNull("sObservaciones")
            End If

            ObjCierredr.Update()

            'Asignar Id a la variable
            'publica del formulario
            IdSteCierre = ObjCierredr.nSteCierreDiarioCajaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Cierre Diario de Caja ID: " & Me.IdSteCierre & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
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
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarCierreDiario()
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
                        Me.IdCierre = 0
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.IdCierre = 0
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2008
    ' Procedure Name:       CargarCaja
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajas en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCaja(ByVal intCajaID As Integer)
        Try
            Dim Strsql As String

            Me.cboCaja.ClearFields()
            If intCajaID = 0 Then
                Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.nStbDelegacionProgramaID, a.dFechaApertura, a.nCerrada " &
                         " From vwSteCaja a " &
                         " WHERE a.nCerrada = 0 " &
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.nStbDelegacionProgramaID, a.dFechaApertura, a.nCerrada  " & _
                         " From vwSteCaja a " & _
                         " WHERE (a.nCerrada = 0) " & _
                         " Or a.nSteCajaID = " & intCajaID & _
                         " Order by a.nCodigo "
            End If

            If XdsCaja.ExistTable("Caja") Then
                XdsCaja("Caja").ExecuteSql(Strsql)
            Else
                XdsCaja.NewTable(Strsql, "Caja")
                XdsCaja("Caja").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCaja.DataSource = XdsCaja("Caja").Source
            Me.cboCaja.Rebind()

            'Configurar el combo
            Me.cboCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nCerrada").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 250
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").Width = 90

            Me.cboCaja.Columns("nCodigo").Caption = "Código"
            Me.cboCaja.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.cboCaja.Columns("dFechaApertura").Caption = "Fecha Apertura"

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Columns("dFechaApertura").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboCaja_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCaja.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en la Caja
    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Ciere:
    Private Sub cdeFechaCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCierre.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en las Observaciones:
    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub
End Class