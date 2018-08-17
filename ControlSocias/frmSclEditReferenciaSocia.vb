Imports BOSistema.Win
' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                07/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditReferenciaSocia.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de las referencias de una Socia.
'-------------------------------------------------------------------------
Public Class frmSclEditReferenciaSocia

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSclReferencia As Integer
    Dim IdSclSocia As Integer
    Dim IdSclConsultarDelegacion As Integer

    Dim XContadorReg As Integer
    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable

    '-- Clases para procesar la informacion de los combos
    Dim XdtTipoReferencia As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset
    Dim ObjReferenciadt As BOSistema.Win.SclEntSocia.SclReferenciaSociaDataTable
    Dim ObjReferenciadr As BOSistema.Win.SclEntSocia.SclReferenciaSociaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Referencia.
    Public Property IdReferencia() As Integer
        Get
            IdReferencia = IdSclReferencia
        End Get
        Set(ByVal value As Integer)
            IdSclReferencia = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdSocia() As Long
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Long)
            IdSclSocia = value
        End Set
    End Property

    'Propiedad utilizada para determinar si el usuario puede consultar
    'socias de otra delegacion.
    '1 = Puede visualizar todas las Delegaciones del Programa. 
    Public Property IdConsultarDelegacion() As Integer
        Get
            IdConsultarDelegacion = IdSclConsultarDelegacion
        End Get
        Set(ByVal value As Integer)
            IdSclConsultarDelegacion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       frmSclEditReferenciaSocia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global. 
    '-------------------------------------------------------------------------
    Private Sub frmSclEditReferenciaSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtTipoReferencia.Close()
                XdtTipoReferencia = Nothing

                ObjReferenciadt.Close()
                ObjReferenciadt = Nothing

                ObjReferenciadr.Close()
                ObjReferenciadr = Nothing

                XdtDatos.Close()
                XdtDatos = Nothing

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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       frmSclEditReferenciaSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la referencia en caso de estar en el 
    '                       modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditReferenciaSocia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarTipoReferencia()

            'Si el formulario está en modo edición
            'cargar los datos de la SociaGS.
            If ModoForm = "UPD" Then 'Solo modificar Observaciones.
                CargarReferencia()
                Me.txtObservaciones.Select()
                Me.mtbNumCedula.Enabled = False
                Me.cboReferencia.Enabled = False
                Me.cmdBuscar.Enabled = False
            Else
                If Me.IdSclSocia <> 0 Then
                    CargarCedula()
                    Me.cboReferencia.Select()
                Else
                    Me.mtbNumCedula.Select()
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Referencia a Socia"
            Else
                Me.Text = "Modificar Referencia de Socia"
            End If

            ObjReferenciadt = New BOSistema.Win.SclEntSocia.SclReferenciaSociaDataTable
            ObjReferenciadr = New BOSistema.Win.SclEntSocia.SclReferenciaSociaRow
            XdtTipoReferencia = New BOSistema.Win.XDataSet.xDataTable
            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboReferencia.ClearFields()

            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            Me.grpBotones.Enabled = False
            XContadorReg = 0

            If ModoForm = "ADD" Then
                ObjReferenciadr = ObjReferenciadt.NewRow
                'Inicializar los Length de los campos
                Me.txtObservaciones.MaxLength = ObjReferenciadr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       CargarReferencia
    ' Descripción:          Este procedimiento permite cargar los datos de la Socia
    '                       seleccionada en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarReferencia()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            'En caso que se esté editando una filtrar para esta socia:
            ObjReferenciadt.Filter = "nSclReferenciaSociaID = " & IdSclReferencia
            ObjReferenciadt.Retrieve()
            If ObjReferenciadt.Count = 0 Then
                Exit Sub
            End If
            ObjReferenciadr = ObjReferenciadt.Current

            'Cargar Socia:
            If Not ObjReferenciadr.IsFieldNull("nSclSociaID") Then
                'Cédula:
                strSQL = "SELECT sNumeroCedula FROM SclSocia " & _
                         "WHERE (nSclSociaID = " & ObjReferenciadr.nSclSociaID & ")"
                Me.mtbNumCedula.Text = XcDatos.ExecuteScalar(strSQL)
                'Nombre:
                strSQL = "SELECT SclSocia.sNombre1 + ' ' + dbo.SclSocia.sNombre2 + ' ' + dbo.SclSocia.sApellido1 + ' ' + dbo.SclSocia.sApellido2 as Nombre " & _
                         "FROM SclSocia WHERE (nSclSociaID = " & ObjReferenciadr.nSclSociaID & ")"
                Me.txtNombreSocia.Text = XcDatos.ExecuteScalar(strSQL)
                Me.txtNombreSocia.Tag = ObjReferenciadr.nSclSociaID
            End If

            'Cargar Combo de Tipo de Referencia:
            If Not ObjReferenciadr.IsFieldNull("nStbTipoReferenciaID") Then
                CargarTipoReferencia()
                If XdtTipoReferencia.Count > 0 Then
                    Me.cboReferencia.SelectedIndex = 0
                End If
                XdtTipoReferencia.SetCurrentByID("nStbValorCatalogoID", ObjReferenciadr.nStbTipoReferenciaID)
            Else
                Me.cboReferencia.Text = ""
                Me.cboReferencia.SelectedIndex = -1
            End If

            'Cargar Observaciones:
            If Not ObjReferenciadr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjReferenciadr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            ''Cargar Fecha de Supervision
            'Dim cmd As New XComando
            'strSQL = "select dFechaSupervision from SclReferenciaSocia where nSclReferenciaSociaID=" & ObjReferenciadr.nSclReferenciaSociaID
            'Dim ObjFecha = cmd.ExecuteScalar(strSQL)
            'If Not IsDBNull(ObjFecha) Then
            '    Dim fecha As Date = CDate(ObjFecha)
            '    cdeFechaSupervision.Value = fecha
            'End If


            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjReferenciadr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       CargarCedula
    ' Descripción:          Este procedimiento permite cargar los datos de la Socia
    '                       seleccionada en caso de estar en el Modo de Adicionar.
    '-------------------------------------------------------------------------
    Public Sub CargarCedula()
        Dim XcDatosA As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            
            'Cédula:
            strSQL = "SELECT sNumeroCedula FROM SclSocia " & _
                     "WHERE (nSclSociaID = " & Me.IdSclSocia & ")"
            Me.mtbNumCedula.Text = XcDatosA.ExecuteScalar(strSQL)
            'Nombre:
            strSQL = "SELECT SclSocia.sNombre1 + ' ' + dbo.SclSocia.sNombre2 + ' ' + dbo.SclSocia.sApellido1 + ' ' + dbo.SclSocia.sApellido2 as Nombre " & _
                     "FROM SclSocia WHERE (nSclSociaID = " & Me.IdSclSocia & ")"
            Me.txtNombreSocia.Text = XcDatosA.ExecuteScalar(strSQL)
            Me.txtNombreSocia.Tag = Me.IdSclSocia

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosA.Close()
            XcDatosA = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim Strsql As String
        Try

            ValidaDatosEntrada = True
            Me.errModulo.Clear()


            ''Fecha de supervision IS_DATE y menor a FechaActual (Server)
            'If IsDate(cdeFechaSupervision.Value) Then
            '    Dim fs = FechaServer()
            '    If Format(CDate(cdeFechaSupervision.Value), "yyy-MM-dd") >= Format(fs, "yyyy-MM-dd") Then
            '        MsgBox("La fecha de supervisión no debe ser mayor a la fecha de hoy.", vbCritical, "Error")
            '        Me.errModulo.SetError(cdeFechaSupervision, "La fecha de supervisión no debe ser mayor a la fecha de hoy.")
            '        ValidaDatosEntrada = False
            '    End If
            'Else
            '    MsgBox("Debe haber una fecha de supervision.", vbCritical, "Error")
            '    Me.errModulo.SetError(cdeFechaSupervision, "Debe haber una fecha de supervision.")
            '    ValidaDatosEntrada = False
            'End If


            'Seleccionar Socia:
            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'Cedula Socia debe existir en Catálogo de Socias:
            'Usuario unicamente puede Consultar Socias de su Delegación:
            If Me.IdSclConsultarDelegacion <> 1 Then
                Strsql = "SELECT nSclSociaID FROM  SclSocia WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (nSociaActiva =1) and (nDispuestaFormarGS = 1) and (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            Else
                Strsql = "SELECT nSclSociaID FROM  SclSocia WHERE (nSociaActiva =1) and (nDispuestaFormarGS = 1) and (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            End If
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("No existe socia ACTIVA con este Número de Cédula.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "No existe socia con este Número de Cédula.")
                Me.mtbNumCedula.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Debe haberse localizado una Socia o cargarse la actual:
            If (Me.txtNombreSocia.Text = "") Or (Me.txtNombreSocia.Tag = 0) Then
                MsgBox("Debe buscar la Socia a Ingresar.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "Debe buscar la Socia a Ingresar.")
                Me.mtbNumCedula.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            REM REM
            'Imposible si la Socia no tiene ninguna FNC con crédito aprobado:
            Strsql = "SELECT GS.nSclSociaID " & _
                     "FROM SclFichaNotificacionCredito AS FNC INNER JOIN StbValorCatalogo AS C ON FNC.nStbEstadoCreditoID = C.nStbValorCatalogoID  INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID  " & _
                     "INNER JOIN SclFichaSocia AS FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID  INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia ON GS.nSclSociaID = SclSocia.nSclSociaID " & _
                     "WHERE (C.sCodigoInterno = '2') and (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("La Socia no tiene ningun Crédito Aprobado.", MsgBoxStyle.Information)
                Me.errModulo.SetError(Me.mtbNumCedula, "La Socia no tiene ningun Crédito Aprobado.")
                Me.mtbNumCedula.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Seleccionar Tipo de Referencia:
            If Me.cboReferencia.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una referencia válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.cboReferencia, "Debe seleccionar una referencia válida.")
                Me.cboReferencia.Focus()
                Exit Function
            End If

            'No repetir para la misma Socia mas de un mismo tipo de referencia Activa:
            Strsql = "SELECT * FROM SclReferenciaSocia " & _
                     "WHERE (nActiva = 1) AND (nSclSociaId = " & Me.txtNombreSocia.Tag & ") " & _
                     "AND (nStbTipoReferenciaID = " & Me.cboReferencia.Columns("nStbValorCatalogoID").Value & ") AND (nSclReferenciaSociaID <> " & Me.IdSclReferencia & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Esta referencia ya ha sido asignada a la Socia.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.cboReferencia, "Esta referencia ya ha sido asignada a la Socia.")
                Me.cboReferencia.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       SalvarReferencia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub SalvarReferencia()
        Try

            If ModoForm = "ADD" Then
                ObjReferenciadr.NewRow()
                ObjReferenciadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjReferenciadr.dFechaCreacion = FechaServer()
                ObjReferenciadr.nActiva = 1
                ObjReferenciadr.nSclSociaID = Me.txtNombreSocia.Tag
                Me.IdSocia = Me.txtNombreSocia.Tag
            Else
                ObjReferenciadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjReferenciadr.dFechaModificacion = FechaServer()
            End If

            ObjReferenciadr.nStbTipoReferenciaID = Me.cboReferencia.Columns("nStbValorCatalogoID").Value
            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjReferenciadr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjReferenciadr.SetFieldNull("sObservaciones")
            End If

            ObjReferenciadr.Update()

            'Asignar el Id de la Referencia a la 
            'variable publica del formulario:
            IdSclReferencia = ObjReferenciadr.nSclReferenciaSociaID

            'If ObjReferenciadr.nSclReferenciaSociaID <> 0 Then
            '    Dim strSQL As String = "update SclReferenciaSocia set dFechaSupervision='" & Format(cdeFechaSupervision.Value, "yyyy-MM-dd") & "'" _
            '        & "  where nSclReferenciaSociaID=" & ObjReferenciadr.nSclReferenciaSociaID
            '    Dim cmd As New XComando
            '    cmd.ExecuteNonQuery(strSQL)
            'End If

            If Me.IdSclReferencia = 0 Then
                MsgBox("El registro NO PUDO Grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                'Si el salvado se realizó de forma satisfactoria
                'enviar mensaje informando y cerrar el formulario.
                If ModoForm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede salvar o quedarse en el formulario.
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
                            SalvarReferencia()
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       CargarTipoReferencia
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       tipos de referencias en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarTipoReferencia()
        Try
            Dim Strsql As String = ""

            'Limpiar Combo:
            Me.cboReferencia.ClearFields()

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoReferenciaSocia') " & _
                     " ORDER BY a.sCodigoInterno"

            XdtTipoReferencia.ExecuteSql(Strsql)
            Me.cboReferencia.DataSource = XdtTipoReferencia.Source
            cboReferencia.Rebind()

            Me.cboReferencia.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboReferencia.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
            Me.cboReferencia.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboReferencia.Splits(0).DisplayColumns("sDescripcion").Width = 265

            Me.cboReferencia.Columns("sCodigoInterno").Caption = "Código"
            Me.cboReferencia.Columns("sDescripcion").Caption = "Descripción"

            Me.cboReferencia.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboReferencia.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            Dim Strsql As String
            Me.errModulo.Clear()

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Cedula Socia debe existir en Catálogo de Socias:
            'Usuario unicamente puede Consultar Socias de su Delegación:
            If Me.IdSclConsultarDelegacion <> 1 Then
                Strsql = " SELECT a.nSclSociaID, a.sNumeroCedula, a.NombreSocia " & _
                         " FROM vwSclSocia a " & _
                         " WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (a.nSociaActiva =1) and (a.nDispuestaFormarGS = 1) " & _
                         " AND (a.sNumeroCedula = '" & Me.mtbNumCedula.Text & "') " & _
                         " ORDER BY a.NombreSocia"
            Else
                Strsql = " SELECT a.nSclSociaID, a.sNumeroCedula, a.NombreSocia " & _
                         " FROM vwSclSocia a " & _
                         " WHERE (a.nSociaActiva =1) and (a.nDispuestaFormarGS = 1) " & _
                         " AND (a.sNumeroCedula = '" & Me.mtbNumCedula.Text & "') " & _
                         " ORDER BY a.NombreSocia"
            End If
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("No existe socia ACTIVA con este Número de Cédula.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "No existe socia con este Número de Cédula.")
                Me.mtbNumCedula.Focus()
                Me.txtNombreSocia.Text = ""
                Me.txtNombreSocia.Tag = 0
                Exit Sub
            End If

            XContadorReg = 0
            XdtDatos.ExecuteSql(Strsql)
            If XdtDatos.Count > 1 Then
                grpBotones.Enabled = True
            Else
                grpBotones.Enabled = False
            End If
            PresentaSocia()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub PresentaSocia()
        Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreSocia")
        Me.txtNombreSocia.Tag = XdtDatos.Table.Rows(XContadorReg).Item("nSclSociaID")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaSocia()
    End Sub

    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSocia()
    End Sub

    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Esta sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSocia()
    End Sub

    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Esta sobre el ultimo registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSocia()
    End Sub

    Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
        vbModifico = True
        Me.txtNombreSocia.Text = ""
        Me.txtNombreSocia.Tag = 0
    End Sub

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    'Se indica que hubo modificación en la Observación:
    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboReferencia_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboReferencia.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Tipo de Referencia:
    Private Sub cboReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferencia.TextChanged
        vbModifico = True
    End Sub
End Class