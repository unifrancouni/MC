' ------------------------------------------------------------------------
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Meta .
'-------------------------------------------------------------------------
Imports Microsoft.VisualBasic
Public Class frmSccEditMetasPrograma

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intMetaID As Integer
    Dim blnModificar As Boolean = True

    

    '-- Clases para procesar la informacion de los combos
    Dim XdsMeta As BOSistema.Win.XDataSet
    Dim XdsFicha As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjMetadt As BOSistema.Win.SccEntCredito.SccMetasProgramaDataTable
    Dim ObjMetadr As BOSistema.Win.SccEntCredito.SccMetasProgramaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Ficha.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la meta  que corresponde al campo
    'nSccMetasProgramaID de la tabla SccMetasPrograma.
    Public Property intStbMetaID() As Long
        Get
            intStbMetaID = intMetaID
        End Get
        Set(ByVal value As Long)
            intMetaID = value
        End Set
    End Property
    Dim strColorFrm As String
    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

    
    Private Sub frmStbEditMetasPrograma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                XdsMeta.Close()
                XdsMeta = Nothing

                ObjMetadt.Close()
                ObjMetadt = Nothing

                ObjMetadr.Close()
                ObjMetadr = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmStbEditBarrio_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la Ficha en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditMetasPrograma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            CargarTipoPlazo()
            Me.cboTipoPlazo.Enabled = False
            'Por que se calcula la fecha final. No se ingresa la fecha
            Me.cdeFechaFinal.Enabled = False
            'Si el formulario está en modo edición
            'cargar los datos de la meta.
            If ModoFrm = "UPD" Then
                CargarMeta()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Meta"
            Else
                Me.Text = "Modificar Meta"
            End If

            ObjMetadt = New BOSistema.Win.SccEntCredito.SccMetasProgramaDataTable
            ObjMetadr = New BOSistema.Win.SccEntCredito.SccMetasProgramaRow
            XdsMeta = New BOSistema.Win.XDataSet
            XdsFicha = New BOSistema.Win.XDataSet
            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()

            If ModoFrm = "ADD" Then

                ObjMetadr = ObjMetadt.NewRow

                ''Inicializar los Length de los campos
                'Me.txtDescripcion.MaxLength = ObjMetadr.GetColumnLenght("sNombre")
                'Me.txtCodigo.MaxLength = ObjMetadr.GetColumnLenght("sCodigo")

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar los datos de la Meta
    '                       seleccionada en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarMeta()
        Dim ObjUbicacionDT As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Barrio correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjMetadt.Filter = "nSccMetasProgramaID= " & Me.intMetaID
            ObjMetadt.Retrieve()
            If ObjMetadt.Count = 0 Then
                Exit Sub
            End If
            ObjMetadr = ObjMetadt.Current
            strSQL = "SELECT     nSccMetasProgramaID, nStbDepartamentoID, nStbMunicipioID, " & _
                                 "  SDepartamento,  SMunicipio,  nStbDistritoID, " & _
                                 " SDistrito, CodDistrito,nStbTipoPlazoID,CodigoPlazo,DescripcionPlazo, dFechaInicio, dFechaFin, nCantidadNuevos, nMontoNuevos,nCantidadRecurrentes,nMontoRecurrentes From vwSccMetasPrograma " & _
                                 " Where nSccMetasProgramaID = " & ObjMetadr.nSccMetasProgramaID

            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then

                XdsMeta("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))

                If Not ObjUbicacionDT.ValueField("nStbMunicipioID") Is DBNull.Value Then
                    CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    If Me.cboMunicipio.ListCount > 0 Then
                        Me.cboMunicipio.SelectedIndex = 0
                        XdsMeta("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    End If

                    If Not ObjUbicacionDT.ValueField("nStbDistritoID") Is DBNull.Value Then
                        CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                        If Me.cboDistrito.ListCount > 0 Then
                            Me.cboDistrito.SelectedIndex = 0
                            XdsMeta("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                        End If
                    End If
                End If
            End If


            Me.cneCredito.Value = ObjUbicacionDT.ValueField("nCantidadNuevos")
            Me.cneMonto.Value = ObjUbicacionDT.ValueField("nMontoNuevos")
            Me.cneCreditoRecurrente.Value = ObjUbicacionDT.ValueField("nCantidadRecurrentes")
            Me.cneMontoRecurrente.Value = ObjUbicacionDT.ValueField("nMontoRecurrentes")

            Me.cdeFechaInicio.Value = ObjUbicacionDT.ValueField("dFechaInicio")
            Me.cdeFechaFinal.Value = ObjUbicacionDT.ValueField("dFechaFin")



            Me.cboDepartamento.Enabled = False
            Me.cboMunicipio.Enabled = False
            Me.cboDistrito.Enabled = False
            Me.cboTipoPlazo.Enabled = False
            Me.cdeFechaInicio.Enabled = False
            Me.cdeFechaFinal.Enabled = False

            If XdsFicha("TipoPlazo").Count > 0 Then
                XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", ObjUbicacionDT.ValueField("nStbTipoPlazoID"))
            End If




        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjUbicacionDT.Close()
            ObjUbicacionDT = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then
                SalvarMeta()

                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim objMetaTmpDT As New BOSistema.Win.SccEntCredito.SccMetasProgramaDataTable
        Dim StrFilter As String
        Dim dFechaInicio, dFechaFinal As Date
        Try
            

            ValidaDatosEntrada = True
            Me.errMeta.Clear()


            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            If Me.cboTipoPlazo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cboDistrito, "Debe seleccionar un Plazo válido.")
                Me.cboTipoPlazo.Focus()
                Exit Function
            End If

            'Fecha de Inicio
            If Me.cdeFechaInicio.ValueIsDbNull Then
                MsgBox("La Fecha de Inicio NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cdeFechaInicio, "La Fecha de Inicio NO DEBE quedar vacía.")
                Me.cdeFechaInicio.Focus()
                Exit Function
            End If

            If Day(Me.cdeFechaInicio.Value) <> 1 Then
                MsgBox("La Fecha de Inicio Solo  acepta el primer día de cada mes.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cdeFechaInicio, "La Fecha de Inicio Solo  acepta el primer día de cada mes.")
                Me.cdeFechaInicio.Focus()
                Exit Function
            End If

            If Year(Me.cdeFechaInicio.Value) <> Year(Me.cdeFechaFinal.Value) Then
                MsgBox("Solo  se aceptan periodos para el mismo año.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cdeFechaInicio, "Solo  se aceptan periodos para el mismo año.")
                Me.cdeFechaInicio.Focus()
                Exit Function
            End If

            'If Year(Me.cdeFechaInicio.Value) <> FechaServer.Year Then
            '    MsgBox("Solo  se aceptan periodos iguales o mayores para el año.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errMeta.SetError(Me.cdeFechaInicio, "Solo  se aceptan periodos para el mismo año.")
            '    Me.cdeFechaInicio.Focus()
            '    Exit Function
            'End If

            ''Fecha del Recibo no menor que la Fecha de Desembolso
            'If dFechaRecibo.Date < Me.cdeFecha.Calendar.MinDate.Date Then
            '    MsgBox("Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Menor que la Fecha del Desembolso (" & Me.cdeFecha.Calendar.MinDate.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Menor que la Fecha del Desembolso (" & Me.cdeFecha.Calendar.MinDate.Date & ").")
            '    Me.cdeFecha.Focus()
            '    Exit Function
            'End If

            ''Fecha del Recibo no mayor que la Fecha del Servidor
            'If dFechaRecibo.Date > FechaServer.Date Then
            '    MsgBox("Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").")
            '    Me.cdeFecha.Focus()
            '    Exit Function
            'End If
            If IsDBNull(Me.cneCredito.Value) Then
                MsgBox("Debe indicar un total de créditos nuevos con cero o más.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cneCredito, "Debe indicar un total de créditos mayor que cero.")
                Me.cneCredito.Focus()
                Exit Function
            End If

            If IsDBNull(Me.cneCreditoRecurrente.Value) Then
                MsgBox("Debe indicar un total de créditos recurrentes con cero o más.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cneCredito, "Debe indicar un total de créditos recurrentes con cero o más.")
                Me.cneCreditoRecurrente.Focus()
                Exit Function
            End If



            If Val(Me.cneCredito.Value) + Val(Me.cneCreditoRecurrente.Value) <= 0 Then
                MsgBox("Debe indicar un total de créditos entre nuevos y recurerentes mayor que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cneCredito, "Debe indicar un total de créditos entre nuevos y recurerentes mayor que cero.")
                Me.cneCredito.Focus()
                Exit Function
            End If
            If IsDBNull(Me.cneMonto.Value) Then
                MsgBox("Debe indicar un Monto  de créditos nuevos igual o  mayor que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cneMonto, "Debe indicar un Monto  de créditos nuevos igual o  mayor que cero.")
                Me.cneMonto.Focus()
                Exit Function
            End If

            If IsDBNull(Me.cneMontoRecurrente.Value) Then
                MsgBox("Debe indicar un Monto  de créditos recurrentes igual o  mayor que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cneMontoRecurrente, "Debe indicar un Monto  de créditos recurrentes igual o  mayor que cero.")
                Me.cneMontoRecurrente.Focus()
                Exit Function
            End If


            If Val(Me.cneMonto.Value) + Val(Me.cneMontoRecurrente.Value) <= 0 Then
                MsgBox("Debe indicar un Monto  de créditos entre nuevos y recurrentes mayor que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errMeta.SetError(Me.cneMonto, "Debe indicar un Monto  de créditos entre nuevos y recurrentes mayor que cero.")
                Me.cneMonto.Focus()
                Exit Function
            End If
            'Determinar duplicados
            dFechaInicio = Me.cdeFechaInicio.Value
            dFechaFinal = Me.cdeFechaFinal.Value
            If ModoFrm = "ADD" Then

                StrFilter = " nStbDistritoID = " & XdsMeta("Distrito").ValueField("nStbDistritoID") & " And nStbMunicipioID = " & XdsMeta("Municipio").ValueField("nStbMunicipioID")

                StrFilter = StrFilter + " And (( Convert(Varchar(10),dFechaInicio , 112) >= Convert(Varchar(10),'" & Format(dFechaInicio.Date, "yyyy-MM-dd") & "' , 112) " & " And  Convert(Varchar(10),dFechaInicio, 112) <= Convert(Varchar(10),'" & Format(dFechaFinal.Date, "yyyy-MM-dd") & "', 112) )  "
                StrFilter = StrFilter + " Or ( Convert(Varchar(10),dFechaFin , 112) >= Convert(Varchar(10),'" & Format(dFechaInicio.Date, "yyyy-MM-dd") & "' , 112) " & " And  Convert(Varchar(10),dFechaFin, 112) <= Convert(Varchar(10),'" & Format(dFechaFinal.Date, "yyyy-MM-dd") & "', 112) ) )  "

                objMetaTmpDT.Filter = StrFilter
                objMetaTmpDT.Retrieve()

                If objMetaTmpDT.Count > 0 Then
                    MsgBox("Ya existen metas ingresadas en ese periodo para esta ubicacion geografica. ", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Exit Function
                End If

            End If

            

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            objMetaTmpDT.Close()
            objMetaTmpDT = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Procedure Name:       SalvarMeta
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Meta en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarMeta()
        Try
            If ModoFrm = "ADD" Then
                ObjMetadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjMetadr.dFechaCreacion = FechaServer()
            Else
                ObjMetadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjMetadr.dFechaModificacion = FechaServer()
            End If

            ObjMetadr.nStbDistritoID = XdsMeta("Distrito").ValueField("nStbDistritoID")
            ObjMetadr.nStbMunicipioID = XdsMeta("Municipio").ValueField("nStbMunicipioID")

            ObjMetadr.nStbTipoPlazoID = Me.cboTipoPlazo.Columns("nStbValorCatalogoID").Value
            ObjMetadr.nCantidadNuevos = Me.cneCredito.Value
            ObjMetadr.nMontoNuevos = Me.cneMonto.Value
            ObjMetadr.nCantidadRecurrentes = Me.cneCreditoRecurrente.Value
            ObjMetadr.nMontoRecurrentes = Me.cneMontoRecurrente.Value
            ObjMetadr.dFechaInicio = Me.cdeFechaInicio.Value
            ObjMetadr.dFechaFin = Me.cdeFechaFinal.Value






            ObjMetadr.Update()

            'Asignar el Id de la Meta a la 
            'variable publica del formulario
            Me.intMetaID = ObjMetadr.nSccMetasProgramaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Declaracion de Variables 
            Dim res As Object

            If (vbModifico = True) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarMeta()
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

    

    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0, 0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0, 0)
                If Me.cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                End If
                Me.cboDistrito.Enabled = False
                'CargarBarrio(0, 0)
            End If
        Else
            CargarDistrito(1, 0)
        End If
        vbModifico = True
    End Sub
    
    Private Sub cboDepartamento_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0, 0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0, 0)
                If Me.cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                End If
                Me.cboDistrito.Enabled = False
            End If
        Else
            CargarDistrito(1, 0)
        End If
        vbModifico = True
    End Sub

#Region "Combos"


    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoPlazo
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazo()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 And (sCodigoInterno='M' Or sCodigoInterno='B' Or sCodigoInterno='T' Or sCodigoInterno='E' Or sCodigoInterno='A') " & _
                     " Order by a.nStbValorCatalogoID Desc "

            If XdsFicha.ExistTable("TipoPlazo") Then
                XdsFicha("TipoPlazo").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoPlazo")
                XdsFicha("TipoPlazo").Retrieve()
            End If
            
            'Asignando a las fuentes de datos
            Me.cboTipoPlazo.DataSource = XdsFicha("TipoPlazo").Source

            'Ubicarse en el registro de trimestre
            If XdsFicha("TipoPlazo").Count > 0 Then
                XdsFicha("TipoPlazo").SetCurrentByID("sCodigoInterno", "M")
            End If

            Me.cboTipoPlazo.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoPlazo.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazo.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            If XdsMeta.ExistTable("Departamento") Then
                XdsMeta("Departamento").ExecuteSql(Strsql)
            Else
                XdsMeta.NewTable(Strsql, "Departamento")
                XdsMeta("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsMeta("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsMeta("Departamento").Count > 0 Then
                XdsMeta("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where a.nStbDepartamentoID = " & XdsMeta("Departamento").ValueField("nStbDepartamentoID") & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsMeta("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " Or a.nStbMunicipioID = " & intMunicipioID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsMeta.ExistTable("Municipio") Then
                XdsMeta("Municipio").ExecuteSql(Strsql)
            Else
                XdsMeta.NewTable(Strsql, "Municipio")
                XdsMeta("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsMeta("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsMeta("Municipio").Count > 0 Then
                XdsMeta("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If
            If Me.cboMunicipio.SelectedIndex = -1 And Me.cboMunicipio.ListCount > 0 Then
                Me.cboMunicipio.SelectedIndex = 0
            End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de Distritos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbDistrito a " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbDistrito a " & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsMeta.ExistTable("Distrito") Then
                XdsMeta("Distrito").ExecuteSql(Strsql)
            Else
                XdsMeta.NewTable(Strsql, "Distrito")
                XdsMeta("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsMeta("Distrito").Source
            Me.cboDistrito.Rebind()


            'Ubicarse en el primer registro
            If XdsMeta("Distrito").Count > 0 Then
                If XdsMeta("Municipio").ValueField("Descripcion") <> "Managua" Then
                    XdsMeta("Distrito").SetCurrentByID("sCodigo", "0")
                Else
                    XdsMeta("Distrito").SetCurrentByID("sCodigo", "2")
                End If
            End If

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'me.cboDistrito.PartialRightColumn  

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


#End Region

    Private Sub EncontrarFechaFinal()
        If IsDate(Me.cdeFechaInicio.Value) And Trim(cboTipoPlazo.Columns("sCodigoInterno").Value) <> "" Then
            Select Case cboTipoPlazo.Columns("sCodigoInterno").Value
                Case "M"
                    Me.cdeFechaFinal.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Me.cdeFechaInicio.Value))
                Case "B"
                    Me.cdeFechaFinal.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 2, Me.cdeFechaInicio.Value))
                Case "T"
                    Me.cdeFechaFinal.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 3, Me.cdeFechaInicio.Value))
                Case "E"
                    Me.cdeFechaFinal.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 6, Me.cdeFechaInicio.Value))
                Case "A"
                    Me.cdeFechaFinal.Value = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, Me.cdeFechaInicio.Value))


            End Select
        End If

    End Sub
    Private Sub cboTipoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazo.TextChanged
        EncontrarFechaFinal()
    End Sub
    

    Private Sub cdeFechaInicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaInicio.TextChanged
        EncontrarFechaFinal()
    End Sub
End Class