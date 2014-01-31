Public Class FRM_Baugruppenmeister

    Event RefreshBGTable()
    Event Table_changed()

    Private Sub BTN_Refresh_Click(sender As Object, e As EventArgs) Handles BTN_Refresh.Click
        RaiseEvent RefreshBGTable()
    End Sub


    Private Sub BTN_Changed_Click(sender As Object, e As EventArgs) Handles BTN_Changed.Click
        RaiseEvent Table_changed()
    End Sub

    
End Class