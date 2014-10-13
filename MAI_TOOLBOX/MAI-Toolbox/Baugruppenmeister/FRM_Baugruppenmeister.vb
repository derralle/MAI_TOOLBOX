Imports System.Windows.Forms

Public Class FRM_Baugruppenmeister


    Event RefreshBGTable()
    Event Table_changed()
    Event Datei_Oeffnen(ByVal Path As String)
    Event BGNr_changed(ByVal BGNr As MAI_Teilenummer)
    Event Mehrfeldbearbeitung()
    Event EigenschaftenEinlesen()

    Private DGVlocation As Windows.Forms.DataGridViewCellEventArgs

    Private getchangesValue As Boolean = False
    Public Property getchanges() As Boolean
        Get
            Return getchangesValue
        End Get
        Set(ByVal value As Boolean)
            getchangesValue = value
        End Set
    End Property




    Private Sub BTN_Refresh_Click(sender As Object, e As EventArgs) Handles BTN_Refresh.Click
        RaiseEvent RefreshBGTable()
    End Sub

    Private Sub BTN_Changed_Click(sender As Object, e As EventArgs) Handles BTN_Changed.Click
        RaiseEvent Table_changed()
    End Sub

    Private Sub TSMI_oeffnen_Click(sender As Object, e As EventArgs) Handles TSMI_oeffnen.Click
        Dim row As Windows.Forms.DataGridViewRow

        Dim dgvrow As BG_Dataset.BaugruppeRow
        row = DataGridView1.Rows(DGVlocation.RowIndex)


        If TypeOf row.DataBoundItem.row Is BG_Dataset.BaugruppeRow Then

            dgvrow = row.DataBoundItem.row

        End If


        RaiseEvent Datei_Oeffnen(dgvrow.Pfad)

    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        DGVlocation = e
        'Debug.Print("Cell enter: " & DGVlocation.ColumnIndex & ";" & DGVlocation.RowIndex)
    End Sub


    'Kontextmenu Dateinamen anzeigen
    Private Sub TSMI_oeffnen_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles TSMI_oeffnen.Paint
        Dim row As Windows.Forms.DataGridViewRow

        Dim dgvrow As BG_Dataset.BaugruppeRow
        row = DataGridView1.Rows(DGVlocation.RowIndex)


        If TypeOf row.DataBoundItem.row Is BG_Dataset.BaugruppeRow Then

            dgvrow = row.DataBoundItem.row

            sender.text = "öffnen von >" & dgvrow.Dateiname & "<"
        End If

    End Sub


    




    Private Sub CB_HBG_einbeziehen_CheckedChanged(sender As Object, e As EventArgs) Handles CB_HBG_einbeziehen.CheckedChanged
        RaiseEvent RefreshBGTable()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim BgNr As MAI_Teilenummer = TextBox_Baugruppennummer.Text
        If BgNr.Gueltig Then
            RaiseEvent BGNr_changed(BgNr)
        End If

    End Sub




    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.DoubleBuffered = True

    End Sub



    Private Sub TSMI_mehrere_Click(sender As Object, e As EventArgs) Handles TSMI_mehrere.Click

        RaiseEvent Mehrfeldbearbeitung()

    End Sub

    Private Sub DGV_CTMS1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGV_CTMS1.Opening

    End Sub

    Private Sub BtnEigenschaftenEinlesen_Click(sender As Object, e As EventArgs) Handles BtnEigenschaftenEinlesen.Click
        RaiseEvent EigenschaftenEinlesen()
    End Sub
End Class