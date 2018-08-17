' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                28/07/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditCargo.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Cargos.
'-------------------------------------------------------------------------
Public Class frmStbEditCargo

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdScnCargo As Long

    '-- Crear un data table de tipo Xdataset
    Dim ObjCargodt As BOSistema.Win.SrhEntEmpleado.SrhCargoDataTable
    Dim ObjCargodr As BOSistema.Win.SrhEntEmpleado.SrhCargoRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de Doc. Soporte.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Doc. Soporte que corresponde al campo
    'ScnDocSoporteID de la tabla ScnDocSoporte.
    Public Property IdCargo() As Long
        Get
            IdCargo = IdScnCargo
        End Get
        Set(ByVal value As Long)
            IdScnCargo = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmScnEditCargo_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCargo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjCargodt.Close()
                ObjCargodt = Nothing

                ObjCargodr.Close()
                ObjCargodr = Nothing
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmScnEditCargo_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Doc. Soporte en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición
            'cargar los datos del Doc. Soporte.
            If ModoFrm = "UPD" Then
                Me.txtCodigo.Enabled = False
                CargarCargo()
            End If

            If Me.chkActivo.Checked = False Then
                Me.chkActivo.Select()
            Else
                If ModoFrm = "ADD" Then
                    Me.txtCodigo.Select()
                Else
                    Me.txtDescripcion.Select()
                End If
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Cargo"
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
            Else
                Me.Text = "Modificar Cargo"
                Me.chkActivo.Enabled = True
            End If

            ObjCargodt = New BOSistema.Win.SrhEntEmpleado.SrhCargoDataTable
            ObjCargodr = New BOSistema.Win.SrhEntEmpleado.SrhCargoRow

            If ModoFrm = "ADD" Then

                ObjCargodr = ObjCargodt.NewRow

                'Inicializar los Length de los campos
                Me.txtCodigo.MaxLength = ObjCargodr.GetColumnLenght("sCodigo")
                Me.txtDescripcion.MaxLength = ObjCargodr.GetColumnLenght("sNombreCargo")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarCargo
    ' Descripción:          Este procedimiento permite cargar los datos del Doc. Soporte
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCargo()
        Try
            '-- Buscar el Doc. Soporte corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjCargodt.Filter = "nSrhCargoID = " & IdCargo
            ObjCargodt.Retrieve()
            If ObjCargodt.Count = 0 Then
                Exit Sub
            End If
            ObjCargodr = ObjCargodt.Current

            'Codigo 
            If Not ObjCargodr.IsFieldNull("sCodigo") Then
                Me.txtCodigo.Text = ObjCargodr.sCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Descripcion
            If Not ObjCargodr.IsFieldNull("sNombreCargo") Then
                Me.txtDescripcion.Text = ObjCargodr.sNombreCargo
            Else
                Me.txtDescripcion.Text = ""
            End If

            If Not ObjCargodr.IsFieldNull("nActivo") Then
                Me.chkActivo.Checked = ObjCargodr.nActivo
                If Me.chkActivo.Checked = False Then
                    Me.txtCodigo.Enabled = False
                    Me.txtDescripcion.Enabled = False
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtCodigo.MaxLength = ObjCargodr.GetColumnLenght("sCodigo")
            Me.txtDescripcion.MaxLength = ObjCargodr.GetColumnLenght("sNombreCargo")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCargo()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpCargo As New BOSistema.Win.SrhEntEmpleado.SrhCargoDataTable
        Try
            Dim sCodigoCargo As String

            ValidaDatosEntrada = True
            Me.errDocSoporte.Clear()

            'Código
            If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
                MsgBox("Código del Cargo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtCodigo, "Código del Cargo NO DEBE quedar vacío.")
                Me.txtCodigo.Focus()
                Exit Function
            End If

            sCodigoCargo = Format(CInt(Me.txtCodigo.Text), "00")

            'Determinar duplicados en las Siglas del Doc. Soporte
            If ModoFrm = "UPD" Then
                ObjTmpCargo.Filter = " sCodigo = '" & sCodigoCargo & "'" & " And nSrhCargoID <> " & IdCargo            '& " And Activo = 1"
            Else
                ObjTmpCargo.Filter = " sCodigo = '" & sCodigoCargo & "'"                       '& " And Activo = 1"
            End If

            ObjTmpCargo.Retrieve()

            If ObjTmpCargo.Count > 0 Then
                MsgBox("El Código del Cargo NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtCodigo, "El Código del Cargo NO DEBE repetirse. ")
                Me.txtCodigo.SelectAll()
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Descripción
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox("Nombre del Cargo NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtDescripcion, "Nombre del Cargo NO DEBE quedar vacía.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'Descripción
            'Determinar duplicados en la Descripción
            If ModoFrm = "UPD" Then
                ObjTmpCargo.Filter = " Upper(sNombreCargo) = '" & UCase(Me.txtDescripcion.Text) & "'" & " And nSrhCargoID <> " & IdCargo            '& " And Activo = 1"
            Else
                ObjTmpCargo.Filter = " Upper(sNombreCargo) = '" & UCase(Me.txtDescripcion.Text) & "'"                       '& " And Activo = 1"
            End If

            ObjTmpCargo.Retrieve()

            If ObjTmpCargo.Count > 0 Then
                MsgBox("La Descripción del Cargo NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtDescripcion, "La Descripción del Cargo NO DEBE repetirse. ")
                Me.txtDescripcion.SelectAll()
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            ''Inactivar un Cargo
            'If Me.chkActivo.Checked = False Then
            '    ObjCargoOrdinal.Filter = "objCargoID = " & Me.IdScnCargo & " And Activo = 1"
            '    ObjCargoOrdinal.Retrieve()
            '    If ObjCargoOrdinal.Count > 0 Then
            '        MsgBox("El registro no se puede Inactivar porque tiene Ordinales asociados.", MsgBoxStyle.Information)
            '        ValidaDatosEntrada = False
            '        Me.errDocSoporte.SetError(Me.chkActivo, "El registro no se puede Inactivar porque tiene Ordinales asociados.")
            '        Me.chkActivo.Focus()
            '        Exit Function
            '    End If
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpCargo.Close()
            ObjTmpCargo = Nothing

            'ObjCargoOrdinal.Close()
            'ObjCargoOrdinal = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       SalvarCargo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Cargo en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCargo()
        Try

            If ModoFrm = "ADD" Then
                ObjCargodr.sUsuarioCreacion = InfoSistema.LoginName
                ObjCargodr.dFechaCreacion = FechaServer()
            Else
                ObjCargodr.sUsuarioModificacion = InfoSistema.LoginName
                ObjCargodr.dFechaModificacion = FechaServer()
            End If

            ObjCargodr.sCodigo = Format(CInt(Me.txtCodigo.Text), "00")

            ObjCargodr.sNombreCargo = Me.txtDescripcion.Text

            If Me.chkActivo.Checked = True Then
                ObjCargodr.nActivo = 1
            Else
                ObjCargodr.nActivo = 0
            End If

            ObjCargodr.Update()

            'Asignar el Id del Doc. Soporte a la 
            'variable publica del formulario
            IdScnCargo = ObjCargodr.nSrhCargoID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
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
                            SalvarCargo()
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
    'Solo se permite Número 0 - 9, BackSpace 
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Código del Cargo
    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        vbModifico = True
    End Sub
    'Solo se permite Letras A - Z, número 0-9, BackSpace y la Barra espaciadora
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en la Descripción del Documento Soporte
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        vbModifico = True
    End Sub
    'Se indica que hubo modificación en al Estado de Activo
    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        vbModifico = True
    End Sub
    'Para controlar la ubicación del foco en el checkbox
    Private Sub chkActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.GotFocus
        Try
            Me.chkActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Para controlar cuando el checkbox pierde el foco
    Private Sub chkActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.LostFocus
        Try
            Me.chkActivo.BackColor = Me.grpBanco.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class