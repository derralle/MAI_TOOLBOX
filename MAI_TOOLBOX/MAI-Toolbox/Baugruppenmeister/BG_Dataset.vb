Partial Class BG_Dataset
    Partial Class BaugruppeDataTable

        Private Sub BaugruppeDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DataColumn1Column.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

End Class
