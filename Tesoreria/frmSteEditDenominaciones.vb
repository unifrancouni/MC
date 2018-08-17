' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                09/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditDenominaciones.vb
' Descripci�n:          Este formulario permite ingresar o modificar datos en
'                       el Cat�logo de Denominaciones de Billetes/Monedas.
'-------------------------------------------------------------------------
Public Class frmSteEditDenominaciones

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSclDenominacion As Long 'SclSocia.nSclSociaID

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjDenominaciondt As BOSistema.Win.SteEntArqueo.SteDenominacionesDataTable
    Dim ObjDenominaciondr As BOSistema.Win.SteEntArqueo.SteDenominacionesRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Denominaci�n.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Denominaci�n.
    Public Property IdDenominacion() As Long
        Get
            IdDenominacion = IdSclDenominacion
        End Get
        Set(ByVal value As Long)
            IdSclDenominacion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       frmSteEditDenominaciones_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditDenominaciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjDenominaciondt.Close()
                ObjDenominaciondt = Nothing

                ObjDenominaciondr.Close()
                ObjDenominaciondr = Nothing

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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       frmSteEditDenominaciones_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Denominacion en caso de estar en   
    '                       modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditDenominaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario est� en modo edici�n cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarDenominacion()
            Else 'ADD.
                chkBillete.Checked = True
            End If

            Me.cneValor.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       InicializarVariables
    ' Descripci�n:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Denominaci�n"
            Else
                Me.Text = "Modificar Denominaci�n"
            End If

            ObjDenominaciondt = New BOSistema.Win.SteEntArqueo.SteDenominacionesDataTable
            ObjDenominaciondr = New BOSistema.Win.SteEntArqueo.SteDenominacionesRow

            If ModoFrm = "ADD" Then
                ObjDenominaciondr = ObjDenominaciondt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       CargarDenominacion
    ' Descripci�n:          Este procedimiento permite cargar los datos del Cat�logo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarDenominacion()
        Try

            '-- Buscar la Denominaci�n correspondiente al Id especificado
            '-- como par�metro, en los casos que se est� editando una.
            ObjDenominaciondt.Filter = "nSteDenominacionID = " & IdDenominacion
            ObjDenominaciondt.Retrieve()
            If ObjDenominaciondt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjDenominaciondr = ObjDenominaciondt.Current 'Socia actual.

            'Cargar N�mero de Documento de Identificaci�n:
            If Not ObjDenominaciondr.IsFieldNull("nValor") Then
                Me.cneValor.Value = ObjDenominaciondr.nValor
            Else
                Me.cneValor.Value = 0
            End If

            'Tipo de Denominaci�n:            
            If Not ObjDenominaciondr.IsFieldNull("nBillete") Then
                Me.chkBillete.Checked = ObjDenominaciondr.nBillete
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripci�n:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarDenominacion()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripci�n:          Esta funci�n permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try

            ValidaDatosEntrada = True
            Me.errDenominacion.Clear()
            Dim StrSql As String

            'Valor de Denominaci�n Obligatorio:
            If Not IsNumeric(cneValor.Value) Then
                MsgBox("Valor de Denominaci�n Inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDenominacion.SetError(Me.cneValor, "Valor de Denominaci�n Inv�lido.")
                Me.cneValor.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If
            If CDbl(cneValor.Value) = 0 Then
                MsgBox("Valor de Denominaci�n Inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDenominacion.SetError(Me.cneValor, "Valor de Denominaci�n Inv�lido.")
                Me.cneValor.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Validar si tipo y valor de denominaci�n ya existe:
            StrSql = "SELECT nSteDenominacionID FROM SteDenominaciones " & _
                     "WHERE (nValor = " & cneValor.Value & ") AND (nSteDenominacionID <> " & IdDenominacion & ") AND (nBillete = " & IIf(chkBillete.Checked, 1, 0) & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Ya existe un Denominaci�n con este tipo y valor.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDenominacion.SetError(Me.cneValor, "Ya existe un Denominaci�n con este tipo y valor.")
                Me.cneValor.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       SalvarDenominacion
    ' Descripci�n:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Denominaci�n en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarDenominacion()
        Try

            'Actualiza usuario y fecha de creaci�n:
            If ModoForm = "ADD" Then
                ObjDenominaciondr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjDenominaciondr.dFechaCreacion = FechaServer()
            Else
                ObjDenominaciondr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjDenominaciondr.dFechaModificacion = FechaServer()
            End If

            'Valor de Denominaci�n:
            ObjDenominaciondr.nValor = cneValor.Value
            
            'Tipo de Denominaci�n:
            If Me.chkBillete.Checked Then
                ObjDenominaciondr.nBillete = 1
            Else
                ObjDenominaciondr.nBillete = 0
            End If
            
            ObjDenominaciondr.Update()
            'Asignar el Id de la Denominaci�n a la variable publica del formulario
            IdSclDenominacion = ObjDenominaciondr.nSteDenominacionID
            '--------------------------------

            'Si el salvado se realiz� de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificaci�n de Denominaci�n ID: " & Me.IdSclDenominacion & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripci�n:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("�Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarDenominacion()
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

    'Indicar que hubo modificaci�n
    Private Sub chkBillete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBillete.CheckedChanged
        vbModifico = True
    End Sub

    'Para controlar la ubicaci�n del foco en el checkbox
    Private Sub chkBillete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBillete.GotFocus
        Try
            Me.chkBillete.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Para controlar cuando el checkbox pierde el foco
    Private Sub chkBillete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBillete.LostFocus
        Try
            Me.chkBillete.BackColor = Me.grpDenominacion.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cneValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValor.TextChanged
        vbModifico = True
    End Sub
End Class