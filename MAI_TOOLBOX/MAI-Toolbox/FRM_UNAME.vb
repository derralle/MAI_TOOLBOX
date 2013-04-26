Public Class FRM_UNAME


    Sub New(ByRef component_name As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.component_name = component_name
        TB_NAME.Text = component_name
        Label1.Text = TB_NAME.TextLength & " Zeichen"



    End Sub

    Private _mit_Zeichnung As Boolean
    Friend Property mit_Zeichnung As Boolean
        Get
            Return _mit_Zeichnung
        End Get
        Set(ByVal value As Boolean)
            _mit_Zeichnung = value
        End Set
    End Property


    Private _component_name As String
    Friend Property component_name As String
        Get
            Return _component_name
        End Get
        Set(ByVal value As String)
            _component_name = value
        End Set
    End Property


    Private Sub BTN_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EXIT.Click
        Me.Close()
    End Sub


    Private Sub TB_NAME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_NAME.KeyPress

        Dim intBS As Integer = Asc(e.KeyChar)

        If intBS = 13 Then
            Me.component_name = TB_NAME.Text
            Me.mit_Zeichnung = CB_Zeichnung.Checked
            Me.Close()
        End If



    End Sub



    Private Sub BTN_EXEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EXEC.Click
        Me.component_name = TB_NAME.Text
        Me.mit_Zeichnung = CB_Zeichnung.Checked
        Me.Close()
    End Sub

    Private Sub TB_NAME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_NAME.TextChanged

        Label1.Text = TB_NAME.TextLength & " Zeichen"

    End Sub
End Class