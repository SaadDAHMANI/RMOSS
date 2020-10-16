Option Strict On
Imports System.ComponentModel
Imports IOOperations.Components

Namespace GreyWolfOptimizer
    Public Class GWOEngine
        Inherits OptimizationEngineBase

        Private GW_Optimizer As GWOptimizer = Nothing
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
        Public Overrides Property Name As String = "GWO-Engine"

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
        <Category("Results GWO")> Public Overrides ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
            Get
                Return mBest_Charts
            End Get
        End Property

        Dim mPerformance As List(Of IOOperations.Components.DataSerie3D) = Nothing
        <Category("Results GWO")> Public Overrides ReadOnly Property Performance As List(Of IOOperations.Components.DataSerie3D)
            Get
                Return mPerformance
            End Get
        End Property

        <Category("Parameters")> Public Property GWOVersion As GWOVersionEnum = GWOVersionEnum.StandardGWO

        <Category("Parameters")> Public Property IGWO_uParameter As Double = 1.1
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
            Evaporation = New IOOperations.Components.DataSerie1D() With {.Name = "Evaporation"}
            Infiltration = New IOOperations.Components.DataSerie1D() With {.Name = "Infiltration"}


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
                Me.Intervalles.Add(New Intervalle With {.Min_Value = Min_Release, .Max_Value = Di(i)})
            Next i

            With GW_Optimizer

                '.SearchIntervalle = New Intervalle With {.Max_Value = Max_Release, .Min_Value = Min_Release}
                .Intervalles = Intervalles
                .WolvesCount = Agents_N
                .Dimensions = Dimensions_D
                .IterationsCount = Max_Iteration
                .OptimizationType = OptimizationType
                .GWOVersion = GWOVersion
                .IGWO_uParameter = IGWO_uParameter
            End With

        End Sub

        Public Overrides Sub Luanch_Optimization()
            Try

                'Initialisation :
                If CheckData() = False Then Return
                'If IsNothing(GW_Optimizer) Then
                GW_Optimizer = New GWOptimizer() With {.Dimensions = Me.TotalTimePeriod}
                'End If
                '-----------Objective function----------------------------------------------------
                AddHandler GW_Optimizer.ObjectiveFunctionComputation, AddressOf FitnessObjectiveFunction
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
                GW_Optimizer.LuanchComputation()

                For Each rr In GW_Optimizer.BestSolution
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
                    .Title = String.Format("GWO_Vesion-[{0}]_P{1}_[IGWO-U{2}]_Performance", GWOVersion, Agents_N, IGWO_uParameter)
                    .Description = .Name
                    .X_Title = "Fitness"
                End With

                With performanceP
                    .Title = String.Format("GWO_Vesion-[{0}]_P{1}_[IGWO-U{2}]_Performance", GWOVersion, Agents_N, IGWO_uParameter)
                    .Description = .Name
                    .X_Title = "Best-Solution"
                    .Y_Title = "Worst-Solution"
                    .Z_Title = "Mean-Solution"
                End With

                For ss = 0 To (GW_Optimizer.BestChart.Count - 1)
                    best_Chart.Add(ss.ToString(), GW_Optimizer.BestChart(ss))
                    performanceP.Add(ss.ToString(), GW_Optimizer.BestChart(ss), GW_Optimizer.WorstChart(ss), GW_Optimizer.MeanChart(ss))
                Next

                mBest_Charts.Add(best_Chart)
                mPerformance.Add(performanceP)

                '---------------------------------------------------------------------

                Chronos.Stop()
                mComputationTime = Chronos.ElapsedMilliseconds
                Chronos.Reset()
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
                fitnessValue += (positions(j) - 1)
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

    End Class
End Namespace

