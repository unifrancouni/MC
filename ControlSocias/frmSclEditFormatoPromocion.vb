' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                14/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditFormatoPromocion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Formato de Promoción y Capacitación.
'-------------------------------------------------------------------------
Public Class frmSclEditFormatoPromocion

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSclFormato As Integer
    Dim IdSrhTecnico As Integer
    Dim IntPermiteEditarDelegacion As Integer
    Dim StrTecnico As String

    '-- Crear un data table de tipo Xdataset
    Dim ObjFormatodt As BOSistema.Win.SclEntSocia.SclFormatoPromocionDataTable
    Dim ObjFormatodr As BOSistema.Win.SclEntSocia.SclFormatoPromocionRow

    '-- Crear un data table de tipo Xdataset para Combos
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener Permisos de edición fuera de la Delegación.
    Public Property intSclPermiteEditarDelegacion() As Integer
        Get
            intSclPermiteEditarDelegacion = IntPermiteEditarDelegacion
        End Get
        Set(ByVal value As Integer)
            IntPermiteEditarDelegacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Formato.
    Public Property IdFormato() As Integer
        Get
            IdFormato = IdSclFormato
        End Get
        Set(ByVal value As Integer)
            IdSclFormato = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Tecnico actual.
    Public Property IdTecnico() As Integer
        Get
            IdTecnico = IdSrhTecnico
        End Get
        Set(ByVal value As Integer)
            IdSrhTecnico = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Tecnico actual.
    Public Property sNombreTecnico() As String
        Get
            sNombreTecnico = StrTecnico
        End Get
        Set(ByVal value As String)
            StrTecnico = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       frmSclEditFormatoPromocion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFormatoPromocion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjFormatodt.Close()
                ObjFormatodt = Nothing

                ObjFormatodr.Close()
                ObjFormatodr = Nothing

                XdsUbicacion.Close()
                XdsUbicacion = Nothing

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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       frmSclEditFormatoPromocion_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Formato en caso de estar en el modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFormatoPromocion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento(0)
            Me.txtNombreTecnico.Text = Me.StrTecnico

            'Si el formulario está en modo edición
            'cargar los datos del Formulario.
            If ModoForm <> "ADD" Then
                CargarFormato()
                'Si el Registro no se encuentra Activo:
                InhabilitarControles()
            End If

            Me.cboDepartamento.Select()
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            If ObjFormatodr.nActivo <> 1 Then
                Me.CmdAceptar.Enabled = False
                Me.grpLocalizacion.Enabled = False
                Me.grpSocias.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Formato de Promoción y Capacitación"
            ElseIf ModoFrm = "UPD" Then
                Me.Text = "Modificar Formato de Promoción y Capacitación"
            End If

            ObjFormatodt = New BOSistema.Win.SclEntSocia.SclFormatoPromocionDataTable
            ObjFormatodr = New BOSistema.Win.SclEntSocia.SclFormatoPromocionRow
            XdsUbicacion = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboMercado.ClearFields()

            If ModoForm = "ADD" Then
                ObjFormatodr = ObjFormatodt.NewRow
                'Inicializar los Length de los campos
                'Me.txtDescripcion.MaxLength = ObjFormatodr.GetColumnLenght("sDescripcion")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CargarFormato
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Formato en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarFormato()
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim Strsql As String
        Dim IdMunicipio As Long
        Dim IdDepartamento As Long

        Try
            '-- Buscar el correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjFormatodt.Filter = "nSclFormatoPromocionID = " & IdSclFormato
            ObjFormatodt.Retrieve()
            If ObjFormatodt.Count = 0 Then
                Exit Sub
            End If
            ObjFormatodr = ObjFormatodt.Current

            '-- Cargar Ubicación Geográfica Original:
            'Cargar Combo de Departamentos:
            If Not ObjFormatodr.IsFieldNull("nStbBarrioID") Then
                'Determinar Id de Municipio:
                Strsql = " SELECT nStbMunicipioID FROM StbBarrio WHERE (nStbBarrioID = " & ObjFormatodr.nStbBarrioID & ")"
                IdMunicipio = XcUbicacion.ExecuteScalar(Strsql)
                'Cargar Dpto:
                Strsql = " SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & IdMunicipio & ")"
                IdDepartamento = XcUbicacion.ExecuteScalar(Strsql)
                CargarDepartamento(IdDepartamento)
                If cboDepartamento.ListCount > 0 Then
                    Me.cboDepartamento.SelectedIndex = 0
                End If
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XcUbicacion.ExecuteScalar(Strsql))
            Else
                Me.cboDepartamento.Text = ""
                Me.cboDepartamento.SelectedIndex = -1
            End If

            'Cargar Combo de Municipios:
            If Not ObjFormatodr.IsFieldNull("nStbBarrioID") Then
                CargarMunicipio(0, IdMunicipio)
                If cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                End If
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", IdMunicipio)
            Else
                Me.cboMunicipio.Text = ""
                Me.cboMunicipio.SelectedIndex = -1
            End If

            'Cargar Combo de Distritos:
            If Not ObjFormatodr.IsFieldNull("nStbBarrioID") Then
                Strsql = " SELECT nStbDistritoID FROM StbBarrio WHERE (nStbBarrioID = " & ObjFormatodr.nStbBarrioID & ")"
                CargarDistrito(0, XcUbicacion.ExecuteScalar(Strsql))
                If cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                End If
                XdsUbicacion("Distrito").SetCurrentByID("nStbDistritoID", XcUbicacion.ExecuteScalar(Strsql))
            Else
                Me.cboDistrito.Text = ""
                Me.cboDistrito.SelectedIndex = -1
            End If

            'Cargar Combo de Barrios:
            If Not ObjFormatodr.IsFieldNull("nStbBarrioID") Then
                CargarBarrio(0, ObjFormatodr.nStbBarrioID)
                If cboBarrio.ListCount > 0 Then
                    Me.cboBarrio.SelectedIndex = 0
                End If
                XdsUbicacion("Barrio").SetCurrentByID("nStbBarrioID", ObjFormatodr.nStbBarrioID)
            Else
                Me.cboBarrio.Text = ""
                Me.cboBarrio.SelectedIndex = -1
            End If

            'Cargar Combo de Mercados:
            If Not ObjFormatodr.IsFieldNull("nStbMercadoID") Then
                CargarMercado(0, ObjFormatodr.nStbMercadoID)
                If cboMercado.ListCount > 0 Then
                    Me.cboMercado.SelectedIndex = 0
                End If
                XdsUbicacion("Mercado").SetCurrentByID("nStbMercadoID", ObjFormatodr.nStbMercadoID)
            Else
                Me.cboMercado.Text = ""
                Me.cboMercado.SelectedIndex = -1
            End If

            'Fecha de Actividad:
            If Not ObjFormatodr.IsFieldNull("dFechaActividad") Then
                Me.cdeFecha.Value = ObjFormatodr.dFechaActividad
            Else
                Me.cdeFecha.Value = Me.cdeFecha.ValueIsDbNull
            End If

            'Datos Visita:
            Me.cneCapacitacionA.Value = ObjFormatodr.nPrimerCapacitacion
            Me.cneCapacitacionB.Value = ObjFormatodr.nSegundaCapacitacion
            Me.cneFichasRecepcionadas.Value = ObjFormatodr.nFichasRecepcionadas
            Me.cneFichasVerificadas.Value = ObjFormatodr.nFichasVerificadas
            Me.cneSeguimiento.Value = ObjFormatodr.nSeguimientoPostCredito

            'Inicializar los Length de los campos:
            'Me.txtDescripcion.MaxLength = ObjFormatodr.GetColumnLenght("sDescripcion")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarFormato()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ValidaDatosEntrada = True
            Me.errFormato.Clear()
            Dim StrSql As String

            '-- Datos Localización:
            'Indicar Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Departamento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboDepartamento, "Debe indicar un Departamento.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Indicar Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Municipio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboMunicipio, "Debe indicar un Municipio.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Debe existir Delegacion para el Dpto:
            StrSql = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                     "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                     "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existe una Delegación registrada" & Chr(13) & "para el Departamento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboDepartamento, "Delegación Invalida.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            'El Municipio seleccionado Debe corresponder con el de la Delegación del usuario:
            If IntPermiteEditarDelegacion = 0 Then
                StrSql = "SELECT nStbMunicipioID FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                If cboMunicipio.Columns("nStbMunicipioId").Value <> XcDatos.ExecuteScalar(StrSql) Then
                    MsgBox("Municipio no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFormato.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                    Me.cboMunicipio.Focus()
                    Exit Function
                End If
            End If

            'Indicar Distrito:
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Distrito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboDistrito, "Debe indicar un Distrito.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Indicar Barrio:
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Barrio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboBarrio, "Debe indicar un Barrio.")
                Me.cboBarrio.Focus()
                Exit Function
            End If

            'Indicar Mercado:
            If Me.cboMercado.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Mercado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboMercado, "Debe indicar un Mercado.")
                Me.cboMercado.Focus()
                Exit Function
            End If

            '-- Datos Socias:
            'Fecha de la Actividad:
            If Me.cdeFecha.ValueIsDbNull Then
                MsgBox("La Fecha de las actividades NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cdeFecha, "La Fecha de las actividades NO DEBE quedar vacía.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Imposible si no se indicó Cantidad de Fichas Recepcionadas Válidas:
            If Not IsNumeric(Me.cneFichasRecepcionadas.Value) Then
                MsgBox("Cantidad de Fichas Recepcionadas Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cneFichasRecepcionadas, "Cantidad de Fichas Recepcionadas Inválida.")
                Me.cneFichasRecepcionadas.Focus()
                Exit Function
            End If

            'Imposible si no se indicó Cantidad de Fichas Verificadas Válidas:
            If Not IsNumeric(Me.cneFichasVerificadas.Value) Then
                MsgBox("Cantidad de Fichas Verificadas Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cneFichasVerificadas, "Cantidad de Fichas Verificadas Inválida.")
                Me.cneFichasVerificadas.Focus()
                Exit Function
            End If

            'Imposible si no se indicó Cantidad de Primer Capacitación Válidas:
            If Not IsNumeric(Me.cneCapacitacionA.Value) Then
                MsgBox("Cantidad de Primer Capacitación Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cneCapacitacionA, "Cantidad de Primer Capacitación Inválida.")
                Me.cneCapacitacionA.Focus()
                Exit Function
            End If

            'Imposible si no se indicó Cantidad de Segunda Capacitación Válidas:
            If Not IsNumeric(Me.cneCapacitacionB.Value) Then
                MsgBox("Cantidad de Segunda Capacitación Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cneCapacitacionB, "Cantidad de Segunda Capacitación Inválida.")
                Me.cneCapacitacionB.Focus()
                Exit Function
            End If

            'Imposible si no se indicó Cantidad de Seguimiento Post Crédito Válidas:
            If Not IsNumeric(Me.cneSeguimiento.Value) Then
                MsgBox("Cantidad de Visitas de Seguimiento Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cneSeguimiento, "Cantidad de Visitas de Seguimiento Inválida.")
                Me.cneSeguimiento.Focus()
                Exit Function
            End If

            'Al menos indicar una Cantidad:
            If (CDbl(Me.cneFichasRecepcionadas.Value) + CDbl(Me.cneFichasVerificadas.Value) + CDbl(Me.cneCapacitacionA.Value) + CDbl(Me.cneCapacitacionB.Value) + CDbl(Me.cneSeguimiento.Value)) = 0 Then
                MsgBox("Debe indicar al menos una Cantidad mayor que cero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cneFichasRecepcionadas, "Monto Aprobado Inválido.")
                Me.cneFichasRecepcionadas.Focus()
                Exit Function
            End If

            'Imposible si ya se registro la Actividad para el Tecnico, Fecha, Barrio:
            StrSql = "SELECT nSclFormatoPromocionID FROM SclFormatoPromocion " & _
                     "WHERE (nSrhTecnicoID = " & Me.IdSrhTecnico & ") AND (dFechaActividad = CONVERT(DATETIME, '" & Format(CDate(cdeFecha.Text), "yyyy-MM-dd") & "', 102)) " & _
                     "AND (nActivo = 1) AND (nStbBarrioID = " & Me.cboBarrio.Columns("nStbBarrioID").Value & ") AND  (nSclFormatoPromocionID <> " & Me.IdSclFormato & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existe registro ACTIVO para este Técnico" & Chr(13) & "en esta fecha y Barrio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboBarrio, "Actividades Registradas para el Técnico, Barrio y Fecha.")
                Me.cboBarrio.Focus()
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
    ' Fecha:                14/07/2008
    ' Procedure Name:       SalvarFormato
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Formato en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarFormato()
        Dim XcDelegacion As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjFormatodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjFormatodr.dFechaCreacion = FechaServer()
                '-- Delegación del Formato:
                'No se ubica en el Update ya que podria estar modificando datos
                'un usuario de otra Delegación si tiene Acceso Total para
                'Edición con lo que se alteraría la Delegación original.
                'ObjFormatodr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
                strSQL = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                        "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                        "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
                ObjFormatodr.nStbDelegacionProgramaID = XcDelegacion.ExecuteScalar(strSQL)

                ObjFormatodr.nActivo = 1
            Else
                ObjFormatodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjFormatodr.dFechaModificacion = FechaServer()
            End If

            'Ubicación Geográfica:
            ObjFormatodr.nStbBarrioID = Me.cboBarrio.Columns("nStbBarrioID").Value
            ObjFormatodr.nStbMercadoID = Me.cboMercado.Columns("nStbMercadoID").Value

            'Fecha de Actividad:
            ObjFormatodr.dFechaActividad = Format(Me.cdeFecha.Value, "yyyy-MM-dd")

            'Técnico del Programa:
            ObjFormatodr.nSrhTecnicoID = Me.IdSrhTecnico

            'Conteo de Fichas:
            ObjFormatodr.nFichasRecepcionadas = Me.cneFichasRecepcionadas.Value
            ObjFormatodr.nFichasVerificadas = Me.cneFichasVerificadas.Value
            ObjFormatodr.nPrimerCapacitacion = Me.cneCapacitacionA.Value
            ObjFormatodr.nSegundaCapacitacion = Me.cneCapacitacionB.Value
            ObjFormatodr.nSeguimientoPostCredito = Me.cneSeguimiento.Value

            ObjFormatodr.Update()
            'Asignar el Id a la variable publica del formulario:
            Me.IdSclFormato = ObjFormatodr.nSclFormatoPromocionID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 15, "Modificación de Formato de Promoción y Capacitación ID:" & Me.IdSclFormato & ".")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDelegacion.Close()
            XcDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
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
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarFormato()
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

    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
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
            CargarBarrio(1, 0)
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarBarrio(0, 0)
        Else
            CargarBarrio(1, 0)
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        If Me.cboBarrio.SelectedIndex <> -1 Then
            CargarMercado(0, 0)
        Else
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If intDepartamentoID = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where ((a.nActivo = 1) AND (a.nPertenecePrograma = 1)) or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Departamento:
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMunicipio.ClearFields()

            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nActivo = 1) And (a.nPertenecePrograma = 1) And  (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & "))" & _
                             " Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Municipio") Then
                XdsUbicacion("Municipio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Municipio")
                XdsUbicacion("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsUbicacion("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsUbicacion("Municipio").Count > 0 Then
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Municipio:
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de Distritos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboDistrito.ClearFields()

            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where (a.nPertenecePrograma = 1) And  (a.nActivo = 1) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1)) " & _
                             " OR (a.nStbDistritoID = " & intDistritoID & ") " & _
                             " Order by a.sCodigo"
                End If
            Else 'Limpiar = 0 Qry No regresa ningun Distrito:
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Distrito") Then
                XdsUbicacion("Distrito").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Distrito")
                XdsUbicacion("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsUbicacion("Distrito").Source
            Me.cboDistrito.Rebind()

            'Configurar el combo Distritos:
            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("sNombre").Caption = "Descripción"
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBarrio.ClearFields()

            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & ")) " & _
                             " Or (a.nStbBarrioID = " & intBarrioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsUbicacion.ExistTable("Barrio") Then
                XdsUbicacion("Barrio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Barrio")
                XdsUbicacion("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsUbicacion("Barrio").Source
            Me.cboBarrio.Rebind()

            'Configurar el combo Barrio:
            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("sNombre").Caption = "Descripción"
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/07/2008
    ' Procedure Name:       CargarMercado
    ' Descripción:          Este procedimiento permite cargar el listado de Mercados
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMercado(ByVal intLimpiarID As Integer, ByVal intMercadoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMercado.ClearFields()

            If intLimpiarID = 0 Then
                If intMercadoID = 0 Then 'Mercados del Barrio Indicado:
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("Barrio").ValueField("nStbBarrioID") & _
                             " )) Or (a.nStbMercadoID = 1) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("Barrio").ValueField("nStbBarrioID") & _
                             " ) Or (a.nStbMercadoID = 1)) Or (a.nStbMercadoID = " & intMercadoID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                         " From StbMercado a " & _
                         " Where a.nStbMercadoID = 0"
            End If

            If XdsUbicacion.ExistTable("Mercado") Then
                XdsUbicacion("Mercado").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Mercado")
                XdsUbicacion("Mercado").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMercado.DataSource = XdsUbicacion("Mercado").Source
            Me.cboMercado.Rebind()

            'Configurar el combo Barrio:
            Me.cboMercado.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMercado.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMercado.Columns("sCodigo").Caption = "Código"
            Me.cboMercado.Columns("sNombre").Caption = "Descripción"
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercado.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
            If Me.cboMercado.ListCount > 0 Then
                Me.cboMercado.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboMercado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMercado.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFecha.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneFichasRecepcionadas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneFichasRecepcionadas.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneFichasVerificadas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneFichasVerificadas.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneCapacitacionA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneCapacitacionA.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneCapacitacionB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneCapacitacionB.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneSeguimiento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneSeguimiento.TextChanged
        vbModifico = True
    End Sub
End Class