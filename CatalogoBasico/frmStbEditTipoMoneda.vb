'Imports SE = System.Environment
'Imports sql = System.Data.SqlClient
Public Class frmStbEditTipoMoneda

    'Variables Globales del Formulario  --------------------
    Dim ModoForm As String
    Dim ObjMonedaDt As New BOSistema.Win.StbEntCatalogo.StbMonedaDataTable
    Dim ObjMonedaDr As New BOSistema.Win.StbEntCatalogo.StbMonedaRow
    Dim IdMonedal As Long
    Dim Activo1 As Boolean
    Dim IdNacional2 As Boolean
    Dim vbUsuarioModifica As Boolean = False
    Dim ErrorProvider1 As New System.Windows.Forms.ErrorProvider
    Dim Yavalido As Boolean = False
    ' --------------------------------------------------------------------------------------
    'Acciones del Usuario en el Formulario
    '-----------------------------------------------------
    Public Enum AcciondelBoton
        Aceptar = 1
        Cancelar = 2
        Ninguno = 3
    End Enum
    Public AccionUsuario As AcciondelBoton
    '-- Id de la Moneda
    Property IdMoneda() As Long
        Get
            IdMoneda = IdMonedal
        End Get
        Set(ByVal value As Long)
            IdMonedal = value
        End Set
    End Property
    Private Sub frmSteMonedaEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AcciondelBoton.Ninguno Then
                ObjMonedaDt = Nothing
                ObjMonedaDr = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AcciondelBoton.Cancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda_Add.vb
    '-- Descripción      :    Esta propiedad permitirá saber si el formulario está en modo Edición o Agregado.
    '----------------------------------------------------------------------------------------------------------
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    Private Sub FrmSteMonedaEdit_Add_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            IniciarVariables()
            If ModoForm = "ADD" Then

                Me.CkboxActivo.Checked = True
                Me.CkboxActivo.Enabled = False
                Me.RbNacionalNo.Checked = True
                Me.TxtCodigo.Focus()
                Me.TxtCodigo.Select()
            Else
                CargarDatosMoneda()
                Me.TxtCodigo.Select()
                Me.TxtCodigo.SelectionLength = ObjMonedaDt.GetColumnLenght("sCodigoInterno")
            End If
            vbUsuarioModifica = False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-----------------------------------------------------------------------
    '-- Autor                  :    
    '-- Fecha de Implementacion:    Managua, 24 de Julio del 2006
    '-- Solution Name          :    SlnTablasBasicas
    '-- Project Name           :    PrjTablasBásicas
    '-- Project Item Name      :    FrmSteMonda
    '-- Descripcion            :    Cargar los datos del registro seleccionado en el formulario.
    '------------------------------------------------------------------------
    Private Sub CargarDatosMoneda()

        Dim vbDatosRelacionados As Boolean
        Try

            'Buscar la Moneda
            ObjMonedaDt.Filter = "nStbMonedaID = " & IdMoneda
            ObjMonedaDt.Retrieve()
            If ObjMonedaDt.Count > 0 Then
                ObjMonedaDr = ObjMonedaDt.Current

                'Cargar los datos de la Moneda

                Me.TxtCodigo.Text = ObjMonedaDr.sCodigoInterno
                Me.TxtDescripcionMoneda.Text = ObjMonedaDr.sDescripcion
                Me.TxtSimbolo.Text = ObjMonedaDr.sSimbolo
                Me.Activo1 = ObjMonedaDr.nActivo

                If ObjMonedaDr.nNacional = 1 Then
                    Me.RbNacionalSi.Checked = True
                    IdNacional2 = True
                Else
                    Me.RbNacionalNo.Checked = True
                    IdNacional2 = False
                End If

                If ObjMonedaDr.nActivo = 1 And ObjMonedaDr.nNacional = 0 Then
                    vbDatosRelacionados = Existedatosrelacionados()
                    If vbDatosRelacionados Then
                        CkboxActivo.Checked = True
                        Me.TxtCodigo.Enabled = False
                        Me.TxtCodigo.Enabled = False
                        Me.TxtDescripcionMoneda.Enabled = False
                        Me.TxtSimbolo.Enabled = False
                        Me.RbNacionalSi.Enabled = False
                        Me.RbNacionalNo.Enabled = False
                        Me.CkboxActivo.BackColor = Color.White


                    Else
                        CkboxActivo.Checked = True
                        Me.TxtCodigo.Enabled = True
                        Me.TxtCodigo.Enabled = True
                        Me.TxtDescripcionMoneda.Enabled = True
                        Me.TxtSimbolo.Enabled = True
                        Me.RbNacionalSi.Enabled = True
                        Me.RbNacionalNo.Enabled = True
                        Me.CkboxActivo.Enabled = True

                    End If

                Else
                    If ObjMonedaDr.nActivo = 1 Then
                        CkboxActivo.Checked = True
                    Else
                        CkboxActivo.Checked = False
                    End If

                    Me.TxtCodigo.Enabled = False
                    Me.TxtCodigo.Enabled = False
                    Me.TxtDescripcionMoneda.Enabled = False
                    Me.TxtSimbolo.Enabled = False
                    Me.RbNacionalSi.Enabled = False
                    Me.RbNacionalNo.Enabled = False
                    Me.CkboxActivo.Enabled = False
                    Me.CkboxActivo.BackColor = Color.White
                End If

                CkboxActivo.Enabled = True
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ---------------------------------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                01/03/2007
    ' Procedure Name:       Existedatosrelacionados
    ' Descripción:          Este procedimiento verifica que la moneda se encuentre
    '                       relacionada con las siguientes tablas:
    '                       StePago,SteDDepositoCheque,SteParidadCambiaria,SteCtaBancaria,
    '                       ScnFondoDesembolso,ScnCtaBancaria,ScnCuentaxPagar, SteDenominaciónMoneda,
    '                       SteMovimientoBancario,SteLibroBanco,ScnComprobanteContable,ScnFondoControl
    '----------------------------------------------------------------------------------------------------
    Public Function Existedatosrelacionados() As Boolean
        Dim VbDatosRelacionados As Boolean
        Dim ObjSteParidadCambiariadt As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable

        VbDatosRelacionados = False

        Try

            ObjSteParidadCambiariadt.Filter = "nStbMonedaBaseID= " & IdMoneda & " " & " Or nStbMonedaCambioID = " & IdMoneda & ""
            ObjSteParidadCambiariadt.Retrieve()
            If ObjSteParidadCambiariadt.Count > 0 Then
                VbDatosRelacionados = True
                Exit Try
            End If

        Catch ex As Exception

        End Try
        Return VbDatosRelacionados
    End Function
    Public Sub IniciarVariables()
        Try
            '-- Instanciar la clase
            ObjMonedaDr = New BOSistema.Win.StbEntCatalogo.StbMonedaRow
            ObjMonedaDt = New BOSistema.Win.StbEntCatalogo.StbMonedaDataTable


            '-- Limpiar los campos

            Me.TxtDescripcionMoneda.Text = ""
            Me.TxtSimbolo.Text = ""

            Me.IdNacional2 = False


            If ModoForm = "ADD" Then
                vbUsuarioModifica = True
                ObjMonedaDr = ObjMonedaDt.NewRow
                Me.RbNacionalSi.Checked = True

                Me.TxtCodigo.Enabled = True
                Me.TxtCodigo.MaxLength = ObjMonedaDt.GetColumnLenght("sCodigoInterno")
                Me.TxtDescripcionMoneda.MaxLength = ObjMonedaDt.GetColumnLenght("sDescripcion")
            Else
                ObjMonedaDr = ObjMonedaDt.NewRow
                Me.TxtCodigo.MaxLength = ObjMonedaDt.GetColumnLenght("sCodigoInterno")
                Me.TxtDescripcionMoneda.MaxLength = ObjMonedaDt.GetColumnLenght("sDescripcion")
                vbUsuarioModifica = False
            End If

            '------------------------------------ 
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try

            If FncValidaParametros() Then
                SalvarMoneda()
                AccionUsuario = AcciondelBoton.Cancelar
                Me.Close()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda_Add.vb
    '-- Descripcion      :    Se validan los parametros de entrada tal como:
    '--                          1. El codigo interno es un valor requerido
    '--                          2. La Fecha de la Tasa de Cambioes un valor requerido.
    '--                          3. La Tasa de Cambio debe ser distinto de cero.
    '------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Dim ObjMoneda As New BOSistema.Win.StbEntCatalogo.StbMonedaDataTable

        Dim VbResultado As Boolean
        Try
            '-- Declaracion de Variables 

            ErrorProvider1.Clear()

            VbResultado = False
            ObjMoneda = New BOSistema.Win.StbEntCatalogo.StbMonedaDataTable



            '-- 1. Verificando que exista un valor válido para el Codigo Interno

            If Me.TxtCodigo.Text.Length = 0 Then
                MsgBox("El Código de moneda no debe quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                FncValidaParametros = False
                Me.ErrorProvider1.SetError(Me.TxtCodigo, "El Código de moneda no debe quedar vacío.")

                Me.TxtCodigo.Focus()
                Exit Function
            End If

            If Me.TxtCodigo.Text.Length > 0 Then
                'Determinar duplicados en el Código Interno
                'Me.TxtCodigoInterno.Text
                If ModoFrm = "UPD" Then
                    ObjMoneda.Filter = "sCodigoInterno = '" & Me.TxtCodigo.Text & "'" & " And nStbMonedaID <> " & IdMonedal & " And nActivo = 1"
                Else
                    ObjMoneda.Filter = "sCodigoInterno = '" & Me.TxtCodigo.Text & "'" & " And nActivo = 1"
                End If

                ObjMoneda.Retrieve()

                If ObjMoneda.Count > 0 Then
                    MsgBox("El Código ya Existe ", MsgBoxStyle.Critical, "SMUSURA0")
                    ErrorProvider1.SetError(Me.TxtCodigo, "Código ya existe, por favor verifique!!!")
                    Me.TxtCodigo.SelectAll()
                    Me.TxtCodigo.Focus()
                    GoTo SALIR
                End If
            End If
            '-- 2. Validando la descripción de la moneda debe contener un valor valido.
            If Trim(Me.TxtDescripcionMoneda.Text).Length = 0 Then
                MsgBox("La descripción de la moneda no debe quedar vacia.", MsgBoxStyle.Critical, "SMUSURA0")
                ErrorProvider1.SetError(Me.TxtDescripcionMoneda, "La descripción de la moneda no debe quedar vacia")
                Me.TxtDescripcionMoneda.Focus()
                GoTo SALIR
            ElseIf ModoForm = "ADD" Then
                ObjMoneda.Filter = "sDescripcion ='" & Me.TxtDescripcionMoneda.Text.Trim & "'" & " And nStbMonedaID <> " & IdMonedal & " And nActivo = 1"
                ObjMoneda.Retrieve()
                If ObjMoneda.Count > 0 Then
                    MessageBox.Show("El nombre ya existe, por favor verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrorProvider1.SetError(Me.TxtDescripcionMoneda, "El nombre de la moneda ya existe, por favor verifique!!!")
                    Me.TxtDescripcionMoneda.Focus()
                    GoTo SALIR
                End If
            End If


            If ModoForm = "UPD" Then
                ObjMoneda.Filter = "sDescripcion ='" & Me.TxtDescripcionMoneda.Text.Trim & "'" & " And nStbMonedaID <> " & IdMonedal & " And nActivo = 1"
                ObjMoneda.Retrieve()
                If ObjMoneda.Count > 0 Then
                    MessageBox.Show("El nombre ya existe, por favor verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrorProvider1.SetError(Me.TxtDescripcionMoneda, "La Descripción de la Moneda ya existe, por favor verifique!!!")
                    Me.TxtDescripcionMoneda.SelectAll()
                    Me.TxtDescripcionMoneda.Focus()

                    GoTo SALIR
                End If
            End If

            '-- 3. Validando que exista un valor valido para el simbolo de la moneda.

            If Trim(Me.TxtSimbolo.Text).Length = 0 Then
                MsgBox("El símbolo de la moneda no debe quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ErrorProvider1.SetError(Me.TxtSimbolo, "El Símbolo de la Moneda no puede estar vacío")
                Me.TxtSimbolo.Focus()
                GoTo SALIR
            Else
                If ModoForm = "ADD" Then
                    ObjMoneda.Filter = "(nActivo=1) and sSimbolo ='" & Me.TxtSimbolo.Text.Trim & "'"
                    ObjMoneda.Retrieve()
                ElseIf ModoForm = "UPD" Then
                    ObjMoneda.Filter = "(nActivo=1) and sSimbolo ='" & Me.TxtSimbolo.Text.Trim & "'" & " And nStbMonedaID <> " & IdMonedal & ""
                    ObjMoneda.Retrieve()
                End If
                If ObjMoneda.Count > 0 Then
                    MessageBox.Show("El símbolo ya existe, por favor verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrorProvider1.SetError(Me.TxtSimbolo, "El símbolo que seleccionó ya existe")
                    Me.TxtSimbolo.SelectAll()
                    Me.TxtSimbolo.Focus()
                    GoTo SALIR
                End If
                If Trim(Me.TxtSimbolo.Text).Length > 3 Then
                    MessageBox.Show("La longitud del símbolo no puede ser mayor de 3 caracteres, verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrorProvider1.SetError(Me.TxtSimbolo, "El símbolo tiene más de 3 caracteres")
                    Me.TxtSimbolo.SelectAll()
                    Me.TxtSimbolo.Focus()
                    GoTo SALIR
                End If
            End If
            If ModoForm = "ADD" Then
                If Me.RbNacionalSi.Checked Then
                    ObjMoneda.Filter = "(nActivo = 1) and (nNacional=1) and sCodigoInterno <> '" & Me.TxtCodigo.Text.Trim & "'"
                    ObjMoneda.Retrieve()
                    If ObjMoneda.Count > 0 Then
                        MessageBox.Show("Ya existe una moneda nacional, por favor verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ErrorProvider1.SetError(Me.RbNacionalSi, "Existe moneda nacional")
                        Me.RbNacionalSi.Focus()
                        GoTo SALIR

                    End If
                End If
            Else
                If Me.RbNacionalSi.Checked Then
                    ObjMoneda.Filter = "(nActivo = 1) and (nNacional=1) and sCodigoInterno <> '" & Me.TxtCodigo.Text.Trim & "'"
                    ObjMoneda.Retrieve()
                    If ObjMoneda.Count > 0 Then
                        MessageBox.Show("Existe ya una Moneda Nacional, por favor verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ErrorProvider1.SetError(Me.RbNacionalSi, " Existe Moneda Nacional")
                        Me.RbNacionalSi.Focus()
                        GoTo SALIR

                    End If
                End If
            End If
            If ModoForm = "UPD" Then
                If IdNacional2 = True And Me.RbNacionalNo.Checked = True Then
                    If MsgBox("¿ La Moneda Seleccionada es Nacional, Desea Modificarla ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.No Then
                        ErrorProvider1.SetError(Me.RbNacionalSi, " Moneda es Nacional")
                        Me.RbNacionalSi.Focus()
                        GoTo SALIR
                    End If
                End If
            End If


            VbResultado = True
            Yavalido = True
SALIR:
            Return (VbResultado)
            ObjMoneda = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    24/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda_Add.vb
    '-- Descripcion      :    Salvar los datos de la Moneda.
    '------------------------------------------------------------------------
    Private Sub SalvarMoneda()
        Dim Num = 0
        Try
            'Asignar los datos al DataRow de la Moneda

            If ModoFrm = "ADD" Then
                ObjMonedaDr.NewRow()
                'BuscaMayorCodigo()
                ObjMonedaDr.sUsuarioCreacion = InfoSistema.LoginName
                ObjMonedaDr.dFechaCreacion = FechaServer()
            Else
                ObjMonedaDr.sUsuarioModificacion = InfoSistema.LoginName
                ObjMonedaDr.dFechaModificacion = FechaServer()
            End If

            ObjMonedaDr.sCodigoInterno = Me.TxtCodigo.Text
            ObjMonedaDr.sDescripcion = Me.TxtDescripcionMoneda.Text
            ObjMonedaDr.sSimbolo = Me.TxtSimbolo.Text
            If ModoForm = "ADD" Then
                ObjMonedaDr.nActivo = 1
            Else
                ObjMonedaDr.nActivo = IIf(Me.Activo1 = True, 1, 0)
            End If


            If Me.RbNacionalSi.Checked Then
                ObjMonedaDr.nNacional = 1
            Else
                ObjMonedaDr.nNacional = 0
            End If

            ObjMonedaDr.Update()
            IdMoneda = ObjMonedaDr.nStbMonedaID

            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub TxtSimbolo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSimbolo.KeyPress
        If Letras(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            ' Variables 
            Dim respuesta As Object

            If vbUsuarioModifica = True Then
                respuesta = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case respuesta
                    Case vbYes
                        If Me.Yavalido = False Then
                            If FncValidaParametros() Then
                                SalvarMoneda()
                                AccionUsuario = AcciondelBoton.Aceptar
                                Me.Close()
                            Else
                                AccionUsuario = AcciondelBoton.Ninguno
                            End If
                        Else
                            SalvarMoneda()
                            AccionUsuario = AcciondelBoton.Aceptar
                            Me.Close()
                        End If
                    Case vbNo
                        AccionUsuario = AcciondelBoton.Cancelar
                        Me.Close()
                    Case vbCancel
                        AccionUsuario = AcciondelBoton.Ninguno
                End Select
            Else
                AccionUsuario = AcciondelBoton.Cancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub TxtDescripcionMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcionMoneda.KeyPress
        If Letras(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    Private Sub TxtDescripcionMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionMoneda.TextChanged
        vbUsuarioModifica = True
    End Sub
    Private Sub TxtSimbolo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSimbolo.TextChanged
        vbUsuarioModifica = True
    End Sub
    Private Sub RbNacionalSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbNacionalSi.CheckedChanged
        vbUsuarioModifica = True
    End Sub
    Private Sub RbNacionalNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbNacionalNo.CheckedChanged
        vbUsuarioModifica = True
    End Sub
    Private Sub C1CodigoInterno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        vbUsuarioModifica = True
    End Sub
    Private Sub RbActivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        vbUsuarioModifica = True
    End Sub

    Private Sub CkboxActivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkboxActivo.Click
        If CkboxActivo.Checked Then
            Me.Activo1 = True
        Else
            Me.Activo1 = False
        End If
        Me.vbUsuarioModifica = True
    End Sub
    Private Sub CkboxActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkboxActivo.GotFocus
        Try
            Me.CkboxActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CkboxActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkboxActivo.LostFocus
        Try
            Me.CkboxActivo.BackColor = GrpMonedas.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged
        vbUsuarioModifica = True
    End Sub

    Private Sub CkboxActivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkboxActivo.TextChanged
        vbUsuarioModifica = True
    End Sub
End Class
