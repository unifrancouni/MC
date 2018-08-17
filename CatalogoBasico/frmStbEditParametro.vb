' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                28/07/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditCargo.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Cargos.
'-------------------------------------------------------------------------
Public Class frmStbEditParametro

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdScnParametro As Long

    '-- Crear un data table de tipo Xdataset
    Dim ObjParametrodt As BOSistema.Win.StbEntCatalogo.StbParametroDataTable
    Dim ObjParametrodr As BOSistema.Win.StbEntCatalogo.StbParametroRow

    Dim ObjValorParametrodt As BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
    Dim ObjValorParametrodr As BOSistema.Win.StbEntCatalogo.StbValorParametroRow

    Dim ObjTempVparametroTable As BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
    Dim ObjTempVparametroRow As BOSistema.Win.StbEntCatalogo.StbValorParametroRow

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
    Public Property IdParametro() As Long
        Get
            IdParametro = IdScnParametro
        End Get
        Set(ByVal value As Long)
            IdScnParametro = value
        End Set
    End Property
 
    Private Sub frmScnEditParametro_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjParametrodt.Close()
                ObjParametrodt = Nothing

                ObjParametrodr.Close()
                ObjParametrodr = Nothing

                ObjValorParametrodt.Close()
                ObjValorParametrodt = Nothing

                ObjValorParametrodr.Close()
                ObjValorParametrodr = Nothing
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
    Private Sub frmScnEditParametro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                CargarParametro()
            End If

            If Me.chkActivo.Checked = False Then

                Me.chkActivo.Select()
            Else
                If ModoFrm = "ADD" Then
                    Me.txtCodigo.Select()
                    CargarID()
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
                Me.Text = "Agregar Parámetro"
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
            Else
                Me.Text = "Modificar Parámetro"
                Me.chkActivo.Enabled = True
            End If

            ObjParametrodt = New BOSistema.Win.StbEntCatalogo.StbParametroDataTable
            ObjParametrodr = New BOSistema.Win.StbEntCatalogo.StbParametroRow

            ObjValorParametrodt = New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
            ObjValorParametrodr = New BOSistema.Win.StbEntCatalogo.StbValorParametroRow

            If ModoFrm = "ADD" Then

                ObjParametrodr = ObjParametrodt.NewRow
                ObjValorParametrodr = ObjValorParametrodt.NewRow

                'Inicializar los Length de los campos
                Me.txtDescripcion.MaxLength = ObjParametrodr.GetColumnLenght("sDescripcionParametro")
            End If
            With Me.lstTipoDato.Items
                .Add(" D  Fecha")
                .Add(" N  Numerico")
                .Add(" S  Texto")
            End With


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
    Private Sub CargarParametro()

        Try
            '-- Buscar el Doc. Soporte corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.

            ObjParametrodt.Filter = "nStbParametroID = " & IdParametro
            ObjParametrodt.Retrieve()

            ObjValorParametrodt.Filter = "nStbParametroID = " & IdParametro
            ObjValorParametrodt.Retrieve()
            If ObjParametrodt.Count = 0 Then
                Exit Sub
            End If

            ObjParametrodr = ObjParametrodt.Current
            ObjValorParametrodr = ObjValorParametrodt.Current

            'Id
            If Not ObjParametrodr.IsFieldNull("nStbParametroID") Then
                Me.txtCodigo.Text = ObjParametrodr.nStbParametroID
            Else
                Me.txtCodigo.Text = ""
            End If

            'Valor del parametro
            If Not ObjValorParametrodr.IsFieldNull("sValorParametro") Then
                Me.txtValorParametro.Text = ObjValorParametrodr.sValorParametro
            Else
                Me.txtValorParametro.Text = ""
            End If

            'Descripcion
            If Not ObjParametrodr.IsFieldNull("sDescripcionParametro") Then
                Me.txtDescripcion.Text = ObjParametrodr.sDescripcionParametro
            Else
                Me.txtDescripcion.Text = ""
            End If

            'Tipo de Dato
            If Not ObjValorParametrodr.IsFieldNull("sTipoDato") Then

                If ObjValorParametrodr.sTipoDato = "N" Then
                    Me.lstTipoDato.Text = " N  Numerico"
                ElseIf ObjValorParametrodr.sTipoDato = "D" Then
                    Me.lstTipoDato.Text = " D  Fecha"
                ElseIf ObjValorParametrodr.sTipoDato = "S" Then
                    Me.lstTipoDato.Text = " S  Texto"
                End If
            End If
            'Fecha Inicio
            If Not ObjValorParametrodr.IsFieldNull("dFechaInicio") Then
                Me.dtpFechaInicio.Text = ObjValorParametrodr.dFechaInicio
            End If

            If Not ObjValorParametrodr.IsFieldNull("dFechaFin") Then
                Me.dtpFechaFin.Text = ObjValorParametrodr.dFechaFin
                Me.chkActivo.Enabled = True
            Else
                Me.chkActivo.CheckState = CheckState.Indeterminate
            End If

            'Inicializar los Length de los campos
            Me.txtDescripcion.MaxLength = ObjParametrodr.GetColumnLenght("sDescripcionParametro")


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
                SalvarParametro()
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
        Dim ObjTmpParametro As New BOSistema.Win.StbEntCatalogo.StbParametroDataTable
        Dim ObjTmpValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try

            ValidaDatosEntrada = True
            Me.errDocSoporte.Clear()

            ObjTmpParametro.Retrieve()

            'Descripción
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox("Descripción del Parámetro NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtDescripcion, "Descripción del Parámetro NO DEBE quedar vacía.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'Descripción
            'Determinar duplicados en la Descripción
            If ModoFrm = "UPD" Then
                ObjTmpParametro.Filter = " Upper(sDescripcionParametro) = '" & UCase(Me.txtDescripcion.Text) & "'" & " And nStbParametroID <> " & IdParametro            '& " And Activo = 1"
            Else
                ObjTmpParametro.Filter = " Upper(sDescripcionParametro) = '" & UCase(Me.txtDescripcion.Text) & "'"                       '& " And Activo = 1"
            End If

            ObjTmpParametro.Retrieve()

            If ObjTmpParametro.Count > 0 Then
                MsgBox("La Descripción del Parámetro NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtDescripcion, "La Descripción del Parámetro NO DEBE repetirse. ")
                Me.txtDescripcion.SelectAll()
                Me.txtDescripcion.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpParametro.Close()
            ObjTmpParametro = Nothing

            ObjTmpValorParametro.Close()
            ObjTmpValorParametro = Nothing
        End Try
    End Function
    Private Sub SalvarParametro()
        Try
            If ModoFrm = "ADD" Then
                ObjParametrodr.sDescripcionParametro = Me.txtDescripcion.Text
                ObjParametrodr.sUsuarioCreacion = InfoSistema.LoginName
                ObjParametrodr.dFechaCreacion = FechaServer()

                ObjValorParametrodr.nStbParametroID = Format(CInt(Me.txtCodigo.Text), "00")
                ObjValorParametrodr.dFechaInicio = Me.dtpFechaInicio.Text
                If Me.lstTipoDato.Text = " N  Numerico" Then
                    ObjValorParametrodr.sTipoDato = "N"
                ElseIf Me.lstTipoDato.Text = " D  Fecha" Then
                    ObjValorParametrodr.sTipoDato = "D"
                ElseIf Me.lstTipoDato.Text = " S  Texto" Then
                    ObjValorParametrodr.sTipoDato = "S"
                End If
                ObjValorParametrodr.sValorParametro = Me.txtValorParametro.Text

                If Me.dtpFechaFin.Text <> "" And Me.chkActivo.Checked = True Then
                    ObjValorParametrodr.dFechaFin = Me.dtpFechaFin.Text
                End If

                ObjValorParametrodr.sUsuarioCreacion = InfoSistema.LoginName
                ObjValorParametrodr.dFechaCreacion = FechaServer()

            Else

                ObjParametrodr.sDescripcionParametro = Me.txtDescripcion.Text
                ObjParametrodr.sUsuarioModificacion = InfoSistema.LoginName
                ObjParametrodr.dFechaModificacion = FechaServer()

                If Me.lstTipoDato.Text = " N  Numerico" Then
                    ObjValorParametrodr.sTipoDato = "N"
                ElseIf Me.lstTipoDato.Text = " D  Fecha" Then
                    ObjValorParametrodr.sTipoDato = "D"
                ElseIf Me.lstTipoDato.Text = " S  Texto" Then
                    ObjValorParametrodr.sTipoDato = "S"
                End If

                ObjValorParametrodr.sValorParametro = Me.txtValorParametro.Text
                If Me.dtpFechaFin.Text <> "" Then
                    ObjValorParametrodr.dFechaFin = CDate(Me.dtpFechaFin.Text)
                End If

                ObjValorParametrodr.sUsuarioModificacion = InfoSistema.LoginName
                ObjValorParametrodr.dFechaModificacion = FechaServer()

            End If

            ObjParametrodr.Update()
            ObjValorParametrodr.Update()

            IdScnParametro = ObjParametrodr.nStbParametroID
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
                            SalvarParametro()
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
            Me.chkActivo.Enabled = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarID()
        Try
            Dim ObjTmpParametroId As New BOSistema.Win.XDataSet
            Dim Strsql As String = ""

            If ModoFrm = "ADD" Then

                Strsql = "SELECT     ISNULL(MAX(nStbParametroID), 0) + 1 AS nCodigoSiguiente " & _
                          "FROM         StbParametro"

                If ObjTmpParametroId.ExistTable("ParametroId") Then
                    ObjTmpParametroId("ParametroId").ExecuteSql(Strsql)
                Else
                    ObjTmpParametroId.NewTable(Strsql, "ParametroId")
                    ObjTmpParametroId("ParametroId").Retrieve()
                End If
                Me.txtCodigo.Text = ObjTmpParametroId("ParametroId").ValueField("nCodigoSiguiente")
                Me.txtCodigo.Enabled = False
                Me.txtDescripcion.Focus()
            End If
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