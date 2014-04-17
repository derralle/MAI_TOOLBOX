Public Class Form_Traegheit

    Event Uebertragen()

    Private Sub Button_Uebertragen_Click(sender As Object, e As EventArgs) Handles Button_Uebertragen.Click
        RaiseEvent Uebertragen()

    End Sub
End Class