Option Strict On
Imports System.ComponentModel
Imports IOOperations.Components

Namespace GreyWolfOptimizer
    Public Class GWOEngine_1
        Inherits OptimizationEngineBase

        Private GW_Optimizer As GWOptimizer = Nothing
        Private Chronos As Stopwatch = Nothing

#Region "Hydraulic local variables"

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

#End Region

#Region "Properties"
        Public Overrides Property Name As String = "GWO-Engine"

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

        Dim mBest_Solutions As List(Of DataSerie1D)
        Public Overrides ReadOnly Property Best_Solutions As List(Of DataSerie1D)
            Get
                Return mBest_Solutions
            End Get
        End Property

        Dim mBest_Charts As List(Of IOOperations.Components.DataSerie1D) = Nothing
        <Category("Results")> Public Overrides ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
            Get
                Return mBest_Charts
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
            R_Result = New DataSerie1D()
            S_Result = New DataSerie1D()
            O_Result = New DataSerie1D()

            Evaporation = New IOOperations.Components.DataSerie1D()
            Infiltration = New IOOperations.Components.DataSerie1D()

            Me.Intervalles = New List(Of Intervalle)
            For i As Integer = 0 To 11
                Me.Intervalles.Add(New Intervalle With {.Min_Value = Min_Release, .Max_Value = Max_Release})
            Next

            '-------------GA---------------------------
            S0 = Initial_Storage
            Smin = Min_Storage
            Smax = Max_Storage
            '------------------------------------------
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
                If IsNothing(GW_Optimizer) Then
                    GW_Optimizer = New GWOptimizer()
                End If

                Initialization()

                If CheckData() = False Then Return
                '---------------------------------------------------------------------------------

                If IsNothing(Chronos) Then Chronos = New Stopwatch()

                '-----------Objective function----------------------------------------------------
                AddHandler GW_Optimizer.ObjectiveFunctionComputation, AddressOf FitnessObjectiveFunction
                '----------------------------------------------------------------------------------
                mBest_Solutions = New List(Of DataSerie1D)
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
                    GW_Optimizer.Intervalles = Me.Intervalles
                    GW_Optimizer.LuanchComputation()

                    k = 0

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

                    S0 = Si(12)

                    '------------------------ Best Solution ------------------------------
                    best_chart = New DataSerie1D() With {.Name = String.Format("Year [{0}]", t)}
                    With best_chart
                        .Title = .Name
                        .Description = .Name
                        .X_Title = "Fitness"
                    End With
                    ss = 0
                    For Each bc In GW_Optimizer.BestChart
                        best_chart.Add(ss.ToString(), bc)
                        ss += 1
                        '------------------------------------------
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



#Region "Objective_Function"
        'Private sum As Double = 0R
        Private Penalty_1, Penalty_2 As Double
        Public Overloads Sub FitnessObjectiveFunction(ByRef positions() As Double, ByRef fitnessValue As Double)

            For i As Integer = 0 To (Dimensions_D - 1)
                Si(i) = 0
                Penalty_1 = 0R
                Penalty_2 = 0R
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
                    Penalty_2 += Math.Pow(((Si(j + 1) - Smax) / Smax), 2)
                    'Si(j + 1) = Smax
                ElseIf Si(j + 1) < Smin Then
                    Penalty_1 += Math.Pow((Smin - Si(j + 1)), 2) / Smin
                    'Si(j + 1) = Smin
                End If

            Next

            fitnessValue = 0R
            For j As Int32 = 0 To (Dimensions_D - 1)
                fitnessValue += Math.Abs((positions(j) - Di(j)))
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

