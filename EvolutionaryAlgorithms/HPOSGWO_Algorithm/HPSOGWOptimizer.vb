Option Strict On
Imports System.ComponentModel

Namespace GreyWolfOptimizer
    Public Class HPSOGWOptimizer
        Implements IEvolutionaryAlgo

        Public Sub New(dimensions As Integer, agents As Integer, iterationMax As Integer)
            Dimensions_D = dimensions
            Agents_N = agents
            MaxIterations = iterationMax
        End Sub

        Private Shared Rndm As New Random(0)

#Region "Common of Interface: IEvolutionaryAlgo"

        Dim dimensionD As Integer
        Public Property Dimensions_D As Integer Implements IEvolutionaryAlgo.Dimensions_D
            Get
                Return dimensionD
            End Get
            Set(value As Integer)
                dimensionD = Math.Max(0, value)
            End Set
        End Property

        Dim wolfCountN As Integer
        Public Property Agents_N As Integer Implements IEvolutionaryAlgo.Agents_N
            Get
                Return wolfCountN
            End Get
            Set(value As Integer)
                wolfCountN = Math.Max(value, 0)
            End Set
        End Property

        Dim mIntervalles As List(Of Intervalle)
        Public Property Intervalles As List(Of Intervalle) Implements IEvolutionaryAlgo.Intervalles
            Get
                Return mIntervalles
            End Get
            Set(value As List(Of Intervalle))
                mIntervalles = value
            End Set
        End Property

        Dim iterationsMax As Integer
        Public Property MaxIterations As Integer Implements IEvolutionaryAlgo.MaxIterations
            Get
                Return iterationsMax
            End Get
            Set(value As Integer)
                iterationsMax = Math.Max(value, 0)
            End Set
        End Property

        Dim mOptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Minimization
        Public Property OptimizationType As OptimizationTypeEnum Implements IEvolutionaryAlgo.OptimizationType
            Get
                Return mOptimizationType
            End Get
            Set(value As OptimizationTypeEnum)
                mOptimizationType = value
            End Set
        End Property

        Dim Chronos As Stopwatch
        Public ReadOnly Property ComputationTime As Long Implements IEvolutionaryAlgo.ComputationTime
            Get
                If Object.Equals(Chronos, Nothing) Then
                    Return 0
                Else
                    Return Chronos.ElapsedMilliseconds
                End If
            End Get
        End Property

        Dim mBestSolution As Double()
        Public ReadOnly Property BestSolution As Double() Implements IEvolutionaryAlgo.BestSolution
            Get
                Return mBestSolution
            End Get
        End Property

        Dim mBestChart As List(Of Double)
        Public ReadOnly Property BestChart As List(Of Double) Implements IEvolutionaryAlgo.BestChart
            Get
                Return mBestChart
            End Get
        End Property

        Dim mWorstChart As List(Of Double)
        Public ReadOnly Property WorstChart As List(Of Double) Implements IEvolutionaryAlgo.WorstChart
            Get
                Return mWorstChart
            End Get
        End Property

        Dim mMeanChart As List(Of Double)
        Public ReadOnly Property MeanChart As List(Of Double) Implements IEvolutionaryAlgo.MeanChart
            Get
                Return mMeanChart
            End Get
        End Property

        Dim mSolution_Fitness As Dictionary(Of String, Double)
        Public ReadOnly Property Solution_Fitness As Dictionary(Of String, Double) Implements IEvolutionaryAlgo.Solution_Fitness
            Get
                Return mSolution_Fitness
            End Get
        End Property

        Public Event ObjectiveFunctionComputation(ByRef positions() As Double, ByRef fitnessValue As Double) Implements IEvolutionaryAlgo.ObjectiveFunctionComputation

        Dim mCurrentFitness As Double = Double.NaN
        Public ReadOnly Property CurrentBestFitness As Double Implements IEvolutionaryAlgo.CurrentBestFitness
            Get
                Return mCurrentFitness
            End Get
        End Property

#End Region

#Region "HPSOGWO_Optimization_Parameters"

        Dim C1 As Double = 0.6
        <DisplayName("C1"), Description("Search parameter, default : C1 = 0.5"), DefaultValue(0.5)>
        Public Property C_1 As Double
            Get
                Return C1
            End Get
            Set(value As Double)
                C1 = value
            End Set
        End Property

        Dim C2 As Double = 0.6
        <DisplayName("C2"), Description("Search parameter, default : C2 = 0.5"), DefaultValue(0.5)>
        Public Property C_2 As Double
            Get
                Return C2
            End Get
            Set(value As Double)
                C2 = value
            End Set
        End Property

        Dim C3 As Double = 0.6
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

        Public Sub RunEpoch() Implements IEvolutionaryAlgo.RunEpoch
            If OptimizationType = OptimizationTypeEnum.Minimization Then
                RunEpoch_Minimization()
            Else
                RunEpoch_Maximization()
            End If
        End Sub

