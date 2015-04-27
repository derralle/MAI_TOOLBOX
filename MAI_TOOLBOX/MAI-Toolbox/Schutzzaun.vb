Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic


Public Class Schutzzaun



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
        Dim swMathUtil As MathUtility

        swMathUtil = swapp.GetMathUtility

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
            'Transform Matrix erstellen 
            transform = sketch.ModelToSketchTransform

            'Umkehrmatrix erzeugen
            transform = transform.Inverse


        Else

            transform = Nothing

        End If

        'Linienarray durchlaufen
        For Each item As SketchLine In lines

            Dim mpunkt As MathPoint
            Dim spunkt As SketchPoint
            Dim coords(2) As Double


            'Startkoordinaten Skizzenpunkt 
            spunkt = item.GetStartPoint2



            coords(0) = spunkt.X
            coords(1) = spunkt.Y
            coords(2) = spunkt.Z

            mpunkt = swMathUtil.CreatePoint(coords)



            'punkt.ArrayData = item.GetStartPoint2

            If sketch.Is3D = False Then

                mpunkt = mpunkt.MultiplyTransform(transform)

            End If


            points.Add(mpunkt)

        Next






        For Each item As MathPoint In points

            '' MsgBox("X: " & item.X & vbNewLine & _
            ''        "Y: " & item.Y & vbNewLine & _
            ''        "Z: " & item.Z)
            komponente = SwAssy.AddComponent5("DP-F-2200 Durchgangspfosten.SLDPRT", False, "", False, "", item.ArrayData(0), item.ArrayData(1), item.ArrayData(2))

        Next





        'alle selektionen löschen
        'Modeldoc.ForceRebuild3(True)





    End Sub
End Class
