Option Strict On
Imports System.ComponentModel
    Imports IOOperations.Components

Namespace GeneticAlgorithm
    <Description("GA Engine V2.0")>
    Public Class GAEngine
        Inherits OptimizationEngineBase
        Private WithEvents GA_Optimizer As GAOptimizer = Nothing
        Private Chronos As Stopwatch = Nothing

#Region "Hydraulic local variables"

        Private Si() As Double

        Private Objective_Si() As Double

        Private Oi() As Double

        Private Qi() As Double
        Private Di() As Double

        Private S0 As Double = 117.543

        Private Smax As Double = 170
        Private Smin As Double = 23.3

        Private Qinfiltration() As Double
        Private Qevaporation() As Double

#End Region

#Region "Properties"

        Public Overrides Property Name As String = "GA-Engine"

        Public ReadOnly Property Dimensions_D As Integer
            Get
                Return Me.TotalTimePeriod
            End Get
        End Property

        Dim mComputationTime As Long = 0
        Public Overrides ReadOnly Property ComputationTime As Long
            Get
                Return mComputationTime
            End Get
        End Property

        Dim S_Result As DataSerie1D
        Public Overrides ReadOnly Property Storage As DataSerie1D
            Get
                Return S_Result
            End Get
        End Property

        Dim R_Result As DataSerie1D
        Public Overrides ReadOnly Property Release As DataSerie1D
            Get
                Return R_Result
            End Get
        End Property

        Dim O_Result As DataSerie1D
        Public Overrides ReadOnly Property OverFlow As DataSerie1D
            Get
                Return O_Result
            End Get
        End Property

        Dim mBest_Charts As List(Of IOOperations.Components.DataSerie1D) = Nothing
        <Category("Results GA")> Public Overrides ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
            Get
                Return mBest_Charts
            End Get
        End Property

        Dim mPerformance As List(Of IOOperations.Components.DataSerie3D) = Nothing
        <Category("Results GA")> Public Overrides ReadOnly Property Performance As List(Of IOOperations.Components.DataSerie3D)
            Get
                Return mPerformance
            End Get
        End Property

#End Region

