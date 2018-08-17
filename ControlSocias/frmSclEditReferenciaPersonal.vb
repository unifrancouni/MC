Public Class frmSclEditReferenciaPersonal
    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim intSclFichaID As Integer
    Dim intSclGarantiaFiduciariaID As Integer

    Dim intSclReferenciaCrediticiaID As Integer
    Dim intSclReferenciaPersonalID As Integer

    Dim intStbPersonaReferenciaID As Integer

    Dim intTipoPersona As Integer
    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjGarantiaFiduciariadt As BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaDataTable
    Dim ObjGarantiaFiduciariadr As BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaRow

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

    'Propiedad utilizada para obtener el tipo de Persona. El del Credito o el Fiador.
    '1-Es el del credito ,2  es el Fiador.
    Public Property intSclTipoPersona() As Integer
        Get
            intSclTipoPersona = intTipoPersona
        End Get
        Set(ByVal value As Integer)
            intTipoPersona = value
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

    Public Property intReferenciaCrediticiaID() As Integer
        Get
            intReferenciaCrediticiaID = intSclReferenciaCrediticiaID
        End Get
        Set(ByVal value As Integer)
            intSclReferenciaCrediticiaID = value
        End Set
    End Property




    Public Property intReferenciaPersonalID() As Integer
        Get
            intReferenciaPersonalID = intSclReferenciaPersonalID
        End Get
        Set(ByVal value As Integer)
            intSclReferenciaPersonalID = value
        End Set
    End Property



    Public Property intPersonalID() As Integer
        Get
            intPersonalID = intStbPersonaReferenciaID
        End Get
        Set(ByVal value As Integer)
            intStbPersonaReferenciaID = value
        End Set
    End Property







    'Propiedad utilizada para obtener el ID del otro crédito que corresponde al campo
    'SclOtroCreditoVigenteID de la tabla SclOtroCreditoVigente.
    Public Property intGarantiaFiduciariaID() As Integer
        Get
            intGarantiaFiduciariaID = intSclGarantiaFiduciariaID
        End Get
        Set(ByVal value As Integer)
            intSclGarantiaFiduciariaID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditGarantiaFiduciaria_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditGarantiaFiduciaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        '    If AccionUsuario <> AccionBoton.BotonNinguno Then

        '        XdsFicha.Close()
        '        XdsFicha = Nothing

        '        ObjGarantiaFiduciariadt.Close()
        '        ObjGarantiaFiduciariadt = Nothing

        '        'ObjOtroCreditodr.Close()
        '        ObjGarantiaFiduciariadr = Nothing
        '    Else
        '        e.Cancel = True
        '        'Regresar la accion del Usuario al estado Inicial
        '        AccionUsuario = AccionBoton.BotonCancelar
        '    End If
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub frmSclGarantiaFiduciaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            'CargarFiador(0)


    

            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            If ModoFrm = "UPD" Then
                CargarFiador(intPersonalID)
                CargarDatos()

            Else

                CargarFiador(0)
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
                If intTipoPersona = 1 Then
                    Me.Text = "Agregar Referencia personal al Credito"
                Else
                    Me.Text = "Agregar Referencia personal al Fiador"
                End If

            Else
                If intTipoPersona = 1 Then
                    Me.Text = "Modificar Referencia personal al Credito"
                Else
                    Me.Text = "Modificar Referencia personal al Fiador"
                End If
            End If

            ObjGarantiaFiduciariadt = New BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaDataTable
            ObjGarantiaFiduciariadr = New BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaRow

            'Obtener los Datos de los combos
            XdsFicha = New BOSistema.Win.XDataSet



            'Limpiar los combos
            Me.cboFiador.ClearFields()
        

            Me.cboFiador.Select()

    

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDatos()
        Dim ObjFiadorDT As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Otro Crédito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.


            If intTipoPersona = 1 Then 'Credito

                strSQL = "Select nSclReferenciaPersonalID,nSclFichaSociaID,nStbPersonaReferenciaID,sDireccion    From SclReferenciaPersonal Where  nSclReferenciaPersonalID=" & Me.intReferenciaPersonalID
            Else ' Fiador

                strSQL = "Select nSclReferenciaCrediticiaPersonalID,nSclGarantiaFiduciariaID,nStbPersonaReferenciaID,sDireccion    From SclReferenciaCrediticiaPersonal  Where  nSclReferenciaCrediticiaPersonalID=" & Me.intReferenciaPersonalID

            End If


            RegTmp.ExecuteSql(strSQL)
            If RegTmp.Count > 0 Then






            End If


            'ObjGarantiaFiduciariadt.Filter = "nSclGarantiaFiduciariaID = " & Me.intGarantiaFiduciariaID
            'ObjGarantiaFiduciariadt.Retrieve()
            'If ObjGarantiaFiduciariadt.Count = 0 Then
            '    Exit Sub
            'End If
            'ObjGarantiaFiduciariadr = ObjGarantiaFiduciariadt.Current

            'Fiador
            If Not IsDBNull(RegTmp.ValueField("nStbPersonaReferenciaID")) Then
                If Me.cboFiador.ListCount > 0 Then
                    Me.cboFiador.SelectedIndex = 0
                End If
                XdsFicha("Fiador").SetCurrentByID("nStbPersonaID", RegTmp.ValueField("nStbPersonaReferenciaID"))
                Me.cboFiador.Enabled = False
            Else
                Me.cboFiador.Text = ""
                Me.cboFiador.SelectedIndex = -1
            End If

            'Datos adicionales que se presentan del Fiador
            ObjFiadorDT.Filter = " nStbPersonaID = " & RegTmp.ValueField("nStbPersonaReferenciaID")
            ObjFiadorDT.Retrieve()
            If ObjFiadorDT.Count > 0 Then
                Me.txtCedula.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sNumCedula")), "", ObjFiadorDT.ValueField("sNumCedula"))
                Me.txtCelular.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sCelular")), "", ObjFiadorDT.ValueField("sCelular"))
                Me.txtTelefono.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sTelefono")), "", ObjFiadorDT.ValueField("sTelefono"))
                Me.txtDireccionDomicilio.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sDireccion")), "", ObjFiadorDT.ValueField("sDireccion"))
            End If

            
            If Not IsDBNull(RegTmp.ValueField("sDireccion")) Then
                Me.txtDireccionTrabajo.Text = RegTmp.ValueField("sDireccion")
            Else
                Me.txtDireccionTrabajo.Text = ""
            End If

            

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFiadorDT.Close()
            ObjFiadorDT = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarFiador
    ' Descripción:          Este procedimiento permite cargar el listado de Persona
    '                       Natural en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarFiador(ByVal intFiadorID As Integer)
        Try
            Dim Strsql As String

            If intFiadorID = 0 Then

                If intTipoPersona = 1 Then
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1 AND " & _
                             " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFichaActiva Where nSclFichaSociaID= " & Me.intFichaID & ") " & _
                             " Order by a.sFiador Asc"

                Else
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1 AND " & _
                             " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFiadorFichaActiva Where nSclGarantiaFiduciariaID=" & intReferenciaCrediticiaID & ") " & _
                             " Order by a.sFiador Asc"
                End If



            Else



                If intTipoPersona = 1 Then
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1 AND " & _
                             " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFichaActiva) " & _
                             " or a.nStbPersonaID = " & intFiadorID & _
                             " Order by a.sFiador Asc"

                Else
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1 AND " & _
                             " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFiadorFichaActiva Where nSclGarantiaFiduciariaID=" & intReferenciaCrediticiaID & " ) " & _
                              " or a.nStbPersonaID = " & intFiadorID & _
                             " Order by a.sFiador Asc"
                End If








                'Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                '         " From vwStbPersonaNatural a " & _
                '         " WHERE ((a.nPersonaActiva = 1) AND (a.nStbPersonaID NOT IN (Select nStbFiadorID FROM vwSclFiadorFichaActiva))) " & _
                '         " or a.nStbPersonaID = " & intFiadorID & _
                '         " Order by a.sFiador Asc"
            End If

            If XdsFicha.ExistTable("Fiador") Then
                XdsFicha("Fiador").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Fiador")
                XdsFicha("Fiador").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboFiador.DataSource = XdsFicha("Fiador").Source

            Me.cboFiador.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            'Me.cboInstitucion.Splits(0).DisplayColumns("Sigla").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFiador.Splits(0).DisplayColumns("sFiador").Width = 160
            Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").Width = 120

            Me.cboFiador.Columns("sFiador").Caption = "Nombre del Referente"
            Me.cboFiador.Columns("sNumCedula").Caption = "No.Cédula"

            Me.cboFiador.Splits(0).DisplayColumns("sFiador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
                SalvarReferencia()
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
            Me.errGarantiaFiduciaria.Clear()

            'Fiador
            If Me.cboFiador.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Fiador válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.txtDireccionTrabajo, "Debe seleccionar un Fiador válido.")
                Me.txtDireccionTrabajo.Focus()
                Exit Function
            End If


            'Dirección Trabajo
            If Trim(RTrim(Me.txtDireccionTrabajo.Text)).ToString.Length = 0 Then
                MsgBox("Dirección del Trabajo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.txtDireccionTrabajo, "Dirección del Trabajo NO DEBE quedar vacío.")
                Me.txtDireccionTrabajo.Focus()
                Exit Function
            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarGarantiaFiduciaria
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Comprobante en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReferencia()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim StrSql As String
        Dim xResponse As Integer
        Try



            StrSql = "Exec spSclGrabarReferenciaPersonal '" & ModoFrm.ToString() & "'," & Me.intSclTipoPersona & "," & Me.intFichaID & "," & intSclReferenciaPersonalID & "," & intReferenciaCrediticiaID & "," & XdsFicha("Fiador").ValueField("nStbPersonaID") & ",'" & LTrim(RTrim(Me.txtDireccionTrabajo.Text)) & "','" & InfoSistema.LoginName & "'"


            xResponse = XcDatos.ExecuteScalar(StrSql)


            If xResponse = 0 Then
                MsgBox("Eror al intentar ingresar los datos.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                    intSclReferenciaPersonalID = xResponse
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If

            End If



            'If ModoFrm = "ADD" Then
            '    ObjGarantiaFiduciariadr.nUsuarioCreacionID = InfoSistema.IDCuenta
            '    ObjGarantiaFiduciariadr.dFechaCreacion = FechaServer()
            'Else
            '    ObjGarantiaFiduciariadr.nUsuarioModificacionID = InfoSistema.IDCuenta
            '    ObjGarantiaFiduciariadr.dFechaModificacion = FechaServer()
            'End If

            'If Me.cboFiador.SelectedIndex = -1 Then
            '    ObjGarantiaFiduciariadr.SetFieldNull("nStbFiadorID")
            'Else
            '    ObjGarantiaFiduciariadr.nStbFiadorID = XdsFicha("Fiador").ValueField("nStbPersonaID")
            'End If

            'ObjGarantiaFiduciariadr.nStbTipoPlazoIngresosID = XdsFicha("TipoPlazoIngresos").ValueField("nStbValorCatalogoID")
            'ObjGarantiaFiduciariadr.nStbTipoPlazoObligacionesID = XdsFicha("TipoPlazoObligaciones").ValueField("nStbValorCatalogoID")
            'ObjGarantiaFiduciariadr.nStbParentescoFiadorID = XdsFicha("Parentesco").ValueField("nStbValorCatalogoID")
            'ObjGarantiaFiduciariadr.nSclFichaSociaID = Me.intFichaID
            ''ObjGarantiaFiduciariadr.nMontoIngresos = Me.cneMontoIngresos.Value
            ''ObjGarantiaFiduciariadr.nMontoObligaciones = Me.cneObligaciones.Value

            'If LTrim(RTrim(Me.txtDireccionTrabajo.Text)) = "" Then
            '    ObjGarantiaFiduciariadr.SetFieldNull("sDireccionTrabajo")
            'Else
            '    ObjGarantiaFiduciariadr.sDireccionTrabajo = Me.txtDireccionTrabajo.Text
            'End If

            'ObjGarantiaFiduciariadr.Update()

            ''Asignar el Id del Comprobante a la 
            ''variable publica del formulario-
            'Me.intGarantiaFiduciariaID = ObjGarantiaFiduciariadr.nSclGarantiaFiduciariaID
            ''--------------------------------

            ''Si el salvado se realizó de forma satisfactoria
            ''enviar mensaje informando y cerrar el formulario.
            'If ModoFrm = "ADD" Then
            '    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            'Else
            '    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            'End If

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
                            Me.SalvarReferencia()
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
    'En caso que ocurra otro Tipo de Error
    Private Sub cboFiador_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFiador.Error
        Control_Error(e.Exception)
    End Sub
    'Se indica que hubo modificación en el combo de Institución
    Private Sub cboFiador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFiador.TextChanged
        Dim ObjFiadorDT As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Try

            If Me.cboFiador.SelectedIndex <> -1 Then
                'Datos adicionales que se presentan del Fiador
                ObjFiadorDT.Filter = " nStbPersonaID = " & XdsFicha("Fiador").ValueField("nStbPersonaID")
                ObjFiadorDT.Retrieve()
                If ObjFiadorDT.Count > 0 Then
                    Me.txtCedula.Text = ObjFiadorDT.ValueField("sNumCedula")
                    If Not ObjFiadorDT.ValueField("sCelular") Is DBNull.Value Then
                        Me.txtCelular.Text = ObjFiadorDT.ValueField("sCelular")
                    Else
                        Me.txtCelular.Text = ""
                    End If
                    If Not ObjFiadorDT.ValueField("sTelefono") Is DBNull.Value Then
                        Me.txtTelefono.Text = ObjFiadorDT.ValueField("sTelefono")
                    Else
                        Me.txtTelefono.Text = ""
                    End If
                    Me.txtDireccionDomicilio.Text = ObjFiadorDT.ValueField("sDireccion")
                End If
            Else
                Me.txtCedula.Text = ""
                Me.txtCelular.Text = ""
                Me.txtTelefono.Text = ""
                Me.txtDireccionDomicilio.Text = ""
            End If

            vbModifico = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFiadorDT.Close()
            ObjFiadorDT = Nothing
        End Try
    End Sub

    Private Sub txtDireccionTrabajo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccionTrabajo.KeyPress
        Try
            If TextoValido(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtDireccionTrabajo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccionTrabajo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMontoSolicitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoIngresos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cneObligaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoObligaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboTipoMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub
End Class