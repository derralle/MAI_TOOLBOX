Imports System.Collections.Generic

Public Class FRM_Zylinderkonfig

    Private _huebe As New List(Of Double)

    Public Property huebe() As List(Of Double)
        Get
            Return _huebe
        End Get
        Set(ByVal value As List(Of Double))
            _huebe = value
        End Set
    End Property

    Private absValue As Double
    Public Property abs() As Double
        Get
            Return absValue
        End Get
        Set(ByVal value As Double)
            absValue = value
        End Set
    End Property

    Private AbortValue As Boolean
    Public Property Abort() As Boolean
        Get
            Return AbortValue
        End Get
        Set(ByVal value As Boolean)
            AbortValue = value
        End Set
    End Property


    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.LBL_abs.Text = "Abstand: " & abs * 1000
        Me.TB_Hubein.Text = 0

        Me.Abort = True

    End Sub

    Private Sub BTN_Abort_Click(sender As Object, e As EventArgs) Handles BTN_Abort.Click

        Me.Abort = True
        Me.Close()

    End Sub

    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click

        Me.huebe.Add((TB_Hubein.Text / 1000) + Me.abs)

        Me.huebe.Add((TB_Hubaus.Text / 1000) + Me.abs)

        Me.Abort = False

        Me.Close()




    End Sub


    Private Sub TB_Hubges_ModifiedChanged(sender As Object, e As EventArgs) Handles TB_Hubges.ModifiedChanged
        Dim text As String
        text = TB_Hubges.Text

        TB_Hubaus.Text = text
        TB_Hubges.Modified = False
    End Sub
End Class