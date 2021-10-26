Imports Simphony.Simulation

Public Class Form1

    Dim MyEngine As New DiscreteEventEngine



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RunSimulation()
    End Sub


    Private Sub RunSimulation()

        Dim MyModel As New Model(MyEngine, Me)

        'Initialization
        MyEngine.InitializeEngine()

        MyEngine.Simulate(MyModel)



    End Sub


End Class
