Public Class FrmSccParametrosRecibosPorNumero
    Public Enum EnumReportes
        PorNumero = 1
        RecibosArqueados = 2
        RecibosAnulados = 3
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

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            If ValidaDatosEntrada() Then

                frmVisor.WindowState = FormWindowState.Maximized
                Select Case mNomRep
                    Case EnumReportes.PorNumero
                        frmVisor.NombreReporte = "RepSccCC20.rpt"
                        frmVisor.Text = "Listado de Recibos de Caja "
                        frmVisor.WindowState = FormWindowState.Maximized
                        frmVisor.Formulas("Parametros") = "' Recibos del  " & Me.txtReciboIni.Text & " Al " & txtReciboFin.Text & "'"
                        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                        frmVisor.Parametros("@ReciboIni") = Val(txtReciboIni.Text)
                        frmVisor.Parametros("@ReciboFin") = Val(txtReciboFin.Text)

                    Case EnumReportes.RecibosArqueados
                        frmVisor.NombreReporte = "RepSteTE16.rpt"
                        frmVisor.Text = "Listado de Recibos Arqueados"
                        frmVisor.WindowState = FormWindowState.Maximized
                        frmVisor.Formulas("RangoRecibos") = "' Recibos del  " & Me.txtReciboIni.Text & " Al " & txtReciboFin.Text & "'"
                        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                        

                        'Para el Tipo de Programa:
                        If CboPrograma.SelectedIndex > 0 Then
                            frmVisor.SQLQuery = " Select * " & _
                                                " From vwSteArqueoRecibosRep " & _
                                                " WHERE (nStbTipoProgramaID = " & Me.CboPrograma.Columns("nStbValorCatalogoID").Value & ") And (NoRecibo between " & Val(txtReciboIni.Text) & " and " & Val(txtReciboFin.Text) & ") " & _
                                                " Order by nStbTipoProgramaID, nSteArqueoCajaID, NoRecibo "
                        Else
                            frmVisor.SQLQuery = " Select * " & _
                                                " From vwSteArqueoRecibosRep " & _
                                                " WHERE (NoRecibo between " & Val(txtReciboIni.Text) & " and " & Val(txtReciboFin.Text) & ") " & _
                                                " Order by nStbTipoProgramaID, nSteArqueoCajaID, NoRecibo "
                        End If



                    Case EnumReportes.RecibosAnulados
                        frmVisor.NombreReporte = "RepSteTE30.rpt"
                        frmVisor.Text = "Consulta de Recibos Anulados (No Arqueados)"
                        frmVisor.WindowState = FormWindowState.Maximized
                        frmVisor.Formulas("RangoRecibos") = "' Recibos del  " & Me.txtReciboIni.Text & " Al " & txtReciboFin.Text & "'"
                        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                        'Para el Tipo de Programa:
                        If CboPrograma.SelectedIndex > 0 Then
                            frmVisor.SQLQuery = " Select * " & _
                                                " From vwSteRecibosAnulados " & _
                                                " WHERE (nStbTipoProgramaID = " & Me.CboPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                                                " And (nCodigo between " & Val(txtReciboIni.Text) & " and " & Val(txtReciboFin.Text) & ") " & _
                                                " Order by nStbTipoProgramaID, nStbDepartamentoID, Cajero, nCodigo "
                        Else
                            frmVisor.SQLQuery = " Select * " & _
                                                " From vwSteRecibosAnulados " & _
                                                " WHERE (nCodigo between " & Val(txtReciboIni.Text) & " and " & Val(txtReciboFin.Text) & ") " & _
                                                " Order by nStbTipoProgramaID, nStbDepartamentoID, Cajero, nCodigo "
                        End If

                        

                End Select

                frmVisor.ShowDialog()
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
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Número de Recibo Inicial:
            If Not Val(Me.txtReciboIni.Text) >= 1 Then
                MsgBox("El Recibo Inicial tiene que ser igual o mayor que uno.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtReciboIni, "El Recibo Inicial tiene que ser igual o mayor que uno.")
                Me.txtReciboIni.Focus()
                Exit Function
            End If


            If Not Val(Me.txtReciboFin.Text) >= 1 Then
                MsgBox("El Recibo Final tiene que ser igual o mayor que uno.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtReciboFin, "El Recibo Final tiene que ser igual o mayor que uno.")
                Me.txtReciboFin.Focus()
                Exit Function
            End If

            If Not Val(Me.txtReciboFin.Text) >= Val(Me.txtReciboIni.Text) Then
                MsgBox("El Recibo Final tiene que ser igual o mayor que el inicial.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtReciboFin, "El Recibo Final tiene que ser igual o mayor que el inicial.")
                Me.txtReciboFin.Focus()
                Exit Function
            End If


            'Tipo de Programa: 
            If Me.CboPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Programa válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.CboPrograma, "Debe seleccionar un Programa válido.")
                Me.CboPrograma.Focus()
                Exit Function
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub FrmSccParametrosRecibosPorNumero_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSccParametrosRecibosPorNumero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            If mNomRep = EnumReportes.PorNumero Then
                ObjGUI.SetFormLayout(Me, "Verde")
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
            ElseIf mNomRep = EnumReportes.RecibosArqueados Then
                ObjGUI.SetFormLayout(Me, "Naranja")
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Tesorería")
            ElseIf mNomRep = EnumReportes.RecibosAnulados Then
                ObjGUI.SetFormLayout(Me, "Naranja")
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Tesorería")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            XdsCombos = New BOSistema.Win.XDataSet

            'InicializaVariables()
            REM QUITAR RPTS QUE TENGAN FILTRO POR TIPO DE PROGRAMA:
            'Si no tiene filtro por Tipo de Programa:
            If (Me.NomRep = EnumReportes.PorNumero) Then
                Me.CboPrograma.Visible = False
                Me.lblPrograma.Visible = False
            End If
            CargarTipoPrograma()

            'CargarRecibo("A%")
            'Seguridad()

            ''Me.toolRefrescar.Enabled = False
            'Me.toolRefrescarM.Enabled = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/01/2010
    ' Procedure Name:       CargarTipoPrograma
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Programas.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPrograma()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion, 1 as Orden " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoDePrograma')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsCombos.ExistTable("Programa") Then
                XdsCombos("Programa").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Programa")
                XdsCombos("Programa").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboPrograma.DataSource = XdsCombos("Programa").Source

            Me.CboPrograma.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("Orden").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.CboPrograma.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.CboPrograma.Columns("sCodigoInterno").Caption = "Código"
            Me.CboPrograma.Columns("sDescripcion").Caption = "Descripción"

            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboPrograma.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboPrograma.ListCount > 0 Then
                XdsCombos("Programa").AddRow()
                XdsCombos("Programa").ValueField("sDescripcion") = "Todos"
                XdsCombos("Programa").ValueField("nStbValorCatalogoID") = -19
                XdsCombos("Programa").ValueField("Orden") = 0
                XdsCombos("Programa").UpdateLocal()
                XdsCombos("Programa").Sort = "Orden, sCodigoInterno asc"
                Me.CboPrograma.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


End Class