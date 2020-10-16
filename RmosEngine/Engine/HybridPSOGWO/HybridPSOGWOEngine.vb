Option Strict On
Imports System.ComponentModel
Imports IOOperations.Components

Namespace GreyWolfOptimizer

    Public Class HybridPSOGWOEngine

        Inherits OptimizationEngineBase

        Private HPSOGW_Optimizer As HybridPSOGWOptimizer = Nothing
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
        Public Overrides Property Name As String = "HybridPSOGWO-Engine"

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

        Dim mBest_Solutions As List(Of DataSerie1D)
        Public Overrides ReadOnly Property Best_Solutions As List(Of DataSerie1D)
            Get
                Return mBest_Solutions
            End Get
        End Property

        Dim mBest_Charts As List(Of IOOperations.Components.DataSerie1D) = Nothing
        <Category("Results H-PSOGWO")> Public Overrides ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
            Get
                Return mBest_Charts
            End Get
        End Property

        Dim mPerformance As List(Of IOOperations.Components.DataSerie3D) = Nothing
        <Category("Results H-PSOGWO")> Public Overrides ReadOnly Property Performance As List(Of IOOperations.Components.DataSerie3D)
            Get
                Return mPerformance
            End Get
        End Property

        Dim C1 As Double = 0.5
        <DisplayName("C1"), Description("Search parameter, default : C1 = 0.5"), DefaultValue(0.5)>
        Public Property C_1 As Double
            Get
                Return C1
            End Get
            Set(value As Double)
                C1 = value
            End Set
        End Property

        Dim C2 As Double = 0.5
        <DisplayName("C2"), Description("Search parameter, default : C2 = 0.5"), DefaultValue(0.5)>
        Public Property C_2 As Double
            Get
                Return C2
            End Get
            Set(value As Double)
                C2 = value
            End Set
        End Property

        Dim C3 As Double = 0.5
        <DisplayName("C3"), Description("Search parameter, default : C3 = 0.5"), DefaultValue(0.5)>
        Public Property C_3 As Double
            Get
                Return C3
            End Get
            Set(value As Double)
                C3 = value
            End Set
        End Property

        Dim AlphaScore As Double = Double.NaN
        Public ReadOnly Property Score_Alpha As Double
            Get
                Return AlphaScore
            End Get
        End Property

        Dim BetaScore As Double = Double.NaN
        Public ReadOnly Property Score_Beta As Double
            Get
                Return BetaScore
            End Get
        End Property

        Dim DeltaScore As Double = Double.NaN
        Public ReadOnly Property Score_Delta As Double
            Get
                Return DeltaScore
            End Get
        End Property
        '<Category("Parameters")> Public Property GWOVersion As GWOVersionEnum = GWOVersionEnum.StandardGWO

        '<Category("Parameters")> Public Property IGWO_uParameter As Double = 1.1
#End Region

