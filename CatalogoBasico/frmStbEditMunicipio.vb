' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbEditMunicipio.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Municipios.
'-------------------------------------------------------------------------
Public Class frmStbEditMunicipio

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdStbDepartamento As Integer
    Dim IdStbMunicipio As Integer

    '-- Crear un data table de tipo Xdataset
    Dim ObjMunicipiodt As BOSistema.Win.StbEntUbicacionGeografica.StbMunicipioDataTable
    Dim ObjMunicipiodr As BOSistema.Win.StbEntUbicacionGeografica.StbMunicipioRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de Municipio.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Departamento que corresponde al campo
    'nStbDepartamentoID de la tabla StbDepartamento.
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = IdStbDepartamento
        End Get
        Set(ByVal value As Integer)
            IdStbDepartamento = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Municipio que corresponde al campo
    'nStbMunicipioID de la tabla StbMunicipio.
    Public Property IdMunicipio() As Integer
        Get
            IdMunicipio = IdStbMunicipio
        End Get
        Set(ByVal value As Integer)
            IdStbMunicipio = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmStbEditMunicipio_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditMunicipio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjMunicipiodt.Close()
                ObjMunicipiodt = Nothing

                ObjMunicipiodr.Close()
                ObjMunicipiodr = Nothing
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
    ' Procedure Name:       frmStbEditMunicipio_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Departamento en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditMunicipio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición
            'cargar los datos del Municipio.
            If ModoFrm = "UPD" Then
                CargarMunicipio()
                Me.txtCodigo.Enabled = False

                If Me.chkActivo.Checked = False Then
                    Me.chkActivo.Select()
                Else
                    Me.txtNombre.Select()
                End If
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
        Dim ObjDepartamentoDT As New BOSistema.Win.StbEntUbicacionGeografica.StbDepartamentoDataTable
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Municipio"
                Me.chkActivo.Checked = True
                Me.chkIncluidoPrograma.Checked = True
                Me.chkActivo.Enabled = False
            Else
                Me.Text = "Modificar Municipio"
                Me.chkActivo.Enabled = True
            End If

            ObjDepartamentoDT.Filter = "nStbDepartamentoID = " & Me.IdDepartamento
            ObjDepartamentoDT.Retrieve()

            Me.txtDepartamento.Text = ObjDepartamentoDT.ValueField("sCodigo") & " " & ObjDepartamentoDT.ValueField("sNombre")

            ObjMunicipiodt = New BOSistema.Win.StbEntUbicacionGeografica.StbMunicipioDataTable
            ObjMunicipiodr = New BOSistema.Win.StbEntUbicacionGeografica.StbMunicipioRow

            If ModoFrm = "ADD" Then
                ObjMunicipiodr = ObjMunicipiodt.NewRow
                'Inicializar los Length de los campos
                Me.txtCodigo.MaxLength = ObjMunicipiodr.GetColumnLenght("sCodigo")
                Me.txtNombre.MaxLength = ObjMunicipiodr.GetColumnLenght("sNombre")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjDepartamentoDT.Close()
            ObjDepartamentoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar los datos del Municipio
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio()
        Try
            '-- Buscar el Municipio corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjMunicipiodt.Filter = "nStbMunicipioID = " & Me.IdMunicipio
            ObjMunicipiodt.Retrieve()
            If ObjMunicipiodt.Count = 0 Then
                Exit Sub
            End If
            ObjMunicipiodr = ObjMunicipiodt.Current

            'Codigo 
            If Not ObjMunicipiodr.IsFieldNull("sCodigo") Then
                Me.txtCodigo.Text = ObjMunicipiodr.sCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Nombre
            If Not ObjMunicipiodr.IsFieldNull("sNombre") Then
                Me.txtNombre.Text = ObjMunicipiodr.sNombre
            Else
                Me.txtNombre.Text = ""
            End If

            'Pertenece Programa
            If Not ObjMunicipiodr.IsFieldNull("nPertenecePrograma") Then
                Me.chkIncluidoPrograma.Checked = ObjMunicipiodr.nPertenecePrograma
            End If

            'Activo
            If Not ObjMunicipiodr.IsFieldNull("nActivo") Then
                Me.chkActivo.Checked = ObjMunicipiodr.nActivo
                If Me.chkActivo.Checked = False Then
                    Me.txtCodigo.Enabled = False
                    Me.txtNombre.Enabled = False
                    Me.chkIncluidoPrograma.Enabled = False
                End If
            End If

            'Pago en Efectivo:
            If Not ObjMunicipiodr.IsFieldNull("nPagoEfectivo") Then
                Me.chkEfectivo.Checked = ObjMunicipiodr.nPagoEfectivo
            End If

            'Inicializar los Length de los campos
            Me.txtCodigo.MaxLength = ObjMunicipiodr.GetColumnLenght("sCodigo")
            Me.txtNombre.MaxLength = ObjMunicipiodr.GetColumnLenght("sNombre")

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
                SalvarMunicipio()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
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
        Dim ObjTmpMunicipio As New BOSistema.Win.StbEntUbicacionGeografica.StbMunicipioDataTable
        Dim ObjBarrioDT As New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioDataTable
        Try
            Dim sCodigoMunic As String

            ValidaDatosEntrada = True
            Me.errMunicipio.Clear()

            'Codigo
            If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
                MsgBox("El Codigo del Municipio NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMunicipio.SetError(Me.txtCodigo, "El Codigo del Municipio NO DEBE quedar vacío.")
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Determinar duplicados en el codigo del Municipio
            sCodigoMunic = Format(CInt(Me.txtCodigo.Text), "00")
            If ModoFrm = "UPD" Then
                ObjTmpMunicipio.Filter = " sCodigo = '" & sCodigoMunic & "' And nStbDepartamentoID = " & Me.IdDepartamento & " And nStbMunicipioID <> " & Me.IdMunicipio
            Else
                ObjTmpMunicipio.Filter = " sCodigo = '" & sCodigoMunic & "' And nStbDepartamentoID = " & Me.IdDepartamento
            End If

            ObjTmpMunicipio.Retrieve()
            If ObjTmpMunicipio.Count > 0 Then
                MsgBox("El Codigo del Municipio NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMunicipio.SetError(Me.txtCodigo, "El Codigo del Municipio NO DEBE repetirse.")
                Me.txtCodigo.SelectAll()
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Determinar duplicados en el nombre del Municipio
            If ModoFrm = "UPD" Then
                ObjTmpMunicipio.Filter = " Upper(sNombre) = '" & UCase(Me.txtNombre.Text) & "'" & " And nStbMunicipioID <> " & Me.IdMunicipio
            Else
                ObjTmpMunicipio.Filter = " Upper(sNombre) = '" & UCase(Me.txtNombre.Text) & "'"
            End If
            ObjTmpMunicipio.Retrieve()
            If ObjTmpMunicipio.Count > 0 Then
                MsgBox("El Nombre del Municipio NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMunicipio.SetError(Me.txtNombre, "El Nombre del Municipio NO DEBE repetirse.")
                Me.txtNombre.SelectAll()
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Nombre
            If Trim(RTrim(Me.txtNombre.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre del Municipio NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMunicipio.SetError(Me.txtNombre, "El Nombre del Municipio NO DEBE quedar vacía.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Inactivar un Municipio
            If Me.chkActivo.Checked = False Then
                ObjBarrioDT.Filter = "nStbMunicipioID = " & Me.IdMunicipio & " And nActivo = 1"
                ObjBarrioDT.Retrieve()
                If ObjMunicipiodt.Count > 0 Then
                    MsgBox("El registro no se puede Inactivar porque tiene Barrios asociados.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errMunicipio.SetError(Me.chkActivo, "El registro no se puede Inactivar porque tiene Barrios asociados.")
                    Me.chkActivo.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpMunicipio.Close()
            ObjTmpMunicipio = Nothing

            ObjBarrioDT.Close()
            ObjBarrioDT = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                14/09/2007
    ' Procedure Name:       SalvarMunicipio
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Municipio en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarMunicipio()
        Try
            If ModoFrm = "ADD" Then
                ObjMunicipiodr.sUsuarioCreacion = InfoSistema.LoginName
                ObjMunicipiodr.dFechaCreacion = FechaServer()
            Else
                ObjMunicipiodr.sUsuarioModificacion = InfoSistema.LoginName
                ObjMunicipiodr.dFechaModificacion = FechaServer()
            End If

            ObjMunicipiodr.nStbDepartamentoID = Me.IdDepartamento

            ObjMunicipiodr.sCodigo = Format(CInt(Me.txtCodigo.Text), "00")
            ObjMunicipiodr.sNombre = Me.txtNombre.Text

            If Me.chkActivo.Checked = True Then
                ObjMunicipiodr.nActivo = 1
            Else
                ObjMunicipiodr.nActivo = 0
            End If

            If Me.chkIncluidoPrograma.Checked = True Then
                ObjMunicipiodr.nPertenecePrograma = 1
            Else
                ObjMunicipiodr.nPertenecePrograma = 0
            End If

            If Me.chkEfectivo.Checked = True Then
                ObjMunicipiodr.nPagoEfectivo = 1
            Else
                ObjMunicipiodr.nPagoEfectivo = 0
            End If

            ObjMunicipiodr.Update()

            'Asignar el Id del Municipio a la 
            'variable publica del formulario
            IdMunicipio = ObjMunicipiodr.nStbMunicipioID
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
                            SalvarMunicipio()
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
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress, txtCodigo.KeyPress
        Try
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Código del Municipio
    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged, txtCodigo.TextChanged
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
            Me.chkActivo.BackColor = Me.grpMunicipio.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkIncluidoPrograma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub chkIncluidoPrograma_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.GotFocus
        Try
            Me.chkIncluidoPrograma.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkIncluidoPrograma_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.LostFocus
        Try
            Me.chkIncluidoPrograma.BackColor = Me.grpMunicipio.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEfectivo.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub chkEfectivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEfectivo.GotFocus
        Try
            Me.chkEfectivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkEfectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEfectivo.LostFocus
        Try
            Me.chkEfectivo.BackColor = Me.grpMunicipio.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class