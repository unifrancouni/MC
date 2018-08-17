' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                15/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditArqueoRecibo.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Documentos para un Arqueo de Caja.
'-------------------------------------------------------------------------
Public Class frmSteEditArqueoRecibo

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/UPD/DEL
    Dim IdSteArqueo As Integer
    Dim IdSteRecibo As Integer
    Dim nSteReciboMin As Integer
    Dim nSteReciboMax As Integer
    Dim nValidarTalonarios As Integer
    Dim nUltimoCodigo As Integer
    Dim StrCodTipoPrograma As String
    Dim IdTipoPrograma As Integer
    Dim IdTipoPlazoPagos As Integer
    Dim CodigoTalonario As Integer

    'Departamento de la caja
    Dim IdSteDepartamento As Integer
    'Departamento que atiende a la caja
    Dim IdSteDepartamentoAtiende As Integer
    'Municipio de la caja
    Dim IdSteMunicipio As String
    'Municipio de Valor Parametro
    Dim nMunicipioID As Integer
    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjRecibodt As BOSistema.Win.SteEntArqueo.SteArqueoReciboDataTable
    Dim ObjRecibodr As BOSistema.Win.SteEntArqueo.SteArqueoReciboRow

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property IdArqueo() As Integer
        Get
            IdArqueo = IdSteArqueo
        End Get
        Set(ByVal value As Integer)
            IdSteArqueo = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property nCodigoTalonario() As Integer
        Get
            nCodigoTalonario = CodigoTalonario
        End Get
        Set(ByVal value As Integer)
            CodigoTalonario = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property IdRecibo() As Integer
        Get
            IdRecibo = IdSteRecibo
        End Get
        Set(ByVal value As Integer)
            IdSteRecibo = value
        End Set
    End Property

    'Propiedad utilizada para obtener el Minimo Codigo de Recibo permitido 
    'de acuerdo con las Entregas de Recibos registradas.
    Public Property nReciboMin() As Integer
        Get
            nReciboMin = nSteReciboMin
        End Get
        Set(ByVal value As Integer)
            nSteReciboMin = value
        End Set
    End Property

    'Propiedad utilizada para obtener el Maximo Codigo de Recibo permitido 
    'de acuerdo con las Entregas de Recibos registradas.
    Public Property nReciboMax() As Integer
        Get
            nReciboMax = nSteReciboMax
        End Get
        Set(ByVal value As Integer)
            nSteReciboMax = value
        End Set
    End Property


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       frmSteEditArqueoRecibo_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditArqueoRecibo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjRecibodt.Close()
                ObjRecibodt = Nothing

                ObjRecibodr.Close()
                ObjRecibodr = Nothing

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
    ' Fecha:                15/01/2008
    ' Procedure Name:       frmSteEditArqueoRecibo_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditArqueoRecibo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm <> "ADD" Then
                CargarRecibo()
            End If

            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim XcDatosTP As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            Me.chkManual.Checked = True
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Documentos de Arqueo"
                Me.txtNumRecibo.Select()
                'Solo ADD Recibos Manuales:
                Me.chkManual.Enabled = False
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Documentos de Arqueo"
                Me.cneValor.Select()
                'Solo UPD Recibos Manuales:
                Me.chkManual.Enabled = False
            Else
                Me.Text = "Eliminar Documentos de Arqueo"
                lblValor.Visible = False
                cneValor.Visible = False
                Me.txtNumRecibo.Select()
                Me.chkManual.Enabled = True
            End If

            'Encuentra Tipo de Programa de la Caja del Arqueo:
            strSQL = "SELECT StbValorCatalogo.sCodigoInterno " & _
                     "FROM SteArqueoCaja INNER JOIN SteCaja ON SteArqueoCaja.nSteCajaID = SteCaja.nSteCajaID INNER JOIN StbValorCatalogo ON SteCaja.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SteArqueoCaja.nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            StrCodTipoPrograma = XcDatosTP.ExecuteScalar(strSQL)

            strSQL = "SELECT StbValorCatalogo.nStbValorCatalogoID " & _
                     "FROM SteArqueoCaja INNER JOIN SteCaja ON SteArqueoCaja.nSteCajaID = SteCaja.nSteCajaID INNER JOIN StbValorCatalogo ON SteCaja.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SteArqueoCaja.nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            IdTipoPrograma = XcDatosTP.ExecuteScalar(strSQL)

            strSQL = "SELECT SteCaja.nStbTipoPlazoPagosID " & _
                     "FROM SteArqueoCaja INNER JOIN SteCaja ON SteArqueoCaja.nSteCajaID = SteCaja.nSteCajaID " & _
                     "WHERE (SteArqueoCaja.nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            IdTipoPlazoPagos = XcDatosTP.ExecuteScalar(strSQL)

            ObjRecibodt = New BOSistema.Win.SteEntArqueo.SteArqueoReciboDataTable
            ObjRecibodr = New BOSistema.Win.SteEntArqueo.SteArqueoReciboRow

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosTP.Close()
            XcDatosTP = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CargarRecibo
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo()
        Dim ObjMinutaDT As New BOSistema.Win.SteEntTesoreria.SteMinutaDepositoDataTable
        Try

            '-- Buscar Documento de Recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjRecibodt.Filter = "nSteArqueoReciboID = " & Me.IdSteRecibo
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current

            'Número de Recibo:
            If Not ObjRecibodr.IsFieldNull("nCodigo") Then
                Me.txtNumRecibo.Text = ObjRecibodr.nCodigo
            Else
                Me.txtNumRecibo.Text = ""
            End If

            'Número de Recibo Hasta
            If Not ObjRecibodr.IsFieldNull("nCodigo") Then
                Me.txtHastaRecibo.Text = ObjRecibodr.nCodigo
            Else
                Me.txtHastaRecibo.Text = ""
            End If

            'Monto del Recibo:
            If ModoForm = "UPD" Then
                If Not ObjRecibodr.IsFieldNull("nValor") Then
                    Me.cneValor.Value = ObjRecibodr.nValor
                Else
                    Me.cneValor.Value = 0
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjMinutaDT.Close()
            ObjMinutaDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarRecibo()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatosV As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
          
            'Dim nManual As Integer

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Número de Recibo (Desde):
            If Trim(RTrim(Me.txtNumRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo Inicial NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNumRecibo, "El Número del Recibo Inicial NO DEBE quedar vacío.")
                Me.txtNumRecibo.Focus()
                Exit Function
            End If

            'Número de Recibo (Hasta):
            If Trim(RTrim(Me.txtHastaRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtHastaRecibo, "El Número del Recibo Final NO DEBE quedar vacío.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'Número de Recibo (Hasta) mayor: 
            If CInt(Me.txtHastaRecibo.Text) < CInt(Me.txtNumRecibo.Text) Then
                MsgBox("El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo Inicial.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtHastaRecibo, "El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo Inicial.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'Monto del Recibo Valido:
            If Not IsNumeric(cneValor.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.cneValor, "Monto Inválido.")
                Me.cneValor.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Datos usado para el registro de recibos manuales pertenecientes al municipio de Bluefields 
            '23/01/2017 , a este municipio se le dio un talonario manual reiniciad

            Dim strSQLAux As String

            Dim XdtValor As New BOSistema.Win.XComando


            'Dim nMunicipio As Integer
            'Obtener la fecha del enredo talonario manual 3 1ro de diciembre del 2014
            strSQLAux = " SELECT        sValorParametro" & _
            " FROM dbo.StbValorParametro" & _
            " WHERE (nStbParametroID = 117) "
            nMunicipioID = XdtValor.ExecuteScalar(strSQLAux)



            '-- Encuentra Departamento asociado a la Caja:
            strSQL = "SELECT D.nStbDepartamentoID " & _
                     "FROM SteArqueoCaja AS AC INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS D ON C.nStbBarrioID = D.nStbBarrioID " & _
                     "WHERE (AC.nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            Me.IdSteDepartamento = XcDatosV.ExecuteScalar(strSQL)


            '-- Encuentra Municipio asociado a la Caja:
            strSQL = "SELECT D.nStbMunicipioID " & _
                     "FROM SteArqueoCaja AS AC INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS D ON C.nStbBarrioID = D.nStbBarrioID " & _
                     "WHERE (AC.nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            IdSteMunicipio = XcDatosV.ExecuteScalar(strSQL)

            'Verificamos si la caja pertenece a un municipio que es atendido por otro departamento 
            'por lo cual tendriamos que validar que los recibos no pertenezcan a un arqueo activo de una caja
            'que pertenezca al departamento que lo atienede o un arqueo de otra caja que pertenecen al municipio de la caja

            strSQL = "SELECT   dbo.StbMunicipioAtendidoDepartamentoAlterno.nStbDepartamentoAtiendeID " &
                      "From dbo.SteArqueoCaja INNER Join " &
                      "dbo.SteCaja On dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER Join " &
                      "dbo.vwStbUbicacionGeografica ON dbo.SteCaja.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER Join " &
                      "dbo.StbMunicipioAtendidoDepartamentoAlterno ON " &
                      "dbo.vwStbUbicacionGeografica.nStbMunicipioID = dbo.StbMunicipioAtendidoDepartamentoAlterno.nStbMunicipioID " &
                       "WHERE(dbo.SteArqueoCaja.nSteArqueoCajaID = " & Me.IdArqueo & ")"

            IdSteDepartamentoAtiende = XcDatosV.ExecuteScalar(strSQL)

            'Si es Adición:
            If ModoForm = "ADD" Then

                '-- El Código del Recibo (rango) no debe de repetirse dentro de un mismo Departamento:

                If IdSteDepartamentoAtiende > 0 Then
                    ' Validación para cuando la caja es atendida por otro Departamento 
                    strSQL = "SELECT  dbo.SteArqueoRecibo.nSteArqueoReciboID From dbo.SteArqueoRecibo INNER Join " &
                         "dbo.SteArqueoCaja On dbo.SteArqueoRecibo.nSteArqueoCajaID = dbo.SteArqueoCaja.nSteArqueoCajaID INNER Join " &
                         "dbo.StbValorCatalogo On dbo.SteArqueoCaja.nStbEstadoArqueoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER Join " &
                         "dbo.SteCaja ON dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER Join " &
                         "dbo.vwStbUbicacionGeografica ON dbo.SteCaja.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER Join " &
                         "(Select nStbMunicipioID From (Select nStbMunicipioID From dbo.StbMunicipioAtendidoDepartamentoAlterno " &
                         "Where (nStbDepartamentoAtiendeID =" & IdSteDepartamentoAtiende & ")) As MunicipiosAtiende) As MunicipiosAtiende_1 On " &
                         "dbo.vwStbUbicacionGeografica.nStbMunicipioID = MunicipiosAtiende_1.nStbMunicipioID " &
                         "WHERE (SteArqueoRecibo.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " And " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " &
                         "And (StbValorCatalogo.sCodigoInterno <> '3' And StbValorCatalogo.sCodigoInterno <> '4') " &
                         "AND (SteCaja.nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " &
                         "AND (SteCaja.nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") " &
                         "AND (SteArqueoRecibo.nCodigoTalonario = " & Me.CodigoTalonario & ") " &
                         "AND (SteArqueoRecibo.nSccReciboOficialCajaID IS NULL)"

                    'If RegistrosAsociados(strSQL) Then
                    '    MsgBox("Existen Códigos de Recibos en el rango que se encuentran" & Chr(13) & "registrados en un Arqueo de Caja Activo.", MsgBoxStyle.Critical, NombreSistema)
                    '    Me.errRecibo.SetError(Me.txtHastaRecibo, "Existen Recibos ingresados en el rango.")
                    '    Me.txtHastaRecibo.Focus()
                    '    ValidaDatosEntrada = False
                    '    Exit Function
                    'End If

                Else


                    strSQL = "Select SteArqueoRecibo.nSteArqueoReciboID " &
                         "FROM  SteArqueoRecibo INNER JOIN SteArqueoCaja On SteArqueoRecibo.nSteArqueoCajaID = SteArqueoCaja.nSteArqueoCajaID INNER JOIN StbValorCatalogo On SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " &
                         "INNER JOIN SteCaja On SteArqueoCaja.nSteCajaID = SteCaja.nSteCajaID INNER JOIN vwStbUbicacionGeografica On SteCaja.nStbBarrioID = vwStbUbicacionGeografica.nStbBarrioID " &
                         "WHERE (SteArqueoRecibo.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " And " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") And (StbValorCatalogo.sCodigoInterno <> '3' And StbValorCatalogo.sCodigoInterno <> '4') " &
                         "AND (vwStbUbicacionGeografica.nStbDepartamentoID = " & IdSteDepartamento & ") " &
                         "AND (SteCaja.nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " &
                         "AND (SteCaja.nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") " &
                         "AND (SteArqueoRecibo.nCodigoTalonario = " & Me.CodigoTalonario & ") " &
                         "AND (SteArqueoRecibo.nSccReciboOficialCajaID IS NULL)"

                    'If RegistrosAsociados(strSQL) Then
                    '    MsgBox("Existen Códigos de Recibos en el rango que se encuentran" & Chr(13) & "registrados en un Arqueo de Caja Activo.", MsgBoxStyle.Critical, NombreSistema)
                    '    Me.errRecibo.SetError(Me.txtHastaRecibo, "Existen Recibos ingresados en el rango.")
                    '    Me.txtHastaRecibo.Focus()
                    '    ValidaDatosEntrada = False
                    '    Exit Function
                    'End If

                End If

                If IdSteDepartamento = 17 And IdSteMunicipio = nMunicipioID Then
                    strSQL = strSQL + " AND (dbo.vwStbUbicacionGeografica.nStbMunicipioID =" & IdSteMunicipio & ") "
                End If

                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen Códigos de Recibos en el rango que se encuentran" & Chr(13) & "registrados en un Arqueo de Caja Activo.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtHastaRecibo, "Existen Recibos ingresados en el rango.")
                    Me.txtHastaRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If

                '-- No ingresar Números que estan registrados manualmente en la Pantalla de Anulados 
                '   para el Dpto, Programa y Periodicidad de Pagos:


                If IdSteDepartamentoAtiende > 0 Then
                    strSQL = "SELECT SteReciboAnulado.* FROM SteReciboAnulado " &
                         "WHERE (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " &
                         "AND (nStbDepartamentoID = " & IdSteDepartamentoAtiende & ") " &
                         "AND (nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " &
                         "AND (nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") " &
                         "AND (nCodigoTalonario = " & Me.CodigoTalonario & ")"

                Else


                    strSQL = "SELECT SteReciboAnulado.* FROM SteReciboAnulado " &
                         "WHERE (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " &
                         "AND (nStbDepartamentoID = " & IdSteDepartamento & ") " &
                         "AND (nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " &
                         "AND (nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") " &
                         "AND (nCodigoTalonario = " & Me.CodigoTalonario & ")"
                End If
                If IdSteDepartamento = 17 And IdSteMunicipio = nMunicipioID Then
                        strSQL = strSQL + " AND (nStbMunicipioID =" & IdSteMunicipio & ") "
                    End If

                    If RegistrosAsociados(strSQL) Then
                        MsgBox("Existen Códigos de Recibos en el rango que se encuentran" & Chr(13) & "registrados como Recibos Anulados en el Departamento y Programa.", MsgBoxStyle.Critical, NombreSistema)
                        Me.errRecibo.SetError(Me.txtHastaRecibo, "Existen Recibos Anulados ingresados en el rango.")
                        Me.txtHastaRecibo.Focus()
                        ValidaDatosEntrada = False
                        Exit Function
                    End If

                Else 'Si es Editar/Eliminar:

                    '-- Imposible Modificar Recibos Automáticos:
                    If (ModoForm = "UPD") And (Me.chkManual.Checked = False) Then
                    MsgBox("Imposible modificar recibos oficiales" & Chr(13) & "de caja automáticos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtHastaRecibo, "Imposible modificar recibos automáticos.")
                    Me.txtHastaRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If

                '-- El(los) Recibo(s) deben estar contenidos en el Arqueo:
                If Me.chkManual.Checked = True Then
                    strSQL = "Select * From SteArqueoRecibo " & _
                             "WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") " & _
                             "AND (nSccReciboOficialCajaID IS NULL) " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                Else 'Eliminar Recibos
                    strSQL = "Select * From SteArqueoRecibo " & _
                             "WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") " & _
                             "AND (nSccReciboOficialCajaID IS NOT NULL) " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                End If
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("No existen Recibos de este tipo asociados al Arqueo" & Chr(13) & "con los Códigos indicados.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtHastaRecibo, "No existen Recibos asociados al Arqueo con los Códigos indicados.")
                    Me.txtHastaRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If

                '-- Los recibos a Editar/Eliminar no deben tener Recibo de Caja asociado y Activo:
                '-- Recibos Manuales (No hacen distinción por caja):
                '15/12/2009 Y del tipo de Programa de la Caja:
                If Me.chkManual.Checked = True Then 'If nManual = 1 Then

                    If IdSteDepartamento = 17 And IdSteMunicipio = nMunicipioID Then

                        Dim xdatos As New BOSistema.Win.XComando
                        Dim fecha As Date
                        strSQL = "SELECT dFechaArqueo " & _
                                 "FROM dbo.SteArqueoCaja " & _
                                 "WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ")"

                        fecha = xdatos.ExecuteScalar(strSQL)
                        strSQL = " SELECT a.nCodigo FROM " &
                                                                  "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario, dFechaRecibo " &
                                                                  "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " &
                                                                  "And (nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") AND (nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " &
                                                                  ") AS a INNER JOIN " &
                                                                  " (SELECT AR.nCodigo,  'Q' AS sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " &
                                                                  "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " &
                                                                  "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeograficaMunicipioAlterno AS G ON C.nStbBarrioID = G.nStbBarrioID " &
                                                                  "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " &
                                                                  " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & Me.IdSteArqueo & ")) " &
                                                                  "AS b " &
                                                  "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " &
                                                  "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " &
                                                  "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " &
                                                  "AND a.nCodigoTalonario = b.nCodigoTalonario " &
                                                  "WHERE (a.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                    Else

                        strSQL = " SELECT a.nCodigo FROM " &
                                              "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario " &
                                              "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " &
                                              "And (nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") AND (nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " &
                                              ") AS a INNER JOIN " &
                                              " (SELECT AR.nCodigo, G.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " &
                                              "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " &
                                              "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeograficaMunicipioAlterno AS G ON C.nStbBarrioID = G.nStbBarrioID " &
                                              "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " &
                                              " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & Me.IdSteArqueo & ")) " &
                                              "AS b " &
                              "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " &
                              "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " &
                              "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " &
                              "AND a.nCodigoTalonario = b.nCodigoTalonario " &
                              "WHERE (a.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"



                        'strSQL = " SELECT a.nCodigo FROM (SELECT nCodigo, sSerieDelegacion, nManual, nSteCajaID " & _
                        '         " FROM vwSccReciboSerie WHERE (sCodigoInterno <> '3')AND (TipoPrograma = " & Me.StrCodTipoPrograma & ")) AS a INNER JOIN " & _
                        '         " (SELECT AR.nCodigo, D.sSerieDelegacion, CASE WHEN AR.nSccReciboOficialCajaID IS NULL THEN 1 ELSE 0 END AS nManual, AC.nSteCajaID " & _
                        '         " FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                        '         " INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                        '         " INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                        '         " WHERE  (AR.nSteArqueoCajaID = " & Me.IdSteArqueo & ")) AS b " & _
                        '         " ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion AND a.nManual = b.nManual " & _
                        '         " WHERE (a.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"

                        '-- Recibos Automáticos (Hacen distinción por caja):
                    End If
                Else

                    strSQL = " SELECT a.nCodigo FROM " & _
                                        "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario, nSteCajaID " & _
                                        "FROM vwSccReciboSerie WHERE (nManual = 0) AND (sCodigoInterno <> '3') " & _
                                        "And (nStbTipoPlazoPagosID = " & Me.IdTipoPlazoPagos & ") AND (nStbTipoProgramaID = " & Me.IdTipoPrograma & ") " & _
                                        ") AS a INNER JOIN " & _
                                        " (SELECT AR.nCodigo, D.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario, AC.nSteCajaID " & _
                                        "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                                        "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                                        "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                                        " WHERE (AR.nSccReciboOficialCajaID IS NOT NULL) AND (AR.nSteArqueoCajaID = " & Me.IdSteArqueo & ")) " & _
                                        "AS b " & _
                        "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " & _
                        "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " & _
                        "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " & _
                        "AND a.nCodigoTalonario = b.nCodigoTalonario AND a.nSteCajaID = b.nSteCajaID " & _
                        "WHERE (a.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                    'strSQL = " SELECT a.nCodigo FROM (SELECT nCodigo, sSerieDelegacion, nManual, nSteCajaID " & _
                    '         " FROM vwSccReciboSerie WHERE (sCodigoInterno <> '3')) AS a INNER JOIN " & _
                    '         " (SELECT AR.nCodigo, D.sSerieDelegacion, CASE WHEN AR.nSccReciboOficialCajaID IS NULL THEN 1 ELSE 0 END AS nManual, AC.nSteCajaID " & _
                    '         " FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                    '         " INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                    '         " INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                    '         " WHERE  (AR.nSteArqueoCajaID = " & Me.IdSteArqueo & ")) AS b " & _
                    '         " ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion AND a.nManual = b.nManual AND a.nSteCajaID = b.nSteCajaID " & _
                    '         " WHERE (a.nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"

                End If
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen Recibos Oficiales de Caja ACTIVOS en el rango.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtHastaRecibo, "Existen Recibos Oficiales de Caja ACTIVOS en el rango.")
                    Me.txtHastaRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                End If

            'Si es Adición:
            If ModoForm = "ADD" Then
                REM Si Fecha del Arqueo es Mayor a 10/08/2008:
                strSQL = "SELECT dFechaArqueo FROM SteArqueoCaja WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") AND (dFechaArqueo > CONVERT(DATETIME, '2008-08-10 00:00:00', 102))"
                If RegistrosAsociados(strSQL) Then
                    nValidarTalonarios = 1
                    'Código Inicial no debe ser menor que el Recibo Mínimo:
                    If CInt(Me.txtNumRecibo.Text) < Me.nSteReciboMin Then
                        MsgBox("El No. del Recibo Inicial no puede ser menor que " & Me.nSteReciboMin & Chr(13) & "(primer rango de entrega asignado al Cajero).", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errRecibo.SetError(Me.txtNumRecibo, "Recibo Inicial Invalido.")
                        Me.txtNumRecibo.Focus()
                        Exit Function
                    End If
                    'Código Inicial no debe ser mayor que el Recibo Máximo:
                    If CInt(Me.txtNumRecibo.Text) > Me.nSteReciboMax Then
                        MsgBox("El No. del Recibo Inicial no puede ser mayor que " & Me.nSteReciboMax & Chr(13) & "(último rango de entrega asignado al Cajero).", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errRecibo.SetError(Me.txtNumRecibo, "Recibo Inicial Invalido.")
                        Me.txtNumRecibo.Focus()
                        Exit Function
                    End If
                    'Código Final no debe ser mayor que el Recibo Máximo:
                    If CInt(Me.txtHastaRecibo.Text) > Me.nSteReciboMax Then
                        MsgBox("El No. del Recibo Final no puede ser mayor que " & Me.nSteReciboMax & Chr(13) & "(último rango de entrega asignado al Cajero).", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errRecibo.SetError(Me.txtHastaRecibo, "Recibo Final Invalido.")
                        Me.txtHastaRecibo.Focus()
                        Exit Function
                    End If
                    'Código Final no menor que Recibo Mínimo:
                    If CInt(Me.txtHastaRecibo.Text) < Me.nSteReciboMin Then
                        MsgBox("El No. del Recibo Final no puede ser menor que " & Me.nSteReciboMin & Chr(13) & "(primer rango de entrega asignado al Cajero).", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errRecibo.SetError(Me.txtHastaRecibo, "Recibo Final Invalido.")
                        Me.txtHastaRecibo.Focus()
                        Exit Function
                    End If
                Else
                    nValidarTalonarios = 0
                End If
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatosV.Close()
            XcDatosV = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       InsertarRecibos
    ' Descripción:          Este procedimiento permite insertar Recibos 
    '                       en el Rango. 
    '-------------------------------------------------------------------------
    Private Sub InsertarRecibos()
        Dim Trans As BOSistema.Win.Transact
        Dim XcDatos As New BOSistema.Win.XComando
        Trans = Nothing

        Try
            Dim StrSql As String
            Dim StrSql1 As String
            Dim intReciboD As Integer
            Dim intReciboH As Integer
            Dim dFechaArqueo As Date
            Dim CajeroId As Integer
            Dim nCodigo As Integer
            Dim nIngreso As Integer
            nIngreso = 0
            nUltimoCodigo = 0

            intReciboD = Trim(RTrim(Me.txtNumRecibo.Text))
            intReciboH = Trim(RTrim(Me.txtHastaRecibo.Text))

            StrSql1 = "SELECT dFechaArqueo FROM SteArqueoCaja WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            dFechaArqueo = XcDatos.ExecuteScalar(StrSql1)
            StrSql1 = "SELECT nSrhCajeroId FROM SteArqueoCaja WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            CajeroId = XcDatos.ExecuteScalar(StrSql1)
            'StrSql1 = "SELECT U.nStbDepartamentoID " & _
            '          "FROM SteArqueoCaja AS A INNER JOIN SteCaja AS C ON A.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON C.nStbBarrioID = U.nStbBarrioID " & _
            '          "WHERE (A.nSteArqueoCajaID = " & Me.IdSteArqueo & ")"
            'DepartamentoId = XcDatos.ExecuteScalar(StrSql1)

            'Validamos con el deparamento que atiende la caja
            If IdSteDepartamentoAtiende > 0 Then
                IdSteDepartamento = IdSteDepartamentoAtiende
            End If

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transacción:
            Trans.BeginTrans()

            For i As Integer = intReciboD To intReciboH



                StrSql1 = "Exec SpSteRevisaReciboExiste '" & Format(dFechaArqueo, "yyyy-MM-dd") & "', " & intReciboD & ", " & intReciboH & ", " & i & ", " & CajeroId & ", " & IdSteDepartamento & ", 0, " & Me.IdTipoPrograma & "," & Me.IdTipoPlazoPagos & "," & Me.CodigoTalonario

                If Me.IdSteDepartamento = 17 And Me.IdSteMunicipio = Me.nMunicipioID Then
                    StrSql1 = StrSql1 + "," & Me.IdSteMunicipio
                End If

                nCodigo = XcDatos.ExecuteScalar(StrSql1)
                If (nCodigo <> 0) Or (nValidarTalonarios = 0) Then
                    '---------------------------
                    'Insertar Recibo al Arqueo:
                    StrSql = "Insert Into SteArqueoRecibo " & _
                             "(nSteArqueoCajaID, nCodigo, nValor, nCodigoTalonario, nUsuarioCreacionID, dFechaCreacion) " & _
                             " Values (" & Me.IdSteArqueo & ", " & i & _
                             ", " & cneValor.Value & "," & Me.CodigoTalonario & ", " & InfoSistema.IDCuenta & "," & "GetDate())"
                    Trans.ExecuteSql(StrSql)
                    nUltimoCodigo = i
                    nIngreso = 1
                    '---------------------------
                End If
            Next

            '-- Finaliza Transacción:
            Trans.Commit()

            If nIngreso = 0 Then
                MsgBox("Los códigos indicados no se encuentran dentro de los" & Chr(13) & "rangos de Entregas de Recibos asignados al Cajero.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       SalvarRecibo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarRecibo()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'En caso de Adición:
            If ModoForm = "ADD" Then
                InsertarRecibos()
            ElseIf ModoForm = "UPD" Then '/Edición: SOLO RECIBOS MANUALES. 
                strSQL = "Update SteArqueoRecibo " & _
                         "SET nValor = " & cneValor.Value & ", " & _
                         "    nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", " & _
                         "    dFechaModificacion = getdate() " & _
                         "WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") " & _
                         "AND (nSccReciboOficialCajaID IS NULL) " & _
                         "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                XcDatos.ExecuteNonQuery(strSQL)
            Else
                If Me.chkManual.Checked Then 'MANUALES
                    strSQL = "Delete From SteArqueoRecibo " & _
                             "WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") " & _
                             "AND (nSccReciboOficialCajaID IS NULL) " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                Else 'AUTOMATICOS
                    strSQL = "Delete From SteArqueoRecibo " & _
                             "WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") " & _
                             "AND (nSccReciboOficialCajaID IS NOT NULL) " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNumRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                End If
                
                XcDatos.ExecuteNonQuery(strSQL)
            End If

            'Localizar número de recibo:
            If ModoForm = "ADD" Then
                strSQL = "SELECT nSteArqueoReciboID FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") AND (nCodigo = " & nUltimoCodigo & ")"
            Else
                strSQL = "SELECT nSteArqueoReciboID FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & Me.IdSteArqueo & ") AND (nCodigo = " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
            End If

            Me.IdSteRecibo = XcDatos.ExecuteScalar(strSQL)
            '--------------------------------

            '-- Buscar el Recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjRecibodt.Filter = "nSteArqueoReciboID = " & Me.IdSteRecibo
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdSteRecibo = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                Call GuardarAuditoria(2, 25, "Modificación de Recibo asociado a Arqueo de Caja ID: " & Me.IdSteArqueo & ").")
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            'XdtDatos.Close()
            'XdtDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarRecibo()
                            AccionUsuario = AccionBoton.BotonAceptar
                            Me.Close()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case vbNo
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.Close()

                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtHastaRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaRecibo.KeyPress
        Try
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtHastaRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHastaRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValor.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNumRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRecibo.KeyPress
        Try
            'Solo numeros: 
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNumRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumRecibo.TextChanged
        vbModifico = True
    End Sub
End Class