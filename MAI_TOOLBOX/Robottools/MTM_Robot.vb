Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic



Public Class MTM_Robot

#Region "Eigenschaften"

    'Solidworks Objekt
    Private WithEvents _SwApp As ISldWorks
    Public Property SwApp() As ISldWorks
        Get
            Return _SwApp
        End Get
        Set(ByVal value As ISldWorks)
            _SwApp = value
        End Set
    End Property


    Private WithEvents _SelMgr As ISelectionMgr
    Public Property SelMgr() As ISelectionMgr
        Get
            Return _SelMgr
        End Get
        Set(ByVal value As ISelectionMgr)
            _SelMgr = value
        End Set
    End Property



    Private _Modeldoc As IModelDoc2
    Public Property ModelDoc As IModelDoc2
        Get
            Return _Modeldoc
        End Get
        Set(ByVal value As IModelDoc2)
            _Modeldoc = value
        End Set
    End Property

    Private WithEvents _AssemblyDoc As AssemblyDoc
    Public Property AssemblyDoc() As AssemblyDoc
        Get
            Return _AssemblyDoc
        End Get
        Set(ByVal value As AssemblyDoc)
            _AssemblyDoc = value
        End Set
    End Property

    Private _Koordinatensystem As CoordinateSystemFeatureData
    Public Property Koordinatensystem() As CoordinateSystemFeatureData
        Get
            Return _Koordinatensystem
        End Get
        Set(ByVal value As CoordinateSystemFeatureData)
            _Koordinatensystem = value
        End Set
    End Property


    'Text der später zur Anzeige und für die Zeichnung erzeugt wird
    Private _Ausgabetext As String
    Private Property Ausgabetext As String
        Get
            Return _Ausgabetext
        End Get
        Set(value As String)
            _Ausgabetext = value
        End Set
    End Property

    'Form initialisieren
    Dim WithEvents TraegheitsForm As New Form_Traegheit


#End Region

#Region "Events"


    'mit SWX Events verbinden
    Sub AttachSWEvents()
        Try
            AddHandler _AssemblyDoc.NewSelectionNotify, AddressOf Selection_Change
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub

    'von SWX Events trennen
    Sub DettachSWEvents()
        Try
            RemoveHandler _AssemblyDoc.NewSelectionNotify, AddressOf Selection_Change
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub


    'Wird Ausgerufen wenn etwas in SWX selektiert wird
    Private Function Selection_Change() As Integer Handles _AssemblyDoc.NewSelectionNotify
        'Feature-Objekt 
        Dim OFeature As Feature

        'Koordinatenselektierung ausfiltern
        If SelMgr.GetSelectedObjectType3(1, -1) = swSelectType_e.swSelCOORDSYS Then

            'Ausgabetext rücksetzen (sonst wird er immer länger)
            Ausgabetext = ""

            'Feature des selektierten Objektes erfassen
            OFeature = SelMgr.GetSelectedObject6(1, -1)

            'Koordinatensystem aus Feature erzeugen
            Koordinatensystem = OFeature.GetDefinition

            'Name des Koordinatensystems auf Form anzeigen
            TraegheitsForm.Label_Select.Text = OFeature.Name

            'Hintergrundfarbe des Select_Labels ändern
            TraegheitsForm.Label_Select.BackColor = Drawing.Color.LightGreen

            'Trägheitsmomente auslesen
            Traegheit()

        End If
    End Function




