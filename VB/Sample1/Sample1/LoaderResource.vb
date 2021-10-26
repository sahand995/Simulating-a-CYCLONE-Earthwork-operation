Imports Simphony.Simulation

Public Class LoaderResource
    Inherits Resource

    Public Type As String

    Public Sub New(ByVal name As String, ByVal servers As Integer, ByVal type As String)
        Me.Name = name
        Me.Servers = servers
        Me.Type = type
    End Sub
End Class
