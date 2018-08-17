Public Class frmSclEditMantenimientoFiador
    Dim CodigoFicha As String
    Dim EstadoFicha As String

    Dim NombreFiador As String
    Dim FiadorGarantiaFiduciariaID As Integer
    Dim intFichaID As Integer
    Dim strColorFrm As String
    Public Property sCodigoFicha() As String
        Get
            sCodigoFicha = CodigoFicha
        End Get
        Set(ByVal value As String)
            CodigoFicha = value
        End Set
    End Property

    Public Property sEstadoFicha() As String
        Get
            sEstadoFicha = EstadoFicha
        End Get
        Set(ByVal value As String)
            EstadoFicha = value
        End Set
    End Property


    Public Property sNombreFiador() As String
        Get
            sNombreFiador = NombreFiador
        End Get
        Set(ByVal value As String)
            NombreFiador = value
        End Set
    End Property
    'Propiedad utilizada para obtener el ID del Comprobante que corresponde al campo
    'SclFichaSociaID de la tabla SclFichaSocia.
    Public Property intSclFichaID() As Integer
        Get
            intSclFichaID = intFichaID
        End Get
        Set(ByVal value As Integer)
            intFichaID = value
        End Set
    End Property

    ''El Id de garantia fiador que indica cual es el fiador nSclGarantiaFiduciariaID de SclGarantiaFidiucaria
    Public Property intFiadorGarantiaFiduciariaID() As Integer
        Get
            intFiadorGarantiaFiduciariaID = FiadorGarantiaFiduciariaID
        End Get
        Set(ByVal value As Integer)
            FiadorGarantiaFiduciariaID = value
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

    Dim XdsDetalle As BOSistema.Win.XDataSet

    Private Sub frmSclEditMantenimientoFiador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")
            txtCodigoRC.Text = CodigoFicha.ToString()
            txtEstadoRC.Text = EstadoFicha.ToString()
            txtNombreFiador.Text = NombreFiador.ToString()
            XdsDetalle = New BOSistema.Win.XDataSet
            CargarReferenciaPersonal()
            CargarReferenciaBancaria()
            CargarReferenciaComercial()
            CargarReferencia()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub LlamaAgregarRP()
        Dim ObjFrmSclEditReferenciaPersonal As New frmSclEditReferenciaPersonal
        Try
            ObjFrmSclEditReferenciaPersonal.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaPersonal.intFichaID = Me.intFichaID

            ObjFrmSclEditReferenciaPersonal.intReferenciaCrediticiaID = intFiadorGarantiaFiduciariaID
            ObjFrmSclEditReferenciaPersonal.intSclTipoPersona = 2
            ObjFrmSclEditReferenciaPersonal.strColor = "RojoLight"
            ObjFrmSclEditReferenciaPersonal.ShowDialog()

            If ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID <> 0 Then
                CargarReferenciaPersonal()
                XdsDetalle("ReferenciaPersonal").SetCurrentByID("nSclReferenciaPersonalID", ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID)
                Me.grdReferenciaPersonal.Row = XdsDetalle("ReferenciaPersonal").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaPersonal.Close()
            ObjFrmSclEditReferenciaPersonal = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRP()
        Dim ObjFrmSclEditReferenciaPersonal As New frmSclEditReferenciaPersonal
        Try
            If Me.grdReferenciaPersonal.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferenciaPersonal.intSclTipoPersona = 2 'Es Credito no fiador.
            ObjFrmSclEditReferenciaPersonal.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaPersonal.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaPersonal.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID = XdsDetalle("ReferenciaPersonal").ValueField("nSclReferenciaPersonalID")
            ObjFrmSclEditReferenciaPersonal.intPersonalID = XdsDetalle("ReferenciaPersonal").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaPersonal.strColor = "RojoLight"
            ObjFrmSclEditReferenciaPersonal.ShowDialog()

            CargarReferenciaPersonal()
            XdsDetalle("ReferenciaPersonal").SetCurrentByID("nSclReferenciaPersonalID", ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID)
            Me.grdReferenciaPersonal.Row = XdsDetalle("ReferenciaPersonal").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaPersonal.Close()
            ObjFrmSclEditReferenciaPersonal = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRP()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferenciaPersonal.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaCrediticiaPersonal   where nSclReferenciaCrediticiaPersonalID=" & XdsDetalle("ReferenciaPersonal").ValueField("nSclReferenciaPersonalID"))
                CargarReferenciaPersonal()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferenciaPersonal.Caption = "Listado de Referencias Personales (" + Me.grdReferenciaPersonal.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub
    Public Sub CargarReferenciaPersonal()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclReferenciaCrediticiaPersonalID as nSclReferenciaPersonalID ,a.nStbPersonaReferenciaID  as nStbPersonaReferenciaID,a.sFiador,a.sNumCedula,a.sTelefono,a.sCelular,a.sDireccion " & _
                     " From vwSclReferenciaPersonalFiador  a " & _
                     " Where a.nSclGarantiaFiduciariaID = " & Me.FiadorGarantiaFiduciariaID

            If XdsDetalle.ExistTable("ReferenciaPersonal") Then
                XdsDetalle("ReferenciaPersonal").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "ReferenciaPersonal")
                XdsDetalle("ReferenciaPersonal").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferenciaPersonal.DataSource = XdsDetalle("ReferenciaPersonal").Source
            Me.grdReferenciaPersonal.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferenciaPersonal.Caption = " Listado de Referencias Personales (" + Me.grdReferenciaPersonal.RowCount.ToString + " registros)"


            'Configuracion del Grid 
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("nSclReferenciaPersonalID").Visible = False
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("nStbPersonaReferenciaID").Visible = False


            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sNumCedula").Width = 100
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sTelefono").Width = 100
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sCelular").Width = 100
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sDireccion").Width = 250


            Me.grdReferenciaPersonal.Columns("sFiador").Caption = "Nombre"
            Me.grdReferenciaPersonal.Columns("sNumCedula").Caption = "Cédula"
            Me.grdReferenciaPersonal.Columns("sTelefono").Caption = "Teléfono"
            Me.grdReferenciaPersonal.Columns("sCelular").Caption = "Celular"
            Me.grdReferenciaPersonal.Columns("sDireccion").Caption = "Dirección"


            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sFiador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sDireccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbReferenciasPersonales_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferenciasPersonales.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRP"
                LlamaAgregarRP()
            Case "toolModificarRP"
                LlamaModificarRP()
            Case "toolEliminarRP"
                LlamaEliminarRP()
            Case "toolRefrescarRP"
                CargarReferenciaPersonal()
            Case "toolAyudaRP"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbReferenciasBancarias_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferenciasBancarias.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRB"
                LlamaAgregarRB()
            Case "toolModificarRB"
                LlamaModificarRB()
            Case "toolEliminarRB"
                LlamaEliminarRB()
            Case "toolRefrescarRB"
                CargarReferenciaBancaria()
            Case "toolAyudaRP"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaAgregarRB()
        Dim ObjFrmSclEditReferenciaBancaria As New frmSclEditReferenciaBancaria
        Try
            ObjFrmSclEditReferenciaBancaria.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaBancaria.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaBancaria.intReferenciaCrediticiaID = intFiadorGarantiaFiduciariaID
            ObjFrmSclEditReferenciaBancaria.intSclTipoPersona = 2
            ObjFrmSclEditReferenciaBancaria.strColor = "RojoLight"
            ObjFrmSclEditReferenciaBancaria.ShowDialog()

            If ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID <> 0 Then
                CargarReferenciaBancaria()
                XdsDetalle("ReferenciaBancaria").SetCurrentByID("nSclReferenciaBancariaID", ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID)
                Me.grdReferenciaBancaria.Row = XdsDetalle("ReferenciaBancaria").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaBancaria.Close()
            ObjFrmSclEditReferenciaBancaria = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRB()
        Dim ObjFrmSclEditReferenciaBancaria As New frmSclEditReferenciaBancaria
        Try
            If Me.grdReferenciaPersonal.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferenciaBancaria.intSclTipoPersona = 2 'Es Credito no fiador.
            ObjFrmSclEditReferenciaBancaria.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaBancaria.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaBancaria.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID = XdsDetalle("ReferenciaBancaria").ValueField("nSclReferenciaBancariaID")
            ObjFrmSclEditReferenciaBancaria.intPersonalID = XdsDetalle("ReferenciaBancaria").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaBancaria.strColor = "RojoLight"
            ObjFrmSclEditReferenciaBancaria.ShowDialog()

            CargarReferenciaBancaria()
            XdsDetalle("ReferenciaBancaria").SetCurrentByID("nSclReferenciaBancariaID", ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID)
            Me.grdReferenciaBancaria.Row = XdsDetalle("ReferenciaBancaria").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaBancaria.Close()
            ObjFrmSclEditReferenciaBancaria = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRB()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferenciaBancaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaBancariaFiador  where nSclReferenciaBancariaFiadorID=" & XdsDetalle("ReferenciaBancaria").ValueField("nSclReferenciaBancariaID"))
                CargarReferenciaBancaria()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferenciaBancaria.Caption = "Listado de Referencias Bancarias (" + Me.grdReferenciaBancaria.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub

    Public Sub CargarReferenciaBancaria()
        Try
            Dim Strsql As String

            'Strsql = " Select a.nSclReferenciaPersonalID as nSclReferenciaPersonalID ,a.nStbPersonaReferenciaID  as nStbPersonaReferenciaID,a.sFiador,a.sNumCedula,a.sTelefono,a.sCelular,a.sDireccion " & _
            '         " From vwSclReferenciaBancaria a " & _
            '         " Where a.nSclFichaSociaID = " & Me.intFichaID

            Strsql = "SELECT     a.nSclReferenciaBancariaFiadorID as nSclReferenciaBancariaID, a.nStbPersonaReferenciaID, a.sFiador, a.sNumCedula, a.sTelefono, a.sCelular, a.DesBanco, a.DesTipoCuenta, a.DesTipoMoneda, a.nMontoPromedio, a.dFechaReferencia, a.nAnionRelacion  FROM         dbo.vwSclReferenciaBancariaFiador AS a Where a.nSclGarantiaFiduciariaID = " & Me.FiadorGarantiaFiduciariaID

            '" Where a.nSclGarantiaFiduciariaID = " & Me.FiadorGarantiaFiduciariaID


            If XdsDetalle.ExistTable("ReferenciaBancaria") Then
                XdsDetalle("ReferenciaBancaria").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "ReferenciaBancaria")
                XdsDetalle("ReferenciaBancaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferenciaBancaria.DataSource = XdsDetalle("ReferenciaBancaria").Source
            Me.grdReferenciaBancaria.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferenciaBancaria.Caption = " Listado de Referencias Bancarias (" + Me.grdReferenciaBancaria.RowCount.ToString + " registros)"


            'Configuracion del Grid 
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nSclReferenciaBancariaID").Visible = False
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nStbPersonaReferenciaID").Visible = False


            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sNumCedula").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sTelefono").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sCelular").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesBanco").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoCuenta").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoMoneda").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nMontoPromedio").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("dFechaReferencia").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nAnionRelacion").Width = 100



            Me.grdReferenciaBancaria.Columns("sFiador").Caption = "Nombre"
            Me.grdReferenciaBancaria.Columns("sNumCedula").Caption = "Cédula"
            Me.grdReferenciaBancaria.Columns("sTelefono").Caption = "Teléfono"
            Me.grdReferenciaBancaria.Columns("sCelular").Caption = "Celular"
            Me.grdReferenciaBancaria.Columns("DesBanco").Caption = "Banco"
            Me.grdReferenciaBancaria.Columns("DesTipoCuenta").Caption = "Tipo de Cuenta"
            Me.grdReferenciaBancaria.Columns("DesTipoMoneda").Caption = "Tipo de Moneda"
            Me.grdReferenciaBancaria.Columns("nMontoPromedio").Caption = "Monto Promedio"
            Me.grdReferenciaBancaria.Columns("dFechaReferencia").Caption = "Fecha Referencia"
            Me.grdReferenciaBancaria.Columns("nAnionRelacion").Caption = "Años de Relación"




            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sFiador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesBanco").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoMoneda").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nMontoPromedio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("dFechaReferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nAnionRelacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    '-------------Referencia Comercial




    Private Sub LlamaAgregarRCO()
        Dim ObjFrmSclEditReferenciaComercial As New frmSclEditReferenciaComercial
        Try
            ObjFrmSclEditReferenciaComercial.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaComercial.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaComercial.intSclTipoPersona = 2
            ObjFrmSclEditReferenciaComercial.intReferenciaCrediticiaID = intFiadorGarantiaFiduciariaID
            ObjFrmSclEditReferenciaComercial.strColor = "RojoLight"
            ObjFrmSclEditReferenciaComercial.ShowDialog()

            If ObjFrmSclEditReferenciaComercial.intReferenciaComercialID <> 0 Then
                CargarReferenciaComercial()
                XdsDetalle("ReferenciaComercial").SetCurrentByID("nSclReferenciaComercialID", ObjFrmSclEditReferenciaComercial.intReferenciaComercialID)
                'Me.grdReferenciaComerciales.Row = XdsDetalle("ReferenciaComecial").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaComercial.Close()
            ObjFrmSclEditReferenciaComercial = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRCO()
        Dim ObjFrmSclEditReferenciaComercial As New frmSclEditReferenciaComercial
        Try
            If Me.grdReferenciaComerciales.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferenciaComercial.intSclTipoPersona = 2 'Es Credito no fiador.
            ObjFrmSclEditReferenciaComercial.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaComercial.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaComercial.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaComercial.intReferenciaComercialID = XdsDetalle("ReferenciaComercial").ValueField("nSclReferenciaComercialID")
            ObjFrmSclEditReferenciaComercial.intPersonalID = XdsDetalle("ReferenciaComercial").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaComercial.strColor = "RojoLight"
            ObjFrmSclEditReferenciaComercial.ShowDialog()

            CargarReferenciaComercial()
            XdsDetalle("ReferenciaComercial").SetCurrentByID("nSclReferenciaComercialID", ObjFrmSclEditReferenciaComercial.intReferenciaComercialID)
            Me.grdReferenciaComerciales.Row = XdsDetalle("ReferenciaComercial").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaComercial.Close()
            ObjFrmSclEditReferenciaComercial = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRCO()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferenciaComerciales.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaComercialFiador  where nSclReferenciaComercialFiadorID=" & XdsDetalle("ReferenciaComercial").ValueField("nSclReferenciaComercialID"))
                CargarReferenciaComercial()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferenciaComerciales.Caption = "Listado de Referencias Comerciales (" + Me.grdReferenciaComerciales.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub

    Public Sub CargarReferenciaComercial()
        Try
            Dim Strsql As String

            'Strsql = " Select a.nSclReferenciaPersonalID as nSclReferenciaPersonalID ,a.nStbPersonaReferenciaID  as nStbPersonaReferenciaID,a.sFiador,a.sNumCedula,a.sTelefono,a.sCelular,a.sDireccion " & _
            '         " From vwSclReferenciaBancaria a " & _
            '         " Where a.nSclFichaSociaID = " & Me.intFichaID

            Strsql = "SELECT     a.nSclReferenciaComercialFiadorID as nSclReferenciaComercialID, a.nStbPersonaReferenciaID, a.sFiador, a.sNumCedula, a.sTelefono, a.sCelular, a.DesComercio,a.dFechaReferencia, a.nAnionRelacion  FROM         dbo.vwSclReferenciaComercialFiador AS a Where a.nSclGarantiaFiduciariaID = " & Me.FiadorGarantiaFiduciariaID


            If XdsDetalle.ExistTable("ReferenciaComercial") Then
                XdsDetalle("ReferenciaComercial").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "ReferenciaComercial")
                XdsDetalle("ReferenciaComercial").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferenciaComerciales.DataSource = XdsDetalle("ReferenciaComercial").Source
            Me.grdReferenciaComerciales.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferenciaComerciales.Caption = " Listado de Referencias Comercial (" + Me.grdReferenciaComerciales.RowCount.ToString + " registros)"


            'Configuracion del Grid 
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nSclReferenciaComercialID").Visible = False
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nStbPersonaReferenciaID").Visible = False


            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sNumCedula").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sTelefono").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sCelular").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("DesComercio").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("dFechaReferencia").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nAnionRelacion").Width = 100



            Me.grdReferenciaComerciales.Columns("sFiador").Caption = "Nombre"
            Me.grdReferenciaComerciales.Columns("sNumCedula").Caption = "Cédula"
            Me.grdReferenciaComerciales.Columns("sTelefono").Caption = "Teléfono"
            Me.grdReferenciaComerciales.Columns("sCelular").Caption = "Celular"
            Me.grdReferenciaComerciales.Columns("DesComercio").Caption = "Comercio"
            Me.grdReferenciaComerciales.Columns("dFechaReferencia").Caption = "Fecha Referencia"
            Me.grdReferenciaComerciales.Columns("nAnionRelacion").Caption = "Años de Relación"




            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sFiador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("DesComercio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("dFechaReferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nAnionRelacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub







    '-----------Fin Referencia comercial

    Private Sub tbReferenciasComerciales_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferenciasComerciales.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRCO"
                LlamaAgregarRCO()
            Case "toolModificarRCO"
                LlamaModificarRCO()
            Case "toolEliminarRCO"
                LlamaEliminarRCO()
            Case "toolRefrescarRCO"
                CargarReferenciaComercial()
            Case "toolAyudaRP"
                LlamaAyuda()
        End Select
    End Sub

    Private Sub btnDatosFinanciero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosFinanciero.Click
        Dim ObjFrmSclEditInformacionFinanciera As New frmSclEditInformacionFinanciera
        Try
            ObjFrmSclEditInformacionFinanciera.ModoFrm = "ADD"
            ObjFrmSclEditInformacionFinanciera.intFichaID = Me.intFichaID
            ObjFrmSclEditInformacionFinanciera.intReferenciaCrediticiaID = Me.intFiadorGarantiaFiduciariaID
            'ObjFrmSclEditReferenciaComercial.intReferenciaComercialID = Me.intFiadorGarantiaFiduciariaID
            ObjFrmSclEditInformacionFinanciera.intSclTipoPersona = 2
            ObjFrmSclEditInformacionFinanciera.strColor = "RojoLight"


            ObjFrmSclEditInformacionFinanciera.ShowDialog()




        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditInformacionFinanciera.Close()
            ObjFrmSclEditInformacionFinanciera = Nothing
        End Try
    End Sub

    '--Cargar Referencia crediticia



    '-------------------------------------------------------------------------
    Public Sub CargarReferencia()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclReferenciaCrediticiaFiadorID as nSclReferenciaCrediticiaID,a.sSiglas,a.nMontoObtenido,a.nPlazo,a.sTipoPlazo,a.dFechaSolicitud,a.dFechaCancelacion " & _
                     " From vwSclReferenciaCrediticiaFiador a " & _
                     " Where a.nSclGarantiaFiduciariaID= " & Me.FiadorGarantiaFiduciariaID

            If XdsDetalle.ExistTable("Referencia") Then
                XdsDetalle("Referencia").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Referencia")
                XdsDetalle("Referencia").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferencia.DataSource = XdsDetalle("Referencia").Source
            Me.grdReferencia.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferencia.Caption = " Listado de Referencias Crediticias (" + Me.grdReferencia.RowCount.ToString + " registros)"



            'Configuracion del Grid 
            Me.grdReferencia.Splits(0).DisplayColumns("nSclReferenciaCrediticiaID").Visible = False

            Me.grdReferencia.Splits(0).DisplayColumns("nMontoObtenido").Width = 120
            Me.grdReferencia.Splits(0).DisplayColumns("nPlazo").Width = 50
            Me.grdReferencia.Splits(0).DisplayColumns("sTipoPlazo").Width = 80
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaSolicitud").Width = 80
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaCancelacion").Width = 80
            Me.grdReferencia.Splits(0).DisplayColumns("sSiglas").Width = 120

            Me.grdReferencia.Columns("nMontoObtenido").Caption = "Monto"
            Me.grdReferencia.Columns("nPlazo").Caption = "Plazo"
            Me.grdReferencia.Columns("sTipoPlazo").Caption = "Tipo Plazo"
            Me.grdReferencia.Columns("dFechaSolicitud").Caption = "Fecha Solicitud"
            Me.grdReferencia.Columns("dFechaCancelacion").Caption = "Fecha Cancelación"
            Me.grdReferencia.Columns("sSiglas").Caption = "Institución"

            Me.grdReferencia.Splits(0).DisplayColumns("dFechaSolicitud").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaCancelacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdReferencia.Splits(0).DisplayColumns("nMontoObtenido").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("nPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("sTipoPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaSolicitud").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaCancelacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center








        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    '--Fin Cargar Referencia Crediticia

    Private Sub tbReferencia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferencia.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRC"
                LlamaAgregarRC()
            Case "toolModificarRC"
                LlamaModificarRC()
            Case "toolEliminarRC"
                LlamaEliminarRC()
            Case "toolRefrescarRC"
                CargarReferencia()
            Case "toolAyudaRC"
                LlamaAyuda()
        End Select
    End Sub




    Private Sub LlamaAgregarRC()
        Dim ObjFrmSclEditReferenciaFiador As New frmSclEditReferenciaFiador
        Try
            ObjFrmSclEditReferenciaFiador.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaFiador.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaFiador.intReferenciaCrediticiaID = intFiadorGarantiaFiduciariaID

            ObjFrmSclEditReferenciaFiador.strColor = "RojoLight"
            ObjFrmSclEditReferenciaFiador.ShowDialog()

            If ObjFrmSclEditReferenciaFiador.intReferenciaCrediticiaFiadorID <> 0 Then
                CargarReferencia()
                XdsDetalle("Referencia").SetCurrentByID("nSclReferenciaCrediticiaID", ObjFrmSclEditReferenciaFiador.intReferenciaCrediticiaFiadorID)
                Me.grdReferencia.Row = XdsDetalle("Referencia").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaFiador.Close()
            ObjFrmSclEditReferenciaFiador = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRC()
        Dim ObjFrmSclEditReferenciaFiador As New frmSclEditReferenciaFiador
        Try
            If Me.grdReferencia.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditReferenciaFiador.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaFiador.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaFiador.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaFiador.intReferenciaCrediticiaFiadorID = XdsDetalle("Referencia").ValueField("nSclReferenciaCrediticiaID")
            'ObjFrmSclEditReferenciaBancaria.intPersonalID = XdsDetalle("ReferenciaBancaria").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaFiador.strColor = "RojoLight"
            ObjFrmSclEditReferenciaFiador.ShowDialog()

            CargarReferencia()
            XdsDetalle("Referencia").SetCurrentByID("nSclReferenciaCrediticiaID", ObjFrmSclEditReferenciaFiador.intReferenciaCrediticiaFiadorID)
            Me.grdReferencia.Row = XdsDetalle("Referencia").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaFiador.Close()
            ObjFrmSclEditReferenciaFiador = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRC()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferencia.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaCrediticiaFiador where nSclReferenciaCrediticiaFiadorID=" & XdsDetalle("Referencia").ValueField("nSclReferenciaCrediticiaID"))
                CargarReferencia()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferencia.Caption = "Listado de Referencias Crediticias (" + Me.grdReferenciaBancaria.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub










End Class