Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic



Public Class RobotTools

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
            Return _ModelDoc
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

    Private _Koordinatensytem As CoordinateSystemFeatureData
    Public Property Koordinatensystem() As CoordinateSystemFeatureData
        Get
            Return _Koordinatensytem
        End Get
        Set(ByVal value As CoordinateSystemFeatureData)
            _Koordinatensytem = value
        End Set
    End Property


    Dim WithEvents TraegheitsForm As New Form_Traegheit


#End Region

#Region "Events"

    Sub AttachSWEvents()
        Try
            AddHandler _AssemblyDoc.NewSelectionNotify, AddressOf Selection_Change
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    Private Function Selection_Change() As Integer Handles _AssemblyDoc.NewSelectionNotify
       
        Dim OFeature As Feature

        If SelMgr.GetSelectedObjectType3(1, -1) = swSelectType_e.swSelCOORDSYS Then

            OFeature = SelMgr.GetSelectedObject6(1, -1)

            Koordinatensystem = OFeature.GetDefinition

            TraegheitsForm.Label_Select.Text = OFeature.Name

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


        Else
            MsgBox("Dokument ist keine Baugruppe!")
            Me.Finalize()

        End If

    End Sub





    Private Sub Traegheit()

        Dim Ausgabetext As String = ""

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
            " Lx= " & SchwerpunktKoordinaten(0) & "mm" & vbNewLine & _
            " Ly= " & SchwerpunktKoordinaten(1) & "mm" & vbNewLine & _
            " Lz= " & SchwerpunktKoordinaten(2) & "mm" & vbNewLine & _
            vbNewLine & vbNewLine & _
            "Trägheitsmomente bezogen auf Massemittelpunkt" & vbNewLine & _
            " Ix= " & MTM(0) & "kgm²" & vbNewLine & _
            " Iy= " & MTM(4) & "kgm²" & vbNewLine & _
            " Iz= " & MTM(8) & "kgm²"


        TraegheitsForm.TextBox_Ergebniss.Text = Ausgabetext



    End Sub



End Class
