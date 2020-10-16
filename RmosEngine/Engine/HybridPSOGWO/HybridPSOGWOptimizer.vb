Option Strict On
Imports System.ComponentModel

Namespace GreyWolfOptimizer

    Public Class HybridPSOGWOptimizer

#Region "Properties"
        Private Shared Rndm As New Random(0)

        Private dimension_D As Integer = 36
        Public Property Dimensions As Integer
            Get
                Return dimension_D
            End Get
            Set(value As Integer)
                If value > 0 Then
                    dimension_D = value
                Else
                    dimension_D = 1
                End If
            End Set
        End Property

        Public Property Intervalles As List(Of Intervalle)

        Private Iterations As Integer = 500
        Public Property IterationsCount As Integer
            Get
                Return Iterations
            End Get
            Set(value As Integer)
                If value > 0 Then
                    Iterations = value
                End If
            End Set
        End Property

        Private WolfCount_N As Integer = 10
        Public Property WolvesCount As Integer
            Get
                Return WolfCount_N
            End Get
            Set(value As Integer)
                If value > 0 Then
                    WolfCount_N = value
                End If
            End Set
        End Property

        Private BestPositions As Double() = Nothing
        Public ReadOnly Property BestSolution As Double()
            Get
                Return BestPositions
            End Get
        End Property

        Public Property BestChart As List(Of Double)
        Public Property WorstChart As List(Of Double)
        Public Property MeanChart As List(Of Double)

        Dim Chronos As Stopwatch

        Public ReadOnly Property ComputationTime As Long
            Get
                If IsNothing(Chronos) = False Then
                    Return Chronos.ElapsedMilliseconds
                Else
                    Return -1
                End If
            End Get
        End Property

        Dim mOptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Minimization
        Public Property OptimizationType As OptimizationTypeEnum
            Get
                Return mOptimizationType
            End Get
            Set(value As OptimizationTypeEnum)
                mOptimizationType = value
            End Set
        End Property

#Region "Optimization_Parameters"

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
#End Region
#End Region

        Dim eArg As AsyncOptimEventArgs
