Public Class FRM_Baugruppenmeister

    Event RefreshBGTable()
    Event Table_changed()
    Event Datei_Oeffnen(ByVal Path As String)

    Private DGVlocation As Windows.Forms.DataGridViewCellEventArgs


    Private Sub BTN_Refresh_Click(sender As Object, e As EventArgs) Handles BTN_Refresh.Click
        RaiseEvent RefreshBGTable()
    End Sub


    Private Sub BTN_Changed_Click(sender As Object, e As EventArgs) Handles BTN_Changed.Click
        RaiseEvent Table_changed()
    End Sub


    
    Private Sub TSMI_oeffnen_Click(sender As Object, e As EventArgs) Handles TSMI_oeffnen.Click
        

    End Sub

    

    '' Deal with hovering over a cell.
    'Private Sub dataGridView_CellMouseEnter(ByVal sender As Object, _
    '    ByVal location As DataGridViewCellEventArgs) _
    '    Handles DataGridView.CellMouseEnter

    '    mouseLocation = location
    'End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        DGVlocation = e
    End Sub

    Private Sub DGV_CTMS1_Opened(sender As Object, e As EventArgs) Handles DGV_CTMS1.Opened
        Dim row As Windows.Forms.DataGridViewRow

        Dim dgvrow As BG_Dataset.BaugruppeRow
        row = DataGridView1.Rows(DGVlocation.RowIndex)


        If TypeOf row.DataBoundItem.row Is BG_Dataset.BaugruppeRow Then

            dgvrow = row.DataBoundItem.row

            TSMI_oeffnen.Text = "öffnen von " & dgvrow.Pfad.ToString
            DGV_CTMS1.

        End If
    End Sub
End Class