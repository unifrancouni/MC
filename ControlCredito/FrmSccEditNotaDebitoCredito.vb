'COMENTARIO
Public Class FrmSccEditNotaDebitoCredito
    Dim ModoForm As String 'ADD/MOD
    Dim IdSccNota As Long
    Dim IntHabilitar As Integer
    Dim nSclFichaDetalleId As Long
    Dim nSccSolicitudChequeId As Long
    Dim FichaFuenteId As Long
    Dim FichaDelegacionId As Long
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim IntAnioActual As Integer


    '-- Clases para procesar la informacion de los combos
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDelegacion As BOSistema.Win.XDataSet.xDataTable
    Dim XdtGrupo As BOSistema.Win.XDataSet.xDataTable
    Dim XdtGrupoS As BOSistema.Win.XDataSet.xDataTable
    Dim XdtFichas As BOSistema.Win.XDataSet.xDataTable

    Dim XdtCreditosSeleccion As BOSistema.Win.XDataSet.xDataTable

    Dim sColor As String
    Dim XMaximoGrupos As Integer
    'Color a mostrarse en el formulario
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property


    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdNota() As Long
        Get
            IdNota = IdSccNota
        End Get
        Set(ByVal value As Long)
            IdSccNota = value
        End Set
    End Property

    'Propiedad utilizada para habilitar o no Controles.
    Public Property IntHabilito() As Integer
        Get
            IntHabilito = IntHabilitar
        End Get
        Set(ByVal value As Integer)
            IntHabilitar = value
        End Set
    End Property
    Private Sub LimpiarNotasDetalleFichas()
        Try
            mtbNumCedula.Text = ""
            txtNombreSocia.Text = ""
            txtCodigoFNC.Text = ""
            txtCodigoGrupo.Text = ""
            mtbNumeroSesion.Text = ""
            TxtNombreGrupo.Text = ""
            txtnSclFichaDetalle.Text = ""
            Me.nSccSolicitudChequeId = 0
            Me.cneMontoFicha.Value = 0


        Catch ex As Exception

        End Try
    End Sub
    Private Sub PresentarNotasDetalleFichas()
        Try
            LimpiarNotasDetalleFichas()

            If Me.grdDetalles.RowCount = 0 Then
                Exit Sub
            End If

            ' XdtSocia.ExecuteSql("SELECT   nStbDelegacionProgramaID, sNumeroCedula, nSclFichaNotificacionDetalleID, nCodigo, CodigoGS, sNombreGS, sNumSesion, NombreSocia,nSccSolicitudChequeID,nScnFuenteFinanciamientoID ,nCodigoSolicitudCheque FROM dbo.vwSccFichaNotificacionCreditoDetalle WHERE     (nSccSolicitudChequeID= " & nSccSolicitudCheque & ")")
            mtbNumCedula.Text = Me.XdtFichas.ValueField("sNumeroCedula")
            txtNombreSocia.Text = Me.XdtFichas.ValueField("Socia")
            txtCodigoFNC.Text = Me.XdtFichas.ValueField("nCodigoFNC")
            txtCodigoGrupo.Text = Me.XdtFichas.ValueField("CodGrupo")
            mtbNumeroSesion.Text = Me.XdtFichas.ValueField("sNumSesion")
            TxtNombreGrupo.Text = Me.XdtFichas.ValueField("NombreGrupo")
            nSclFichaDetalleId = Me.XdtFichas.ValueField("nSccNotaDetalleFichaID")

            Me.txtnSclFichaDetalle.Text = Me.XdtFichas.ValueField("nSccNotaDetalleFichaID")
            '  XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", XdtSocia.ValueField("nScnFuenteFinanciamientoID"))
            ' Me.XdtDelegacion.SetCurrentByID("nStbDelegacionProgramaID ", XdtSocia.ValueField("nStbDelegacionProgramaID"))
            'FichaFuenteId = XdtSocia.ValueField("nScnFuenteFinanciamientoID")
            'FichaDelegacionId = XdtSocia.ValueField("nStbDelegacionProgramaID")
            Me.nSccSolicitudChequeId = Me.XdtFichas.ValueField("nSccSolicitudChequeId")
            Me.cneMontoFicha.Value = Me.XdtFichas.ValueField("nMontoFicha")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CargarDatosFichaDetalle(ByVal nSccSolicitudCheque As Long)
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try
            XdtSocia.ExecuteSql("SELECT   nStbDelegacionProgramaID, sNumeroCedula, nSclFichaNotificacionDetalleID, nCodigo, CodigoGS, sNombreGS, sNumSesion, NombreSocia,nSccSolicitudChequeID,nScnFuenteFinanciamientoID ,nCodigoSolicitudCheque FROM dbo.vwSccFichaNotificacionCreditoDetalle WHERE     (nSccSolicitudChequeID= " & nSccSolicitudCheque & ")")
            mtbNumCedula.Text = XdtSocia.ValueField("sNumeroCedula")
            txtNombreSocia.Text = XdtSocia.ValueField("NombreSocia")
            txtCodigoFNC.Text = XdtSocia.ValueField("nCodigo")
            txtCodigoGrupo.Text = XdtSocia.ValueField("CodigoGS")
            mtbNumeroSesion.Text = XdtSocia.ValueField("sNumSesion")
            TxtNombreGrupo.Text = XdtSocia.ValueField("sNombreGS")
            nSclFichaDetalleId = XdtSocia.ValueField("nSclFichaNotificacionDetalleID")

            Me.txtnSclFichaDetalle.Text = XdtSocia.ValueField("nSclFichaNotificacionDetalleID")
            '  XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", XdtSocia.ValueField("nScnFuenteFinanciamientoID"))
            ' Me.XdtDelegacion.SetCurrentByID("nStbDelegacionProgramaID ", XdtSocia.ValueField("nStbDelegacionProgramaID"))
            FichaFuenteId = XdtSocia.ValueField("nScnFuenteFinanciamientoID")
            FichaDelegacionId = XdtSocia.ValueField("nStbDelegacionProgramaID")
        Catch ex As Exception
            XdtSocia.Close()
            XdtSocia = Nothing
        End Try
    End Sub
    Private Sub EncuentraParametrosD()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub
    Private Sub CargarDatosNota(ByVal nSccNotaID As Long)
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try
            XdtSocia.ExecuteSql("SELECT  nSccNotaID, nCodigo, sConceptoNota, nMonto, nScnFuenteFinanciamientoID ,nStbDelegacionProgramaID,nEsDebito FROM dbo.SccNotaCreditoDebito WHERE     (nSccNotaID= " & nSccNotaID & ")")
            mtbNumCedula.Text = XdtSocia.ValueField("sNumeroCedula")
            txtNombreSocia.Text = XdtSocia.ValueField("NombreSocia")
            txtCodigoFNC.Text = XdtSocia.ValueField("nCodigo")
            txtCodigoGrupo.Text = XdtSocia.ValueField("CodigoGS")
            mtbNumeroSesion.Text = XdtSocia.ValueField("sNumSesion")
            TxtNombreGrupo.Text = XdtSocia.ValueField("sNombreGS")
            nSclFichaDetalleId = XdtSocia.ValueField("nSclFichaNotificacionDetalleID")
            Me.cneMonto.Value = XdtSocia.ValueField("nMonto")
            Me.txtnSclFichaDetalle.Text = XdtSocia.ValueField("nSclFichaNotificacionDetalleID")
            XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", XdtSocia.ValueField("nScnFuenteFinanciamientoID"))
            Me.XdtDelegacion.SetCurrentByID("nStbDelegacionProgramaID ", XdtSocia.ValueField("nStbDelegacionProgramaID"))

        Catch ex As Exception
            XdtSocia.Close()
            XdtSocia = Nothing
        End Try
    End Sub
    Private Sub Buscar()
        Dim ObjFrmSclEditSCK As New frmSccBusquedaFichasDetalles
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        'Dim StrSql As String

        Try
            ObjFrmSclEditSCK.StbDelegacionId = Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID")
            ObjFrmSclEditSCK.StbFuenteId = Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID")
            ObjFrmSclEditSCK.ShowDialog()

            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCK.nSccSolicitudCheque <> 0 Then


                nSccSolicitudChequeId = ObjFrmSclEditSCK.nSccSolicitudCheque

                CargarDatosFichaDetalle(nSccSolicitudChequeId)

                XdtSocia.ExecuteSql("Exec spSccObtenerSaldoCredito " & nSclFichaDetalleId)
                cneMontoFicha.Value = XdtSocia.ValueField("SaldoCredito")


            End If



        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSCK.Close()
            ObjFrmSclEditSCK = Nothing

        End Try
    End Sub

    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Nota de Debito Credito"
            Else
                Me.Text = "Modificar Nota de Debito Credito"
            End If

            XdtFuenteFondos = New BOSistema.Win.XDataSet.xDataTable

            XdtDelegacion = New BOSistema.Win.XDataSet.xDataTable
            XdtFichas = New BOSistema.Win.XDataSet.xDataTable

            XdtGrupo = New BOSistema.Win.XDataSet.xDataTable
            XdtGrupoS = New BOSistema.Win.XDataSet.xDataTable
            XdtCreditosSeleccion = New BOSistema.Win.XDataSet.xDataTable
            'Limpiar los combos:
            Me.cboFuente.ClearFields()


            If ModoFrm = "ADD" Then
                'ObjSolicituddr = ObjSolicituddt.NewRow
                ''Inicializar los Length de los campos (Strings?)
                'Me.txtConcepto.MaxLength = ObjSolicituddr.GetColumnLenght("sConceptoPago")
                'Me.txtObservaciones.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarFichas()
        Dim StrSql As String
        StrSql = "SELECT     nCodigo,nMontoFicha, nMonto, Socia,sNumeroCedula, CodGrupo, NombreGrupo, sNumSesion, dFechaPago, nSccNotaID ,nCodigoFNC,                       nSccNotaDetalleFichaID FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  WHERE     (nSccNotaID = " & IdSccNota & ")"

        Me.XdtFichas.ExecuteSql(StrSql)
        Me.grdDetalles.DataSource = XdtFichas.Source
        If Me.grdDetalles.RowCount > 0 Then
            'Me.chkEsDebito.Enabled = False
            'Me.cboFuente.Enabled = False
            'Me.cboDelegacion.Enabled = False
        Else
            'Me.chkEsDebito.Enabled = True
            ' Me.cboFuente.Enabled = True
            'Me.cboDelegacion.Enabled = True
        End If
        grdDetalles.Splits(0).DisplayColumns("nSccNotaDetalleFichaID").Visible = False
        grdDetalles.Splits(0).DisplayColumns("sNumSesion").Visible = False
        grdDetalles.Splits(0).DisplayColumns("nMonto").Visible = False
        grdDetalles.Splits(0).DisplayColumns("nSccNotaID").Visible = False
        grdDetalles.Splits(0).DisplayColumns("nCodigo").Visible = False
        'grdDetalles.Splits(0).DisplayColumns("dFechaPago").Visible = False
        grdDetalles.Splits(0).DisplayColumns("nCodigo").Width = 80
        grdDetalles.Splits(0).DisplayColumns("nMontoFicha").Width = 60
        grdDetalles.Splits(0).DisplayColumns("Socia").Width = 150
        grdDetalles.Splits(0).DisplayColumns("CodGrupo").Width = 80
        grdDetalles.Splits(0).DisplayColumns("NombreGrupo").Width = 150
        grdDetalles.Splits(0).DisplayColumns("sNumeroCedula").Width = 120
        grdDetalles.Splits(0).DisplayColumns("sNumSesion").Width = 100
        grdDetalles.Splits(0).DisplayColumns("dFechaPago").Width = 100
        grdDetalles.Splits(0).DisplayColumns("nCodigoFNC").Width = 80
        grdDetalles.Splits(0).DisplayColumns("nSccNotaDetalleFichaID").Width = 80
        Me.grdDetalles.Columns("CodGrupo").Caption = "Codigo Grupo"
        Me.grdDetalles.Columns("nSccNotaID").Caption = "Nota Id"
        Me.grdDetalles.Columns("nCodigo").Caption = "Nota No"
        Me.grdDetalles.Columns("nMontoFicha").Caption = "Monto C$"
        Me.grdDetalles.Columns("Socia").Caption = "Nombre Socia"
        Me.grdDetalles.Columns("CodGrupo").Caption = ""
        Me.grdDetalles.Columns("NombreGrupo").Caption = "Nombre Grupo"
        Me.grdDetalles.Columns("sNumeroCedula").Caption = "Cedula"
        Me.grdDetalles.Columns("sNumSesion").Caption = "Sesion"
        Me.grdDetalles.Columns("dFechaPago").Caption = "Fecha Ult. Pago"
        Me.grdDetalles.Columns("nCodigoFNC").Caption = "Ficha No"
        Me.grdDetalles.Columns("nSccNotaDetalleFichaID").Caption = "Detalle Ficha"
        Me.grdDetalles.Columns("nMonto").NumberFormat = "#,##0.00"
        Me.grdDetalles.Caption = " Listado de Creditos (" + Me.grdDetalles.RowCount.ToString + " registros)"
    End Sub

    Private Sub CalcularSaldos()
        Try
            Dim vTotal As Double = 0


            For index As Integer = 0 To Me.grdSeleccion.RowCount - 1
                '' Solo las socias seleccionadas
                Me.grdSeleccion.Row = index
                If Convert.ToBoolean(Me.grdSeleccion.DataSource.DataSource.Rows(index).ItemArray(2)) = True Then
                    vTotal = vTotal + Me.grdSeleccion.Columns("nSaldo").Value
                End If
            Next
            If Me.grdSeleccion.RowCount > 0 Then
                Me.grdSeleccion.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdSeleccion.Columns("nSaldo").FooterText = Format(vTotal, "C$ #,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarCreditosGrupo(ByVal Grupoid As Long, ByVal FuenteId As Integer, ByVal DelegacionId As Integer)
        Dim StrSql As String
        Dim ContadorColumna As Integer
        StrSql = "Exec spSccListaNotaFichasSeleccionar " & Grupoid & "," & FuenteId & "," & DelegacionId & "," & IIf(Me.chkEsDebito.Checked, 1, 0)




        Me.XdtCreditosSeleccion.ExecuteSql(StrSql)

        Me.grdSeleccion.DataSource = XdtCreditosSeleccion.Source
        Me.grdSeleccion.Rebind(False)

        grdSeleccion.Splits(0).DisplayColumns("nSeleccionado").Locked = True
        grdSeleccion.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
        grdSeleccion.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
        'grdSeleccion.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
        grdSeleccion.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
        grdSeleccion.Splits(0).DisplayColumns("nSclSociaID").Visible = False
        grdSeleccion.Splits(0).DisplayColumns("nEsDebito").Visible = False


        grdSeleccion.Splits(0).DisplayColumns("nSclFichaNotificacionID").Width = 80
        grdSeleccion.Splits(0).DisplayColumns("NombreSocia").Width = 200
        grdSeleccion.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
        grdSeleccion.Splits(0).DisplayColumns("nSaldo").Width = 80
        grdSeleccion.Splits(0).DisplayColumns("nSeleccionado").Width = 80
        grdSeleccion.Splits(0).DisplayColumns("FechaPagoUltimo").Width = 80

        grdSeleccion.Columns("nSclFichaNotificacionDetalleID").Caption = "Ficha Id Detalle"
        grdSeleccion.Columns("NombreSocia").Caption = "Nombre Socia"
        grdSeleccion.Columns("sNumeroCedula").Caption = "Numero Cedula"
        grdSeleccion.Columns("nSaldo").Caption = "Saldo"
        grdSeleccion.Columns("nSeleccionado").Caption = "Seleccionar"
        grdSeleccion.Columns("FechaPagoUltimo").Caption = "Ultimo Pago"

        grdSeleccion.Columns("nSaldo").NumberFormat = "#,##0.00"

        grdSeleccion.Columns("nSeleccionado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox


        For ContadorColumna = 0 To Me.grdSeleccion.Splits(0).DisplayColumns.Count - 1
            Me.grdSeleccion.Splits(0).DisplayColumns(ContadorColumna).Locked = True
        Next

        Me.grdSeleccion.Splits(0).DisplayColumns("nSeleccionado").Locked = False
        Me.grdSeleccion.Caption = " Listado  de Creditos  Cancelados Elegibles para " & IIf(Me.chkEsDebito.Checked, "Nota de Debito", "Nota de Credito") & " (" + Me.grdSeleccion.RowCount.ToString + " registros)"
        Me.CalcularSaldos()
    End Sub
    Private Sub CargarFuenteFondos(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " &
                         " From ScnFuenteFinanciamiento a " &
                         " Where (a.nActiva = 1) " &
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " &
                         " From ScnFuenteFinanciamiento a " &
                         " Where (a.nActiva = 1) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " &
                         " Order by a.sCodigo"
            End If

            XdtFuenteFondos.ExecuteSql(Strsql)
            Me.cboFuente.DataSource = XdtFuenteFondos.Source

            Me.cboFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Width = 47
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboFuente.Columns("sCodigo").Caption = "Código"
            Me.cboFuente.Columns("sNombre").Caption = "Descripción"

            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            If intFuenteID <> 0 Then
                Me.cboFuente.SelectedValue = intFuenteID
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarGrupos(ByVal intDelegacionID As Integer, ByVal intFuenteId As Integer)
        Try
            Dim Strsql As String = ""



            Strsql = "SELECT     nSclGrupoSolidarioID, NombreGrupo, CodGrupo,dFechaNotificacion,nScnFuenteFinanciamientoID, nStbDelegacionProgramaID  FROM         dbo.VwSccNotaDebitoGruposListar WHERE     (nScnFuenteFinanciamientoID = " & intFuenteId & ") AND (nStbDelegacionProgramaID = " & intDelegacionID & ") Order by nSclGrupoSolidarioID"

            XdtGrupo.ExecuteSql(Strsql)
            Me.cboGrupo.DataSource = XdtGrupo.Source

            Me.cboGrupo.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("dFechaNotificacion").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboGrupo.Splits(0).DisplayColumns("NombreGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboGrupo.Splits(0).DisplayColumns("CodGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            'Configurar el combo
            Me.cboGrupo.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Width = 50
            Me.cboGrupo.Splits(0).DisplayColumns("NombreGrupo").Width = 200
            Me.cboGrupo.Splits(0).DisplayColumns("CodGrupo").Width = 100


            Me.cboGrupo.Columns("nSclGrupoSolidarioID").Caption = "Id "
            Me.cboGrupo.Columns("NombreGrupo").Caption = "Nombre"
            Me.cboGrupo.Columns("CodGrupo").Caption = "Codigo"

            Me.cboGrupo.Splits(0).DisplayColumns("nSclGrupoSolidarioID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupo.Splits(0).DisplayColumns("NombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupo.Splits(0).DisplayColumns("CodGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarGruposporFuentes(ByVal intFuenteId As Integer)
        Try
            Dim Strsql As String = ""

            Dim CadWhere As String = ""
            'Si Usuario unicamente puede Consultar Fichas de su Delegación:
            If Me.IntPermiteConsultar <> 1 Then

                CadWhere = " And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            End If


            Strsql = "SELECT     nSclGrupoSolidarioID, NombreGrupo, CodGrupo,dFechaNotificacion,nScnFuenteFinanciamientoID, nStbDelegacionProgramaID  FROM         dbo.VwSccNotaDebitoGruposListar WHERE     (nScnFuenteFinanciamientoID = " & intFuenteId & ") " & Trim(CadWhere) & " Order by nSclGrupoSolidarioID"

            XdtGrupoS.ExecuteSql(Strsql)
            Me.cboGrupoS.DataSource = XdtGrupoS.Source

            Me.cboGrupoS.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.cboGrupoS.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboGrupoS.Splits(0).DisplayColumns("dFechaNotificacion").Visible = False
            Me.cboGrupoS.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboGrupoS.Splits(0).DisplayColumns("NombreGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboGrupoS.Splits(0).DisplayColumns("CodGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            'Configurar el combo
            Me.cboGrupoS.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Width = 50
            Me.cboGrupoS.Splits(0).DisplayColumns("NombreGrupo").Width = 200
            Me.cboGrupoS.Splits(0).DisplayColumns("CodGrupo").Width = 100


            Me.cboGrupoS.Columns("nSclGrupoSolidarioID").Caption = "Id "
            Me.cboGrupoS.Columns("NombreGrupo").Caption = "Nombre"
            Me.cboGrupoS.Columns("CodGrupo").Caption = "Codigo"

            Me.cboGrupoS.Splits(0).DisplayColumns("nSclGrupoSolidarioID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupoS.Splits(0).DisplayColumns("NombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupoS.Splits(0).DisplayColumns("CodGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CargarDelegacion(ByVal intDelegacionID As Integer)
        Try
            Dim Strsql As String = ""

            If intDelegacionID = 0 Then
                Strsql = "SELECT     nStbDelegacionProgramaID, nCodigo, sNombreDelegacion, nActiva  FROM         dbo.StbDelegacionPrograma Where nActiva=1 Order By nCodigo"

            Else

                Strsql = "SELECT     nStbDelegacionProgramaID, nCodigo, sNombreDelegacion, nActiva  FROM         dbo.StbDelegacionPrograma Where nActiva=1  or  nStbDelegacionProgramaID=" & intDelegacionID & " Order By nCodigo"
            End If

            XdtDelegacion.ExecuteSql(Strsql)
            Me.cboDelegacion.DataSource = XdtDelegacion.Source

            Me.cboDelegacion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.cboDelegacion.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").Width = 47
            Me.cboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").Width = 100

            Me.cboDelegacion.Columns("nCodigo").Caption = "Código"
            Me.cboDelegacion.Columns("sNombreDelegacion").Caption = "Nombre"

            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                CargarGrupos(Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"), XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"))
                SalvarNota()
                AccionUsuario = AccionBoton.BotonAceptar
                grpDatosGenerales.Enabled = False
                grpDatosFicha.Enabled = True
                ' cmdModificar.Enabled = True





                'Me.ModoFrm = "UPD"
                '  Me.Close()

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidaDatosEntrada() As Boolean
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable

        'Dim XMonto As Double
        Try

            ValidaDatosEntrada = True
            Me.errSolicitud.Clear()
            Dim strSQL As String



            'strSQL = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SccSolicitudCheque.nSccSolicitudChequeID FROM         dbo.SclFichaNotificacionDetalle INNER JOIN                    dbo.SclFichaNotificacionCredito ON " & _
            '         " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
            '         " dbo.SccSolicitudDesembolsoCredito ON " & _
            '         " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " & _
            '         " dbo.SccSolicitudCheque ON  " & _
            '         " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
            '         " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
            '         " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
            '        " WHERE(dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & " )"
            'XdtSocia.ExecuteSql(strSQL)
            'If XdtSocia.ValueField("sCodigoInterno") <> "7" Then
            '    MsgBox("Ese Credito no se encuentra en estado cancelado.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitud.SetError(Me.cmdBuscar, "Ese Credito no se encuentra en estado cancelado.")
            '    Me.cmdBuscar.Focus()
            '    Exit Function
            'End If

            'strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebito WHERE     (sCodigoInterno <> '5') AND (nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & ") AND (nSccNotaID<>" & Me.IdNota & " )"
            'XdtSocia.ExecuteSql(strSQL)
            'If XdtSocia.Count > 0 Then
            '    MsgBox("Ya existe una nota ingresada para este credito.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitud.SetError(Me.cmdBuscar, "Ya existe una nota ingresada para este credito.")
            '    Me.cmdBuscar.Focus()
            '    Exit Function
            'End If
            'Ver el monto si es positivo ver en parametro lo maximo permitido
            'If Me.cneMonto.Value > 0 Then
            '    strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Monto Maximo Nota de Credito')"
            '    XdtSocia.ExecuteSql(strSQL)
            '    If XdtSocia.Count = 0 Then
            '        MsgBox("No existe configuracion de parametro para el maximo de cordobas permitidos del parametro 'Monto Maximo Nota de Credito' Cuando es monto positivo.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSolicitud.SetError(Me.cmdBuscar, "No existe configuracion de parametro para el maximo de cordobas permitidos del parametro 'Monto Maximo Nota de Credito' Cuando es monto positivo.")
            '        Me.cmdBuscar.Focus()
            '        Exit Function
            '    End If

            '    If Me.cneMonto.Value > CDbl(XdtSocia.ValueField("sValorParametro")) Then
            '        MsgBox("Solo se permite 'Monto Maximo Nota de Credito' " & XdtSocia.ValueField("sValorParametro") & " C$", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSolicitud.SetError(Me.cmdBuscar, "Solo se permite 'Monto Maximo Nota de Credito' '" & XdtSocia.ValueField("sValorParametro") & "' C$")
            '        Me.cmdBuscar.Focus()
            '        Exit Function
            '    End If
            'End If
            'Fecha de Solicitud:
            If Me.cdeFechaS.ValueIsDbNull Then
                MsgBox("La Fecha de la Nota  NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaS, "La Fecha de la Nota  NO DEBE quedar vacía.")
                Me.cdeFechaS.Focus()
                Exit Function
            End If

            'Fecha de T.C.:
            If Me.cdeFechaTC.ValueIsDbNull Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fechas de Solicitud y TC deben ser de un Mes Contable Abierto:
            If PeriodoAbiertoDadaFecha(Me.cdeFechaS.Value) = False Then
                MsgBox("La Fecha de Nota corresponde a un mes Contable Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaS, "Fecha de Nota Inválida.")
                Me.cdeFechaS.Focus()
                Exit Function
            End If
            If PeriodoAbiertoDadaFecha(Me.cdeFechaTC.Value) = False Then
                MsgBox("La Fecha del T.C. corresponde a un mes Contable Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaTC, "Fecha de Tipo de Cambio Inválida.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Solicitud no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaS.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Nota NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaS, "La Fecha de Nota NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaS.Focus()
                Exit Function
            End If

            'Fecha de Solicitud no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaS.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Nota NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaS, "La Fecha de Nota NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaS.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If







            If Me.ModoFrm = "UPD" Then


                'strSQL = "SELECT     nSccNotaID                 FROM dbo.SccNotaCreditoDebitoDetalleFichas Where  nSccNotaID=" & Me.IdNota & _
                '" And (CONVERT(DATETIME, '" & Format(Me.cdeFechaS.Value, "yyyy-MM-dd") & "')>dFechaPago  )"


                strSQL = "SELECT     nSccNotaID                 FROM dbo.SccNotaCreditoDebitoDetalleFichas Where  nSccNotaID=" & Me.IdNota &
                " And  CONVERT(varchar(10), '" & Format(Me.cdeFechaS.Value, "yyyy-MM-dd") & "', 112) <CONVERT(varchar(10), dFechaPago, 112)  "

                'AND (CONVERT(varchar(10), dbo.SccTablaAmortizacion.dFechaPago, 112) 
                '																			  < CONVERT(varchar(10), @FechaFinal, 112))
                XdtSocia.ExecuteSql(strSQL)
                If XdtSocia.Count > 0 Then
                    MsgBox("Esa fecha de Nota es menor que una de las ultimas fechas de pago de uno de los creditos.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cdeFechaS, "Esa fecha de Nota es menor que una de las ultimas fechas de pago de uno de los creditos.")
                    Me.cdeFechaS.Focus()
                    Exit Function
                End If


            End If

            'Fecha de Solicitud < Fecha TC:
            If Me.cdeFechaS.Value > Me.cdeFechaTC.Value Then
                MsgBox("La Fecha de Nota NO DEBE ser mayor a la de Tipo de Cambio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaS, "La Fecha de Nota NO DEBE ser mayor a la de Tipo de Cambio.")
                Me.cdeFechaS.Focus()
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha TC:
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaTC, "No existe una Tasa de Cambio para la Fecha.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento:
            If Me.cboDelegacion.SelectedIndex = -1 Then
                MsgBox("Debe indicar Delegacion.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cboFuente, "Debe indicar Delegacion.")
                Me.cboFuente.Focus()
                Exit Function
            End If

            'Concepto:
            If Trim(Me.txtConcepto.Text) = "" Then
                MsgBox("Debe indicar el Concepto.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.txtConcepto, "Debe indicar el Concepto.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

            If Me.ModoFrm = "ADD" Then
                If Me.cboGrupoS.SelectedIndex = -1 Then
                    MsgBox("Debe Seleccionar un grupo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cboGrupoS, "Debe Seleccionar un grupo.")
                    Me.cboGrupoS.Focus()
                    Exit Function
                End If


                CargarCreditosGrupo(Me.XdtGrupoS.ValueField("nSclGrupoSolidarioID"), Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"), Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"))

                If grdSeleccion.RowCount = 0 Then

                    MsgBox("El Grupo que selecciono no tiene ninguna ficha en condicion de " & IIf(Me.chkEsDebito.Checked, "Nota de Debito.", "Nota de Credito."), MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cboGrupoS, "Debe Seleccionar un grupo.")
                    Me.cboGrupoS.Focus()
                    Exit Function
                End If
            End If
            HabilitarG(True)


            ''Imposible si no se indicó un Monto Válido:
            'If Not IsNumeric(cneMonto.Value) Then
            '    MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitud.SetError(Me.cneMonto, "Monto Inválido.")
            '    Me.cneMonto.Focus()
            '    Exit Function
            'End If
            'If CDbl(cneMonto.Value) = 0 Then
            '    MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitud.SetError(Me.cneMonto, "Monto Inválido.")
            '    Me.cneMonto.Focus()
            '    Exit Function
            'End If


            'XdtSocia.ExecuteSql("Exec spSccObtenerSaldoCredito " & nSclFichaDetalleId)
            'XMonto = XdtSocia.ValueField("SaldoCredito")
            'If CDbl(cneMonto.Value) - XMonto <> 0 Then
            '    MsgBox("Monto Inválido de Acuerdo al Saldo del Credito.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitud.SetError(Me.cneMonto, "Monto Inválido de Acuerdo al Saldo del Credito.")
            '    Me.cneMonto.Focus()
            '    Exit Function
            'End If





        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    Private Function ValidaDatosEntradaFicha() As Boolean
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable

        Dim XMonto As Double
        Dim XMaximoGrupos As Integer
        Dim XSclFichaNotificacionCredito As Long
        Try

            ValidaDatosEntradaFicha = True
            Me.errSolicitud.Clear()
            Dim strSQL As String

            'Solicitud de Cheque asociada a la nota:
            If Me.nSccSolicitudChequeId = 0 Then
                MsgBox("Debe seleccionar el credito al cual se aplica la nota.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "Debe seleccionar el credito al cual se aplica la nota.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If


            strSQL = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SccSolicitudCheque.nSccSolicitudChequeID,dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID,dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID,dbo.SccSolicitudCheque.nStbDelegacionProgramaID      FROM         dbo.SclFichaNotificacionDetalle INNER JOIN                    dbo.SclFichaNotificacionCredito ON " &
                     " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " &
                     " dbo.SccSolicitudDesembolsoCredito ON " &
                     " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " &
                     " dbo.SccSolicitudCheque ON  " &
                     " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " &
                     " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " &
                     " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
                    " WHERE(dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & " )"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.ValueField("sCodigoInterno") <> "7" Then
                MsgBox("Ese Credito no se encuentra en estado cancelado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "Ese Credito no se encuentra en estado cancelado.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If
            'Validar Misma Fuente
            If XdtSocia.ValueField("nScnFuenteFinanciamientoID") <> Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID") Then
                MsgBox("Ese Credito Tiene una Fuente Financiera Diferente a la de la Nota.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "Ese Credito Tiene una Fuente Financiera Diferente a la de la Nota.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If
            'Validar Misma delegacion
            If XdtSocia.ValueField("nStbDelegacionProgramaID") <> Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID") Then
                MsgBox("Ese Credito Tiene una Delegacion Diferente a la de la Nota.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "Ese Credito Tiene una Delegacion Diferente a la de la Nota.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If


            XSclFichaNotificacionCredito = XdtSocia.ValueField("nSclFichaNotificacionID")
            'Validar el numero de grupos permitidos por nota

            'Obtener el maximo de grupos por nota
            XMaximoGrupos = 1 'Por defecto maximo numero de grupos permitido en la nota
            strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Numero Maximo Grupos Nota de Credito')"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                XMaximoGrupos = CInt(XdtSocia.ValueField("sValorParametro"))
            End If

            strSQL = "SELECT     nSccNotaID, nSclFichaNotificacionID  FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas WHERE     (nSccNotaID = " & Me.IdNota & ") AND (nSclFichaNotificacionID <> " & XSclFichaNotificacionCredito & ") Group By nSccNotaID, nSclFichaNotificacionID  "

            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                If XdtSocia.Count + 1 > XMaximoGrupos Then
                    MsgBox("En esta nota ya se ha alcanzado el maximo de grupos." & XMaximoGrupos.ToString(), MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFicha = False
                    Me.errSolicitud.SetError(Me.cmdBuscar, "En esta nota ya se ha alcanzado el maximo de grupos." & XMaximoGrupos.ToString())
                    Me.cmdBuscar.Focus()
                    Exit Function
                End If
            End If

            strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  a WHERE      (nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & ") AND (nSccNotaID=" & Me.IdNota & " )"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                MsgBox("En esta nota ya esta ingresado este credito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "En esta nota ya esta ingresado este credito.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If
            'strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  a WHERE    (sCodigoInterno <> '5') And  (nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & ") AND (nSccNotaID<>" & Me.IdNota & " )"
            strSQL = "SELECT     dbo.SccSolicitudCheque.nSccSolicitudChequeID " &
" FROM         dbo.SclFichaNotificacionDetalle INNER JOIN " &
  "                    dbo.SccSolicitudDesembolsoCredito ON " &
  "                    dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " &
  "                    dbo.SccSolicitudCheque ON  " &
  "                    dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " &
  "                    dbo.SccTablaAmortizacion ON " &
   "                   dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID INNER JOIN " &
    "                  dbo.StbValorCatalogo ON dbo.SccTablaAmortizacion.nStbEstadoPagoID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
" WHERE     (dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '1')"

            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                MsgBox("Ese Credito no ha cancelado todas sus cuotas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "Ese Credito no ha cancelado todas sus cuotas")
                Me.cmdBuscar.Focus()
                Exit Function
            End If

            strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  a WHERE    (sCodigoInterno <> '5') And  (nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & ") AND (nSccNotaID<>" & Me.IdNota & " )"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                MsgBox("Ese Credito ya esta ingresado en otra Nota Activa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "Ese Credito ya esta ingresado en otra Nota Activa.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If

            'Fecha valida del ultimo pago debe ser menor o igual a la fecha de la nota.

            strSQL = "	SELECT     MAX(dbo.SccReciboOficialCaja.dFechaRecibo) as FechaPagoUltimo " &
   " FROM         dbo.SccReciboOficialCaja INNER JOIN " &
 "							  dbo.StbValorCatalogo ON dbo.SccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
 "		WHERE     (dbo.StbValorCatalogo.sCodigoInterno <> '3') AND (dbo.SccReciboOficialCaja.nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & " )"

            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count = 0 Then
                MsgBox("No se ha hecho ni un solo pago de cuota.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "No se ha hecho ni un solo pago de cuota.")
                Me.cmdBuscar.Focus()
                Exit Function
            End If






            If XdtSocia.ValueField("FechaPagoUltimo") > Me.cdeFechaS.Value Then
                MsgBox("La fecha del ultimo pago es mayor que la de la nota de debito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cmdBuscar, "La fecha del ultimo pago es mayor que la de la nota de debito")
                Me.cmdBuscar.Focus()
                Exit Function
            End If




            'Ver el monto si es positivo ver en parametro lo maximo permitido
            If Me.cneMontoFicha.Value > 0 Then
                strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Monto Maximo Nota de Credito')"
                XdtSocia.ExecuteSql(strSQL)
                If XdtSocia.Count = 0 Then
                    MsgBox("No existe configuracion de parametro para el maximo de cordobas permitidos del parametro 'Monto Maximo Nota de Credito' Cuando es monto positivo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFicha = False
                    Me.errSolicitud.SetError(Me.cmdBuscar, "No existe configuracion de parametro para el maximo de cordobas permitidos del parametro 'Monto Maximo Nota de Credito' Cuando es monto positivo.")
                    Me.cmdBuscar.Focus()
                    Exit Function
                End If

                If Me.cneMontoFicha.Value > CDbl(XdtSocia.ValueField("sValorParametro")) Then
                    MsgBox("Solo se permite 'Monto Maximo Nota de Credito' " & XdtSocia.ValueField("sValorParametro") & " C$", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFicha = False
                    Me.errSolicitud.SetError(Me.cmdBuscar, "Solo se permite 'Monto Maximo Nota de Credito' '" & XdtSocia.ValueField("sValorParametro") & "' C$")
                    Me.cmdBuscar.Focus()
                    Exit Function
                End If
            End If




            'Imposible si no se indicó un Monto Válido:
            If Not IsNumeric(cneMontoFicha.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cneMontoFicha, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If
            If CDbl(cneMontoFicha.Value) = 0 Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cneMontoFicha, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If



            XdtSocia.ExecuteSql("Exec spSccObtenerSaldoCredito " & nSclFichaDetalleId)
            XMonto = XdtSocia.ValueField("SaldoCredito")
            If XMonto >= 0 And Me.chkEsDebito.Checked Then
                MsgBox("Es Nota de Debito no se Permite Credito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cneMonto, "Es Nota de Debito no se Permite Credito.")
                Me.cneMonto.Focus()
                Exit Function
            Else
                If XMonto < 0 And Me.chkEsDebito.Checked = False Then
                    MsgBox("Es Nota de Credito no se Permite Debito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFicha = False
                    Me.errSolicitud.SetError(Me.cneMonto, "Es Nota de Debito no se Permite Credito.")
                    Me.cneMonto.Focus()
                    Exit Function
                End If
            End If
            If CDbl(cneMontoFicha.Value) - XMonto <> 0 Then
                MsgBox("Monto Inválido de Acuerdo al Saldo del Credito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFicha = False
                Me.errSolicitud.SetError(Me.cneMonto, "Monto Inválido de Acuerdo al Saldo del Credito.")
                Me.cneMonto.Focus()
                Exit Function
            End If
            ''Fuente de Financiamiento:
            'If Me.cboFuente.SelectedIndex = -1 Then
            '    MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaFicha = False
            '    Me.errSolicitud.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
            '    Me.cboFuente.Focus()
            '    Exit Function
            'End If




        Catch ex As Exception
            ValidaDatosEntradaFicha = False
            Control_Error(ex)
        End Try
    End Function

    Private Function ValidaDatosEntradaFichaPorGrupo(ByVal xnSccSolicitudChequeId As Long, ByVal xnSclFichaDetalleId As Long, ByVal xSaldo As Double, ByVal xNombre As String) As Boolean
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable

        Dim XMonto As Double
        Dim XMaximoGrupos As Integer
        Dim XSclFichaNotificacionCredito As Long
        Try

            ValidaDatosEntradaFichaPorGrupo = True
            Me.errSolicitud.Clear()
            Dim strSQL As String

            'Solicitud de Cheque asociada a la nota:
            If xnSccSolicitudChequeId = 0 Then
                MsgBox("Debe seleccionar el credito al cual se aplica la nota.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If


            strSQL = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SccSolicitudCheque.nSccSolicitudChequeID,dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID,dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID,dbo.SccSolicitudCheque.nStbDelegacionProgramaID      FROM         dbo.SclFichaNotificacionDetalle INNER JOIN                    dbo.SclFichaNotificacionCredito ON " &
                     " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " &
                     " dbo.SccSolicitudDesembolsoCredito ON " &
                     " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " &
                     " dbo.SccSolicitudCheque ON  " &
                     " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " &
                     " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " &
                     " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
                    " WHERE(dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & xnSccSolicitudChequeId & " )"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.ValueField("sCodigoInterno") <> "7" Then
                MsgBox("Ese Credito no se encuentra en estado cancelado. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If
            'Validar Misma Fuente
            'If XdtSocia.ValueField("nScnFuenteFinanciamientoID") <> Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID") Then
            '    MsgBox("Ese Credito Tiene una Fuente Financiera Diferente a la de la Nota. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaFichaPorGrupo = False
            '    Exit Function
            'End If
            'Validar Misma delegacion
            'If XdtSocia.ValueField("nStbDelegacionProgramaID") <> Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID") Then
            '    MsgBox("Ese Credito Tiene una Delegacion Diferente a la de la Nota. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaFichaPorGrupo = False
            '    Exit Function
            'End If


            XSclFichaNotificacionCredito = XdtSocia.ValueField("nSclFichaNotificacionID")
            'Validar el numero de grupos permitidos por nota

            'Obtener el maximo de grupos por nota
            XMaximoGrupos = 1 'Por defecto maximo numero de grupos permitido en la nota
            strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Numero Maximo Grupos Nota de Credito')"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                XMaximoGrupos = CInt(XdtSocia.ValueField("sValorParametro"))
            End If

            strSQL = "SELECT     nSccNotaID, nSclFichaNotificacionID  FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas WHERE     (nSccNotaID = " & Me.IdNota & ") AND (nSclFichaNotificacionID <> " & XSclFichaNotificacionCredito & ") Group By nSccNotaID, nSclFichaNotificacionID  "

            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                If XdtSocia.Count + 1 > XMaximoGrupos Then
                    MsgBox("En esta nota ya se ha alcanzado el maximo de grupos." & XMaximoGrupos.ToString() & ". Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFichaPorGrupo = False
                    Exit Function
                End If
            End If

            strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  a WHERE      (nSccSolicitudChequeID = " & xnSccSolicitudChequeId & ") AND (nSccNotaID=" & Me.IdNota & " )"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                MsgBox("En esta nota ya esta ingresado este credito. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If
            'strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  a WHERE    (sCodigoInterno <> '5') And  (nSccSolicitudChequeID = " & Me.nSccSolicitudChequeId & ") AND (nSccNotaID<>" & Me.IdNota & " )"
            strSQL = "SELECT     dbo.SccSolicitudCheque.nSccSolicitudChequeID " &
" FROM         dbo.SclFichaNotificacionDetalle INNER JOIN " &
  "                    dbo.SccSolicitudDesembolsoCredito ON " &
  "                    dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " &
  "                    dbo.SccSolicitudCheque ON  " &
  "                    dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " &
  "                    dbo.SccTablaAmortizacion ON " &
   "                   dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID INNER JOIN " &
    "                  dbo.StbValorCatalogo ON dbo.SccTablaAmortizacion.nStbEstadoPagoID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
" WHERE     (dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & xnSccSolicitudChequeId & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '1')"

            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                MsgBox("Ese Credito no ha cancelado todas sus cuotas. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If


            strSQL = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  a WHERE    (sCodigoInterno <> '5') And  (nSccSolicitudChequeID = " & xnSccSolicitudChequeId & ") AND (nSccNotaID<>" & Me.IdNota & " )" &
        " AND (nAnio IN (SELECT     CAST(sValorParametro AS int) AS  nioAct  FROM dbo.StbValorParametro WHERE      (nStbParametroID = 82)))"
            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count > 0 Then
                MsgBox("Ese Credito ya esta ingresado en otra Nota Activa. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If

            'Fecha valida del ultimo pago debe ser menor o igual a la fecha de la nota.

            strSQL = "	SELECT     MAX(dbo.SccReciboOficialCaja.dFechaRecibo) as FechaPagoUltimo " &
   " FROM         dbo.SccReciboOficialCaja INNER JOIN " &
 "							  dbo.StbValorCatalogo ON dbo.SccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
 "		WHERE     (dbo.StbValorCatalogo.sCodigoInterno <> '3') AND (dbo.SccReciboOficialCaja.nSccSolicitudChequeID = " & xnSccSolicitudChequeId & " )"

            XdtSocia.ExecuteSql(strSQL)
            If XdtSocia.Count = 0 Then
                MsgBox("No se ha hecho ni un solo pago de cuota. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If






            If XdtSocia.ValueField("FechaPagoUltimo") > Me.cdeFechaS.Value Then
                MsgBox("La fecha del ultimo pago es mayor que la de la nota de debito. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If




            'Ver el monto si es positivo ver en parametro lo maximo permitido
            If xSaldo > 0 Then
                strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Monto Maximo Nota de Credito')"
                XdtSocia.ExecuteSql(strSQL)
                If XdtSocia.Count = 0 Then
                    MsgBox("No existe configuracion de parametro para el maximo de cordobas permitidos del parametro 'Monto Maximo Nota de Credito' Cuando es monto positivo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFichaPorGrupo = False
                    Exit Function
                End If

                If xSaldo > CDbl(XdtSocia.ValueField("sValorParametro")) Then
                    MsgBox("Solo se permite 'Monto Maximo Nota de Credito' " & XdtSocia.ValueField("sValorParametro") & " C$ Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFichaPorGrupo = False
                    Exit Function
                End If
            End If




            'Imposible si no se indicó un Monto Válido:
            If Not IsNumeric(xSaldo) Then
                MsgBox("Monto Inválido. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If
            If CDbl(xSaldo) = 0 Then
                MsgBox("Monto Inválido. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If



            XdtSocia.ExecuteSql("Exec spSccObtenerSaldoCredito " & xnSclFichaDetalleId)
            XMonto = XdtSocia.ValueField("SaldoCredito")
            If XMonto >= 0 And Me.chkEsDebito.Checked Then
                MsgBox("Es Nota de Debito no se Permite Credito. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            Else
                If XMonto < 0 And Me.chkEsDebito.Checked = False Then
                    MsgBox("Es Nota de Credito no se Permite Debito. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaFichaPorGrupo = False
                    Exit Function
                End If
            End If
            If CDbl(xSaldo) - XMonto <> 0 Then
                MsgBox("Monto Inválido de Acuerdo al Saldo del Credito. Para " & Trim(xNombre), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaFichaPorGrupo = False
                Exit Function
            End If

            ''Fuente de Financiamiento:
            'If Me.cboFuente.SelectedIndex = -1 Then
            '    MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaFichaPorGrupo = False
            '    Me.errSolicitud.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
            '    Me.cboFuente.Focus()
            '    Exit Function
            'End If




        Catch ex As Exception
            ValidaDatosEntradaFichaPorGrupo = False
            Control_Error(ex)
        End Try
    End Function

    Private Sub SalvarNota()
        'Dim ObjTmpSolicitud As New BOSistema.Win.XDataSet
        Dim XcDatos As New BOSistema.Win.XComando
        Dim xnSccNotaID As Long

        Try
            Dim strSQL As String

            'If ModoForm = "ADD" Then
            '    strSQL = "Exec spSccGrabarNotaDebitoCredito " & IdNota & "," & nSccSolicitudChequeId & "," & Me.cneMonto.Value & ",'" & Format(Me.cdeFechaS.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "','ADD'," & InfoSistema.IDCuenta & ",'" & Trim(txtConcepto.Text) & "'"
            'Else
            '    strSQL = "Exec spSccGrabarNotaDebitoCredito " & IdNota & "," & nSccSolicitudChequeId & "," & Me.cneMonto.Value & ",'" & Format(Me.cdeFechaS.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "','UPD'," & InfoSistema.IDCuenta & ",'" & Trim(txtConcepto.Text) & "'"
            'End If

            If ModoForm = "ADD" Then
                strSQL = "Exec spSccGrabarNotaDebitoCredito " & IdNota & "," & Me.cneMonto.Value & ",'" & Format(Me.cdeFechaS.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "'," & XdtDelegacion.ValueField("nStbDelegacionProgramaID") & "," & Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID") & "," & IIf(Me.chkEsDebito.Checked = True, 1, 0) & ",'ADD'," & InfoSistema.IDCuenta & ",'" & Trim(txtConcepto.Text) & "'"
            Else
                strSQL = "Exec spSccGrabarNotaDebitoCredito " & IdNota & "," & Me.cneMonto.Value & ",'" & Format(Me.cdeFechaS.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "'," & XdtDelegacion.ValueField("nStbDelegacionProgramaID") & "," & Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID") & "," & IIf(Me.chkEsDebito.Checked = True, 1, 0) & ",'UPD'," & InfoSistema.IDCuenta & ",'" & Trim(txtConcepto.Text) & "'"
            End If

            xnSccNotaID = XcDatos.ExecuteScalar(strSQL)

            If xnSccNotaID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If
            If ModoForm = "ADD" Then
                grpGrupoInicial.Visible = False
                IdNota = xnSccNotaID

                If Me.cboGrupo.ListCount > 0 Then
                    Me.cboGrupo.SelectedIndex = 0
                End If
                Me.XdtGrupo.SetCurrentByID("nSclGrupoSolidarioID", Me.XdtGrupoS.ValueField("nSclGrupoSolidarioID"))

                CargarCreditosGrupo(Me.XdtGrupo.ValueField("nSclGrupoSolidarioID"), Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"), Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"))
                ModoForm = "UPD"
                BuscarG()
            Else
                cmdModificar.Enabled = True

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally


            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub SalvarNotaFicha()
        'Dim ObjTmpSolicitud As New BOSistema.Win.XDataSet
        Dim XcDatos As New BOSistema.Win.XComando
        Dim xnSccNotaID As Long

        Try
            Dim strSQL As String


            strSQL = "Exec spSccGrabarNotaDebitoCreditoDetalleFichas " & IdNota & ",0," & nSccSolicitudChequeId & "," & Me.cneMontoFicha.Value & ",'ADD'," & InfoSistema.IDCuenta



            xnSccNotaID = XcDatos.ExecuteScalar(strSQL)

            If xnSccNotaID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally


            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub EliminarNotaFicha()
        'Dim ObjTmpSolicitud As New BOSistema.Win.XDataSet
        Dim XcDatos As New BOSistema.Win.XComando
        Dim xnSccNotaID As Long

        Try
            Dim strSQL As String


            strSQL = "Exec spSccGrabarNotaDebitoCreditoDetalleFichas " & Me.XdtFichas.ValueField("nSccNotaID") & "," & Me.XdtFichas.ValueField("nSccNotaDetalleFichaID") & ",0," & Me.XdtFichas.ValueField("nMontoFicha") & ",'DEL'," & InfoSistema.IDCuenta



            xnSccNotaID = XcDatos.ExecuteScalar(strSQL)

            If xnSccNotaID = 0 Then
                MsgBox("La Ficha no se pudo eliminar de la nota.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Se elimino la ficha de la nota satisfactoriamente", MsgBoxStyle.Information, "SMUSURA0")
                LimpiarNotasDetalleFichas()
                CargarFichas()
                CargarNota()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally


            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            'Dim res As Object

            'If vbModifico = True Then
            '    res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
            '    Select Case res
            '        Case vbYes
            '            'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
            '            If ValidaDatosEntrada() Then
            '                SalvarNota()
            '                AccionUsuario = AccionBoton.BotonAceptar
            '                grpDatosGenerales.Enabled = False
            '                grpDatosFicha.Enabled = True
            '                cmdModificar.Enabled = True
            '                'Me.Close()
            '            Else
            '                AccionUsuario = AccionBoton.BotonNinguno
            '            End If

            '        Case vbNo
            '            AccionUsuario = AccionBoton.BotonCancelar
            '            ' Me.Close()

            '        Case vbCancel
            '            AccionUsuario = AccionBoton.BotonNinguno
            '    End Select
            'Else
            AccionUsuario = AccionBoton.BotonCancelar
            grpDatosGenerales.Enabled = False
            grpDatosFicha.Enabled = True
            Me.cmdModificar.Enabled = True
            CargarNota()
            'Me.Close()
            ' End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function UltimaFuenteIngresada() As Int32
        Dim XdtQuery As New BOSistema.Win.XDataSet.xDataTable
        Dim sQuery As String = String.Empty
        Dim FuenteFinanciamiento As Int32 = 0
        sQuery = "SELECT top 1 " &
        "                sff.nScnFuenteFinanciamientoID," &
        "                sff.sCodigo," &
        "                sff.sNombre, " &
        "                sff.nFondoPresupuestario" &
        "         FROM   SccNotaCreditoDebito sncd" &
        "                INNER JOIN ScnFuenteFinanciamiento sff" &
        "                    ON  sff.nScnFuenteFinanciamientoID = sncd.nScnFuenteFinanciamientoID" &
        "                INNER JOIN (" &
        "                      SELECT sc.*" &
        "                      FROM   SsgCuenta sc" &
        "                             INNER JOIN SrhEmpleado se" &
        "                                  ON  se.nSrhEmpleadoID = sc.objEmpleadoID" &
        "                             INNER JOIN StbPersona sp" &
        "                                  ON  sp.nStbPersonaID = se.nStbPersonaID" &
        "                      WHERE  sc.[Login] = '" + InfoSistema.LoginName + "'" &
        "                ) AS USR ON sncd.nUsuarioCreacionID = USR.SsgCuentaID  " &
        "        ORDER BY sncd.nSccNotaID DESC"
        Try
            XdtQuery.ExecuteSql(sQuery)
            If XdtQuery.Count > 0 Then
                FuenteFinanciamiento = Convert.ToInt32(XdtQuery.ValueField("nScnFuenteFinanciamientoID"))
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtQuery.Close()
            XdtQuery = Nothing
        End Try

        Return FuenteFinanciamiento

    End Function

    Private Sub FrmSccEditNotaDebitoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            RegTmp.ExecuteSql("	SELECT CAST(sValorParametro AS int) as AnioAct FROM dbo.StbValorParametro  WHERE     (nStbParametroID = 82)")


            IntAnioActual = RegTmp.ValueField("AnioAct")


            EncuentraParametrosD()
            If Me.sColor = "Verde" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Registrar Solicitudes de Cheque")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Revisión de Solicitudes de Cheque")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            BuscarMaximoGrupos()
            'Cargar Combos:
            Dim fuenteID As Int32 = 0
            fuenteID = Me.UltimaFuenteIngresada()

            CargarFuenteFondos(fuenteID)

            CargarDelegacion(0)
            CargarFichas()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm = "UPD" Then
                CargarNota()
                'grpDatosFicha.Enabled = False
                grpDatosGenerales.Enabled = False

                InhabilitarControles()
                CargarGrupos(Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"), XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"))

                If XMaximoGrupos > 1 Then
                    Me.txtConcepto.Enabled = True
                Else
                    Me.txtConcepto.Enabled = False
                End If
            Else

                TxtAnio.Text = IntAnioActual
                Me.cneMonto.Value = 0

                Me.cmdModificar.Enabled = False
                grpDatosFicha.Enabled = False
                Me.chkEsDebito.Checked = True
                Me.cdeFechaS.Value = Now()
                Me.cdeFechaTC.Value = Now()
                If fuenteID = 0 Then
                    Me.cboFuente.Select()
                Else
                    Me.cboGrupoS.Select()
                End If
                Me.cmdCancelar.Enabled = False
                grpGrupoInicial.Visible = True
                cboFuente.Enabled = True
            End If

            ''Me.cdeFechaS.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar
            Me.grdSeleccion.Caption = " Listado  de Creditos  Cancelados Elegibles para " & IIf(Me.chkEsDebito.Checked, "Nota de Debito", "Nota de Credito") & " (0 registros)"

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub InhabilitarControles()
        Try
            'Dim StrSql As String
            'Inhabilitar todo el Bloque de Datos Generales:
            If IntHabilito = 0 Then
                'Si la Solicitud esta Autorizada, Anulada o Autorizada con CK:
                '    StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                '             "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                '             "WHERE (StbValorCatalogo.sCodigoInterno > '3') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & IdSolicitudCheque & ")"
                '    If RegistrosAsociados(StrSql) Then
                '        Me.cmdAceptar.Enabled = False
                '        Me.grpDatosGenerales.Enabled = False
                '    Else
                '        'En caso contrario: Solo Habilitar Observaciones y Concepto del Pago:
                '        cdeFechaS.Enabled = False
                '        cdeFechaTC.Enabled = False
                '        cneMonto.Enabled = False
                '        cboTipoS.Enabled = False
                '        cboFuente.Enabled = False
                '        cboBeneficiario.Enabled = False
                '        cboFirmaS.Enabled = False
                '        Me.txtConcepto.Select()
                '    End If
                'Else
                '    'Si el Tipo de Solicitud de Pago es Automática:
                '    'bloquear datos que provienen de la Solicitud
                '    'de Desembolso de Fondos:
                '    If cboTipoS.Columns("nAutomatica").Value = 1 Then
                '        cdeFechaS.Enabled = False
                '        cdeFechaTC.Enabled = False
                '        cneMonto.Enabled = False
                '        cboTipoS.Enabled = False
                '        'cboFuente.Enabled = False Se permitirá modificar la Cuenta siempre que aún no exista Codificación Contable.
                '        cboBeneficiario.Enabled = False
                '    End If
                grpDatosFicha.Enabled = False
                grpDatosGenerales.Enabled = False
                cmdAceptar.Enabled = False
                Me.cmdModificar.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarNota()
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            XdtSocia.ExecuteSql("SELECT nAnio,  nScnFuenteFinanciamientoID ,  nSccNotaID,  dbo.SccNotaCreditoDebito.nMonto, nStbEstadoNotaID, dbo.SccNotaCreditoDebito.dFechaNota, dbo.SccNotaCreditoDebito.dFechaTipoCambio, dbo.SccNotaCreditoDebito.nCodigo,sConceptoNota,nStbDelegacionProgramaID,nScnFuenteFinanciamientoID,nEsDebito FROM         dbo.SccNotaCreditoDebito  Where     (nSccNotaID= " & Me.IdNota & ")")
            'nSclFichaDetalleId = XdtSocia.ValueField("nSclFichaNotificacionDetalleID")
            'Me.nSccSolicitudChequeId = XdtSocia.ValueField("nSccSolicitudChequeID")
            'Me.txtnSclFichaDetalle.Text = XdtSocia.ValueField("nSclFichaNotificacionDetalleID")

            'XdtFuenteFondos.Table.DataSet.Tables.Item(0)
            XdtFuenteFondos.BindingSource.MoveFirst()
            If XdtSocia.ValueField("nScnFuenteFinanciamientoID") = XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID") Then
                Me.cboFuente.SelectedIndex = 0
            Else
                XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", XdtSocia.ValueField("nScnFuenteFinanciamientoID"))
            End If
            XdtDelegacion.BindingSource.MoveFirst()
            If XdtSocia.ValueField("nStbDelegacionProgramaID") = XdtDelegacion.ValueField("nStbDelegacionProgramaID") Then
                Me.cboDelegacion.SelectedIndex = 0
            Else
                XdtDelegacion.SetCurrentByID("nStbDelegacionProgramaID", XdtSocia.ValueField("nStbDelegacionProgramaID"))
            End If


            Me.cneMonto.Value = XdtSocia.ValueField("nMonto")
            Me.cdeFechaS.Value = XdtSocia.ValueField("dFechaNota")
            Me.cdeFechaTC.Value = XdtSocia.ValueField("dFechaTipoCambio")
            txtCodigo.Text = XdtSocia.ValueField("nCodigo")
            txtConcepto.Text = XdtSocia.ValueField("sConceptoNota")
            TxtAnio.Text = XdtSocia.ValueField("nAnio")


            If IntAnioActual <> Val(TxtAnio.Text) Then

                MsgBox("No se puede modificar nota. año es diferente al actual.", MsgBoxStyle.Information, "SMUSURA0")
                cmdModificar.Enabled = False
                cmdEliminar.Enabled = False
                cmdBuscarG.Enabled = False
            End If


            If XdtSocia.ValueField("nEsDebito") = 1 Then
                Me.chkEsDebito.Checked = True
            Else

                Me.chkEsDebito.Checked = False
            End If
            'CargarDatosFichaDetalle(nSccSolicitudChequeId)
        Catch ex As Exception
            XdtSocia.Close()
            XdtSocia = Nothing
        End Try
    End Sub


    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click

        Try
            Buscar()



        Catch ex As Exception
            Control_Error(ex)


        End Try
    End Sub


    Private Sub cmdModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModificar.Click
        grpDatosGenerales.Enabled = True
        grpDatosFicha.Enabled = False
        cmdModificar.Enabled = False
        Me.cmdCancelar.Enabled = True
        Me.cmdAceptar.Enabled = True

    End Sub

    Private Sub cmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        Try
            If ValidaDatosEntradaFicha() Then
                SalvarNotaFicha()
                'AccionUsuario = AccionBoton.BotonAceptar
                'grpDatosGenerales.Enabled = False
                'grpDatosFicha.Enabled = True
                CargarFichas()
                CargarNota()

                '  Me.Close()

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click

        Try



            'Imposible si no existen Solicitudes:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No existen Fichas  registradas", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de Eliminar a " & Me.XdtFichas.ValueField("Socia") & Chr(13) & "Del Grupo :  " & Me.XdtFichas.ValueField("NombreGrupo") & Chr(13) & "Detalle de Ficha " & Me.XdtFichas.ValueField("nSccNotaDetalleFichaID") & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If
            EliminarNotaFicha()
            Me.nSccSolicitudChequeId = 0
            CargarNota()

        Catch ex As Exception
            Control_Error(ex)


        End Try
    End Sub

    Private Sub grdDetalles_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDetalles.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdDetalles_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalles.Filter
        Try
            XdtFichas.FilterLocal(e.Condition)
            Me.grdDetalles.Caption = " Listado de Creditos (" + Me.grdDetalles.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdDetalles_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdDetalles.RowColChange
        PresentarNotasDetalleFichas()
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFechaS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaS.TextChanged
        Me.cdeFechaTC.Value = Me.cdeFechaS.Value
    End Sub

    Private Sub txtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdBuscarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscarG.Click
        Try
            BuscarG()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub BuscarG()
        Try
            grpGrupoSeleccion.Visible = True

            cmdModificar.Enabled = False

        Catch ex As Exception
            Control_Error(ex)


        End Try
    End Sub

    Private Sub cboGrupo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupo.TextChanged
        Try
            txtGrupoId.Text = Me.XdtGrupo.ValueField("nSclGrupoSolidarioID")
            txtGrupoNombre.Text = Me.XdtGrupo.ValueField("NombreGrupo")
            txtGrupoCodigo.Text = Me.XdtGrupo.ValueField("CodGrupo")

            Me.cdeFechaC.Value = Me.XdtGrupo.ValueField("dFechaNotificacion")
            CargarConceptoR()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub cmdListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListar.Click
        Try

            'Fuente de Financiamiento:
            If Me.cboGrupo.SelectedIndex = -1 Then
                MsgBox("Debe Seleccionar un grupo.", MsgBoxStyle.Critical, NombreSistema)
                Me.cboGrupo.Focus()
                Exit Sub
            End If

            txtNombreFuenteFinanciamiento.Text = Me.XdtFuenteFondos.ValueField("sNombre")

            CargarCreditosGrupo(Me.XdtGrupo.ValueField("nSclGrupoSolidarioID"), Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"), Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"))

            If grdSeleccion.RowCount = 0 Then Exit Sub

            HabilitarG(True)
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    Private Sub HabilitarG(ByVal band As Boolean)
        cmdAceptarG.Enabled = band
        cmdCancelarG.Enabled = band
        cboGrupo.Enabled = Not band
        cmdListar.Enabled = Not band
    End Sub

    Private Sub BuscarMaximoGrupos()
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Dim strSQL As String
        'Obtener el maximo de grupos por nota
        XMaximoGrupos = 1 'Por defecto maximo numero de grupos permitido en la nota
        strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Numero Maximo Grupos Nota de Credito')"
        XdtSocia.ExecuteSql(strSQL)
        If XdtSocia.Count > 0 Then
            XMaximoGrupos = CInt(XdtSocia.ValueField("sValorParametro"))
        End If
    End Sub

    Private Sub cmdAceptarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarG.Click

        Try
            Dim i As Integer
            Dim strSQL As String
            Dim xnSccNotaID As Long
            Dim XcDatos As New BOSistema.Win.XComando
            Dim ContadorInsertados As Integer
            Dim ContadorSeleccionados As Integer
            Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable

            'Dim XMonto As Double

            Dim XSclFichaNotificacionCredito As Long
            'Fuente de Financiamiento:
            ContadorInsertados = 0
            ContadorSeleccionados = 0
            grdSeleccion.MoveFirst()


            For i = 0 To Me.grdSeleccion.RowCount - 1

                If Me.XdtCreditosSeleccion.ValueField("nSeleccionado") = True Then
                    strSQL = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SccSolicitudCheque.nSccSolicitudChequeID,dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID,dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID,dbo.SccSolicitudCheque.nStbDelegacionProgramaID      FROM         dbo.SclFichaNotificacionDetalle INNER JOIN                    dbo.SclFichaNotificacionCredito ON " &
                             " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " &
                             " dbo.SccSolicitudDesembolsoCredito ON " &
                             " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " &
                             " dbo.SccSolicitudCheque ON  " &
                             " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " &
                             " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " &
                             " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID " &
                            " WHERE(dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & Me.XdtCreditosSeleccion.ValueField("nSccSolicitudChequeID") & " )"
                    XdtSocia.ExecuteSql(strSQL)
                    XSclFichaNotificacionCredito = XdtSocia.ValueField("nSclFichaNotificacionID")

                    'Validar el numero de grupos permitidos por nota

                    ''Obtener el maximo de grupos por nota
                    'XMaximoGrupos = 1 'Por defecto maximo numero de grupos permitido en la nota
                    'strSQL = "SELECT     dbo.StbValorParametro.sValorParametro FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Numero Maximo Grupos Nota de Credito')"
                    'XdtSocia.ExecuteSql(strSQL)
                    'If XdtSocia.Count > 0 Then
                    '    XMaximoGrupos = CInt(XdtSocia.ValueField("sValorParametro"))
                    'End If

                    strSQL = "SELECT     nSccNotaID, nSclFichaNotificacionID  FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas WHERE     (nSccNotaID = " & Me.IdNota & ") AND (nSclFichaNotificacionID <> " & XSclFichaNotificacionCredito & ") Group By nSccNotaID, nSclFichaNotificacionID  "

                    XdtSocia.ExecuteSql(strSQL)
                    If XdtSocia.Count > 0 Then
                        If XdtSocia.Count + 1 > XMaximoGrupos Then
                            MsgBox("En esta nota ya se ha alcanzado el maximo de grupos." & XMaximoGrupos.ToString(), MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If


                    'If XMaximoGrupos = 1 And i = 0 Then
                    CargarConceptoR()
                    strSQL = "Update SccNotaCreditoDebito Set sConceptoNota='" & Trim(txtConcepto.Text) & "' Where nSccNotaID=" & IdNota

                    XdtSocia.ExecuteSql(strSQL)
                    'End If



                    ContadorSeleccionados = ContadorSeleccionados + 1
                    If ValidaDatosEntradaFichaPorGrupo(Me.XdtCreditosSeleccion.ValueField("nSccSolicitudChequeID"), Me.XdtCreditosSeleccion.ValueField("nSclFichaNotificacionDetalleID"), Me.XdtCreditosSeleccion.ValueField("nSaldo"), Me.XdtCreditosSeleccion.ValueField("NombreSocia")) Then




                        strSQL = "Exec spSccGrabarNotaDebitoCreditoDetalleFichas " & IdNota & ",0," & Me.XdtCreditosSeleccion.ValueField("nSccSolicitudChequeID") & "," & Me.XdtCreditosSeleccion.ValueField("nSaldo") & ",'ADD'," & InfoSistema.IDCuenta
                        '& "," & IIf(Me.chkEsDebito.Checked, 1, 0)



                        xnSccNotaID = XcDatos.ExecuteScalar(strSQL)

                        If xnSccNotaID = 0 Then
                            MsgBox("Los datos no pudieron grabarse Para " & Me.XdtCreditosSeleccion.ValueField("NombreSocia"), MsgBoxStyle.Information, "SMUSURA0")
                        Else
                            '    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                            ContadorInsertados = ContadorInsertados + 1
                            'End If
                        End If
                    End If
                End If
                Me.grdSeleccion.MoveNext()
            Next

            If ContadorInsertados = 0 Then
                MsgBox("No se pudo Registrar ni una sola ficha para la nota. ", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Se Registraron " & ContadorInsertados.ToString().Trim() & " de un total de " & ContadorSeleccionados.ToString().Trim() & " fichas para la nota. ", MsgBoxStyle.Information, "SMUSURA0")
            End If

            ''CargarCreditosGrupo(Me.XdtGrupo.ValueField("nSclGrupoSolidarioID"), Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"), Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"))
            CargarCreditosGrupo(0, Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"), Me.XdtDelegacion.ValueField("nStbDelegacionProgramaID"))
            CargarFichas()
            HabilitarG(False)
            CargarNota()
            grpGrupoSeleccion.Visible = False

            cmdModificar.Enabled = True
        Catch ex As Exception
            Control_Error(ex)


        End Try
    End Sub


    Private Sub cmdCancelarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelarG.Click
        Try

            HabilitarG(False)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdRegresarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegresarDetalle.Click
        Try
            grpGrupoSeleccion.Visible = False
            cmdModificar.Enabled = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdSeleccion_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSeleccion.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdSeleccion_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSeleccion.Filter
        Try
            Me.XdtCreditosSeleccion.FilterLocal(e.Condition)
            Me.grdSeleccion.Caption = " Listado  de Creditos  Cancelados Elegibles para " & IIf(Me.chkEsDebito.Checked, "Nota de Debito", "Nota de Credito") & " (" + Me.grdSeleccion.RowCount.ToString + " registros)"
            Me.CalcularSaldos()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboGrupoS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupoS.TextChanged
        Try
            txtGrupoIdS.Text = Me.XdtGrupoS.ValueField("nSclGrupoSolidarioID")
            txtGrupoNombreS.Text = Me.XdtGrupoS.ValueField("NombreGrupo")
            txtGrupoCodigoS.Text = Me.XdtGrupoS.ValueField("CodGrupo")

            Me.cdeFechaCS.Value = Me.XdtGrupoS.ValueField("dFechaNotificacion")
            'XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", XdtSocia.ValueField("nScnFuenteFinanciamientoID"))


            If Me.cboDelegacion.ListCount > 0 Then
                Me.cboDelegacion.SelectedIndex = 0
            End If
            Dim nStbDelegacionProgramaID As Integer
            nStbDelegacionProgramaID = Me.XdtGrupoS.ValueField("nStbDelegacionProgramaID")
            Me.XdtDelegacion.SetCurrentByID("nStbDelegacionProgramaID", nStbDelegacionProgramaID)
            CargarConcepto()
        Catch ex As Exception
            Control_Error(ex)


        End Try
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        If Me.ModoFrm = "ADD" Then
            Me.CargarGruposporFuentes(Me.XdtFuenteFondos.ValueField("nScnFuenteFinanciamientoID"))
        End If
    End Sub

    Private Sub CargarConcepto()
        Dim xnSclGrupoSolidarioID As Integer

        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Dim SqlStr As String
        If cboGrupoS.SelectedIndex > -1 Then
            xnSclGrupoSolidarioID = Me.XdtGrupoS.ValueField("nSclGrupoSolidarioID")
            'SqlStr = "SELECT     'FICHA NO.' + CAST(FNC.nCodigo AS Varchar(10)) +  ' GRUPO: ' + dbo.SclGrupoSolidario.sDescripcion + '(' + dbo.SclGrupoSolidario.sCodigo + ') ACTA DE COMITE No. ' + FNC.sNumSesion + ' CON FECHA DE NOTIFICACION ' + CONVERT(nvarchar(30), FNC.dFechaNotificacion, 105) + ' (' + dbo.StbDelegacionPrograma.sNombreDelegacion + ')' AS DESCR" & _
            '         " FROM         dbo.SclFichaNotificacionCredito AS FNC INNER JOIN  dbo.SclGrupoSolidario ON FNC.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.StbValorCatalogo ON FNC.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID  INNER JOIN   dbo.StbDelegacionPrograma ON dbo.SclGrupoSolidario.nStbDelegacionProgramaID = dbo.StbDelegacionPrograma.nStbDelegacionProgramaID" & _
            '         " WHERE     (FNC.nSclGrupoSolidarioID = " & xnSclGrupoSolidarioID & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '2')"

            xnSclGrupoSolidarioID = Me.XdtGrupoS.ValueField("nSclGrupoSolidarioID")
            SqlStr = "SELECT     'FICHA NO: ' + CAST(FNC.nCodigo AS Varchar(10)) +  ' GRUPO: ' + dbo.SclGrupoSolidario.sDescripcion + '(' + dbo.SclGrupoSolidario.sCodigo + ')(' + dbo.StbDelegacionPrograma.sNombreDelegacion + ')' AS DESCR" &
                     " FROM         dbo.SclFichaNotificacionCredito AS FNC INNER JOIN  dbo.SclGrupoSolidario ON FNC.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.StbValorCatalogo ON FNC.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID  INNER JOIN   dbo.StbDelegacionPrograma ON dbo.SclGrupoSolidario.nStbDelegacionProgramaID = dbo.StbDelegacionPrograma.nStbDelegacionProgramaID" &
                     " WHERE     (FNC.nSclGrupoSolidarioID = " & xnSclGrupoSolidarioID & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '2')"

            RegTmp.ExecuteSql(SqlStr)
            If RegTmp.Count > 0 Then
                Me.txtConcepto.Text = IIf(Me.chkEsDebito.Checked, "ND ", "NC ") + RegTmp.ValueField("DESCR")
            End If

        End If
    End Sub

    Private Sub CargarConceptoR()
        Dim xnSclGrupoSolidarioID As Integer

        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Dim SqlStr As String
        If cboGrupo.SelectedIndex > -1 Then
            xnSclGrupoSolidarioID = Me.XdtGrupo.ValueField("nSclGrupoSolidarioID")
            'SqlStr = "SELECT     'FICHA NO.' + CAST(FNC.nCodigo AS Varchar(10)) +  ' GRUPO: ' + dbo.SclGrupoSolidario.sDescripcion + '(' + dbo.SclGrupoSolidario.sCodigo + ') ACTA DE COMITE No. ' + FNC.sNumSesion + ' CON FECHA DE NOTIFICACION ' + CONVERT(nvarchar(30), FNC.dFechaNotificacion, 105) + ' (' + dbo.StbDelegacionPrograma.sNombreDelegacion + ')' AS DESCR" & _
            '         " FROM         dbo.SclFichaNotificacionCredito AS FNC INNER JOIN  dbo.SclGrupoSolidario ON FNC.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.StbValorCatalogo ON FNC.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID  INNER JOIN   dbo.StbDelegacionPrograma ON dbo.SclGrupoSolidario.nStbDelegacionProgramaID = dbo.StbDelegacionPrograma.nStbDelegacionProgramaID" & _
            '         " WHERE     (FNC.nSclGrupoSolidarioID = " & xnSclGrupoSolidarioID & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '2')"

            SqlStr = "SELECT     'FICHA NO: ' + CAST(FNC.nCodigo AS Varchar(10)) +  ' GRUPO: ' + dbo.SclGrupoSolidario.sDescripcion + '(' + dbo.SclGrupoSolidario.sCodigo + ') (' + dbo.StbDelegacionPrograma.sNombreDelegacion + ')' AS DESCR" &
         " FROM         dbo.SclFichaNotificacionCredito AS FNC INNER JOIN  dbo.SclGrupoSolidario ON FNC.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.StbValorCatalogo ON FNC.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID  INNER JOIN   dbo.StbDelegacionPrograma ON dbo.SclGrupoSolidario.nStbDelegacionProgramaID = dbo.StbDelegacionPrograma.nStbDelegacionProgramaID" &
         " WHERE     (FNC.nSclGrupoSolidarioID = " & xnSclGrupoSolidarioID & ") AND (dbo.StbValorCatalogo.sCodigoInterno = '2')"

            RegTmp.ExecuteSql(SqlStr)
            If RegTmp.Count > 0 Then
                Me.txtConcepto.Text = IIf(Me.chkEsDebito.Checked, "ND ", "NC ") + RegTmp.ValueField("DESCR")
            End If

        End If
    End Sub

    Private Sub grdSeleccion_AfterColEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles grdSeleccion.AfterColEdit
        If e.Column.Name = "Seleccionar" Then
            Me.CalcularSaldos()
        End If
    End Sub

End Class