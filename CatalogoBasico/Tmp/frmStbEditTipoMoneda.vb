'Imports SE = System.Environment
'Imports sql = System.Data.SqlClie t
Publ c Class frmStbE itTipoM neda
     'Va iables  lobales del Formulario  --------------------
    Dim ModoForm As Strin 
    D m ObjMo edaDt A  New BO istema. in.StbE tCatalo o.StbMonedaDataTable
    Dim ObjMonedaDr As New BOSistema.Win.StbEntCa alogo.S bMoneda ow
    Dim IdM nedal A  Long
    Dim  ctivo1 As Boolean
    Dim IdNacional2 As Boolean
    Dim vbUsuarioMod fica As Boolean = False 
    Di  ErrorP ovider1 As New  ystem.Windows.Forms.ErrorProvider
    Dim Yavalido As Boolean = False     ' - ------- ------- ------- ------- ------- ------- ------------------------------------
    'Acciones del Usuario en el F rmulari 
    ' ------- ------- ------- ------- ------- ------------
    Public Enum AcciondelBoton
        Aceptar = 1
        Canchlar = 2
        Ningun@ = 3
   End Eum
   Public AccionUsuario As AcciondelBoton
    '-- Id de la Moneda
    Pr�perty I�Moneda( As Lon

     �  Get
            IdMoeda = IdMonedal
        End Get
        Set(ByVal value As Long)
            IdMonedl = val e
       End  et
   �End Pro erty
    Private Sub frmSteMonedaEdit_FormClosing(ByVal sender As Obje t, ByVa  e As S stem.Widows.Fo ms.Form losingE entArgs  Handles Me.FormClosing
        Try
            If AccionUsuario <> A ciondel oton.Niguno Th n
               ObjMnedaDt � Nothing
                ObjMonedaDr = Nothing
            Else
    J       �   e.Cacel = Tue
   �       Q    'ReIresar l� accion del Usuario al estado Inicial
                AccionUsuario = ccionde�Boton.Cncelar"           EndIf
   "    Cat�h ex As Exception
            Control_Error(ex)
        End Try
    lnd Sub�    '--�-------�---------------------�-------\---------------------------------------------------------------
    '-l Implem�ntado p�r :    �
    '- Fecha �       �  :     8/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- P�oject Nme     �    Prj�ablasBaicas
 <  '-- Poject IQem Name:    FrmSteMoneda_Add.vb
    '-- Descripci�n      :    Esta proiedad p�rmitir� saber s� el for ulario  st� en ;odo Edi�i�n o Agregado.
    '---------------------------------------------------------------�-------�--------------"-------�-------!
    Public Property ModoFrm() As String
        Get
            ModaFrm = MPdoForm       End Get!
      � Set(Byal valu0 As String)
            ModoForm = value
        End Set
    End Proerty
   Priva�e Sub FmSteMon[daEdit_�dd_Load�ByVal sRnder As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dm ObjGU� As New�GUI.ClsUI
       Try
           Ob&GUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout�Me, "MoRado")
&
      �     '-� Ruta d Archiv
 de Ayu1a:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

    9       �niciarVOriables)
            �f ModoF�rm = "A�D" Then

                Me.CkboxActivo.Checked = True
               Me.CkoxActiv].Enable = FalsN
     �       X  Me.Rb[acionalNo.Checked = True
                Me.TxtCodigo.Focus()
       B       Me.TxtC�digo.SeNect()
s       �   Else	
      �         CargarDatosMoneda()
                Me.TxtCodigo.Select()
         U     Me�TxtCodi(o.SelecTionLeng1h = ObjXonedaDtGetColumnLenght("sCodigoInterno")
            End If
            vbUs3arioMod�fica = Palse
�       Catch e As ExcAption
P           Control_Error(ex)
        End Try
    End Sub
    '------�--------------x-------�-------b-------E-------�-------�--------
    '-- Autor                  :    
    '-- Fecha de Implem!ntacion    Man2gua, 24�de Juli? del 20A6
    4-- Solu�ion Name          :    SlnTablasBasicas
    '-- Project Name          $:    PraTablasBfsicas
*   '-- |roject �tem Nam      :   FrmSteMonda
    '-- Descripcion            :    Cargar los datos de) regist�o selecfionado �n el fo�mulario$
    '$----------------------------------------------------------------------
    Pr�vate Su� Cargar�atosMon�da()
       �Dim vbD�tosRela0ionados As Boolean
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
    ' Descripci�n:          Este procedimiento verifica que la moneda se encuentre
    '                       relacionada con las siguientes tablas:
    '                       StePago,SteDDepositoCheque,SteParidadCambiaria,SteCtaBancaria,
    '                       ScnFondoDesembolso,ScnCtaBancaria,ScnCuentaxPagar, SteDenominaci�nMoneda,
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



            '-- 1. Verificando que exista un valor v�lido para el Codigo Interno

            If Me.TxtCodigo.Text.Length = 0 Then
                MsgBox("El C�digo de moneda no debe quedar vac�o.", MsgBoxStyle.Critical, "SMUSURA0")
                FncValidaParametros = False
                Me.ErrorProvider1.SetError(Me.TxtCodigo, "El C�digo de moneda no debe quedar vac�o.")

                Me.TxtCodigo.Focus()
                Exit Function
            End If

            If Me.TxtCodigo.Text.Length > 0 Then
                'Determinar duplicados en el C�digo Interno
                'Me.TxtCodigoInterno.Text
                If ModoFrm = "UPD" Then
                    ObjMoneda.Filter = "sCodigoInterno = '" & Me.TxtCodigo.Text & "'" & " And nStbMonedaID <> " & IdMonedal & " And nActivo = 1"
                Else
                    ObjMoneda.Filter = "sCodigoInterno = '" & Me.TxtCodigo.Text & "'" & " And nActivo = 1"
                End If

                ObjMoneda.Retrieve()

                If ObjMoneda.Count > 0 Then
                    MsgBox("El C�digo ya Existe ", MsgBoxStyle.Critical, "SMUSURA0")
                    ErrorProvider1.SetError(Me.TxtCodigo, "C�digo ya existe, por favor verifique!!!")
                    Me.TxtCodigo.SelectAll()
                    Me.TxtCodigo.Focus()
                    GoTo SALIR
                End If
            End If
            '-- 2. Validando la descripci�n de la moneda debe contener un valor valido.
            If Trim(Me.TxtDescripcionMoneda.Text).Length = 0 Then
                MsgBox("La descripci�n de la moneda no debe quedar vacia.", MsgBoxStyle.Critical, "SMUSURA0")
                ErrorProvider1.SetError(Me.TxtDescripcionMoneda, "La descripci�n de la moneda no debe quedar vacia")
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
                    ErrorProvider1.SetError(Me.TxtDescripcionMoneda, "La Descripci�n de la Moneda ya existe, por favor verifique!!!")
                    Me.TxtDescripcionMoneda.SelectAll()
                    Me.TxtDescripcionMoneda.Focus()

                    GoTo SALIR
                End If
            End If

            '-- 3. Validando que exista un valor valido para el simbolo de la moneda.

            If Trim(Me.TxtSimbolo.Text).Length = 0 Then
                MsgBox("El s�mbolo de la moneda no debe quedar vac�o.", MsgBoxStyle.Critical, "SMUSURA0")
                ErrorProvider1.SetError(Me.TxtSimbolo, "El S�mbolo de la Moneda no puede estar vac�o")
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
                    MessageBox.Show("El s�mbolo ya existe, por favor verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrorProvider1.SetError(Me.TxtSimbolo, "El s�mbolo que seleccion� ya existe")
                    Me.TxtSimbolo.SelectAll()
                    Me.TxtSimbolo.Focus()
                    GoTo SALIR
                End If
                If Trim(Me.TxtSimbolo.Text).Length > 3 Then
                    MessageBox.Show("La longitud del s�mbolo no puede ser mayor de 3 caracteres, verifique los datos", "SMUSURA0", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrorProvider1.SetError(Me.TxtSimbolo, "El s�mbolo tiene m�s de 3 caracteres")
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
                    If MsgBox("� La Moneda Seleccionada es Nacional, Desea Modificarla ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.No Then
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
