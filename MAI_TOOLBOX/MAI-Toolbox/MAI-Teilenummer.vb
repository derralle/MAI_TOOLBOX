Imports System.Collections.Generic

''' <summary>
''' Klasse für MAI-Teilenummern
''' </summary>
''' <remarks></remarks>
Public Class MAI_Teilenummer

    Private Const Projektnummerlaenge As Long = 6
    Private Const BGNummerlaenge As Long = 2
    Private Const Teilenummerlaenge As Long = 2
    Private Const maxBGTiefe As Long = 3
    Private Const Indexlaenge As Long = 1


#Region "Eigenschaften"




    Private ProjektNrValue As String
    Public Property ProjektNr As String
        Get

            Return ProjektNrValue
        End Get
        Set(ByVal value As String)
            ProjektNrValue = value
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


    Public ReadOnly Property Gueltig As Boolean
        Get

            Return CheckAll()

        End Get
    End Property


#End Region



#Region "Methoden"




    Public Sub New(Optional ByVal Teilenummer As String = "123456.12.12.12A")

        CheckinStr(Teilenummer)

    End Sub


    Public Shared Narrowing Operator CType(ByVal Teilenummer As String) As MAI_Teilenummer
        Return New MAI_Teilenummer(Teilenummer)
    End Operator



    ''' <summary>
    ''' Teilenummer als String einchecken und Prüfen
    ''' </summary>
    ''' <param name="Teilenummer"></param>
    ''' <remarks></remarks>
    Private Sub CheckinStr(ByVal Teilenummer As String)
        Dim TrennzeichenPos As New List(Of Long)
        Dim k As Long = 0
        Dim str As String



        ' If CheckTnr(Teilenummer) Then

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
        'If IsNumeric(str(str.Length - 2)) Then

        If str.Length <> Teilenummerlaenge Then

            Me.TeileNr = str.Substring(0, str.Length - 1)
            Me.Index = str.Substring(str.Length - 1)

            Debug.Print("Teilenummer: " & Me.TeileNr)
            Debug.Print("Index: " & Me.Index)
        Else
            Me.TeileNr = str
            Debug.Print("Teilenummer: " & Me.TeileNr)
        End If


        'Else

        '  Throw New ArgumentException("Falsches Format für Teilenummer")

        'End If




    End Sub


    ''' <summary>
    ''' Erzeugt Komponentennummer (Teilenummer)
    ''' </summary>
    ''' <returns>Komponentennummer als String</returns>
    ''' <remarks></remarks>
    Public Function CreateTnr() As String
        Dim BGStr As String = ""
        Dim ReturnStr As String

        'Baugruppenkette zusammenbauen
        For Each item In Me.BaugruppenNr

            BGStr = BGStr & item & Me.Trennzeichen

        Next

        'RückgabeString zusammenbauen
        ReturnStr = Me.ProjektNr & Me.Trennzeichen & BGStr & Me.TeileNr & Me.Index

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
    Public Function IstTeil() As Boolean

        Return Not Me.IsBaugruppe

    End Function

    ''' <summary>
    ''' Fragt Tiefe der Baugruppe ab
    ''' </summary>
    ''' <returns>Tiefe der Baugruppe </returns>
    ''' <remarks></remarks>
    Public Function BGTiefe() As Long
        Return Me.BaugruppenNr.Count
    End Function


    ''' <summary>
    ''' Checkt Baugruppennummern
    ''' </summary>
    ''' <returns>False wenn Baugruppennummern nicht gültig</returns>
    ''' <remarks></remarks>
    Private Function CheckBG() As Boolean


        'Tiefe prüfen
        If BGTiefe() >= maxBGTiefe Then

            Return False

        End If


        For Each item In Me.BaugruppenNr

            'Prüfen ob Baugruppennummer numerisch ist
            If IsNumeric(item) = False Then
                Return False
            End If

            'Prüfen ob Baugruppennummer die richtige Länge hat
            If item.Length <> BGNummerlaenge Then
                Return False
            End If

        Next

        Return True

    End Function


    ''' <summary>
    ''' Checkt Projektnummern
    ''' </summary>
    ''' <returns> False wenn Projektnummer nicht gültig</returns>
    ''' <remarks></remarks>
    Private Function CheckProjektNr() As Boolean

        'Prüfen ob Projektnummer die richtige Länge hat
        If Me.ProjektNr.Length <> Projektnummerlaenge Then
            Return False
        End If

        'Prüfen ob Projektnummer Numerisch ist
        If IsNumeric(Me.ProjektNr) = False Then
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Checkt Teilenummern
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckTeilenummer() As Boolean

        'Prüfen ob Teilenummer numerisch ist
        If IsNumeric(Me.TeileNr) = False Then
            Return False
        End If

        'Richtige Länge prüfen
        If Me.TeileNr.Length <> Teilenummerlaenge Then
            Return False
        End If

        Return True

    End Function


    ''' <summary>
    ''' Checkt Index
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIndex() As Boolean

        Dim validchars As String = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim switch As Boolean = False

        'Prüfen ob Index vorhanden ist

        If Me.Index = "" Or Nothing Then
            Return True
        End If


        'Prüfen ob Teilenummer numerisch ist
        For Each item As Char In validchars

            If item = Index Then
                switch = True
                Exit For
            Else
                switch = False
            End If
        Next
       



        'Richtige Länge prüfen
        If Me.Index.Length = Indexlaenge Then
            switch = True
        Else
            switch = False
        End If

        Return switch
    End Function

    Private Function CheckAll() As Boolean

        If CheckProjektNr() And CheckBG() And CheckTeilenummer() And CheckIndex() Then
            Return True
        End If

        Return False

    End Function





#End Region

End Class
