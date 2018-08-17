' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbEditProfesion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Profesiones.
'-------------------------------------------------------------------------
Public Class frmStbEditProfesion

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdStbProfesion As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsProfesion As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjProfesiondt As BOSistema.Win.SrhEntEmpleado.StbProfesionDataTable
    Dim ObjProfesiondr As BOSistema.Win.SrhEntEmpleado.StbProfesionRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de Distrito.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Profesion que corresponde al campo
    'nStbProfesionID de la tabla StbProfesion.
    Public Property IdProfesion() As Integer
        Get
            IdProfesion = IdStbProfesion
        End Get
        Set(ByVal value As Integer)
            IdStbProfesion = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmStbEditProfesion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditProfesion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjProfesiondt.Close()
                ObjProfesiondt = Nothing

                ObjProfesiondr.Close()
                ObjProfesiondr = Nothing

                XdsProfesion.Close()
                XdsProfesion = Nothing
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
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmStbEditProfesion_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Departamento en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditProfesion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarTituloObtenido()

            'Si el formulario está en modo edición
            'cargar los datos del Distrito.
            If ModoFrm = "UPD" Then
                CargarProfesion()
            End If

            If Me.chkActivo.Checked = False Then
                Me.chkActivo.Select()
            Else
                Me.txtCodigo.Select()
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
    ' Fecha:                12/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Profesión"
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
            Else
                Me.Text = "Modificar Profesión"
                Me.chkActivo.Enabled = True
            End If

            ObjProfesiondt = New BOSistema.Win.SrhEntEmpleado.StbProfesionDataTable
            ObjProfesiondr = New BOSistema.Win.SrhEntEmpleado.StbProfesionRow
            XdsProfesion = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            If ModoFrm = "ADD" Then

                ObjProfesiondr = ObjProfesiondt.NewRow

                'Inicializar los Length de los campos
                Me.txtCodigo.MaxLength = ObjProfesiondr.GetColumnLenght("sCodigo")
                Me.txtNombre.MaxLength = ObjProfesiondr.GetColumnLenght("sNombreCarrera")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       CargarProfesion
    ' Descripción:          Este procedimiento permite cargar los datos del Distrito
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarProfesion()
        Try
            '-- Buscar el Distrito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjProfesiondt.Filter = "nStbProfesionID = " & Me.IdProfesion
            ObjProfesiondt.Retrieve()
            If ObjProfesiondt.Count = 0 Then
                Exit Sub
            End If
            ObjProfesiondr = ObjProfesiondt.Current

            'Codigo 
            If Not ObjProfesiondr.IsFieldNull("sCodigo") Then
                Me.txtCodigo.Text = ObjProfesiondr.sCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Nombre
            If Not ObjProfesiondr.IsFieldNull("sNombreCarrera") Then
                Me.txtNombre.Text = ObjProfesiondr.sNombreCarrera
            Else
                Me.txtNombre.Text = ""
            End If

            'Título Obtenido
            If Not ObjProfesiondr.IsFieldNull("nStbTituloObtenidoID") Then
                If Me.cboTituloObtenido.ListCount > 0 Then
                    Me.cboTituloObtenido.SelectedIndex = 0
                    XdsProfesion("TituloObtenido").SetCurrentByID("nStbValorCatalogoID", ObjProfesiondr.nStbTituloObtenidoID)
                End If
            Else
                Me.cboTituloObtenido.Text = ""
                Me.cboTituloObtenido.SelectedIndex = -1
            End If

            'Activo
            If Not ObjProfesiondr.IsFieldNull("nActivo") Then
                Me.chkActivo.Checked = ObjProfesiondr.nActivo
                If Me.chkActivo.Checked = False Then
                    Me.cboTituloObtenido.Enabled = False
                    Me.txtCodigo.Enabled = False
                    Me.txtNombre.Enabled = False
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtCodigo.MaxLength = ObjProfesiondr.GetColumnLenght("sCodigo")
            Me.txtNombre.MaxLength = ObjProfesiondr.GetColumnLenght("sNombreCarrera")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                14/09/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarProfesion()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTituloObtenido
    ' Descripción:          Este procedimiento permite cargar el listado de posibles
    '                       títulos obtenidos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTituloObtenido()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TituloObtenido') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsProfesion.ExistTable("TituloObtenido") Then
                XdsProfesion("TituloObtenido").ExecuteSql(Strsql)
            Else
                XdsProfesion.NewTable(Strsql, "TituloObtenido")
                XdsProfesion("TituloObtenido").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTituloObtenido.DataSource = XdsProfesion("TituloObtenido").Source

            Me.cboTituloObtenido.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTituloObtenido.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTituloObtenido.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTituloObtenido.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTituloObtenido.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTituloObtenido.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTituloObtenido.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTituloObtenido.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                14/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpProfesion As New BOSistema.Win.SrhEntEmpleado.StbProfesionDataTable
        Try
            Dim sCodigoProfesion As String

            ValidaDatosEntrada = True
            Me.errProfesion.Clear()

            'Código
            If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
                MsgBox("El Código de la Profesión NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errProfesion.SetError(Me.txtCodigo, "El Código de la Profesión NO DEBE quedar vacío.")
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Determinar duplicados en el codigo de la Profesión

            sCodigoProfesion = Format(CInt(Me.txtCodigo.Text), "00")

            If ModoFrm = "UPD" Then
                ObjTmpProfesion.Filter = " sCodigo = '" & sCodigoProfesion & "'" & " And nStbProfesionID <> " & Me.IdProfesion
            Else
                ObjTmpProfesion.Filter = " sCodigo = '" & sCodigoProfesion & "'"
            End If

            ObjTmpProfesion.Retrieve()

            If ObjTmpProfesion.Count > 0 Then
                MsgBox("El Codigo de la Profesión NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errProfesion.SetError(Me.txtCodigo, "El Codigo de la Profesión NO DEBE repetirse.")
                Me.txtCodigo.SelectAll()
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Nombre
            If Trim(RTrim(Me.txtNombre.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre de la Profesión NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errProfesion.SetError(Me.txtNombre, "El Nombre de la Profesión NO DEBE quedar vacía.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Determinar duplicados en el nombre de la Profesión
            If ModoFrm = "UPD" Then
                ObjTmpProfesion.Filter = " Upper(sNombreCarrera) = '" & UCase(Me.txtNombre.Text) & "'" & " And nStbProfesionID <> " & Me.IdProfesion
            Else
                ObjTmpProfesion.Filter = " Upper(sNombreCarrera) = '" & UCase(Me.txtNombre.Text) & "'"
            End If

            ObjTmpProfesion.Retrieve()

            If ObjTmpProfesion.Count > 0 Then
                MsgBox("El Nombre de la Profesión NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errProfesion.SetError(Me.txtNombre, "El Nombre de la Profesión NO DEBE repetirse.")
                Me.txtNombre.SelectAll()
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Título Obtenido
            If Me.cboTituloObtenido.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Título Obtenido válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errProfesion.SetError(Me.cboTituloObtenido, "Debe seleccionar un Título Obtenido válido.")
                Me.cboTituloObtenido.Focus()
                Exit Function
            End If

            'Inactivar una Profesión
            'If Me.chkActivo.Checked = False Then
            '    ObjBarrioDT.Filter = "nStbDistritoID = " & Me.IdDistrito & " And nActivo = 1"
            '    ObjBarrioDT.Retrieve()
            '    If ObjBarrioDT.Count > 0 Then
            '        MsgBox("El registro no se puede Inactivar porque tiene Barrios asociados.", MsgBoxStyle.Critical, "SMUSURA0")
            '        ValidaDatosEntrada = False
            '        Me.errProfesion.SetError(Me.chkActivo, "El registro no se puede Inactivar porque tiene Barrios asociados.")
            '        Me.chkActivo.Focus()
            '        Exit Function
            '    End If
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpProfesion.Close()
            ObjTmpProfesion = Nothing

            'ObjBarrioDT.Close()
            'ObjBarrioDT = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                14/09/2007
    ' Procedure Name:       SalvarProfesion
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Profesión en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarProfesion()
        Try
            If ModoFrm = "ADD" Then
                ObjProfesiondr.sUsuarioCreacion = InfoSistema.LoginName
                ObjProfesiondr.dFechaCreacion = FechaServer()
            Else
                ObjProfesiondr.sUsuarioModificacion = InfoSistema.LoginName
                ObjProfesiondr.dFechaModificacion = FechaServer()
            End If

            ObjProfesiondr.sCodigo = Format(CInt(Me.txtCodigo.Text), "00")
            ObjProfesiondr.sNombreCarrera = Me.txtNombre.Text
            ObjProfesiondr.nStbTituloObtenidoID = XdsProfesion("TituloObtenido").ValueField("nStbValorCatalogoID")

            If Me.chkActivo.Checked = True Then
                ObjProfesiondr.nActivo = 1
            Else
                ObjProfesiondr.nActivo = 0
            End If

            ObjProfesiondr.Update()

            'Asignar el Id de la Profesión a la 
            'variable publica del formulario
            IdProfesion = ObjProfesiondr.nStbProfesionID
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
    ' Fecha:                14/09/2007
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
                            SalvarProfesion()
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
    'Solo se permite Numeros 0 - 9, BackSpace 
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Código del Documento Soporte
    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        vbModifico = True
    End Sub
    'Solo se permite Letras A - Z, número 0-9, BackSpace y la Barra espaciadora
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en la Descripción del Documento Soporte
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
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
            Me.chkActivo.BackColor = Me.grpDepartamento.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboTituloObtenido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTituloObtenido.TextChanged
        vbModifico = True
    End Sub
End Class