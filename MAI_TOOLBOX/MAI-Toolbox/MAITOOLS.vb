Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic


Public Class MAITOOLS


    Private _swApp As SldWorks
    Private Property swApp As SldWorks
        Get
            Return _swApp
        End Get
        Set(ByVal value As SldWorks)
            _swApp = value
        End Set
    End Property









    Public Sub New(ByRef iswapp As SldWorks)
        _swApp = iswapp
    End Sub



#Region "Dateioperationen"






    'Speicher unter 
    Friend Sub SpeichernUnter( _
    ByVal oSwModel As ModelDoc2, _
    ByVal sSpeicherpfad As String, _
    Optional ByVal eSaveAsOptions As swSaveAsOptions_e = _
        swSaveAsOptions_e.swSaveAsOptions_Silent, _
    Optional ByRef eSaveWarning As swFileSaveWarning_e = 0)
        Try
            'Instanz prüfen
            If oSwModel Is Nothing Then
                'Fehler
                Throw New Exception( _
                "Keine Instanz vorhanden.")
            Else
                'Rückgabewerte
                Dim bStatus As Boolean
                Dim eError As swFileSaveError_e
                'Aktuelles Dokument speichern
                bStatus = oSwModel.SaveAs4( _
                       sSpeicherpfad, _
                       swSaveAsVersion_e.swSaveAsCurrentVersion, _
                       eSaveAsOptions, _
                       CType(eError, swFileSaveError_e), _
                       CType(eSaveWarning, swFileSaveWarning_e))
                'Rückgaben auswerten
                If bStatus = False Then
                    Throw New Exception( _
                    "Aktuelles Dokument wurde nicht gespeichert." & _
                    vbNewLine & "Errormeldung der API Methode: " & _
                    eError.ToString & ".")
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False)
            Trace.WriteLine("Fehler: Wo: " & _
                ex.StackTrace & " Was: " & ex.Message)
            If oSwModel Is Nothing Then
                Throw New Exception( _
                "Fehler beim ""Speichern unter"" " & _
                "eines Dokuments")
            Else
                Throw New Exception( _
                "Fehler beim ""Speichern unter"" " & _
                "des Dokuments " & oSwModel.GetTitle)
            End If
        End Try
    End Sub


    'Komponente umbenennen
    Public Sub UNAME(ByRef modeldoc As ModelDoc2, _
                     Optional ByVal newname As String = "")




        Dim newpath As String
        Dim path As String
        Dim name As String
        Dim dialogname As String = ""
        Dim ending As String
        Dim folder As String



        'Pfad ermitteln
        path = modeldoc.GetPathName()

        folder = path.Remove(path.LastIndexOf("\") + 1)

        ending = path.Substring(path.LastIndexOf("."), (path.Length) - path.LastIndexOf("."))

        name = path.Substring(path.LastIndexOf("\") + 1, path.Length - folder.Length - ending.Length)


        'Namen in Dialog ändern
        dialogname = name

        Dim form As New FRM_UNAME(dialogname)
        form.ShowDialog()
        dialogname = form.component_name

        If (name = dialogname) Or dialogname = "" Then
            MsgBox("Fehler der Name wurde nicht geändert, keine Aktion durchgeführt")
            Exit Sub
        End If

        newpath = folder & dialogname & ending

        If FileIO.FileSystem.FileExists(newpath) Then
            MsgBox("Fehler: Eine Datei mit diesem Namen existiert schon!")
            Exit Sub
        End If

        SpeichernUnter(modeldoc, newpath)
        FileIO.FileSystem.DeleteFile(path)



    End Sub

    Public Sub UNAME_Dialog(ByRef swapp As SldWorks, _
                            ByRef modeldoc As ModelDoc2)

        Dim newpath As String
        Dim path As String
        Dim name As String
        Dim dialogname As String = ""
        Dim ending As String
        Dim folder As String
        Dim Zeichnungdoc As ModelDoc2
        Dim fileerror As Long
        Dim filewarning As Long


        'Pfad ermitteln
        path = modeldoc.GetPathName()

        folder = path.Remove(path.LastIndexOf("\") + 1)

        ending = path.Substring(path.LastIndexOf("."), (path.Length) - path.LastIndexOf("."))

        name = path.Substring(path.LastIndexOf("\") + 1, path.Length - folder.Length - ending.Length)



        'Namen in Dialog ändern
        dialogname = name

        Dim form As New FRM_UNAME(dialogname)









        form.ShowDialog()
        dialogname = form.component_name

        If (name = dialogname) Or dialogname = "" Then
            MsgBox("Fehler der Name wurde nicht geändert, keine Aktion durchgeführt")
            Exit Sub
        End If

        newpath = folder & dialogname & ending

        If FileIO.FileSystem.FileExists(newpath) Then
            MsgBox("Fehler: Eine Datei mit diesem Namen existiert schon!")
            Exit Sub
        End If

        'Prüfen ob Datei keine Zeichnung ist und ob eine Zeichung existiert
        If ending <> ".SLDDRW" And form.mit_Zeichnung And FileIO.FileSystem.FileExists(folder & name & ".SLDDRW") Then
            'Zeichnung öffnen
            Zeichnungdoc = swapp.OpenDoc6(folder & name & ".SLDDRW", swDocumentTypes_e.swDocDRAWING, swOpenDocOptions_e.swOpenDocOptions_Silent, "", fileerror, filewarning)

            'Model speichern unter 
            SpeichernUnter(modeldoc, newpath)

            'Zeichnung speichern unter
            SpeichernUnter(Zeichnungdoc, folder & dialogname & ".SLDDRW")

            'Zeichnung schließen
            'Zeichnungdoc.ForceRebuild3(True)
            swapp.CloseDoc(Zeichnungdoc.GetTitle())

            'Dateien löschen
            FileIO.FileSystem.DeleteFile(folder & name & ".SLDDRW")
            FileIO.FileSystem.DeleteFile(path)
        Else
            SpeichernUnter(modeldoc, newpath)
            FileIO.FileSystem.DeleteFile(path)
        End If




    End Sub
#End Region

#Region "Eigenschaften bearbeiten"

    'Eigenschaften von Festo-Teilen übernehmen
    Public Sub FESTO_PROP(ByRef modeldoc As ModelDoc2)



        Dim swAssy As AssemblyDoc
        Dim comps() As Object
        Dim hersteller As String = "Festo"
        Dim bestellnummer As String = ""
        Dim beschreibung As String = ""
        Dim compcount As Long
        Dim tmpmdl As ModelDoc2




        If modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then

            swAssy = modeldoc

            'Eigenschaften Auslesen
            bestellnummer = modeldoc.GetCustomInfoValue("", "BOMINFO")
            beschreibung = modeldoc.GetCustomInfoValue("", "NT")

            'in Assembly einfügen
            modeldoc.CustomInfo2("", "Best.Nr") = bestellnummer
            modeldoc.CustomInfo2("", "Name") = beschreibung
            modeldoc.CustomInfo2("", "Hersteller") = hersteller

            comps = swAssy.GetComponents(True)
            compcount = swAssy.GetComponentCount(True)

            For i = 0 To compcount - 1
                tmpmdl = comps(i).Getmodeldoc2

                'in Teile einfügen
                tmpmdl.CustomInfo2("", "Best.Nr") = bestellnummer
                tmpmdl.CustomInfo2("", "Name") = beschreibung
                tmpmdl.CustomInfo2("", "Hersteller") = hersteller
                tmpmdl.ForceRebuild3(False)
            Next (i)


        End If

        If modeldoc.GetType = swDocumentTypes_e.swDocPART Then

            'Eigenschaften Auslesen
            bestellnummer = modeldoc.GetCustomInfoValue("", "BOMINFO")
            beschreibung = modeldoc.GetCustomInfoValue("", "NT")

            'in Teil einfügen
            modeldoc.CustomInfo2("", "Best.Nr") = bestellnummer
            modeldoc.CustomInfo2("", "Name") = beschreibung
            modeldoc.CustomInfo2("", "Hersteller") = hersteller

        End If

        MsgBox("Folgende Eigenschaften geschrieben: " & vbNewLine & vbNewLine & _
                   "Hersteller:" & vbTab & vbTab & hersteller & vbNewLine & _
                   "Name: " & vbTab & vbTab & beschreibung & vbNewLine & _
                   "Bestellnummer: " & vbTab & bestellnummer)

        'Neuaufbau
        modeldoc.ForceRebuild3(True)


    End Sub

    'Eigenschaften von Schunk-Teilen übernehmen
    Public Sub SCHUNK_PROP(ByRef modeldoc As ModelDoc2)

        Dim swAssy As AssemblyDoc
        Dim comps() As Object
        Dim hersteller As String = "Schunk"
        Dim bestellnummer As String = ""
        Dim beschreibung As String = ""
        Dim kurzbez As String = ""
        Dim compcount As Long
        Dim tmpmdl As ModelDoc2




        If modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then

            swAssy = modeldoc

            'Eigenschaften Auslesen
            bestellnummer = modeldoc.GetCustomInfoValue("", "IDNR")
            beschreibung = modeldoc.GetCustomInfoValue("", "NT")
            kurzbez = modeldoc.GetCustomInfoValue("", "TYP")

            'in Assembly einfügen
            modeldoc.CustomInfo2("", "Best.Nr") = bestellnummer
            modeldoc.CustomInfo2("", "Name") = kurzbez & " " & beschreibung
            modeldoc.CustomInfo2("", "Hersteller") = hersteller


            comps = swAssy.GetComponents(True)
            compcount = swAssy.GetComponentCount(True)

            For i = 0 To compcount - 1
                tmpmdl = comps(i).Getmodeldoc2

                'in Teile einfügen
                tmpmdl.CustomInfo2("", "Best.Nr") = bestellnummer
                tmpmdl.CustomInfo2("", "Name") = kurzbez & " " & beschreibung
                tmpmdl.CustomInfo2("", "Hersteller") = hersteller
                tmpmdl.ForceRebuild3(False)
            Next (i)

            modeldoc.ForceRebuild3(False)
            MsgBox("jup")

        End If

        If modeldoc.GetType = swDocumentTypes_e.swDocPART Then

            'Eigenschaften Auslesen
            bestellnummer = modeldoc.GetCustomInfoValue("", "IDNR")
            beschreibung = modeldoc.GetCustomInfoValue("", "NT")
            kurzbez = modeldoc.GetCustomInfoValue("", "TYP")

            'in Teil einfügen
            modeldoc.CustomInfo2("", "Best.Nr") = bestellnummer
            modeldoc.CustomInfo2("", "Name") = kurzbez & " " & beschreibung
            modeldoc.CustomInfo2("", "Hersteller") = hersteller

        End If

        MsgBox("Folgende Eigenschaften geschrieben: " & vbNewLine & vbNewLine & _
                 "Hersteller:" & vbTab & vbTab & hersteller & vbNewLine & _
                 "Name: " & vbTab & vbTab & kurzbez & " " & beschreibung & vbNewLine & _
                 "Bestellnummer: " & vbTab & bestellnummer)


        'Neuaufbau
        modeldoc.ForceRebuild3(True)


    End Sub

    '
    Public Sub IMPORT_PROP(ByRef modeldoc As ModelDoc2)

        Dim swAssy As AssemblyDoc = Nothing
        Dim comps() As Object
        Dim hersteller As String = ""
        Dim bestellnummer As String = ""
        Dim beschreibung As String = ""
        Dim kurzbez As String = ""
        Dim compcount As Long
        Dim tmpmdl As ModelDoc2

        Dim SwModelDocExt As ModelDocExtension = modeldoc.Extension
        Dim SwPropMgr As CustomPropertyManager = SwModelDocExt.CustomPropertyManager("")
        Dim Proptypes As Object = Nothing
        Dim Propnames As Object = Nothing
        Dim Propvalues As Object = Nothing





    Dim Form As New FRM_IMPORT_EIGENSCH

        ' Ausführen in Baugruppe oder Teil
        If modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Or modeldoc.GetType = swDocumentTypes_e.swDocPART Then


            If modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then

                swAssy = modeldoc

            End If

            'Eigenschaften Auslesen
            SwPropMgr.GetAll(Propnames, Proptypes, Propvalues)



            Dim i As Integer = 0
            For Each item In Propvalues


                If item <> "" Then
                    Form.eigenschaftsliste.Add(item)
                    i = i + 1

                End If

            Next






            Form.ShowDialog()

            If Form.Cancel = True Then
                Exit Sub

            End If

            'in Assembly einfügen
            modeldoc.CustomInfo2("", "Best.Nr") = Form.bestellnummer
            modeldoc.CustomInfo2("", "Name") = Form.bezeichung
            modeldoc.CustomInfo2("", "Hersteller") = Form.hersteller


            

            If modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then

                comps = swAssy.GetComponents(True)
                compcount = swAssy.GetComponentCount(True)

                For i = 0 To compcount - 1
                    tmpmdl = comps(i).Getmodeldoc2

                    'in Teile einfügen
                    tmpmdl.CustomInfo2("", "Best.Nr") = Form.bestellnummer
                    tmpmdl.CustomInfo2("", "Name") = Form.bezeichung
                    tmpmdl.CustomInfo2("", "Hersteller") = Form.hersteller
                    tmpmdl.ForceRebuild3(False)
                Next (i)

                modeldoc.ForceRebuild3(False)
            End If

        End If

        MsgBox("Folgende Eigenschaften geschrieben: " & vbNewLine & vbNewLine & _
                 "Hersteller:" & vbTab & Form.hersteller & vbNewLine & _
                 "Name: " & vbTab & vbTab & Form.bezeichung & vbNewLine & _
                 "Bestellnummer: " & vbTab & Form.bestellnummer)


        'Neuaufbau
        modeldoc.ForceRebuild3(True)


    End Sub

    'Eigenschaft in einer Baugruppe ersetzen.
    'Wenn Eigenschaft leer ist  wird nichts gemacht!
    Private Sub CHANGE_PROP_BG(ByRef modeldoc As ModelDoc2, ByVal prop_name As String, ByVal prop_val As String)



        Dim swAssy As AssemblyDoc
        'Dim comps() As Component2
        Dim comps() As Object
        Dim compcount As Long
        Dim tmpmdl As ModelDoc2
        Dim ALLPROPS As Object



        If modeldoc.GetType <> swDocumentTypes_e.swDocASSEMBLY Then
            MsgBox("Aktives Dokument ist keine Baugruppe!")
            Exit Sub
        End If


        'PROP in Baugruppe Ändern 

        ALLPROPS = modeldoc.GetCustomInfoNames2("")
        For Each tmpstr As String In ALLPROPS
            If UCase(prop_name) = UCase(tmpstr) Then
                modeldoc.CustomInfo2("", tmpstr) = prop_val
            End If
        Next


        swAssy = modeldoc

        'Array der Komponenten

        comps = swAssy.GetComponents(True)

        'anzahl der Komponenten
        compcount = swAssy.GetComponentCount(True)

        'Schleife ein Durchlauf für jede Komponente
        For i = 0 To compcount - 1
            'Komponente

            If comps(i).GetSuppression <> SolidWorks.Interop.swconst.swComponentSuppressionState_e.swComponentSuppressed Then


                tmpmdl = comps(i).GetModelDoc2


                'Alle Propertys durchsuchen 
                ALLPROPS = tmpmdl.GetCustomInfoNames2("")
                For Each tmpstr As String In ALLPROPS
                    If UCase(prop_name) = UCase(tmpstr) Then
                        tmpmdl.CustomInfo2("", tmpstr) = prop_val
                    End If
                Next


                'Modellneuaufbau
                'tmpmdl.ForceRebuild3(False)
            End If
        Next (i)

        modeldoc.ForceRebuild3(True)
        MsgBox("wieder jup")

    End Sub


    'Kontrukteur für eine ganze Baugruppe ändern
    Public Sub CHANGE_DESIGNER(ByRef modeldoc As ModelDoc2)
        Dim newname As String = ""

        Dim form As New BG_OCU_NAME(newname)

        form.ShowDialog()

        newname = form.newname

        CHANGE_PROP_BG(modeldoc, "Konstrukteur", newname)

    End Sub


    'Eigenschaften aus Dateinamen übernehmen
    Public Sub PROPFROMFILE(ByRef doc As ModelDoc2, Optional ByVal Silent As Boolean = False)


        Dim Pfad As String
        Dim Dateiname As String = ""
        Dim Teilenummer_bez As String = "TNR"
        Dim Teilenummer_datei As String = ""
        Dim Name_bez As String = "Name"
        Dim Name_datei As String = ""
        Dim Pos_bez As String = "Position"
        Dim Pos_datei As String = ""
        Dim points As Long = 0
        'Dim TSTTNR As New MaiTeilenummer

        If IsNothing(doc) Then
            Exit Sub
            MsgBox("Kein Dokument geöffnet")
        End If

        'Pfad des Dokuments ermitteln
        Pfad = doc.GetPathName

        Try

            'Dateinamen aus Pfad extrahieren (ohne Endung)
            Dim lenght As Long = (Pfad.LastIndexOf(".") - (Pfad.LastIndexOf("\") + 1))
            Dateiname = Pfad.Substring(Pfad.LastIndexOf("\") + 1, lenght)

            'Teilenamen aus Dateinamen extrahieren
            Name_datei = Dateiname.Substring(Dateiname.IndexOf("-") + 1)

            'Teilenummer extrahieren
            Teilenummer_datei = Dateiname.Substring(0, Dateiname.IndexOf("-"))






            




        Catch ex As Exception
            Debug.Print("Fehler: Propfromfile Dateiname: " & Dateiname)
            Exit Sub
        End Try

        'If CHKTNR(Teilenummer_datei) = False Then
        'Throw New Exception
        'Exit Sub
        'End If


        'Ohne Benutzereingriff aber MIT Teilenummerncheck
        If Silent Then

            If CHKTNR(Teilenummer_datei) Then
                'Wenn ohne Benutzereingabe ausgeführt

                Pos_datei = Teilenummer_datei.Substring(Teilenummer_datei.LastIndexOf(".") + 1, Teilenummer_datei.Length - Teilenummer_datei.LastIndexOf(".") - 1)
                Pos_datei = FormatNumber(Pos_datei, 0, 0, 0, 0)


                CHANGEPROP(doc, Teilenummer_bez, Teilenummer_datei, False)
                CHANGEPROP(doc, Name_bez, Name_datei, False)
                CHANGEPROP(doc, Pos_bez, Pos_datei, True)
                '    doc.ForceRebuild3(True)
            End If


        Else
            'Wenn mit Benutzereingabe ausgeführt
            Dim form As New Frm_Eigensch

            form.propname = Name_datei
            form.teilenummer = Teilenummer_datei

            Try
                'Positionsnummer einfügen
                Pos_datei = Teilenummer_datei.Substring(Teilenummer_datei.LastIndexOf(".") + 1, Teilenummer_datei.Length - Teilenummer_datei.LastIndexOf(".") - 1)
                Pos_datei = FormatNumber(Pos_datei, 0, 0, 0, 0)
            Catch

            End Try


            form.Position = Pos_datei

            If CHKTNR(Teilenummer_datei) = False Then
                form.NormTNR = False
            End If

            'Form anzeigen
            form.ShowDialog()

            'Abbruch des Dialogs erkennen
            If form.exitstat Then

                CHANGEPROP(doc, Teilenummer_bez, form.teilenummer, False)
                CHANGEPROP(doc, Name_bez, form.propname, False)
                CHANGEPROP(doc, Pos_bez, Pos_datei, True)
                doc.ForceRebuild3(True)

            End If
        End If

    End Sub


    'Vorhandene Eigenschaften ändern
    Function CHANGEPROP(ByRef doc As ModelDoc2, ByVal propname As String, ByVal propvalue As String, ByVal force As Boolean) As Boolean

        Dim SwModelDocExt As ModelDocExtension = doc.Extension
        Dim SwPropMgr As CustomPropertyManager = SwModelDocExt.CustomPropertyManager("")

        Dim Prop_bez() As Object

        Prop_bez = SwPropMgr.GetNames

        For i = 0 To SwPropMgr.Count - 1

            If Prop_bez(i).ToString.ToUpper = propname.ToUpper Then
                propname = Prop_bez(i).ToString
                SwPropMgr.Set(propname, propvalue)
                Return True
                Exit Function
            End If

        Next

        'Eigenschaft anlegen wenn nicht vorhanden
        If force Then
            SwPropMgr.Add2(propname, swCustomInfoType_e.swCustomInfoText, propvalue)
            Return True
        End If

        Return False

    End Function


    ''' <summary>
    ''' Klasse für MAI-Teilenummern
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MaiTeilenummer


#Region "Eigenschaften"


        'Private ProjektNrValue As String
        Public Property ProjektNr As String
            Get

                Return CreateTnr()
            End Get
            Set(ByVal value As String)
                CheckinStr(value)
            End Set
        End Property


        Private BaugruppenNrValue As New List(Of String)
        Public Property BaugruppenNr As List(Of String)
            Get
                Return BaugruppenNrValue
            End Get
            Set(ByVal value As List(Of String))
                BaugruppenNrValue = value
            End Set
        End Property


        Private TeileNrValue As String
        Public Property TeileNr As String
            Get
                Return TeileNrValue
            End Get
            Set(ByVal value As String)
                TeileNrValue = value
            End Set
        End Property


        Private IndexValue As String
        Public Property Index As String
            Get
                Return IndexValue
            End Get
            Set(ByVal value As String)
                IndexValue = value
            End Set
        End Property


        Private TrennzeichenValue As String = "."
        Public Property Trennzeichen() As String
            Get
                Return TrennzeichenValue
            End Get
            Set(ByVal value As String)
                TrennzeichenValue = value
            End Set
        End Property




#End Region



#Region "Methoden"




        Public Sub New(Optional ByVal Teilenummer As String = "123456.12.12.12A")

            CheckinStr(Teilenummer)

        End Sub

        ''' <summary>
        ''' Teilenummer als String einchecken und Prüfen
        ''' </summary>
        ''' <param name="Teilenummer"></param>
        ''' <remarks></remarks>
        Private Sub CheckinStr(ByVal Teilenummer As String)
            Dim TrennzeichenPos As New List(Of Long)
            Dim k As Long = 0
            Dim str As String

            If CheckTnr(Teilenummer) Then

                'Trennzeichenpositionen ermitteln (-1 wg. Zeichenlänge Trennzeichen)
                For i = 0 To (Teilenummer.Length - 1)

                    If Teilenummer.Substring(i, 1) = Me.Trennzeichen Then
                        TrennzeichenPos.Add(i)
                        k = k + 1
                    End If
                Next


                'Index zurücksetzen
                k = 0


                'Projektnummer einlesen
                Me.ProjektNr = Teilenummer.Substring(0, TrennzeichenPos(k))
                Debug.Print("Projektnummer: " & Me.ProjektNr)


                'Baugruppennummern einlesen
                For i = 0 To (TrennzeichenPos.Count - 2)

                    Dim start As Long = TrennzeichenPos(i) + 1
                    Dim length As Long = TrennzeichenPos(i + 1) - TrennzeichenPos(i) - 1

                    Me.BaugruppenNr.Add(Teilenummer.Substring(start, length))
                    Debug.Print("Baugruppennummer " & i & ": " & Me.BaugruppenNr(i))

                Next


                'Teilenummer Einlesen
                str = Teilenummer.Substring(TrennzeichenPos(TrennzeichenPos.Count - 1) + 1)

                'Auf Index prüfen 
                If IsNumeric(str(str.Length - 2)) Then

                    Me.TeileNr = str.Substring(0, str.Length - 1)
                    Me.Index = str.Substring(str.Length - 1)

                    Debug.Print("Teilenummer: " & Me.TeileNr)
                    Debug.Print("Index: " & Me.Index)
                Else
                    Me.TeileNr = str
                    Debug.Print("Teilenummer: " & Me.TeileNr)
                End If


            Else

                '  Throw New ArgumentException("Falsches Format für Teilenummer")

            End If




        End Sub


        ''' <summary>
        ''' Erzeugt Komponentennummer (Teilenummer)
        ''' </summary>
        ''' <returns>Komponentennummer als String</returns>
        ''' <remarks></remarks>
        Private Function CreateTnr() As String
            Dim BGStr As String = ""
            Dim ReturnStr As String

            'Baugruppenkette zusammenbauen
            For Each item In Me.BaugruppenNr

                BGStr = BGStr & item

            Next

            'RückgabeString zusammenbauen
            ReturnStr = Me.ProjektNr & BGStr & Me.TeileNr & Me.Index

            Return ReturnStr

        End Function


        'Teilenummern aus String extrahieren 
        Public Function EXTRACTTNR(ByVal tnrstr As String) As String
            Const minlength As Long = 12
            Const maxlength As Long = 16

            Dim chklength As Long = 0
            Dim tnr As String = ""
            Dim tmpstr As String = ""


            ' Prüfen ob tnrstr nicht kleiner als minimale Nummernlänge
            If tnrstr.Length < 12 Then

                Return ""

            End If


            chklength = maxlength


            'Äußere Schleife: Suchlänge abrastern

            While chklength <> (minlength - 1)



                'Innerer Schleife: Mit Prüflänge durch String rotieren
                For i = 0 To tnrstr.Length - chklength

                    'Prüfen ob Teilenummer enthalten
                    'Debug.Print("Prüflänge: " & chklength & "  Prüfstring: " & tnrstr.Substring(i, chklength))


                    If CheckTnr(tnrstr.Substring(i, chklength)) Then
                        'Debug.Print("Treffer: " & tnrstr.Substring(i, chklength))
                        Return tnrstr.Substring(i, chklength)
                    End If

                Next

                ' Prüflänge erhöhen
                chklength = chklength - 1
            End While






            Return ""



        End Function


        'Teilenummern überprüfen
        Private Function CheckTnr(ByVal tnrstr As String) As Boolean

            Dim validchars As String = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim validindex As Boolean = False



            'Prüfen ob Index zuglassene Zeichen enthält
            If tnrstr.Length = 16 Then
                For Indexchar = 0 To validchars.Length - 1
                    If tnrstr(15) = validchars(Indexchar) Then
                        validindex = True
                        Exit For
                    End If
                Next
            End If

            If tnrstr.Length = 13 Then
                For Indexchar = 0 To validchars.Length - 1
                    If tnrstr(12) = validchars(Indexchar) Then
                        validindex = True
                        Exit For
                    End If
                Next
            End If


            'Index entfernen
            If Len(tnrstr) = 13 And validindex Then
                tnrstr = tnrstr.Remove(12)
            End If

            'index entfernen
            If Len(tnrstr) = 16 And validindex Then
                tnrstr = tnrstr.Remove(15)
            End If


            'Stellen prüfen
            If Len(tnrstr) <> 15 And Len(tnrstr) <> 12 Then
                Return False
            End If


            'Stellen 1-6 numerisch
            If IsNumeric(Mid(tnrstr, 6)) = False Then
                Return False
            End If


            'Stelle 7 ein Punkt
            If Mid(tnrstr, 7, 1) <> "." Then
                Return False
            End If


            'Stelle 8-9 nummerisch
            If IsNumeric(Mid(tnrstr, 8, 2)) = False Then
                Return False
            End If


            'Stelle 10 ein Punkt
            If Mid(tnrstr, 10, 1) <> "." Then
                Return False
            End If


            'Stelle 11-12 nummerisch
            If IsNumeric(Mid(tnrstr, 11, 2)) = False Then
                Return False
            End If


            'Stelle 10 ein Punkt und String 15 Zeichen lang
            If (Len(tnrstr) = 15) And (Mid(tnrstr, 13, 1) = ".") = False Then
                Return False
            End If

            'Stelle 14-15 Numerisch und String 15 Zeichen lang
            If (Len(tnrstr) = 15) And IsNumeric(Mid(tnrstr, 14, 2)) = False Then
                Return False
            End If

            Return True



        End Function


        ''' <summary>
        ''' Beantwortet die Frage ob die Komponentennummer eine Baugruppennummer ist.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsBaugruppe() As Boolean



            If Me.TeileNr = "00" Then

                Return True

            Else

                Return False

            End If

        End Function


        ''' <summary>
        ''' Beantwortet die Frage ob die Komponentennummer eine Teilenummer ist.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsTeil() As Boolean

            Return Not Me.IsBaugruppe

        End Function


#End Region
    End Class








    'Teilenummern überprüfen
    Public Function CHKTNR(ByVal tnrstr As String) As Boolean

        Dim validchars As String = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim validindex As Boolean = False

        'Prüfen ob Index zuglassene Zeichen enthält
        If tnrstr.Length = 16 Then
            For index = 0 To validchars.Length - 1
                If tnrstr(15) = validchars(index) Then
                    validindex = True
                    Exit For
                End If
            Next
        End If

        If tnrstr.Length = 13 Then
            For index = 0 To validchars.Length - 1
                If tnrstr(12) = validchars(index) Then
                    validindex = True
                    Exit For
                End If
            Next
        End If


        'Index entfernen
        If Len(tnrstr) = 13 And validindex Then
            tnrstr = tnrstr.Remove(12)
        End If

        'index entfernen
        If Len(tnrstr) = 16 And validindex Then
            tnrstr = tnrstr.Remove(15)
        End If


        'Stellen prüfen
        If Len(tnrstr) <> 15 And Len(tnrstr) <> 12 Then
            Return False
        End If


        'Stellen 1-6 numerisch
        If IsNumeric(Mid(tnrstr, 6)) = False Then
            Return False
        End If


        'Stelle 7 ein Punkt
        If Mid(tnrstr, 7, 1) <> "." Then
            Return False
        End If


        'Stelle 8-9 nummerisch
        If IsNumeric(Mid(tnrstr, 8, 2)) = False Then
            Return False
        End If


        'Stelle 10 ein Punkt
        If Mid(tnrstr, 10, 1) <> "." Then
            Return False
        End If


        'Stelle 11-12 nummerisch
        If IsNumeric(Mid(tnrstr, 11, 2)) = False Then
            Return False
        End If


        'Stelle 10 ein Punkt und String 15 Zeichen lang
        If (Len(tnrstr) = 15) And (Mid(tnrstr, 13, 1) = ".") = False Then
            Return False
        End If

        'Stelle 14-15 Numerisch und String 15 Zeichen lang
        If (Len(tnrstr) = 15) And IsNumeric(Mid(tnrstr, 14, 2)) = False Then
            Return False
        End If

        Return True



    End Function


    'Eigenschaften für komplette Baugruppe (und Unterkomponenten) aus Dateinamen übernehmen.
    Public Function PROPFROMFILE_BG(ByRef doc As ModelDoc2) As Boolean

        Dim swAssy As AssemblyDoc
        'Dim comps() As Component2
        Dim comps() As Object
        Dim compcount As Long
        Dim tmpmdl As ModelDoc2




        If doc.GetType <> swDocumentTypes_e.swDocASSEMBLY Then
            MsgBox("Aktives Dokument ist keine Baugruppe!")
            Return False
            Exit Function
        End If


        'Eigenschaften in Baugruppe Ändern 
        PROPFROMFILE(doc, True)


        swAssy = doc

        'Array der Komponenten

        comps = swAssy.GetComponents(True)

        'anzahl der Komponenten
        compcount = swAssy.GetComponentCount(True)

        'Schleife ein Durchlauf für jede Komponente
        For i = 0 To compcount - 1
            'Komponente

            If comps(i).GetSuppression <> SolidWorks.Interop.swconst.swComponentSuppressionState_e.swComponentSuppressed Then


                tmpmdl = comps(i).GetModelDoc2


                'Alle Propertys durchsuchen 
                PROPFROMFILE(tmpmdl, True)
            End If
        Next (i)


        doc.ForceRebuild3(False)
        MsgBox("wieder jup")
        Return True

    End Function

#End Region


#Region "Baugruppenoperationen"
    'Limitiertes Maß
    Public Sub LIMIT_MATE(ByRef doc As ModelDoc2)
        Dim swSelMgr As SelectionMgr
        Dim mate As Mate2
        Dim assem As AssemblyDoc
        Dim SelType1 As swSelectType_e
        Dim SelType2 As swSelectType_e


        If doc.GetType <> swDocumentTypes_e.swDocASSEMBLY Then
            Throw New AggregateException
        End If

        swSelMgr = doc
        SelType1 = swSelMgr.GetSelectedObjectType3(1, -1)
        SelType2 = swSelMgr.GetSelectedObjectType3(2, -1)

    End Sub

    ''' <summary>
    ''' Fixiert alle Komponenten im der Baugruppe und allen ihren Unterbaugruppen
    ''' </summary>
    ''' <param name="doc">Model (Baugruppe ) als sldworks.ModelDoc"</param>
    ''' <remarks></remarks>
    Public Sub FixAllComponents(ByRef doc As ModelDoc2)

        Dim components As Object 'List(Of Component2)
        Dim SwAssy As AssemblyDoc
        Dim SelMgr As SelectionMgr
        Dim Komponente As ModelDoc2
        Dim seldat As SelectData


        'Prüfen ob das Dokument eine Baugruppe ist
        If doc.GetType <> swDocumentTypes_e.swDocASSEMBLY Then

            MsgBox("Dokument ist keine Baugruppe!")
            Throw New AggregateException

        End If

        'Assembly aus Model 
        SwAssy = doc

        'Selection Manager aus Model
        SelMgr = doc.ISelectionManager

        seldat = SelMgr.CreateSelectData

        'alle selektionen löschen
        doc.ForceRebuild3(True)


        'Komponenten der Baugruppe erhalten
        components = SwAssy.GetComponents(True)


        'Jede Komponente selektieren elche nicht schon fixert ist
        For Each item As Component2 In components

            If item.IsFixed = False Then
                item.Select4(True, seldat, False)
            End If


        Next

        'selektierte komponenten fixieren
        SwAssy.FixComponent()


        'Jede komponente prüfen ob sie eine Baugruppe ist, wenn ja "FixAllComponents" (rekursiv) aufrufen
        For Each item As Component2 In components


            Komponente = item.GetModelDoc2()

            If Komponente.GetType = swDocumentTypes_e.swDocASSEMBLY Then

                'rekursives Aufrufen von sich selbst
                FixAllComponents(Komponente)


            End If


        Next

        'Neuaufbau
        doc.ForceRebuild3(True)

    End Sub

    Public Function GetModelKoordinaten(ByVal Punkt As Object, ByVal Transform As MathTransform, ByVal swapp As SldWorks) As MathPoint

        Dim swMathUtil As MathUtility

        swMathUtil = swapp.GetMathUtility

        Dim swMathPoint As MathPoint

        swMathPoint = swMathUtil.CreatePoint(Punkt)



        Transform.Inverse()

        swMathPoint.MultiplyTransform(Transform)

        Return swMathPoint



    End Function

    Public Sub Schutzzaun(ByVal Modeldoc As ModelDoc2, ByVal swapp As SldWorks)

        Dim SwAssy As AssemblyDoc
        Dim SelMgr As SelectionMgr
        Dim seldat As SelectData
        Dim featureo As Feature
        Dim sketch As Sketch
        Dim lines As Object
        Dim points As New List(Of MathPoint)
        Dim komponente As Component2
        Dim transform As MathTransform
        Dim ist3DSkizze As Boolean = False


        'Prüfen ob das Dokument eine Baugruppe ist
        If Modeldoc.GetType <> swDocumentTypes_e.swDocASSEMBLY Then

            MsgBox("Dokument ist keine Baugruppe!")
            Throw New AggregateException

        End If

        'Assembly aus Model 
        SwAssy = Modeldoc

        'Selection Manager aus Model
        SelMgr = Modeldoc.ISelectionManager

        'SelectData Objekt erzeugen
        seldat = SelMgr.CreateSelectData

        'Das Objekt das selektiert wurde einem Feature-Objekt zuweisen
        featureo = SelMgr.GetSelectedObject6(1, -1)

        'Skizze aus dem Feature extruieren
        sketch = featureo.GetSpecificFeature2()

        'linien 
        lines = sketch.GetSketchSegments

        'Prüfen ob Skizze eine 3D-Skizze ist. Eine
        '2D-Skizze 
        If sketch.Is3D = False Then
            transform = sketch.ModelToSketchTransform
        Else

            transform = Nothing

        End If


        For Each item As SketchLine In lines
            Dim punkt As MathPoint

            punkt. = item.GetStartPoint2

            If sketch.Is3D = False Then

                punkt = GetModelKoordinaten(punkt, transform, swapp)


            End If




            'MsgBox("X: " & punkt.X & vbNewLine & _
            '     "Y: " & punkt.Y & vbNewLine & _
            '      "Z: " & punkt.Z)

            points.Add(punkt)
        Next



        For Each item In points

            MsgBox("X: " & item.X & vbNewLine & _
                   "Y: " & item.Y & vbNewLine & _
                   "Z: " & item.Z)
            komponente = SwAssy.AddComponent5("DP-F-2200 Durchgangspfosten.SLDPRT", False, "", False, "", item.X, item.Y, item.Z)

        Next





        'alle selektionen löschen
        'Modeldoc.ForceRebuild3(True)





    End Sub
#End Region

#Region "Skizzenoperationen"
    ' 4 Punkte Symetrisch zu 2 Achsen ausrichten
    Public Sub BohrbildSym(ByRef doc As ModelDoc2)
        Dim ActiveSketch As Sketch = GetActiveSketch(doc)

        Dim Linienlaenge As Double = 0.1
        Dim Punktabstand As Double = 0.05

        Dim Linie1 As SketchSegment
        Dim Linie2 As SketchSegment

        Dim Punkt1 As SketchPoint
        Dim Punkt2 As SketchPoint
        Dim Punkt3 As SketchPoint
        Dim Punkt4 As SketchPoint




        If IsNothing(ActiveSketch) Then
            Exit Sub
        End If

        doc.SketchManager.AddToDB = True

        'Automatische Verknüpfungen deaktivieren
        doc.SketchManager.AutoInference = False



        'Mittelllinien erzeugen
        Linie1 = doc.SketchManager.CreateLine(0, -0.1, 0, 0, 0.1, 0)
        Linie2 = doc.SketchManager.CreateLine(-0.1, 0, 0, 0.1, 0, 0)

        Linie1.ConstructionGeometry = True
        Linie2.ConstructionGeometry = True

        'Auswahlen löschen
        doc.ClearSelection2(True)




        'Linien selektieren
        Linie1.Select4(False, Nothing)
        doc.SketchAddConstraints("sgVERTICAL2D")
        Linie2.Select4(False, Nothing)
        doc.SketchAddConstraints("sgHORIZONTAL2D")

        Linie1.Select4(False, Nothing)
        Linie2.Select4(True, Nothing)




        doc.SketchAddConstraints("sgSAMELENGTH")
        doc.SketchAddConstraints("sgATMIDDLE")

        'Punkte erzeugen
        doc.ClearSelection2(True)
        Punkt1 = doc.SketchManager.CreatePoint(Punktabstand, Punktabstand, 0)
        Punkt2 = doc.SketchManager.CreatePoint(Punktabstand * -1, Punktabstand, 0)
        Punkt3 = doc.SketchManager.CreatePoint(Punktabstand * -1, Punktabstand * -1, 1)
        Punkt4 = doc.SketchManager.CreatePoint(Punktabstand, Punktabstand * -1, 1)

        '
        Linie1.Select4(False, Nothing)
        Punkt1.Select4(True, Nothing)
        Punkt2.Select4(True, Nothing)
        doc.SketchAddConstraints("sgSYMMETRIC")

        '
        Linie1.Select4(False, Nothing)
        Punkt3.Select4(True, Nothing)
        Punkt4.Select4(True, Nothing)
        doc.SketchAddConstraints("sgSYMMETRIC")

        '
        Linie2.Select4(False, Nothing)
        Punkt1.Select4(True, Nothing)
        Punkt4.Select4(True, Nothing)
        doc.SketchAddConstraints("sgSYMMETRIC")

        '
        Punkt1.Select4(False, Nothing)
        Punkt2.Select4(True, Nothing)
        doc.AddDimension2(0, Punktabstand * 1.1, 0)

        '
        Punkt1.Select4(False, Nothing)
        Punkt4.Select4(True, Nothing)
        doc.AddDimension2(Punktabstand * 1.1, 0, 0)



        doc.SketchManager.AutoInference = True
        doc.SketchManager.AddToDB = False

    End Sub


    'Fremdcode!!!
    ''' <summary>
    ''' Ermittelt die aktive Skizze (in Bearbeitung)
    ''' eines SolidWorks Dokuments und gibt
    ''' dieses als SldWorks.Sktech Objekt zurück
    ''' </summary>
    ''' <param name="oSwModel">
    ''' Betroffenes SolidWorks Dokument</param>
    ''' <returns>Aktive Skizze oder Nothing
    ''' wenn keine Skizze aktiv ist</returns>
    Private Function GetActiveSketch(ByVal oSwModel As ModelDoc2) As Sketch

        Dim oSwSketch As Sketch
        oSwSketch = CType(oSwModel.GetActiveSketch2(), Sketch)
        If oSwSketch Is Nothing Then
            Trace.WriteLine( _
                    "Es ist keine Skizze im Dokument " & _
                    oSwModel.GetTitle & " aktiv.")
            Return Nothing
        Else
            Return oSwSketch
        End If
    End Function



#End Region


End Class
