Option Strict On
Imports System.ComponentModel
Namespace GravitationalSearchAlgorithm

    Public Class GSAEngine
        Inherits OptimizationEngineBase

        Private GSA_Optimizer As GSAOptimizer
#Region "Local variables"

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

        Private chronos As New Stopwatch()
#End Region

        Public Overrides Property Name As String = "GSA-Engine"

        Dim mInflowSerie As IOOperations.Components.DataSerie1D
        <Category("Data")> Public Overrides Property InflowSerie As IOOperations.Components.DataSerie1D
            Get
                Return mInflowSerie
            End Get
            Set(value As IOOperations.Components.DataSerie1D)
                mInflowSerie = value
            End Set
        End Property

        Dim mEvaporation As IOOperations.Components.DataSerie1D
        <Category("Data")> Public Overrides Property Evaporation As IOOperations.Components.DataSerie1D
            Get
                Return mEvaporation
            End Get
            Set(value As IOOperations.Components.DataSerie1D)
                mEvaporation = value
            End Set
        End Property

        Dim mInfiltration As IOOperations.Components.DataSerie1D
        <Category("Data")> Public Overrides Property Infiltration As IOOperations.Components.DataSerie1D
            Get
                Return mInfiltration
            End Get
            Set(value As IOOperations.Components.DataSerie1D)
                mInfiltration = value
            End Set
        End Property

        Dim mDemands As IOOperations.Components.DataSerie1D
        <Category("Data")> Public Overrides Property Demands As IOOperations.Components.DataSerie1D
            Get
                Return mDemands
            End Get
            Set(value As IOOperations.Components.DataSerie1D)
                mDemands = value
            End Set
        End Property

        <Category("Results")> Public Overrides ReadOnly Property Release As IOOperations.Components.DataSerie1D
            Get
                Return Me.R_Result
            End Get

        End Property

        <Category("Results")> Public Overrides ReadOnly Property Storage As IOOperations.Components.DataSerie1D
            Get
                Return Me.S_Result
            End Get

        End Property

        <Category("Results")> Public Overrides ReadOnly Property OverFlow As IOOperations.Components.DataSerie1D
            Get
                Return Me.O_Result
            End Get

        End Property

        <Category("Data")> Public Overrides Property Min_Storage As Double
            Get
                Return Smin
            End Get
            Set(value As Double)
                Smin = value
            End Set
        End Property

        <Category("Data")> Public Overrides Property Max_Storage As Double
            Get
                Return Smax
            End Get
            Set(value As Double)
                Smax = value
            End Set
        End Property

        Dim mObjective_Storage As IOOperations.Components.DataSerie1D
        Public Property Objective_Storage As IOOperations.Components.DataSerie1D
            Get
                Return mObjective_Storage
            End Get
            Set(value As IOOperations.Components.DataSerie1D)
                mObjective_Storage = value
            End Set
        End Property

        Private Sub ROM_Function(ByRef gsaAlgo As GSAOptimizer)

            Dim X(,) As Double = gsaAlgo.X

            Dim N As Integer = gsaAlgo.N_Agents - 1

            Try
                '[Qj]:
                'Dim Qi(D) As Double
                'ReDim Si((D + 1))
                'Dim Di(D) As Double

                For i As Integer = 0 To (Dimensions_D - 1)
                    ' Oi(i) = 0
                    Si(i) = 0

                    Qi(i) = 2.458

                    Di(i) = 5.66
                Next

                Si(0) = S0

                'Min(s= x+y+z+t), [-min, max] :
                Dim sum As Double = 0R
                For i As Integer = 0 To N
                    sum = 0.0R
                    Si(0) = S0

                    For j As Integer = 0 To (Dimensions_D - 1)

                        Si(j + 1) = (Si(j) + Qi(j)) - X(i, j)

                        If Si(j + 1) > Smax Then

                            Si(j + 1) = Smax

                        End If
                    Next

                    For j As Int32 = 0 To (Dimensions_D - 1)
                        If Si(j) < Smin Then
                            ' sum += 10 * Math.Pow((X(i, j) - Di(j)), 2) + 10 * Math.Pow((Smax - Si(j + 1)), 2)
                            sum += 50 * Math.Pow((Smax - Si(j + 1)), 2) + 50 * Math.Pow((X(i, j) - Di(j)), 2)

                            'sum += 10 * Math.Abs((Smax - Si(j + 1))) + 10 * Math.Abs((X(i, j) - Di(j)))

                        Else

                            sum += 0.8 * Math.Pow((X(i, j) - Di(j)), 2) + 0.2 * Math.Pow((Smax - Si(j + 1)), 2)

                        End If

                    Next
                    gsaAlgo.Fitness(i) = sum
                Next

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        'Shared Function Objective_Function(ByRef X(,) As Double, ByVal N As Integer, ByVal D As Integer) As Double()

        '    Dim fitness(N) As Double
        '    Try

        '        For i As Integer = 0 To D
        '            ' Oi(i) = 0
        '            Si(i) = 0
        '            'Qi(i) = 2.458
        '            'Di(i) = 5.66
        '        Next

        '        Si(0) = S0

        '        'Min(s= x+y+z+t), [-min, max] :
        '        Dim sum As Double = 0R
        '        For i As Integer = 0 To N
        '            sum = 0.0R
        '            Si(0) = S0

        '            For j As Integer = 0 To D

        '                Si(j + 1) = (Si(j) + Qi(j)) - X(i, j)

        '                If Si(j + 1) > Smax Then

        '                    Si(j + 1) = Smax

        '                ElseIf Si(j + 1) < Smin Then

        '                    Si(j + 1) = Smin

        '                End If
        '            Next

        '            For j As Int32 = 0 To D
        '                If Si(j) < (Smin + Di(j)) Then
        '                    ' sum += 10 * Math.Pow((X(i, j) - Di(j)), 2) + 10 * Math.Pow((Smax - Si(j + 1)), 2)
        '                    'sum += 50 * Math.Pow((Smax - Si(j + 1)), 2) + 50 * Math.Pow((X(i, j) - Di(j)), 2)
        '                    'sum += 1 * Math.Pow((Smax - Si(j + 1)), 2) + 1 * Math.Pow((X(i, j) - Di(j)), 2)
        '                    sum += 1 * Math.Pow((0 - Di(j)), 2)
        '                Else

        '                    sum += 1 * Math.Pow((X(i, j) - Di(j)), 2) '+ 0.1 * Math.Pow((Objective_Si(j) - Si(j + 1)), 2)

        '                End If

        '            Next
        '            fitness(i) = sum
        '        Next

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        '    Return fitness
        'End Function

        '<Category("GSA")> Public ReadOnly Property Dimensions_D As Integer
        '    Get
        '        Return Me.TotalTimePeriod
        '    End Get
        'End Property

        Dim mG0_Value As Double = 120.0R
        <Category("GSA")> Public Property G0_Value As Double
            Get
                Return mG0_Value
            End Get
            Set(value As Double)
                mG0_Value = value
            End Set
        End Property

        <Category("GSA")> Public Property Alpha As Double = 20

        'Dim mBest_Chart As IOOperations.Components.DataSerie1D
        '<Category("Results GSA")> Public ReadOnly Property Best_Chart As IOOperations.Components.DataSerie1D
        '    Get
        '        Return mBest_Chart
        '    End Get
        'End Property

        Dim mBest_Charts As List(Of IOOperations.Components.DataSerie1D) = Nothing
        <Category("Results GSA")> Public Overrides ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
            Get
                Return mBest_Charts
            End Get
        End Property

        Dim mPerformance As List(Of IOOperations.Components.DataSerie3D) = Nothing
        <Category("Results GSA")> Public Overrides ReadOnly Property Performance As List(Of IOOperations.Components.DataSerie3D)
            Get
                Return mPerformance
            End Get
        End Property

        Dim mComputationTime As Long = 0
        <Category("Results")> Public Overrides ReadOnly Property ComputationTime As Long
            Get
                Return mComputationTime
            End Get
        End Property

        <Category("GSA")> Public ReadOnly Property Dimensions_D As Integer
            Get
                Return Me.TotalTimePeriod
            End Get
        End Property

        Dim R_Result As IOOperations.Components.DataSerie1D
        Dim S_Result As IOOperations.Components.DataSerie1D
        Dim O_Result As IOOperations.Components.DataSerie1D

        Public Overrides Sub Luanch_Optimization()

            'Initialisation :
            If CheckData() = False Then Return
            '-------------------------------------------------------------------------
            ' If IsNothing(GSA_Optimizer) Then
            GSA_Optimizer = New GSAOptimizer() With {.D_Dimensions = Me.TotalTimePeriod}
            ' End If
            '--------Set Objectif function---------
            AddHandler GSA_Optimizer.ObjectiveFunction, AddressOf ObjectiveFunction
            'AddHandler GSA_Optimizer.ObjectiveFunction, AddressOf Function_F1
            '--------------------------------------
            Initialization()

            Dim best_Chart As IOOperations.Components.DataSerie1D
            Dim performanceP As IOOperations.Components.DataSerie3D
            '---------------------------------------------------------
            'Dim j As Integer = 0
            Dim i As Integer = 0
            Dim k As Integer = 0
            Dim ss As Integer = 0
            Dim storageTp1 As Double = 0
            Dim releaseStar As Double = 0R
            '-----------------------------------------
            S0 = Me.Initial_Storage
            '----------------------------------------
            Si(0) = S0

            'GSA computation : 
            chronos.Start()
            GSA_Optimizer.Luanch()

            For Each rr In GSA_Optimizer.BestLine
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

                mEvaporation.Add(k.ToString(), Qevaporation(k))
                mInfiltration.Add(k.ToString(), Qinfiltration(k))

                k += 1
            Next

            '------------------------ Best chart ------------------------------
            best_Chart = New IOOperations.Components.DataSerie1D() With {.Name = String.Format("Fitness Evolution: Total Period = {0} [Time Unit]", Me.TotalTimePeriod)}
            performanceP = New IOOperations.Components.DataSerie3D() With {.Name = String.Format("Performance Evolution: Total Period = {0} [Time Unit]", Me.TotalTimePeriod)}

            With best_Chart
                .Title = String.Format("GSA_Alpha{0}_Go{1}_P{2}_Performance", Alpha, G0_Value, Agents_N)
                .Description = .Name
                .X_Title = "Fitness"
            End With

            With performanceP
                .Title = String.Format("GSA_Alpha{0}_Go{1}_P{2}_Performance", Alpha, G0_Value, Agents_N)
                .Description = .Name
                .X_Title = "Best-Solution"
                .Y_Title = "Worst-Solution"
                .Z_Title = "Mean-Solution"
            End With

            For ss = 0 To (GSA_Optimizer.BestChart.Count - 1)
                best_Chart.Add(ss.ToString(), GSA_Optimizer.BestChart(ss))
                performanceP.Add(ss.ToString(), GSA_Optimizer.BestChart(ss), GSA_Optimizer.WorstChart(ss), GSA_Optimizer.MeanChart(ss))
            Next

            mBest_Charts.Add(best_Chart)
            mPerformance.Add(performanceP)
            '---------------------------------------------------------------------
            chronos.Stop()
            mComputationTime = chronos.ElapsedMilliseconds
            chronos.Reset()
        End Sub

        Private Sub Initialization()
            '------------ Data ------------------------
            '------------ Data ------------------------
            R_Result = New IOOperations.Components.DataSerie1D() With {.Name = "Release (R*)", .Description = "Optimale Release", .Title = "Time", .X_Title = "R*"}
            S_Result = New IOOperations.Components.DataSerie1D() With {.Name = "Storage (S*)", .Description = "Storage", .Title = "Time", .X_Title = "S*"}
            O_Result = New IOOperations.Components.DataSerie1D() With {.Name = "Overflow (O)", .Description = "Overflow", .Title = "Time", .X_Title = "O"}


            mEvaporation = New IOOperations.Components.DataSerie1D() With {.Name = "Evaporation"}
            mInfiltration = New IOOperations.Components.DataSerie1D() With {.Name = "Infiltration"}

            mBest_Charts = New List(Of IOOperations.Components.DataSerie1D)
            mPerformance = New List(Of IOOperations.Components.DataSerie3D)
            '-------------GSA---------------------------
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

                'F1  [-100, 100] d=30: 
                'Me.Intervalles.Add(New RmosEngine.Intervalle With {.Min_Value = -5.12, .Max_Value = 5.12})

            Next i

            'AF14 = Get_F14_aij()

            With GSA_Optimizer
                .N_Agents = Me.Agents_N
                .D_Dimensions = Dimensions_D
                .MaxIterations = Max_Iteration
                .G0 = G0_Value
                .Alpha = Alpha
                .Intervalles = Me.Intervalles
                .OptimizationType = OptimizationType
                .ElitistCheck = ElitistCheckEnum.Equation21
            End With

        End Sub

        Private Function CheckData() As Boolean
            Dim result As Boolean = True
            Try
                If IsNothing(Reservoir) Then
                    result = False
                    Exit Try
                End If

                If IsNothing(Me.InflowSerie) Then
                    result = False
                    Exit Try
                End If
                If IsNothing(Me.InflowSerie.Data) Then
                    result = False
                    Exit Try
                End If

                If IsNothing(Me.Demands) Then
                    result = False
                    Exit Try
                End If
                If IsNothing(Me.Demands.Data) Then
                    result = False
                    Exit Try
                End If

                If Me.mDemands.Data.Count <> mInflowSerie.Data.Count Then
                    result = False
                    Exit Try
                End If

            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

