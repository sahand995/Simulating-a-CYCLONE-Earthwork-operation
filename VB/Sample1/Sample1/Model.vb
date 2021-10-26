Imports Simphony.Simulation

Public Class Model
    Implements IModel

    Dim MyEngine As DiscreteEventEngine

    'Private ReadOnly MyScenario As Scenario                         '*************
    Private MyScenarios As New List(Of IScenario)

    'Ctor
    Public Sub New(ByVal Engine1 As DiscreteEventEngine, ByVal MyForm As Form1)

        MyEngine = Engine1


        Dim Scenario1 As New Scenario(MyEngine, 1, 1, MyForm)
        MyScenarios.Add(Scenario1)

        Dim Scenario2 As New Scenario(MyEngine, 1, 2, MyForm)
        MyScenarios.Add(Scenario2)

        Dim Scenario3 As New Scenario(MyEngine, 2, 1, MyForm)
        MyScenarios.Add(Scenario3)

        Dim Scenario4 As New Scenario(MyEngine, 2, 2, MyForm)
        MyScenarios.Add(Scenario4)



    End Sub



    Public ReadOnly Property Scenarios As IEnumerable(Of IScenario) Implements IModel.Scenarios
        Get
            Return MyScenarios
        End Get
    End Property

    Public Sub FinalizeModel() Implements IModel.FinalizeModel
        'Throw New NotImplementedException()
    End Sub

    Public Sub InitializeModel() Implements IModel.InitializeModel
        'Throw New NotImplementedException()
    End Sub
End Class