#Region "Subs_Functions"

        Private Sub Luanch_Optimization2()
            Try
                If IsNothing(GA_Optimizer) Then
                    GA_Optimizer = New GAOptimizer()
                End If

                If IsNothing(Chronos) Then Chronos = New Stopwatch()

                '-----------Objective function----------------------------------------------------
                AddHandler GA_Optimizer.CalculateFitnessValue, AddressOf FitnessObjectiveFunction
                '----------------------------------------------------------------------------------
                Chronos.Start()
                With GA_Optimizer
                    .Intervalles = Me.Intervalles
                    .InitialPopulation = 20
                    .PopulationLimit = 20
                    .GenomesLenght = Me.TotalTimePeriod
                    .MutationFrequency = 20
                    .Save_2_BestCrossover = True
                    .DeathFitnessLimit = -100
                    .ReproductionFitness = 0
                    .MaxIteration = Max_Iteration
                    '-----------------------------------------

                    .LuanchComputation()

                    '-----------------------------------------
                    Genomes = .GenomesPopulation

                End With

                Chronos.Stop()
                mComputationTime = Chronos.ElapsedMilliseconds
                Chronos.Reset()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub Luanch_Optimization()
            Try

                'Initialisation :
                If CheckData() = False Then Return

                GA_Optimizer = New GAOptimizer() With {.GenomesLenght = Me.TotalTimePeriod}

                Initialization()
                '---------------------------------------------------------------------------------

                If IsNothing(Chronos) Then Chronos = New Stopwatch()

                '-----------Objective function----------------------------------------------------
                AddHandler GA_Optimizer.CalculateFitnessValue, AddressOf FitnessObjectiveFunction
                'AddHandler GA_Optimizer.CalculateFitnessValue, AddressOf Function_F14
                '----------------------------------------------------------------------------------
                mBest_Charts = New List(Of DataSerie1D)
                mPerformance = New List(Of DataSerie3D)

                Dim best_chart As DataSerie1D
                Dim performanceP As IOOperations.Components.DataSerie3D
                '----------------------------------------------------------------------------------
                '---------------- Analyse --------------------------
                'Dim yearT As Integer = YearCount - 1
                'Dim j As Integer = 0
                Dim i As Integer = 0
                Dim k As Integer = 0
                Dim ss As Integer = 0
                Dim storageTp1 As Double = 0
                Dim releaseStar As Double = 0R
                '-----------------------------------------
                S0 = Me.Initial_Storage
                '----------------------------------------

                'Set Inflows & Demands :
                For i = 0 To (Me.TotalTimePeriod - 1)
                    Qi(i) = InflowSerie.Data(i).X_Value
                    Di(i) = Demands.Data(i).X_Value
                    Me.Intervalles(i).Max_Value = Di(i)
                Next i

                'GA computation : 
                Chronos.Start()
                GA_Optimizer.LuanchComputation()

                For Each rr In GA_Optimizer.Best_Genome.TheArray
                    storageTp1 = (Si(k) + Qi(k)) - (rr + Qevaporation(k) + Qinfiltration(k))

                    If storageTp1 <= Smin Then
                        storageTp1 = Smin

                        releaseStar = (Si(k) + Qi(k)) - (Smin + Qevaporation(k) + Qinfiltration(k))

                    ElseIf storageTp1 >= Smax Then
                        releaseStar = rr
                        Oi(k) = storageTp1 - Smax
                        storageTp1 = Smax
                    Else
                        releaseStar = rr
                    End If

                    Si(k + 1) = storageTp1

                    R_Result.Add(k.ToString(), releaseStar)
                    S_Result.Add(k.ToString(), Si(k))
                    O_Result.Add(k.ToString(), Oi(k))

                    Evaporation.Add(k.ToString(), Qevaporation(k))
                    Infiltration.Add(k.ToString(), Qinfiltration(k))

                    k += 1
                Next

                '------------------------ Best Solution ------------------------------
                best_chart = New DataSerie1D() With {.Name = String.Format("Fitness Evolution: Total Period = {0} [Time Unit]", Me.TotalTimePeriod)}
                performanceP = New IOOperations.Components.DataSerie3D() With {.Name = String.Format("Performance Evolution: Total Period = {0} [Time Unit]", Me.TotalTimePeriod)}

                With best_chart
                    .Title = String.Format("GA_Mutation{0}_P{1}_Performance", MutationFrequency, Agents_N)
                    .Description = .Name
                    .X_Title = "Fitness"
                End With

                With performanceP
                    .Title = String.Format("GA_Mutation{0}_P{1}_Performance", MutationFrequency, Agents_N)
                    .Description = .Name
                    .X_Title = "Best-Solution"
                    .Y_Title = "Worst-Solution"
                    .Z_Title = "Mean-Solution"
                End With

                For ss = 0 To (GA_Optimizer.BestChart.Count - 1)
                    best_chart.Add(ss.ToString(), GA_Optimizer.BestChart(ss))
                    performanceP.Add(ss.ToString(), GA_Optimizer.BestChart(ss), GA_Optimizer.WorstChart(ss), GA_Optimizer.MeanChart(ss))
                Next

                mBest_Charts.Add(best_chart)
                mPerformance.Add(performanceP)
                '---------------------------------------------------------------------

                Chronos.Stop()
                mComputationTime = Chronos.ElapsedMilliseconds
                Chronos.Reset()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub Initialization()

            '------------ Data ------------------------
            R_Result = New DataSerie1D() With {.Name = "Release (R*)", .Description = "Optimale Release", .Title = "Time", .X_Title = "R*"}
            S_Result = New DataSerie1D() With {.Name = "Storage (S*)", .Description = "Storage", .Title = "Time", .X_Title = "S*"}
            O_Result = New DataSerie1D() With {.Name = "Overflow (O)", .Description = "Overflow", .Title = "Time", .X_Title = "O"}
            Evaporation = New IOOperations.Components.DataSerie1D() With {.Name = "Evaporation"}
            Infiltration = New IOOperations.Components.DataSerie1D() With {.Name = "Infiltration"}
            '-------------GA---------------------------
            S0 = Initial_Storage
            Smin = Min_Storage
            Smax = Max_Storage
            Dmax = Me.Demands.Max
            '------------------------------------------
            ' Me.TotalTimePeriod = Me.InflowSerie.Count

            ReDim Si(Me.Dimensions_D)
            ReDim Objective_Si((Me.Dimensions_D - 1))

            ReDim Oi((Me.Dimensions_D - 1))

            ReDim Qi((Me.Dimensions_D - 1))
            ReDim Di((Me.Dimensions_D - 1))

            ReDim Qinfiltration((Me.Dimensions_D - 1))
            ReDim Qevaporation((Me.Dimensions_D - 1))

            '------------------------------------------
            Me.Intervalles = New List(Of RmosEngine.Intervalle)
            For i As Integer = 0 To (Me.Dimensions_D - 1)

                Qi(i) = InflowSerie.Data(i).X_Value
                Di(i) = Demands.Data(i).X_Value

                Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = Min_Release, .Max_Value = Di(i)})

                'F1  [-100, 100] d=30: 
                'Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = -100, .Max_Value = 100})

                'F6  [-100, 100] d=30: 
                'Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = -10, .Max_Value = 10})

                'F9  [-5.12, 5.12] d= 30 
                'Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = -5.12, .Max_Value = 5.12})

                'F11  [-600, 600] d= 30: 
                'Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = -600, .Max_Value = 600})

                'F14  [-65, 65] d=2  
                'Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = -65, .Max_Value = 65})
            Next

            'AF14 = Get_F14_aij()

            With GA_Optimizer

                '.Intervalle = New Intervalle With {.Max_Value = Max_Release, .Min_Value = Min_Release}
                .Intervalles = Me.Intervalles

                .InitialPopulation = Agents_N
                .PopulationLimit = Agents_N
                .GenomesLenght = Dimensions_D

                .MutationFrequency = MutationFrequency
                .Save_2_BestCrossover = Save_2_BestCrossover

                .DeathFitnessLimit = Single.MinValue
                .ReproductionFitness = 0
                .MaxIteration = Max_Iteration

            End With

        End Sub

        Private Function CheckData() As Boolean
            Dim result As Boolean = True
            Try
                If IsNothing(Reservoir) Then
                    result = False
                    Exit Try
                End If

                If IsNothing(InflowSerie) Then
                    result = False
                    Exit Try
                End If
                If IsNothing(InflowSerie.Data) Then
                    result = False
                    Exit Try
                End If

                If IsNothing(Demands) Then
                    result = False
                    Exit Try
                End If
                If IsNothing(Demands.Data) Then
                    result = False
                    Exit Try
                End If

                If Demands.Data.Count <> InflowSerie.Data.Count Then
                    result = False
                    Exit Try
                End If

            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

