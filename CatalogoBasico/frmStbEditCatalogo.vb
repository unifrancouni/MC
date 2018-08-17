Public Class frmStbEditCatalogo

    'Declaracion de variables del formulario
    Dim ModoForm As String
    Dim mCancelo As Boolean
    Dim Cambio As Boolean 'Variable que me indicara si cambio el contenido de los campos
    Dim Band As Boolean ' Variable que me indica el origen del cambio True= grid, false CheckBox

    Public ObjCatalogoRow As BOSistema.Win.StbEntCatalogo.StbCatalogoRow
    Public ObjValoresCatalogo As BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable

    'Para posicionar el foco en el registro agregado
    Dim mIDCatalogo As Integer


    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton


    Public Property IDCatalogo() As Integer
        Get
            Return mIDCatalogo
        End Get
        Set(ByVal value As Integer)
            mIDCatalogo = value
        End Set
    End Property

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
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	InicializaVariables
    ' Description		:	Este procedimiento se encarga de inizilizar las variables del formulario
    ' y la apariencia de los grid
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Catálogo"
                Me.chkActivo.Enabled = False
                Me.grpValores.Enabled = False
                ObjValoresCatalogo = New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
                Me.GrdValores.DataSource = ObjValoresCatalogo.Source
                GrdValores.Caption = "Valores del Catálogo ( " & GrdValores.RowCount.ToString & " registros )"

                'Posiciono el foco en el primer control editable
                Me.txtNombre.Focus()
            Else
                Me.Text = "Modificar Catálogo"
                Me.chkActivo.Tag = "init"

                'Asigno los valores del registro que estoy editando
                Me.txtNombre.Text = ObjCatalogoRow.sNombre
                Me.txtDescripcion.Text = ObjCatalogoRow.sDescripcion
                Me.chkActivo.Checked = ObjCatalogoRow.nActivo
                Me.ChkReservado.Checked = ObjCatalogoRow.nReservado

                If Not ObjValoresCatalogo Is Nothing Then
                    grpValores.Enabled = True
                    Me.GrdValores.DataSource = ObjValoresCatalogo.Source
                    GrdValores.Caption = "Valores del Catálogo ( " & Me.GrdValores.RowCount.ToString & " registros )"
                    GrdValores.Splits(0).DisplayColumns("ColumnMentira").Visible = False
                End If

                'Habilito la edicion del nombre del catalogo en dependencia si tiene o no valores de 
                'catalogos asociados
                If Me.GrdValores.RowCount > 0 Then
                    Me.txtNombre.Enabled = False
                    'Posiciono el foco en el primer control editable
                    Me.txtDescripcion.Focus()
                Else
                    Me.txtNombre.Focus()
                End If

                'Si el registro esta inactivo no dejo que modifique nada mas que el estado
                If Me.chkActivo.Checked = False Then
                    Me.txtNombre.Enabled = False
                    Me.txtDescripcion.Enabled = False
                    Me.ChkReservado.Enabled = False
                    Me.chkActivo.Focus()
                End If
            End If

            'Formateo el grid
            GrdValores.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            GrdValores.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            GrdValores.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            GrdValores.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            GrdValores.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            GrdValores.Splits(0).DisplayColumns("nStbCatalogoID").Visible = False

            GrdValores.Splits(0).DisplayColumns("nActivo").Width = 8
            GrdValores.Columns("sCodigoInterno").Caption = "Código"
            GrdValores.Columns("sDescripcion").Caption = "Descripción"
            GrdValores.Columns("nActivo").Caption = "Activo"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	24/07/2006
    ' Procedure name	:	frmStbEditValorCatalogo_FormClosing
    ' Description		:	Libero la memoria de los objetos creados publicos en el formulario
    ' -----------------------------------------------------------------------------------------
    Private Sub frmStbEditCatalogo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjValoresCatalogo = Nothing
                ObjCatalogoRow = Nothing
            Else
                e.Cancel = True
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	frmStbEditCatalogo_Load
    ' Description		:	Cargar formulario de edicion de catálogos
    ' -----------------------------------------------------------------------------------------
    Private Sub frmStbEditCatalogo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            'Seteo la apariencia del formulario
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Metodo que inicializa las variables del formulario
            InicializaVariables()

            'Coloco el len de los textbox
            SetearControles()

            'Seteo las variables de estado del formulario
            Cambio = False
            AccionUsuario = AccionBoton.BotonCancelar

            Seguridad()

            Band = False
        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	SetearControles
    ' Description		:	Este metodo establece el tamaño de los controles de tipo caracter
    ' -----------------------------------------------------------------------------------------
    Private Sub SetearControles()
        Try
            Me.txtNombre.MaxLength = ObjCatalogoRow.GetColumnLenght("sNombre")
            Me.txtDescripcion.MaxLength = ObjCatalogoRow.GetColumnLenght("sDescripcion")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            If Cambio = True Then
                Select Case MsgBox("¿Desea salvar los cambios antes de salir? ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, NombreSistema)
                    Case MsgBoxResult.Yes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If FncValidaParametros() Then
                            SalvarCatalogo()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case MsgBoxResult.No
                        ObjValoresCatalogo.Table.RejectChanges()
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

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If FncValidaParametros() Then
            SalvarCatalogo()
        End If
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:   SalvarCatalogo	
    ' Description		:	Este procedimiento permite salvar los datos de un catalogo nuevo o modificado
    ' -----------------------------------------------------------------------------------------
    Private Sub SalvarCatalogo()
        Try
            '-------------------------------------------------
            'Asignando a la clase los valores que se 
            'requieren salvar en la Base de Datos.
            ObjCatalogoRow.sNombre = Trim(txtNombre.Text)
            ObjCatalogoRow.sDescripcion = Trim(txtDescripcion.Text)
            ObjCatalogoRow.nActivo = Me.chkActivo.Checked
            ObjCatalogoRow.nReservado = Me.ChkReservado.Checked

            If ModoFrm = "ADD" Then
                ObjCatalogoRow.FechaCreacion = FechaServer()
                ObjCatalogoRow.sUsuarioCreacion = InfoSistema.LoginName
            Else
                ObjCatalogoRow.FechaModificacion = FechaServer()
                ObjCatalogoRow.sUsuarioModificacion = InfoSistema.LoginName
            End If

            ObjCatalogoRow.Update()
            ObjValoresCatalogo.Update()

            mIDCatalogo = ObjCatalogoRow.nStbCatalogoID
            AccionUsuario = AccionBoton.BotonAceptar

            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	FncValidaParametros
    ' Description		:	Esta funcion permite validar los datos del registro de catalogo que se 
    'esta agregando o modificando, en este caso si se esta agregando uno nuevo se considera lo siguiente:
    '1-Se haya introducido un nombre, descripcion y que el estado no sea activo
    '2-El nombre del catalogo no debe repetirse en toda la tabla de catalogos
    ' -----------------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Dim VbResultado As Boolean
        Dim ObjCatataVali As BOSistema.Win.StbEntCatalogo.StbCatalogoDataTable

        Try
            'Inicializo la variable que me permitira validar si el nuevo registro de catalogo esta repetido o no
            ObjCatataVali = New BOSistema.Win.StbEntCatalogo.StbCatalogoDataTable

            VbResultado = False
            ErrorProvider1.Clear()

            If Trim(txtNombre.Text).Length = 0 Then
                MsgBox("El nombre del Catálogo no puede ser vacío.", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtNombre, "El nombre del Catálogo no puede ser vacío.")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If

            If Trim(txtDescripcion.Text).Length = 0 Then
                MsgBox("La descripción del Catálogo no puede ser vacía.", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtDescripcion, "La descripción del Catálogo no puede ser vacía.")
                Me.txtDescripcion.Focus()
                GoTo SALIR
            End If

            'Filtro el catalogo por el nombre para ver si hay registros con esas caracteristicas
            ObjCatataVali.Filter = " lower(Ltrim(rtrim(sNombre))) ='" & Trim(txtNombre.Text.ToLower) & "'"
            ObjCatataVali.Retrieve()

            'Si el estado del form es agregar y hay registros mando la validacion
            If ModoForm = "ADD" And ObjCatataVali.CountFiltro > 0 Then
                MsgBox("El nombre de este Catálogo ya existe.", MsgBoxStyle.Critical, NombreSistema)
                ErrorProvider1.SetError(Me.txtNombre, "El nombre de este Catálogo ya existe.")
                Me.txtNombre.SelectAll()
                Me.txtNombre.Focus()
                GoTo SALIR
            ElseIf ModoForm <> "ADD" And ObjCatataVali.CountFiltro > 0 Then
                If ObjCatataVali("nStbCatalogoID") <> ObjCatalogoRow.nStbCatalogoID Then
                    MsgBox("El nombre ya existe en otro Catálogo.", MsgBoxStyle.Critical, NombreSistema)
                    ErrorProvider1.SetError(Me.txtNombre, "El nombre ya existe en otro Catálogo.")
                    Me.txtNombre.SelectAll()
                    Me.txtNombre.Focus()
                    GoTo SALIR
                End If
            End If

            'Si el nuevo estado es TRUE
            If chkActivo.Checked = True Then
                If GrdValores.RowCount = 0 Then
                    MsgBox("Debe agregar un valor de Catálogo para poder guardar este Catálogo como activo.", MsgBoxStyle.Critical, NombreSistema)
                    ErrorProvider1.SetError(Me.GrdValores, "Debe agregar un valor de Catálogo para poder guardar este Catálogo como activo.")
                    Me.GrdValores.Focus()
                    GoTo SALIR
                Else

                    Dim i As Integer, Band As Boolean = False

                    For i = 0 To Me.GrdValores.RowCount - 1
                        If ObjValoresCatalogo.Itemn(i).nActivo = True Then
                            Band = True
                            Exit For
                        End If
                    Next
                    If Band = False Then
                        MsgBox("Debe activar o agregar un valor de Catálogo para poder guardar este Catálogo como activo.", MsgBoxStyle.Critical, NombreSistema)
                        ErrorProvider1.SetError(Me.GrdValores, "Debe activar o agregar un valor de Catálogo para poder guardar este Catálogo como activo.")
                        Me.GrdValores.Focus()
                        GoTo SALIR
                    End If
                End If


            End If

            VbResultado = True

SALIR:
            ObjCatataVali.Dispose()
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally
            ObjCatataVali = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	chkActivo_CheckedChanged
    ' Description		:	Si el estado pasa de TRUE A FALSE  se deben de inactivar los valores
    ' de catalogo asociados siempre y cuando los tenga, en caso contrario
    ' Si pasa del estado FALSE al estado TRUE debe de cambiar el estado de un hijo a TRUE o
    ' agregar un nuevo hijo
    ' -----------------------------------------------------------------------------------------
    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        Dim i As Integer

        If Band = False Then
            'Si el nuevo estado es FALSE se inactivan sus hijos si ya los tiene
            If chkActivo.Checked = False Then
                If Seg.HasPermission("EditarValorCatalogo") = True Then  'Habilita
                    If GrdValores.RowCount > 0 And ObjValoresCatalogo.Table.Select("nActivo=1 and nStbCatalogoID=" & Me.mIDCatalogo.ToString).Length > 0 Then
                        If MsgBox("Al inactivar este Catálogo se inactivarán también sus valores asociados." + Chr(13) + "¿Desea inactivarlo de todas formas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                            For i = 0 To GrdValores.RowCount - 1
                                ObjValoresCatalogo.Itemn(i).nActivo = False
                            Next
                        Else
                            Me.chkActivo.Checked = True
                        End If
                    End If
                End If
            End If
        End If
        Band = False

        Cambio = True
    End Sub

    Private Sub cmdAgregarValor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarValor.Click
        Dim ObjFrmEditValorCatalogo As frmStbEditValorCatalogo
        Try
            'Llamo al formulario para agregar un nuevo valor de catalogo

            ObjFrmEditValorCatalogo = New frmStbEditValorCatalogo

            ObjFrmEditValorCatalogo.ModoFrm = "ADD"
            ObjFrmEditValorCatalogo.ObjValorCatalogoRow = ObjValoresCatalogo.NewRow
            ObjFrmEditValorCatalogo.ObjCatalogoRow = ObjCatalogoRow

            ObjFrmEditValorCatalogo.ShowDialog()

            'En caso de haber agregar un valor de catalogo
            If ObjFrmEditValorCatalogo.AccionUsuario = frmStbEditValorCatalogo.AccionBoton.BotonAceptar Then
                chkActivo.Checked = True
                GrdValores.Caption = "Valores del Catálogo ( " & Me.GrdValores.RowCount.ToString & " registros )"
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditValorCatalogo = Nothing
        End Try
    End Sub

    Private Sub GrdValores_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles GrdValores.AfterColEdit
        Cambio = True
    End Sub

    Private Sub GrdValores_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles GrdValores.BeforeColEdit
        Try

            If e.Column.Name <> "nActivo" Then
                e.Cancel = True
            Else
                'Si activo un valor catalogo entonces activo a su papa catalogo
                If Me.GrdValores.Columns(e.ColIndex).Value = True Then
                    chkActivo.Checked = True
                Else
                    'Si lo que se esta haciendo es estableciendo a FALSE
                    'Verificare si no hay mas filas activas, si no las hay envio el mensaje
                    'para ver si el usuario inactiva el catalogo
                    Dim Cont As Integer = 0

                    Cont = ObjValoresCatalogo.Table.Select("nActivo=1 And nStbCatalogoID=" & ObjCatalogoRow.nStbCatalogoID.ToString).Length

                    'Si hay solo uno y ese uno es el que estoy editando
                    If Cont = 1 Then
                        If MsgBox("Al inactivar este registro se inactivará su Catálogo " & Chr(13) & _
                                  "¿Desea inactivarlo de todas formas?" & Chr(13) & _
                                  "Recuerde que la inactivación de un Catálogo básico puede " & Chr(13) & "ocasionar un funcionamiento indebido en alguna parte de la aplicación.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                            Band = True
                            chkActivo.Checked = False
                        Else
                            e.Cancel = True
                        End If

                    ElseIf Cont > 1 Then
                        If MsgBox("La inactivación de un valor puede provocar inconsistencias en la aplicación " & Chr(13) & _
                                   "¿Desea inactivarlo de todas formas?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                            e.Cancel = True
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	24/07/2006
    ' Procedure name	:	txtNombre_KeyPress
    ' Description		:	Valido que no entren espacios al nombre
    ' -----------------------------------------------------------------------------------------
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If CaracterValidoTexto(e.KeyChar, True) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If CaracterValidoTexto(e.KeyChar, False) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	11/10/2006
    ' Procedure name		   	:	Seguridad
    ' Description			   	:	Este procedimiento se encarga de activar o desactivar las opciones
    ' del formulario en dependencia de los permisos del usuario que inicio sesion
    ' -----------------------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            '******************************************
            'Controlar la opción SELECCIONAR PERIODO
            'En este caso, mnuMantPeriodo es la acción descrita en el UC y que debe estar definida además en la BD
            'lblMantPeriodo es el control que se desea habilitar o deshabilitar, el mas común sería un botón de la toolbar.
            '*****************************************
            If Seg.HasPermission("AgregarValorCatalogo") = False Then  'Habilita
                Me.cmdAgregarValor.Enabled = False
            Else  'Deshabilita
                Me.cmdAgregarValor.Enabled = True
            End If

            If Seg.HasPermission("EditarValorCatalogo") = False Then  'Habilita
                Me.GrdValores.AllowUpdate = False
                Me.GrdValores.AllowUpdateOnBlur = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ChkReservado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkReservado.CheckedChanged
        Cambio = True
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        Cambio = True
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        Cambio = True
    End Sub

    Private Sub GrdValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdValores.Click

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

    Private Sub ChkReservado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkReservado.GotFocus
        Try
            Me.ChkReservado.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ChkReservado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkReservado.LostFocus
        Try
            Me.ChkReservado.BackColor = Me.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class