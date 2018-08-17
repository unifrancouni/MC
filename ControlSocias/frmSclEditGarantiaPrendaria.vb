' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                21/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditGarantiaPrendaria.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Garantía Prendaria.
'-------------------------------------------------------------------------
Public Class frmSclEditGarantiaPrendaria
    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim intSclFichaID As Integer
    Dim intSclGarantiaPrendariaID As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjGarantiaPrendariadt As BOSistema.Win.SclEntSocia.SclGarantiaPrendariaDataTable
    Dim ObjGarantiaPrendariadr As BOSistema.Win.SclEntSocia.SclGarantiaPrendariaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton = AccionBoton.BotonNinguno
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Comprobante.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Ficha que corresponde al campo
    'nSclFichaSociaID de la tabla SclFichaSocia.
    Public Property intFichaID() As Integer
        Get
            intFichaID = intSclFichaID
        End Get
        Set(ByVal value As Integer)
            intSclFichaID = value
        End Set
    End Property
    'Propiedad utilizada para obtener el ID del otro crédito que corresponde al campo
    'SclOtroCreditoVigenteID de la tabla SclOtroCreditoVigente.
    Public Property intGarantiaPrendariaID() As Integer
        Get
            intGarantiaPrendariaID = intSclGarantiaPrendariaID
        End Get
        Set(ByVal value As Integer)
            intSclGarantiaPrendariaID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditGarantiaPrendaria_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditGarantiaPrendaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsFicha.Close()
                XdsFicha = Nothing

                ObjGarantiaPrendariadt.Close()
                ObjGarantiaPrendariadt = Nothing

                'ObjOtroCreditodr.Close()
                ObjGarantiaPrendariadr = Nothing
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
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclGarantiaPrendaria_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Otro Crédito en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclGarantiaPrendaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            If ModoFrm = "UPD" Then
                CargarGarantiaPrendaria()
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
    ' Fecha:                21/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Garantía Prendaria"
            Else
                Me.Text = "Modificar Garantía Prendaria"
            End If

            ObjGarantiaPrendariadt = New BOSistema.Win.SclEntSocia.SclGarantiaPrendariaDataTable
            ObjGarantiaPrendariadr = New BOSistema.Win.SclEntSocia.SclGarantiaPrendariaRow

            'Obtener los Datos de los combos
            XdsFicha = New BOSistema.Win.XDataSet

            'Limpiar los combos
            Me.cneValorGarantia.Value = 0

            Me.txtGarantia.Select()

            If ModoFrm = "ADD" Then

                ObjGarantiaPrendariadr = ObjGarantiaPrendariadt.NewRow

                'Inicializar los Length de los campos
                Me.txtGarantia.MaxLength = ObjGarantiaPrendariadr.GetColumnLenght("sDescripcion")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarGarantiaPrendaria
    ' Descripción:          Este procedimiento permite cargar los Datos de 
    '                       Garantía Prendaria asociado anteriormente a la Ficha.
    '-------------------------------------------------------------------------
    Private Sub CargarGarantiaPrendaria()
        Try
            Dim strSQL As String = ""

            '-- Buscar el Otro Crédito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjGarantiaPrendariadt.Filter = "nSclGarantiaPrendariaID = " & Me.intGarantiaPrendariaID
            ObjGarantiaPrendariadt.Retrieve()
            If ObjGarantiaPrendariadt.Count = 0 Then
                Exit Sub
            End If
            ObjGarantiaPrendariadr = ObjGarantiaPrendariadt.Current

            'Descripción Garantía Prendaria
            If Not ObjGarantiaPrendariadr.IsFieldNull("sDescripcion") Then
                Me.txtGarantia.Text = ObjGarantiaPrendariadr.sDescripcion
            Else
                Me.txtGarantia.Text = ""
            End If

            'Monto Solicitado
            If Not ObjGarantiaPrendariadr.IsFieldNull("nValorGarantia") Then
                Me.cneValorGarantia.Value = ObjGarantiaPrendariadr.nValorGarantia
            Else
                Me.cneValorGarantia.Value = 0
            End If

            'Inicializar los Length de los campos
            Me.txtGarantia.MaxLength = ObjGarantiaPrendariadr.GetColumnLenght("sDescripcion")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarGarantiaPrendaria()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            ValidaDatosEntrada = True
            Me.errGarantiaPrendaria.Clear()

            'Descripción de la Garantía
            If Trim(RTrim(Me.txtGarantia.Text)).ToString.Length = 0 Then
                MsgBox("Descripción de la Garantía NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaPrendaria.SetError(Me.txtGarantia, "Descripción de la Garantía NO DEBE quedar vacía.")
                Me.txtGarantia.Focus()
                Exit Function
            End If

            'Valor Garantía
            If Me.cneValorGarantia.ValueIsDbNull Then
                MsgBox("El Valor de la Garantía NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaPrendaria.SetError(Me.cneValorGarantia, "El Valor de la Garantía NO DEBE quedar vacío.")
                Me.cneValorGarantia.Focus()
                Exit Function
            End If

            'Valor Garantía
            If Me.cneValorGarantia.Value = 0 Then
                MsgBox("El Valor de la Garantía NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaPrendaria.SetError(Me.cneValorGarantia, "El Valor de la Garantía NO DEBE ser Cero.")
                Me.cneValorGarantia.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarGarantiaPrendaria
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Comprobante en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarGarantiaPrendaria()
        Try
            If ModoFrm = "ADD" Then
                ObjGarantiaPrendariadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjGarantiaPrendariadr.dFechaCreacion = FechaServer()
            Else
                ObjGarantiaPrendariadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjGarantiaPrendariadr.dFechaModificacion = FechaServer()
            End If

            ObjGarantiaPrendariadr.nSclFichaSociaID = Me.intFichaID
            ObjGarantiaPrendariadr.nValorGarantia = Me.cneValorGarantia.Value

            If LTrim(RTrim(Me.txtGarantia.Text)) = "" Then
                ObjGarantiaPrendariadr.SetFieldNull("sDescripcion")
            Else
                ObjGarantiaPrendariadr.sDescripcion = Me.txtGarantia.Text
            End If
			
			If ModoFrm <> "ADD" Then
				GuardarAuditoriaTablas(14, 2, "Modificar Garantia Prendaria", intGarantiaPrendariaID, InfoSistema.IDCuenta)
			End If

            ObjGarantiaPrendariadr.Update()

            'Asignar el Id del Comprobante a la variable publica del formulario
            Me.intGarantiaPrendariaID = ObjGarantiaPrendariadr.nSclGarantiaPrendariaID

            'Si el salvado se realizó de forma satisfactoria enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                GuardarAuditoriaTablas(14, 1, "Agregar Garantia Prendaria", intGarantiaPrendariaID, InfoSistema.IDCuenta)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")                
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
                            SalvarGarantiaPrendaria()
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

    Private Sub txtGarantia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGarantia.KeyPress
        Try
            If TextoValido(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtGarantia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGarantia.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneValorGarantia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValorGarantia.TextChanged
        vbModifico = True
    End Sub

End Class