#End Region

#Region "GA_Params"
        Private kMutationFrequency As Single = 10.0F
        <Description("Probability of mutation (Default 10%)"), DefaultValue(10)>
        Public Property MutationFrequency As Single
            Get
                Return kMutationFrequency
            End Get
            Set(value As Single)
                If value >= 0 Then
                    kMutationFrequency = value
                Else
                    kMutationFrequency = 10.0F
                End If
            End Set
        End Property

        Dim Best2 As Boolean = True
        <Description("If [True], add (save) top fitness genes after crossover operation."), DefaultValue(True)>
        Public Property Save_2_BestCrossover As Boolean
            Get
                Return Best2
            End Get
            Set(value As Boolean)
                Best2 = value
            End Set

        End Property

        Private Genomes As New List(Of Genome)
        <Description("The best solution (Genome with index 0).")> Public ReadOnly Property Best_Genome As Genome
            Get
                If IsNothing(Genomes) = False Then
                    If Genomes.Count > 0 Then
                        Return Genomes(0)
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property GenomesPopulation As List(Of Genome)
            Get
                Return Genomes
            End Get
        End Property
#End Region

#Region "Objective_Function"

        Private Sum As Double = 0R
        Private Penalty_1, Penalty_2 As Double
        Private MonthIndex As Integer = 0I
        Private Dmax As Double = 0R
        Public Overloads Sub FitnessObjectiveFunction(ByRef gene As Genome)

            For i As Integer = 0 To (Me.Dimensions_D - 1)
                Si(i) = 0R
                Qinfiltration(i) = 0R
                Qevaporation(i) = 0R
            Next

            Si(0) = S0
            Penalty_1 = 0R
            Penalty_2 = 0R
            MonthIndex = 0I

            For j As Integer = 0 To (Dimensions_D - 1)

                Qinfiltration(j) = 0.033 'Reservoir.GetInfiltrationOf(Si(j))

                Qevaporation(j) = Reservoir.GetEvaporationOf(CType(MonthIndex, HydComponents.MonthsEnum), Si(j), Qi(j), gene.TheArray(j), Qinfiltration(j))

                Si(j + 1) = (Si(j) + Qi(j)) - (gene.TheArray(j) + Qevaporation(j) + Qinfiltration(j))

                If Si(j + 1) > Smax Then
                    Penalty_2 += Math.Pow(((Si(j + 1) - Smax) / Smax), 2)
                    'Si(j + 1) = Smax
                ElseIf Si(j + 1) < Smin Then
                    Penalty_1 += Math.Pow((Smin - Si(j + 1)), 2) / Smin
                    'Si(j + 1) = Smin
                End If

                MonthIndex += 1
                If MonthIndex > 11 Then
                    MonthIndex = 0
                End If

            Next

            Sum = 0R

            For j As Int32 = 0 To (Dimensions_D - 1)

                'If Si(j + 1) = Smin Then
                '    gene.TheArray(j) = (Si(j) + Qi(j)) - (Smin + Qevaporation(j) + Qinfiltration(j))
                'End If

                Sum += Math.Pow(((gene.TheArray(j) - Di(j)) / Dmax), 2)

            Next

            If Me.OptimizationType = OptimizationTypeEnum.Minimization Then
                Sum += (Penalty_1 + Penalty_2)
                gene.CurrentFitness = (1 / Sum)
                'gene.CurrentFitness = (1 / Sum) - (Penalty_1 + Penalty_2)
            Else
                gene.CurrentFitness = Sum - (Penalty_1 + Penalty_2)
            End If

        End Sub

        ''' <summary>
        ''' Objective function with ancien penalty function.
        ''' </summary>
        ''' <param name="gene"></param>
        Public Overloads Sub FitnessObjectiveFunction_1(ByRef gene As Genome)

            For i As Integer = 0 To (Me.Dimensions_D - 1)
                Si(i) = 0
                Qinfiltration(i) = 0R
                Qevaporation(i) = 0R
            Next

            Si(0) = S0

            For j As Integer = 0 To (Dimensions_D - 1)
                Qinfiltration(j) = Reservoir.GetInfiltrationOf(Si(j))
                Qevaporation(j) = Reservoir.GetEvaporationOf(CType(j, HydComponents.MonthsEnum), Si(j), Qi(j), gene.TheArray(j), Qinfiltration(j))

                Si(j + 1) = (Si(j) + Qi(j)) - (gene.TheArray(j) + Qevaporation(j) + Qinfiltration(j))

                If Si(j + 1) > Smax Then
                    Si(j + 1) = Smax
                ElseIf Si(j + 1) < Smin Then
                    Si(j + 1) = Smin
                End If
            Next

            Sum = 0R

            For j As Int32 = 0 To (Dimensions_D - 1)

                If Si(j + 1) = Smin Then
                    gene.TheArray(j) = (Si(j) + Qi(j)) - (Smin + Qevaporation(j) + Qinfiltration(j))
                End If

                Sum += Math.Abs(gene.TheArray(j) - Di(j))

            Next

            If Me.OptimizationType = OptimizationTypeEnum.Minimization Then
                gene.CurrentFitness = (1 / Sum)
            Else
                gene.CurrentFitness = Sum
            End If

        End Sub
        Public Overloads Sub FitnessObjectiveFunction_0(ByRef gene As Genome)


            For i As Integer = 0 To (Me.Dimensions_D - 1)
                Si(i) = 0
            Next

            Si(0) = S0

            For j As Integer = 0 To (Dimensions_D - 1)
                Si(j + 1) = (Si(j) + Qi(j)) - gene.TheArray(j)
                If Si(j + 1) > Smax Then
                    Si(j + 1) = Smax
                ElseIf Si(j + 1) < Smin Then
                    Si(j + 1) = Smin
                End If
            Next

            Sum = 0R
            For j As Int32 = 0 To (Dimensions_D - 1)
                'If Si(j) < (Smin + Di(j)) Then
                '    ' sum += 10 * Math.Pow((X(i, j) - Di(j)), 2) + 10 * Math.Pow((Smax - Si(j + 1)), 2)
                '    'sum += 50 * Math.Pow((Smax - Si(j + 1)), 2) + 50 * Math.Pow((X(i, j) - Di(j)), 2)
                '    'sum += 1 * Math.Pow((Smax - Si(j + 1)), 2) + 1 * Math.Pow((X(i, j) - Di(j)), 2)
                '    sum += 1 * Math.Pow(Di(j), 2)
                'Else
                '    'sum += Math.Pow((gene.TheArray(j) - Di(j)), 2) '+ 0.1 * Math.Pow((Objective_Si(j) - Si(j + 1)), 2)
                '    sum += Math.Abs((gene.TheArray(j) - Di(j))) / Di(j) '+ 0.1 * Math.Pow((Objective_Si(j) - Si(j + 1)), 2)
                'End If
                'sum += Math.Abs((gene.TheArray(j) - Di(j))) / Di(j)
                If Si(j) <= (Smin) Then
                    gene.TheArray(j) = 0
                    Sum += Math.Abs(Di(j))
                Else
                    Sum += Math.Abs(gene.TheArray(j) - Di(j))
                End If

                'sum += Math.Abs(gene.TheArray(j) - Di(j))
            Next

            'For i As Integer = 0 To (gene.Length - 1)
            '    sum += Math.Abs(gene.TheArray(i) - Di(i))
            'Next

            gene.CurrentFitness = (1 / Sum)

        End Sub

