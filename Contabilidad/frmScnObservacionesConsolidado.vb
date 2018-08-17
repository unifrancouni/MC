Public Class frmScnObservacionesConsolidado

    'Dim ObjObs As BOSistema.Win.ScnEntContabilidad.ScnEstadoFinancieroObservacionDataTable
    Dim ModoForm As String
    Dim IdMes As Integer
    Dim IdAnio As Integer
    Dim IdTipoFondo As Integer
    Dim IdEsBalance As Integer



    Dim SDesp As String

    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property



    Public Property SDescripcion() As String
        Get
            SDescripcion = SDesp
        End Get
        Set(ByVal value As String)
            SDesp = value
        End Set
    End Property


    Public Property Mes() As Integer
        Get
            Mes = IdMes
        End Get
        Set(ByVal value As Integer)
            IdMes = value
        End Set
    End Property


    Public Property Anio() As Integer
        Get
            Anio = IdAnio
        End Get
        Set(ByVal value As Integer)
            IdAnio = value
        End Set
    End Property
 

    Public Property TipoFondo() As Integer
        Get
            TipoFondo = IdTipoFondo
        End Get
        Set(ByVal value As Integer)
            IdTipoFondo = value
        End Set
    End Property

    Public Property EsBalance() As Integer
        Get
            EsBalance = IdEsBalance
        End Get
        Set(ByVal value As Integer)
            IdEsBalance = value
        End Set
    End Property
    Private Sub frmScnObservacionesConsolidado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")
            InicializarVariables()
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub InicializarVariables()
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Dim SQLstring As String
        ObjComando = New BOSistema.Win.XDataSet.xDataTable
        Try

            SQLstring = "SELECT sObservacion FROM ScnEstadoFinancieroObservacion Where  nEsBalance=" & Me.EsBalance & " And nTipoFondos=" & Me.TipoFondo & " And nMes= " & Me.Mes & " And nAnio= " & Anio
            ObjComando.ExecuteSql(SQLstring)
            If ObjComando.Count > 0 Then
                ModoForm = "UPD"
                Me.sObservacion.Text = Convert.ToString(ObjComando.Table.Rows(0).Item(0))
                'If Convert.ToInt32(ObjComando.Table.Rows(0).Item(1)) = 1 Then
                '    Me.ChekIncluir.Checked = True
                'End If
            Else
                ModoForm = "ADD"
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Dim strSQL As String = ""
        Dim dfecha As Date
        'Dim incluir As Integer
        dfecha = Format(FechaServer.Date, "yyyy-MM-dd")
        Try
            'If Me.ChekIncluir.Checked = True Then
            '    incluir = 1
            'Else
            '    incluir = 0
            '    Me.sObservacion.Text = ""
            'End If

            'strSQL = "EXEC spScnGrabarEstadoFinancieroObservacion=" & Me.IdObservacion & ",@Observacion='" & Me.sObservacion.Text & "',@Fecha='" & dfecha.Year & "-" & dfecha.Month & "-" & dfecha.Day & "'" & ",@UsuarioID=" & InfoSistema.IDCuenta & ",@Incluir= " & incluir & ", @Descripcion='" & Me.SDescripcion & "', @strModoFRM='" & Me.ModoFrm & "'"

            If Me.sObservacion.Text.Trim() <> "" Then


                strSQL = "EXEC spScnGrabarEstadoFinancieroObservacion '" & Me.sObservacion.Text.Trim() & "'," & InfoSistema.IDCuenta & "," & EsBalance & "," & TipoFondo & "," & Mes & "," & Anio
                ObjComando = New BOSistema.Win.XDataSet.xDataTable
                ObjComando.ExecuteSql(strSQL)
                'If ObjComando.Count > 0 Then
                'Me.IdObservacion = Convert.ToInt32(ObjComando.Table.Rows(0).Item(0))
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
                'End If
            Else
            AccionUsuario = AccionBoton.BotonAceptar
            Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        AccionUsuario = AccionBoton.BotonCancelar
        Me.Close()
    End Sub
End Class