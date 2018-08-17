' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                28/07/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditEstructuraContable.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Niveles.
'-------------------------------------------------------------------------
Public Class frmScnEditEstructuraContable

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdScnEstructura As Integer

    '-- Crear un data table de tipo Xdataset
    Dim ObjEstructuradt As BOSistema.Win.ScnEntContabilidad.ScnEstructuraContableDataTable
    Dim ObjEstructuradr As BOSistema.Win.ScnEntContabilidad.ScnEstructuraContableRow

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

    'Propiedad utilizada para obtener el ID de Estructura Contable que corresponde al campo
    'nScnEstructuraContableID de la tabla ScnEstructuraContable.
    Public Property IdEstructura() As Integer
        Get
            IdEstructura = IdScnEstructura
        End Get
        Set(ByVal value As Integer)
            IdScnEstructura = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmScnEditEstructuraContable_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditEstructuraContable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjEstructuradt.Close()
                ObjEstructuradt = Nothing

                ObjEstructuradr.Close()
                ObjEstructuradr = Nothing
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
    ' Procedure Name:       frmScnEditEstructuraContable_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Doc. Soporte en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditEstructuraContable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición
            'cargar los datos del Doc. Soporte.
            If ModoFrm = "UPD" Then
                CargarEstructura()
            End If

            Me.txtDescripcion.Select()

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
                Me.Text = "Agregar Nivel"
            Else
                Me.Text = "Modificar Nivel"
            End If

            ObjEstructuradt = New BOSistema.Win.ScnEntContabilidad.ScnEstructuraContableDataTable
            ObjEstructuradr = New BOSistema.Win.ScnEntContabilidad.ScnEstructuraContableRow

            If ModoFrm = "ADD" Then

                ObjEstructuradr = ObjEstructuradt.NewRow

                'Inicializar los Length de los campos
                Me.txtDescripcion.MaxLength = ObjEstructuradr.GetColumnLenght("sDescripcionNivel")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarEstructura
    ' Descripción:          Este procedimiento permite cargar los datos del Doc. Soporte
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarEstructura()
        Try
            '-- Buscar el Doc. Soporte corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjEstructuradt.Filter = "nScnEstructuraContableID = " & Me.IdEstructura
            ObjEstructuradt.Retrieve()
            If ObjEstructuradt.Count = 0 Then
                Exit Sub
            End If
            ObjEstructuradr = ObjEstructuradt.Current

            'Nivel 
            If Not ObjEstructuradr.IsFieldNull("nNivel") Then
                Me.txtNivel.Text = ObjEstructuradr.nNivel
            Else
                Me.txtNivel.Text = ""
            End If

            'Descripcion
            If Not ObjEstructuradr.IsFieldNull("sDescripcionNivel") Then
                Me.txtDescripcion.Text = ObjEstructuradr.sDescripcionNivel
            Else
                Me.txtDescripcion.Text = ""
            End If

            'Dígitos por Nivel
            If Not ObjEstructuradr.IsFieldNull("nDigitosNivel") Then
                Me.txtDigitos.Text = ObjEstructuradr.nDigitosNivel
            Else
                Me.txtDigitos.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtDescripcion.MaxLength = ObjEstructuradr.GetColumnLenght("sDescripcionNivel")

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
                SalvarEstructura()
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
        Dim ObjTmpEstructura As New BOSistema.Win.ScnEntContabilidad.ScnEstructuraContableDataTable
        Try
            ValidaDatosEntrada = True
            Me.errEstructura.Clear()

            'Descripción
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox("La Descripción del Nivel NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errEstructura.SetError(Me.txtDescripcion, "La Descripción del Nivel NO DEBE quedar vacía.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'Descripción
            'Determinar duplicados en la Descripción
            If ModoFrm = "UPD" Then
                ObjTmpEstructura.Filter = " Upper(sDescripcionNivel) = '" & UCase(Me.txtDescripcion.Text) & "'" & " And nScnEstructuraContableID <> " & Me.IdEstructura
            Else
                ObjTmpEstructura.Filter = " Upper(sDescripcionNivel) = '" & UCase(Me.txtDescripcion.Text) & "'"
            End If

            ObjTmpEstructura.Retrieve()

            If ObjTmpEstructura.Count > 0 Then
                MsgBox("La Descripción del Nivel NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errEstructura.SetError(Me.txtDescripcion, "La Descripción del Nivel NO DEBE repetirse. ")
                Me.txtDescripcion.SelectAll()
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'Dígitos del Nivel
            If Trim(RTrim(Me.txtDigitos.Text)).ToString.Length = 0 Then
                MsgBox("La Cantidad de Dígitos del Nivel NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errEstructura.SetError(Me.txtDigitos, "La Cantidad de Dígitos del Nivel NO DEBE quedar vacía.")
                Me.txtDigitos.Focus()
                Exit Function
            End If

            'Dígitos del Nivel
            If CInt(Me.txtDigitos.Text) = 0 Then
                MsgBox("La Cantidad de Dígitos del Nivel DEBE ser Mayor que Cero(0).", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errEstructura.SetError(Me.txtDigitos, "La Cantidad de Dígitos del Nivel DEBE ser Mayor que Cero(0).")
                Me.txtDigitos.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpEstructura.Close()
            ObjTmpEstructura = Nothing

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
    Private Sub SalvarEstructura()
        Dim ObjTmpEstructura As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            If ModoFrm = "ADD" Then

                strSQL = " SELECT max(nNivel) as maxNivel " & _
                         " FROM   ScnEstructuraContable"

                ObjTmpEstructura.ExecuteSql(strSQL)

                If Not ObjTmpEstructura.ValueField("maxNivel") Is DBNull.Value Then
                    Me.txtNivel.Text = ObjTmpEstructura.ValueField("maxNivel") + 1
                Else
                    Me.txtNivel.Text = "1"
                End If

                ObjEstructuradr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjEstructuradr.dFechaCreacion = FechaServer()
            Else
                ObjEstructuradr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjEstructuradr.dFechaModificacion = FechaServer()
            End If

            ObjEstructuradr.nNivel = Me.txtNivel.Text

            ObjEstructuradr.sDescripcionNivel = Me.txtDescripcion.Text

            ObjEstructuradr.nDigitosNivel = Me.txtDigitos.Text

            ObjEstructuradr.Update()

            'Asignar el Id del Nivel a la 
            'variable publica del formulario
            Me.IdScnEstructura = ObjEstructuradr.nScnEstructuraContableID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Call GuardarAuditoria(2, 24, "Modificación de Estructura Contable ID:" & Me.IdScnEstructura & ".")
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
                            SalvarEstructura()
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

    'Solo se permite Letras A - Z, número 0-9, BackSpace y la Barra espaciadora
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
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
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtDigitos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDigitos.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtDigitos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDigitos.TextChanged
        vbModifico = True
    End Sub
End Class