Imports System.IO

Public Class frmStbFirmaEmpleado

    'Variables
    Dim XDatos As New BOSistema.Win.XComando
    Private sCodigoEmpleadoValue As String
    Private sRutaImegenFirma As String
    Private sDirectoryFirmas As String
    Public Enum Operacion
        VIEW = 0
        ADD = 1
        UPD = 2
    End Enum
    Private _Accion As Operacion = Operacion.VIEW

    'Propiedades 
    Public Property CodigoEmpleado() As String
        Get
            Return sCodigoEmpleadoValue
        End Get
        Set(ByVal value As String)
            sCodigoEmpleadoValue = value
        End Set
    End Property

    Private Property RutaImegenFirma() As String
        Get
            Return sRutaImegenFirma
        End Get
        Set(ByVal value As String)
            sRutaImegenFirma = value
        End Set
    End Property

    Private Property DirectoryFirmas() As String
        Get
            Return sDirectoryFirmas
        End Get
        Set(ByVal value As String)
            sDirectoryFirmas = value
        End Set
    End Property

    Public Property Accion() As Operacion
        Get
            Return _Accion
        End Get
        Set(ByVal value As Operacion)
            _Accion = value
        End Set
    End Property


    'Métodos
    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                02 de Marzo 2012
    ' Procedure Name:       EliminarArchivo
    ' Descripción:          Este procedimiento permite Eliminar la firma de un empleado
    '-------------------------------------------------------------------------
    Private Sub EliminarArchivo()
        Dim Destination As String = Me.DirectoryFirmas & Me.stxtRutaFirma.Text & ".jpg"
        System.IO.File.Delete(Destination)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                02 de Marzo 2012
    ' Procedure Name:       CopiarArchivo
    ' Descripción:          Este procedimiento copiar el archivo de imagen de la firma
    '-------------------------------------------------------------------------
    Private Sub CopiarArchivo()
        Dim Destination As String = Me.DirectoryFirmas & Me.stxtRutaFirma.Text & ".jpg"
        System.IO.File.Copy(Me.RutaImegenFirma, Destination, True)
    End Sub

    Private Sub Seguridad()
        Dim bEnabled As Boolean
        Seg.RefreshPermissions()
        Select Case Accion
            Case Operacion.ADD
                If Seg.HasPermission("AgregarFirma") Then
                    Me.btnAceptar.Enabled = True
                Else
                    Me.btnAceptar.Enabled = False
                End If
            Case Operacion.UPD

                bEnabled = Seg.HasPermission("ActualizarFirma")

                Me.btnAceptar.Enabled = bEnabled
                Me.btnBuscarFirma.Enabled = bEnabled

            Case Operacion.VIEW
                Me.btnAceptar.Enabled = False
        End Select
    End Sub

    ''Eventos
    Private Sub btnBuscarFirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFirma.Click
        If Me.OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.RutaImegenFirma = Me.OpenFileDialog.SafeFileName
            Me.stxtRutaFirma.Text = "F" & Me.CodigoEmpleado
            Me.PictureBox.ImageLocation = Me.RutaImegenFirma
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If String.IsNullOrEmpty(Me.stxtRutaFirma.Text) Then
                MessageBox.Show("No ha seleccionado una firma", "SMUSURA0 - [Imagen de Firma]", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim sCodigoFirma As String = Me.DirectoryFirmas & Me.stxtRutaFirma.Text & ".jpg"
                If System.IO.File.Exists(sCodigoFirma) Then
                    If MessageBox.Show("Ya existe una Firma asociado a este empleado" & Chr(13) _
                                    & "¿Desea reemplazar la firma?", "SMUSURA0 - [Imagen de Firma]", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Me.EliminarArchivo()
                        Me.CopiarArchivo()
                    End If
                Else
                    Me.CopiarArchivo()
                End If
                MessageBox.Show("Imagen de Firma " & IIf(Me.Accion = Operacion.ADD, "Agregada", "Actualizada") & " Satisfactoriamente.", "SMUSURA0 - [Imagen de Firma]", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al tratar de guardar la firma: " & ex.Message, "SMUSURA0 - [Imagen de Firma]", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmStbFirmaEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Inicializamos 
        Dim sSQLString As String

        If Me.CodigoEmpleado = Nothing Then
            MessageBox.Show("Se necesita el código del Empleado", "SMUSURA0 - [Imagen de Firma]", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End If

        Dim ObjGUI As New GUI.ClsGUI
        ObjGUI.AppPath = Application.StartupPath
        ObjGUI.SetFormLayout(Me, "Morado")
        Me.Text = "SMUSURA0 - [Imagen de Firma]"

        Try
            'Verificar si existe una firma para este empleado
            sSQLString = "select sValorParametro from StbValorParametro where nstbparametroID=38"

            Dim sDirectorio As String = XDatos.ExecuteScalar(sSQLString)

            Me.DirectoryFirmas = sDirectorio & IIf(sDirectorio.EndsWith("\"), "", "\")

            Dim sCodigoFirma As String = "F" & Me.CodigoEmpleado

            Dim sRutaFirma As String = Me.DirectoryFirmas & sCodigoFirma & ".jpg"

            If System.IO.File.Exists(sRutaFirma) Then
                'De encontrarse la firma se setean los controles
                Me.stxtRutaFirma.Text = sCodigoFirma
                Me.PictureBox.ImageLocation = Me.DirectoryFirmas & sCodigoFirma & ".jpg"
                Me.Accion = Operacion.UPD
                Me.btnAceptar.Text = "Actualizar"
            Else
                Me.stxtRutaFirma.Text = String.Empty
                Me.PictureBox.ImageLocation = Nothing
                Me.Accion = Operacion.ADD
                Me.btnAceptar.Text = "Agregar"
            End If

            'Aplicar seguridad
            Me.Seguridad()

        Catch ex As Exception

        Finally
            XDatos.Close()
            XDatos = Nothing
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class