Public Class Frm_Eigensch

    Private _propname As String
    Public Property propname As String
        Get
            Return _propname
        End Get
        Set(ByVal value As String)
            _propname = value
            TB_Name.Text = value
        End Set
    End Property


    Private _teilenummer As String
    Public Property teilenummer As String
        Get
            Return _teilenummer
        End Get
        Set(ByVal value As String)
            _teilenummer = value
            TB_Tnr.Text = value
        End Set
    End Property


    Private _exitstat As Boolean = False
    Public Property exitstat As Boolean
        Get
            Return _exitstat
        End Get
        Set(ByVal value As Boolean)
            _exitstat = value
        End Set
    End Property


    Private _Position As String
    Public Property Position() As String
        Get
            Return _Position
        End Get
        Set(ByVal value As String)
            _Position = value
            LBL_Pos.Text = "Position: " & value
        End Set
    End Property

    ''' <summary>
    ''' Teilenummer entspricht der Norm
    ''' </summary>
    ''' <remarks></remarks>
    Private _NormTNR As Boolean
    Public Property NormTNR() As Boolean
        Get
            Return _NormTNR
        End Get
        Set(ByVal value As Boolean)
            _NormTNR = value
            If _NormTNR = False Then
                LBL_Warn.Text = "Teilenummer entpricht nicht der Norm, dass ist nicht schön!"
            End If
        End Set
    End Property



    Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.



    End Sub

    Private Sub Btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exit.Click
        Me.exitstat = False
        Me.Close()
    End Sub

    Private Sub Btn_Exec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exec.Click
        Me.exitstat = True
        Me.teilenummer = TB_Tnr.Text
        Me.propname = TB_Name.Text
        Me.Close()
    End Sub

    
End Class