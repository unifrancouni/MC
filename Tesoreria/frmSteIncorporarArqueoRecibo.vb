Public Class frmSteIncorporarArqueoRecibo

    '-- Declaracion de Variables 
    Private nCodigoArqueo As Integer
    Private nCodigoRecibo As Integer
    Private dFechaRecibo As DateTime
    Private intArqueoID As Integer
    Private nSrhCajeroEmpleadoID As Integer
    Private nSteCajaID As Integer

    '-- Declaracion de Propiedades
    Public Property CodigoRecibo()
        Get
            Return nCodigoRecibo
        End Get
        Set(ByVal value)
            nCodigoRecibo = value
        End Set
    End Property
    Public Property CodigoArqueo() As Integer
        Get
            Return nCodigoArqueo
        End Get
        Set(ByVal value As Integer)
            nCodigoArqueo = value
        End Set
    End Property
    Public Property FechaRecibo() As DateTime
        Get
            Return dFechaRecibo
        End Get
        Set(ByVal value As DateTime)
            dFechaRecibo = value
        End Set
    End Property
    Public Property ArqueoID() As Integer
        Get
            Return intArqueoID
        End Get
        Set(ByVal value As Integer)
            intArqueoID = value
        End Set
    End Property

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim XCmArqueRecibo As New BOSistema.Win.XComando
        Try

            XCmArqueRecibo = New BOSistema.Win.XComando

            If Validar() Then
                Dim strProcedure As String = String.Format("exec spSteIncorporarArqueoRecibo " & Me.CodigoArqueo & "," & Me.txtCodigoRecibo.Text & "," & "'" & Format(Me.FechaRecibo, "MM/dd/yyyy")) & "'"
                XCmArqueRecibo.ExecuteNonQuery(strProcedure)
                MsgBox("Recibo incorporado satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Me.Close()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

        XCmArqueRecibo.Close()
        XCmArqueRecibo = Nothing

    End Sub

    Function Validar() As Boolean

        Dim XCommand As New BOSistema.Win.XComando
        Dim XdsQuery As New BOSistema.Win.XDataSet.xDataTable

        Try
            If String.IsNullOrEmpty(Me.txtCodigoRecibo.Text) Then
                MsgBox("Digite el código del recibo.", MsgBoxStyle.Critical, NombreSistema)
                Validar = False
                Me.errorCodigoRecibo.SetError(Me.txtCodigoRecibo, "Ingrese un código de recibo válido.")
                Me.txtCodigoRecibo.Focus()
                Exit Function

            End If

            Dim strVal As String = "SELECT 1 " & _
                                   "FROM SteArqueoRecibo sar " & _
                                   "     INNER JOIN SteArqueoCaja sac " & _
                                   "     ON sac.nSteArqueoCajaID = sar.nSteArqueoCajaID " & _
                                   "     INNER JOIN StbValorCatalogo svc " & _
                                   "     ON svc.nStbValorCatalogoID = sac.nStbEstadoArqueoID " & _
                                   "WHERE(sar.nCodigo = " + Me.txtCodigoRecibo.Text + ") " & _
                                   "   AND " & _
                                   "   ( svc.sCodigoInterno <> '3' " & _
                                   "     AND svc.sCodigoInterno <> '4' " & _
                                   "   ) " & _
                                   "   AND sac.nCodigo = " & Me.CodigoArqueo

            '-- validar que el recibo no este incluido en el arqueo actual
            Dim resultado = XCommand.ExecuteScalar(strVal)
            If Not resultado Is Nothing And resultado = 1 Then
                MsgBox("El recibo ya se encuentra incluido.", MsgBoxStyle.Critical, NombreSistema)
                Validar = False
                Me.errorCodigoRecibo.SetError(Me.txtCodigoRecibo, "Ingrese un código de recibo válido.")
                Me.txtCodigoRecibo.Focus()
                Exit Function
            End If
            '-- validar que el recibo no este agregado a otro arqueo para la misma caja
            strVal = " SELECT  " & _
                     "		 nSteCajaID, " & _
                     "		 nSrhCajeroId " & _
                     " FROM   SteArqueoCaja sac " & _
                     " WHERE  nSteArqueoCajaID = " & Me.intArqueoID

            XdsQuery.ExecuteSql(strVal)

            Me.nSrhCajeroEmpleadoID = XdsQuery.ValueField("nSrhCajeroId")
            Me.nSteCajaID = XdsQuery.ValueField("nSteCajaID")

            strVal = "SELECT sroc.*  " & _
                    " FROM SccReciboOficialCaja sroc  " & _
                    "      INNER JOIN ( " & _
                    "            SELECT sac.nSteArqueoCajaID,  " & _
                    "                   sar.nCodigo  " & _
                    "            FROM   SteArqueoRecibo sar  " & _
                    "                   INNER JOIN SteArqueoCaja sac  " & _
                    "                        ON  sac.nSteArqueoCajaID = sar.nSteArqueoCajaID  " & _
                    "            WHERE  sar.nCodigo = " & Me.txtCodigoRecibo.Text & _
                    "                   AND sac.nSteCajaID = " & Me.nSteCajaID & _
                    "      ) sar " & _
                    "      ON  sroc.nCodigo = sar.nCodigo " & _
                    "      INNER JOIN StbValorCatalogo svc " & _
                    "      ON svc.nStbValorCatalogoID = sroc.nStbEstadoReciboID " & _
                    " WHERE sroc.nCodigo = " & Me.txtCodigoRecibo.Text & _
                    "       AND sroc.nSteCajaID = " & Me.nSteCajaID & _
                    "       AND sroc.nSrhEmpleadoCajeroID = " & Me.nSrhCajeroEmpleadoID & " " & _
                    "       AND svc.sCodigoInterno <> '3' " & _
                    "       AND sar.nSteArqueoCajaID <> " & Me.intArqueoID

            XdsQuery.ExecuteSql(strVal)

            If XdsQuery.Count > 0 Then
                MsgBox("El recibo ya se encuentra incluido en otro arqueo.", MsgBoxStyle.Critical, NombreSistema)
                Validar = False
                Me.errorCodigoRecibo.SetError(Me.txtCodigoRecibo, "Ingrese un código de recibo único para el arqueo.")
                Me.txtCodigoRecibo.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XCommand.Close()
            XCommand = Nothing
            XdsQuery.Close()
            XdsQuery = Nothing
        End Try

        Validar = True

    End Function

    Private Sub frmSteIncorporarArqueoRecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")
            Me.txtCodigoRecibo.Focus()
            Me.txtCodigoRecibo.Select()
            Me.Text = "Incorporar recibo"

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtCodigoRecibo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoRecibo.KeyPress
        If ModSMUSURA0.Numeros(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Class