#End Region

#Region "Benchmark Functions"
        Public Sub Function_F1(ByRef gene As Genome)
            Sum = 0R
            For i As Integer = 0 To (gene.Length - 1)
                Sum += Math.Pow(gene.TheArray(i), 2)
            Next

            gene.CurrentFitness = (1 / Sum)

        End Sub

        Public Sub Function_F6(ByRef gene As Genome)
            Sum = 0R
            For i As Integer = 0 To (gene.Length - 1)
                Sum += (gene.TheArray(i) + 0.5) ^ 2
            Next

            gene.CurrentFitness = (1 / Sum)

        End Sub

        Const pi2 As Double = 2 * Math.PI
        Public Sub Function_F9(ByRef gene As Genome)
            Sum = 0R
            For i As Integer = 0 To (gene.Length - 1)
                Sum += (gene.TheArray(i) ^ 2) - 10 * Math.Cos((pi2 * gene.TheArray(i))) + 10
            Next

            gene.CurrentFitness = (1 / Sum)
        End Sub

        Dim somme, prod As Double
        Public Sub Function_F11(ByRef gene As Genome)
            somme = 0
            prod = 1
            Sum = 0R

            For i As Integer = 0 To (gene.Length - 1)
                somme += Math.Pow(gene.TheArray(i), 2)
                prod = prod * (Math.Cos(gene.TheArray(i) / Math.Sqrt((i + 1))))
            Next
            Sum = (somme / 4000) - prod + 1
            gene.CurrentFitness = (1 / Sum)

        End Sub

        Public Function Get_F14_aij() As Int32(,)
            Dim aij(1, 24) As Int32
            aij(0, 0) = -32
            aij(0, 1) = -16
            aij(0, 2) = 0
            aij(0, 3) = 16
            aij(0, 4) = 32
            aij(0, 5) = -32
            aij(0, 6) = -16
            aij(0, 7) = 0
            aij(0, 8) = 16
            aij(0, 9) = 32
            aij(0, 10) = -32
            aij(0, 11) = -16
            aij(0, 12) = 0
            aij(0, 13) = 16
            aij(0, 14) = 32
            aij(0, 15) = -32
            aij(0, 16) = -16
            aij(0, 17) = 0
            aij(0, 18) = 16
            aij(0, 19) = 32
            aij(0, 20) = -32
            aij(0, 21) = -16
            aij(0, 22) = 0
            aij(0, 23) = 16
            aij(0, 24) = 32
            '------------------
            aij(1, 0) = -32
            aij(1, 1) = -32
            aij(1, 2) = -32
            aij(1, 3) = -32
            aij(1, 4) = -32
            aij(1, 5) = -16
            aij(1, 6) = -16
            aij(1, 7) = -16
            aij(1, 8) = -16
            aij(1, 9) = -16
            aij(1, 10) = 0
            aij(1, 11) = 0
            aij(1, 12) = 0
            aij(1, 13) = 0
            aij(1, 14) = 0
            aij(1, 15) = 16
            aij(1, 16) = 16
            aij(1, 17) = 16
            aij(1, 18) = 16
            aij(1, 19) = 16
            aij(1, 20) = 32
            aij(1, 21) = 32
            aij(1, 22) = 32
            aij(1, 23) = 32
            aij(1, 24) = 32
            Return aij
        End Function
        Private AF14(,) As Int32
        Const f14Const = (1 / 500)

        Public Sub Function_F14(ByRef gene As Genome)
            somme = 0
            Sum = 0R

            For j = 0 To 24
                somme = 0
                For i = 0 To 1
                    somme += Math.Pow((gene.TheArray(i) - AF14(i, j)), 6)
                Next
                Sum += 1 / ((j + 1) + somme)
            Next
            somme = (f14Const + Sum)
            Sum = (1 / somme)

            gene.CurrentFitness = (1 / Sum)

        End Sub

