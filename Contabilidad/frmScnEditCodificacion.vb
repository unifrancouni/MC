' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                26/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditCodificacion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Codificación de Cuentas Contables.
'-------------------------------------------------------------------------
Public Class frmScnEditCodificacion

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdScnComprobante As Long
    Dim StrNombreTablaTmp As String
    Dim DblMontoDolares As Double

    '-- Clases para procesar la informacion de los combos
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtCuenta As BOSistema.Win.XDataSet.xDataTable

    Dim XcDatosGl As New BOSistema.Win.XComando

    '-- Crear un data table de tipo Xdataset (conjunto de tablas):
    Dim ObjComprobantedt As BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
    Dim ObjComprobantedr As BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza
    'para Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Comprobante.
    Public Property IdComprobante() As Long
        Get
            IdComprobante = IdScnComprobante
        End Get
        Set(ByVal value As Long)
            IdScnComprobante = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
    ' Procedure Name:       frmScnEditCodificacion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCodificacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjComprobantedt.Close()
                ObjComprobantedt = Nothing

                ObjComprobantedr.Close()
                ObjComprobantedr = Nothing

                XdtFuenteFondos.Close()
                XdtFuenteFondos = Nothing

                XdtCuenta.Close()
                XdtCuenta = Nothing

                XcDatosGl.Close()
                XcDatosGl = Nothing

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
    ' Fecha:                26/11/2007
    ' Procedure Name:       frmScnEditCodificacion_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCodificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFuenteFondos(0)

            'Cargar Datos de Encabezado de la transacción:
            CargarCodificacion()

            'Si el formulario está en modo edición:
            If ModoForm = "UPD" Then
                grpDatosGenerales.Enabled = False
            End If

            Me.cboCuenta.Select()
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
    ' Fecha:                26/11/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Codificación Contable"
            Else
                Me.Text = "Modificar Codificación Contable"
            End If

            XdtFuenteFondos = New BOSistema.Win.XDataSet.xDataTable
            XdtCuenta = New BOSistema.Win.XDataSet.xDataTable

            ObjComprobantedt = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
            ObjComprobantedr = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboCuenta.ClearFields()

            cneDebe.Value = "0"
            cneHaber.Value = "0"

            If ModoForm = "ADD" Then
                ObjComprobantedr = ObjComprobantedt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
    ' Procedure Name:       CargarCodificacion
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Comprobante de Diario caso de estar en el Modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCodificacion()
        Try

            '-- Buscar el Comprobante correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjComprobantedt.Filter = "nScnTransaccionContableID = " & IdComprobante
            ObjComprobantedt.Retrieve()
            If ObjComprobantedt.Count = 0 Then
                Exit Sub
            End If
            ObjComprobantedr = ObjComprobantedt.Current

            'Fecha de Transacción:
            If Not ObjComprobantedr.IsFieldNull("dFechaTransaccion") Then
                Me.cdeFechaCD.Value = ObjComprobantedr.dFechaTransaccion
            Else
                Me.cdeFechaCD.Value = Me.cdeFechaCD.ValueIsDbNull
            End If

            'Fecha de Tipo de Cambio:
            If Not ObjComprobantedr.IsFieldNull("dFechaTipoCambio") Then
                Me.cdeFechaTC.Value = ObjComprobantedr.dFechaTipoCambio
            Else
                Me.cdeFechaTC.Value = Me.cdeFechaTC.ValueIsDbNull
            End If

            'Fuente de Fondos:
            If Not ObjComprobantedr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFuenteFondos(ObjComprobantedr.nScnFuenteFinanciamientoID)
                If cboFuente.ListCount > 0 Then
                    Me.cboFuente.SelectedIndex = 0
                End If
                XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", ObjComprobantedr.nScnFuenteFinanciamientoID)
            Else
                Me.cboFuente.Text = ""
                Me.cboFuente.SelectedIndex = -1
            End If

            'Cargar Datos de Codificación en ListView:
            CargarListView()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCodificacion()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ValidaDatosEntrada = True
            Me.errComprobante.Clear()
            Dim strSQL As String

            'Fecha de Transacción:
            If Me.cdeFechaCD.ValueIsDbNull Then
                MsgBox("La Fecha de Transacción NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE quedar vacía.")
                Me.cdeFechaCD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Si la transacción tiene una Fecha de Depósito: 
            'Y esta no coincide con la nueva Fecha de transacción:
            strSQL = "SELECT SteMinutaDeposito.dFechaDeposito FROM ScnTransaccionContable INNER JOIN SteMinutaDeposito ON ScnTransaccionContable.nSteMinutaDepositoID = SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "WHERE (ScnTransaccionContable.nScnTransaccionContableID = " & IdScnComprobante & ")"
            If RegistrosAsociados(strSQL) = True Then
                If XcDatos.ExecuteScalar(strSQL) <> Me.cdeFechaCD.Value Then
                    MsgBox("Fecha del Depósito (" & XcDatos.ExecuteScalar(strSQL) & ") NO coincide con la nueva" & Chr(13) & "Fecha de la Transacción (" & Me.cdeFechaCD.Value & ").", MsgBoxStyle.Critical, NombreSistema)
                    Me.errComprobante.SetError(Me.cdeFechaCD, "Fecha del Depósito NO coincide con la nueva Fecha de la Transacción.")
                    Me.cdeFechaCD.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            End If

            'Fecha de T.C.:
            If Me.cdeFechaTC.ValueIsDbNull Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaTC.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Fecha de Transacción no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Transacción no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Transacción < Fecha TC:
            If (DateDiff("d", cdeFechaCD.Value, cdeFechaTC.Value) < 0) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor a la de Tipo de Cambio.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de Tipo de Cambio.")
                Me.cdeFechaCD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha TC:
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaTC, "No existe una Tasa de Cambio para la Fecha.")
                Me.cdeFechaTC.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Fuente de Financiamiento:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si el periodo de la fecha de transacción esta Cerrado
            If PeriodoAbiertoDadaFecha(Me.cdeFechaCD.Value) = False Then
                MsgBox("El Período Contable correspondiente a la Fecha" & Chr(13) & "de Transacción se encuentra Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaCD, "Período Contable Cerrado.")
                Me.cdeFechaCD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si no Hay elementos en el ListView:
            If lvwCuentas.Items.Count = 0 Then
                MsgBox("Debe indicar Codificación Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.lvwCuentas, "Debe indicar Codificación Contable.")
                Me.lvwCuentas.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si existe descuadre en Débitos/Créditos:
            If (CDbl(cneDebe.Value) - CDbl(cneHaber.Value)) <> 0 Then
                MsgBox("La transacción DEBE estar cuadrada" & Chr(13) & "en Débitos y Créditos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
    ' Procedure Name:       SalvarCodificacion
    ' Descripción:          Este procedimiento permite salvar datos ingresados o
    '                       modificados del Detalle del Comprobante de Diario:
    '                       1. Revertir Mayorizacion Actual en Saldos (UPD).
    '                       2. Elimina Detalles CD (UPD)
    '                       3. Insertar Nuevos Detalles CD (Desde Tabla Tmp)
    '                       4. Mayorizar en Saldos Comprobante 
    '                       5. Actualizar Campos Fechas y Fuente en Encabezado
    '                       6. Actualizar Numero de Comprobante de Diario (CD-).
    '                       7. Actualiza Estado Transacción a Mayorizada.
    '-------------------------------------------------------------------------
    Private Sub SalvarCodificacion()
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""

            Dim StrFechaTx As String
            Dim StrFechaTC As String

            StrFechaTx = Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")
            StrFechaTC = Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")

            '-- Crear Tabla Temporal con los Detalles de la Transacción:
            'CrearTablaTemporal()
            'CargarTablaTemporal()
            Dim Trans As BOSistema.Win.Transact
            Trans = Nothing
            Try

                'Instanciar Trans:
                Trans = New BOSistema.Win.Transact
                'Inicio la Transaccion:
                Trans.BeginTrans()

                CargarTablaTemporal(Trans)

                '-- Ejecuta Procedimiento Almacenado:
                strSQL = " EXEC spScnGrabarJornalizacion " & Me.IdScnComprobante & ", " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ", '" & StrFechaTx & "', '" _
                            & StrFechaTC & "', '" & Me.ModoForm & "', '" & InfoSistema.LoginName & "'," & InfoSistema.IDCuenta & ", " & CambiarNumeroCD() & ", '" & StrNombreTablaTmp & "'"
                Me.IdComprobante = Trans.ExecuteScalar(strSQL)
                'Trans.ExecuteSql(strSQL)

                '-- Eliminar Tabla Temporal
                'EliminarTablaTemporal()
                'Eliminar Tabla
                strSQL = "Drop Table ##" & StrNombreTablaTmp
                Trans.ExecuteSql(strSQL)

                'Finaliza Transaccion:
                Trans.Commit()

            Catch ex As Exception
                Trans.RollBack()
            Finally
                Trans = Nothing
            End Try

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdComprobante = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                    Call GuardarAuditoria(2, 24, "Modificación de Codificación Contable ID:" & Me.IdScnComprobante & ".")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
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
                            SalvarCodificacion()
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
    ' Fecha:                26/11/2007
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cuentas Contables en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCuenta(ByVal intLimpiar As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboCuenta.ClearFields()

            If intLimpiar = 0 Then
                Strsql = " SELECT a.nScnCatalogoContableID, a.sCodigoCuenta, LTRIM(a.sNombreCuenta) as sNombreCuenta, a.nCuentaDetalle, a.nSteCuentaBancariaID " & _
                         " FROM ScnCatalogoContable a " & _
                         " WHERE (a.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
                         " ORDER BY a.sCodigoCuenta"
            Else
                Strsql = " SELECT a.nScnCatalogoContableID, a.sCodigoCuenta, LTRIM(a.sNombreCuenta) as sNombreCuenta, a.nCuentaDetalle, a.nSteCuentaBancariaID " & _
                         " FROM ScnCatalogoContable a " & _
                         " WHERE (a.nScnFuenteFinanciamientoID = 0) " & _
                         " ORDER BY a.sCodigoCuenta"
            End If
            XdtCuenta.ExecuteSql(Strsql)
            Me.cboCuenta.DataSource = XdtCuenta.Source
            Me.cboCuenta.Rebind()

            Me.cboCuenta.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("nCuentaDetalle").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            'Configurar el combo
            Me.cboCuenta.Splits(0).DisplayColumns("sCodigoCuenta").Width = 200
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").Width = 380

            Me.cboCuenta.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.cboCuenta.Columns("sNombreCuenta").Caption = "Cuenta Contable"

            Me.cboCuenta.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
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

            XdtFuenteFondos.ExecuteSql(Strsql)
            Me.cboFuente.DataSource = XdtFuenteFondos.Source
            Me.cboFuente.Rebind()

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

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboFuente_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFuente.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cdeFechaCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCD.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaTC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaTC.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        If Me.cboFuente.SelectedIndex <> -1 Then
            CargarCuenta(0)
        Else
            CargarCuenta(1)
        End If
        vbModifico = True
    End Sub

    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        If Me.cboCuenta.SelectedIndex <> -1 Then
            txtCuenta.Text = cboCuenta.Columns("sNombreCuenta").Value
        Else
            txtCuenta.Text = ""
        End If
        vbModifico = True
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2007
    ' Procedure Name:       CargarListView
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Cuentas Contables en control ListView.
    '-------------------------------------------------------------------------
    Private Sub CargarListView()
        Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
        XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable

        Try

            Dim StrSql As String
            Dim IntRegistros As Integer

            StrSql = "SELECT D.nScnTransaccionContableDetalleID, D.nScnTransaccionContableID, D.nScnCatalogoContableID, C.nScnFuenteFinanciamientoID, " & _
                     "D.nDebito, D.nMontoC, D.nMontoD, C.sCodigoCuenta, C.sNombreCuenta, ISNULL(C.nSteCuentaBancariaID, 0) AS nSteCuentaBancariaID " & _
                     "FROM  ScnTransaccionContableDetalle D INNER JOIN ScnCatalogoContable C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID " & _
                     "WHERE (D.nScnTransaccionContableID = " & IdComprobante & ")"
            XdtTmpCuentas.ExecuteSql(StrSql)
            IntRegistros = XdtTmpCuentas.Count

            'Mostrar details:
            lvwCuentas.View = View.Details
            'Llenar ListView:
            While IntRegistros > 0
                '---------------------------
                Dim lvwItem As New ListViewItem(Str(XdtTmpCuentas.ValueField("nScnTransaccionContableDetalleID")), 0) 'Comprobante Detalle ID
                lvwItem.SubItems.Add(XdtTmpCuentas.ValueField("nScnTransaccionContableID"))
                lvwItem.SubItems.Add(XdtTmpCuentas.ValueField("nScnCatalogoContableID"))
                lvwItem.SubItems.Add(XdtTmpCuentas.ValueField("sCodigoCuenta"))
                lvwItem.SubItems.Add(XdtTmpCuentas.ValueField("sNombreCuenta"))
                lvwItem.SubItems.Add(XdtTmpCuentas.ValueField("nDebito"))
                If XdtTmpCuentas.ValueField("nDebito") = 1 Then 'Debe
                    lvwItem.SubItems.Add(Format(XdtTmpCuentas.ValueField("nMontoC"), "#,##0.00;(#,##0.00)"))
                    lvwItem.SubItems.Add("")
                    cneDebe.Value = Math.Round(CDbl(cneDebe.Value) + CDbl(XdtTmpCuentas.ValueField("nMontoC")), 2)
                Else
                    lvwItem.SubItems.Add("")
                    lvwItem.SubItems.Add(Format(XdtTmpCuentas.ValueField("nMontoC"), "#,##0.00;(#,##0.00)"))
                    cneHaber.Value = Math.Round(CDbl(cneHaber.Value) + CDbl(XdtTmpCuentas.ValueField("nMontoC")), 2)
                End If
                lvwItem.SubItems.Add(Format(XdtTmpCuentas.ValueField("nMontoD"), "#,##0.00;(#,##0.00)"))
                lvwItem.SubItems.Add(XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID"))
                '---------------------------
                'Agregar Item a ListView:
                lvwCuentas.Items.AddRange(New ListViewItem() {lvwItem})
                '---------------------------
                XdtTmpCuentas.Source.MoveNext()
                IntRegistros = IntRegistros - 1
            End While

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpCuentas.Close()
            XdtTmpCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/11/2007
    ' Procedure Name:       AgregarCuentaContable
    ' Descripción:          Este procedimiento permite Agregar una Cuenta Contable
    '                       en el control ListView.
    '-------------------------------------------------------------------------
    Private Sub AgregarCuentaContable()
        Try

            '---------------------------
            Dim lvwItem As New ListViewItem("0", 0) 'Comprobante Detalle ID
            lvwItem.SubItems.Add(IdComprobante)
            lvwItem.SubItems.Add(Me.cboCuenta.Columns("nScnCatalogoContableID").Value)
            lvwItem.SubItems.Add(Me.cboCuenta.Text)
            lvwItem.SubItems.Add(Me.txtCuenta.Text)
            lvwItem.SubItems.Add(IIf(chkDebe.Checked, "1", "0"))
            If chkDebe.Checked = True Then 'Debe
                lvwItem.SubItems.Add(Format(Me.cneMonto.Value, "#,##0.00;(#,##0.00)"))
                lvwItem.SubItems.Add("")
                cneDebe.Value = Math.Round(CDbl(cneDebe.Value) + CDbl(Me.cneMonto.Value), 2)
            Else
                lvwItem.SubItems.Add("")
                lvwItem.SubItems.Add(Format(Me.cneMonto.Value, "#,##0.00;(#,##0.00)"))
                cneHaber.Value = Math.Round(CDbl(cneHaber.Value) + CDbl(Me.cneMonto.Value), 2)
            End If
            'lvwCuentas.Items(2).SubItems.Add(cboCuenta.Columns("nScnCatalogoContableID").Value)
            lvwItem.SubItems.Add(Format(DblMontoDolares, "#,##0.00;(#,##0.00)"))
            lvwItem.SubItems.Add(cboFuente.Columns("nScnFuenteFinanciamientoID").Value)
            '--------------------------- 
            'Agregar Item a ListView:
            lvwCuentas.Items.AddRange(New ListViewItem() {lvwItem})
            'Me.Controls.Add(lvwCuentas)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2007
    ' Procedure Name:       CargarTablaTemporal
    ' Descripción:          Esta función permite Cargar tabla con datos temporales
    '                       de Detalles de la Transacción Contable.
    '-------------------------------------------------------------------------
    Private Sub CargarTablaTemporal(ByRef Trans As BOSistema.Win.Transact)
        'Dim Trans As BOSistema.Win.Transact
        'Trans = Nothing
        Try
            Dim i As Integer
            Dim Strsql As String, strGUID As String
            Dim nMontoCordobas As Double

            '-----------------------------------------------
            'Randomize()
            strGUID = Replace(XcDatosGl.ExecuteScalar("Select Convert(varchar(36), NewID())"), "-", "", 1, -1, CompareMethod.Text)
            StrNombreTablaTmp = InfoSistema.LoginName & strGUID 'Trim(Str(Int((9999 * Rnd()) + 1)))
            'StrNombreTablaTmp = "x"

            'Si la tabla ya existe en tempDb eliminar la misma:
            Strsql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
            If XcDatosGl.ExecuteScalar(Strsql) > 0 Then
                Strsql = "Drop Table  ##" & StrNombreTablaTmp
                XcDatosGl.ExecuteNonQuery(Strsql)
            End If
            '------------------------------------------------

            'Instanciar Trans:
            'Trans = New BOSistema.Win.Transact
            'Inicio la Transaccion:
            'Trans.BeginTrans()

            '--------------------------------------------------------------------------------
            'Crea la Tabla en: System Databases: tempDb: Temporary Tables
            Strsql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
                                "[nTransaccionContableID] [int] NOT NULL , " & _
                                "[nCatalogoContableID] [int] NOT NULL , " & _
                                "[nDebito] [tinyint] NOT NULL , " & _
                                "[nMontoC] [numeric] (18, 2) NOT NULL , " & _
                                "[nMontoD] [numeric] (18, 2) NOT NULL)"
            Trans.ExecuteSql(Strsql)
            '--------------------------------------------------------------------------------
            For i = 0 To lvwCuentas.Items.Count - 1
                If lvwCuentas.Items(i).SubItems(5).Text = "1" Then
                    nMontoCordobas = CDbl(lvwCuentas.Items(i).SubItems(6).Text)
                Else
                    nMontoCordobas = CDbl(lvwCuentas.Items(i).SubItems(7).Text)
                End If
                Strsql = "Insert Into ##" & StrNombreTablaTmp & " (" & _
                         "nTransaccionContableID, nCatalogoContableID, nDebito, nMontoC, nMontoD) " & _
                         " Values (" & IdScnComprobante & ", " & lvwCuentas.Items(i).SubItems(2).Text & ", " & lvwCuentas.Items(i).SubItems(5).Text & ", " & nMontoCordobas & "," & CDbl(lvwCuentas.Items(i).SubItems(8).Text) & ")"
                Trans.ExecuteSql(Strsql)
            Next i

            'Finaliza Transacción:
            'Trans.Commit()

        Catch ex As Exception
            'Trans.RollBack()
            Control_Error(ex)
        Finally
            'Trans = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2007
    ' Procedure Name:       CrearTablaTemporal
    ' Descripción:          Esta función permite Crear tabla para el registro 
    '                       de datos temporales.
    '-------------------------------------------------------------------------
    Private Sub CrearTablaTemporal()
        Try

            Dim StrSql As String, strGUID As String
            'Randomize()

            strGUID = Replace(XcDatosGl.ExecuteScalar("Select Convert(varchar(36), NewID())"), "-", "", 1, -1, CompareMethod.Text)
            StrNombreTablaTmp = InfoSistema.LoginName & strGUID 'Trim(Str(Int((9999 * Rnd()) + 1)))

            'Si la tabla ya existe en tempDb eliminar la misma:
            StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
            If XcDatosGl.ExecuteScalar(StrSql) > 0 Then
                StrSql = "Drop Table  ##" & StrNombreTablaTmp
                XcDatosGl.ExecuteNonQuery(StrSql)
            End If

            'Crea la Tabla en: System Databases: tempDb: Temporary Tables
            StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
                                "[nTransaccionContableID] [int] NOT NULL , " & _
                                "[nCatalogoContableID] [int] NOT NULL , " & _
                                "[nDebito] [tinyint] NOT NULL , " & _
                                "[nMontoC] [numeric] (18, 2) NOT NULL , " & _
                                "[nMontoD] [numeric] (18, 2) NOT NULL)"
            XcDatosGl.ExecuteNonQuery(StrSql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2007
    ' Procedure Name:       EliminarTablaTemporal
    ' Descripción:          Esta función permite Eliminar los datos temporales
    '                       creados para Detalles de Transacción Contable.
    '-------------------------------------------------------------------------
    Private Sub EliminarTablaTemporal()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            'Eliminar Tabla Temporal
            StrSql = "Drop Table ##" & StrNombreTablaTmp
            XcDatos.ExecuteNonQuery(StrSql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/11/2007
    ' Procedure Name:       ValidaAdicion
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaAdicion() As Boolean
        Try

            ValidaAdicion = True
            Dim i As Integer
            Dim StrSql As String
            Me.errComprobante.Clear()

            'Cuenta Contable:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe indicar Cuenta Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cboCuenta, "Debe indicar Cuenta Contable.")
                Me.cboCuenta.Focus()
                ValidaAdicion = False
                Exit Function
            End If

            'Imposible si no se indicó un Monto Válido:
            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                ValidaAdicion = False
                Exit Function
            End If
            If CDbl(cneMonto.Value) = 0 Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                ValidaAdicion = False
                Exit Function
            End If

            'Fecha de Transacción:
            If Me.cdeFechaCD.ValueIsDbNull Then
                MsgBox("La Fecha de Transacción NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE quedar vacía.")
                Me.cdeFechaCD.Focus()
                ValidaAdicion = False
                Exit Function
            End If

            'Fecha de T.C.:
            If Me.cdeFechaTC.ValueIsDbNull Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaTC.Focus()
                ValidaAdicion = False
                Exit Function
            End If

            'Fecha de Transacción no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaAdicion = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Transacción no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaAdicion = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaAdicion = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaAdicion = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Encuentra Tasa de Cambio con la Fecha:
            If nTasaCambio(Me.cdeFechaTC.Value) = -1 Then
                MsgBox("No existe una Tasa de Cambio para la Fecha.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cdeFechaTC, "No existe una Tasa de Cambio para la Fecha.")
                Me.cdeFechaTC.Focus()
                ValidaAdicion = False
                Exit Function
            End If

            'Encuentra Monto en Dólares:
            DblMontoDolares = Format(CDbl(cneMonto.Value) / nTasaCambio(Me.cdeFechaTC.Value), "#,##0.00;(#,##0.00)")

            'Imposible si la Cuenta ya Existe en ListView con el mismo Tipo de Movimiento:
            For i = 0 To lvwCuentas.Items.Count - 1
                If (lvwCuentas.Items(i).SubItems(2).Text = cboCuenta.Columns("nScnCatalogoContableID").Value) And (CInt(lvwCuentas.Items(i).SubItems(5).Text) = CInt(IIf(chkDebe.Checked, 1, 0))) Then
                    MsgBox("La Cuenta ya existe.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errComprobante.SetError(Me.cboCuenta, "La Cuenta ya existe.")
                    Me.cboCuenta.Focus()
                    ValidaAdicion = False
                    Exit Function
                End If
            Next i

            'Cuenta debe ser de Detalle:
            If cboCuenta.Columns("nCuentaDetalle").Value = 0 Then
                MsgBox("La Cuenta DEBE ser de Detalle.", MsgBoxStyle.Critical, NombreSistema)
                Me.errComprobante.SetError(Me.cboCuenta, "La Cuenta DEBE ser de Detalle.")
                Me.cboCuenta.Focus()
                ValidaAdicion = False
                Exit Function
            End If

            REM Si la Cuenta crea Saldos Rojos:
            'Definir Bloqueo de Saldos Rojos.
            'If nMontoSaldoRojo(cboCuenta.Columns("nScnCATALOGOCONTABLEID").Value, chkDebe.Checked, cneMonto.Value) < 0 Then
            '    MsgBox("El movimiento crearía Saldos Rojos.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaAdicion = False
            'End If

            'Si la cuenta bancaria se encuentra Cerrada:
            If IsNumeric(cboCuenta.Columns("nSteCuentaBancariaID").Value) Then
                StrSql = "SELECT * FROM SteCuentaBancaria WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") AND (nCerrada = 1)"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("La cuenta bancaria se encuentra Cerrada.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errComprobante.SetError(Me.cboCuenta, "La cuenta bancaria se encuentra Cerrada.")
                    Me.cboCuenta.Focus()
                    ValidaAdicion = False
                    Exit Function
                End If
            End If

            'Imposible Agregar Cuenta si es un Comprobante de Recuperación de Crédito
            'y la Cuenta Contable existe en parámetros para la fuente de fondos y con
            'los tipos de afectación:
            '     1: Cuentas por Cobrar Socias
            '     2: Interes por Mora
            '     3: Interes Corriente
            '     4: Mantenimiento Valor
            StrSql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = 'CR') AND (ScnTransaccionContable.nScnTransaccionContableID = " & IdScnComprobante & ")"
            '-- Es un Comprobante de Recuperación de Crédito: 
            If RegistrosAsociados(StrSql) Then
                '-- La Cuenta Contable seleccionada existe en Parámetros para la Fuente de 
                '-- fondos y con los tipos de afectacion entre 1 - 4.
                StrSql = "SELECT P.nScnCatalogoContableID " & _
                         "FROM ScnTransaccionParametros AS P INNER JOIN StbValorCatalogo AS A ON P.nStbTipoAfectacionID = A.nStbValorCatalogoID INNER JOIN StbValorCatalogo AS C ON P.nStbTipoDocContableID = C.nStbValorCatalogoID " & _
                         "WHERE (A.sCodigoInterno IN ('1', '2', '3', '4')) AND (P.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") AND (C.sCodigoInterno = 'CR') AND (P.nScnCatalogoContableID = " & cboCuenta.Columns("nScnCatalogoContableID").Value & ")"
                'REM COMENTARIO TEMPORAL 24/03/2009
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Imposible Agregar manualmente esta Cuenta Contable" & Chr(13) & "para Comprobantes de Cierre Diario de Cartera.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errComprobante.SetError(Me.cboCuenta, "Cuenta Inválida.")
                    Me.cboCuenta.Focus()
                    ValidaAdicion = False
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/11/2007
    ' Procedure Name:       CambiarNumeroCD
    ' Descripción:          Esta función permite determinar si es necesario
    '                       modificar el número de comprobante por cambio en
    '                       la fecha de la transacción contable.
    '-------------------------------------------------------------------------
    Private Function CambiarNumeroCD() As Integer
        
        Try
            Dim StrSql As String
            CambiarNumeroCD = 0

            'Busca el registro del Comprobante actual:
            'Verifica: Si es CD, CR, CA o CC
            'Si la fecha de la transacción sufrio cambio
            StrSql = "SELECT E.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable E INNER JOIN StbValorCatalogo C ON E.nStbTipoDocContableID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno IN ('CD', 'CR', 'CA', 'CC')) " & _
                     "AND (E.nScnTransaccionContableID = " & IdScnComprobante & ") " & _
                     "AND (E.dFechaTransaccion <> CONVERT(DATETIME, '" & Format(Me.cdeFechaCD.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(StrSql) Then
                CambiarNumeroCD = 1
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/11/2007
    ' Procedure Name:       cmdAgregarC_Click
    ' Descripción:          Permite Agregar Cuenta Contable al ListView.
    '-------------------------------------------------------------------------
    Private Sub cmdAgregarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarC.Click
        Try
            If ValidaAdicion() Then
                AgregarCuentaContable()
                grpDatosGenerales.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/11/2007
    ' Procedure Name:       cmdEliminarC_Click
    ' Descripción:          Permite Eliminar Cuenta Contable de ListView.
    '-------------------------------------------------------------------------
    Private Sub cmdEliminarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminarC.Click
        Try

            Dim StrSql As String
            'Imposible si no hay Cuentas en Listiview:
            If lvwCuentas.Items.Count = 0 Then
                MsgBox("No existen Cuentas registradas.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Debe seleccionar un Item:
            If lvwCuentas.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar la Cuenta a eliminar.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible Eliminar Cuenta si es un Comprobante de Recuperación de Crédito
            'y la Cuenta Contable existe en parámetros para la fuente de fondos y con
            'los Tipos de Afectación siguientes:
            '    1. Cuentas por Cobrar Socias
            '    2. Interes por Mora
            '    3. Interes Corriente
            '    4. Mantenimiento Valor.
            StrSql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = 'CR') AND (ScnTransaccionContable.nScnTransaccionContableID = " & IdScnComprobante & ")"
            '-- Es un Comprobante de Recuperación de Crédito:
            If RegistrosAsociados(StrSql) Then
                '-- La Cuenta Contable en el ListView existe en Parámetros para la Fuente de 
                '-- fondos del Comprobante y con los tipos de afectacion entre 1 y 4.
                StrSql = "SELECT P.nScnCatalogoContableID " & _
                         "FROM ScnTransaccionParametros AS P INNER JOIN StbValorCatalogo AS A ON P.nStbTipoAfectacionID = A.nStbValorCatalogoID INNER JOIN StbValorCatalogo AS C ON P.nStbTipoDocContableID = C.nStbValorCatalogoID " & _
                         "WHERE (A.sCodigoInterno IN ('1', '2', '3', '4')) AND (P.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") AND (C.sCodigoInterno = 'CR') AND (P.nScnCatalogoContableID = " & lvwCuentas.FocusedItem.SubItems(2).Text & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Imposible eliminar esta Cuenta Contable para" & Chr(13) & "Comprobantes de Cierre Diario de Cartera.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If
            End If

            'Disminuye Montos Totales de la Transacción: 
            If lvwCuentas.FocusedItem.SubItems(5).Text = "1" Then 'Débitos:
                Me.cneDebe.Value = Math.Round((CDbl(Me.cneDebe.Value) - CDbl(Me.lvwCuentas.FocusedItem.SubItems(6).Text)), 2)
            Else 'Créditos:
                Me.cneHaber.Value = Math.Round((CDbl(Me.cneHaber.Value) - CDbl(Me.lvwCuentas.FocusedItem.SubItems(7).Text)), 2)
            End If

            'Elimina Cuenta del ListView: 
            lvwCuentas.Items.RemoveAt(lvwCuentas.FocusedItem.Index)

            If lvwCuentas.Items.Count = 0 Then
                grpDatosGenerales.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class