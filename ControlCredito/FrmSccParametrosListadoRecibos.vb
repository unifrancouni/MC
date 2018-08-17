'Presenta el listado de los recibos. Ya sea todos o filtrados por un rango de fechas
Public Class FrmSccParametrosListadoRecibos

    Dim IntPermiteConsultar As Integer
    'Dim IntPermiteEditar As Integer
    'Dim IntDepartamento As Integer

    Public Enum EnumReportes
        Unico = 1
        ListadoRecibosFechaIngreso
    End Enum
    Dim mNomRep As EnumReportes
    Dim XdsCombos As BOSistema.Win.XDataSet

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        '----------------------------------------------------------------------
        'Llama al reporte del listado de recibos
        '----------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte


        Try

            If NomRep <> EnumReportes.ListadoRecibosFechaIngreso Then
                NomRep = EnumReportes.Unico
            End If

            If ValidarParametros() = False Then Exit Sub
            Me.errParametro.Clear()

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            Select Case NomRep
                Case EnumReportes.ListadoRecibosFechaIngreso

                    frmVisor.Parametros("@FechaInicio") = Format("yyyy-MM-dd HH:mm:ss", Me.cdeFechaInicial.Text)
                    frmVisor.Parametros("@FechaFinal") = Format("yyyy-MM-dd HH:mm:ss", Me.CdeFechaFinal.Text)
                    frmVisor.Parametros("@DigitadorId") = cboUsuario.Columns("NusuarioCreacionId").Value
                    frmVisor.Parametros("@TipoFecha") = IIf(Me.RdRecibo.Checked = True, 1, 0)
                    frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked = True, 1, 2)

                    Dim stipoFecha As String = IIf(Me.RdRecibo.Checked = True, "Recibo", "Creación")
                    frmVisor.Formulas("TipoFecha") = "'" & stipoFecha & "'"
                    frmVisor.Text = "Listado de recibos por fecha de " & stipoFecha
                    frmVisor.NombreReporte = "RepSccCC76.rpt"

                Case EnumReportes.Unico
                    If Me.RdDetalle.Checked = True Then
                        frmVisor.Text = "Listado de Recibos "
                        frmVisor.NombreReporte = "RepSccCC15.rpt"
                        frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked = True, 1, 2) & "'"
                        If cboUsuario.Columns("NusuarioCreacionId").Value <> -19 Then
                            frmVisor.CRVReportes.SelectionFormula = "{spSccReciboListadoDepositos.NusuarioCreacionId}=" & cboUsuario.Columns("NusuarioCreacionId").Value & " And {spSccReciboListadoDepositos.CodigoPrograma}='" & IIf(Me.RdUsuraCero.Checked = True, 1, 2) & "'"
                        End If

                    Else
                        frmVisor.Text = "Totales  de Recibos "
                        frmVisor.NombreReporte = "RepSccCC17.rpt"
                        frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked = True, 1, 2)
                        If cboUsuario.Columns("NusuarioCreacionId").Value <> -19 Then
                            frmVisor.CRVReportes.SelectionFormula = "{spSccReciboListadoDepositosTotales.NusuarioCreacionId}=" & cboUsuario.Columns("NusuarioCreacionId").Value
                        End If
                    End If

                    

                    ' Se filtra por rango de fechas de los recibos y por usuarios 
                    'FiltroUsuario = ""
                    'If cboUsuario.Columns("NusuarioCreacionId").Value <> -19 Then
                    '    FiltroUsuario = " And nUsuarioCreacionID= " & cboUsuario.Columns("NusuarioCreacionId").Value
                    'End If

                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@DigitadorId") = cboUsuario.Columns("NusuarioCreacionId").Value
                    frmVisor.Parametros("@TipoFecha") = IIf(Me.RdRecibo.Checked = True, 1, 0)

                    If Me.RdRecibo.Checked = True Then
                        'frmVisor.SQLQuery = "SELECT  * From vwSccReciboListadoDepositos      " & _
                        '        " Where dFechaRecibo>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaRecibo<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') " & _
                        '         Trim(FiltroUsuario) '& " Order by nUsuarioCreacionID,NCodigo  "
                        frmVisor.Formulas("RangoFecha") = "' POR FECHA DEL RECIBO DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    Else
                        'frmVisor.SQLQuery = "SELECT  * From vwSccReciboListadoDepositos      " & _
                        '        " Where dFechaCreacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaRecibo<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') " & _
                        '         Trim(FiltroUsuario) '&  " Order by nUsuarioCreacionID,NCodigo  "
                        frmVisor.Formulas("RangoFecha") = "' POR FECHA DE INGRESO DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    End If
            End Select

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False

            'Usuario:
            If Me.cboUsuario.Enabled Then
                If Me.cboUsuario.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Digitador válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboUsuario, "Debe seleccionar un Digitador válido.")
                    Me.cboUsuario.Focus()
                    GoTo SALIR
                End If
            End If

            If IsDBNull(cdeFechaInicial.Value) Then
                MsgBox("Debe seleccionar una fecha de inicio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válido.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If
            If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function



    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSccParametrosListadoRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDigitadores()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub CargarDigitadores()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 0 Then
                Strsql = "SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID AS NusuarioCreacionId, RTRIM(LTRIM(dbo.StbPersona.sNombre1)) " & _
                         " + ' ' + LTRIM(RTRIM(dbo.StbPersona.sNombre2)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido2)) AS NombreUsuario ,1 As Orden" & _
                         "   FROM         dbo.SsgCuenta INNER JOIN dbo.SrhEmpleado ON dbo.SsgCuenta.objEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                         " dbo.StbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.StbPersona.nStbPersonaID " & _
                         " WHERE (dbo.SsgCuenta.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                         "  ORDER BY RTRIM(LTRIM(dbo.StbPersona.sNombre1)), LTRIM(RTRIM(dbo.StbPersona.sNombre2)), LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)),LTrim(RTrim(dbo.StbPersona.sApellido2))"
            Else
                Strsql = "SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID AS NusuarioCreacionId, RTRIM(LTRIM(dbo.StbPersona.sNombre1)) " & _
                         " + ' ' + LTRIM(RTRIM(dbo.StbPersona.sNombre2)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido2)) AS NombreUsuario ,1 As Orden" & _
                         "   FROM         dbo.SsgCuenta INNER JOIN dbo.SrhEmpleado ON dbo.SsgCuenta.objEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
                         " dbo.StbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.StbPersona.nStbPersonaID " & _
                         "  ORDER BY RTRIM(LTRIM(dbo.StbPersona.sNombre1)), LTRIM(RTRIM(dbo.StbPersona.sNombre2)), LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)),LTrim(RTrim(dbo.StbPersona.sApellido2))"
            End If

            If XdsCombos.ExistTable("UsuarioRecibos") Then
                XdsCombos("UsuarioRecibos").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "UsuarioRecibos")
                XdsCombos("UsuarioRecibos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboUsuario.DataSource = XdsCombos("UsuarioRecibos").Source



            'Me.cboUsuario.Splits(0).DisplayColumns("usuarioCreacionId").Visible = False
            Me.cboUsuario.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboUsuario.Splits(0).DisplayColumns("NusuarioCreacionId").Visible = False
            'Me.cboUsuario.Splits(0).DisplayColumns("NombreUsuario").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboUsuario.Splits(0).DisplayColumns("NombreUsuario").Width = 260

            Me.cboUsuario.Columns("NusuarioCreacionId").Caption = "Código"
            Me.cboUsuario.Columns("NombreUsuario").Caption = "Digitador"

            Me.cboUsuario.Splits(0).DisplayColumns("NombreUsuario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            'Ubicarlo en el primer registro
            If Me.cboUsuario.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("UsuarioRecibos").AddRow()
                XdsCombos("UsuarioRecibos").ValueField("NombreUsuario") = "Todos"
                XdsCombos("UsuarioRecibos").ValueField("NusuarioCreacionId") = -19
                XdsCombos("UsuarioRecibos").ValueField("Orden") = 0
                XdsCombos("UsuarioRecibos").UpdateLocal()
                XdsCombos("UsuarioRecibos").Sort = "Orden,NombreUsuario asc"
                Me.cboUsuario.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub
    Private Sub InicializarVariables()
        Try
            'Inicializar las clases 
            XdsCombos = New BOSistema.Win.XDataSet
            ''Me.RdDetalle.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	13/03/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Delegación.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            ''Fecha Editar datos de Todas las Delegaciones:
            'Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            'IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

            ''Departamento de la Delegación
            'Strsql = "SELECT nStbDepartamentoID FROM vwStbDatosDelegacion WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            'IntDepartamento = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    Private Sub RdVentanadeGenero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdVentanadeGenero.CheckedChanged

    End Sub
End Class