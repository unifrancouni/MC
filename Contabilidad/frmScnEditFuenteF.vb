Public Class frmScnEditFuenteF

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim vbModifico As Boolean

    '-- Declaro los objetos que contendra mi formulario
    Dim ObjFuenteFRdr As BOSistema.Win.ScnEntContabilidad.ScnFuenteFinanciamientoRow
    Dim ObjFuenteFRdt As BOSistema.Win.ScnEntContabilidad.ScnFuenteFinanciamientoDataTable

    'Contiene el ID del tipo de Fuente Financiamiento
    Dim IDFF As Integer

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum
    Public Property FuenteFinanID() As Integer
        Get
            Return IDFF
        End Get
        Set(ByVal value As Integer)
            IDFF = value
        End Set
    End Property

    Public AccionUsuario As AccionBoton
    '-------------------------------------------------
    'Parámetro del formulario Editando Aplicación
    'para determinar si está en modo Nuevo o Edicion.
    '-------------------------------------------------
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    Private Sub frmScnEditFuenteF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjFuenteFRdr.Close()
                ObjFuenteFRdr = Nothing
            Else
                e.Cancel = True
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmScnEditFuenteF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ObjGUI As GUI.ClsGUI

            'Seteo la apariencia del formulario
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Metodo que inicializa las variables del formulario
            InicializaVariables()

            'Coloco el len de los textbox
            SetearControles()

            'Seteo las variables de estado del formulario
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            'Coloco el foco en la caja de texto del codigo
            txtCodigo.Select()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                15/08/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializaVariables()
        Dim StrSql As String
        Try

            ObjFuenteFRdt = New BOSistema.Win.ScnEntContabilidad.ScnFuenteFinanciamientoDataTable
            ObjFuenteFRdr = New BOSistema.Win.ScnEntContabilidad.ScnFuenteFinanciamientoRow

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Fuente de Financiamiento"
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
                ObjFuenteFRdr = ObjFuenteFRdt.NewRow
            Else
                '------------------
                Me.Text = "Modificar Fuente de Financiamiento"
                ObjFuenteFRdt.Filter = "nScnFuenteFinanciamientoID = " & FuenteFinanID
                ObjFuenteFRdt.Retrieve()
                If ObjFuenteFRdt.Count > 0 Then
                    ObjFuenteFRdr = ObjFuenteFRdt.Current
                    Me.txtCodigo.Text = ObjFuenteFRdr.sCodigo
                    Me.txtNombre.Text = ObjFuenteFRdr.sNombre
                    Me.txtSiglas.Text = ObjFuenteFRdr.sSiglas

                    'Fuente Activa:
                    If ObjFuenteFRdr.nActiva = 1 Then
                        Me.chkActivo.Checked = True
                    Else
                        Me.chkActivo.Checked = False
                    End If
                    'Fondo Presupuestario:
                    If ObjFuenteFRdr.nFondoPresupuestario = 1 Then
                        Me.chkFondoPresupuestario.Checked = True
                    Else
                        Me.chkFondoPresupuestario.Checked = False
                    End If
                End If

                'Fuente Inactiva:
                If Me.chkActivo.Checked = False Then
                    Me.txtCodigo.Enabled = False
                    Me.txtNombre.Enabled = False
                    Me.chkFondoPresupuestario.Enabled = False
                    Me.chkActivo.Focus()
                Else
                    Me.txtCodigo.Focus()
                End If

                'Si la Fuente tiene Solicitudes de Desembolso activas asociadas imposible
                'modificar Fondo Presupuestario:
                StrSql = "SELECT SD.nSccSolicitudDesembolsoCreditoID " & _
                         "FROM SccSolicitudDesembolsoCredito AS SD INNER JOIN StbValorCatalogo AS C ON SD.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                         "WHERE  (C.sCodigoInterno <> '2') AND (SD.nScnFuenteFinanciamientoID = " & FuenteFinanID & ")"
                If RegistrosAsociados(StrSql) Then
                    Me.chkFondoPresupuestario.Enabled = False
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------------
    'Author		        :	
    'Date			    :   15/08/2006
    'Procedure name	    :   SetearControles
    'Description		:	Este metodo establece el tamaño de los controles de tipo caracter
    '-----------------------------------------------------------------------------------------
    Private Sub SetearControles()
        Try
            Me.txtCodigo.MaxLength = ObjFuenteFRdr.GetColumnLenght("sCodigo")
            Me.txtNombre.MaxLength = ObjFuenteFRdr.GetColumnLenght("sNombre")
            Me.txtSiglas.MaxLength = ObjFuenteFRdr.GetColumnLenght("sSiglas")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" Then
            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        vbModifico = True
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/08/2006
    ' Procedure name	:   SalvarFuentesF	
    ' Description		:	Este procedimiento permite salvar los datos en la base de datos  
    ' -----------------------------------------------------------------------------------------
    Private Sub SalvarFuentesF()
        Try
            '-------------------------------------------------
            'Asignando a la clase los valores que se 
            'requieren salvar en la Base de FF.

            ObjFuenteFRdr.sCodigo = Trim(txtCodigo.Text)
            ObjFuenteFRdr.sNombre = Trim(txtNombre.Text)
            ObjFuenteFRdr.sSiglas = Trim(txtSiglas.Text)

            If Me.chkActivo.Checked = True Then
                ObjFuenteFRdr.nActiva = 1
            Else
                ObjFuenteFRdr.nActiva = 0
            End If

            If Me.chkFondoPresupuestario.Checked = True Then
                ObjFuenteFRdr.nFondoPresupuestario = 1
            Else
                ObjFuenteFRdr.nFondoPresupuestario = 0
            End If

            If ModoFrm = "ADD" Then
                ObjFuenteFRdr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjFuenteFRdr.dFechaCreacion = FechaServer()
            Else
                ObjFuenteFRdr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjFuenteFRdr.dFechaModificacion = FechaServer()
            End If
            ObjFuenteFRdr.Update()

            IDFF = ObjFuenteFRdr.nScnFuenteFinanciamientoID

            AccionUsuario = AccionBoton.BotonAceptar

            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 24, "Modificación de Fuente de Fondos ID:" & Me.IDFF & ".")
            End If
            '---------------------
            AccionUsuario = AccionBoton.BotonAceptar

            Me.Close()
            '---------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	15/08/2006
    ' Procedure name	:	ValidaParametros
    ' Description		:	Esta funcion valida los datos requeridos para salvar  
    ' -----------------------------------------------------------------------------------------
    Private Function ValidaParametros() As Boolean

        Dim ObjFuenteFValid As New BOSistema.Win.ScnEntContabilidad.ScnFuenteFinanciamientoDataTable

        Try
            ValidaParametros = True
            Me.ErrorProvider1.Clear()

            '1 .- Validando Codigo:
            If Trim(Me.txtCodigo.Text).Length = 0 Then
                MsgBox("El código no puede ser vacío.", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtCodigo, "El código no puede ser vacío.")
                ValidaParametros = False
                Me.txtCodigo.Focus()
                Exit Function
            End If

            '2.- Validando Nombre:
            If Trim(Me.txtNombre.Text).Length = 0 Then
                MsgBox("El nombre no puede ser vacío.", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtNombre, "El nombre no puede ser vacío.")
                ValidaParametros = False
                Me.txtNombre.Focus()
                Exit Function
            End If

            '3. Validar que no se duplique el Nombre de la Fuente de Financiamiento:
            If ModoFrm = "UPD" Then
                ObjFuenteFValid.Filter = " Upper(LTrim(RTrim(sNombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "'" & " And nScnFuenteFinanciamientoID <> " & ObjFuenteFRdr.nScnFuenteFinanciamientoID
            Else
                ObjFuenteFValid.Filter = " Upper(LTrim(RTrim(sNombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "'"
            End If
            ObjFuenteFValid.Retrieve()
            If ObjFuenteFValid.Count > 0 Then
                MsgBox("El Nombre de la Fuente de Financiamiento NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtNombre, "El Nombre de la Fuente de Financiamiento NO DEBE repetirse. ")
                ValidaParametros = False
                Me.txtNombre.SelectAll()
                Me.txtNombre.Focus()
                Exit Function
            End If

            '4. Validar que no se duplique el Codigo:
            If ModoFrm = "UPD" Then
                ObjFuenteFValid.Filter = " Upper(LTrim(RTrim(sCodigo))) = '" & UCase(LTrim(RTrim(Me.txtCodigo.Text))) & "'" & " And nScnFuenteFinanciamientoID <> " & ObjFuenteFRdr.nScnFuenteFinanciamientoID
            Else
                ObjFuenteFValid.Filter = " Upper(LTrim(RTrim(sCodigo))) = '" & UCase(LTrim(RTrim(Me.txtCodigo.Text))) & "'"
            End If
            ObjFuenteFValid.Retrieve()
            If ObjFuenteFValid.Count > 0 Then
                MsgBox("El Código de la Fuente de Financiamiento NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtCodigo, "El Código de la Fuente de Financiamiento NO DEBE repetirse.")
                ValidaParametros = False
                Me.txtCodigo.SelectAll()
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Validando Siglas
            If Trim(Me.txtSiglas.Text).Length = 0 Then
                MsgBox("Las Siglas NO DEBEN ser vacío.", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtNombre, "Las Siglas NO DEBEN ser vacío.")
                ValidaParametros = False
                Me.txtSiglas.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaParametros = False
        Finally
            ObjFuenteFValid.Close()
            ObjFuenteFValid = Nothing
        End Try
    End Function
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            If vbModifico = True Then
                Select Case MsgBox("¿Desea salvar los cambios antes de salir? ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, NombreSistema)
                    Case MsgBoxResult.Yes
                        If ValidaParametros() Then
                            SalvarFuentesF()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case MsgBoxResult.No
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.Close()

                    Case MsgBoxResult.Cancel
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

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaParametros() Then
                SalvarFuentesF()

            End If
        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub chkActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.GotFocus
        Try
            Me.chkActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.LostFocus
        Try
            Me.chkActivo.BackColor = Me.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkFondoPresupuestario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFondoPresupuestario.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub chkFondoPresupuestario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFondoPresupuestario.GotFocus
        Try
            Me.chkFondoPresupuestario.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkFondoPresupuestario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFondoPresupuestario.LostFocus
        Try
            Me.chkFondoPresupuestario.BackColor = Me.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtSiglas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSiglas.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtSiglas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSiglas.TextChanged
        vbModifico = True
    End Sub
End Class
