Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic


Public Class HubEinstellen

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

    Private _Face1 As Face2
    Private Property Face1() As Face2
        Get
            Return _Face1
        End Get
        Set(ByVal value As Face2)
            _Face1 = value
        End Set
    End Property

    Private _Face2 As Face2
    Private Property Face2() As Face2
        Get
            Return _Face2
        End Get
        Set(ByVal value As Face2)
            _Face2 = value
        End Set
    End Property

    Private _Abstand As Double
    Private Property Abstand() As Double
        Get
            Return _Abstand
        End Get
        Set(ByVal value As Double)
            _Abstand = value
        End Set
    End Property


    'Form initialisieren
    Dim WithEvents HubEinstellenFormO As New Form_HubEinstellen

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

        'Flächenselektierung1 ausfiltern
        If SelMgr.GetSelectedObjectType3(1, -1) = swSelectType_e.swSelFACES Then

            'Fläche 1 
            Me.Face1 = SelMgr.GetSelectedObjectsFace(1, -1)

            'Namen der Fläche anzeigen
            HubEinstellenFormO.Label_Select1.Text = "Kolbenstange gewählt"

            'Hintergrundfarbe des Select_Labels ändern
            HubEinstellenFormO.Label_Select1.BackColor = Drawing.Color.LightGreen
        Else
            HubEinstellenFormO.Label_Select1.BackColor = Drawing.Color.Salmon
            HubEinstellenFormO.Label_Select1.Text = "Fläche Kolbenstange auswählen"
        End If

        'Flächenselektierung2 ausfiltern
        If SelMgr.GetSelectedObjectType3(2, -1) = swSelectType_e.swSelFACES Then

            'Fläche 2
            Me.Face1 = SelMgr.GetSelectedObjectsFace(2, -1)

            'Namen der Fläche anzeigen
            HubEinstellenFormO.Label_Select2.Text = "Zylinder gewählt"

            'Hintergrundfarbe des Select_Labels ändern
            HubEinstellenFormO.Label_Select2.BackColor = Drawing.Color.LightGreen
        Else
            HubEinstellenFormO.Label_Select2.BackColor = Drawing.Color.Salmon
            HubEinstellenFormO.Label_Select2.Text = "Fläche Zylinder auswählen"
        End If

        If SelMgr.GetSelectedObjectType3(1, -1) = swSelectType_e.swSelFACES And SelMgr.GetSelectedObjectType3(2, -1) = swSelectType_e.swSelFACES Then

            AbstandMessen()

        End If

    End Function

    Public Sub New(ByVal SwApp As ISldWorks)
        Me.SwApp = SwApp
        Me.ModelDoc = SwApp.ActiveDoc

        If ModelDoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then
            Me.AssemblyDoc = Me.ModelDoc
            Me.SelMgr = Me.ModelDoc.ISelectionManager
            HubEinstellenFormO.Show()
            AttachSWEvents()
            HubEinstellenFormO.Label_Select1.Text = "Fläche Kolbenstange auswählen"
            HubEinstellenFormO.Label_Select2.Text = "Fläche Zylinder auswählen"

        Else
            MsgBox("Dokument ist keine Baugruppe!")
            Me.Finalize()

        End If

    End Sub



