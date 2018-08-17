Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core
Imports System.Text

Public Class frmSteEstadoCuentaDiario

    Dim objDataSet As New Data.DataSet
    Dim xData As New BOSistema.Win.XDataSet.xDataTable
    Dim dtresult As New Data.DataTable("Reporte")
    Dim lDocumentosNoAsignados As New List(Of String)
    Dim m_Excel As Excel.Application
    Dim source As Data.DataTable

    Private _Archivo As String
    Public Property Archivo() As String
        Get
            Return _Archivo
        End Get
        Set(ByVal value As String)
            _Archivo = value
        End Set
    End Property

    Private Function GeneraGridMinuta() As System.Data.DataTable

        Dim result As New Data.DataTable("Main")
        Try

            result.Columns.Add("Fecha", Type.GetType("System.DateTime"))
            result.Columns.Add("Documento", Type.GetType("System.Int32"))
            result.Columns.Add("Descripcion", Type.GetType("System.String"))
            result.Columns.Add("Monto", Type.GetType("System.Double"))
            result.Columns.Add("Saldo", Type.GetType("System.Double"))

        Catch ex As Exception
            Control_Error(ex)
        End Try

        Return result

    End Function

    Private Function GeneraFormatoSalida() As System.Data.DataTable

        Dim result As New Data.DataTable("Reporte")
        Try

            result.Columns.Add("ID", Type.GetType("System.Int32"))
            result.Columns.Add("CajaID", Type.GetType("System.Int32"))
            result.Columns.Add("FechaDeposito", Type.GetType("System.DateTime"))
            result.Columns.Add("NombreCaja", Type.GetType("System.String"))
            result.Columns.Add("Documento", Type.GetType("System.Int32"))
            result.Columns.Add("MontoSistema", Type.GetType("System.Double"))
            result.Columns.Add("MontoBanco", Type.GetType("System.Double"))
            result.Columns.Add("Diferencia", Type.GetType("System.Double"))
            result.Columns.Add("CajaManagua", Type.GetType("System.Int32"))
            result.Columns.Add("NombreDelegacion", Type.GetType("System.String"))

        Catch ex As Exception
            Control_Error(ex)
        End Try

        Return result

    End Function

    Private Sub frmSteEstadoCuentaDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a utilizarse.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub AbrirExcel(ByVal source As Data.DataTable)

        Me.m_Excel = New Excel.Application()
        '' Creamos una variable para guardar la cultura actual
        Dim OldCultureInfo As System.Globalization.CultureInfo = _
        System.Threading.Thread.CurrentThread.CurrentCulture
        'Crear una cultura standard (en-US) inglés estados unidos
        System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("en-US")
        ''Abrimos el libro
        Dim wb As Excel.Workbook = Me.m_Excel.Workbooks.Open(Me.OpenFileDialog.FileName)
        Dim objHojaExcel As Excel.Worksheet = wb.Worksheets(Me.txtNombreHoja.Text)
        Dim rango As String() = Me.txtRange.Text.Split(":")
        Dim InicioFila As Int32 = Me.Numero(rango(0))
        Dim FinFila As Int32 = Me.Numero(rango(1))

        ''Recorremos 
        For Fila As Int32 = (InicioFila + 1) To FinFila
            Dim row As Data.DataRow = source.NewRow
            row("Fecha") = objHojaExcel.Range(String.Format("A{0}", Fila), Type.Missing).Value
            row("Documento") = objHojaExcel.Range(String.Format("B{0}", Fila), Type.Missing).Value
            row("Descripcion") = objHojaExcel.Range(String.Format("C{0}", Fila), Type.Missing).Value
            row("Monto") = objHojaExcel.Range(String.Format("D{0}", Fila), Type.Missing).Value
            row("Saldo") = objHojaExcel.Range(String.Format("E{0}", Fila), Type.Missing).Value
            source.Rows.Add(row)
        Next

        wb.Close()
        wb = Nothing
        objHojaExcel = Nothing

        System.Threading.Thread.CurrentThread.CurrentCulture = OldCultureInfo
       
    End Sub

    Private Function Numero(ByVal str As String) As Int32
        Dim caracteres As Char() = str.ToCharArray()
        Dim strnumber As String = String.Empty
        For Each caracter As Char In caracteres
            If Char.IsNumber(caracter) Then
                strnumber += caracter
            End If
        Next
        Return Convert.ToInt32(strnumber)
    End Function

    Private Sub cmdCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCargar.Click
        ' // Pasar valores para Leer el rango   
        If Not String.IsNullOrEmpty(Archivo) Then
            If Not String.IsNullOrEmpty(Me.txtNombreHoja.Text) Then
                If Not String.IsNullOrEmpty(Me.txtRange.Text) Then

                    source = Me.GeneraGridMinuta()
                    ''objDataSet = AbrirLibroExcel(Archivo, txtNombreHoja.Text, txtRange.Text)
                    Me.AbrirExcel(source)
                    ''source = AbrirLibroExcel(Archivo, txtNombreHoja.Text, txtRange.Text)
                    If Not source.Rows.Count = 0 Then
                        With DataGridView1
                            .DataSource = source ''objDataSet
                            ''.DataMember = objDataSet.Tables(0).TableName
                        End With
                    End If
                    Me.cmdGenerar.Enabled = True
                Else
                    MsgBox("Indique el rango.", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Indique el nombre de la hoja.", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Busque el archivo de Excel.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click


        Try
            dtresult = GeneraFormatoSalida()

            lDocumentosNoAsignados.Clear()

            xData.ExecuteSql(Me.Query())

            If DataGridView1.Rows.Count > 0 Then
                For Each minuta As DataGridViewRow In DataGridView1.Rows

                    Dim rows As Data.DataRow() = xData.Table.Select(String.Format("sNumeroDeposito={0}", minuta.Cells("Documento").Value))

                    If rows.Length = 0 Then
                        lDocumentosNoAsignados.Add(minuta.Cells("Documento").Value.ToString())
                    End If

                    For Each row As Data.DataRow In xData.Table.Select(String.Format("sNumeroDeposito={0}", minuta.Cells("Documento").Value))

                        Dim fila As Data.DataRow = dtresult.NewRow

                        fila("ID") = Convert.ToInt32(row("ID"))
                        fila("CajaID") = Convert.ToInt32(row("nSteCajaID"))
                        fila("FechaDeposito") = Convert.ToDateTime(row("dFechaDeposito"))
                        fila("NombreCaja") = row("sDescripcionCaja").ToString
                        fila("Documento") = minuta.Cells("Documento").Value
                        fila("MontoSistema") = Convert.ToDouble(row("nMontoDeposito"))
                        Dim montoBanco As Double = 0
                        If IsDBNull(minuta.Cells("Monto").Value) Then
                            montoBanco = 0
                        Else
                            montoBanco = Convert.ToDouble(minuta.Cells("Monto").Value)
                        End If
                        fila("MontoBanco") = montoBanco
                        fila("Diferencia") = fila("MontoSistema") - fila("MontoBanco")
                        fila("CajaManagua") = row("CajaManagua")
                        fila("NombreDelegacion") = row("sNombreDelegacion")

                        dtresult.Rows.Add(fila)

                    Next

                Next

                With dgvResultado
                    .DataSource = dtresult
                End With

                dgvResultado.Columns("NombreCaja").Frozen = True
                dgvResultado.Columns("CajaID").Visible = False
                dgvResultado.Columns("FechaDeposito").Visible = False
                dgvResultado.Columns("CajaManagua").Visible = False
                dgvResultado.Columns("ID").Visible = False
                dgvResultado.Columns("NombreDelegacion").Visible = False
                dgvResultado.Columns("NombreCaja").Width = 190

                Me.btnExportar.Enabled = True

                MsgBox("Generación Finalizada", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Me.OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Archivo = Me.OpenFileDialog.SafeFileName
            Me.txtArchivo.Text = Me.OpenFileDialog.SafeFileName
        End If
    End Sub

    Public Function AbrirLibroExcel(ByVal sFileName As String, _
                                      ByVal sSheetName As String, _
                                      ByVal sRange As String) As System.Data.DataTable

        Dim result As DataTable

        Try
            ' // Comprobar que el archivo Excel existe  
            If System.IO.File.Exists(sFileName) Then

                System.Diagnostics.Process.Start(sFileName)

                Dim objDataSet As System.Data.DataSet
                Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
                ' // Declarar la Cadena de conexión  
                Dim sCs As String = "provider=Microsoft.Jet.OLEDB.4.0; " & "data source=" & sFileName & "; Extended Properties=Excel 8.0;"
                Dim objOleConnection As System.Data.OleDb.OleDbConnection
                objOleConnection = New System.Data.OleDb.OleDbConnection(sCs)

                ' // Declarar la consulta SQL que indica el libro y el rango de la hoja  
                Dim sSql As String = "select Fecha, Documento, Descripcion, Monto, Saldo from " & "[" & sSheetName & "$" & sRange & "] "
                ' // Obtener los datos  
                objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSql, objOleConnection)

                ' // Crear DataSet y llenarlo  
                objDataSet = New System.Data.DataSet
                'objDataSet.Tables(0) = GeneraGridMinuta()


                objDataAdapter.Fill(objDataSet)

                result = objDataSet.Tables(0)

                ' // Cerrar la conexión  

                objOleConnection.Close()

                'For Each proceso As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                '    proceso.Kill()
                'Next

                ''return objDataSet
                Return result

            Else
                MsgBox("No se ha encontrado el archivo: " & sFileName, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return New Data.DataTable()

    End Function

    Private Sub GeneraReporte()
        Dim oApp As New Excel.Application()
        Dim objLibroExcel As Excel.Workbook
        Dim objHojaExcel As Excel.Worksheet
        oApp.Visible = True
        oApp.UserControl = True
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        ' consolidar el monto de las cajas
        Dim dataToReport As Data.DataTable = AgruparCajas()
        Dim FechaDeposito As DateTime = dataToReport.Rows(0)("FechaDeposito")
        ' Exportar el reporte a Excel
        objLibroExcel = oApp.Workbooks.Add()
        objHojaExcel = objLibroExcel.Worksheets.Add()
        objHojaExcel.Name = String.Format("{0} {1}", FechaDeposito.Day, Mes(FechaDeposito.Month).ToUpper())
        objHojaExcel.Activate()
        objHojaExcel.Cells(1, 1).select()
        xData.ExecuteSql("SELECT sValorParametro FROM StbValorParametro svp WHERE svp.nStbValorParametroID = 38 ")
        Dim pathImage As String = xData.Table.Rows(0).Item("sValorParametro")
        Dim logo1 As System.Drawing.Image = System.Drawing.Image.FromFile(String.Format("{0}Logo.jpg", pathImage))
        objHojaExcel.Shapes.AddPicture(String.Format("{0}Logo.jpg", pathImage), MsoTriState.msoCTrue, MsoTriState.msoCTrue, 1.0F, 1.0F, logo1.Width - 90, logo1.Height - 30)
        '' Cargamos los montos por caja
        Dim CeldaAn As Excel.Range = objHojaExcel.Range("A1") 'Asignado para evitar warnings
        Dim CeldaBn As Excel.Range = objHojaExcel.Range("A1") 'Asignado para evitar warnings
        Dim Fila As Integer = 4
        'Combinamos las filas
        Dim objTitulo As Excel.Range = objHojaExcel.Range("A4")
        objTitulo.HorizontalAlignment = 3
        Dim objCeldaB As Excel.Range = objHojaExcel.Range("B4")
        objCeldaB.ColumnWidth = 38
        objTitulo.Value = String.Format("INGRESOS DE {0} DE {1} {2}", FechaDeposito.Day, Mes(FechaDeposito.Month).ToUpper, FechaDeposito.Year)
        objTitulo.Font.Bold = True
        objTitulo.Font.Size = 16
        objTitulo.ColumnWidth = 38
        objTitulo.Font.Name = "Calibri"
        objHojaExcel.Range("A4", "B4").Merge()
        Fila += 1
        'Saldo Anterior
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Saldo Anterior", "A", , , True)
        FormatoCelda(objHojaExcel, CeldaBn, Fila, SaldoAnterior().ToString, "B", 14, , True)
        Fila += 1
        Dim Band As Boolean = False
        Dim IndiceFormulaManagua As Integer

        For Each row As Data.DataRow In dataToReport.Rows
            If row("CajaManagua") = 0 And Not Band Then
                FormatoCelda(objHojaExcel, CeldaAn, Fila, "Total Managua", "A", , , True)
                '' Asignando el monto
                FormatoCelda(objHojaExcel, CeldaBn, Fila, "", "B", 14, , True, String.Format("=SUM(B6:B{0})", (Fila - 1)))
                Band = True
                IndiceFormulaManagua = Fila
                Fila += 1
            End If
            '' Asignando la caja
            FormatoCelda(objHojaExcel, CeldaAn, Fila, Me.FormatearNombreCaja(row("NombreCaja")), "A")
            '' Asignando el monto
            FormatoCelda(objHojaExcel, CeldaBn, Fila, row("MontoBanco"), "B", 14)
            Fila += 1

        Next
        '' Total Delegaciones
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Total Delegaciones", "A", , , True)
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "", "B", 14, , True, String.Format("=SUM(B{0}:B{1})", (IndiceFormulaManagua + 1), (Fila - 1)))
        Fila += 1
        '' Minutas Sin Asignar
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Minutas sin asignar", "A")
        CeldaAn = objHojaExcel.Range(String.Format("A{0}", Fila))
        CeldaAn.AddComment().Text(String.Format("Minutas Sin Asignar: {0}", ListaMinutasSinAsignar()))
        ''CeldaAn.NoteText(String.Format("Minutas Sin Asignar: {0}", ListaMinutasSinAsignar()))
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, ObtenerMontoMinutasSinAsignar(), "B", 14)
        Fila += 1
        '' Total Efectivo
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Total Efectivo", "A", , , True)
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "", "B", 14, , True, String.Format("= B{0} + B{1} + B{2}", (IndiceFormulaManagua), (Fila - 2), (Fila - 1)))
        Fila += 1
        '' Traslado de fondos
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "(-) Traslado de Fondos", "A")
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "0.0", "B", 14)
        Fila += 1
        '' Revalorización e Int.
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "(+) Revalorización e Int.", "A")
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "0.0", "B", 14)
        Fila += 1
        '' Traslado Cta. Unifem.
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "(+) Traslado Cta. Unifem", "A")
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "0.0", "B", 14)
        Fila += 1
        '' Saldo Final.
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Saldo Final", "A", , , True)
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "0.0", "B", 14, , True, String.Format("= B5 + B{0} + B{1} + B{2} - B{3}", (Fila - 4), ((Fila - 2)), (Fila - 1), ((Fila - 3))))
        Fila += 1
        '' Según estado de cuenta.
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Según estado de cuenta", "A")
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "0.0", "B", 14)
        Fila += 1
        '' Diferencia.
        FormatoCelda(objHojaExcel, CeldaAn, Fila, "Diferencia", "A")
        '' Asignando el monto
        FormatoCelda(objHojaExcel, CeldaBn, Fila, "0.0", "B", 14, , , String.Format("= B{0} - B{1}", (Fila - 2), (Fila - 1)))
        'Formatear el las celdas a moneda
        objHojaExcel.Range("B5", String.Format("B{0}", Fila)).NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* "" - ""??_);_(@_)"
        Fila += 2
        FormatoCelda(objHojaExcel, CeldaAn, Fila, " Elaborado por:________________________", "A", 11, , , , False)
        FormatoCelda(objHojaExcel, CeldaBn, Fila, " Revisado por:________________________", "B", 11, , , , False)
        'Eliminamos la instancia de Excel de memoria
        If Not objLibroExcel Is Nothing Then
            '' objLibroExcel.Application.Quit()
            objLibroExcel.Close()
            objLibroExcel = Nothing
            oApp = Nothing
            objHojaExcel = Nothing
            logo1.Dispose()
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        ''System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")

    End Sub

    Private Sub FormatoCelda(ByVal objHojaExcel As Excel.Worksheet, ByVal Celda As Excel.Range, ByVal Fila As Integer, ByVal Valor As String, ByVal columna As String, Optional ByVal fontSize As Integer = 12, Optional ByVal fontName As String = "Calibri", Optional ByVal fontBold As Boolean = False, Optional ByVal formula As String = "", Optional ByVal recuadro As Boolean = True)
        Celda = objHojaExcel.Range(String.Format("{0}{1}", columna, Fila))
        Celda.Font.Size = fontSize
        Celda.Font.Name = fontName
        If Not String.IsNullOrEmpty(formula) Then
            Celda.Formula = formula
        Else
            Celda.Value = Valor
        End If
        If fontBold Then
            Celda.Font.Bold = True
        End If

        If recuadro Then
            With Celda.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With Celda.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With Celda.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With Celda.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With Celda.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With Celda.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
        End If

    End Sub

    Private Function SaldoAnterior() As Double
        ''Obtiene el saldo anterior
        Dim saldo As Double = 0.0
        If Me.DataGridView1.RowCount > 0 Then
            Dim data As Data.DataTable = source
            Dim row As DataRow = data.NewRow
            row = data.Rows(0)
            saldo = Convert.ToDouble(row("Saldo")) - Convert.ToDouble(IIf(IsDBNull(row("Monto")), 0, row("Monto")))
        End If
        Return saldo
    End Function

    Private Function Mes(ByVal nMes As Int32) As String
        Select Case nMes
            Case 1
                Return "Enero"
            Case 2
                Return "Febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "Mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Septiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
        End Select
        Return ""
    End Function

    Private Sub Agrupar(ByRef resultado As Data.DataTable, ByVal order As String, Optional ByVal filter As String = "")
        Dim NombreCaja As String = String.Empty
        Dim nMonto As Double = 0.0
        Dim bCajaManagua As Boolean = False
        Dim contador As Int32 = 0
        Dim NombreAuxiliar As String
        For Each row As Data.DataRow In dtresult.Select(filter, order)
            contador += 1
            If String.IsNullOrEmpty(NombreCaja) Then

                NombreCaja = IIf(row("CajaManagua") = 1, row("NombreCaja"), row("NombreDelegacion"))

            End If
            'Agrupamos por caja los puntos de pago en Managua y por delegación los de los departamentos
            If row("CajaManagua") = 1 Then
                NombreAuxiliar = row("NombreCaja")
            Else
                NombreAuxiliar = row("NombreDelegacion")
            End If

            If Not NombreAuxiliar.Equals(NombreCaja) Then

                Dim fila As Data.DataRow = resultado.NewRow

                fila("NombreCaja") = NombreCaja
                fila("MontoBanco") = nMonto
                fila("FechaDeposito") = row("FechaDeposito")
                fila("CajaManagua") = bCajaManagua
                nMonto = 0.0
                resultado.Rows.Add(fila)

            End If

            nMonto += row("MontoBanco")
            NombreCaja = IIf(row("CajaManagua") = 1, row("NombreCaja"), row("NombreDelegacion"))
            bCajaManagua = row("CajaManagua")

            If contador = dtresult.Select(filter, order).Length Then

                Dim fila As Data.DataRow = resultado.NewRow
                fila("NombreCaja") = NombreCaja
                fila("MontoBanco") = nMonto
                fila("FechaDeposito") = row("FechaDeposito")
                fila("CajaManagua") = bCajaManagua
                resultado.Rows.Add(fila)

            End If
        Next

    End Sub

    Private Function AgruparCajas() As Data.DataTable

        Dim result As Data.DataTable = CType(Me.dgvResultado.DataSource, Data.DataTable)
        Dim resultado As Data.DataTable = GeneraFormatoSalida()
        ''Primero agrupamos las cajas de Managua
        Me.Agrupar(resultado, "NombreCaja", "CajaManagua = 1")
        ''Agrupamos las otras delegaciones
        Me.Agrupar(resultado, "NombreDelegacion", "CajaManagua = 0")

        Return resultado

    End Function

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try
            Me.GeneraReporte()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function FormatearNombreCaja(ByVal sNombre As String) As String
        Dim salida As String = ""
        sNombre = sNombre.ToLower.Replace("departamental", "")
        Dim cadenas As String() = sNombre.Split(" ")
        For Each cadena As String In cadenas
            If Not String.IsNullOrEmpty(cadena) Then
                salida += cadena.Substring(0, 1).ToUpper + cadena.Substring(1, cadena.Length - 1) + " "
            End If
        Next
        Return salida
    End Function

    Private Function ObtenerNumeroDocumentos() As String
        Dim documentos As String = " "
        Dim contador As Int16 = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            contador += 1
            documentos += String.Format("{0}{1} ", row.Cells("Documento").Value, IIf(contador = DataGridView1.Rows.Count, "", ","))
        Next
        Return documentos
    End Function

    Private Function Query() As String
        Dim consulta As New StringBuilder
        consulta.Append("SELECT *")
        consulta.Append("FROM   (")
        consulta.Append("       SELECT ROW_NUMBER() OVER(ORDER BY smd.sNumeroDeposito ASC) ID,")
        consulta.Append("                           sc.nSteCajaID,")
        consulta.Append("                           sc.nCodigo,")
        consulta.Append("                           sc.sDescripcionCaja,")
        consulta.Append("                           sac.nSteMinutaDepositoID,")
        consulta.Append("                           smd.sNumeroDeposito,")
        consulta.Append("                           smd.dFechaDeposito,")
        consulta.Append("                           smd.nMontoDeposito,")
        consulta.Append("                           CASE ")
        consulta.Append("                           WHEN vsug.Departamento = 'Managua' THEN 1")
        consulta.Append("                           ELSE 0")
        consulta.Append("                           END CajaManagua,")
        consulta.Append("                           sdp.sNombreDelegacion")
        consulta.Append("       FROM   SteArqueoCaja sac")
        consulta.Append("               INNER JOIN SteMinutaDeposito smd")
        consulta.Append("                   ON  smd.nSteMinutaDepositoID = sac.nSteMinutaDepositoID")
        consulta.Append("               INNER JOIN StbDelegacionPrograma sdp")
        consulta.Append("                   ON  sdp.nStbDelegacionProgramaID = smd.nStbDelegacionProgramaID")
        consulta.Append("               LEFT JOIN SteCaja sc")
        consulta.Append("                   ON  sc.nSteCajaID = sac.nSteCajaID")
        consulta.Append("               INNER JOIN vwStbUbicacionGeografica vsug")
        consulta.Append("                   ON  vsug.nStbBarrioID = sc.nStbBarrioID")
        consulta.Append("               INNER JOIN StbValorCatalogo svc")
        consulta.Append("                   ON  svc.nStbValorCatalogoID = sac.nStbEstadoArqueoID")
        consulta.Append("       WHERE  svc.sCodigoInterno IN ('1', '2')")
        consulta.Append(String.Format("               AND smd.sNumeroDeposito in ({0}) ", ObtenerNumeroDocumentos()))
        consulta.Append("       ) AS A ")
        consulta.Append("ORDER BY ")
        consulta.Append("       CajaManagua DESC,")
        consulta.Append("       sDescripcionCaja")
        Return consulta.ToString()
    End Function

    Private Function ObtenerMontoMinutasSinAsignar() As Double
        Dim monto As Double = 0.0
        Dim data As Data.DataTable = CType(DataGridView1.DataSource, Data.DataTable)
        For Each minuta As String In lDocumentosNoAsignados
            For Each row As Data.DataRow In data.Select(String.Format("Documento = {0}", minuta))

                monto += IIf(IsDBNull(row("Monto")), 0, row("Monto"))
            Next
        Next
        Return monto
    End Function

    Private Function ListaMinutasSinAsignar() As String
        Dim lista As String = String.Empty
        Dim contador As Int16 = 0
        For Each documento As String In lDocumentosNoAsignados
            contador += 1
            lista += String.Format("{0}{1}", documento, IIf(contador = lDocumentosNoAsignados.Count, "", ","))
        Next
        Return lista
    End Function

    Private Sub frmSteEstadoCuentaDiario_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not objDataSet Is Nothing Then
            objDataSet = Nothing
        End If
        If Not xData Is Nothing Then
            xData.Close()
            xData = Nothing
        End If
        If Not dtresult Is Nothing Then
            dtresult = Nothing
        End If
        If Not lDocumentosNoAsignados Is Nothing Then
            lDocumentosNoAsignados = Nothing
        End If
        If Not m_Excel Is Nothing Then

            m_Excel.Quit()

            m_Excel = Nothing

        End If

    End Sub
End Class