#Region "Objective Functions"

        Dim Sum As Double = 0R
        Private Penalty_1, Penalty_2 As Double
        Private Dmax As Double = 0R
        Private MonthIndex As Integer = 0I

        Private Sub ObjectiveFunction(ByRef gsaOptAlgo As GSAOptimizer)
            ' Dim X(,) As Double = gsaOptAlgo.X
            Try

                For i As Integer = 0 To (Dimensions_D - 1)
                    Si(i) = 0R
                    Qinfiltration(i) = 0R
                    Qevaporation(i) = 0R
                Next

                For i As Integer = 0 To (Agents_N - 1)

                    Si(0) = S0
                    Penalty_1 = 0
                    Penalty_2 = 0
                    MonthIndex = 0I

                    For j As Integer = 0 To (Dimensions_D - 1)

                        Qinfiltration(j) = 0.033 'Reservoir.GetInfiltrationOf(Si(j))
                        Qevaporation(j) = Reservoir.GetEvaporationOf(CType(MonthIndex, HydComponents.MonthsEnum), Si(j), Qi(j), gsaOptAlgo.X(i, j), Qinfiltration(j))

                        Si(j + 1) = (Si(j) + Qi(j)) - (Qinfiltration(j) + Qevaporation(j) + gsaOptAlgo.X(i, j))

                        'Si(j + 1) = (Si(j) + Qi(j)) - X(i, j)

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

                    Next j

                    Sum = 0.0R
                    For j As Int32 = 0 To (Dimensions_D - 1)
                        Sum += Math.Pow(((gsaOptAlgo.X(i, j) - Di(j)) / Dmax), 2)
                    Next

                    If OptimizationType = OptimizationTypeEnum.Minimization Then
                        Sum += (Penalty_1 + Penalty_2)
                    Else
                        Sum -= (Penalty_1 + Penalty_2)
                    End If

                    gsaOptAlgo.Fitness(i) = Sum
                Next
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Private Sub ObjectiveFunction_1(ByRef gsaAlgo As GSAOptimizer)
            Dim X(,) As Double = gsaAlgo.X

            Try

                For i As Integer = 0 To (Dimensions_D - 1)
                    Si(i) = 0R
                    Qinfiltration(i) = 0R
                    Qevaporation(i) = 0R
                Next

                Si(0) = S0

                'Min(s= x+y+z+t), [-min, max] :

                For i As Integer = 0 To (Agents_N - 1)
                    Sum = 0.0R
                    Si(0) = S0

                    For j As Integer = 0 To (Dimensions_D - 1)

                        Qinfiltration(j) = Reservoir.GetInfiltrationOf(Si(j))
                        Qevaporation(j) = Reservoir.GetEvaporationOf(CType(j, HydComponents.MonthsEnum), Si(j), Qi(j), X(i, j), Qinfiltration(j))

                        Si(j + 1) = (Si(j) + Qi(j)) - (Qinfiltration(j) + Qevaporation(j) + X(i, j))

                        'Si(j + 1) = (Si(j) + Qi(j)) - X(i, j)

                        If Si(j + 1) > Smax Then

                            Si(j + 1) = Smax

                        ElseIf Si(j + 1) < Smin Then

                            Si(j + 1) = Smin

                        End If
                    Next

                    For j As Int32 = 0 To (Dimensions_D - 1)
                        'If Si(j) < (Smin + Di(j)) Then
                        '    ' sum += 10 * Math.Pow((X(i, j) - Di(j)), 2) + 10 * Math.Pow((Smax - Si(j + 1)), 2)
                        '    'sum += 50 * Math.Pow((Smax - Si(j + 1)), 2) + 50 * Math.Pow((X(i, j) - Di(j)), 2)
                        '    'sum += 1 * Math.Pow((Smax - Si(j + 1)), 2) + 1 * Math.Pow((X(i, j) - Di(j)), 2)
                        '    sum += 1 * Math.Pow((0 - Di(j)), 2)
                        'Else
                        '    sum += 1 * Math.Pow((X(i, j) - Di(j)), 2) '+ 0.1 * Math.Pow((Objective_Si(j) - Si(j + 1)), 2)
                        'End If

                        Sum += Math.Pow((X(i, j) - Di(j)), 2)
                    Next
                    gsaAlgo.Fitness(i) = Sum
                Next
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

