Option Strict On
Imports System.ComponentModel
Imports RmosEngine.GreyWolfOptimizer
Imports IOOperations
Imports IOOperations.Components

Public Class ReportForm
    Friend Chronos As Stopwatch
    Dim Duration As Long = 0
    Public Shared BestScore As Double
    Dim EngineIndex As Int32 = 0
    Dim folder As String = "E:\RMOS_GA_GSA_HPSOGWO_Results"
    Dim BestScoresList As New List(Of DataSerie1D)

    Private Sub BtnLuanch_Click(sender As Object, e As EventArgs) Handles BtnLuanch.Click
        'Chronos = New Stopwatch()
        'Chronos.Start()
        'BackgroundWorker1.RunWorkerAsync()

    End Sub

    Sub Calculate()
        Try
            HPSOGWO_Engine = New HybridPSOGWOEngine() With {.OptimizationType = RmosEngine.OptimizationTypeEnum.Minimization}

            Dim maxIter As Int32 = 3000

            With HPSOGWO_Engine

                .Max_Iteration = maxIter

                .TotalTimePeriod = 36
                .Initial_Storage = 117.543
                .Reservoir = TheReservoir
                .InflowSerie = TheReservoir.Inflow
                .Demands = TheReservoir.Downstream
            End With

            '------------------------------------------
            Dim population(4) As Integer
            population(0) = 10
            population(1) = 30
            population(2) = 50
            population(3) = 70
            population(4) = 100
            '--------------------------------------------
            Dim C1s(4) As Double
            C1s(0) = 0.2
            C1s(1) = 0.4
            C1s(2) = 0.5
            C1s(3) = 0.6
            C1s(4) = 0.8
            '--------------------------------------------
            Dim C2s(4) As Double
            C2s(0) = 0.2
            C2s(1) = 0.4
            C2s(2) = 0.5
            C2s(3) = 0.6
            C2s(4) = 0.8
            '--------------------------------------------
            Dim C3s(4) As Double
            C3s(0) = 0.2
            C3s(1) = 0.4
            C3s(2) = 0.5
            C3s(3) = 0.6
            C3s(4) = 0.8
            '---------------------

            Dim BestChartList As New DataSerie3D()
            With BestChartList
                .Title = "Scenario"
                .X_Title = "Best"
                .Y_Title = "Worst"
                .Z_Title = "Avearge"
            End With

            Dim folder As String = "E:\HPSOGWO_Results"
            Dim fileName As String = String.Empty
            Dim title As String = String.Empty
            Dim saving As Boolean = False
            Dim csvWriter As CsvFileIO

            Dim counter As Integer = 0

            With HPSOGWO_Engine
                For t = 2 To 4
                    .C_3 = C3s(t)

                    For i = 0 To 4
                        .C_2 = C2s(i)

                        For j = 0 To 4
                            .C_1 = C1s(j)

                            For k = 0 To 4
                                counter += 1

                                .Agents_N = population(k)

                                .Luanch_Optimization()

                                BestScore = .Score_Alpha

                                BestChartList.Add(String.Format("C3= {0} ; C2= {1} ; C1= {2} ; Population = {3} : ", .C_3, .C_2, .C_1, .Agents_N), .Performance(0).Data((maxIter - 1)).X_Value, .Performance(0).Data((maxIter - 1)).Y_Value, .Performance(0).Data((maxIter - 1)).Z_Value)

                                BackgroundWorker1.ReportProgress(counter)
                            Next k
                        Next j

                        title = String.Format("HPSOGWO_C3_{0}_C2_{1}.CSV", (.C_3 * 10), (.C_2 * 10))
                        fileName = String.Format("{0}\{1}", folder, title)
                        csvWriter = New CsvFileIO(fileName)
                        saving = csvWriter.Write(BestChartList)
                        BestChartList.Data.Clear()
                    Next i
                Next t
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Sub Display(msg As String)
        MsgBox(msg, MsgBoxStyle.Information)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If BackgroundWorker1.CancellationPending Then
            e.Cancel = True
        Else
            Select Case EngineIndex
                Case 0
                    Exit Sub
                Case 1
                    RunGA()
                Case 2
                    RunGSA()
                Case 3
                    RunHPSOGWO()
                Case 4
                    Calculate()
            End Select

        End If

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Label1.Text = String.Format("Operation = {0} Over 10.", e.ProgressPercentage)

        ListBox1.Items.Add(String.Format("Duration of Operation {0} is : {1} Mnts. | Total time : {2}| Best ={3}.", e.ProgressPercentage, ((Chronos.ElapsedMilliseconds - Duration) / (60000)), (Chronos.ElapsedMilliseconds / 60000), BestScore))

        Duration = Chronos.ElapsedMilliseconds

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        If e.Cancelled Then
            Display("Operation is cancelled")
            Chronos.Stop()
            Chronos = Nothing
        Else

            Chronos.Stop()
            Chronos = Nothing
            Display("Work is completed successfully..")

        End If

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BtnGA_Click(sender As Object, e As EventArgs) Handles BtnGA.Click
        EngineIndex = 1
        ListBox1.Items.Add("GA is running...")
        Chronos = New Stopwatch()
        Chronos.Start()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Sub RunGA()

        Dim fileName As String = String.Empty
        Dim title As String = String.Empty
        Dim saving As Boolean = False
        Dim csvWriter As CsvFileIO

        Dim BestChartList As New DataSerie3D()
        With BestChartList
            .Title = "Run"
            .X_Title = "Best"
            .Y_Title = "Worst"
            .Z_Title = "Avearge"
        End With

        GA_Engine = New RmosEngine.GeneticAlgorithm.GAEngine()

        Dim maxIter As Integer = 3000
        Dim D = 2

        With GA_Engine

            .Agents_N = 30
            .MutationFrequency = 20
            .Max_Iteration = maxIter

            .TotalTimePeriod = D

            .Initial_Storage = 117.543
            .Reservoir = TheReservoir
            .InflowSerie = TheReservoir.Inflow
            .Demands = TheReservoir.Downstream

        End With

        For k = 1 To 20

            With GA_Engine

                .Luanch_Optimization()

                BestScore = .Best_Charts(0).Min

                BestScoresList.Add(.Best_Charts(0))

                BestChartList.Add(String.Format("GA : = {0} ", k), .Performance(0).Data((maxIter - 1)).X_Value, .Performance(0).Data((maxIter - 1)).Y_Value, .Performance(0).Data((maxIter - 1)).Z_Value)

                BackgroundWorker1.ReportProgress(k)

            End With

        Next k

        title = "GA_20_Runs_F14.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestChartList)
        '------------------------------------------------------
        title = "GA_Details_20_Runs_F14.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestScoresList, fileName)
        '-------------------------------------------------------
        BestChartList.Data.Clear()
        BestChartList.Data = Nothing
        BestChartList = Nothing

    End Sub

    Sub RunGSA()

        Dim BestChartList As New DataSerie3D()

        With BestChartList
            .Title = "Run"
            .X_Title = "Best"
            .Y_Title = "Worst"
            .Z_Title = "Avearge"
        End With

        Dim fileName As String = String.Empty
        Dim title As String = String.Empty
        Dim saving As Boolean = False
        Dim csvWriter As CsvFileIO

        Dim maxIter As Integer = 3000
        Dim D As Integer = 30

        GSA_Engine = New RmosEngine.GravitationalSearchAlgorithm.GSAEngine()
        With GSA_Engine
            .Agents_N = 30
            .G0_Value = 100
            .Alpha = 20
            .Max_Iteration = maxIter
            .TotalTimePeriod = D
            .Initial_Storage = 117.543
            .Reservoir = TheReservoir
            .InflowSerie = TheReservoir.Inflow
            .Demands = TheReservoir.Downstream
        End With

        For k = 1 To 20
            With GSA_Engine

                .Luanch_Optimization()

                BestScore = .Best_Charts(0).Min

                BestScoresList.Add(.Best_Charts(0))

                BestChartList.Add(String.Format("GSA : = {0} ", k), .Performance(0).Data((maxIter - 1)).X_Value, .Performance(0).Data((maxIter - 1)).Y_Value, .Performance(0).Data((maxIter - 1)).Z_Value)

                BackgroundWorker1.ReportProgress(k)

            End With


        Next k
        title = "GSA_G0-100_a20_20_Runs_F9_3.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestChartList)
        '-------------------------------------------------------------
        title = "GSA_Details_20_Runs_F9_3.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestScoresList, fileName)
        '-------------------------------------------------------------
        BestChartList.Data.Clear()
        BestChartList.Data = Nothing
        BestChartList = Nothing
        'GSA_Engine = Nothing
    End Sub

    Sub RunHPSOGWO()

        Dim BestChartList As New DataSerie3D()
        With BestChartList
            .Title = "Run"
            .X_Title = "Best"
            .Y_Title = "Worst"
            .Z_Title = "Avearge"
        End With


        Dim fileName As String = String.Empty
        Dim title As String = String.Empty
        Dim saving As Boolean = False
        Dim csvWriter As CsvFileIO

        Dim maxIter As Integer = 3000
        Dim D As Int32 = 2

        HPSOGWO_Engine = New RmosEngine.GreyWolfOptimizer.HybridPSOGWOEngine()

        With HPSOGWO_Engine

            .Agents_N = 30
            .C_1 = 0.5
            .C_2 = 0.5
            .C_3 = 0.5
            .Max_Iteration = maxIter
            .TotalTimePeriod = D
            .Initial_Storage = 117.543
            .Reservoir = TheReservoir
            .InflowSerie = TheReservoir.Inflow
            .Demands = TheReservoir.Downstream

            For k = 1 To 30

                .Luanch_Optimization()

                BestScore = .Best_Charts(0).Min

                BestScoresList.Add(.Best_Charts(0))

                BestChartList.Add(String.Format("HPSOGWO_Engine : = {0} ", k), .Performance(0).Data((maxIter - 1)).X_Value, .Performance(0).Data((maxIter - 1)).Y_Value, .Performance(0).Data((maxIter - 1)).Z_Value)

                BackgroundWorker1.ReportProgress(k)
            Next k

        End With

        title = "HPSOGWO_20_Runs_F14_2.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestChartList)

        '-------------------------------------------------------------
        title = "HPSOGWO_Details_20_Runs_F14_2.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestScoresList, fileName)
        '-------------------------------------------------------------

        BestChartList.Data.Clear()
        BestChartList.Data = Nothing
        BestChartList = Nothing
        HPSOGWO_Engine = Nothing
    End Sub


    Sub RunHPSOGWO_0()

        Dim BestChartList As New DataSerie3D()
        With BestChartList
            .Title = "Run"
            .X_Title = "Best"
            .Y_Title = "Worst"
            .Z_Title = "Avearge"
        End With

        Dim folder As String = "E:\HPSOGWO_Results"
        Dim fileName As String = String.Empty
        Dim title As String = String.Empty
        Dim saving As Boolean = False
        Dim csvWriter As CsvFileIO

        Dim maxIter As Integer = 3000
        Dim D As Int32 = 30

        HPSOGWO_Engine = New RmosEngine.GreyWolfOptimizer.HybridPSOGWOEngine()

        With HPSOGWO_Engine
            .Agents_N = 30
            .C_1 = 0.5
            .C_2 = 0.5
            .C_3 = 0.5
            .Max_Iteration = maxIter
            .TotalTimePeriod = D
            .Initial_Storage = 117.543
            .Reservoir = TheReservoir
            .InflowSerie = TheReservoir.Inflow
            .Demands = TheReservoir.Downstream
        End With

        For k = 1 To 20

            With HPSOGWO_Engine

                .Luanch_Optimization()

                BestScore = .Best_Charts(0).Min

                BestChartList.Add(String.Format("HPSOGWO_Engine : = {0} ", k), .Performance(0).Data((maxIter - 1)).X_Value, .Performance(0).Data((maxIter - 1)).Y_Value, .Performance(0).Data((maxIter - 1)).Z_Value)

                BackgroundWorker1.ReportProgress(k)

            End With

            ' HPSOGWO_Engine = Nothing

        Next k

        title = "HPSOGWO_Engine_20_Runs_F1.CSV"
        fileName = String.Format("{0}\{1}", folder, title)
        csvWriter = New CsvFileIO(fileName)
        saving = csvWriter.Write(BestChartList)
        BestChartList.Data.Clear()
        BestChartList.Data = Nothing
        BestChartList = Nothing

    End Sub

    Private Sub BtnRunGSA_Click(sender As Object, e As EventArgs) Handles BtnRunGSA.Click
        EngineIndex = 2
        ListBox1.Items.Add("GSA is running...")
        Chronos = New Stopwatch()
        Chronos.Start()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BtnHPSOGWO_Click(sender As Object, e As EventArgs) Handles BtnHPSOGWO.Click
        EngineIndex = 3
        ListBox1.Items.Add("HPSOGWO is running...")
        Chronos = New Stopwatch()
        Chronos.Start()
        BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class