Imports System.Collections.Generic

Public Class FRM_EXPORTLIST

    Private Mausetastegedr As Boolean = False


    Private _dateiliste As ArrayList
    Public Property dateiliste As ArrayList
        Get
            Return _dateiliste
        End Get
        Set(ByVal value As ArrayList)
            _dateiliste = value
            RaiseEvent E_set_dateiliste(Me, EventArgs.Empty)

        End Set
    End Property

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        LB_FILES.DataSource = dateiliste
    End Sub



    Public Event E_listeloeschen As EventHandler

    Public Event E_elementloeschen As EventHandler
  
    Public Event E_set_dateiliste As EventHandler

    Protected Overridable Sub OnE_set_dateiliste()
        RaiseEvent E_set_dateiliste(Me, EventArgs.Empty)
    End Sub

   



    Private Sub Liste_Aufbauen() Handles Me.E_set_dateiliste

        LB_FILES.Items.Clear()
        For Each item As String In Me.dateiliste

            LB_FILES.Items.Add(item.Substring(item.LastIndexOf("\") + 1))

        Next

    End Sub


    Private Sub BT_ZeileLoeschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ZeileLoeschen.Click
        LB_FILES.Refresh()
    End Sub


    Private Sub BT_ListeLoeschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ListeLoeschen.Click
        RaiseEvent E_listeloeschen(Me, EventArgs.Empty)

    End Sub

    Private Sub FRM_EXPORTLIST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
    End Sub



    ' Drag and drop

    '   Private Sub LB_FILES_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LB_FILES.MouseDown
    '      Mausetastegedr = True
    ' End Sub

    'Private Sub LB_FILES_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LB_FILES.MouseMove

    'If Mausetastegedr Then
    'Dim items() As String = Nothing
    'Dim i As Long = Me.dateiliste.Count
    '       For index = 0 To i - 1
    '
    '           items(index) = dateiliste.Item(index)

    '        Next
    '       Me.DoDragDrop(items, Windows.Forms.DragDropEffects.Copy)
    '
    '   End If
    '  Mausetastegedr = False
    'End Sub
End Class