#End Region
#Region "Benchmark Functions"
        Private Sub Function_F1(ByRef gsaAlgo As GSAOptimizer)

            For i = 0 To (Me.Agents_N - 1)
                Sum = 0R
                For j As Int32 = 0 To (Dimensions_D - 1)

                    Sum += Math.Pow(gsaAlgo.X(i, j), 2)
                Next
                gsaAlgo.Fitness(i) = Sum
            Next

        End Sub

        Const pi2 As Double = 2 * Math.PI
        Public Sub Function_F9(ByRef gsaAlgo As GSAOptimizer)

            For i = 0 To (Me.Agents_N - 1)
                Sum = 0R
                For j As Int32 = 0 To (Dimensions_D - 1)
                    Sum += (gsaAlgo.X(i, j) ^ 2) - 10 * Math.Cos((pi2 * gsaAlgo.X(i, j))) + 10
                Next
                gsaAlgo.Fitness(i) = Sum
            Next
        End Sub

        Dim somme, prod As Double
        Public Sub Function_F11(ByRef gsaAlgo As GSAOptimizer)
            For i = 0 To (Me.Agents_N - 1)
                somme = 0
                prod = 1
                For j As Int32 = 0 To (Dimensions_D - 1)

                    somme += Math.Pow(gsaAlgo.X(i, j), 2)
                    prod = prod * (Math.Cos(gsaAlgo.X(i, j) / Math.Sqrt((i + 1))))
                Next
                gsaAlgo.Fitness(i) = (somme / 4000) - prod + 1
            Next
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

        Public Sub Function_F14(ByRef gsaAlgo As GSAOptimizer)

            For k = 0 To (Agents_N - 1)
                Sum = 0R
                For j = 0 To 24

                    somme = 0
                    For i = 0 To 1
                        somme += Math.Pow((gsaAlgo.X(k, i) - AF14(i, j)), 6)
                    Next
                    Sum += 1 / ((j + 1) + somme)
                Next
                gsaAlgo.Fitness(k) = (f14Const + Sum)
            Next
        End Sub
#End Region



    End Class

End Namespace