#Region "Subs_Functions"

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

        Private Sub Initialization()
            '------------ Data ------------------------
            R_Result = New DataSerie1D() With {.Name = "Release (R*)", .Description = "Optimale Release", .Title = "Time", .X_Title = "R*"}
            S_Result = New DataSerie1D() With {.Name = "Storage (S*)", .Description = "Storage", .Title = "Time", .X_Title = "S*"}
            O_Result = New DataSerie1D() With {.Name = "Overflow (O)", .Description = "Overflow", .Title = "Time", .X_Title = "O"}


            Evaporation = New IOOperations.Components.DataSerie1D()
            Infiltration = New IOOperations.Components.DataSerie1D()

            mBest_Charts = New List(Of IOOperations.Components.DataSerie1D)
            mPerformance = New List(Of IOOperations.Components.DataSerie3D)

            '-------------GA---------------------------
            S0 = Initial_Storage
            Smin = Min_Storage
            Smax = Max_Storage
            Dmax = Me.Demands.Max
            '------------------------------------------

            ReDim Si(Me.Dimensions_D)
            ReDim Objective_Si((Me.Dimensions_D - 1))

            ReDim Oi((Me.Dimensions_D - 1))

            ReDim Qi((Me.Dimensions_D - 1))
            ReDim Di((Me.Dimensions_D - 1))

            ReDim Qinfiltration((Me.Dimensions_D - 1))
            ReDim Qevaporation((Me.Dimensions_D - 1))

            Me.Intervalles = New List(Of Intervalle)
            'Set Inflows & Demands :
            For i = 0 To (Me.Dimensions_D - 1)
                Qi(i) = InflowSerie.Data(i).X_Value
                Di(i) = Demands.Data(i).X_Value
                Me.Intervalles.Add(New Intervalle With {.Min_Value = Min_Release, .Max_Value = (1.1 * Di(i)
                                   )})
                'Me.Intervalles.Add(New Intervalle With {.Min_Value = Min_Release, .Max_Value = Dmax})
                'Me.Intervalles.Add(New Intervalle With {.Min_Value = -65, .Max_Value = 65})

            Next i

            'AF14 = Get_F14_aij()

            With HPSOGW_Optimizer

                '.SearchIntervalle = New Intervalle With {.Max_Value = Max_Release, .Min_Value = Min_Release}
                .Intervalles = Intervalles
                .WolvesCount = Agents_N
                .Dimensions = Dimensions_D
                .IterationsCount = Max_Iteration
                .OptimizationType = OptimizationType
                .C_1 = C_1
                .C_2 = C_2
                .C_3 = C_3
            End With

        End Sub

        Public Overrides Sub Luanch_Optimization()
            Try

                'Initialisation :
                If CheckData() = False Then Return
                'If IsNothing(GW_Optimizer) Then
                HPSOGW_Optimizer = New HybridPSOGWOptimizer() With {.Dimensions = Me.TotalTimePeriod}
                'End If
                '-----------Objective function----------------------------------------------------
                AddHandler HPSOGW_Optimizer.ObjectiveFunctionComputation, AddressOf FitnessObjectiveFunction
                'AddHandler HPSOGW_Optimizer.ObjectiveFunctionComputation, AddressOf Function_F14
                '----------------------------------------------------------------------------------
                Initialization()
                '---------------------------------------------------------------------------------
                Dim best_Chart As IOOperations.Components.DataSerie1D
                Dim performanceP As IOOperations.Components.DataSerie3D

                If IsNothing(Chronos) Then Chronos = New Stopwatch()

                '---------------- Analyse --------------------------

                'Dim j As Integer = 0
                Dim i As Integer = 0
                Dim k As Integer = 0
                Dim ss As Integer = 0
                Dim storageTp1 As Double = 0
                Dim releaseStar As Double = 0R

                '-----------------------------------------
                S0 = Me.Initial_Storage
                Si(0) = S0
                '----------------------------------------

                Chronos.Start()
                '--------------------------------------------------
                HPSOGW_Optimizer.LuanchComputation()

                For Each rr In HPSOGW_Optimizer.BestSolution
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

                '------------------------ Best chart ------------------------------
                best_Chart = New IOOperations.Components.DataSerie1D() With {.Name = String.Format("Fitness Evolution: Total Period = {0} [Time Unit]", Me.TotalTimePeriod)}
                performanceP = New IOOperations.Components.DataSerie3D() With {.Name = String.Format("Performance Evolution: Total Period = {0} [Time Unit]", Me.TotalTimePeriod)}

                With best_Chart
                    .Title = String.Format("HPSOGWO_P_{0}_C1_{1}_C2_{2}_C3_{3}_Performance", Agents_N, C1, C2, C3)
                    .Description = .Name
                    .X_Title = "Fitness"
                End With

                With performanceP
                    .Title = String.Format("HPSOGWO_P_{0}_C1_{1}_C2_{2}_C3_{3}_Performance", Agents_N, C1, C2, C3)
                    .Description = .Name
                    .X_Title = "Best-Solution"
                    .Y_Title = "Worst-Solution"
                    .Z_Title = "Mean-Solution"
                End With

                For ss = 0 To (HPSOGW_Optimizer.BestChart.Count - 1)
                    best_Chart.Add(ss.ToString(), HPSOGW_Optimizer.BestChart(ss))
                    performanceP.Add(ss.ToString(), HPSOGW_Optimizer.BestChart(ss), HPSOGW_Optimizer.WorstChart(ss), HPSOGW_Optimizer.MeanChart(ss))
                Next

                Chronos.Stop()
                mComputationTime = Chronos.ElapsedMilliseconds
                Chronos.Reset()
                '--------------------------------------------------------------------
                mBest_Charts.Add(best_Chart)
                mPerformance.Add(performanceP)
                '---------------------------------------------------------------------
                With HPSOGW_Optimizer
                    Me.AlphaScore = .Score_Alpha
                    Me.BetaScore = .Score_Beta
                    Me.DeltaScore = .Score_Delta
                End With

            Catch ex As Exception
                Throw ex
            End Try

        End Sub


