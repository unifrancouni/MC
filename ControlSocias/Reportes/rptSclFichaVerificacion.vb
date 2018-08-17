Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclFichaVerificacion
    'Declaracion de Variables
    Dim mIdFicha As Integer
    'Dim mIdConsecutivoPrestamo As Integer

    Dim objEncabeza As rptEncabezadoV
    Dim xdtFicha As BOSistema.Win.XDataSet.xDataTable

    'Dim ObjSociasGrupo As srptSclSociasGrupo

    'ID de la Ficha seleccionada
    Public Property IdFicha() As Integer
        Get
            IdFicha = mIdFicha
        End Get
        Set(ByVal value As Integer)
            mIdFicha = value
        End Set
    End Property
    ''Consecutivo de Préstamo del Grupo de la Ficha seleccionada
    'Public Property IdConsecutivoPrestamo() As Integer
    '    Get
    '        IdConsecutivoPrestamo = mIdConsecutivoPrestamo
    '    End Get
    '    Set(ByVal value As Integer)
    '        mIdConsecutivoPrestamo = value
    '    End Set
    'End Property


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        'Declaracion de Variables 
        'Dim ObjModulodt As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

        Try
            'ObjModulodt = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

            'Me.txtEntidad.Text = InfoSistema.CodigoUnidadLocal & " - " & InfoSistema.UnidadSaludLocal
            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            'Me.txtReporte.Text = "rptStbBarrio"

            'Buscar el Nombre del Módulo
            'ObjModulodt.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = 'STB'"
            'ObjModulodt.Retrieve()
            'If ObjModulodt.Count > 0 Then
            '    'Me.txtSub.Text = ObjModulodt("Nombre")
            'End If

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
            'Finally
            '    ObjModulodt = Nothing
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
                     " nEdadAnios,sNumeroCedula,sDireccionSociaVerificada,sTelefonoSociaVerificado,sNombreBarrio,sNombreDistrito, " & _
                     " sNombreMunicipio,sNombreDepartamento,sPrimaria,sSecundaria,sCarreraTecnica,sOtrosEstudiosVerificado, " & _
                     " nAlfabetizadaVerificada,nNumHijosVivos,nNumHijosDependientes,nTieneNegocioVerificado,sTipoNegocio,sDireccionNegocioVerificada, " & _
                     " dFechaAperturaNegocioVerificada,nPromedioVentasVerificado,sTipoPlazoVentas,nMontoCreditoVerificado,nPlazoVerificado,nDispuestaFormarGS, " & _
                     " sNombreGrupo,sTipoPlazoPrestamo,sSociasConocidas,sObservacionesVerificacion,dFechaHoraVerificacion,sPersonaPrograma " & _
                     " From vwSclFichaVerificacionRep " & _
                     " Where nSclFichaSociaID = " & Me.IdFicha

            xdtFicha.ExecuteSql(Strsql)

            'Datos de Otro Crédito Vigente
            Strsql = " SELECT a.nMontoDeudaVerificado,a.nPlazoVerificado,a.sNombreQuienPresta,a.sTipoPlazo, " & _
                     " a.nMontoCuotaVerificado,a.sPeriodicidad,a.nSaldoVerificado,a.sSimbolo " & _
                     " FROM vwSclDetalleOtroCreditoVerificacionRep a " & _
                     " WHERE a.nSclFichaSociaID = " & Me.IdFicha & " and nActivo = 1"   '& " And a.nAltaVerificacion = 0"

            ObjDatosAdicionalesDT.ExecuteSql(Strsql)

            If ObjDatosAdicionalesDT.Count > 0 Then
                Me.chkOtroCreditoSi.Checked = True
                Me.chkOtroCreditoNo.Checked = False
                Me.txtMontoSolOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nMontoDeudaVerificado"), "#,##0.00")
                Me.txtPlazoOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("nPlazoVerificado")
                Me.txtInstitucionOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sNombreQuienPresta")
                Me.txtTipoPlazoOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sTipoPlazo")
                Me.txtCuotaOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nMontoCuotaVerificado"), "#,##0.00")
                Me.txtPeriodicidadOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sPeriodicidad")
                Me.txtSaldoOtroCredito.Text = ObjDatosAdicionalesDT.ValueField("sSimbolo") & " " & Format(ObjDatosAdicionalesDT.ValueField("nSaldoVerificado"), "#,##0.00")
            Else
                Me.chkOtroCreditoSi.Checked = False
                Me.chkOtroCreditoNo.Checked = True
            End If

            'Datos de Referencias Crediticias
            'Strsql = " SELECT a.sNombreReferencia,a.nMontoObtenido,a.nPlazo,a.sTipoPlazo, " & _
            '         " a.dFechaSolicitud,a.dFechaCancelacion " & _
            '         " FROM vwSclDetalleReferenciaRep a " & _
            '         " WHERE a.nSclFichaSociaID = " & Me.IdFicha

            'ObjDatosAdicionalesDT.ExecuteSql(Strsql)

            'If ObjDatosAdicionalesDT.Count > 0 Then
            '    Me.txtInstitucionReferencia.Text = ObjDatosAdicionalesDT.ValueField("sNombreReferencia")
            '    Me.txtMontoReferencia.Text = Format(ObjDatosAdicionalesDT.ValueField("nMontoObtenido"), "#,##0.00")
            '    Me.txtPlazoReferencia.Text = ObjDatosAdicionalesDT.ValueField("nPlazo")
            '    Me.txtTipoPlazoReferencia.Text = ObjDatosAdicionalesDT.ValueField("sTipoPlazo")
            '    Me.txtFechaSolicitud.Text = Format(ObjDatosAdicionalesDT.ValueField("dFechaSolicitud"), "dd/MM/yyyy")
            '    Me.txtFechaCancelacion.Text = Format(ObjDatosAdicionalesDT.ValueField("dFechaCancelacion"), "dd/MM/yyyy")
            '    Me.chkReferenciaSi.Checked = True
            '    Me.chkReferenciaNo.Checked = False
            'Else
            '    Me.chkReferenciaSi.Checked = False
            '    Me.chkReferenciaNo.Checked = True
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjDatosAdicionalesDT.Close()
            ObjDatosAdicionalesDT = Nothing
        End Try
    End Sub
    Private Sub rptSclFichaVerificacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
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
            'Me.txtFechaVerificacion.DataField = "dFechaInscripcion"
            Me.txtDistrito.DataField = "sNombreDistrito"
            Me.txtNombreApellidos.DataField = "sNombreSocia"
            Me.txtEdad.DataField = "nEdadAnios"
            'Me.chkAlfabetizada.DataField = "nAlfabetizada"
            Me.txtCedula.DataField = "sNumeroCedula"
            Me.txtDireccion.DataField = "sDireccionSociaVerificada"
            Me.txtTelefono.DataField = "sTelefonoSociaVerificado"
            Me.txtBarrio.DataField = "sNombreBarrio"
            Me.txtMunicipio.DataField = "sNombreMunicipio"
            Me.txtDepartamento.DataField = "sNombreDepartamento"
            'Me.txtPrimaria.DataField = "sPrimaria"
            'Me.txtSecundaria.DataField = "sSecundaria"
            'Me.txtCarreraTecnica.DataField = "sCarreraTecnica"
            'Me.txtOtrosEstudios.DataField = "sOtrosEstudios"
            'Me.txtNumHijosVivos.DataField = "nNumHijosVivos"
            'Me.txtNumHijosDependientes.DataField = "nNumHijosDependientes"
            Me.chkSiNegocioActual.DataField = "nTieneNegocioVerificado"
            Me.txtTipoNegocioActual.DataField = "sTipoNegocio"
            Me.txtTipoNegocioPropuesto.DataField = "sTipoNegocio"
            Me.txtDireccionNegocio.DataField = "sDireccionNegocioVerificada"
            Me.txtFechaApertura.DataField = "dFechaAperturaNegocioVerificada"
            Me.txtMontoVentas.DataField = "nPromedioVentasVerificado"
            Me.txtTipoPlazoVentas.DataField = "sTipoPlazoVentas"
            Me.txtMontoPrestamo.DataField = "nMontoCreditoVerificado"
            Me.txtPlazoPrestamo.DataField = "nPlazoVerificado"
            Me.txtGrupoSolidario.DataField = "sNombreGrupo"
            Me.chkDispuestaSi.DataField = "nDispuestaFormarGS"
            Me.txtTipoPlazoPrestamo.DataField = "sTipoPlazoPrestamo"
            Me.txtObservaciones.DataField = "sObservacionesVerificacion"
            Me.txtFechaVerificacion.DataField = "dFechaHoraVerificacion"
            Me.txtNombreRepresentante.DataField = "sPersonaPrograma"
            Me.txtConoceSocias.DataField = "sSociasConocidas"

            'Me.chkNoNegocioActual.DataField = Not Me.chkSiNegocioActual.DataField
            Me.txtSclGrupoSolidarioID.DataField = "nSclGrupoSolidarioID"

            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'ObjSociasGrupo = New srptSclSociasGrupo
        'ObjSociasGrupo.IdGrupoSolidario = CInt(Me.txtSclGrupoSolidarioID.Text)
        'Me.srptSociasGrupo.Report = ObjSociasGrupo
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

        'If Me.chkDispuestaSi.Checked = True Then
        '    Me.chkDispuestaNo.Checked = False
        'Else
        '    Me.chkDispuestaNo.Checked = True
        'End If

        Me.txtFechaVerificacion.Text = Format(Me.txtFechaVerificacion.Value, "dd/MM/yyyy")

        If Not Me.txtFechaApertura.Value Is DBNull.Value Then
            Me.txtFechaApertura.Text = Format(Me.txtFechaApertura.Value, "dd/MM/yyyy")
        End If

        Me.txtMontoPrestamo.Text = Format(Me.txtMontoPrestamo.Value, "#,##0.00")

    End Sub
End Class
