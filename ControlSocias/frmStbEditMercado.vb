' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbEditMercado.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de un Mercado.
'-------------------------------------------------------------------------

Public Class frmStbEditMercado

    Public Enum eTipoObjeto
        Mercado = 0
        Cooperativa = 1
    End Enum

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intMercadoID As Integer
    Dim blnModificar As Boolean = True
    Dim nTipo As eTipoObjeto

    '-- Clases para procesar la informacion de los combos
    Dim XdsMercado As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjMercadodt As BOSistema.Win.StbEntUbicacionGeografica.StbMercadoDataTable
    Dim ObjMercadodr As BOSistema.Win.StbEntUbicacionGeografica.StbMercadoRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'usarlo como Mercado o Cooperativa.
    Public Property TipoObjeto() As eTipoObjeto
        Get
            Return nTipo
        End Get
        Set(ByVal value As eTipoObjeto)
            nTipo = value
        End Set
    End Property

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

    'Propiedad utilizada para obtener el ID del Mercado que corresponde al campo
    'StbMercadoID de la tabla StbMercado
    Public Property intStbMercadoID() As Integer
        Get
            intStbMercadoID = intMercadoID
        End Get
        Set(ByVal value As Integer)
            intMercadoID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbEditMercado_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditMercado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                XdsMercado.Close()
                XdsMercado = Nothing

                ObjMercadodt.Close()
                ObjMercadodt = Nothing

                ObjMercadodr.Close()
                ObjMercadodr = Nothing
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
    ' Procedure Name:       frmStbEditMercado_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la Ficha en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditMercado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            Dim frmStrName As String = IIf(TipoObjeto = eTipoObjeto.Mercado, "Mercado", "Cooperativa")
            Me.lblDescripcion.Text = "Nombre " & IIf(TipoObjeto = eTipoObjeto.Mercado, "Mercado", "Cooperativa")
            Me.grpDatosBarrio.Text = "Datos " & IIf(TipoObjeto = eTipoObjeto.Mercado, "Mercado", "Cooperativa")

            InicializarVariables(frmStrName)

            CargarDepartamento()

            Me.txtCodigo.MaxLength = IIf(TipoObjeto = eTipoObjeto.Mercado, 3, 6)

            'Si el formulario está en modo edición
            'cargar los datos del barrio.
            If ModoFrm = "UPD" Then
                CargarMercado()
                'ObtenerSiModifica()
                'PresentacionControles()

            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If Me.chkActivo.Checked = False Then
                Me.chkActivo.Select()
            Else
                Me.txtCodigo.Select()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables(ByVal sName As String)
        Try
            If ModoFrm = "ADD" Then
                Me.Text = String.Format("Agregar {0}", sName)
                Me.chkIncluidoPrograma.Checked = True
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
            Else
                Me.Text = String.Format("Modificar {0}", sName)
                Me.chkActivo.Enabled = True
            End If

            ObjMercadodt = New BOSistema.Win.StbEntUbicacionGeografica.StbMercadoDataTable
            ObjMercadodr = New BOSistema.Win.StbEntUbicacionGeografica.StbMercadoRow
            XdsMercado = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()

            If ModoFrm = "ADD" Then

                ObjMercadodr = ObjMercadodt.NewRow

                'Inicializar los Length de los campos
                Me.txtDescripcion.MaxLength = ObjMercadodr.GetColumnLenght("sNombre")
                Me.txtCodigo.MaxLength = ObjMercadodr.GetColumnLenght("sCodigo")

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarMercado
    ' Descripción:          Este procedimiento permite cargar los datos de la Ficha
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarMercado()
        Dim ObjUbicacionDT As New BOSistema.Win.XDataSet.xDataTable
        Dim ObjCooperativa As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Barrio correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.

            If TipoObjeto = eTipoObjeto.Cooperativa Then
                ObjCooperativa.ExecuteSql(String.Format("Select * From StbMercado Where nStbMercadoID = {0}", Me.intMercadoID))
                If ObjCooperativa.Count = 0 Then
                    Exit Sub
                End If
            Else
                ObjMercadodt.Filter = "nStbMercadoID = " & Me.intMercadoID
                ObjMercadodt.Retrieve()
                If ObjMercadodt.Count = 0 Then
                    Exit Sub
                End If
                ObjMercadodr = ObjMercadodt.Current

            End If

            'Código 
            If TipoObjeto = eTipoObjeto.Cooperativa Then

                If Not IsDBNull(ObjCooperativa.ValueField("sCodigo")) Then
                    Me.txtCodigo.Text = ObjCooperativa.ValueField("sCodigo")
                Else
                    Me.txtCodigo.Text = ""
                End If

            Else

                If Not ObjMercadodr.IsFieldNull("sCodigo") Then
                    Me.txtCodigo.Text = ObjMercadodr.sCodigo
                Else
                    Me.txtCodigo.Text = ""
                End If

            End If

            'Ubicación
            strSQL = " Select a.nStbMunicipioID,a.nStbDepartamentoID," & _
                     " a.nStbDistritoID,a.nStbBarrioID" & _
                     " From vwStbUbicacionMercado a " & _
                     " Where a.nStbMercadoID = " & Me.intMercadoID


            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then

                XdsMercado("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))

                If Not ObjUbicacionDT.ValueField("nStbMunicipioID") Is DBNull.Value Then
                    CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    If Me.cboMunicipio.ListCount > 0 Then
                        Me.cboMunicipio.SelectedIndex = 0
                        XdsMercado("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    End If

                    If Not ObjUbicacionDT.ValueField("nStbDistritoID") Is DBNull.Value Then
                        CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                        If Me.cboDistrito.ListCount > 0 Then
                            Me.cboDistrito.SelectedIndex = 0
                            XdsMercado("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                        End If

                        If Not ObjUbicacionDT.ValueField("nStbBarrioID") Is DBNull.Value Then
                            CargarBarrio(0, ObjUbicacionDT.ValueField("nStbBarrioID"))
                            If Me.cboBarrio.ListCount > 0 Then
                                Me.cboBarrio.SelectedIndex = 0
                                XdsMercado("Barrio").SetCurrentByID("nStbBarrioID", ObjUbicacionDT.ValueField("nStbBarrioID"))
                            End If
                        End If

                    End If
                End If
            End If

            'Descripción
            If Me.TipoObjeto = eTipoObjeto.Mercado Then
                If Not ObjMercadodr.IsFieldNull("sNombre") Then
                    Me.txtDescripcion.Text = ObjMercadodr.sNombre
                Else
                    Me.txtDescripcion.Text = ""
                End If

                'Incluido Programa
                If Not ObjMercadodr.IsFieldNull("nPertenecePrograma") Then
                    Me.chkIncluidoPrograma.Checked = ObjMercadodr.nPertenecePrograma
                End If

                'Activo
                If Not ObjMercadodr.IsFieldNull("nActivo") Then
                    Me.chkActivo.Checked = ObjMercadodr.nActivo
                    If Me.chkActivo.Checked = False Then
                        Me.txtCodigo.Enabled = False
                        Me.txtDescripcion.Enabled = False
                        Me.cboDepartamento.Enabled = False
                        Me.cboMunicipio.Enabled = False
                        Me.cboDistrito.Enabled = False
                        Me.cboBarrio.Enabled = False
                        Me.chkIncluidoPrograma.Enabled = False
                    End If
                End If

                Me.txtDescripcion.MaxLength = ObjMercadodr.GetColumnLenght("sNombre")
                Me.txtCodigo.MaxLength = 3
            Else
                If Not IsDBNull(ObjCooperativa.ValueField("sNombre")) Then
                    Me.txtDescripcion.Text = ObjCooperativa.ValueField("sNombre")
                Else
                    Me.txtDescripcion.Text = ""
                End If
                'Incluido Programa
                If Not IsDBNull(ObjCooperativa.ValueField("nPertenecePrograma")) Then
                    Me.chkIncluidoPrograma.Checked = Convert.ToBoolean(ObjCooperativa.ValueField("nPertenecePrograma"))
                End If
                'Activo
                If Not IsDBNull(ObjCooperativa.ValueField("nActivo")) Then
                    Me.chkActivo.Checked = Convert.ToBoolean(ObjCooperativa.ValueField("nActivo"))
                    If Me.chkActivo.Checked = False Then
                        Me.txtCodigo.Enabled = False
                        Me.txtDescripcion.Enabled = False
                        Me.cboDepartamento.Enabled = False
                        Me.cboMunicipio.Enabled = False
                        Me.cboDistrito.Enabled = False
                        Me.cboBarrio.Enabled = False
                        Me.chkIncluidoPrograma.Enabled = False
                    End If
                End If

                Me.txtDescripcion.MaxLength = 60
                Me.txtCodigo.MaxLength = 6
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjUbicacionDT.Close()
            ObjUbicacionDT = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then
                SalvarMercado()

                AccionUsuario = AccionBoton.BotonAceptar
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
        Dim objMercadoTmpDT As New BOSistema.Win.StbEntUbicacionGeografica.StbMercadoDataTable
        Dim objCooperativaTmpDT As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim sCodigoMercado As String

            Dim sComportamiento As String = IIf(Me.TipoObjeto = eTipoObjeto.Mercado, " del Mercado", " de la Cooperativa")

            ValidaDatosEntrada = True
            Me.errBarrio.Clear()

            'Código
            'If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
            '    MsgBox("El Código NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errBarrio.SetError(Me.txtCodigo, "El Código NO DEBE quedar vacío.")
            '    Me.txtCodigo.Focus()
            '    Exit Function
            'End If

            ''Determinar duplicados en el Código del Mercado

            'sCodigoMercado = Format(CInt(Me.txtCodigo.Text), IIf(TipoObjeto = eTipoObjeto.Mercado, "000", "000000"))

            Dim strQuery As String = ""
            'If ModoFrm = "UPD" Then
            '    strQuery = " sCodigo = '" & sCodigoMercado & "'" & " And nStbMercadoID <> " & Me.intMercadoID 'ObjMercadodr.nStbMercadoID
            'Else
            '    strQuery = " sCodigo = '" & sCodigoMercado & "'"
            'End If

            Dim cantidadRegistros As Integer = 0
            'If Me.TipoObjeto = eTipoObjeto.Mercado Then
            '    objMercadoTmpDT.Filter = strQuery
            '    objMercadoTmpDT.Retrieve()
            '    cantidadRegistros = objMercadoTmpDT.Count
            'Else
            '    objCooperativaTmpDT.ExecuteSql(" Select * from StbMercado where " & strQuery)
            '    cantidadRegistros = objCooperativaTmpDT.Count
            'End If

            'If cantidadRegistros > 0 Then
            '    MsgBox(String.Format("El Código {0} NO DEBE repetirse. ", sComportamiento), MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errBarrio.SetError(Me.txtCodigo, String.Format("El Código {0} NO DEBE repetirse. ", sComportamiento))
            '    Me.txtCodigo.Focus()
            '    Exit Function
            'End If

            'Departamento
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Barrio
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Barrio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboBarrio, "Debe seleccionar un Barrio válido.")
                Me.cboBarrio.Focus()
                Exit Function
            End If

            'Descripción
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox(String.Format("El Nombre {0} NO DEBE quedar vacío.", sComportamiento), MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.txtDescripcion, String.Format("El Nombre {0} NO DEBE quedar vacío.", sComportamiento))
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'Determinar duplicados en el Nombre del Mercado

            If ModoFrm = "UPD" Then
                strQuery = " nStbBarrioID = " & XdsMercado("Barrio").ValueField("nStbBarrioID") & " AND Upper(sNombre) = '" & UCase(Me.txtDescripcion.Text) & "'" & " And nStbMercadoID <> " & Me.intMercadoID
            Else
                strQuery = " nStbBarrioID = " & XdsMercado("Barrio").ValueField("nStbBarrioID") & " AND Upper(sNombre) = '" & UCase(Me.txtDescripcion.Text) & "'"
            End If

            If Me.TipoObjeto = eTipoObjeto.Mercado Then
                objMercadoTmpDT.Filter = strQuery
                objMercadoTmpDT.Retrieve()
                cantidadRegistros = objMercadoTmpDT.Count
            Else
                objCooperativaTmpDT.ExecuteSql(" Select * from StbMercado where " & strQuery)
                cantidadRegistros = objCooperativaTmpDT.Count
            End If

            If cantidadRegistros > 0 Then
                MsgBox(String.Format("El Nombre {0} NO DEBE repetirse.", sComportamiento), MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.txtDescripcion, String.Format("El Nombre {0} NO DEBE repetirse.", sComportamiento))
                Me.txtDescripcion.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            objMercadoTmpDT.Close()
            objMercadoTmpDT = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarMercado
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Mercado en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarMercado()
        Try
            If TipoObjeto = eTipoObjeto.Mercado Then
                If ModoFrm = "ADD" Then
                    ObjMercadodr.sUsuarioCreacion = InfoSistema.LoginName
                    ObjMercadodr.dFechaCreacion = FechaServer()
                Else
                    ObjMercadodr.sUsuarioModificacion = InfoSistema.LoginName
                    ObjMercadodr.dFechaModificacion = FechaServer()
                End If

                ObjMercadodr.sCodigo = Me.GeneraCodigo(3, 0) ''Format(CInt(Me.txtCodigo.Text), "000")
                ObjMercadodr.sNombre = Me.txtDescripcion.Text
                ObjMercadodr.nStbBarrioID = XdsMercado("Barrio").ValueField("nStbBarrioID")

                If Me.chkActivo.Checked = True Then
                    ObjMercadodr.nActivo = 1
                Else
                    ObjMercadodr.nActivo = 0
                End If

                If Me.chkIncluidoPrograma.Checked = True Then
                    ObjMercadodr.nPertenecePrograma = 1
                Else
                    ObjMercadodr.nPertenecePrograma = 0
                End If

                ObjMercadodr.Update()

                'Asignar el Id del Mercado a la 
                'variable publica del formulario
                Me.intMercadoID = ObjMercadodr.nStbMercadoID
            Else
                Dim SQlQuery As String
                Dim XdsComando As New BOSistema.Win.XComando

                If ModoFrm = "ADD" Then
                    SQlQuery = " Insert Into StbMercado (nStbBarrioID,sCodigo,sNombre,nActivo,nPertenecePrograma, sUsuarioCreacion, dFechaCreacion, sUsuarioModificacion, dFechaModificacion, nCooperativa) Values("
                Else
                    SQlQuery = " Update StbMercado Set "
                End If

                SQlQuery += IIf(ModoFrm = "ADD", "", " nStbBarrioID = ") & "" & XdsMercado("Barrio").ValueField("nStbBarrioID").ToString + ", "
                SQlQuery += IIf(ModoFrm = "ADD", "'", " sCodigo = '") & "" & IIf(ModoForm = "ADD", Me.GeneraCodigo(6, 1), Me.txtCodigo.Text) + "', "
                SQlQuery += IIf(ModoFrm = "ADD", "'", " sNombre = '") & "" & Me.txtDescripcion.Text + "', "
                SQlQuery += IIf(ModoFrm = "ADD", "", " nActivo = ") & "" & IIf(Me.chkActivo.Checked, 1, 0).ToString() + ", "
                SQlQuery += IIf(ModoFrm = "ADD", "", " nPertenecePrograma = ") & "" & IIf(Me.chkIncluidoPrograma.Checked, 1, 0).ToString() + ", "

                If ModoFrm = "ADD" Then
                    SQlQuery += "'" & InfoSistema.LoginName + "', "
                    SQlQuery += "'" & Format(FechaServer(), "yyyy-MM-dd") + "', "
                End If

                SQlQuery += IIf(ModoFrm = "ADD", "'", " sUsuarioModificacion = '") & "" & InfoSistema.LoginName + "', "
                SQlQuery += IIf(ModoFrm = "ADD", "'", " dFechaModificacion = '") & "" & Format(FechaServer(), "yyyy-MM-dd") + "', "
                SQlQuery += IIf(ModoFrm = "ADD", "", " nCooperativa = ") & "1"

                If ModoFrm = "ADD" Then
                    SQlQuery += " ); Select @@IDENTITY AS nStbMercadoID "
                Else
                    SQlQuery += String.Format(" Where nStbMercadoID = {0}", Me.intMercadoID)
                End If
                Try
                    If ModoForm = "ADD" Then
                        Me.intMercadoID = Convert.ToInt32(XdsComando.ExecuteScalar(SQlQuery))
                    Else
                        Convert.ToInt32(XdsComando.ExecuteScalar(SQlQuery))
                    End If
                Catch ex As Exception
                    Control_Error(ex)
                Finally
                    XdsComando.Close()
                    XdsComando = Nothing
                End Try

            End If
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

    Public Function GeneraCodigo(ByVal MaxLength As Integer, ByVal Cooperativa As Int16) As String
        Dim XdDatos As BOSistema.Win.XComando
        Dim strQuery As String
        Dim sCodigo As String = String.Empty
        strQuery = " DECLARE @sCodigo VARCHAR(6);" & _
                   " SELECT @sCodigo = isNull(Max(sm.sCodigo),0) + 1  " & _
                   " FROM StbMercado sm " & _
                   String.Format(" WHERE sm.nCooperativa = {0};", Cooperativa) & _
                   String.Format(" SET @sCodigo = REPLICATE('0',({0}-(LEN(@sCodigo)))) + @sCodigo", MaxLength) & _
                   " SELECT @sCodigo"
        Try
            XdDatos = New BOSistema.Win.XComando
            sCodigo = XdDatos.ExecuteScalar(strQuery)
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdDatos.Close()
            XdDatos = Nothing
        End Try
        Return sCodigo
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
                            SalvarMercado()
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

    'Se indica que hubo modificación en la Dirección de la Socia
    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
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
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
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

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarBarrio(0, 0)
        Else
            CargarBarrio(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        vbModifico = True
    End Sub
    Private Sub chkActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.GotFocus
        Try
            Me.chkActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub chkActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.LostFocus
        Try
            Me.chkActivo.BackColor = Me.grpDatosBarrio.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub chkIncluidoPrograma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub chkIncluidoPrograma_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.GotFocus
        Try
            Me.chkIncluidoPrograma.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkIncluidoPrograma_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.LostFocus
        Try
            Me.chkIncluidoPrograma.BackColor = Me.grpDatosBarrio.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#Region "Combos"
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

            If XdsMercado.ExistTable("Departamento") Then
                XdsMercado("Departamento").ExecuteSql(Strsql)
            Else
                XdsMercado.NewTable(Strsql, "Departamento")
                XdsMercado("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsMercado("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsMercado("Departamento").Count > 0 Then
                XdsMercado("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

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
                             " Where a.nStbDepartamentoID = " & XdsMercado("Departamento").ValueField("nStbDepartamentoID") & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsMercado("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " Or a.nStbMunicipioID = " & intMunicipioID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsMercado.ExistTable("Municipio") Then
                XdsMercado("Municipio").ExecuteSql(Strsql)
            Else
                XdsMercado.NewTable(Strsql, "Municipio")
                XdsMercado("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsMercado("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsMercado("Municipio").Count > 0 Then
                XdsMercado("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
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
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
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

            If XdsMercado.ExistTable("Distrito") Then
                XdsMercado("Distrito").ExecuteSql(Strsql)
            Else
                XdsMercado.NewTable(Strsql, "Distrito")
                XdsMercado("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsMercado("Distrito").Source
            Me.cboDistrito.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            Me.cboBarrio.ClearFields()
            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbBarrio a " & _
                             " Where a.nStbMunicipioID = " & XdsMercado("Municipio").ValueField("nStbMunicipioID") & _
                             " And a.nStbDistritoID = " & XdsMercado("Distrito").ValueField("nStbDistritoID") & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbBarrio a " & _
                             " Where (a.nStbMunicipioID = " & XdsMercado("Municipio").ValueField("nStbMunicipioID") & _
                             " And a.nStbDistritoID = " & XdsMercado("Distrito").ValueField("nStbDistritoID") & ")" & _
                             " Or a.nStbBarrioID = " & intBarrioID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsMercado.ExistTable("Barrio") Then
                XdsMercado("Barrio").ExecuteSql(Strsql)
            Else
                XdsMercado.NewTable(Strsql, "Barrio")
                XdsMercado("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsMercado("Barrio").Source
            Me.cboBarrio.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region

End Class