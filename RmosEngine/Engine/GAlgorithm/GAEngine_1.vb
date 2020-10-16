Option Strict On
Imports System.ComponentModel
Imports IOOperations.Components

Namespace GeneticAlgorithm

    Public Class GAEngine_1
        Inherits OptimizationEngineBase

        Private GA_Optimizer As GAOptimizer = Nothing
        Private Chronos As Stopwatch = Nothing

#Region "Hydraulic local variables"

        Private Si(12) As Double

        Private Objective_Si(11) As Double

        Private Oi(11) As Double

        Private Qi(11) As Double
        Private Di(11) As Double

        Private S0 As Double = 118

        Private Smax As Double = 170
        Private Smin As Double = 23.3

        Private Qinfiltration(11) As Double
        Private Qevaporation(11) As Double

#End Region

#Region "Properties"
        Public Overrides Property Name As String = "GA-Engine"

        Public ReadOnly Property Dimensions_D As Integer
            Get
                Return 12
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

        'Dim mBest_Solutions As List(Of DataSerie1D)
        'Public Overrides ReadOnly Property Best_Solutions As List(Of DataSerie1D)
        '    Get
        '        Return mBest_Solutions
        '    End Get
        'End Property

        Dim mBest_Charts As List(Of IOOperations.Components.DataSerie1D) = Nothing
        <Category("Results GA")> Public Overrides ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
            Get
                Return mBest_Charts
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
                    .GenomesLenght = 12
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
                If IsNothing(GA_Optimizer) Then
                    GA_Optimizer = New GAOptimizer()
                End If

                Initialization()

                If CheckData() = False Then Return
                '---------------------------------------------------------------------------------

                If IsNothing(Chronos) Then Chronos = New Stopwatch()

                '-----------Objective function----------------------------------------------------
                AddHandler GA_Optimizer.CalculateFitnessValue, AddressOf FitnessObjectiveFunction
                '----------------------------------------------------------------------------------
                mBest_Charts = New List(Of DataSerie1D)
                Dim best_chart As DataSerie1D
                '----------------------------------------------------------------------------------
                '---------------- Analyse --------------------------
                Dim yearT As Integer = YearCount - 1
                Dim j As Integer = 0
                Dim i As Integer = 0
                Dim k As Integer = 0
                Dim ss As Integer = 0
                Dim storageTp1 As Double = 0
                Dim releaseStar As Double = 0R
                '-----------------------------------------
                S0 = Me.Initial_Storage
                '----------------------------------------

                Si(0) = S0

                Chronos.Start()

                '--------------------------------------------------
                For t As Int32 = 0 To yearT

                    'Set Inflows & Demands :
                    For i = 0 To 11
                        Qi(i) = InflowSerie.Data(j).X_Value
                        Di(i) = Demands.Data(j).X_Value
                        Me.Intervalles(i).Max_Value = Di(i)
                        j += 1
                    Next i

                    'GA computation : 

                    GA_Optimizer.LuanchComputation()

                    k = 0

                    'For Each rr In GA_Optimizer.Best_Genome.TheArray

                    '    storageTp1 = (Si(k) + Qi(k)) - rr

                    '    If storageTp1 <= Smin Then
                    '        storageTp1 = Smin
                    '        releaseStar = (Si(k) + Qi(k)) - Smin

                    '    ElseIf storageTp1 >= Smax Then
                    '        releaseStar = rr
                    '        Oi(k) = storageTp1 - Smax
                    '        storageTp1 = Smax
                    '    Else
                    '        releaseStar = rr
                    '    End If

                    '    Si(k + 1) = storageTp1

                    '    R_Result.Add(k.ToString(), Math.Round(releaseStar, 3))
                    '    S_Result.Add(k.ToString(), Math.Round(Si(k), 3))
                    '    O_Result.Add(k.ToString(), Math.Round(Oi(k), 3))

                    '    k += 1
                    'Next

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
                    S0 = Si(12)

                    '------------------------ Best Solution ------------------------------
                    best_chart = New DataSerie1D() With {.Name = String.Format("Fitness Evolution: Year [{0}]", t)}
                    With best_chart
                        .Title = .Name
                        .Description = .Name
                        .X_Title = "Fitness"
                    End With
                    ss = 0
                    For Each bc In GA_Optimizer.BestChart
                        best_chart.Add(ss.ToString(), bc)
                        ss += 1
                    Next

                    mBest_Charts.Add(best_chart)
                    '---------------------------------------------------------------------
                Next t

                Chronos.Stop()
                mComputationTime = Chronos.ElapsedMilliseconds

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub Initialization()
            '------------ Data ------------------------
            R_Result = New DataSerie1D()
            S_Result = New DataSerie1D()
            O_Result = New DataSerie1D()
            Evaporation = New IOOperations.Components.DataSerie1D()
            Infiltration = New IOOperations.Components.DataSerie1D()
            '-------------GA---------------------------
            S0 = Initial_Storage
            Smin = Min_Storage
            Smax = Max_Storage
            '------------------------------------------
            Me.Intervalles = New List(Of RmosEngine.Intervalle)
            For i As Integer = 0 To 11
                Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = Min_Release, .Max_Value = Max_Release})
            Next

            With GA_Optimizer

                '.Intervalle = New Intervalle With {.Max_Value = Max_Release, .Min_Value = Min_Release}
                .Intervalles = Me.Intervalles

                .InitialPopulation = Agents_N
                .PopulationLimit = Agents_N
                .GenomesLenght = Dimensions_D

                .MutationFrequency = MutationFrequency
                .Save_2_BestCrossover = Save_2_BestCrossover

                .DeathFitnessLimit = -100
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

        Public Overloads Sub FitnessObjectiveFunction(ByRef gene As Genome)

            For i As Integer = 0 To (Me.Dimensions_D - 1)
                Si(i) = 0R

                Qinfiltration(i) = 0R
                Qevaporation(i) = 0R
            Next

            Si(0) = S0
            Penalty_1 = 0R
            Penalty_2 = 0R

            For j As Integer = 0 To (Dimensions_D - 1)

                Qinfiltration(j) = 0.033 'Reservoir.GetInfiltrationOf(Si(j))

                Qevaporation(j) = Reservoir.GetEvaporationOf(CType(j, HydComponents.MonthsEnum), Si(j), Qi(j), gene.TheArray(j), Qinfiltration(j))

                Si(j + 1) = (Si(j) + Qi(j)) - (gene.TheArray(j) + Qevaporation(j) + Qinfiltration(j))

                If Si(j + 1) > Smax Then
                    Penalty_2 += Math.Pow(((Si(j + 1) - Smax) / Smax), 2)
                    'Si(j + 1) = Smax
                ElseIf Si(j + 1) < Smin Then
                    Penalty_1 += Math.Pow((Smin - Si(j + 1)), 2) / Smin
                    'Si(j + 1) = Smin
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
                gene.CurrentFitness = (1 / Sum) + Penalty_1 + Penalty_2
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

    End Class
End Namespace

