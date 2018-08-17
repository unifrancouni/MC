Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclFichaInscripcion
    'Declaracion de Variables
    Dim mIdFicha As Integer
    Dim mIdConsecutivoPrestamo As Integer

    Dim objEncabeza As rptEncabezadoV
    Dim xdtFicha As BOSistema.Win.XDataSet.xDataTable

    Dim ObjSociasGrupo As srptSclSociasGrupo

    'ID de la Ficha seleccionada
    Public Property IdFicha() As Integer
        Get
            IdFicha = mIdFicha
        End Get
        Set(ByVal value As Integer)
            mIdFicha = value
        End Set
    End Property
    'Consecutivo de Préstamo del Grupo de la Ficha seleccionada
    Public Property IdConsecutivoPrestamo() As Integer
        Get
            IdConsecutivoPrestamo = mIdConsecutivoPrestamo
        End Get
        Set(ByVal value As Integer)
            mIdConsecutivoPrestamo = value
        End Set
    End Property


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        'Declaracion de Variables 
        Dim ObjModulodt As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

        Try
            ObjModulodt = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

            'Me.txtEntidad.Text = InfoSistema.CodigoUnidadLocal & " - " & InfoSistema.UnidadSaludLocal
            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            'Me.txtReporte.Text = "rptStbBarrio"

            'Buscar el Nombre del Módulo
            ObjModulodt.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = 'STB'"
            ObjModulodt.Retrieve()
            If ObjModulodt.Count > 0 Then
                'Me.txtSub.Text = ObjModulodt("Nombre")
            End If

            'If Me.IdMunicipio = -20 Then
            '    Me.txtparametro1.Text = " Estado: " & mEstado
            '    'Me.lblMunicipio.Visible = False
            'Else
            '    Me.txtparametro1.Text = " Estado: " & mEstado & "   " & "Municipio: " & mMunicipio
            'End If

            'Me.txtparametro1.Text = " Estado: " & mEstado
            'Me.txtparametro2.Text = " SubSistema: " & mModulo
            'If Me.IdModulo = -20 Then
            '    Me.txtparametro2.Visible = False
            '    Me.lblModulo.Visible = False
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjModulodt = Nothing
        End Try

    End Sub

    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabeza = New rptEncabezadoV
            Me.SubReporte.Report = objEncabeza
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar los objetos 
    '                           :   de la Ficha
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            xdtFicha = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	CargarFicha
    ' Description			   	:	Cargar los datos de la Ficha
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarFicha()
        Dim ObjDatosAdicionalesDT As New BOSistema.Win.XDataSet.xDataTable

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""
            '------------------------

            Strsql = " Select nSclFichaSociaID,nSclGrupoSolidarioID,sCodigo,dFechaInscripcion,sNombreSocia, " & _
                     " nEdadAnios,sNumeroCedula,sDireccionSocia,sTelefonoSocia,sNombreBarrio,sNombreDistrito, " & _
                     " sNombreMunicipio,sNombreDepartamento,sPrimaria,sSecundaria,sCarreraTecnica,sOtrosEstudios, " & _
                     " nAlfabetizada,nNumHijosVivos,nNumHijosDependientes,nTieneNegocio,sTipoNegocio,sDireccionNegocio, " & _
                     " dFechaAperturaNegocio,nPromedioVentas,isnull(sTipoPlazoVentas,'') as sTipoPlazoVentas,nMontoCredito,nPlazo,nDispuestaFormarGS, " & _
                     " sNombreGrupo,sTipoPlazoPrestamo " & _
                     " From vwSclFichaInscripcionRep " & _
                     " Where nSclFichaSociaID = " & Me.IdFicha & " And nConsecutivoCredito = " & Me.IdConsecutivoPrestamo

            xdtFicha.ExecuteSql(Strsql)

            'Datos de Otro Crédito Vigente
            Strsql = " SELECT a.nMontoDeuda,a.nPlazo,a.sNombreQuienPresta,a.sTipoPlazo, " & _
                     " a.nMontoCuota,a.sPeriodicidad,a.nSaldo,a.sSimbolo " & _
                     " FROM vwSclDetalleOtroCreditoRep a " & _
                     " WHERE a.nSclFichaSociaID = " & Me.IdFicha & " And a.nAltaVerificacion = 0"

            ObjDatosAdicionalesDT.ExecuteSql(Strsql)

            If ObjDatosAdicionalesDT.Count > 0 Then
                Me.chkOtroCreditoSi.Checked = True
                Me.chkOtroCreditoNo.Checked = False
                Me.txtMontoSolOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nMontoDeuda"), "#,##0.00")
                Me.txtPlazoOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("nPlazo")
                Me.txtInstitucionOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sNombreQuienPresta")
                Me.txtTipoPlazoOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sTipoPlazo")
                Me.txtCuotaOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nMontoCuota"), "#,##0.00")
                Me.txtPeriodicidadOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sPeriodicidad")
                Me.txtSaldoOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nSaldo"), "#,##0.00")
            Else
                Me.chkOtroCreditoSi.Checked = False
                Me.chkOtroCreditoNo.Checked = True
            End If

            'Datos de Referencias Crediticias
            Strsql = " SELECT a.sNombreReferencia,a.nMontoObtenido,a.nPlazo,a.sTipoPlazo, " & _
                     " a.dFechaSolicitud,a.dFechaCancelacion,a.sSimbolo " & _
                     " FROM vwSclDetalleReferenciaRep a " & _
                     " WHERE a.nSclFichaSociaID = " & Me.IdFicha

            ObjDatosAdicionalesDT.ExecuteSql(Strsql)

            If ObjDatosAdicionalesDT.Count > 0 Then
                Me.txtInstitucionReferencia.Text = ObjDatosAdicionalesDT.ValueField("sNombreReferencia")
                Me.txtMontoReferencia.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nMontoObtenido"), "#,##0.00")
                Me.txtPlazoReferencia.Text = ObjDatosAdicionalesDT.ValueField("nPlazo")
                Me.txtTipoPlazoReferencia.Text = ObjDatosAdicionalesDT.ValueField("sTipoPlazo")
                Me.txtFechaSolicitud.Text = Format(ObjDatosAdicionalesDT.ValueField("dFechaSolicitud"), "dd/MM/yyyy")
                Me.txtFechaCancelacion.Text = Format(ObjDatosAdicionalesDT.ValueField("dFechaCancelacion"), "dd/MM/yyyy")
                Me.chkReferenciaSi.Checked = True
                Me.chkReferenciaNo.Checked = False
            Else
                Me.chkReferenciaSi.Checked = False
                Me.chkReferenciaNo.Checked = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjDatosAdicionalesDT.Close()
            ObjDatosAdicionalesDT = Nothing
        End Try
    End Sub
    Private Sub rptSclFichaInscripcion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarFicha()

            If xdtFicha.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtFicha.Table

            'Asignar el data field
            Me.txtCodigoFicha.DataField = "sCodigo"
            Me.txtFechaInscripcion.DataField = "dFechaInscripcion"
            Me.txtDistrito.DataField = "sNombreDistrito"
            Me.txtNombreApellidos.DataField = "sNombreSocia"
            Me.txtEdad.DataField = "nEdadAnios"
            Me.chkAlfabetizada.DataField = "nAlfabetizada"
            Me.txtCedula.DataField = "sNumeroCedula"
            Me.txtDireccion.DataField = "sDireccionSocia"
            Me.txtTelefono.DataField = "sTelefonoSocia"
            Me.txtBarrio.DataField = "sNombreBarrio"
            Me.txtMunicipio.DataField = "sNombreMunicipio"
            Me.txtDepartamento.DataField = "sNombreDepartamento"
            Me.txtPrimaria.DataField = "sPrimaria"
            Me.txtSecundaria.DataField = "sSecundaria"
            Me.txtCarreraTecnica.DataField = "sCarreraTecnica"
            Me.txtOtrosEstudios.DataField = "sOtrosEstudios"
            Me.txtNumHijosVivos.DataField = "nNumHijosVivos"
            Me.txtNumHijosDependientes.DataField = "nNumHijosDependientes"
            Me.chkSiNegocioActual.DataField = "nTieneNegocio"
            Me.txtTipoNegocioActual.DataField = "sTipoNegocio"
            Me.txtTipoNegocioPropuesto.DataField = "sTipoNegocio"
            Me.txtDireccionNegocio.DataField = "sDireccionNegocio"
            Me.txtFechaApertura.DataField = "dFechaAperturaNegocio"
            Me.txtMontoVentas.DataField = "nPromedioVentas"
            Me.txtTipoPlazoVentas.DataField = "sTipoPlazoVentas"
            Me.txtMontoPrestamo.DataField = "nMontoCredito"
            Me.txtPlazoPrestamo.DataField = "nPlazo"
            Me.txtGrupoSolidario.DataField = "sNombreGrupo"
            Me.chkDispuestaSi.DataField = "nDispuestaFormarGS"
            Me.txtTipoPlazoPrestamo.DataField = "sTipoPlazoPrestamo"

            'Me.chkNoNegocioActual.DataField = Not Me.chkSiNegocioActual.DataField
            Me.txtSclGrupoSolidarioID.DataField = "nSclGrupoSolidarioID"

            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        ObjSociasGrupo = New srptSclSociasGrupo
        ObjSociasGrupo.IdGrupoSolidario = CInt(Me.txtSclGrupoSolidarioID.Text)
        Me.srptSociasGrupo.Report = ObjSociasGrupo
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        If Me.chkSiNegocioActual.Checked = True Then
            Me.chkNoNegocioActual.Checked = False
            'Me.txtTipoNegocioPropuesto.Visible = False
            Me.txtTipoNegocioPropuesto.Text = ""
        Else
            Me.chkNoNegocioActual.Checked = True
            'Me.txtTipoNegocioActual.Visible = False
            Me.txtTipoNegocioActual.Text = ""
        End If

        If Me.chkDispuestaSi.Checked = True Then
            Me.chkDispuestaNo.Checked = False
        Else
            Me.chkDispuestaNo.Checked = True
        End If

        Me.txtFechaInscripcion.Text = Format(Me.txtFechaInscripcion.Value, "dd/MM/yyyy")
        If Not Me.txtFechaApertura.Value Is DBNull.Value Then
            Me.txtFechaApertura.Text = Format(Me.txtFechaApertura.Value, "dd/MM/yyyy")
        End If
        Me.txtMontoPrestamo.Text = Format(Me.txtMontoPrestamo.Value, "#,##0.00")

    End Sub
End Class
