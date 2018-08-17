' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                05/03/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditConciliacionCF.vb
' Descripción:          Este formulario permite ingresar un rango de
'                       Cheques Flotantes para una Conciliación Bancaria.
'-------------------------------------------------------------------------
Public Class frmSteEditConciliacionCF

    '-- Declaracion de Variables: 
    Dim IdSteConciliacion As Integer
    Dim IdSteDocumento As Integer
    Dim IdSteCuentaBanco As Integer
    Dim dSteFechaI As Date
    Dim dSteFechaF As Date

    '-- Clases para procesar la informacion de los combos
    Dim XdsTransacciones As BOSistema.Win.XDataSet

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para obtener el ID de Conciliación.
    Public Property IdConciliacion() As Integer
        Get
            IdConciliacion = IdSteConciliacion
        End Get
        Set(ByVal value As Integer)
            IdSteConciliacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Transacción.
    Public Property IdDocumento() As Integer
        Get
            IdDocumento = IdSteDocumento
        End Get
        Set(ByVal value As Integer)
            IdSteDocumento = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       frmSteEditConciliacionDocumentos_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacionCF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsTransacciones.Close()
                XdsTransacciones = Nothing

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
    ' Fecha:                05/03/2008
    ' Procedure Name:       frmSteEditConciliacionDocumentos_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacionCF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combo:
            CargarFuenteFondos(0)

            Me.cboFuenteFondos.Select()
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
    ' Fecha:                05/03/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim XcFechas As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            XdsTransacciones = New BOSistema.Win.XDataSet

            'Encuentra Fechas de la Conciliación:
            strSQL = "SELECT dFechaInicio FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            dSteFechaI = XcFechas.ExecuteScalar(strSQL)
            strSQL = "SELECT dFechaCorte FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            dSteFechaF = XcFechas.ExecuteScalar(strSQL)

            'Encuentra Cuenta Bancaria de la Conciliación:
            strSQL = "SELECT nSteCuentaBancariaID FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            IdSteCuentaBanco = XcFechas.ExecuteScalar(strSQL)

            'Limpiar los combos:
            Me.cboFuenteFondos.ClearFields()
            Me.cboDocumentoDesde.ClearFields()
            Me.cboDocumentoHasta.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcFechas.Close()
            XcFechas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarDocumento()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim StrSql As String
            ValidaDatosEntrada = True
            Me.errDocumento.Clear()

            'Fuente de Fondos:
            If Me.cboFuenteFondos.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboFuenteFondos, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuenteFondos.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Documento Desde:
            If Me.cboDocumentoDesde.SelectedIndex = -1 Then
                MsgBox("Debe indicar Número de Cheque Inicial.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboDocumentoDesde, "Debe indicar Número de Cheque Inicial.")
                Me.cboDocumentoDesde.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Documento Hasta:
            If Me.cboDocumentoHasta.SelectedIndex = -1 Then
                MsgBox("Debe indicar Número de Cheque Final.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboDocumentoHasta, "Debe indicar Número de Cheque Final.")
                Me.cboDocumentoHasta.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Cheque Final >= Inicial:
            If CDbl(Me.cboDocumentoHasta.Text) < CDbl(Me.cboDocumentoDesde.Text) Then
                MsgBox("Número de Cheque Final no debe ser menor al inicial.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboDocumentoHasta, "Número de Cheque Final no debe ser menor al inicial.")
                Me.cboDocumentoHasta.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si ya existe al menos un CK del rango dentro de la Conciliación:
            StrSql = " SELECT ScnTransaccionContable.sNumeroTransaccion " & _
                     " FROM  SteConciliacionTransacciones INNER JOIN ScnTransaccionContableDetalle ON SteConciliacionTransacciones.nScnTransaccionContableDetalleID = ScnTransaccionContableDetalle.nScnTransaccionContableDetalleID " & _
                     " INNER JOIN ScnTransaccionContable ON ScnTransaccionContableDetalle.nScnTransaccionContableID = ScnTransaccionContable.nScnTransaccionContableID INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " INNER JOIN SteConciliacionBancaria ON SteConciliacionTransacciones.nSteConciliacionBancariaID = SteConciliacionBancaria.nSteConciliacionBancariaID  INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON SteConciliacionBancaria.nStbEstadoConciliacionID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                     " WHERE (StbValorCatalogo_1.sCodigoInterno <> '3') AND (StbValorCatalogo.sCodigoInterno = 'CK') AND (ScnTransaccionContable.sNumeroTransaccion BETWEEN '" & Me.cboDocumentoDesde.Text & "' AND '" & Me.cboDocumentoHasta.Text & "')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Cheques dentro del rango que ya han sido ingresados en una" & Chr(13) & "Conciliación Bancaria ACTIVA.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboDocumentoHasta, "Número de Cheque Final no debe ser menor al inicial.")
                Me.cboDocumentoHasta.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       SalvarDocumento
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarDocumento()
        Dim XdtCheques As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatosCF As New BOSistema.Win.XComando

        Try
            Dim StrSql As String
            Dim StrSqlV As String
            Dim IntTipoOperacion As Integer

            '-- Cheques Flotantes seleccionados en el Rango:
            StrSqlV = " SELECT ScnTransaccionContableDetalle.nScnTransaccionContableDetalleID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion " & _
                      " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID  INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                      " WHERE (StbValorCatalogo_1.sCodigoInterno = 'CK' OR StbValorCatalogo_1.sCodigoInterno = 'CE') AND (ScnTransaccionContable.nScnFuenteFinanciamientoID = " & cboFuenteFondos.Columns("nScnFuenteFinanciamientoID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2') AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBanco & ") AND (ScnTransaccionContable.sNumeroTransaccion BETWEEN '" & Me.cboDocumentoDesde.Text & "' AND '" & Me.cboDocumentoHasta.Text & "') " & _
                      " GROUP BY ScnTransaccionContableDetalle.nScnTransaccionContableDetalleID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion  " & _
                      " HAVING (ScnTransaccionContable.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(Me.dSteFechaI, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) "

            '-- Determina Id de Operación: Cheques Flotantes:
            StrSql = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = 'CF' And b.sNombre = 'OperacionConciliacion' "
            IntTipoOperacion = XcDatosCF.ExecuteScalar(StrSql)

            '-- Insertar Cheques Flotantes en la Conciliación Bancaria:
            StrSql = " INSERT INTO SteConciliacionTransacciones (nSteConciliacionBancariaID, nScnTransaccionContableDetalleID, nStbOperacionID, nUsuarioCreacionID, dFechaCreacion)" & _
                     " SELECT " & Me.IdSteConciliacion & ", a.nScnTransaccionContableDetalleID, " & IntTipoOperacion & ", " & InfoSistema.IDCuenta & ", getdate()" & _
                     " FROM (" & StrSqlV & ") a "
            XdtCheques.ExecuteSqlNotTable(StrSql)
            MsgBox("Los Cheques se incorporaron satisfactoriamente.", MsgBoxStyle.Information)

            '-- Determina Primer Id Insertado:
            StrSql = "SELECT TOP (1) nSteConciliacionTransaccionID AS Id FROM SteConciliacionTransacciones ORDER BY dFechaCreacion DESC, Id"
            IdSteDocumento = XcDatosCF.ExecuteScalar(StrSql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtCheques.Close()
            XdtCheques = Nothing

            XcDatosCF.Close()
            XcDatosCF = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
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
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarDocumento()
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       CargarTransaccion
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cheques de Inicio en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTransaccion(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboDocumentoDesde.ClearFields()

            If intLimpiarID = 0 Then
                Strsql = " SELECT ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                         " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID  INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                         " WHERE (StbValorCatalogo_1.sCodigoInterno = 'CK' or StbValorCatalogo_1.sCodigoInterno = 'CE') AND (ScnTransaccionContable.nScnFuenteFinanciamientoID = " & cboFuenteFondos.Columns("nScnFuenteFinanciamientoID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2') AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBanco & ") " & _
                         " GROUP BY ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion  " & _
                         " HAVING (ScnTransaccionContable.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(Me.dSteFechaI, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) Order By  ScnTransaccionContable.sNumeroTransaccion"
            Else
                Strsql = " SELECT  ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                         " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                         " WHERE ScnTransaccionContable.nScnTransaccionContableID = 0"
            End If

            If XdsTransacciones.ExistTable("Transaccion") Then
                XdsTransacciones("Transaccion").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "Transaccion")
                XdsTransacciones("Transaccion").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDocumentoDesde.DataSource = XdsTransacciones("Transaccion").Source
            Me.cboDocumentoDesde.Rebind()

            'Configurar el combo:
            Me.cboDocumentoDesde.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.cboDocumentoDesde.Splits(0).DisplayColumns("dFechaTransaccion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDocumentoDesde.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 130
            Me.cboDocumentoDesde.Splits(0).DisplayColumns("dFechaTransaccion").Width = 80
            Me.cboDocumentoDesde.Splits(0).DisplayColumns("sDescripcion").Width = 350

            Me.cboDocumentoDesde.Columns("sNumeroTransaccion").Caption = "Número Documento"
            Me.cboDocumentoDesde.Columns("dFechaTransaccion").Caption = "Fecha"
            Me.cboDocumentoDesde.Columns("sDescripcion").Caption = "Concepto"

            Me.cboDocumentoDesde.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDocumentoDesde.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDocumentoDesde.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDocumentoDesde.Columns("dFechaTransaccion").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       CargarTransaccionHasta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cheques de Corte para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTransaccionHasta(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboDocumentoHasta.ClearFields()

            If intLimpiarID = 0 Then
                Strsql = " SELECT ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                         " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID  INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                         " WHERE (StbValorCatalogo_1.sCodigoInterno = 'CK' OR StbValorCatalogo_1.sCodigoInterno = 'CE') AND (ScnTransaccionContable.nScnFuenteFinanciamientoID = " & cboFuenteFondos.Columns("nScnFuenteFinanciamientoID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2') AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBanco & ") " & _
                         " GROUP BY ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion  " & _
                         " HAVING (ScnTransaccionContable.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(Me.dSteFechaI, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) Order By  ScnTransaccionContable.sNumeroTransaccion"
            Else
                Strsql = " SELECT  ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                         " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                         " WHERE ScnTransaccionContable.nScnTransaccionContableID = 0"
            End If

            If XdsTransacciones.ExistTable("TransaccionH") Then
                XdsTransacciones("TransaccionH").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "TransaccionH")
                XdsTransacciones("TransaccionH").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDocumentoHasta.DataSource = XdsTransacciones("TransaccionH").Source
            Me.cboDocumentoHasta.Rebind()

            'Configurar el combo:
            Me.cboDocumentoHasta.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.cboDocumentoHasta.Splits(0).DisplayColumns("dFechaTransaccion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDocumentoHasta.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 130
            Me.cboDocumentoHasta.Splits(0).DisplayColumns("dFechaTransaccion").Width = 80
            Me.cboDocumentoHasta.Splits(0).DisplayColumns("sDescripcion").Width = 350

            Me.cboDocumentoHasta.Columns("sNumeroTransaccion").Caption = "Número Documento"
            Me.cboDocumentoHasta.Columns("dFechaTransaccion").Caption = "Fecha"
            Me.cboDocumentoHasta.Columns("sDescripcion").Caption = "Concepto"

            Me.cboDocumentoHasta.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDocumentoHasta.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDocumentoHasta.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDocumentoHasta.Columns("dFechaTransaccion").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       CargarFuenteFondos
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuenteFondos(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " & _
                         " Order by a.sCodigo"
            End If

            If XdsTransacciones.ExistTable("Fuente") Then
                XdsTransacciones("Fuente").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "Fuente")
                XdsTransacciones("Fuente").Retrieve()
            End If

            'Asignando a las fuentes de datos: 
            Me.cboFuenteFondos.DataSource = XdsTransacciones("Fuente").Source
            Me.cboFuenteFondos.Rebind()

            Me.cboFuenteFondos.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuenteFondos.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuenteFondos.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
            Me.cboFuenteFondos.Splits(0).DisplayColumns("sCodigo").Width = 47
            Me.cboFuenteFondos.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboFuenteFondos.Columns("sCodigo").Caption = "Código"
            Me.cboFuenteFondos.Columns("sNombre").Caption = "Descripción"

            Me.cboFuenteFondos.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuenteFondos.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboFuenteFondos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuenteFondos.TextChanged
        If (Me.cboFuenteFondos.SelectedIndex <> -1) Then
            CargarTransaccion(0)
            CargarTransaccionHasta(0)
        Else
            CargarTransaccion(1)
            CargarTransaccionHasta(1)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDocumentoDesde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumentoDesde.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboDocumentoHasta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumentoHasta.TextChanged
        vbModifico = True
    End Sub
End Class