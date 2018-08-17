Public Class frmStbEditValorCatalogo

    'Declaracion de variables del formulario
    Dim ModoForm As String
    Dim mCancelo As Boolean = False
    Dim Cambio As Boolean 'Variable que me indicara si cambio el contenido de los campos

    Public ObjValorCatalogoRow As BOSistema.Win.StbEntCatalogo.StbValorCatalogoRow
    Public ObjCatalogoRow As BOSistema.Win.StbEntCatalogo.StbCatalogoRow

    Dim mIDValorCatalogo As Integer
    Dim mIDCatalogo As Integer

    Public Property IDValorCatalogo() As Integer
        Get
            Return mIDValorCatalogo
        End Get
        Set(ByVal value As Integer)
            mIDValorCatalogo = value
        End Set
    End Property

    Public Property IDCatalogo() As Integer
        Get
            Return mIDCatalogo
        End Get
        Set(ByVal value As Integer)
            mIDCatalogo = value
        End Set
    End Property


    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

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

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	InicializaVariables
    ' Description		:	Este procedimiento se encarga de inicializar las variables y controles 
    ' del formulario
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Dim Xcomando As BOSistema.Win.XComando
        Try
            Me.txtNombre.Text = ObjCatalogoRow.sNombre
            Me.txtDescCat.Text = ObjCatalogoRow.sDescripcion
            Me.chkActiCat.Checked = ObjCatalogoRow.nActivo
            Me.grpCatalogo.Enabled = False

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Valor de Catálogo"
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
                Me.txtCodigoInterno.Focus()
            Else
                Xcomando = New BOSistema.Win.XComando
                Me.Text = "Modificar Valor de Catálogo"

                'Asigno los valores del registro que estoy editando
                Me.txtCodigoInterno.Text = ObjValorCatalogoRow.sCodigoInterno
                Me.txtDescripcion.Text = ObjValorCatalogoRow.sDescripcion
                Me.chkActivo.Checked = ObjValorCatalogoRow.nActivo
                Me.txtCodigoInterno.Enabled = False

                'Si el valor esta inactivo no se puede modificar nada mas 
                If Me.chkActivo.Checked = False Then
                    Me.txtDescripcion.Enabled = False
                    Me.chkActivo.Focus()
                Else
                    Me.txtDescripcion.Focus()
                End If

                Xcomando.Dispose()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Xcomando = Nothing
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
            Me.txtCodigoInterno.MaxLength = ObjValorCatalogoRow.GetColumnLenght("sCodigoInterno")
            Me.txtDescripcion.MaxLength = ObjValorCatalogoRow.GetColumnLenght("sDescripcion")
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
    Private Sub frmStbEditValorCatalogo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjValorCatalogoRow = Nothing
                ObjCatalogoRow = Nothing
            Else
                e.Cancel = True
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub



    Private Sub frmStbEditValorCatalogo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            'Setear la longitud de los controles
            SetearControles()

            'Seteo las variables de estado del formulario
            Cambio = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing
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

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	FncValidaParametros
    ' Description		:	Esta funcion permite validar los datos del registro de valor catalogo catalogo que se 
    'esta agregando o modificando, en este caso si se esta agregando uno nuevo se considera lo siguiente:
    '1-Se haya introducido un Codigo Interno, descripcion y que el estado sea activo por defecto 
    '2-El codigo interno no se puede repetir para el mismo catalogo
    '
    ' -----------------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Dim VbResultado As Boolean
        Dim ObjVaCataVali As BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable

        Try
            'Inicializo la variable que me permitira validar si el nuevo registro de catalogo esta repetido o no
            ObjVaCataVali = New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable

            VbResultado = False
            Me.ErrorProvider1.Clear()

            If Trim(txtCodigoInterno.Text).Length = 0 Then
                MsgBox("El Código del valor de Catálogo no puede ser vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodigoInterno, "El Código del valor de Catálogo no puede ser vacío.")
                Me.txtCodigoInterno.Focus()
                GoTo SALIR
            End If

            If Trim(txtDescripcion.Text).Length = 0 Then
                MsgBox("La descripción del valor de Catálogo no puede ser vacía.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtDescripcion, "La descripción del valor de Catálogo no puede ser vacía.")
                Me.txtDescripcion.Focus()
                GoTo SALIR
            End If

            'Filtro el catalogo por el nombre para ver si hay registros con esas caracteristicas
            ObjVaCataVali.Filter = " lower(Ltrim(rtrim(sCodigoInterno))) ='" & Trim(txtCodigoInterno.Text.ToLower) & "' and nStbCatalogoID=" & ObjCatalogoRow.nStbCatalogoID
            ObjVaCataVali.Retrieve()

            'Si el estado del form es agregar y hay registros mando la validacion
            If ModoForm = "ADD" And ObjVaCataVali.Count > 0 Then
                MsgBox("El código de éste valor Catálogo ya existe.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodigoInterno, "El Código de éste valor Catálogo ya existe.")
                Me.txtCodigoInterno.SelectAll()
                Me.txtCodigoInterno.Focus()
                GoTo SALIR
            ElseIf ModoForm <> "ADD" And ObjVaCataVali.Count > 0 Then
                If ObjVaCataVali("nStbValorCatalogoID") <> ObjValorCatalogoRow.nStbValorCatalogoID Then
                    MsgBox("El Código ya existe en otro Valor de Catálogo de este Catálogo.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.txtCodigoInterno, "El Código ya existe en otro Valor de Catálogo de este Catálogo.")
                    Me.txtCodigoInterno.SelectAll()
                    Me.txtCodigoInterno.Focus()
                    GoTo SALIR
                End If
            End If

            'Filtro el catalogo por el nombre para ver si hay registros con esas caracteristicas
            ObjVaCataVali.Filter = " Ltrim(rtrim(sDescripcion)) ='" & Trim(txtDescripcion.Text) & "' and nStbCatalogoID=" & ObjCatalogoRow.nStbCatalogoID
            ObjVaCataVali.Retrieve()

            'Si el estado del form es agregar y hay registros mando la validacion
            If ModoForm = "ADD" And ObjVaCataVali.Count > 0 Then
                MsgBox("El Nombre de éste valor Catálogo ya existe.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtDescripcion, "El Nombre de éste valor Catálogo ya existe.")
                Me.txtDescripcion.SelectAll()
                Me.txtDescripcion.Focus()
                GoTo SALIR
            ElseIf ModoForm <> "ADD" And ObjVaCataVali.Count > 0 Then
                If ObjVaCataVali("nStbValorCatalogoID") <> ObjValorCatalogoRow.nStbValorCatalogoID Then
                    MsgBox("El Nombre ya existe en otro Valor de Catálogo de este Catálogo.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.txtDescripcion, "El Nombre ya existe en otro Valor de Catálogo de este Catálogo.")
                    Me.txtDescripcion.SelectAll()
                    Me.txtDescripcion.Focus()
                    GoTo SALIR
                End If
            End If

            If ModoForm = "UPD" Then
                'Busco si este valor es el unico activo para este catalogo, si es asi pregunto si lo desea inactivar
                ' si es asi inactivo a su papa
                ObjVaCataVali.Filter = "nStbCatalogoID=" & ObjCatalogoRow.nStbCatalogoID.ToString & " and nActivo=1"
                ObjVaCataVali.Retrieve()

                'Si hay un registro activo y este es igual al que estoy editando y dejo su estado a inactivo
                'realizo la pregunta
                If ObjVaCataVali.Count = 1 Then
                    If ObjVaCataVali("nStbValorCatalogoID") = ObjValorCatalogoRow.nStbValorCatalogoID And chkActivo.Checked = False Then
                        If MsgBox("Al inactivar este registro se inactivará su Catálogo " & Chr(13) & _
                         "¿Desea inactivarlo de todas formas?" & Chr(13) & _
                         "Recuerde que la inactivación de un Catálogo básico puede ocasionar un " & Chr(13) & _
                         "funcionamiento indebido en alguna parte de la aplicación.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                            ObjCatalogoRow.nActivo = False
                        Else
                            Me.chkActivo.Checked = True
                            GoTo OtroSalir
                        End If
                    End If
                Else

                    'Si el estado del valor cambio de activo a inactivo advierto al usuario
                    If ObjValorCatalogoRow.nActivo = True And Me.chkActivo.Checked = False Then
                        If MsgBox("La inactivación de un valor puede provocar inconsistencias en la aplicación " & Chr(13) & _
                                   "¿Desea inactivarlo de todas formas?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                            Me.chkActivo.Checked = True
                            GoTo OtroSalir
                        End If
                    End If
                End If

            End If

OtroSalir:
                VbResultado = True

SALIR:
                ObjVaCataVali.Dispose()
                Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally
            ObjVaCataVali = Nothing
        End Try
    End Function

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
            ObjValorCatalogoRow.sCodigoInterno = Trim(txtCodigoInterno.Text)
            ObjValorCatalogoRow.sDescripcion = Trim(txtDescripcion.Text)
            ObjValorCatalogoRow.nActivo = chkActivo.Checked
            ObjValorCatalogoRow.nStbCatalogoID = ObjCatalogoRow.nStbCatalogoID

            ' Si el modo es agregar activo al catalogo papa de este valor catalogo
            If ModoFrm = "ADD" Then
                ObjValorCatalogoRow.FechaCreacion = FechaServer()
                ObjValorCatalogoRow.UsuarioCreacion = InfoSistema.LoginName
                ObjCatalogoRow.nActivo = True
            Else
                ObjValorCatalogoRow.FechaModificacion = FechaServer()
                ObjValorCatalogoRow.UsuarioModificacion = InfoSistema.LoginName

                'Si el valor catalogo que se esta editando es activo entonces
                'se activa su papa catalogo por si no estaba activo
                If chkActivo.Checked = True Then
                    ObjCatalogoRow.nActivo = True
                End If
            End If

            'Se actualizan los registros de catalogo y valor catalogo
            ObjValorCatalogoRow.Update()
            mIDValorCatalogo = ObjValorCatalogoRow.nStbValorCatalogoID
            ObjCatalogoRow.Update()
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

   

    Private Sub txtCodigoInterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoInterno.KeyPress
        If CaracterValidoCodigo(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        Else
            Cambio = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If CaracterValidoTexto(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

  
    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        Cambio = True
    End Sub

    Private Sub txtCodigoInterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoInterno.TextChanged
        Cambio = True
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        Cambio = True
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

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class