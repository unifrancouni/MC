Public Class frmSccEditEstadisticasINIDE
    Dim XdsEstadistica As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    
    Dim ModoForm As String
    Dim nsttEstadisticasINIDEID As Integer
    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean
    Dim sColor As String

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property
    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Registro de INIDE.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la CtaBancaria que corresponde al campo
    'SteCtaBancariaID de la tabla SteCtaBancaria.
    Public Property INIDEID() As Integer
        Get
            INIDEID = nsttEstadisticasINIDEID
        End Get
        Set(ByVal value As Integer)
            nsttEstadisticasINIDEID = value
        End Set
    End Property

    Private Sub Generar()
        Dim Conex As New DSSistema.DSSistema
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=300"
        Dim conexion As New SqlClient.SqlConnection()
        Dim XcProcedimiento As New BOSistema.Win.XComando
        Dim StrSql As String
        Dim FechaD As Date
        Dim FechaH As Date

        conexion.ConnectionString = myConnectionString
        If Me.cdeFechaD.ValueIsDbNull Then
            MsgBox("La Fecha de Inicio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
            Me.errEstadistica.SetError(Me.cdeFechaD, "La Fecha de Inicio NO DEBE quedar vacía.")
            Me.cdeFechaD.Focus()
            Exit Sub
        End If

        FechaD = Me.cdeFechaD.Value

        If FechaD.Day <> 1 Then
            MsgBox("La Fecha de Inicio No Puede ser diferente del dia primero.", MsgBoxStyle.Critical, NombreSistema)
            Me.errEstadistica.SetError(Me.cdeFechaD, "La Fecha de Inicio No Puede ser diferente del dia primero.")
            Me.cdeFechaD.Focus()
            Exit Sub
        End If
        FechaH = Me.cdeFechaH.Value
        If (FechaH.Date.AddDays(1).Month = FechaH.Date.Month) Then
            MsgBox("La Fecha Final solo puede ser el ultimo dia del mes.", MsgBoxStyle.Critical, NombreSistema)
            Me.errEstadistica.SetError(Me.cdeFechaD, "La Fecha Final solo puede ser el ultimo dia del mes.")
            Me.cdeFechaH.Focus()
            Exit Sub
        End If


        If Me.cdeFechaH.ValueIsDbNull Then
            MsgBox("La Fecha Final NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
            Me.errEstadistica.SetError(Me.cdeFechaH, "La Fecha Final NO DEBE quedar vacía.")
            Me.cdeFechaH.Focus()
            Exit Sub
        End If
        StrSql = ""

        If ModoForm = "ADD" Then
            StrSql = "Exec spSccGeneraEstadisticaINIDEPorPeriodo 0,'" & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta & ",'" & Format(Now(), "yyyy-MM-dd hh:mm:ss") & "',NULL,NULL"
        Else
            StrSql = "Exec spSccGeneraEstadisticaINIDEPorPeriodo " & Me.INIDEID & ",'" & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta & ",'" & Format(Now(), "yyyy-MM-dd hh:mm:ss") & "'," & InfoSistema.IDCuenta & ",'" & Format(Now(), "yyyy-MM-dd hh:mm:ss") & "'"
        End If

        conexion.Open()

        Dim comando As New SqlClient.SqlCommand(StrSql, conexion)
        '        XcProcedimiento.Execute(StrSql)
        comando.CommandTimeout = 600
        Me.Cursor = Cursors.WaitCursor
        comando.ExecuteNonQuery()
        Me.Cursor = Cursors.Default

        AccionUsuario = AccionBoton.BotonAceptar
        MsgBox("Generado las estadisticas para ese rango de fechas.", MsgBoxStyle.Critical, NombreSistema)


        Me.Close()
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try

    End Sub
  



    Private Sub frmSccEditEstadisticasINIDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            If Me.sColor = "Celeste" Then
                Me.sColor = "CelesteLight"
            End If

            ObjGUI.SetFormLayout(Me, Me.sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Si el formulario está en modo edición
            If ModoFrm = "ADD" Then
                Me.Text = "Generar estadisticas para un periodo"
                Me.cdeFechaD.Focus()
            Else
                CargarEstadistica()
                Me.Text = "Volver a generar estadisticas para un periodo"
                Me.cdeFechaD.Enabled = False
                Me.cdeFechaH.Enabled = False
            End If


            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try

    End Sub
    Public Sub CargarEstadistica()
        Try
            Dim StrSql = "Select * From SttEstadisticasINIDE Where nsttEstadisticasINIDEID=" & INIDEID


            XdsEstadistica = New BOSistema.Win.XDataSet
            If XdsEstadistica.ExistTable("Estadistica") Then
                XdsEstadistica("Estadistica").ExecuteSql(StrSql)
            Else
                XdsEstadistica.NewTable(StrSql, "Estadistica")
                XdsEstadistica("Estadistica").Retrieve()
            End If




            '-- Buscar el registro de estadisticas correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            cdeFechaD.Value = XdsEstadistica("Estadistica").ValueField("dFechaInicio")
            cdeFechaH.Value = XdsEstadistica("Estadistica").ValueField("dFechaFin")

        Catch ex As Exception

        End Try

    End Sub

    
    Private Sub CmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Generar()
    End Sub

   
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Generar()
    End Sub
End Class