Option Strict On
Imports System.ComponentModel
Namespace GravitationalSearchAlgorithm

    Public Class GSAEngine1
        Inherits OptimizationEngineBase

#Region "Local variables"

        Private Si(12) As Double

        Private Objective_Si(11) As Double

        Private Oi(11) As Double

        Private Qi(11) As Double
        Private Di(11) As Double

        Private S0 As Double = 117.543

        Private Smax As Double = 170
        Private Smin As Double = 23.3

        Private Qinfiltration(11) As Double
        Private Qevaporation(11) As Double

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

                For i As Integer = 0 To (Dimensions_D1 - 1)
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

                    For j As Integer = 0 To (Dimensions_D1 - 1)

                        Si(j + 1) = (Si(j) + Qi(j)) - X(i, j)

                        If Si(j + 1) > Smax Then

                            Si(j + 1) = Smax

                        End If
                    Next

                    For j As Int32 = 0 To (Dimensions_D1 - 1)
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

        Dim Dimensions_D As Integer = 12
        <Category("GSA")> Public ReadOnly Property Dimensions As Integer
            Get
                Return Dimensions_D1
            End Get
        End Property

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

        <Category("Results")> Public Overrides ReadOnly Property ComputationTime As Long
            Get
                Return chronos.ElapsedMilliseconds
            End Get
        End Property

        Public Property Dimensions_D1 As Integer
            Get
                Return Dimensions_D
            End Get
            Set(value As Integer)
                Dimensions_D = value
            End Set
        End Property

        Dim R_Result As IOOperations.Components.DataSerie1D
        Dim S_Result As IOOperations.Components.DataSerie1D
        Dim O_Result As IOOperations.Components.DataSerie1D

        Public Overrides Sub Luanch_Optimization()

            'Initialisation :
            Initialization()
            Dim best_Chart As IOOperations.Components.DataSerie1D
            '---------------------------------------------------------
            If CheckData() = False Then Return

            'Intervalles :
            Dim intervalles As New List(Of Intervalle)
            For ii As Integer = 0 To 12
                intervalles.Add(New Intervalle With {.Min_Value = Min_Release, .Max_Value = Max_Release})
            Next

            '-------------------------------------------------------------------------
            Dim gsAlgo As New GSAOptimizer()
            '--------Set Objectif function---------
            AddHandler gsAlgo.ObjectiveFunction, AddressOf ObjectiveFunction
            '--------------------------------------
            With gsAlgo

                .N_Agents = Agents_N
                .D_Dimensions = Dimensions_D1
                .MaxIterations = Max_Iteration

                .G0 = G0_Value
                .Alpha = Alpha

                .Intervalles = intervalles

                .OptimizationType = OptimizationType

                .ElitistCheck = ElitistCheckEnum.Equation21

            End With

            '------------------------------------------
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

            chronos.Start()

            For t As Int32 = 0 To yearT

                'Set Inflows & Demands :
                For i = 0 To 11

                    Qi(i) = mInflowSerie.Data(j).X_Value
                    Di(i) = mDemands.Data(j).X_Value

                    j += 1
                Next

                'GSA computation : 
                gsAlgo.Luanch()

                k = 0
                For Each rr In gsAlgo.BestLine
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

                S0 = Si(12)

                '------------------------ Best chart ------------------------------
                best_Chart = New IOOperations.Components.DataSerie1D() With {.Name = String.Format("Fitness Evolution: Year [{0}]", t)}
                With best_Chart
                    .Title = .Name
                    .Description = .Name
                    .X_Title = "Fitness"
                End With
                ss = 0
                For Each bc In gsAlgo.BestChart
                    best_Chart.Add(ss.ToString(), bc)
                    ss += 1
                Next
                mBest_Charts.Add(best_Chart)
                '---------------------------------------------------------------------
            Next t

            chronos.Stop()
        End Sub

        Private Sub Initialization()
            '------------ Data ------------------------
            R_Result = New IOOperations.Components.DataSerie1D()
            S_Result = New IOOperations.Components.DataSerie1D()
            O_Result = New IOOperations.Components.DataSerie1D()

            mEvaporation = New IOOperations.Components.DataSerie1D()
            mInfiltration = New IOOperations.Components.DataSerie1D()

            mBest_Charts = New List(Of IOOperations.Components.DataSerie1D)

            If IsNothing(mObjective_Storage) OrElse IsNothing(mObjective_Storage.Data) Then
                For i As Integer = 0 To 11
                    Objective_Si(i) = Smax
                Next
            ElseIf mObjective_Storage.Data.Count <> 12 Then
                For i As Integer = 0 To 11
                    Objective_Si(i) = Smax
                Next
            Else
                For i As Integer = 0 To 11
                    Objective_Si(i) = mObjective_Storage.Data(i).X_Value
                Next
            End If

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

        Private Sub ObjectiveFunction(ByRef gsaAlgo As GSAOptimizer)
            Dim X(,) As Double = gsaAlgo.X

            Try

                For i As Integer = 0 To (Dimensions_D1 - 1)
                    Si(i) = 0R
                    Penalty_1 = 0
                    Penalty_2 = 0
                    Qinfiltration(i) = 0R
                    Qevaporation(i) = 0R
                Next

                Si(0) = S0

                For i As Integer = 0 To (Agents_N - 1)
                    Sum = 0.0R
                    Si(0) = S0

                    For j As Integer = 0 To (Dimensions_D1 - 1)

                        Qinfiltration(j) = 0.033 'Reservoir.GetInfiltrationOf(Si(j))
                        Qevaporation(j) = Reservoir.GetEvaporationOf(CType(j, HydComponents.MonthsEnum), Si(j), Qi(j), X(i, j), Qinfiltration(j))

                        Si(j + 1) = (Si(j) + Qi(j)) - (Qinfiltration(j) + Qevaporation(j) + X(i, j))

                        'Si(j + 1) = (Si(j) + Qi(j)) - X(i, j)

                        If Si(j + 1) > Smax Then
                            Penalty_2 += Math.Pow(((Si(j + 1) - Smax) / Smax), 2)
                            'Si(j + 1) = Smax
                        ElseIf Si(j + 1) < Smin Then
                            Penalty_1 += Math.Pow((Smin - Si(j + 1)), 2) / Smin
                            'Si(j + 1) = Smin
                        End If

                    Next

                    For j As Int32 = 0 To (Dimensions_D1 - 1)
                        Sum += Math.Abs((X(i, j) - Di(j)))
                    Next

                    If OptimizationType = OptimizationTypeEnum.Minimization Then
                        Sum += (Penalty_1 + Penalty_2)
                    Else
                        Sum -= (Penalty_1 + Penalty_2)
                    End If

                    gsaAlgo.Fitness(i) = Sum
                Next
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Private Sub ObjectiveFunction_1(ByRef gsaAlgo As GSAOptimizer)
            Dim X(,) As Double = gsaAlgo.X

            Try

                For i As Integer = 0 To (Dimensions_D1 - 1)
                    Si(i) = 0R
                    Qinfiltration(i) = 0R
                    Qevaporation(i) = 0R
                Next

                Si(0) = S0

                'Min(s= x+y+z+t), [-min, max] :

                For i As Integer = 0 To (Agents_N - 1)
                    Sum = 0.0R
                    Si(0) = S0

                    For j As Integer = 0 To (Dimensions_D1 - 1)

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

                    For j As Int32 = 0 To (Dimensions_D1 - 1)
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

    End Class

End Namespace

