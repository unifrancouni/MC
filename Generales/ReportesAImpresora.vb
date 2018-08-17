Public Class ReportesAImpresora

    Dim _id As Integer
    Dim _imprimir As Boolean
    Dim _nombre As String
    Dim _cantidadCopias As Integer
    Dim _intercalar As Boolean
    Dim _impresoras As New List(Of String)


    Public Sub New(ByVal id As Integer, ByVal imprimir As Boolean, ByVal nombre As String, ByVal cantidadCopias As Integer, ByVal intercalar As Boolean)
        Me._id = id
        Me._imprimir = imprimir
        Me._nombre = nombre
        Me._cantidadCopias = cantidadCopias
        Me._intercalar = intercalar
    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Imprimir() As Boolean
        Get
            Return _imprimir
        End Get
        Set(ByVal value As Boolean)
            _imprimir = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property CantidadCopias() As Integer
        Get
            Return _cantidadCopias
        End Get
        Set(ByVal value As Integer)
            _cantidadCopias = value
        End Set
    End Property

    Public Property Intercalar() As Boolean
        Get
            Return _intercalar
        End Get
        Set(ByVal value As Boolean)
            _intercalar = value
        End Set
    End Property


End Class