#Region "Subs & Functions"

        Public Sub LuanchComputation()

            BestChart = New List(Of Double)
            WorstChart = New List(Of Double)
            MeanChart = New List(Of Double)
            '-------------------------------------------
            Dim bestSolution((Me.dimension_D - 1)) As Double
            eArg = New AsyncOptimEventArgs()
            With eArg
                .ProgressPercentage = 0
                .CurrentSate = bestSolution
            End With
            '-------------------------------------------
            Chronos = New Stopwatch()
            Chronos.Start()
            Select Case mOptimizationType
                Case OptimizationTypeEnum.Minimization
                    BestPositions = HybridPSOGWO_Minimization(dimension_D, WolfCount_N, Iterations)
                Case Else
                    BestPositions = HybridPSOGWO_Maximization(dimension_D, WolfCount_N, Iterations)
            End Select
            Chronos.Stop()
        End Sub

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

        Private Function HybridPSOGWO_Minimization(ByVal dimensionD As Integer, SearchAgents_no As Integer, Max_iter As Integer) As Double()

            Dim Alpha_pos((dimensionD - 1)) As Double
            Try

                Dim Alpha_score As Double = Double.MaxValue

                Dim Beta_pos((dimensionD - 1)) As Double
                Dim Beta_score As Double = Double.MaxValue

                Dim Delta_pos((dimensionD - 1)) As Double
                Dim Delta_score As Double = Double.MaxValue

                'Initialize the positions of search agents:
                Dim Positions = Initialization(SearchAgents_no, dimensionD)

                '-------------------PSO variables------------------------------------------
                'Velocities :
                Dim velocity((SearchAgents_no - 1), (dimensionD - 1)) As Double
                Dim rndmIndex As Integer = 0
                For i = 0 To (SearchAgents_no - 1)
                    For j = 0 To (dimensionD - 1)
                        While (rndmIndex = 0)
                            rndmIndex = Rndm.Next(0, 2)
                        End While
                        velocity(i, j) = (0.3 * rndmIndex) * Rndm.NextDouble()
                        rndmIndex = 0I
                    Next
                Next

                Dim w = 0.5 + (0.5 * Rndm.NextDouble())

                Dim fitness As Double = 0R
                Dim worstFitness As Double = Double.MinValue
                Dim meanFitness As Double = 0R

                Dim l As Integer = 0

                While (l < Max_iter)
                    '---------------------------------
                    worstFitness = Double.MinValue
                    meanFitness = 0R
                    '---------------------------------
                    Space_Bound(Positions, dimensionD, SearchAgents_no)

                    For i = 0 To (SearchAgents_no - 1)

                        '% Calculate objective function for each search agent :
                        fitness = ObjectiveFunction(Positions(i))

                        If fitness < Alpha_score Then
                            Alpha_score = fitness '% Update alpha

                            For k = 0 To (dimensionD - 1)
                                Alpha_pos(k) = Positions(i)(k)
                            Next k
                        End If

                        If fitness > Alpha_score And fitness < Beta_score Then
                            Beta_score = fitness '% Update beta
                            For k = 0 To (dimensionD - 1)
                                Beta_pos(k) = Positions(i)(k)
                            Next k

                        End If

                        If fitness > Alpha_score Then
                            If (fitness > Beta_score) And (fitness < Delta_score) Then
                                Delta_score = fitness '% Update delta
                                For k = 0 To (dimensionD - 1)
                                    Delta_pos(k) = Positions(i)(k)
                                Next k
                            End If
                        End If

                        '--------------------Worst and average fitness values-----
                        If fitness > worstFitness Then
                            worstFitness = fitness
                        End If

                        meanFitness += fitness
                        '---------------------------------------------------------
                    Next i

                    '% a decreases linearly fron 2 to 0 :
                    Dim a As Double = 2 - (l * (2 / Max_iter))
                    Dim r1, r2, r3, A1, A2, A3, X1, X2, X3, D_alpha, D_beta, D_delta As Double

                    '% Update the Position of search agents including omegas :
                    For i = 0 To (SearchAgents_no - 1)
                        For j = 0 To (dimensionD - 1)

                            r1 = Rndm.NextDouble() '% r1 Is a random number In [0,1]
                            r2 = Rndm.NextDouble() '% r2 Is a random number In [0,1]

                            A1 = 2 * a * r1 - a '% Equation (3.3)
                            'C1 = 2 * r2 '% Equation (3.4)
                            'C1 = 0.5

                            D_alpha = Math.Abs(C1 * Alpha_pos(j) - w * Positions(i)(j)) '% Equation (3.5)-part 1
                            X1 = Alpha_pos(j) - (A1 * D_alpha) '% Equation (3.6)-part 1

                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()

                            A2 = 2 * a * r1 - a '% Equation (3.3)
                            'C2 = 2 * r2 '% Equation (3.4)
                            'C2 = 0.5

                            D_beta = Math.Abs(C2 * Beta_pos(j) - w * Positions(i)(j)) '% Equation (3.5)-part 2
                            X2 = Beta_pos(j) - (A2 * D_beta) '% Equation (3.6)-part 2

                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()
                            r3 = Rndm.NextDouble()

                            A3 = 2 * a * r1 - a  '% Equation (3.3)
                            'C3 = 2 * r3 '% Equation (3.4)
                            'C3 = 0.5

                            D_delta = Math.Abs(C3 * Delta_pos(j) - w * Positions(i)(j)) '% Equation (3.5)-part 3
                            X3 = Delta_pos(j) - (A3 * D_delta) '% Equation (3.5)-part 3

                            '% velocity updation
                            velocity(i, j) = (w * (velocity(i, j)) + (C1 * r1 * (X1 - Positions(i)(j))) + (C2 * r2 * (X2 - Positions(i)(j))) + (C3 * r3 * (X3 - Positions(i)(j))))

                            '% positions update
                            Positions(i)(j) = Positions(i)(j) + velocity(i, j)

                        Next j
                    Next i
                    
                    Me.BestChart.Add(Alpha_score)
                    Me.WorstChart.Add(worstFitness)
                    Me.MeanChart.Add((meanFitness / SearchAgents_no))

                    '--------------Event---------------------------------------------------------
                    For t = 0 To (Alpha_pos.Count - 1)
                        eArg.CurrentSate(t) = Alpha_pos(t)
                    Next
                    eArg.ProgressPercentage = l
                    RaiseEvent ProgressChanged(Me, eArg)
                    '-----------------------------------------------------------------------------
                    l = l + 1

                End While

                Me.AlphaScore = Alpha_score
                Me.BetaScore = Beta_score
                Me.DeltaScore = Delta_score
            Catch ex As Exception
                Throw ex
            End Try
            Return Alpha_pos

        End Function

        Private Sub Space_Bound(ByRef X()() As Double, D As Integer, N As Integer)

            Dim write As Boolean = False

            Dim Tp(D - 1) As Int32
            Dim Tm(D - 1) As Int32
            Dim TpTildeTm(D - 1) As Int32
            Dim value As Integer = 0I
            Dim TmpArray(D - 1) As Double
            Dim randiDimm(D - 1) As Double

            For i As Integer = 0 To (N - 1)

                For j As Integer = 0 To (D - 1)
                    If X(i)(j) > Me.Intervalles.Item(j).Max_Value Then
                        Tp(j) = 1I
                    Else
                        Tp(j) = 0I
                    End If

                    If X(i)(j) < Me.Intervalles.Item(j).Min_Value Then
                        Tm(j) = 1I
                    Else
                        Tm(j) = 0I
                    End If

                    value = Tp(j) + Tm(j)

                    If value = 0 Then
                        TpTildeTm(j) = 1I
                    Else
                        TpTildeTm(j) = 0I
                    End If
                Next

                '------------------------------------
                For j As Integer = 0 To (D - 1)
                    TmpArray(j) = X(i)(j) * TpTildeTm(j)
                Next
                '-----------------------------------
                For t = 0 To (D - 1)
                    randiDimm(t) = (Rndm.NextDouble() * (Me.Intervalles.Item(t).Max_Value - Me.Intervalles.Item(t).Min_Value) + Me.Intervalles.Item(t).Min_Value) * (Tp(t) + Tm(t))

                Next

                For t = 0 To (D - 1)
                    X(i)(t) = TmpArray(t) + randiDimm(t)
                Next
            Next

        End Sub

        Private Function Initialization(N As Integer, D As Integer) As Double()()
            Dim X(N - 1)() As Double
            Dim dh As Double = 0R
            Dim value As Double = 0R

            dh = (Intervalles(0).Max_Value - Intervalles(0).Min_Value) / N

            For i = 0 To (N - 1)
                X(i) = New Double(D - 1) {}
                value = Intervalles(0).Min_Value

                For j = 0 To (D - 1)
                    X(i)(j) = value
                    value += dh
                Next
            Next



            '--------------------------------------------------
            '            Try
            'Initialization:

            '                Dim value As Double = 0R
            '                Dim signe As Integer = 0

            '                For i = 0 To (N - 1)
            '                    X(i) = New Double(D - 1) {}
            '                Next

            '                For j As Integer = 0 To (D - 1)
            '                    value = (Me.Intervalles.Item(j).Max_Value - Me.Intervalles.Item(j).Min_Value) + Me.Intervalles.Item(j).Min_Value

            '                    For i As Integer = 0 To (N - 1)
            '                        While signe = 0
            '                            signe = Rndm.Next(-1, 2)
            '                        End While
            '                        X(i)(j) = (value * signe * Rndm.NextDouble())
            '                        X(i)(j) = (value * Rndm.NextDouble())
            '                        signe = 0
            '                    Next
            '                Next
            '            Catch ex As Exception
            '                Throw ex
            '            End Try
            '--------------------------------------------------

            Return X
        End Function

        Dim fitnessValue As Double = 0R
        Private Function ObjectiveFunction(ByRef positions() As Double) As Double

            fitnessValue = 0R
            RaiseEvent ObjectiveFunctionComputation(positions, fitnessValue)
            'For i = 0 To (positions.Count - 1)
            '    fitnessValue += positions(i)
            'Next
            Return fitnessValue

        End Function

        Private Function HybridPSOGWO_Maximization(ByVal dimensionD As Integer, SearchAgents_no As Integer, Max_iter As Integer) As Double()

            Dim Alpha_pos((dimensionD - 1)) As Double
            Try

                Dim Alpha_score As Double = Double.MinValue

                Dim Beta_pos((dimensionD - 1)) As Double
                Dim Beta_score As Double = Double.MinValue

                Dim Delta_pos((dimensionD - 1)) As Double
                Dim Delta_score As Double = Double.MinValue

                'Initialize the positions of search agents:
                Dim Positions = Initialization(SearchAgents_no, dimensionD)

                '-------------------PSO variables------------------------------------------
                'Velocities :
                Dim velocity((SearchAgents_no - 1), (dimensionD - 1)) As Double
                Dim rndmIndex As Integer = 0
                For i = 0 To (SearchAgents_no - 1)
                    For j = 0 To (dimensionD - 1)
                        While (rndmIndex = 0)
                            rndmIndex = Rndm.Next(0, 2)
                        End While
                        velocity(i, j) = (0.3 * rndmIndex) * Rndm.NextDouble()
                        rndmIndex = 0I
                    Next
                Next

                Dim w = 0.5 + (0.5 * Rndm.NextDouble())

                Dim fitness As Double = 0R
                Dim worstFitness As Double = Double.MaxValue
                Dim meanFitness As Double = 0R
                Dim l As Integer = 0

                While (l < Max_iter)

                    '---------------------------------
                    worstFitness = Double.MaxValue
                    meanFitness = 0R
                    '---------------------------------

                    Space_Bound(Positions, dimensionD, SearchAgents_no)

                    For i = 0 To (SearchAgents_no - 1)

                        '% Calculate objective function for each search agent :
                        fitness = ObjectiveFunction(Positions(i))

                        If fitness > Alpha_score Then
                            Alpha_score = fitness '% Update alpha

                            For k = 0 To (dimensionD - 1)
                                Alpha_pos(k) = Positions(i)(k)
                            Next k
                        End If

                        If fitness < Alpha_score And fitness > Beta_score Then
                            Beta_score = fitness '% Update beta
                            For k = 0 To (dimensionD - 1)
                                Beta_pos(k) = Positions(i)(k)
                            Next k

                        End If

                        If fitness < Alpha_score Then
                            If (fitness < Beta_score) And (fitness > Delta_score) Then
                                Delta_score = fitness '% Update delta
                                For k = 0 To (dimensionD - 1)
                                    Delta_pos(k) = Positions(i)(k)
                                Next k
                            End If
                        End If

                        '--------------------Worst and average fitness values-----
                        If fitness < worstFitness Then
                            worstFitness = fitness
                        End If

                        meanFitness += fitness
                        '---------------------------------------------------------

                    Next i

                    '% a decreases linearly fron 2 to 0 :
                    Dim a As Double = 2 - (l * (2 / Max_iter))
                    Dim r1, r2, r3, A1, A2, A3, X1, X2, X3, D_alpha, D_beta, D_delta As Double

                    '% Update the Position of search agents including omegas :
                    For i = 0 To (SearchAgents_no - 1)
                        For j = 0 To (dimensionD - 1)

                            r1 = Rndm.NextDouble() '% r1 Is a random number In [0,1]
                            r2 = Rndm.NextDouble() '% r2 Is a random number In [0,1]

                            A1 = 2 * a * r1 - a '% Equation (3.3)
                            'C1 = 2 * r2 '% Equation (3.4)
                            'C1 = 0.5

                            D_alpha = Math.Abs(C1 * Alpha_pos(j) - w * Positions(i)(j)) '% Equation (3.5)-part 1
                            X1 = Alpha_pos(j) - (A1 * D_alpha) '% Equation (3.6)-part 1

                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()

                            A2 = 2 * a * r1 - a '% Equation (3.3)
                            'C2 = 2 * r2 '% Equation (3.4)
                            'C2 = 0.5

                            D_beta = Math.Abs(C2 * Beta_pos(j) - w * Positions(i)(j)) '% Equation (3.5)-part 2
                            X2 = Beta_pos(j) - (A2 * D_beta) '% Equation (3.6)-part 2

                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()
                            r3 = Rndm.NextDouble()

                            A3 = 2 * a * r1 - a  '% Equation (3.3)
                            'C3 = 2 * r3 '% Equation (3.4)
                            'C3 = 0.5

                            D_delta = Math.Abs(C3 * Delta_pos(j) - w * Positions(i)(j)) '% Equation (3.5)-part 3
                            X3 = Delta_pos(j) - (A3 * D_delta) '% Equation (3.5)-part 3

                            '% velocity updation
                            velocity(i, j) = (w * (velocity(i, j)) + (C1 * r1 * (X1 - Positions(i)(j))) + (C2 * r2 * (X2 - Positions(i)(j))) + (C3 * r3 * (X3 - Positions(i)(j))))

                            '% positions update
                            Positions(i)(j) = Positions(i)(j) + velocity(i, j)

                        Next j
                    Next i

                    l = l + 1
                    Me.BestChart.Add(Alpha_score)
                End While

                Me.AlphaScore = Alpha_score
                Me.BetaScore = Beta_score
                Me.DeltaScore = Delta_score

            Catch ex As Exception
                Throw ex
            End Try
            Return Alpha_pos

        End Function

