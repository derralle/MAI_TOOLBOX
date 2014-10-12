Public Class mehrere_Felder_ändern


    Private _ReturnValue As String = ""
    Public Property ReturnValue() As String
        Get
            Return _ReturnValue
        End Get
        Set(ByVal value As String)
            _ReturnValue = value
        End Set
    End Property



    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        Me.ReturnValue = EingabeTextBox.Text
        Me.Close()

    End Sub
End Class