#End Region

#Region "Threading"

        Public Overrides Sub Luanch_Optimisation(syncMode As OptimizationSyncModeEnum)
            If syncMode = OptimizationSyncModeEnum.Synchronous Then
                Luanch_Optimization()
            Else
                'Asynchrouns mode :
                AddHandler MyBase.BackThread.DoWork, AddressOf Async_DoWork
                MyBase.BackThread.RunWorkerAsync()
                RaiseEvent ProcessStarted(Me, New AsyncOptimEventArgs(0, Nothing))
            End If
        End Sub

        Private Sub Async_DoWork(sender As Object, e As DoWorkEventArgs)
            If BackThread.CancellationPending Then
                e.Cancel = True
            Else
                Me.Luanch_Optimization()
                AsynchronState = AsynchStateEnum.Working
            End If

        End Sub

        Private Sub GA_Optimizer_ProgressChanged(sender As Object, e As AsyncOptimEventArgs) Handles GA_Optimizer.ProgressChanged
            eArg.ProgressPercentage = e.ProgressPercentage
            eArg.CurrentSate = e.CurrentSate
            BackThread.ReportProgress(e.ProgressPercentage)
        End Sub

        Public Event ProcessStarted(sender As Object, e As AsyncOptimEventArgs)
#End Region

    End Class
End Namespace



