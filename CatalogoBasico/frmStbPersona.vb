' ------------------------------------------------------------------------
' Autor:                Edgard Delgado
' Fecha:                13 Septiembre 2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbPersona.vb
' Descripción:          Este formulario muestra Catálogo de Personas Naturales, Personas Juridicas y Empleados
'-------------------------------------------------------------------------

Public Class frmStbPersona
    '- Declaración de Variables 
    Dim XdtPersonas As BOSistema.Win.XDataSet.xDataTable
    Dim TPersona As String ' E = Empleado, J = Juridica, N = Natural

    Public Property TipoPersona() As String
        Get
            Return TPersona
        End Get
        Set(ByVal value As String)
            TPersona = value
        End Set
    End Property

    Private Function EncabezadoTipoPersona() As String
        Select Case Me.TipoPersona
            Case "E" : Return "Empleados"
            Case "J" : Return "Personas Juridicas"
            Case "N" : Return "Personas Naturales"
            Case "P" : Return "Proveedores"
            Case Else : Return ""
        End Select
    End Function

    Private Function SeguridadTipoPersona() As String
        Select Case Me.TipoPersona
            Case "E" : Return "Empleado"
            Case "J" : Return "PersonaJuridica"
            Case "N" : Return "PersonaNatural"
            Case "P" : Return "Proveedor"
            Case Else : Return ""
        End Select
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       frmStbPersona_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbPersona_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtPersonas.Close()
            XdtPersonas = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       frmStbPersona_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Sucursales en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbPersona_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            If Me.TipoPersona = "E" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Empleados")
            ElseIf Me.TipoPersona = "J" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Personas Jurídicas")
            ElseIf Me.TipoPersona = "N" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Personas Naturales")
            ElseIf Me.TipoPersona = "P" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Proveedores")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            Me.Text = "Registro de " & Me.EncabezadoTipoPersona()

            InicializaVariables()
            CargarPersona()
            FormatoPersona()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       CargarPersona
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Personas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarPersona()
        Try
            Dim strSQL As String = ""

            Select Case Me.TipoPersona
                Case "E", "N"
                    strSQL = "Select " & _
                        "B.nStbPersonaID, B.nCodigo,C.SCodigo , B.sNombre1, B.sNombre2, B.sApellido1RS, B.sApellido2, " & _
                        "B.sNumCedula, B.sTelefono, B.sCelular, B.sFax, " & _
                        IIf(Me.TipoPersona = "E", "C.sNumInss, ", "") & _
                        "B.nPersonaActiva "

                    strSQL = strSQL & _
                            "From StbValorCatalogo A " & _
                                "Inner Join StbPersona B On A.nStbValorCatalogoID = B.nStbTipoPersonaID " & _
                                "Left Outer Join SrhEmpleado C On B.nStbPersonaID = C.nStbPersonaID " & _
                                "Inner Join StbCatalogo D On A.nStbCatalogoID = D.nStbCatalogoID " & _
                            "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And D.sNombre = 'TipoPersona'"


                Case "J", "P"
                    strSQL = "Select " & _
                        "B.nStbPersonaID, B.nCodigo, B.sNombre1 As sNombreInstitucion, " & _
                        "B.sApellido1RS As sRazonSocial, B.sSiglas," & IIf(Me.TipoPersona = "J", " B.sNumRUC ", "E.sNumRUC") & ",  B.dFechaNacApertura, B.sDireccion, " & _
                        "B.sNumCedula,B.sTelefono, B.sCelular, B.sFax, B.sEMail, B.sSitioWeb, B.sRepresentanteLegal, B.sNombre2 As sContacto, " & _
                        "B.nOtorgaCredito, B.nPersonaActiva , C.nActivo AS nProveedorActivo"

                    strSQL = strSQL & _
                                    " From StbValorCatalogo A " & _
                                        "Inner Join StbPersona B On A.nStbValorCatalogoID = B.nStbTipoPersonaID " & _
                                        "Left Outer Join SrhProveedor C On B.nStbPersonaID = C.nStbPersonaID " & _
                                        "Inner Join StbCatalogo D On A.nStbCatalogoID = D.nStbCatalogoID " & _
                                        " LEFT OUTER JOIN dbo.StbPersonaDatoFiscal E ON B.nStbPersonaID = E.nStbPersonaID " & _
                                    "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And D.sNombre = 'TipoPersona'"

            End Select

            'strSQL = strSQL & _
            '        "From StbValorCatalogo A " & _
            '            "Inner Join StbPersona B On A.nStbValorCatalogoID = B.nStbTipoPersonaID " & _
            '            "Left Outer Join SrhEmpleado C On B.nStbPersonaID = C.nStbPersonaID " & _
            '            "Inner Join StbCatalogo D On A.nStbCatalogoID = D.nStbCatalogoID " & _
            '        "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And D.sNombre = 'TipoPersona'"

            XdtPersonas.ExecuteSql(strSQL)

            'Asignando a las fuentes de datos
            Me.grdPersonas.DataSource = XdtPersonas.Source

            'Actualizando el caption de los GRIDS            
            Me.grdPersonas.Caption = "Listado de " & EncabezadoTipoPersona() & " (" + Me.grdPersonas.RowCount.ToString + " registros) "

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       FormatoSucursal
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Personas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoPersona()
        Try
            'Configuracion del Grid Persona
            Select Case Me.TipoPersona
                Case "E", "N"

                    If Me.TipoPersona = "N" Then
                        Me.grdPersonas.Splits(0).DisplayColumns("sCodigo").Visible = False
                    End If
                    Me.grdPersonas.Splits(0).DisplayColumns("nStbPersonaID").Visible = False

                    Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Width = 40
                    Me.grdPersonas.Splits(0).DisplayColumns("SCodigo").Width = 80
                    Me.grdPersonas.Splits(0).DisplayColumns("sNombre1").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sNombre2").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sApellido1RS").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sApellido2").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sNumCedula").Width = 110
                    Me.grdPersonas.Splits(0).DisplayColumns("sTelefono").Width = 80
                    Me.grdPersonas.Splits(0).DisplayColumns("sCelular").Width = 80
                    Me.grdPersonas.Splits(0).DisplayColumns("sFax").Width = 80
                    If Me.TipoPersona = "E" Then
                        Me.grdPersonas.Splits(0).DisplayColumns("sNumInss").Width = 70
                    End If
                    Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").Width = 50

                    Me.grdPersonas.Columns("nCodigo").Caption = "Código"
                    Me.grdPersonas.Columns("sCodigo").Caption = "Cód Empleado"
                    Me.grdPersonas.Columns("sNombre1").Caption = "Primer Nombre"
                    Me.grdPersonas.Columns("sNombre2").Caption = "Segundo Nombre"
                    Me.grdPersonas.Columns("sApellido1RS").Caption = "Primer Apellido"
                    Me.grdPersonas.Columns("sApellido2").Caption = "Segundo Apellido"
                    Me.grdPersonas.Columns("sNumCedula").Caption = "Cédula"
                    Me.grdPersonas.Columns("sTelefono").Caption = "Teléfono"
                    Me.grdPersonas.Columns("sCelular").Caption = "Celular"
                    Me.grdPersonas.Columns("sFax").Caption = "Fax"
                    If Me.TipoPersona = "E" Then
                        Me.grdPersonas.Columns("sNumInss").Caption = "Número Inss"
                    End If
                    Me.grdPersonas.Columns("nPersonaActiva").Caption = "Activo"
                    Me.grdPersonas.Columns("nPersonaActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

                    Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sNombre1").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sNombre2").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sApellido1RS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sApellido2").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sFax").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    If Me.TipoPersona = "E" Then
                        Me.grdPersonas.Splits(0).DisplayColumns("sNumInss").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End If
                    Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                Case "J", "P"
                    Me.grdPersonas.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
                    Me.grdPersonas.Splits(0).DisplayColumns("sNumCedula").Visible = True
                    'If Me.TipoPersona = "J" Then
                    '    Me.grdPersonas.Splits(0).DisplayColumns("sCodigo").Visible = False
                    'End If

                    Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Width = 40
                    Me.grdPersonas.Splits(0).DisplayColumns("sNombreInstitucion").Width = 200
                    Me.grdPersonas.Splits(0).DisplayColumns("sRazonSocial").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sSiglas").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sNumRUC").Width = 150
                    Me.grdPersonas.Splits(0).DisplayColumns("dFechaNacApertura").Width = 60
                    Me.grdPersonas.Splits(0).DisplayColumns("sDireccion").Width = 150
                    Me.grdPersonas.Splits(0).DisplayColumns("sTelefono").Width = 100
                    Me.grdPersonas.Splits(0).DisplayColumns("sCelular").Width = 50
                    Me.grdPersonas.Splits(0).DisplayColumns("sFax").Width = 50
                    Me.grdPersonas.Splits(0).DisplayColumns("sEmail").Width = 50
                    Me.grdPersonas.Splits(0).DisplayColumns("sSitioWeb").Width = 70
                    Me.grdPersonas.Splits(0).DisplayColumns("sRepresentanteLegal").Width = 120
                    Me.grdPersonas.Splits(0).DisplayColumns("sContacto").Width = 100


                    If Me.TipoPersona = "J" Then
                        Me.grdPersonas.Splits(0).DisplayColumns("nProveedorActivo").Visible = False

                        Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").Width = 50
                        Me.grdPersonas.Columns("nPersonaActiva").Caption = "Activo"
                        Me.grdPersonas.Columns("nPersonaActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                        Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Me.grdPersonas.Splits(0).DisplayColumns("nOtorgaCredito").Width = 90
                        Me.grdPersonas.Columns("nOtorgaCredito").Caption = "Otorga Créditos"
                        Me.grdPersonas.Columns("nOtorgaCredito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                        Me.grdPersonas.Splits(0).DisplayColumns("nOtorgaCredito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Me.grdPersonas.Splits(0).DisplayColumns("nOtorgaCredito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                       
                    Else
                        Me.grdPersonas.Splits(0).DisplayColumns("nPersonaActiva").Visible = False
                        Me.grdPersonas.Splits(0).DisplayColumns("nOtorgaCredito").Visible = False
                        Me.grdPersonas.Splits(0).DisplayColumns("nProveedorActivo").Width = 50
                        Me.grdPersonas.Columns("nProveedorActivo").Caption = "Activo"
                        Me.grdPersonas.Columns("nProveedorActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                        Me.grdPersonas.Splits(0).DisplayColumns("nProveedorActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Me.grdPersonas.Splits(0).DisplayColumns("nProveedorActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    End If



                    Me.grdPersonas.Splits(0).DisplayColumns("sNumCedula").Width = 110


                    Me.grdPersonas.Columns("nCodigo").Caption = "Código"
                    Me.grdPersonas.Columns("sNombreInstitucion").Caption = "Nombre de la Institución"
                    Me.grdPersonas.Columns("sRazonSocial").Caption = "Razón Social"
                    Me.grdPersonas.Columns("sSiglas").Caption = "Siglas"
                    Me.grdPersonas.Columns("sNumRUC").Caption = "Número RUC"
                    Me.grdPersonas.Columns("dFechaNacApertura").Caption = "F.Apertura"
                    Me.grdPersonas.Columns("sDireccion").Caption = "Dirección"
                    Me.grdPersonas.Columns("sTelefono").Caption = "Teléfono"
                    Me.grdPersonas.Columns("sCelular").Caption = "Celular"
                    Me.grdPersonas.Columns("sFax").Caption = "Fax"
                    Me.grdPersonas.Columns("sEMail").Caption = "Email"
                    Me.grdPersonas.Columns("sSitioWeb").Caption = "Sitio Web"
                    Me.grdPersonas.Columns("sRepresentanteLegal").Caption = "Representante Legal"
                    Me.grdPersonas.Columns("sContacto").Caption = "Nombre Contacto"
                    Me.grdPersonas.Columns("sNumCedula").Caption = "Cédula"

                    Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                   
                    Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sNombreInstitucion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sRazonSocial").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sNumRUC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("dFechaNacApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sDireccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sFax").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sEMail").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sSitioWeb").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sRepresentanteLegal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.grdPersonas.Splits(0).DisplayColumns("sContacto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                  

            End Select
            'me.grdPersonas.

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtPersonas = New BOSistema.Win.XDataSet.xDataTable
            ' 06 de agosto del 2014 
            'Agregar para convertir persona juridica en proveedor.
            Me.toolConvertirEmpleado.Visible = IIf(Me.TipoPersona = "N" Or Me.TipoPersona = "J", True, False)

            '
            Me.toolConvertirEmpleado.ToolTipText = IIf(Me.TipoPersona = "N", "Convertir a Empleado", IIf(Me.TipoPersona = "J", "Convertir a Proveedor", False))
            Me.toolConvertirEmpleado.Text = Me.toolConvertirEmpleado.ToolTipText
            'Limpiar los Grids, estructura y Datos
            Me.grdPersonas.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       tbSucursal_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbPersona.
    '-------------------------------------------------------------------------
    Private Sub tbPersona_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbPersona.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarPersona()
            Case "toolModificar"
                LlamaModificarPersona()
            Case "toolEliminar"
                LlamaEliminarPersona()
            Case "toolConvertirEmpleado"
                LlamaConvertirPersonaEmpleado()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolFirma"
                GuardarFirma()
            Case "toolRefrescar"
                InicializaVariables()
                CargarPersona()
                FormatoPersona()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                02 de Marzo 2012
    ' Procedure Name:       GuardarFirma
    ' Descripción:          Este procedimiento permite Guardar y Actualizar
    '                       la firma de un empleado
    '-------------------------------------------------------------------------

    Private Sub GuardarFirma()
        Dim ObjFrmStbFirmaEmpleado As New frmStbFirmaEmpleado
        ObjFrmStbFirmaEmpleado.CodigoEmpleado = XdtPersonas.ValueField("sCodigo")

        ObjFrmStbFirmaEmpleado.ShowDialog()
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmStbParametroPersona As New frmStbParametroPersona
        Try
            Dim strSQL As String = ""

            If Me.grdPersonas.RowCount = 0 Then
                'MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbParametroPersona.LlamadoDesde = Me.TPersona
            ObjFrmStbParametroPersona.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XcDatos.Close()
            '    XcDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaAgregarPersona
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditPersona para Agregar una nueva Persona.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarPersona()
        Dim ObjFrmStbEditPersona As New frmStbEditPersona
        Try
            ObjFrmStbEditPersona.ModoFrm = "ADD"
            ObjFrmStbEditPersona.CambioPersona = False
            ObjFrmStbEditPersona.TipoPersona = Me.TipoPersona
            ObjFrmStbEditPersona.ShowDialog()

            If ObjFrmStbEditPersona.IdPersona <> 0 Then
                CargarPersona()
                XdtPersonas.SetCurrentByID("nStbPersonaID", ObjFrmStbEditPersona.IdPersona)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditPersona.Close()
            ObjFrmStbEditPersona = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaModificarPersona
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditPersona para Modificar una Persona existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarPersona()
        Dim ObjFrmStbEditPersona As New frmStbEditPersona
        Try
            If Me.grdPersonas.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmStbEditPersona.ModoFrm = "UPD"
            ObjFrmStbEditPersona.CambioPersona = False
            ObjFrmStbEditPersona.TipoPersona = Me.TipoPersona
            ObjFrmStbEditPersona.IdPersona = XdtPersonas.ValueField("nStbPersonaID")
            ObjFrmStbEditPersona.ShowDialog()

            CargarPersona()
            XdtPersonas.SetCurrentByID("nStbPersonaID", ObjFrmStbEditPersona.IdPersona)
            Me.grdPersonas.Row = XdtPersonas.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditPersona.Close()
            ObjFrmStbEditPersona = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaEliminarPersona
    ' Descripción:          Este procedimiento permite eliminar el registro
    '                       de una Persona existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarPersona()
        Dim XdtPersonaEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdPersonas.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de Eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                Select Case Me.TipoPersona
                    Case "E"
                        XdtPersonaEliminar.ExecuteSqlNotTable("Delete From SrhEmpleado Where nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID"))
                        XdtPersonaEliminar.ExecuteSqlNotTable("Delete From StbPersona Where nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID"))
                    Case "N", "J"
                        XdtPersonaEliminar.ExecuteSqlNotTable("Delete From StbPersona Where nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID"))
                    Case "P"
                        XdtPersonaEliminar.ExecuteSqlNotTable("Delete From SrhProveedor Where nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID"))
                        XdtPersonaEliminar.ExecuteSqlNotTable("Delete From StbPersona Where nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID"))
                End Select
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)

                CargarPersona()
                Me.grdPersonas.Caption = "Listado de " & EncabezadoTipoPersona() & " (" + Me.grdPersonas.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtPersonaEliminar.Close()
            XdtPersonaEliminar = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaConvertirPersonaEmpleado
    ' Descripción:          Este procedimiento permite convertir una persona natural a empleado.
    '-------------------------------------------------------------------------
    Private Sub LlamaConvertirPersonaEmpleado()
        Dim strSQL As String
        Dim XdtPersona As New BOSistema.Win.XDataSet.xDataTable
        Dim XdtPersonaCambio As New BOSistema.Win.XDataSet
        Try
            If Me.grdPersonas.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If Me.grdPersonas.Columns("nPersonaActiva").Value <> 1 Then
                MsgBox("Por encontrarse desactivado, no se pueden modificar " & Me.EncabezadoTipoPersona() & ".", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Me.TipoPersona = "N" Or Me.TipoPersona = "J"

            If Me.TipoPersona = "N" Then


                strSQL = "SELECT     nSrhEmpleadoID, nStbPersonaID  FROM         dbo.SrhEmpleado WHERE     (nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID") & ")"

                XdtPersona.ExecuteSql(strSQL)

                If XdtPersona.Count > 0 Then
                    MsgBox("Esta persona natural ya es empleado, modifique desde la opcion de catalogo empleados", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema)
                    Exit Sub
                End If

                If MsgBox("¿Está seguro de convertir a la Persona Natural a Empleado en el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                    Dim ObjFrmStbEditPersona As New frmStbEditPersona
                    Try
                        ObjFrmStbEditPersona.ModoFrm = "UPD"
                        ObjFrmStbEditPersona.TipoPersona = "E"
                        ObjFrmStbEditPersona.CambioPersona = True
                        ObjFrmStbEditPersona.IdPersona = XdtPersonas.ValueField("nStbPersonaID")
                        ObjFrmStbEditPersona.ShowDialog()

                        If ObjFrmStbEditPersona.AccionUsuario = frmStbEditPersona.AccionBoton.BotonCancelar Then
                            XdtPersonas.SetCurrentByID("nStbPersonaID", ObjFrmStbEditPersona.IdPersona)
                            Me.grdPersonas.Row = XdtPersonas.BindingSource.Position
                        End If

                    Catch ex As Exception
                        Control_Error(ex)
                    Finally
                        ObjFrmStbEditPersona.Close()
                        ObjFrmStbEditPersona = Nothing
                    End Try

                    CargarPersona()
                    Me.grdPersonas.Caption = "Listado de " & EncabezadoTipoPersona() & " (" + Me.grdPersonas.RowCount.ToString + " registros) "
                End If

            Else

                If Me.TipoPersona = "J" Then


                    strSQL = "SELECT     nSrhProveedorID, nStbPersonaID FROM         dbo.SrhProveedor WHERE     (nStbPersonaID = " & XdtPersonas.ValueField("nStbPersonaID") & ")"
                             
                    XdtPersona.ExecuteSql(strSQL)

                    If XdtPersona.Count > 0 Then
                        MsgBox("Esta persona juridica ya es proveedor, modifique desde la opcion de catalogo proveedores", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema)
                        Exit Sub
                    End If


                    If MsgBox("¿Está seguro de convertir a la Persona Juridica a Proveedor en el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                        Dim ObjFrmStbEditPersona As New frmStbEditPersona
                        Try
                            ObjFrmStbEditPersona.ModoFrm = "UPD"
                            ObjFrmStbEditPersona.TipoPersona = "P"
                            ObjFrmStbEditPersona.CambioPersona = True
                            ObjFrmStbEditPersona.IdPersona = XdtPersonas.ValueField("nStbPersonaID")
                            ObjFrmStbEditPersona.ShowDialog()

                            If ObjFrmStbEditPersona.AccionUsuario = frmStbEditPersona.AccionBoton.BotonCancelar Then
                                XdtPersonas.SetCurrentByID("nStbPersonaID", ObjFrmStbEditPersona.IdPersona)
                                Me.grdPersonas.Row = XdtPersonas.BindingSource.Position
                            End If

                        Catch ex As Exception
                            Control_Error(ex)
                        Finally
                            ObjFrmStbEditPersona.Close()
                            ObjFrmStbEditPersona = Nothing
                        End Try

                        CargarPersona()
                        Me.grdPersonas.Caption = "Listado de " & EncabezadoTipoPersona() & " (" + Me.grdPersonas.RowCount.ToString + " registros) "
                    End If

                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Personas.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       grdSucursal_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Persona existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdPersonas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPersonas.DoubleClick
        Try
            If Seg.HasPermission("Editar" & Me.SeguridadTipoPersona()) Then
                LlamaModificarPersona()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdPersonas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdPersonas.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       grdSucursal_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdPersonas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdPersonas.Filter
        Try
            XdtPersonas.FilterLocal(e.Condition)
            Me.grdPersonas.Caption = "Listado de " & EncabezadoTipoPersona() & " (" + Me.grdPersonas.RowCount.ToString + " registros) "
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                13 Septiembre 2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            Me.toolAgregar.Enabled = IIf(Seg.HasPermission("Agregar" & Me.SeguridadTipoPersona()) = True, True, False)
            Me.toolModificar.Enabled = IIf(Seg.HasPermission("Editar" & Me.SeguridadTipoPersona()) = True, True, False)
            Me.toolEliminar.Enabled = IIf(Seg.HasPermission("Inactivar" & Me.SeguridadTipoPersona()) = True, True, False)
            Me.toolImprimir.Enabled = IIf(Seg.HasPermission("Imprimir" & Me.SeguridadTipoPersona()) = True, True, False)

            Me.toolFirma.Enabled = IIf(Seg.HasPermission("VisualizarFirma") = True, True, False)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class