#Region "Objective_Function"
        'Private sum As Double = 0R
        Private Penalty_1, Penalty_2 As Double
        Private MonthIndex As Integer = 0I
        Private Dmax As Double = 0R
        Public Overloads Sub FitnessObjectiveFunction2(ByRef positions() As Double, ByRef fitnessValue As Double)

            fitnessValue = 0R
            For j As Int32 = 0 To (Dimensions_D - 1)
                fitnessValue += (positions(j) ^ 2)
            Next

        End Sub

        Public Overloads Sub FitnessObjectiveFunction(ByRef positions() As Double, ByRef fitnessValue As Double)

            For i As Integer = 0 To (Dimensions_D - 1)
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
                Qevaporation(j) = Reservoir.GetEvaporationOf(CType(MonthIndex, HydComponents.MonthsEnum), Si(j), Qi(j), positions(j), Qinfiltration(j))

                Si(j + 1) = (Si(j) + Qi(j)) - (positions(j) + Qevaporation(j) + Qinfiltration(j))

                'Si(j + 1) = (Si(j) + Qi(j)) - (positions(j))

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

            fitnessValue = 0R
            For j As Int32 = 0 To (Dimensions_D - 1)
                fitnessValue += Math.Pow(((positions(j) - Di(j)) / Dmax), 2)
            Next

            If Me.OptimizationType = OptimizationTypeEnum.Minimization Then
                fitnessValue += (Penalty_1 + Penalty_2)
            Else
                fitnessValue -= (Penalty_1 + Penalty_2)
            End If

        End Sub

        Public Overloads Sub FitnessObjectiveFunction_1(ByRef positions() As Double, ByRef fitnessValue As Double)

            For i As Integer = 0 To (Dimensions_D - 1)
                Si(i) = 0
                Qinfiltration(i) = 0R
                Qevaporation(i) = 0R
            Next

            Si(0) = S0

            For j As Integer = 0 To (Dimensions_D - 1)

                Qinfiltration(j) = 0.033 'Reservoir.GetInfiltrationOf(Si(j))
                Qevaporation(j) = Reservoir.GetEvaporationOf(CType(j, HydComponents.MonthsEnum), Si(j), Qi(j), positions(j), Qinfiltration(j))

                Si(j + 1) = (Si(j) + Qi(j)) - (positions(j) + Qevaporation(j) + Qinfiltration(j))

                'Si(j + 1) = (Si(j) + Qi(j)) - (positions(j))

                If Si(j + 1) > Smax Then

                    Si(j + 1) = Smax

                ElseIf Si(j + 1) < Smin Then

                    Si(j + 1) = Smin

                End If
            Next

            fitnessValue = 0R
            For j As Int32 = 0 To (Dimensions_D - 1)
                If Si(j) < (Smin + Di(j)) Then
                    ' sum += 10 * Math.Pow((X(i, j) - Di(j)), 2) + 10 * Math.Pow((Smax - Si(j + 1)), 2)
                    'sum += 50 * Math.Pow((Smax - Si(j + 1)), 2) + 50 * Math.Pow((X(i, j) - Di(j)), 2)
                    'sum += 1 * Math.Pow((Smax - Si(j + 1)), 2) + 1 * Math.Pow((X(i, j) - Di(j)), 2)
                    fitnessValue += 10 * Math.Abs((positions(j) - Di(j)))
                Else

                    'sum += 1 * Math.Pow((positions(j) - Di(j)), 2) '+ 0.1 * Math.Pow((Objective_Si(j) - Si(j + 1)), 2)
                    fitnessValue += Math.Abs((positions(j) - Di(j))) '+ 0.1 * Math.Pow((Objective_Si(j) - Si(j + 1)), 2)

                End If

            Next

        End Sub
#End Region

#End Region
#Region "Benchmark Functions"
        Public Sub Function_F1(ByRef positions() As Double, ByRef fitnessValue As Double)
            fitnessValue = 0R
            For i As Integer = 0 To (positions.Length - 1)
                fitnessValue += positions(i) ^ 2
            Next
        End Sub

        'Public Sub Function_F6(ByRef gene As Genome)
        '    Sum = 0R
        '    For i As Integer = 0 To (gene.Length - 1)
        '        Sum += (gene.TheArray(i) + 0.5) ^ 2
        '    Next

        '    gene.CurrentFitness = (1 / Sum)

        'End Sub


        Const pi2 As Double = 2 * Math.PI
        Public Sub Function_F9(ByRef positions() As Double, ByRef fitnessValue As Double)
            fitnessValue = 0R
            For i As Integer = 0 To (positions.Length - 1)
                fitnessValue += (positions(i) ^ 2) - 10 * Math.Cos((pi2 * positions(i))) + 10
            Next
        End Sub

        Dim somme, prod As Double
        Public Sub Function_F11(ByRef positions() As Double, ByRef fitnessValue As Double)
            somme = 0
            prod = 1
            fitnessValue = 0R

            For i As Integer = 0 To (positions.Length - 1)
                somme += Math.Pow(positions(i), 2)
                prod = prod * (Math.Cos(positions(i) / Math.Sqrt((i + 1))))
            Next
            fitnessValue = (somme / 4000) - prod + 1
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

        Public Sub Function_F14(ByRef positions() As Double, ByRef fitnessValue As Double)
            somme = 0
            fitnessValue = 0R

            For j = 0 To 24
                somme = 0
                For i = 0 To 1
                    somme += Math.Pow((positions(i) - AF14(i, j)), 6)
                Next
                fitnessValue += 1 / ((j + 1) + somme)
            Next
            somme = (f14Const + fitnessValue)
            fitnessValue = (1 / somme)
        End Sub
#End Region

    End Class
End Namespace