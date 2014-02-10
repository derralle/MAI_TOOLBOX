
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

    Dim WithEvents Form As New FRM_Baugruppenmeister
    Dim Dataset As New BG_Dataset

    Dim PropBez() As String = {"name", "bemerkung1", "bemerkung2", "bemerkung3", "hersteller", "best.nr", "notiz", "tnr", "konstrukteur", "zeichner"}
    Dim TabBez() As String = {"Name", "Bemerkung1", "Bemerkung2", "Bemerkung3", "Hersteller", "Bestellnummer", "Notiz", "Teilenummer", "Konstrukteur", "Zeichner"}
    Dim BoolPropBez() As String = {"IstFertigungsteil", "IstKaufteil", "IstHilfsBG", "IstHilfsteil"}
    Dim BoolTabBez() As String = {"IstFertigungsteil", "IstKaufteil", "IstHilfsBG", "IstHilfsteil"}

    Public Sub New(ByRef iswapp As SldWorks)

        _swApp = iswapp


        Me.modeldoc = swApp.ActiveDoc


        If Me.modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then


            Form.DataGridView1.DataSource = Dataset.Tables(0)

            FillTable()

            Form.Show()


        End If

        Me.Finalize()

    End Sub

    Private Sub refresh_table() Handles Form.RefreshBGTable

        Dataset.Baugruppe.Clear()
        FillTable()

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


    End Sub

    Private Sub FillTable()
        Dim tools As New MAITOOLS(Me.swApp)
        ' Dim table As BG_Dataset.BaugruppeDataTable

        Dim Assembly As AssemblyDoc
        Dim components() As Object
        Dim compcount As Long
        Dim tempmodel As ModelDoc2


        Assembly = Me.modeldoc

        ' True = Toplevel
        compcount = Assembly.GetComponentCount(True)
        components = Assembly.GetComponents(True)

        'Schleife ein Durchlauf für jede Komponente
        For i = 0 To compcount - 1
            'Komponente

            If components(i).GetSuppression <> SolidWorks.Interop.swconst.swComponentSuppressionState_e.swComponentSuppressed Then

                Dim row As BG_Dataset.BaugruppeRow
                Dim selectrow() As BG_Dataset.BaugruppeRow
                Dim config As String

                row = Dataset.Baugruppe.NewBaugruppeRow

                tempmodel = components(i).GetModelDoc2

                config = components(i).ReferencedConfiguration

                row = Fillrow(tempmodel, row, config)

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
        Next (i)

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


        If Errors <> 0 Or IsNothing(modeldoc) Then
            MsgBox("Fehler beim Laden von:" & row.Pfad)
            Exit Sub
        End If

        Dim SwModelDocExt As ModelDocExtension = modeldoc.Extension
        Dim SwPropMgr As CustomPropertyManager = SwModelDocExt.CustomPropertyManager("")
        Dim tools As New MAITOOLS(Me.swApp)



        'IstFertigungsteil
        If row.IstFertigungsteil Then
            tools.CHANGEPROP(modeldoc, "IstFertigungsteil", "Yes", True)
        Else
            tools.CHANGEPROP(modeldoc, "IstFertigungsteil", "No", True)
        End If

        'IstKaufteil
        If row.IstKaufteil Then
            tools.CHANGEPROP(modeldoc, "IstKaufteil", "Yes", True)
        Else
            tools.CHANGEPROP(modeldoc, "IstKaufteil", "No", True)
        End If

        'IstHilfsBG
        If row.IstHilfsBG Then
            tools.CHANGEPROP(modeldoc, "IstHilfsBG", "Yes", True)
        Else
            tools.CHANGEPROP(modeldoc, "IstHilfsBG", "No", True)
        End If

        'istHilfsteil
        If row.IstHilfsteil Then
            tools.CHANGEPROP(modeldoc, "IstHilfsteil", "Yes", True)
        Else
            tools.CHANGEPROP(modeldoc, "IstHilfsteil", "No", True)
        End If

        'Bestellnummer
        tools.CHANGEPROP(modeldoc, "Best.Nr", row.Bestellnummer, True)

        'Bemerkung1
        tools.CHANGEPROP(modeldoc, "Bemerkung1", row.Bemerkung1, True)

        'Bemerkung2
        tools.CHANGEPROP(modeldoc, "Bemerkung2", row.Bemerkung2, True)

        'Hersteller
        tools.CHANGEPROP(modeldoc, "Hersteller", row.Hersteller, True)

        'Konstrukteur
        tools.CHANGEPROP(modeldoc, "Konstrukteur", row.Konstrukteur, True)


        modeldoc.Rebuild(swRebuildOptions_e.swUpdateDirtyOnly)
    End Sub


End Class
