Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst


Public Class exporttools
    ' maitools Klasse anbinden wg. SpeichernUnter
    Private maitools As New MAITOOLS(Me.iSwApp)

    ' Form Laden
    Private WithEvents ExportForm As New FRM_EXPORTLIST


    ''' <summary>
    ''' Abbildung aller Dateien im Tempverzeichniss als Liste
    ''' </summary>
    ''' <remarks></remarks>
    Private _Dateinamen As New ArrayList
    Private Property Dateinamen As ArrayList
        Get
            Return _Dateinamen
        End Get
        Set(ByVal value As ArrayList)
            _Dateinamen = value
        End Set
    End Property


    ''' <summary>
    ''' Position des Tempverzeichnisses
    ''' </summary>
    ''' <remarks></remarks>
    Private _TempVerz As String
    Public ReadOnly Property TempVerz As String
        Get
            Return _TempVerz
        End Get
    End Property

    ''' <summary>
    ''' SwApp als Eigenschaft
    ''' </summary>
    ''' <remarks></remarks>
    Private _iSwApp As SldWorks
    Private Property iSwApp As SldWorks
        Get
            Return _iSwApp
        End Get
        Set(ByVal value As SldWorks)
            _iSwApp = value
        End Set
    End Property

    ''' <summary>
    ''' Initialisierungsfunktion:
    ''' SwApp wird eingebunden und das Tempverzeichiss wird angelegt
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        _TempVerz = Me.MkTempVerz()

    End Sub

    ''' <summary>
    '''  Das Aktuelle Dokument als ".Endung" in das Quellverzeichniss speichern
    ''' </summary>
    ''' 
    ''' <remarks></remarks>
    Public Sub AktDokAnf(ByRef iswapp As SldWorks, ByRef extention As String)
        Dim doc As ModelDoc2
        Dim path As String


        Me.iSwApp = iswapp

        doc = Me.iSwApp.ActiveDoc

        path = doc.GetPathName()

        path = IO.Path.ChangeExtension(path, extention)

        maitools.SpeichernUnter(doc, path)

        Checkin(path)



        If ExportForm.IsDisposed Then

            ExportForm = New FRM_EXPORTLIST
            Refreshlist()
            ExportForm.Show()
        Else
            Refreshlist()
            ExportForm.Show()
        End If

    End Sub

    ''' <summary>
    ''' Tempverzeichniss anlegen
    ''' </summary>
    ''' <returns> Pfad des Tempverzeichnisses </returns>
    ''' <remarks></remarks>
    Private Function MkTempVerz() As String
        Dim MyGuid As String
        Dim Path As String

        MyGuid = "MAITB_" & System.Guid.NewGuid().ToString() & "__" & DateString

        Path = IO.Path.GetTempPath & MyGuid

        Path = Path
        IO.Directory.CreateDirectory(Path)


        Return Path

    End Function

    ''' <summary>
    ''' Dokument in "Pfad" in das Tempverzeichiss verschieben und einen Refresh der Liste anstoßen
    ''' </summary>
    ''' <param name="path"> Quellpfad des Dokumentes</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Checkin(ByVal path As String) As Integer
        Dim destpath As String

        ' Zielpfad zusammenbauen
        destpath = Me.TempVerz & "\" & IO.Path.GetFileName(path)

        ' Datei verschieben


        If IO.File.Exists(destpath) = False Then
            IO.File.Move(path, destpath)
        End If


        'Liste aktualisieren
        Refreshlist()

        Return 1
    End Function

    Private Sub Refreshlist()

        Me.Dateinamen.Clear()
        For Each file In FileIO.FileSystem.GetFiles(Me.TempVerz)
            Me.Dateinamen.Add(file)
        Next

        ExportForm.dateiliste = Me.Dateinamen
        ExportForm.LB_FILES.Refresh()


    End Sub

    Private Sub Deletelist() Handles ExportForm.E_listeloeschen
        For Each file In FileIO.FileSystem.GetFiles(Me.TempVerz)
            FileIO.FileSystem.DeleteFile(file)
        Next
        Refreshlist()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        IO.Directory.Delete(Me.TempVerz, True)

    End Sub
End Class
