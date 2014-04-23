Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic


Public Class RobotSim

    'SolidWorks-App
    Private _SwApp As ISldWorks
    Public Property SwApp() As ISldWorks
        Get
            Return _SwApp
        End Get
        Set(ByVal value As ISldWorks)
            _SwApp = value
        End Set
    End Property


    Sub New(ByRef swinst As ISldWorks)
        Me.SwApp = swinst
    End Sub





End Class
