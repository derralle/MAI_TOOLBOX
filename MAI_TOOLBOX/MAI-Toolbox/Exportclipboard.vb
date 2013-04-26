Public Class Exportclipboard
    Public Sub New()

    End Sub
    Dim _getfilelist() As String
    Public Property getfilelist() As String
        Get
            Return _getfilelist
        End Get
        Set(ByVal value As String())
            _getfilelist = value
        End Set
    End Property


End Class
