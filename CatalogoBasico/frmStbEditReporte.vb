' ------------------------------------------------------------------------
' Autor:                Lic. Alberto S. Blandón Silva
' Fecha:                06/04/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditReporte.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Reportes.
'-------------------------------------------------------------------------
Public Class frmStbEditReporte

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdStbReporte As Long


    Dim XdsReporte As BOSistema.Win.XDataSet
    '-- Crear un data table de tipo Xdataset
    Dim ObjReportedt As BOSistema.Win.StbEntCatalogo.StbReporteDataTable
    Dim ObjReportedr As BOSistema.Win.StbEntCatalogo.StbReporteRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Reporte.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Reporte que corresponde al campo
    'nStbReporteID de la tabla StbReporte.
    Public Property IdReporte() As Long
        Get
            IdReporte = IdStbReporte
        End Get
        Set(ByVal value As Long)
            IdStbReporte = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto S. Blandón silva.
    ' Fecha:                06/04/2009
    ' Procedure Name:       frmScnEditReporte_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditReporte_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjReportedt.Close()
                ObjReportedt = Nothing

                ObjReportedr.Close()
                ObjReportedr = Nothing

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
    ' Autor:                Lic. Alberto S. Blandón Silva.
    ' Fecha:                06/04/2009
    ' Procedure Name:       frmScnEditReporte_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Reporte en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditreporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarNombreModulo()

            'Si el formulario está en modo edición
            'cargar los datos del Reporte.
            If ModoFrm = "UPD" Then
                Me.txtCodigo.Enabled = False
                CargarReporte()
                'CargarNombreModulo()
                ' Me.cboModulo.Text = XdsReporte("Modulo").ValueField("Nombre")

            End If
            If ModoFrm = "ADD" Then
                'CargarNombreModulo()
                Me.cboModulo.SelectedIndex = 0
                Me.cboModulo.Select()
            Else
                Me.txtDescripcion.Select()
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
    ' Autor:                Lic. Alberto S. Blandón Silva.
    ' Fecha:                06/04/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Reporte"
            Else
                Me.Text = "Modificar Reporte"
            End If

            XdsReporte = New BOSistema.Win.XDataSet

            ObjReportedt = New BOSistema.Win.StbEntCatalogo.StbReporteDataTable
            ObjReportedr = New BOSistema.Win.StbEntCatalogo.StbReporteRow

            If ModoFrm = "ADD" Then

                ObjReportedr = ObjReportedt.NewRow

                'Inicializar los Length de los campos
                'Me.txtCodigo.MaxLength = ObjReportedr.GetColumnLenght("nCodigo")
                Me.txtDescripcion.MaxLength = ObjReportedr.GetColumnLenght("sDescripcion")
                Me.txtTitulo.MaxLength = ObjReportedr.GetColumnLenght("sTitulo")
                Me.txtNombreArchivo.MaxLength = ObjReportedr.GetColumnLenght("sNombreArchivoRpt")
                Me.txtNombreTabla.MaxLength = ObjReportedr.GetColumnLenght("sNombreTablaConsulta")
                Me.txtWhereAdicional.MaxLength = ObjReportedr.GetColumnLenght("sWhereAdicional")
                Me.txtOrderByAdicional.MaxLength = ObjReportedr.GetColumnLenght("sOrderby")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto S. Blandón Silva
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarReporte
    ' Descripción:          Este procedimiento permite cargar los datos del Reporte
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarReporte()
        Try
            '-- Buscar el Reporte al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjReportedt.Filter = "nStbReporteID = " & IdReporte
            ObjReportedt.Retrieve()

            If ObjReportedt.Count = 0 Then
                Exit Sub
            End If
            ObjReportedr = ObjReportedt.Current

            'If ModoFrm = "ADD" Then
            '    'Nombre del Modulo
            '    If Not ObjReportedr.IsFieldNull("nStbReporteID") Then
            '        If Me.cboModulo.ListCount > 0 Then
            '            Me.cboModulo.SelectedIndex = 0
            '        End If
            '    Else
            '        Me.cboModulo.Text = ""
            '        Me.cboModulo.SelectedIndex = -1
            '    End If
            'Else
            '    If Not ObjReportedr.IsFieldNull("nSsgModuloID") Then

            '        Dim Strsql As String = ""
            '        Dim valor As String = ""

            '        valor = CStr(ObjReportedr.nSsgModuloID)

            '        Strsql = "SELECT     Nombre " & _
            '                 " FROM         StbReporte INNER JOIN " & _
            '                 " SsgModulo ON StbReporte.nSsgModuloID = SsgModulo.SsgModuloID " & _
            '                 " WHERE(StbReporte.nSsgModuloID = " & valor & ")"

            '        If XdsReporte.ExistTable("ModuloID") Then
            '            XdsReporte("ModuloID").ExecuteSql(Strsql)
            '        Else
            '            XdsReporte.NewTable(Strsql, "ModuloID")
            '            XdsReporte("ModuloID").Retrieve()
            '        End If
            '        Me.cboModulo.Text = XdsReporte("ModuloID").ValueField("Nombre")
            '    End If
            'End If

            'Módulo
            If Not ObjReportedr.IsFieldNull("nSsgModuloID") Then
                XdsReporte("Modulo").SetCurrentByID("SsgModuloID", ObjReportedr.nSsgModuloID)
            Else
                Me.cboModulo.Text = ""
                Me.cboModulo.SelectedIndex = -1
            End If

            'Codigo 
            If Not ObjReportedr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjReportedr.nCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Titulo
            If Not ObjReportedr.IsFieldNull("sTitulo") Then
                Me.txtTitulo.Text = ObjReportedr.sTitulo
            Else
                Me.txtTitulo.Text = ""
            End If


            'Nombre del Archivo
            If Not ObjReportedr.IsFieldNull("sNombreArchivoRpt") Then
                Me.txtNombreArchivo.Text = ObjReportedr.sNombreArchivoRpt
            Else
                Me.txtNombreArchivo.Text = ""
            End If

            'Nombre de la Tabla Consulta
            If Not ObjReportedr.IsFieldNull("SNombreTablaConsulta") Then
                Me.txtNombreTabla.Text = ObjReportedr.sNombreTablaConsulta
            Else
                Me.txtNombreTabla.Text = ""
            End If

            'Descripcion
            If Not ObjReportedr.IsFieldNull("sDescripcion") Then
                Me.txtDescripcion.Text = ObjReportedr.sDescripcion
            Else
                Me.txtDescripcion.Text = ""
            End If

            'Where Adicional del reporte
            If Not ObjReportedr.IsFieldNull("sWhereadicional") Then
                Me.txtWhereAdicional.Text = ObjReportedr.sWhereAdicional
            Else
                Me.txtWhereAdicional.Text = ""
            End If

            'Order By adicional a la Consulta del Reporte
            If Not ObjReportedr.IsFieldNull("sOrderby") Then
                Me.txtOrderByAdicional.Text = ObjReportedr.sOrderBy
            Else
                Me.txtOrderByAdicional.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtDescripcion.MaxLength = ObjReportedr.GetColumnLenght("sDescripcion")
            Me.txtTitulo.MaxLength = ObjReportedr.GetColumnLenght("sTitulo")
            Me.txtNombreArchivo.MaxLength = ObjReportedr.GetColumnLenght("sNombreArchivoRpt")
            Me.txtNombreTabla.MaxLength = ObjReportedr.GetColumnLenght("sNombreTablaConsulta")
            Me.txtWhereAdicional.MaxLength = ObjReportedr.GetColumnLenght("sWhereAdicional")
            Me.txtOrderByAdicional.MaxLength = ObjReportedr.GetColumnLenght("sOrderby")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto S. Blandón Silva.
    ' Fecha:                06/04/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarReporte()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto S. Blandón Silva
    ' Fecha:                06/04/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpReporte As New BOSistema.Win.StbEntCatalogo.StbReporteDataTable

        'Dim ObjTmpReporteCodExist As New BOSistema.Win.XDataSet
        'Dim Strsql As String = ""
        'Dim nModulo As Integer
        'Dim nModuloId As Integer

        Try
            Dim sCodigoReporte As String

            ValidaDatosEntrada = True
            Me.errDocSoporte.Clear()

            'Código

            'If Me.cboModulo.SelectedIndex <> -1 Then
            '    nModulo = XdsReporte("Modulo").ValueField("SsgModuloID")
            'End If

            'Strsql = "Select nCodigo FROM StbReporte " & _
            '                   " WHERE(nSsgModuloID = " & nModulo & ") and (nCodigo=" & Me.txtCodigo.Text & ")"


            'If ObjTmpReporteCodExist.ExistTable("CodigoID") Then
            '    ObjTmpReporteCodExist("CodigoID").ExecuteSql(Strsql)
            'Else
            '    ObjTmpReporteCodExist.NewTable(Strsql, "CodigoID")
            '    ObjTmpReporteCodExist("CodigoID").Retrieve()
            'End If

            'nModuloId = ObjTmpReporteCodExist("CodigoID").ValueField("nCodigo")


            If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
                MsgBox("Código del Reporte NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtCodigo, "Código del Reporte NO DEBE quedar vacío.")
                Me.txtCodigo.Focus()
                Exit Function
            End If

            sCodigoReporte = CInt(Me.txtCodigo.Text)

            'Determinar duplicados en las Siglas del Doc. Soporte
            If ModoFrm = "UPD" Then
                ObjTmpReporte.Filter = " nSsgModuloID = " & XdsReporte("Modulo").ValueField("SsgModuloID") & " And nCodigo = '" & sCodigoReporte & "'" & " And nStbReporteID <> " & IdReporte            '& " And Activo = 1"
            Else
                ObjTmpReporte.Filter = " nSsgModuloID = " & XdsReporte("Modulo").ValueField("SsgModuloID") & " And nCodigo = '" & sCodigoReporte & "'"                       '& " And Activo = 1"
            End If

            ObjTmpReporte.Retrieve()

            If ObjTmpReporte.Count > 0 Then
                MsgBox("El Código del Reporte NO DEBE Repetirse.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtCodigo, "Código del Reporte NO DEBE Repetirse.")
                Me.txtCodigo.Text = ""
                Me.txtCodigo.Focus()
                Exit Function
            End If

            'Nombre del Archivo
            'Determinar duplicados de Archivos
            If Trim(RTrim(Me.txtNombreArchivo.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre del Archivo del Reporte NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtNombreArchivo, "El Nombre del Archivo del Reporte NO DEBE quedar vacío.")
                Me.txtNombreArchivo.Focus()
                Exit Function
            End If

            If ModoFrm = "UPD" Then
                ObjTmpReporte.Filter = " Upper(sNombreArchivoRpt) = '" & UCase(Me.txtNombreArchivo.Text) & "'" & " And nStbReporteID <> " & IdReporte            '
            Else
                ObjTmpReporte.Filter = " Upper(sNombreArchivoRpt) = '" & UCase(Me.txtNombreArchivo.Text) & "'"
            End If

            ObjTmpReporte.Retrieve()
            If ModoFrm = "ADD" Then
                If ObjTmpReporte.Count > 0 Then
                    MsgBox("El Archivo del Reporte NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errDocSoporte.SetError(Me.txtNombreArchivo, "El Archivo del Reporte NO DEBE repetirse. ")
                    Me.txtNombreArchivo.SelectAll()
                    Me.txtNombreArchivo.Focus()
                    Exit Function
                End If
            End If

            'Descripción
            'Determinar duplicados en la Descripción
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox("La Descripción del Reporte NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtDescripcion, "La Descripción del Reporte NO DEBE quedar vacía.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            '' Titulo del Reporte
            '''' Fuerza a Digitar el titulo del Reporte
            If Trim(RTrim(Me.txtTitulo.Text)).ToString.Length = 0 Then
                MsgBox("El Titulo del Reporte NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtTitulo, "El Titulo del Reporte NO DEBE quedar vacío.")
                Me.txtTitulo.Focus()
                Exit Function
            End If

            ''Nombre de la Tabla
            ''''' Fuerza a escribir el Nombre de la tabla, Vista o Consulta
            If Trim(RTrim(Me.txtNombreTabla.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre de la Tabla del Reporte NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errDocSoporte.SetError(Me.txtNombreTabla, "El Nombre de la Tabla del Reporte NO DEBE quedar vacío.")
                Me.txtNombreTabla.Focus()
                Exit Function
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpReporte.Close()
            ObjTmpReporte = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto S. Blandón Silva
    ' Fecha:                06/04/2009
    ' Procedure Name:       SalvarReporte
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Reporte en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReporte()

        Try
            If ModoFrm = "ADD" Then
               
                ObjReportedr.sUsuarioCreacion = InfoSistema.LoginName
                ObjReportedr.dFechaCreacion = FechaServer()
            Else
                ObjReportedr.sUsuarioModificacion = InfoSistema.LoginName
                ObjReportedr.dFechaModificacion = FechaServer()
            End If

            If Me.cboModulo.SelectedIndex <> -1 Then
                ObjReportedr.nSsgModuloID = XdsReporte("Modulo").ValueField("SsgModuloID")
            Else
                ObjReportedr.nSsgModuloID = XdsReporte("Modulo").ValueField("SsgModuloID")
            End If

            ObjReportedr.nCodigo = Format(CInt(Me.txtCodigo.Text), "00")

            ObjReportedr.sTitulo = Me.txtTitulo.Text
            ObjReportedr.sDescripcion = Me.txtDescripcion.Text
            ObjReportedr.sNombreArchivoRpt = Me.txtNombreArchivo.Text
            ObjReportedr.sNombreTablaConsulta = Me.txtNombreTabla.Text
            ObjReportedr.sWhereAdicional = Me.txtWhereAdicional.Text
            ObjReportedr.sOrderBy = Me.txtOrderByAdicional.Text

            ObjReportedr.Update()

            IdStbReporte = ObjReportedr.nStbReporteID

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
    ' Autor:                Lic. Alberto S. Blandón Silva
    ' Fecha:                06/04/2009
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        If ValidaDatosEntrada() Then
                            SalvarReporte()
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
    Private Sub CargarNombreModulo()
        Try
            Dim Strsql As String = ""
            Strsql = " SELECT     SsgModuloID, CodInterno, Nombre " & _
                    " FROM SsgModulo " & _
                    " ORDER BY Nombre"

            If XdsReporte.ExistTable("Modulo") Then
                XdsReporte("Modulo").ExecuteSql(Strsql)
            Else
                XdsReporte.NewTable(Strsql, "Modulo")
                XdsReporte("Modulo").Retrieve()
            End If

            Me.cboModulo.DataSource = XdsReporte("Modulo").Source
            Me.cboModulo.Rebind()

            Me.cboModulo.Splits(0).DisplayColumns("SsgModuloID").Visible = False
            Me.cboModulo.Splits(0).DisplayColumns("SsgModuloID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboModulo.Splits(0).DisplayColumns("CodInterno").Width = 50
            Me.cboModulo.Splits(0).DisplayColumns("Nombre").Width = 210

            Me.cboModulo.Columns("CodInterno").Caption = "Código"
            Me.cboModulo.Columns("Nombre").Caption = "Nombre"

            Me.cboModulo.Splits(0).DisplayColumns("CodInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboModulo.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


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

    Private Sub txtTitulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitulo.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtTitulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTitulo.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNombreTabla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreTabla.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNombreTabla_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombreTabla.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboModulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModulo.TextChanged
        Try
            Dim ObjTmpReporteCod As New BOSistema.Win.XDataSet
            Dim Strsql As String = ""
            Dim parametromodulo As Integer

            If ModoFrm = "ADD" Then
                If Me.cboModulo.SelectedIndex <> -1 Then
                    parametromodulo = XdsReporte("Modulo").ValueField("SsgModuloID")
                Else
                    ObjReportedr.SetFieldNull("SsgModuloID")
                End If

                Strsql = "Select IsNull(Max(nCodigo), 0) + 1 As nCodigoSiguiente  " & _
                     " FROM StbReporte " & _
                     " WHERE(nSsgModuloID = " & parametromodulo & ")"

                If ObjTmpReporteCod.ExistTable("Codigo") Then
                    ObjTmpReporteCod("Codigo").ExecuteSql(Strsql)
                Else
                    ObjTmpReporteCod.NewTable(Strsql, "Codigo")
                    ObjTmpReporteCod("Codigo").Retrieve()
                End If
                Me.txtCodigo.Text = ObjTmpReporteCod("Codigo").ValueField("nCodigoSiguiente")
                Me.txtCodigo.Enabled = True
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class