#End Region






    ''' <summary>
    ''' Erzeugen eines konfigurierten Maßes z.B. für Zylinder oder Bewegungen.
    ''' Wenn zwei Flächen angewählt wurden wird ein Abstandsmaß erzeugt dass
    ''' mit verschiedenen Werten konfiguriert wird.
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <remarks></remarks>
    Public Sub LIMIT_MATE(ByVal doc As IModelDoc2)

        Dim swSelMgr As ISelectionMgr
        Dim MateObj As IMate2
        Dim SwAssem As IAssemblyDoc
        Dim SelType1 As swSelectType_e
        Dim SelType2 As swSelectType_e
        Dim SelObj1 As IFace2
        Dim SelObj2 As IFace2
        Dim Entity1 As IEntity
        'Dim Entity2 As Entity

        'Dim Pos1 As Object = Nothing
        'Dim Pos2 As Object = Nothing

        Dim MeasureObj As Measure
        Dim distance As Double




        Dim DimError As Integer

        'Abfrage ob Dokument eine Baugruppe ist
        If doc.GetType <> swDocumentTypes_e.swDocASSEMBLY Then
            Throw New AggregateException
        End If


        SwAssem = doc
        swSelMgr = doc.SelectionManager

        SelType1 = swSelMgr.GetSelectedObjectType3(1, -1)
        SelType2 = swSelMgr.GetSelectedObjectType3(2, -1)


        'Prüfen ob die ersten beiden Selektionen planare Flächen sind
        If SelType1 = swSelectType_e.swSelFACES And SelType2 = swSelectType_e.swSelFACES Then

            SelObj1 = swSelMgr.GetSelectedObject6(1, -1)
            SelObj2 = swSelMgr.GetSelectedObject6(2, -1)

            Entity1 = swSelMgr.GetSelectedObject6(1, -1)
            'Entity2 = swSelMgr.GetSelectedObject6(2, -1)

            'Entity1.GetDistance(Entity2, True, Nothing, Pos1, Pos2, distance)
            'Messen des Abstandes der beiden Flächen
            MeasureObj = doc.Extension.CreateMeasure
            MeasureObj.ArcOption = 1
            MeasureObj.Calculate(Nothing)

            distance = MeasureObj.NormalDistance()

            Debug.Print("Distance: " & MeasureObj.Distance * 1000 & "mm")
            Debug.Print("NormalDistance: " & MeasureObj.NormalDistance * 1000 & "mm")
            Debug.Print("Normal: " & MeasureObj.Normal * 1000 & "mm")


            'MsgBox("Maß ist: " & distance * 1000 & "mm")





            '########################################
            '#          Form ausführen              #
            '########################################

            Dim Form As New Form_HubEinstellen

            Form.abs = distance

            Form.ShowDialog()

            If Form.Abort Then
                Exit Sub
            End If


            'Maßverknüpfung erzeugen

            MateObj = SwAssem.AddMate3(swMateType_e.swMateDISTANCE, swMateAlign_e.swMateAlignCLOSEST, True, distance, distance, distance, 0, 0, 0, 0, 0, False, DimError)


            '########################################
            '#      Konfigurationen erzeugen        #
            '########################################

            Dim ConfigMgr As IConfigurationManager
            Dim Config As IConfiguration
            Dim Parentname As String    'Name der Ausgangskonfiguration

            ConfigMgr = doc.ConfigurationManager
            Config = ConfigMgr.ActiveConfiguration

            Parentname = Config.Name

            ConfigMgr.AddConfiguration("eingefahren", "Zylinder eingefahren", "alternatativname1", 1, Config.Name, "12345")
            ConfigMgr.AddConfiguration("ausgefahren", "Zylinder ausgefahren", "alternatativname2", 1, Config.Name, "12345")
            'doc.IGetConfigurationByName(Parentname)
            doc.ShowConfiguration2(Parentname)
            doc.EditRebuild3()

            '############################################
            '#      Maße an Konfiguationen anpassen     #
            '############################################

            Dim DimensionObj As IDimension

            DimensionObj = MateObj.DisplayDimension2(0).GetDimension2(0)


            DimensionObj.SetSystemValue3(distance, swSetValueInConfiguration_e.swSetValue_InSpecificConfigurations, Config.Name)


            DimensionObj.SetSystemValue3(Form.huebe.Item(0), swSetValueInConfiguration_e.swSetValue_InSpecificConfigurations, "eingefahren")

            DimensionObj.SetSystemValue3(Form.huebe.Item(1), swSetValueInConfiguration_e.swSetValue_InSpecificConfigurations, "ausgefahren")




            doc.EditRebuild3()

        Else
            MsgBox("Fehler: keine parallelen Flächen markiert!")
        End If


    End Sub

    Protected Overrides Sub Finalize()

        DettachSWEvents()
        MyBase.Finalize()

    End Sub

    Private Sub AbstandMessen()
        Dim MeasureObj As Measure = ModelDoc.Extension.CreateMeasure
        XXX()




    End Sub

End Class
