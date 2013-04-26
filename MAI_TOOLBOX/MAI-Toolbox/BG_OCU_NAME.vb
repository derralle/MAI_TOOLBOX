Public Class BG_OCU_NAME

    Private _newname As String
    Property newname As String
        Get
            Return _newname
        End Get
        Set(ByVal value As String)
            _newname = value
        End Set
    End Property



    Sub New(ByRef newname As String)
        InitializeComponent()
        ' TODO: Complete member initialization 
        Me.newname = newname
    End Sub



    Private Sub BTN_EXEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EXEC.Click
        If TB_NAME.Text <> "" Then
            Me._newname = TB_NAME.Text
            Me.Close()
        End If
    End Sub

    Private Sub BTN_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EXIT.Click
        Me.Close()
    End Sub

End Class