#Region "HPSOGWO Optimization"
        '--------------------GWO variables ----------------------------
        Dim Alpha_pos() As Double
        Dim Alpha_score As Double = Double.MaxValue

        Dim Beta_pos() As Double
        Dim Beta_score As Double = Double.MaxValue

        Dim Delta_pos((dimensionD - 1)) As Double
        Dim Delta_score As Double = Double.MaxValue

        Dim Positions()() As Double

        Dim iteration As Integer = 0I
        '-------------------PSO variables------------------------------------------
        'Velocities :
        Dim velocity(,) As Double
        Dim rndmIndex As Integer = 0
        Dim w As Double
        '---------------------------------
        Dim fitness As Double = 0R
        Dim worstFitness As Double = Double.MinValue
        Dim meanFitness As Double = 0R

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

        Dim fitnessValue As Double = 0R
        Private Function ObjectiveFunction(ByRef positions() As Double) As Double
            fitnessValue = 0R
            RaiseEvent ObjectiveFunctionComputation(positions, fitnessValue)
            Return fitnessValue
        End Function


#End Region

        Private Sub RunEpoch_Minimization()
            Try
                If iteration = 0 Then
                    Initialize()
                End If


                ' While (l < Max_iter)
                '---------------------------------
                worstFitness = Double.MinValue
                    meanFitness = 0R
                '---------------------------------
                Space_Bound(Positions, dimensionD, Agents_N)

                For i = 0 To (Agents_N - 1)

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
                Dim a As Double = 2 - (iteration * (2 / MaxIterations))
                Dim r1, r2, r3, A1, A2, A3, X1, X2, X3, D_alpha, D_beta, D_delta As Double

                '% Update the Position of search agents including omegas :
                For i = 0 To (Agents_N - 1)
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

                iteration += 1

                Me.mCurrentFitness = AlphaScore
                Me.BestChart.Add(Alpha_score)
                Me.WorstChart.Add(worstFitness)
                Me.MeanChart.Add((meanFitness / Agents_N))

                For ss = 0 To (dimensionD - 1)
                    mBestSolution(ss) = Alpha_pos(ss)
                Next
                'End While

                Me.AlphaScore = Alpha_score
                Me.BetaScore = Beta_score
                Me.DeltaScore = Delta_score

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub RunEpoch_Maximization()
            Throw New NotImplementedException
        End Sub

        Private Sub Initialize()

            mBestChart = New List(Of Double)
            mWorstChart = New List(Of Double)
            mMeanChart = New List(Of Double)
            mBestSolution = New Double(dimensionD - 1) {}

            '-------------GWO---------------------
            Alpha_pos = New Double(dimensionD - 1) {}
            Beta_pos = New Double(dimensionD - 1) {}
            Delta_pos = New Double(dimensionD - 1) {}

            'Initialize the positions of search agents:
            Positions = Initialization(Agents_N, dimensionD)

            '-------------PSO----------------------
            velocity = New Double((Agents_N - 1), (dimensionD - 1)) {}
            For i = 0 To (Agents_N - 1)
                For j = 0 To (dimensionD - 1)
                    While (rndmIndex = 0)
                        rndmIndex = Rndm.Next(0, 2)
                    End While
                    velocity(i, j) = (0.3 * rndmIndex) * Rndm.NextDouble()
                    rndmIndex = 0I
                Next
            Next

            w = 0.5 + (0.5 * Rndm.NextDouble())
            '-----------------------------------------
            iteration = 0I

            If OptimizationType = OptimizationTypeEnum.Minimization Then
                Alpha_score = Double.MaxValue
                Beta_score = Double.MaxValue
                Delta_score = Double.MaxValue
                worstFitness = Double.MinValue

            Else
                Alpha_score = Double.MinValue
                Beta_score = Double.MinValue
                Delta_score = Double.MinValue
                worstFitness = Double.MaxValue
            End If



        End Sub




        Public Sub LuanchComputation() Implements IEvolutionaryAlgo.LuanchComputation
            Throw New NotImplementedException()
        End Sub
    End Class
End Namespace

