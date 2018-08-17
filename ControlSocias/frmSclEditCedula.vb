' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditSocia.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Socias.
'-------------------------------------------------------------------------
Public Class frmSclEditCedula

    '-- Declaracion de Variables 
    'Dim ModoForm As String 'ADD/MOD
    Dim IdSclFichaNotificacion As Integer 'SclSocia.nSclSociaID
    Dim IDSclPersonaLugarPagosID As Integer
    Dim IdSclConsultarDelegacion As Integer
    Dim IdnStbTipoProgramaID As Integer
    Dim IdnStbTipoPlazoPagosID As Integer
    Dim XdtDatos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDatos2 As BOSistema.Win.XDataSet.xDataTable

    Dim XContadorReg As Integer
    Dim IDSccTipoRecibo As Integer
    'Dim strConsulta As String

    'Dim StrFecha As String

    ''-- Clases para procesar la informacion de los combos
    'Dim XdtEstadoCivil As BOSistema.Win.XDataSet.xDataTable
    'Dim XdtDocumento As BOSistema.Win.XDataSet.xDataTable
    'Dim XdsEscolaridad As BOSistema.Win.XDataSet
    'Dim XdsUbicacion As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    'Dim ObjSociadt As BOSistema.Win.SclEntSocia.SclSociaDataTable
    'Dim ObjSociadr As BOSistema.Win.SclEntSocia.SclSociaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    'Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    'Public Property ModoFrm() As String
    '    Get
    '        ModoFrm = ModoForm
    '    End Get
    '    Set(ByVal value As String)
    '        ModoForm = value
    '    End Set
    'End Property

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
    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdPersonaLugarPagosID() As Integer
        Get
            IdPersonaLugarPagosID = IDSclPersonaLugarPagosID
        End Get
        Set(ByVal value As Integer)
            IDSclPersonaLugarPagosID = value
        End Set
    End Property
    'Tipo de Ingreso del Recibo (Manual o Automático)
    Public Property IdTipoRecibo() As Integer
        Get
            IdTipoRecibo = IDSccTipoRecibo
        End Get
        Set(ByVal value As Integer)
            IDSccTipoRecibo = value
        End Set
    End Property


    Public Property IdFichaNotificacion() As Integer
        Get
            IdFichaNotificacion = IdSclFichaNotificacion
        End Get
        Set(ByVal value As Integer)
            IdSclFichaNotificacion = value
        End Set
    End Property
    Public Property nStbTipoProgramaID() As Integer
        Get
            nStbTipoProgramaID = IdnStbTipoProgramaID
        End Get
        Set(ByVal value As Integer)
            IdnStbTipoProgramaID = value
        End Set
    End Property
    Public Property nStbTipoPlazoPagosID() As Integer
        Get
            nStbTipoPlazoPagosID = IdnStbTipoPlazoPagosID
        End Get
        Set(ByVal value As Integer)
            IdnStbTipoPlazoPagosID = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditSocia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtDatos.Close()
                XdtDatos = Nothing
                'ObjSociadt.Close()
                'ObjSociadt = Nothing

                'ObjSociadr.Close()
                'ObjSociadr = Nothing

                'XdtEstadoCivil.Close()
                'XdtEstadoCivil = Nothing

                'XdtDocumento.Close()
                'XdtDocumento = Nothing

                'XdsEscolaridad.Close()
                'XdsEscolaridad = Nothing

                'XdsUbicacion.Close()
                'XdsUbicacion = Nothing

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSocia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            'Ruta Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            'If ModoFrm = "UPD" Then
            '    CargarSocia()
            '    InhabilitarControles()
            'Else 'ADD.
            'End If

            If Me.IdTipoRecibo = 2 Then  'Manual
                Me.ChkTipoBusqueda.Checked = False
                Me.TxtPrimerNombre.Select()
            Else
                Me.mtbNumCedula.Select()
            End If
            'vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

            'If Me.IdPersonaLugarPagosID = 0 Then
            '    MsgBox("Cajero NO tiene Caja asociada.", MsgBoxStyle.Critical, NombreSistema)
            '    Me.Close()
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    'Private Sub InhabilitarControles()
    '    Try
    '        'Si la Socia esta Inactiva:
    '        If ObjSociadr.nSociaActiva = 0 Then
    '            Me.cmdAceptar.Enabled = False
    '            Me.grpSociaGe.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            'If ModoFrm = "ADD" Then
            '    Me.Text = "Agregar Socia"
            'Else
            '    Me.Text = "Modificar Socia"
            'End If

            'XdtEstadoCivil = New BOSistema.Win.XDataSet.xDataTable
            'XdtDocumento = New BOSistema.Win.XDataSet.xDataTable
            'XdsEscolaridad = New BOSistema.Win.XDataSet
            'XdsUbicacion = New BOSistema.Win.XDataSet

            'ObjSociadt = New BOSistema.Win.SclEntSocia.SclSociaDataTable
            'ObjSociadr = New BOSistema.Win.SclEntSocia.SclSociaRow

            'If ModoFrm = "ADD" Then
            'ObjSociadr = ObjSociadt.NewRow
            'Inicializar los Length de los campos (Strings)
            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            XdtDatos2 = New BOSistema.Win.XDataSet.xDataTable
            Me.mtbNumCedula.MaxLength = 16    'ObjSociadr.GetColumnLenght("sNumeroCedula")
            Me.grpBotones.Enabled = False
            Me.ChkTipoBusqueda.Checked = True
            'End If
            XContadorReg = 0
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    'Private Sub CargarSocia()
    '    'Dim IdMunicipio As Long
    '    'Dim IdDepartamento As Long
    '    'Dim XcUbicacion As New BOSistema.Win.XComando
    '    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable

    '    Try
    '        Dim strSQL As String
    '        Me.errSocia.Clear()

    '        strSQL = " Select nSclFichaNotificacionID " & _
    '                 " From vwSclSociaCedula " & _
    '                 " Where sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"

    '        XdtDatos.ExecuteSql(strSQL)

    '        If XdtDatos.Count = 0 Then
    '            MsgBox("Socia NO Encontrada.", MsgBoxStyle.Critical, NombreSistema)
    '            Me.errSocia.SetError(Me.mtbNumCedula, "Socia NO Encontrada.")
    '            Me.mtbNumCedula.Focus()
    '        Else

    '        End If

    '        '-- Buscar la Socia correspondiente al Id especificado
    '        '-- como parámetro, en los casos que se esté editando una.
    '        'ObjSociadt.Filter = "nSclSociaID = " & IdSocia
    '        'ObjSociadt.Retrieve()
    '        'If ObjSociadt.Count = 0 Then 'No hay socias registradas (ADD).
    '        '    Exit Sub
    '        'End If
    '        'ObjSociadr = ObjSociadt.Current 'Socia actual.

    '        ''Inicializar los Length de los campos
    '        'Me.mtbNumCedula.MaxLength = ObjSociadr.GetColumnLenght("sNumeroCedula")

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XdtDatos.Close()
    '        XdtDatos = Nothing
    '        '    XcUbicacion.Close()
    '        '    XcUbicacion = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            'If ValidaDatosEntrada() Then
            '    'CargarSocia()
            '    AccionUsuario = AccionBoton.BotonAceptar
            '    Me.Close()
            'End If

            'If ValidaDatosEntrada() Then
            'CargarSocia()
            AccionUsuario = AccionBoton.BotonAceptar
            Me.Close()

            'End If


        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtDatos.Close()
            '    XdtDatos = Nothing
        End Try
    End Sub

    'Private Function EnListaPagoAlterno(XdtDatos.ValueField("nStbPersonaLugarPagosID"), Me.IdPersonaLugarPagosID)  as boolean 
    Private Function EnListaPagoAlterno(nStbPersonaLugarPagosID As Integer, IdPersonaLugarPagosID As Integer) As Boolean


        Dim XdtTmp As BOSistema.Win.XDataSet.xDataTable

        XdtTmp = New BOSistema.Win.XDataSet.xDataTable

        XdtTmp.ExecuteSql("SELECT        nStbPersonaLugarPagosAlternoID, nActiva        FROM dbo.StbPersonaLugarPagosAlterno WHERE        (nStbPersonaLugarPagosID = " & IdPersonaLugarPagosID & ") AND (nStbPersonaLugarPagosVieneID = " & nStbPersonaLugarPagosID & ") AND (nActiva = 1)")
        If XdtTmp.Count > 0 Then
            Return True
        End If

        Return False

    End Function


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        'Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaDataTable
        'Dim ObjSclGS As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
        'Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            Dim cadWhere As String = ""
            Dim nContador As Integer = 0
            Dim nSclFichaNotificacionID As Integer
            Dim nStbTipoProgramaID As Integer
            Dim IdCaja As Integer
            ValidaDatosEntrada = True
            Me.errSocia.Clear()
            If ChkTipoBusqueda.Checked Then
                'Número de Cédula Obligatorio:
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

            Else

                If Trim(Me.TxtPrimerNombre.Text) = "" Then
                    nContador = nContador + 1
                End If

                If Trim(Me.TxtSegundoNombre.Text) = "" Then
                    nContador = nContador + 1
                End If

                If Trim(Me.TxtPrimerApellido.Text) = "" Then
                    nContador = nContador + 1
                End If

                If Trim(Me.TxtSegundoApellido.Text) = "" Then
                    nContador = nContador + 1
                End If

                'If Trim(Me.TxtPrimerNombre.Text) = "" And Trim(Me.TxtSegundoNombre.Text) = "" And Trim(Me.TxtPrimerApellido.Text) = "" And Trim(Me.TxtSegundoApellido.Text) = "" Then
                If nContador > 2 Then
                    MsgBox("Debe indicar al menos Dos Criterios de búsqueda.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.TxtPrimerNombre, "Debe indicar al menos DOS Criterios de búsqueda.")
                    Me.TxtPrimerNombre.Focus()
                    Exit Function
                End If
            End If

            If Me.IdTipoRecibo = 1 Then  'Automático
                If Me.IdPersonaLugarPagosID = 0 Then
                    MsgBox("Cajero NO tiene Caja asociada.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "Cajero NO tiene Caja asociada.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

            End If

            'Usuario unicamente puede Consultar Socias de su Delegación:
            If Me.IdSclConsultarDelegacion <> 1 Then
                If Trim(cadWhere) = "" Then
                    cadWhere = " Where (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                Else
                    cadWhere = cadWhere & " And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                End If
            End If

            If Me.IdTipoRecibo = 1 Then  'Automático

                'dd()
                'XdtDatos2.ExecuteSql("SELECT  nSclFichaNotificacionID from  vwSclSociaCedula Where ")
                Dim ContadorReg As Integer = 0
                Dim CadCondicion As String = ""
                XdtDatos2.ExecuteSql("SELECT        nStbPersonaLugarPagosVieneID  FROM dbo.StbPersonaLugarPagosAlterno WHERE        (nStbPersonaLugarPagosID = " & IdPersonaLugarPagosID & ")  AND (nActiva = 1)")
                If XdtDatos2.Count > 0 Then
                    While ContadorReg < XdtDatos2.Count
                        CadCondicion = CadCondicion & " Or  nStbPersonaLugarPagosID= " & XdtDatos2.ValueField("nStbPersonaLugarPagosVieneID")
                        XdtDatos2.Source.MoveNext()
                        ContadorReg = ContadorReg + 1
                    End While

                End If


                'Cambios para filtrar por varios lugares de pagos

                If Trim(cadWhere) = "" Then
                    cadWhere = " Where (nStbPersonaLugarPagosID=" & Me.IdPersonaLugarPagosID & CadCondicion & " )  And nStbTipoProgramaID= " & Me.nStbTipoProgramaID & " And  nStbTipoPlazoPagosID= " & Me.nStbTipoPlazoPagosID
                Else
                    '***ORIGINAL****
                    cadWhere = cadWhere & " And (nStbPersonaLugarPagosID=" & Me.IdPersonaLugarPagosID & CadCondicion & " )  And nStbTipoProgramaID= " & Me.nStbTipoProgramaID & " And  nStbTipoPlazoPagosID= " & Me.nStbTipoPlazoPagosID


                    ' ''***OJO PARA BUSCAR SOCIAS CANCELADA****
                    'cadWhere = cadWhere & " And nStbPersonaLugarPagosID=" & Me.IdPersonaLugarPagosID & " And nStbTipoProgramaID= " & Me.nStbTipoProgramaID & " AND  nsclfichanotificacionid=33826 and nStbTipoPlazoPagosID= " & Me.nStbTipoPlazoPagosID

                    'cadWhere = "where nStbPersonaLugarPagosID=" & Me.IdPersonaLugarPagosID & " And nStbTipoProgramaID= " & Me.nStbTipoProgramaID & " AND  nsclfichanotificacionid=39055 and nStbTipoPlazoPagosID= " & Me.nStbTipoPlazoPagosID
                    '*********************
                End If



            End If

            If ChkTipoBusqueda.Checked Then

                If Me.IdTipoRecibo = 3 Then
                    strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                             " From vwSclCedulaSociaCancelada " & _
                             " Where sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" & _
                             " order by nSclFichaNotificacionID desc"
                Else
                    strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                             " From vwSclSociaCedula " & _
                             " Where sCodFuente <> '93' And sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"

                    '***ORIGINAL*****
                    'strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                    '" From vwSclSociaCedula "



                    '*****************************
                    ''****OJO PRUEBA DE IMPRESION DE RECIBO CANCELADO   FECHA:15-06-2011******
                    'strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                    '" From vwSclSociaCedula1 "

                    'strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID  From vwSclSociaCedula1 where nStbPersonaLugarPagosID=1210 And nStbTipoProgramaID= 557 AND  nsclfichanotificacionid=33826 and nStbTipoPlazoPagosID= 46 And sCodFuente <> '93' And sCodFuente <> '94' And sNumeroCedula = '044-021178-0002U'"

                    '*****
                    'If Trim(cadWhere) = "" Then
                    '    cadWhere = " Where sCodFuente <> '93' And sCodFuente <> '94' And sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"
                    'Else
                    '    cadWhere = cadWhere & " And sCodFuente <> '93' And sCodFuente <> '94' And sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"
                    'End If

                    'strSQL = strSQL & cadWhere
                    '***
                End If
            Else
                'If Me.IdTipoRecibo = 1 Then  'Automático
                '    If Trim(cadWhere) = "" Then
                '        cadWhere = " Where nStbPersonaLugarPagosID=" & Me.IdPersonaLugarPagosID
                '    Else
                '        cadWhere = cadWhere & " And nStbPersonaLugarPagosID=" & Me.IdPersonaLugarPagosID
                '    End If
                'End If

                If Trim(Me.TxtPrimerNombre.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "'"
                    End If
                End If

                If Trim(Me.TxtSegundoNombre.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "'"
                    End If
                End If

                If Trim(Me.TxtPrimerApellido.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "'"
                    End If
                End If

                If Trim(Me.TxtSegundoApellido.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "'"
                    End If
                End If

                If Me.IdTipoRecibo = 3 Then
                    strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                             " From vwSclCedulaSociaCancelada " & cadWhere & _
                             " order by nSclFichaNotificacionID desc"
                Else
                    'Que no sea CARUNA
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sCodFuente <> '93' "
                    Else
                        cadWhere = cadWhere & " And sCodfuente <> '93' "
                    End If

                    strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                                             " From vwSclSociaCedula " & cadWhere
                End If

            End If

            XContadorReg = 0

            '***ojo para que imprima un regsitro con la cedula especifica****  
            'strSQL = "Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID  From vwSclSociaCedula where sNumeroCedula='561-110569-0002Q' "
            '***************

            XdtDatos.ExecuteSql(strSQL)

            If Me.IdTipoRecibo <> 1 Then  'Manual

                If ChkTipoBusqueda.Checked Then
                    grpBotones.Enabled = False
                    If XdtDatos.Count = 0 Then
                        MsgBox("Socia NO Encontrada.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "Socia NO Encontrada.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Else
                        Me.IdFichaNotificacion = XdtDatos.ValueField("nSclFichaNotificacionID")
                        Me.txtGrupoSolidario.Text = XdtDatos.ValueField("sNombreGrupo")
                        Me.txtNombreSocia.Text = XdtDatos.ValueField("sNombreSocia")
                        'LblConteo.Text = ""
                        grpBotones.Enabled = True
                        PresentaSocia()

                    End If
                Else
                    If XdtDatos.Count = 0 Then
                        MsgBox("No se encontraron socias con ese criterio.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.TxtPrimerNombre, "No se encontraron socias con ese criterio.")
                        Me.TxtPrimerNombre.Focus()
                        Exit Function
                    Else
                        grpBotones.Enabled = True
                        PresentaSocia()
                    End If

                End If
            Else
                If ChkTipoBusqueda.Checked Then
                    grpBotones.Enabled = False
                    If XdtDatos.Count = 0 Then
                        MsgBox("Socia NO Encontrada.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "Socia NO Encontrada.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Else
                        If XdtDatos.ValueField("nStbPersonaLugarPagosID") = Me.IdPersonaLugarPagosID Or EnListaPagoAlterno(XdtDatos.ValueField("nStbPersonaLugarPagosID"), Me.IdPersonaLugarPagosID) Then

                            nSclFichaNotificacionID = XdtDatos.ValueField("nSclFichaNotificacionID")

                            strSQL = " SELECT a.nSteCajaID,b.nCodigo , a.nStbTipoProgramaID" & _
                                     " FROM vwSclCajaCajero a " & _
                                     " INNER JOIN SteCaja b " & _
                                     " ON a.nSteCajaID = b.nSteCajaID " & _
                                     " WHERE a.ssgCuentaID = " & InfoSistema.IDCuenta & _
                                     " AND a.nActiva = 1 AND (b.nCerrada = 0) "

                            XdtDatos2.ExecuteSql(strSQL)

                            If XdtDatos2.Count > 0 Then
                                IdCaja = XdtDatos2.ValueField("nSteCajaID")
                                nStbTipoProgramaID = XdtDatos2.ValueField("nStbTipoProgramaID")
                                strSQL = " SELECT     nStbTipoProgramaID, nSclFichaNotificacionID  FROM         dbo.vwSccDetalleCreditosPrograma WHERE     nSclFichaNotificacionID = " & nSclFichaNotificacionID
                                XdtDatos2.ExecuteSql(strSQL)
                                If XdtDatos2.Count > 0 Then
                                    If XdtDatos2.ValueField("nStbTipoProgramaID") <> nStbTipoProgramaID Then
                                        MsgBox("Socia tiene asociado diferente tipo de programa al que tiene la caja.", MsgBoxStyle.Critical, NombreSistema)
                                        ValidaDatosEntrada = False
                                        Me.errSocia.SetError(Me.mtbNumCedula, "Socia tiene asociado diferente tipo de programa al que tiene la caja.")
                                        Me.mtbNumCedula.Focus()
                                        Exit Function
                                    End If
                                Else
                                    MsgBox("No se encontro la Ficha Notificacion.", MsgBoxStyle.Critical, NombreSistema)
                                    ValidaDatosEntrada = False
                                    Me.errSocia.SetError(Me.mtbNumCedula, "No se encontro la Ficha Notificacion.")
                                    Me.mtbNumCedula.Focus()
                                    Exit Function


                                End If



                            Else
                                MsgBox("Cajero no tiene caja asociada.", MsgBoxStyle.Critical, NombreSistema)
                                ValidaDatosEntrada = False
                                Me.errSocia.SetError(Me.mtbNumCedula, "Cajero no tiene caja asociada.")
                                Me.mtbNumCedula.Focus()
                                Exit Function
                            End If




                            Me.IdFichaNotificacion = XdtDatos.ValueField("nSclFichaNotificacionID")
                            Me.txtGrupoSolidario.Text = XdtDatos.ValueField("sNombreGrupo")
                            Me.txtNombreSocia.Text = XdtDatos.ValueField("sNombreSocia")
                            LblConteo.Text = ""
                        Else
                            MsgBox("Socia NO pertenece a esta Caja.", MsgBoxStyle.Critical, NombreSistema)
                            ValidaDatosEntrada = False
                            Me.errSocia.SetError(Me.mtbNumCedula, "Socia NO pertenece a esta Caja.")
                            Me.mtbNumCedula.Focus()
                            Exit Function
                        End If

                    End If
                Else
                    If XdtDatos.Count = 0 Then
                        MsgBox("No se encontraron socias con ese criterio.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.TxtPrimerNombre, "No se encontraron socias con ese criterio.")
                        Me.TxtPrimerNombre.Focus()
                        Exit Function
                    Else
                        grpBotones.Enabled = True
                        PresentaSocia()
                    End If
                End If
            End If

            ''NO validar Número de Cédula si no corresponde a Formato:
            ''Y establecer como fecha de nacimiento: 30/05/1964
            'If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
            '    StrFecha = "30/05/1964"
            'Else
            '    'Número de Cédula Válido:
            '    Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
            '        Case Cedula.Invalida
            '            MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
            '            ValidaDatosEntrada = False
            '            Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia es invalido.")
            '            Me.mtbNumCedula.Focus()
            '            Exit Function
            '        Case Cedula.LongitudIncorrecta
            '            MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
            '            ValidaDatosEntrada = False
            '            Me.errSocia.SetError(Me.mtbNumCedula, "La Longitud del Número de Cédula de la Socia es incorrecta.")
            '            Me.mtbNumCedula.Focus()
            '            Exit Function
            '    End Select
            '    'Fecha válida en número de Cédula:
            '    StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
            '    If Not IsDate(StrFecha) Then
            '        MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula debe contener una fecha válida.")
            '        Me.mtbNumCedula.Focus()
            '        Exit Function
            '    End If
            '    'Determinar Duplicados en el Número de Cédula:
            '    If ModoFrm = "UPD" Then
            '        ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSclSociaID <> " & IdSocia
            '    Else
            '        ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"
            '    End If
            '    ObjTmpSocia.Retrieve() 'Obtener los datos filtrados.
            '    If ObjTmpSocia.Count > 0 Then
            '        MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula NO DEBE repetirse.")
            '        Me.mtbNumCedula.Focus()
            '        Exit Function
            '    End If
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjTmpSocia.Close()
            'ObjTmpSocia = Nothing

            'ObjSclGS.Close()
            'ObjSclGS = Nothing

            'XdtDatos.Close()
            'XdtDatos = Nothing
        End Try
    End Function

    Private Sub PresentaSocia()
        Me.IdFichaNotificacion = XdtDatos.Table.Rows(XContadorReg).Item("nSclFichaNotificacionID")
        Me.txtGrupoSolidario.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNombreGrupo")
        Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNombreSocia")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    'Private Sub SalvarSocia()
    '    Dim ObjTmpSocia As New BOSistema.Win.XDataSet
    '    Try
    '        Dim strSQL As String

    '        'Asignar el Id de la Socia a la variable publica del formulario:
    '        IdSclSocia = ObjSociadr.nSclSociaID
    '        '--------------------------------

    '        'Si el salvado se realizó de forma satisfactoria
    '        'enviar mensaje informando y cerrar el formulario.
    '        If ModoFrm = "ADD" Then
    '            MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
    '        Else
    '            MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjTmpSocia.Close()
    '        ObjTmpSocia = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
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
            '                SalvarSocia()
            '                AccionUsuario = AccionBoton.BotonAceptar
            '                Me.Close()
            '            Else
            '                AccionUsuario = AccionBoton.BotonNinguno
            '            End If

            '        Case vbNo
            '            AccionUsuario = AccionBoton.BotonCancelar
            '            Me.Close()

            '        Case vbCancel
            '            AccionUsuario = AccionBoton.BotonNinguno
            '    End Select
            'Else
            Me.IdFichaNotificacion = 0
            AccionUsuario = AccionBoton.BotonCancelar
            Me.Close()
            'End If
        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtDatos.Close()
            '    XdtDatos = Nothing
        End Try
    End Sub

    'Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
    '    vbModifico = True
    'End Sub


    Private Sub ChkTipoBusqueda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTipoBusqueda.CheckedChanged
        If ChkTipoBusqueda.Checked Then
            Me.TxtPrimerNombre.Text = ""
            Me.TxtSegundoNombre.Text = ""
            Me.TxtPrimerApellido.Text = ""
            Me.TxtSegundoApellido.Text = ""
            Me.grpBotones.Enabled = False
            Me.mtbNumCedula.Enabled = True
            Me.GrpNombreCompleto.Enabled = False
            Me.mtbNumCedula.Select()

        Else
            Me.grpBotones.Enabled = True
            Me.mtbNumCedula.Enabled = False
            Me.GrpNombreCompleto.Enabled = True
            mtbNumCedula.Text = ""
            Me.TxtPrimerNombre.Select()
        End If
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        'Me.XdtDatos.Table.Rows(0)("ddd")
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = 0
        PresentaSocia()
    End Sub

    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSocia()
    End Sub

    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSocia()
    End Sub

    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSocia()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try

            ValidaDatosEntrada()

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub grpBotones_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpBotones.Enter

    End Sub
End Class