Imports Simphony.Simulation
Imports Simphony.Mathematics

Public Class Scenario
    Inherits DiscreteEventScenario

    Private ReadOnly MyEngine As DiscreteEventEngine

    Private RequestResourceEvent As New Action(Of Truck)(AddressOf RequestResource)
    Private ResourceIsCapturedEvent As New Action(Of Truck)(AddressOf ResourceIsCaptured)
    Private ReleaseResourceEvent As New Action(Of Truck)(AddressOf ReleaseResource)

    'Resource
    Private LargeLoaders, SmallLoaders As LoaderResource
    Private LargeLoaderCount, SmallLoaderCount As Integer

    Private ReadOnly MyFile As New WaitingFile("MyFile")                '****************

    Private MyNumericStatistic As NumericStatistic
    Private MyForm As Form1


    Private ReadOnly TotalSimulationTime As Double = 2000


    'Ctor
    Public Sub New(ByVal Engine1 As DiscreteEventEngine, ByVal NumLargeLoaders As Integer, ByVal NumSmallLoaders As Integer, ByVal Form As Form1)
        MyEngine = Engine1
        LargeLoaderCount = NumLargeLoaders
        SmallLoaderCount = NumSmallLoaders
        MyForm = Form
    End Sub


    Public Overrides Function InitializeScenario() As Integer
        LargeLoaders = New LoaderResource("LargeLoaders", LargeLoaderCount, "Large")
        SmallLoaders = New LoaderResource("SmallLoaders", SmallLoaderCount, "Small")
        LargeLoaders.WaitingFiles.Add(MyFile)
        SmallLoaders.WaitingFiles.Add(MyFile)

        MyNumericStatistic = New NumericStatistic("CT", False)

        Return 1
    End Function

    Public Overrides Function InitializeRun(runIndex As Integer) As Double
        LargeLoaders.InitializeRun(runIndex)                                '****************
        SmallLoaders.InitializeRun(runIndex)                                '****************
        MyFile.InitializeRun(runIndex)                                      '****************
        MyNumericStatistic.InitializeRun(runIndex)

        For i As Integer = 1 To 10
            Dim MyTruck As New Truck
            If i Mod 2 = 0 Then
                MyTruck.Type = "Small"
                MyTruck.Size = 10
            Else
                MyTruck.Type = "Large"
                MyTruck.Size = 20
            End If

            MyEngine.ScheduleEvent(MyTruck, RequestResourceEvent, 10)

        Next

        Return Double.PositiveInfinity
    End Function

    Private Sub RequestResource(MyTruck As Truck)

        MyTruck.StartTime = MyEngine.TimeNow

        If MyTruck.Type = "Large" Then
            MyEngine.RequestResource(MyTruck, LargeLoaders, 1, ResourceIsCapturedEvent, MyFile)
        Else
            MyEngine.RequestResource(MyTruck, SmallLoaders, 1, ResourceIsCapturedEvent, MyFile)
        End If

    End Sub

    Private Sub ResourceIsCaptured(MyTruck As Truck)
        MyEngine.ScheduleEvent(MyTruck, ReleaseResourceEvent, 20)
    End Sub

    Private Sub ReleaseResource(MyTruck As Truck)

        If MyTruck.Type = "Large" Then
            MyEngine.ReleaseResource(MyTruck, LargeLoaders, 1)
        Else
            MyEngine.ReleaseResource(MyTruck, SmallLoaders, 1)
        End If

        MyEngine.CollectStatistic(MyNumericStatistic, MyEngine.TimeNow - MyTruck.StartTime)

    End Sub

    Public Overrides Sub FinalizeRun(runIndex As Integer)

    End Sub

    Public Overrides Sub FinalizeScenario()

        Dim Mean As Double = MyNumericStatistic.Mean
        Dim StandardDeviation As Double = MyNumericStatistic.StandardDeviation

        MyForm.ListBox1.Items.Add("Mean= " & Mean.ToString & ", Standard Deviation= " & StandardDeviation.ToString)
    End Sub


End Class
