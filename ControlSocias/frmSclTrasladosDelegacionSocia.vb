' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                04/03/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclTrasladosDelegacionSocia.vb
' Descripci�n:          Este formulario permite realizar modificaciones 
'                       de Delegaci�n de Socias.
'-------------------------------------------------------------------------
Public Class frmSclTrasladosDelegacionSocia

    '- Declaraci�n de Variables 
    Dim XdtTraslado As BOSistema.Win.XDataSet.xDataTable
    Dim XdsDelegacion As BOSistema.Win.XDataSet

    Dim IdSclSociaD As Long 'SclSocia.nSclSociaID
    Dim IdSclDelegacion As Integer

    'Propiedad utilizada para obtener el ID de la Socia. 
    Public Property IdSociaD() As Long
        Get
            IdSociaD = IdSclSociaD
        End Get
        Set(ByVal value As Long)
            IdSclSociaD = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Delegaci�n Actual.
    Public Property IdDelegacion() As Long
        Get
            IdDelegacion = IdSclDelegacion
        End Get
        Set(ByVal value As Long)
            IdSclDelegacion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                04/03/2008
    ' Procedure Name:       frmSclTrasladosDelegacionSocia_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclTrasladosDelegacionSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtTraslado.Close()
            XdtTraslado = Nothing

            XdsDelegacion.Close()
            XdsDelegacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                04/03/2008
    ' Procedure Name:       frmSclTrasladosDelegacionSocia_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Fichas de Notificaci�n en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclTrasladosDelegacionSocia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicaci�n.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

            CargarDatosSocia()
            CargarDelegacionD()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                04/03/2008
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar variables.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtTraslado = New BOSistema.Win.XDataSet.xDataTable
            XdsDelegacion = New BOSistema.Win.XDataSet

            'Lugar de Pagos:
            Me.cboDelegacionD.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	04/03/2008
    ' Procedure name		   	:	CargarDelegacionO
    ' Description			   	:	Ubicar nombre de la Delegaci�n actual de la Socia.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarDatosSocia()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'C�digo y Nombre de la Socia:
            Strsql = "SELECT CONVERT(nvarchar(20), nCodigo) + ' - ' + sNombre1 + ' ' + sNombre2 + ' ' + sApellido1 + ' ' + sApellido2 AS Socia FROM SclSocia WHERE (nSclSociaID = " & IdSclSociaD & ")"
            txtSocia.Text = XcDatosD.ExecuteScalar(Strsql)

            'Nombre de la Delegaci�n Actual:
            Strsql = "SELECT sNombreDelegacion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & IdDelegacion & ")"
            txtDelegacion.Text = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                04/03/2008
    ' Procedure Name:       CargarDelegacionD
    ' Descripci�n:          Este procedimiento permite cargar el listado de 
    '                       Delegaciones Activas.
    '-------------------------------------------------------------------------
    Private Sub CargarDelegacionD()
        Try
            Dim Strsql As String
            Me.cboDelegacionD.ClearFields()

            Strsql = " SELECT a.nStbDelegacionProgramaID, a.nCodigo, a.sNombreDelegacion " & _
                     " From StbDelegacionPrograma a " & _
                     " WHERE (a.nActiva = 1) " & _
                     " Order by a.sNombreDelegacion"

            If XdsDelegacion.ExistTable("Delegacion") Then
                XdsDelegacion("Delegacion").ExecuteSql(Strsql)
            Else
                XdsDelegacion.NewTable(Strsql, "Delegacion")
                XdsDelegacion("Delegacion").Retrieve()
            End If

            'Asignando a las fuentes de datos Lugar Pagos Destino:  
            Me.cboDelegacionD.DataSource = XdsDelegacion("Delegacion").Source
            Me.cboDelegacionD.Rebind()
            Me.cboDelegacionD.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.cboDelegacionD.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDelegacionD.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.cboDelegacionD.Splits(0).DisplayColumns("sNombreDelegacion").Width = 150
            Me.cboDelegacionD.Columns("nCodigo").Caption = "C�digo"
            Me.cboDelegacionD.Columns("sNombreDelegacion").Caption = "Delegaci�n"
            Me.cboDelegacionD.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDelegacionD.Splits(0).DisplayColumns("sNombreDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                04/03/2008
    ' Procedure Name:       LlamaSalir
    ' Descripci�n:          Este procedimiento permite cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                04/03/2008
    ' Procedure Name:       CmdTrasladar_Click
    ' Descripci�n:          Este evento permite validar el traslado de lugar
    '                       de pagos y llamar al procedimiento para efectuar
    '                       la modificaci�n masiva.
    '-------------------------------------------------------------------------
    Private Sub CmdTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTrasladar.Click
        Dim XdtTrasladarSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            'Imposible si NO se indica Delegaci�n Destino:
            If Me.cboDelegacionD.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Delegaci�n.", MsgBoxStyle.Critical, NombreSistema)
                cboDelegacionD.Focus()
                Exit Sub
            End If

            'Imposible si Delegaci�n Destino es la misma Origen:
            If cboDelegacionD.Columns("nStbDelegacionProgramaID").Value = IdSclDelegacion Then
                MsgBox("Delegaci�n Destino DEBE ser difente a la Actual.", MsgBoxStyle.Information)
                cboDelegacionD.Focus()
                Exit Sub
            End If

            'Trasladar Delegaci�n de Socia: 
            If MsgBox("�Est� seguro de Trasladar a la socia de Delegaci�n?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XdtTrasladarSocia.ExecuteSqlNotTable("Update SclSocia SET dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "', nStbDelegacionProgramaID = " & cboDelegacionD.Columns("nStbDelegacionProgramaID").Value & " WHERE nSclSociaID = " & IdSclSociaD)
                MsgBox("El registro se modific� satisfactoriamente.", MsgBoxStyle.Information)
                Call GuardarAuditoria(4, 15, "Traslado de Delegaci�n de " & txtDelegacion.Text & " a " & cboDelegacionD.Text & " para la Socia " & txtSocia.Text & ".")
            End If
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTrasladarSocia.Close()
            XdtTrasladarSocia = Nothing
        End Try

    End Sub
End Class