#End Region

#Region "Events"
        Public Event ObjectiveFunctionComputation(ByRef positions() As Double, ByRef fitnessValue As Double)
        Public Event ProgressChanged(sender As Object, e As AsyncOptimEventArgs)
#End Region

#Region "Overrides_Overloads"
        Public Overrides Function ToString() As String
            Dim message As String = "Best Solution : "
            If IsNothing(BestPositions) = False Then
                For i As Integer = 0 To (BestPositions.Count - 1)
                    message += BestPositions(i).ToString() & "   "
                Next
                message += String.Format("| Fitness value : {0}", ObjectiveFunction(BestPositions).ToString())
            End If

            Return message
        End Function

        Public Overloads Function ToString(format As String) As String
            Dim message As New Text.StringBuilder()
            With message
                .AppendLine("The best solution obtained by H-PSOGWO is : ")
                If IsNothing(BestPositions) = False Then
                    For i As Integer = 0 To (BestPositions.Count - 1)
                        .Append(BestPositions(i).ToString(format)).Append("  ")
                    Next
                End If
                .AppendLine("")
                .AppendLine("The best optimal value of the objective funciton found by PSOGWO is :")
                .AppendLine(Me.AlphaScore.ToString(format))
            End With

            Return message.ToString()
        End Function
#End Region

    End Class

End Namespace

