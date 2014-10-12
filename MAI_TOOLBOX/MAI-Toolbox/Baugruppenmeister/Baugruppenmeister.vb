
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic
Imports MAI_TOOLBOX

Public Class Baugruppenmeister

    Private _swApp As SldWorks
    Public Property swApp As SldWorks
        Get
            Return _swApp
        End Get
        Set(ByVal value As SldWorks)
            _swApp = value
        End Set
    End Property


    Private _modeldoc As ModelDoc2
    Public Property modeldoc() As ModelDoc2
        Get
            Return _modeldoc
        End Get
        Set(ByVal value As ModelDoc2)

            _modeldoc = value

        End Set
    End Property

    Private HGBeinbezValue As Boolean
    readonly Public Property HGBeinbez() As Boolean
        Get
            Return Form.CB_HBG_einbeziehen.Checked
        End Get
    End Property

    Private _BgNr As MAI_Teilenummer
    Public Property BGNr() As MAI_Teilenummer
        Get
            Return _BgNr
        End Get
        Set(ByVal value As MAI_Teilenummer)
            _BgNr = value
        End Set
    End Property



    Dim WithEvents Form As New FRM_Baugruppenmeister
    Dim Dataset As New BG_Dataset

    Dim PropBez() As String = {"name", "bemerkung1", "bemerkung2", "bemerkung3", "hersteller", "best.nr", "notiz", "tnr", "konstrukteur", "zeichner"}
    Dim TabBez() As String = {"Name", "Bemerkung1", "Bemerkung2", "Bemerkung3", "Hersteller", "Bestellnummer", "Notiz", "Teilenummer", "Konstrukteur", "Zeichner"}
    Dim BoolPropBez() As String = {"IstFertigungsteil", "IstKaufteil", "IstHilfsBG", "IstHilfsteil"}
    Dim BoolTabBez() As String = {"IstFertigungsteil", "IstKaufteil", "IstHilfsBG", "IstHilfsteil"}




    Structure ModelAndConfig
        Public modeldoc As ModelDoc2
        Public Config As String
    End Structure


    Public Sub New(ByRef iswapp As SldWorks)


        _swApp = iswapp

        Dim toolbox As New MAITOOLS(Me.swApp)

        Me.modeldoc = swApp.ActiveDoc

        Me.BGNr = toolbox.GetProp(Me.modeldoc, "TNR")


        If Me.modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then


            Form.DataGridView1.DataSource = Dataset.Tables(0)

            'FillTable()
            refresh_table()
            Form.getchanges = True
            Form.ShowDialog()

        End If

        Me.Finalize()

    End Sub

    Private Sub refresh_table() Handles Form.RefreshBGTable



        Form.getchanges = False
        Dataset.Baugruppe.Clear()
        Form.TextBox_Baugruppennummer.Text = Me.BGNr.CreateTnr



        FillTable()
        Form.getchanges = True

    End Sub


    Private Sub Behandle_Aenderungen() Handles Form.Table_changed
        Dim table As BG_Dataset.BaugruppeDataTable
        'Dim row As BG_Dataset.BaugruppeRow

        If IsNothing(Dataset.Baugruppe.GetChanges()) Then
            Exit Sub
        End If
        table = Dataset.Baugruppe.GetChanges()

        For Each row As BG_Dataset.BaugruppeRow In table

            writerow(row)

        Next

        refresh_table()

    End Sub



    ''' <summary>
    ''' Mehrere markierte Felder der Tabelle werden bearbeitet
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Mehrfeldbearbeitung() Handles Form.Mehrfeldbearbeitung

        Dim MehrfeldForm As New mehrere_Felder_ändern
        Dim Eingabewert As String

        'Form anzeigen
        MehrfeldForm.ShowDialog()
        Eingabewert = MehrfeldForm.EingabeTextBox.Text  'Textfeld übernehmen

        'prüfen ob Textfeld nicht leer war
        If MehrfeldForm.ReturnValue <> "" Then

            'für jede markierte Zelle den Inhalt ändern
            For counter = 0 To (Form.DataGridView1.SelectedCells.Count - 1)

                Form.DataGridView1.SelectedCells(counter).Value = Eingabewert

            Next

        End If

        'Ressourchen freigeben
        MehrfeldForm.Dispose()


    End Sub

    Private Sub Datei_oeffnen(path As String) Handles Form.Datei_Oeffnen

        Dim openerrors As Integer
        Dim openwarnings As Integer
        Dim activateerrors As Integer

        swApp.OpenDoc6(path, swDocumentTypes_e.swDocPART, swOpenDocOptions_e.swOpenDocOptions_LoadModel, "", openerrors, openwarnings)
        swApp.IActivateDoc3(path, False, activateerrors)


    End Sub

    'Baugruppennummer für alle Fertigungsteile ändern
    Private Sub BGNr_aendern(BgNr_neu As MAI_Teilenummer) Handles Form.BGNr_changed



        For Each Row As BG_Dataset.BaugruppeRow In Dataset.Baugruppe
            Dim TNR As MAI_Teilenummer = Row.Teilenummer

            If TNR.CompleteBGNr = Me.BGNr.CompleteBGNr And Me.BGNr.ProjektNr = TNR.ProjektNr Then

                Row.Teilenummer = BgNr_neu.ProjektNr & "." & BgNr_neu.CompleteBGNr & TNR.TeileNr


            End If

        Next

    End Sub


    Private Sub FillTable()
        Dim tools As New MAITOOLS(Me.swApp)
        ' Dim table As BG_Dataset.BaugruppeDataTable


        Dim MODCONF() As ModelAndConfig


        MODCONF = ErzCompListe(modeldoc, Me.HGBeinbez)




        'Schleife ein Durchlauf für jede Komponente
        For Each item As ModelAndConfig In MODCONF

            'Problem: wenn die Baugruppe nur aus Unterbaugruppen besteht ist das erste Item "Nothing"
            'Fehler in der Funktion "ErzCompListe
            If IsNothing(item.modeldoc) = False Then


                'Komponente

                Dim row As BG_Dataset.BaugruppeRow
                Dim selectrow() As BG_Dataset.BaugruppeRow
                '
                row = Dataset.Baugruppe.NewBaugruppeRow

                row = Fillrow(item.modeldoc, row, item.Config)

                'Zeilen die die gleich Konfiguration und den gleichen Dateinamen haben in selectrow laden
                selectrow = Dataset.Baugruppe.Select("Dateiname = '" & row.Dateiname & "' and Konfiguration = '" & row.Konfiguration & "'")


                'Wenn selectrow leer dann neue Zeile anlegen
                If selectrow.Length = 0 Then
                    Dataset.Baugruppe.AddBaugruppeRow(row)
                Else
                    'sonst Stückzahl erhöhen
                    selectrow(0).Stueckzahl = selectrow(0).Stueckzahl + 1
                End If
                Dataset.AcceptChanges()
            End If
        Next

    End Sub


    Private Function Fillrow(modeldoc As ModelDoc2, row As BG_Dataset.BaugruppeRow, Optional config As String = "") As BG_Dataset.BaugruppeRow

        Dim toolbox As New MAITOOLS(Me.swApp)
        Dim SwModelDocExt As ModelDocExtension = modeldoc.Extension
        Dim SwPropMgr As CustomPropertyManager = SwModelDocExt.CustomPropertyManager("")
        Dim SwPropMgrConfig As CustomPropertyManager = SwModelDocExt.CustomPropertyManager(config)
        Dim returnval As String = ""
        Dim returnvalresolved As String = ""



        'Konfiguration
        row.Konfiguration = config

        'Dateiname
        Dim Dateiname As String
        Dateiname = modeldoc.GetPathName
        row.Dateiname = Dateiname.Substring(Dateiname.LastIndexOf("\") + 1)

        'Pfad
        row.Pfad = modeldoc.GetPathName

        'Stückzahl auf eins setzen
        row.Stueckzahl = 1

        'Konfigurationsabhängiges Lesen


        Dim IsInConfig As Boolean = False
        Dim AllPropBez() As String = SwPropMgr.GetNames
        Dim AllPropBezConfig() As String = SwPropMgrConfig.GetNames




        For i As Long = 0 To PropBez.Length - 1 Step 1

            If IsNothing(AllPropBezConfig) = False Then
                For Each item In AllPropBezConfig
                    If PropBez(i).ToLower = item.ToLower Then
                        IsInConfig = True
                        Exit For
                    End If
                Next

            End If

            If IsInConfig Then
                row.Item(TabBez(i)) = toolbox.GetProp(SwPropMgrConfig, PropBez(i))
            Else
                row.Item(TabBez(i)) = toolbox.GetProp(SwPropMgr, PropBez(i))
            End If
            IsInConfig = False
        Next



        'Boolsche Properties



        For i As Long = 0 To BoolPropBez.Length - 1 Step 1

            If IsNothing(AllPropBezConfig) = False Then
                For Each item In AllPropBezConfig
                    If BoolPropBez(i).ToLower = item.ToLower Then
                        IsInConfig = True
                        Exit For
                    End If
                Next

            End If

            If IsInConfig Then
                If toolbox.GetProp(SwPropMgrConfig, BoolPropBez(i)) = "Yes" Then
                    row.Item(BoolTabBez(i)) = True
                End If
            Else
                If toolbox.GetProp(SwPropMgr, BoolPropBez(i)) = "Yes" Then
                    row.Item(BoolTabBez(i)) = True
                End If
            End If
            IsInConfig = False

        Next



        Return row


    End Function


    ''' <summary>
    ''' Änderungen einer Zeile umsetzen
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub writerow(row As BG_Dataset.BaugruppeRow)

        Dim Errors As Integer
        Dim Warnings As Integer
        Dim Endung As String = row.Pfad.Substring(row.Pfad.LastIndexOf("."))
        Dim modeldoc As ModelDoc2 = Nothing



        If Endung.ToUpper = ".SLDPRT" Then
            modeldoc = Me.swApp.OpenDoc6(row.Pfad, swDocumentTypes_e.swDocPART, swOpenDocOptions_e.swOpenDocOptions_Silent, "", Errors, Warnings)
        End If

        If Endung.ToUpper = ".SLDASM" Then
            modeldoc = Me.swApp.OpenDoc6(row.Pfad, swDocumentTypes_e.swDocASSEMBLY, swOpenDocOptions_e.swOpenDocOptions_Silent, "", Errors, Warnings)
        End If

        'Prüfen ob Model schreibgeschützt ist
        If modeldoc.IsOpenedReadOnly Then
            Exit Sub
        End If

        If Errors <> 0 Or IsNothing(modeldoc) Then
            MsgBox("Fehler beim Laden von:" & row.Pfad)
            Exit Sub
        End If

        Dim SwModelDocExt As ModelDocExtension = modeldoc.Extension
        Dim SwPropMgr As CustomPropertyManager = SwModelDocExt.CustomPropertyManager("")
        Dim SWPropMgrConfig As CustomPropertyManager = SwModelDocExt.CustomPropertyManager(row.Konfiguration)
        Dim tools As New MAITOOLS(Me.swApp)



        Dim AllPropBez() As String = SwPropMgr.GetNames
        Dim AllPropBezConfig() As String = SWPropMgrConfig.GetNames
        Dim IsInConfig As Boolean = False

        'Boolsche Properties

        For i As Long = 0 To BoolPropBez.Length - 1 Step 1

            If IsNothing(AllPropBezConfig) = False Then
                For Each item In AllPropBezConfig
                    If BoolPropBez(i).ToLower = item.ToLower Then
                        IsInConfig = True
                        Exit For
                    End If
                Next

            End If

            If IsInConfig Then
                If row.Item(BoolTabBez(i)) Then
                    tools.CHANGEPROP(SWPropMgrConfig, BoolPropBez(i), "Yes", True)
                Else
                    tools.CHANGEPROP(SWPropMgrConfig, BoolPropBez(i), "No", True)
                End If
            Else
                If row.Item(BoolTabBez(i)) = True Then
                    tools.CHANGEPROP(SwPropMgr, BoolPropBez(i), "Yes", True)
                Else
                    tools.CHANGEPROP(SwPropMgr, BoolPropBez(i), "No", True)
                End If
            End If
            IsInConfig = False

        Next

        '
        '   String Eigenschaften schreiben
        '

        For i As Long = 0 To PropBez.Length - 1 Step 1

            If IsNothing(AllPropBezConfig) = False Then
                For Each item In AllPropBezConfig
                    If PropBez(i).ToLower = item.ToLower Then
                        IsInConfig = True
                        Exit For
                    End If
                Next

            End If

            If IsInConfig Then
                tools.CHANGEPROP(SWPropMgrConfig, PropBez(i), row.Item(TabBez(i)), True)
            Else
                tools.CHANGEPROP(SwPropMgr, PropBez(i), row.Item(TabBez(i)), True)
            End If
            IsInConfig = False
        Next

        '
        'Dateinamen ändern
        '
        Dim MaiTnr As New MAI_Teilenummer

        Dim Name As String = ""

        Name = row.Dateiname.Substring(0, row.Dateiname.LastIndexOf("."))

        MaiTnr = row.Teilenummer

        'Nur Namensänderungen bei Fertigungsteilen
        If MaiTnr.Gueltig Then

            If Name.ToLower <> (row.Teilenummer.ToLower & "-" & row.Name.ToLower) Then

                tools.UNAME(modeldoc, row.Teilenummer & "-" & row.Name)
            End If
        Else 'wenn sich nur die Namensspalte ändert
            If row.Dateiname <> modeldoc.GetPathName.Substring(modeldoc.GetPathName.LastIndexOf("\") + 1) Then
                Debug.Print(row.Dateiname.Substring(0, row.Dateiname.LastIndexOf(".")))
                tools.UNAME(modeldoc, row.Dateiname.Substring(0, row.Dateiname.LastIndexOf(".")))
            End If

        End If

        modeldoc.Rebuild(swRebuildOptions_e.swUpdateDirtyOnly)
    End Sub

    ''' <summary>
    ''' Erzeuge Komponentenliste von Unterbaugruppen
    ''' </summary>
    ''' <param name="modeldoc"></param>
    ''' <returns>Array von Component2</returns>
    ''' <remarks></remarks>
    Private Function ErzCompListe(modeldoc As ModelDoc2, ByVal IncludeHGBParts As Boolean) As ModelAndConfig()

        Dim SwAssy As AssemblyDoc
        Dim CompList() As Object
        Dim CompCount As Long
        Dim MODCONF(0) As ModelAndConfig
        Dim length As Long = 0

        'Prüfen ob 
        If modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then
            SwAssy = modeldoc

        Else
            Return Nothing
        End If

        CompList = SwAssy.GetComponents(True)
        CompCount = SwAssy.GetComponentCount(True)


        For i = 0 To CompCount - 1 Step 1
            'Each component As Object In CompList

            If CompList(i).GetSuppression <> SolidWorks.Interop.swconst.swComponentSuppressionState_e.swComponentSuppressed Then


                Dim tmpmdl As ModelDoc2 = CompList(i).GetModelDoc2
                Dim SwModelDocExt As ModelDocExtension = tmpmdl.Extension
                Dim SwPropMgr As CustomPropertyManager = SwModelDocExt.CustomPropertyManager("")
                Dim tools As New MAITOOLS(Me.swApp)



                If tmpmdl.GetType = swDocumentTypes_e.swDocASSEMBLY _
                    And tools.GetProp(SwPropMgr, "IstHilfsBG") = "Yes" _
                    And IncludeHGBParts _
                    Then

                    Debug.Print("HGB: " & tmpmdl.GetTitle & "  gefunden")
                    Dim NewMODCONF() As ModelAndConfig = ErzCompListe(tmpmdl, IncludeHGBParts)
                    Dim StartIndex As Integer = MODCONF.Length


                    'Array verlängern
                    ReDim Preserve MODCONF(MODCONF.Length + NewMODCONF.Length - 1)

                    'Arrays ineinander kopieren
                    Array.Copy(NewMODCONF, 0, MODCONF, StartIndex, NewMODCONF.Length)
                    length = MODCONF.Length
                Else



                    length = length + 1

                    ReDim Preserve MODCONF(length - 1)
                    MODCONF(length - 1).modeldoc = CompList(i).GetModelDoc2
                    MODCONF(length - 1).Config = CompList(i).ReferencedConfiguration

                End If
            End If

        Next
        Return MODCONF
    End Function





End Class
