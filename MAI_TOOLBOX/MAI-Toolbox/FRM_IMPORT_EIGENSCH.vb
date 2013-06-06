Public Class FRM_IMPORT_EIGENSCH

    ''' <summary>
    ''' Liste aller Eigenschaften zur Auswahl mittels Combobox
    ''' </summary>
    ''' <remarks></remarks>
    Private _eigenschaftsliste As New ArrayList
    ''' <summary>
    ''' Liste aller Eigenschaften zur Auswahl mittels Combobox
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property eigenschaftsliste As ArrayList
        Get
            Return _eigenschaftsliste
        End Get
        Set(ByVal value As ArrayList)
            _eigenschaftsliste = value
        End Set
    End Property

    Private _bezeichnung As String
    ''' <summary>
    ''' Bezeichung als String
    ''' </summary>
    ''' <value></value>
    ''' <returns> Eigentragene Bezeichung als String </returns>
    ''' <remarks></remarks>
    Public Property bezeichung As String
        Get
            Return _bezeichnung
        End Get
        Set(ByVal value As String)
            _bezeichnung = value
            CB_Bezeichnung.Text = _bezeichnung
        End Set
    End Property

    Private _bestellnummer As String
    ''' <summary>
    ''' Bestellnummer als String
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property bestellnummer As String
        Get
            Return _bestellnummer
        End Get
        Set(ByVal value As String)
            _bestellnummer = value
            CB_Bestellnummer.Text = _bestellnummer
        End Set
    End Property

    Private _hersteller As String
    ''' <summary>
    ''' Hersteller als String 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property hersteller As String
        Get
            Return _hersteller
        End Get
        Set(ByVal value As String)
            _hersteller = value
            CB_Hersteller.Text = _hersteller
        End Set
    End Property

    Private _istbaugruppe As Boolean
    Public Property istbaupruppe As Boolean
        Get
            Return _istbaugruppe
        End Get
        Set(ByVal value As Boolean)
            _istbaugruppe = value
        End Set
    End Property

    Private _info As String
    ''' <summary>
    ''' Benutzerinformation z.B Konfigurierte Hersteller
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property info As String
        Get
            Return _info
        End Get
        Set(ByVal value As String)
            _info = value
        End Set
    End Property


    Private CancelValue As Boolean
    Public Property Cancel() As Boolean
        Get
            Return CancelValue
        End Get
        Set(ByVal value As Boolean)
            CancelValue = value
        End Set
    End Property


    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.Cancel = True



    End Sub


    Private Sub uebernehmen()
        Me.bezeichung = Me.CB_Bezeichnung.Text
        Me.bestellnummer = Me.CB_Bestellnummer.Text
        Me.hersteller = Me.CB_Hersteller.Text
        Me.Cancel = False
        Me.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        uebernehmen()
    End Sub

    Private Sub FRM_IMPORT_EIGENSCH_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.CB_Bestellnummer.Items.AddRange(Me.eigenschaftsliste.ToArray)
        Me.CB_Bezeichnung.Items.AddRange(Me.eigenschaftsliste.ToArray)
        Me.CB_Hersteller.Items.AddRange(Me.eigenschaftsliste.ToArray)
        Me.LBL_Info.Text = Me.info

    End Sub

    'Abbrechen
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.CancelValue = True
        Me.Close()
    End Sub


    
End Class