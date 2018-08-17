' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                21/06/2010
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditMinutaBancoEnLinea.vb
' Descripción:          Este formulario permite importar archivo Excel
'                       de Banca en Línea.
'-------------------------------------------------------------------------
Public Class frmSteEditMinutaBancoEnLinea

    '-- Declaración de Variables: 
    Dim IdSteCuentaBancaria As Integer
    Dim ListSqlStrings As New ArrayList  'arreglo donde ingresaremos las sentencias

    'Propiedad utilizada para obtener el ID de la Cuenta Bancaria.
    Public Property IdCuentaBancaria() As Long
        Get
            IdCuentaBancaria = IdSteCuentaBancaria
        End Get
        Set(ByVal value As Long)
            IdSteCuentaBancaria = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       frmSteEditMinutaBancoEnLinea_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditMinutaBancoEnLinea_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       frmSteEditMinutaBancoEnLinea_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Fichas de Notificación en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditMinutaBancoEnLinea_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar variables.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            txtArchivoAbierto.Text = ""
            Me.DataGridView1.DataSource = ""
            ListSqlStrings.Clear()
            Me.cdeFechaD.Select()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       CmdImportar_Click
    ' Descripción:          Este evento permite importar registros Excel.
    '-------------------------------------------------------------------------
    Private Sub CmdImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdImportar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing
        Try

            ' ----------- VALIDACIONES:
            Dim Strsql As String
            Dim strSentencia As Object
            Dim sentencia As String = ""

            'Fechas de Corte Validas:
            If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fecha de Corte no mayor a la de Inicio:
            If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            'Máximo 3 meses entre la fecha de inicio y corte:
            If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 2 Then
                MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a tres meses.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If
            REM
            'Máximo 31 días entre la fecha de inicio y corte:
            'If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
            '    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
            '    Me.cdeFechaD.Focus()
            '    Exit Sub
            'End If

            'Imposible importar si ya se importó para esa Cuenta, Fechas y Tipo de Operación:
            Strsql = " SELECT * " & _
                     " FROM SteMinutaBancoEnLinea " & _
                     " WHERE (nSteCuentaBancariaID = " & Me.IdCuentaBancaria & ")  " & _
                     " AND (nDeposito = " & IIf(Me.chkDepositos.Checked = True, 1, 0) & ")  " & _
                     " AND (dFechaDepositoBanco BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Ya existen registros importados para esta" & Chr(13) & "Cuenta Bancaria y rangos de fechas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si es importación de cheques la cuenta debe ser corriente:
            If Me.chkDepositos.Checked = False Then
                Strsql = " SELECT SteCuentaBancaria.nSteCuentaBancariaID " & _
                         " FROM SteCuentaBancaria INNER JOIN StbValorCatalogo ON SteCuentaBancaria.nStbTipoCuentaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SteCuentaBancaria.nSteCuentaBancariaID = " & Me.IdCuentaBancaria & ")"
                If RegistrosAsociados(Strsql) = False Then
                    MsgBox("La Cuenta Bancaria no es Corriente." & Chr(13) & "Imposible importar cheques.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            '-- Solicita al usuario ruta de archivo Excell:
            If txtArchivoAbierto.Text = "" Then
                MsgBox("Debe buscar Archivo Excel.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Archivo debe contener tres columnas:
            If DataGridView1.ColumnCount <> 3 Then
                MsgBox("Imposible importar." & Chr(13) & "Hoja Excel debe poseer tres columnas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            
            'Si no se encontró el Archivo Excel:
            If Not System.IO.File.Exists(Me.txtArchivoAbierto.Text) Then
                MsgBox("No se encontró el Archivo Excel: " & _
                        Me.txtArchivoAbierto.Text, MsgBoxStyle.Critical, _
                        "Ruta inválida")
                Exit Sub
            End If

            'Importar Registros DataGridView: 
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If IngresarArreglo() Then
                '-- Instanciar Trans:
                Trans = New BOSistema.Win.Transact
                Trans.BeginTrans()

                'Recorrer arreglo para ingresar en SQL Server:
                For Each strSentencia In ListSqlStrings
                    sentencia = strSentencia.ToString()
                    XcDatos.ExecuteNonQuery(sentencia.ToString())
                Next

                '-- Finaliza Transacción:
                Trans.Commit()
                Me.Cursor = System.Windows.Forms.Cursors.Default

                'Indicar inserción satisfactoria:
                MsgBox("Los registros se importaron satisfactoriamente.", MsgBoxStyle.Information)
                Call GuardarAuditoria(5, 25, "Importación Banca en Línea. Del: " & Me.cdeFechaD.Text & " Al: " & Me.cdeFechaH.Text & ". Cuenta ID: " & Me.IdCuentaBancaria)
                'Cerrar Formulario:
                Me.Close()
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default

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
    ' Fecha:                21/06/2010
    ' Procedure Name:       CmdBuscar_Click
    ' Descripción:          Este evento permite buscar archivos xls.
    '-------------------------------------------------------------------------
    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        Try

            'Nombre de Pestaña Válido:
            If (Trim(RTrim(Me.txtPestana.Text)).ToString.Length = 0) Or (txtPestana.Text = "") Then
                MsgBox("El Primer Nombre de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtPestana.Focus()
                Exit Sub
            End If

            'Limpiar Variables:
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            txtArchivoAbierto.Text = ""
            Me.DataGridView1.DataSource = ""
            Me.ListSqlStrings.Clear()

            'Busca Archivo Excel:
            Me.ArchivoLocacion.Filter = "Excel 2007 Workbook (*.xlsx)|*.XLSX|Excel 97-2003 Workbook (*.xls)|*.XLS"
            Me.ArchivoLocacion.ShowDialog()
            txtArchivoAbierto.Text = IIf(IsDBNull(Me.ArchivoLocacion.FileName), "", Me.ArchivoLocacion.FileName)

            'Carga Archivo en ListView
            Cargar(DataGridView1, txtArchivoAbierto.Text, Me.txtPestana.Text)
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       Cargar
    ' Descripción:          Este evento permite importar registros Excel al
    '                       DataGridView.
    '-------------------------------------------------------------------------
    Private Sub Cargar(ByVal dgView As DataGridView, ByVal SLibro As String, ByVal sHoja As String)
        'HDR=YES : Con encabezado  
        Dim cs As String = ""
        Try

            'Crear variable de conexion Excel:
            Dim cn As System.Data.OleDb.OleDbConnection
            If Microsoft.VisualBasic.Right(SLibro, 1) = "x" Then
                cs = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                         "Data Source=" & SLibro & ";" & _
                         "Extended Properties=""Excel 12.0 Xml;HDR=NO""" 'YES"""
            Else
                cs = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                     "Data Source=" & SLibro & ";" & _
                     "Extended Properties=""Excel 8.0;HDR=NO""" 'YES"""
            End If
            cn = New System.Data.OleDb.OleDbConnection(cs)

            'Si no se encuentra Archivo Excel:
            If Not System.IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Archivo Excel: " & _
                        SLibro, MsgBoxStyle.Critical, _
                        "Ruta inválida")
                Exit Sub
            End If

            'Se conecta con la hoja indicada (me.txtPestana.Text):
            Dim dAdapter As System.Data.OleDb.OleDbDataAdapter
            dAdapter = New System.Data.OleDb.OleDbDataAdapter("Select * From [" & sHoja & "$]", cs)

            Dim datos As New DataSet
            'Agrega los datos:
            dAdapter.Fill(datos)

            'Cerrar conexion OLEDB para Excel:
            cn.Close()

            With DataGridView1
                ' llena el DataGridView  
                .DataSource = datos.Tables(0)
            End With

        Catch ex As Exception
            Control_Error(ex)
            'MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/06/2010
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada(ByVal Fila As Integer, ByVal StrFecha As String, ByVal StrDeposito As String, ByVal StrMonto As String) As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True

            'Fecha Válida:
            If Not IsDate(StrFecha) Then
                MsgBox("Fecha Inválida en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If
            'Dentro del rango de fechas indicadas:
            If (Format(CDate(StrFecha), "yyyy-MM-dd") > Format(CDate(cdeFechaH.Text), "yyyy-MM-dd")) Or (Format(CDate(StrFecha), "yyyy-MM-dd") < Format(CDate(cdeFechaD.Text), "yyyy-MM-dd")) Then
                MsgBox("Fecha fuera del rango indicado en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Monto Válido:
            If Not IsNumeric(StrMonto) Then
                MsgBox("Monto Inválido en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If
            If CDbl(StrMonto) = 0 Then
                MsgBox("Monto Inválido en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Si es importación de cheques imposible subir montos positivos:
            If Me.chkDepositos.Checked = False Then
                If CDbl(StrMonto) > 0 Then
                    MsgBox("Monto Inválido en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            End If

            'Número de Cheque/Depósito Válido:
            If Trim(RTrim(StrDeposito.ToString.Length = 0)) Then
                MsgBox("Número de " & IIf(Me.chkDepositos.Checked = True, "depósito", "cheque") & " Inválido en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If
            If (StrDeposito = "0") Or (StrDeposito = "") Then
                MsgBox("Número de " & IIf(Me.chkDepositos.Checked = True, "depósito", "cheque") & " Inválido en Fila " & Fila & " de archivo excel.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si existe registro para la Fecha, Minuta y Monto en BD:
            strSQL = "SELECT nSteMinutaBancoEnLineaID FROM SteMinutaBancoEnLinea " & _
                     "WHERE (sNumeroDepositoBanco = '" & StrDeposito & "') AND (dFechaDepositoBanco = CONVERT(DATETIME, '" & Format(CDate(StrFecha), "yyyy-MM-dd") & "', 102)) AND (nMontoDeposito = " & StrMonto & ")"
            If RegistrosAsociados(strSQL) Then
                ValidaDatosEntrada = False
                MsgBox("Imposible importar información." & Chr(13) & "Ya existe un registro para la fecha, minuta y monto indicado en fila " & Fila & " de Archivo Excel.", MsgBoxStyle.Critical, NombreSistema)
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/06/2010
    ' Procedure Name:       IngresarArreglo
    ' Descripción:          Función que agrga contenido de DataGridView a un
    '                       arreglo siempre que los datos de excel sean válidos.
    '-------------------------------------------------------------------------
    Private Function IngresarArreglo() As Boolean
        Try

            IngresarArreglo = True
            Dim SqlString As String = "" 'variable a la que asignaremos la sentencia
            Dim nMontoCheque As Double

            If DataGridView1.Rows.Count > 0 Then
                'Recorremos el datagrid:
                For i As Integer = 0 To DataGridView1.Rows.Count - 2
                    'Si los datos son válidos:
                    If ValidaDatosEntrada(i + 1, DataGridView1.Rows(i).Cells(0).Value.ToString(), DataGridView1.Rows(i).Cells(1).Value.ToString(), DataGridView1.Rows(i).Cells(2).Value.ToString()) Then
                        'Creamos la sentencia el row siempre tendra el valor de i:
                        If Me.chkDepositos.Checked = True Then
                            SqlString = "INSERT INTO SteMinutaBancoEnLinea (nSteCuentaBancariaID, dFechaDepositoBanco, sNumeroDepositoBanco, nMontoDeposito, nDeposito, nUsuarioCreacionID) " & _
                                        "VALUES (" & Me.IdSteCuentaBancaria & ",'" & Format(CDate(DataGridView1.Rows(i).Cells(0).Value), "yyyy-MM-dd") & "','" + DataGridView1.Rows(i).Cells(1).Value.ToString() & "'," + DataGridView1.Rows(i).Cells(2).Value.ToString() & ", 1," & InfoSistema.IDCuenta & ")"
                        Else
                            nMontoCheque = CDbl(DataGridView1.Rows(i).Cells(2).Value.ToString()) * -1
                            SqlString = "INSERT INTO SteMinutaBancoEnLinea (nSteCuentaBancariaID, dFechaDepositoBanco, sNumeroDepositoBanco, nMontoDeposito, nDeposito, nUsuarioCreacionID) " & _
                                        "VALUES (" & Me.IdSteCuentaBancaria & ",'" & Format(CDate(DataGridView1.Rows(i).Cells(0).Value), "yyyy-MM-dd") & "','" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "'," & nMontoCheque & ", 0," & InfoSistema.IDCuenta & ")"
                        End If
                        ListSqlStrings.Add(SqlString)
                    Else
                        IngresarArreglo = False
                        Me.ListSqlStrings.Clear()
                        Exit Function
                    End If
                Next
            Else
                IngresarArreglo = False
                MsgBox("No hay información para importar.", MsgBoxStyle.Critical, NombreSistema)
                Exit Function
            End If

        Catch ex As Exception
            IngresarArreglo = False
            Control_Error(ex)
        End Try
    End Function
End Class