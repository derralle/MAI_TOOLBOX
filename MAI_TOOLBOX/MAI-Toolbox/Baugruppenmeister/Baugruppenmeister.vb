
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic
Imports MAI_TOOLBOX

Public Class Baugruppenmeister

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

    Private _modeldoc As ModelDoc2
    Public Property modeldoc() As ModelDoc2
        Get
            Return _modeldoc
        End Get
        Set(ByVal value As ModelDoc2)
            _modeldoc = value
        End Set
    End Property






    Dim Form As New FRM_Baugruppenmeister
    Dim Dataset As New BG_Dataset


    Public Sub New()

        Me.modeldoc = swApp.ActiveDoc

        If Me.modeldoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then

            Form.DataGridView1.DataSource = Dataset.Baugruppe
            Form.Show()

        End If

        Me.Finalize()

    End Sub

    Private Sub FillTable()


        Dim Table As DataTable
        Dim Row As DataRow

        Dim Assembly As AssemblyDoc


        Table = Dataset.Baugruppe

        Assembly = Me.modeldoc







    End Sub





End Class