#End Region






    Public Sub New(ByVal SwApp As ISldWorks)
        Me.SwApp = SwApp
        Me.ModelDoc = SwApp.ActiveDoc

        If ModelDoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then
            Me.AssemblyDoc = Me.ModelDoc
            Me.SelMgr = Me.ModelDoc.ISelectionManager
            TraegheitsForm.Show()
            AttachSWEvents()
            TraegheitsForm.Label_Select.Text = "Koordinatensystem auswählen"
            TraegheitsForm.Button_Uebertragen.Enabled = False

        Else
            MsgBox("Dokument ist keine Baugruppe!")
            Me.Finalize()

        End If

    End Sub


    Private Sub Traegheit()

        'Dim Ausgabetext As String = ""

        Dim ModeldocExt As ModelDocExtension = ModelDoc.Extension
        Dim MassProp As IMassProperty = ModeldocExt.CreateMassProperty

        Dim SchwerpunktKoordinaten As Object
        Dim MTM As Object

        MassProp.SetCoordinateSystem(Koordinatensystem.Transform)
        MassProp.UseSystemUnits = True
        SchwerpunktKoordinaten = MassProp.CenterOfMass
        MTM = MassProp.GetMomentOfInertia(swMassPropertyMoment_e.swMassPropertyMomentAboutCenterOfMass)

        'Umrechnung in mm
        For i = 0 To 2 Step 1
            SchwerpunktKoordinaten(i) = SchwerpunktKoordinaten(i) * 1000
        Next



        'Umrechnung in kgm²
        'For i = 0 To 8 Step 1
        '    MTM(i) = MTM(i) * 1000
        'Next

        Ausgabetext = Ausgabetext & "Masse: " & MassProp.Mass.ToString("0.##") & "kg" & vbNewLine & vbNewLine & _
            "Schwerpunkt: " & vbNewLine & _
            " Lx= " & Format(SchwerpunktKoordinaten(0), "0.##") & "mm" & vbNewLine & _
            " Ly= " & Format(SchwerpunktKoordinaten(1), "0.##") & "mm" & vbNewLine & _
            " Lz= " & Format(SchwerpunktKoordinaten(2), "0.##") & "mm" & vbNewLine & _
            vbNewLine & vbNewLine & _
            "Trägheitsmomente bezogen auf Massemittelpunkt" & vbNewLine & _
            " Ix= " & Format(MTM(0), "0.##") & "kgm²" & vbNewLine & _
            " Iy= " & Format(MTM(4), "0.##") & "kgm²" & vbNewLine & _
            " Iz= " & Format(MTM(8), "0.##") & "kgm²" & vbNewLine & _
            vbNewLine & vbNewLine & _
            "erzeugt am: " & DateAndTime.Now


        TraegheitsForm.TextBox_Ergebniss.Text = Ausgabetext

        If Zeichnung_da(ModelDoc.GetPathName) Then
            TraegheitsForm.Button_Uebertragen.Enabled = True
        End If

    End Sub


    Private Function Zeichnung_da(modelpath As String) As Boolean

        If FileIO.FileSystem.FileExists(Zeichnungspfad(modelpath)) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function Zeichnungspfad(modelpath As String) As String

        Dim Dateiname As String = FileIO.FileSystem.GetName(modelpath)
        Dim Verzeichnis As String = FileIO.FileSystem.GetParentPath(modelpath)
        Dim Endung As String = ".SLDDRW"
        Dim Zeichnungspfadstr As String

        Zeichnungspfadstr = Verzeichnis & "\" & Dateiname.Substring(0, Dateiname.LastIndexOf(".")) & Endung

        If FileIO.FileSystem.FileExists(Zeichnungspfadstr) Then
            Return Zeichnungspfadstr
        Else
            Return Nothing
        End If
    End Function


    Private Sub Zeichnungseintrag() Handles TraegheitsForm.Uebertragen
        Dim DrwModelDoc As ModelDoc2
        Dim DrawingDoc As DrawingDoc
        Dim filewarnings As Integer
        Dim fileerrors As Integer
        Dim ZeichnungspfadStr As String = Zeichnungspfad(ModelDoc.GetPathName)
        Dim TextObj As INote

        DrwModelDoc = SwApp.OpenDoc6(ZeichnungspfadStr, _
                                     swDocumentTypes_e.swDocDRAWING, _
                                     swOpenDocOptions_e.swOpenDocOptions_LoadModel, _
                                     "", fileerrors, filewarnings)

        DrwModelDoc = SwApp.ActivateDoc3(FileIO.FileSystem.GetName(ZeichnungspfadStr), _
                                         True, _
                                         swRebuildOnActivation_e.swDontRebuildActiveDoc, _
                                         fileerrors)

        DrawingDoc = DrwModelDoc

        TextObj = DrawingDoc.CreateText2(Me.Ausgabetext, 0.03, 0.1, 0.0, 0.003, 0.0)
        TextObj.Visible = True
        TraegheitsForm.Close()
        Me.Finalize()
    End Sub

End Class
