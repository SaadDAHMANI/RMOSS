﻿Option Strict On

Namespace GravitationalSearchAlgorithm
    ''' <summary>
    ''' Implemented based on : PSOGSA source code v3.0, Generated by SeyedAli Mirjalili, 2011. 
    ''' Adopted from: S. Mirjalili, S.Z. Mohd Hashim, “A New Hybrid PSOGSA 
    ''' Algorithm for Function Optimization, in IEEE International Conference 
    ''' on Computer and Information Application?ICCIA 2010), China, 2010, pp. 374-377.
    ''' </summary>
    Public Class PSOGSAOptimizer
        Implements IEvolutionaryAlgo

        Public Sub New(dimensions As Integer, agents As Integer, iterationMax As Integer)
            Dimensions_D = dimensions
            Agents_N = agents
            MaxIterations = iterationMax
        End Sub

        Public Sub New(dimensions As Integer, agents As Integer, iterationMax As Integer, gO As Double, alpha_g As Double)
            Dimensions_D = dimensions
            Agents_N = agents
            MaxIterations = iterationMax
            G0 = gO
            Me.Alpha = alpha_g
        End Sub

        Private Sub Initialize()

            For Each interval In Me.Intervalles
                If interval.Max_Value < interval.Min_Value Then
                    Throw New Exception("interval.Max_Value must be > interval.Min_Value ")
                End If
            Next

            mBestChart = New List(Of Double)
            mMeanChart = New List(Of Double)
            mWorstChart = New List(Of Double)

            Current_fitness = New Double(N) {}

            gBest = New Double(D) {}
            pBestScore = New Double(N) {}
            pBest = New Double(N, D) {}


            If OptimizationType = OptimizationTypeEnum.Minimization Then
                gBestScore = Double.MaxValue
            Else
                gBestScore = Double.MinValue
            End If

            Positions = New Double(D) {}
            '-----------Initilize PSO Params---------
            Velocity = New Double(N, D) {}
            Initialize_Velocities()
            Acceleration = New Double(N, D) {}
            '----------------------------------------
            Mass = New Double(N) {}
            Force = New Double(N, D) {}

            'Initialize solutions:
            Current_position = New Double(N, D) {}
            Initialize_X(Current_position)


        End Sub

        Private Sub Initialize_Velocities()
            For i = 0 To N
                For j = 0 To D
                    Velocity(i, j) = 0.3 * Rand.NextDouble()
                Next
            Next
        End Sub

        Private Sub Initialize_X(X(,) As Double)

            Try
                'Initialization :

                Dim value As Double = 0R
                Dim signe As Integer = 0

                For j As Integer = 0 To D
                    value = (Me.Intervalles.Item(j).Max_Value - Me.Intervalles.Item(j).Min_Value) + Me.Intervalles.Item(j).Min_Value

                    For i As Integer = 0 To N
                        While signe = 0
                            signe = Rand.Next(-1, 2)
                        End While
                        X(i, j) = (value * signe * Rand.NextDouble())
                        signe = 0
                    Next
                Next
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Sub RunEpoch() Implements IEvolutionaryAlgo.RunEpoch
            If (Iteration = 0) Then
                Initialize()
            End If

            G = G0 * Math.Exp((-1 * Alpha * Iteration) / MaxIterations)
            Iteration += 1

            'Bound the search Space
            Space_Bound(Current_position)

            For i = 0 To N

                'Evaluate the population
                Fitness = 0R
                For j = 0 To D
                    Positions(j) = Current_position(i, j) 'Copy the positions in vectore Positions.
                Next
                RaiseEvent ObjectiveFunctionComputation(Positions, Fitness)
                Current_fitness(i) = Fitness

                '-----------------------------------------------------------------
                If (pBestScore(i) > Fitness) Then
                    pBestScore(i) = Fitness
                    For j = 0 To D
                        pBest(i, j) = Current_fitness(i)
                    Next
                End If

                If (gBestScore > Fitness) Then
                    gBestScore = Fitness
                    For j = 0 To D
                        gBest(j) = Current_position(i, j) 'Copy the Best solution
                    Next
                End If
            Next

            best = Current_fitness.Min 'For minimisation only
            worst = Current_fitness.Max 'For minimisation only
            '---------------------------------------------------------------
            BestChart.Add(gBestScore)
            MeanChart.Add((Current_fitness.Sum / N))
            WorstChart.Add(Current_fitness.Max) 'For minimisation only
            mCurrentBestFitness = gBestScore
            '-----------------------------------------------------------

            'For pp = 0 To N
            '    If (Current_fitness(pp) = best) Then
            '        bestIndex = pp
            '        Exit For
            '    End If
            'Next

            ' Calculate Mass :

            For i = 0 To N
                Mass(i) = (Current_fitness(i) - 0.99 * worst) / (best - worst)
            Next

            For i = 0 To N
                Mass(i) = Mass(i) * 5 / Mass.Sum
            Next

            ' Force update :

            For i = 0 To N
                For j = 0 To D
                    For k = 0 To N
                        If (Current_position(k, j) <> Current_position(i, j)) Then
                            '   % Equation (3)
                            Force(i, j) = Force(i, j) + Rand.NextDouble() * G * Mass(k) * Mass(i) * (Current_position(k, j) - Current_position(i, j)) / (Math.Abs(Current_position(k, j) - Current_position(i, j)) + Eps)

                        End If
                    Next
                Next
            Next

            'Accelations $ Velocities  UPDATE:

            For i = 0 To N
                For j = 0 To D
                    If (Mass(i) <> 0) Then
                        '%Equation (6)
                        Acceleration(i, j) = Force(i, j) / Mass(i)
                    End If
                Next
            Next

            For i = 0 To N
                For j = 0 To D
                    ' %Equation(9)
                    Velocity(i, j) = Rand.NextDouble() * Velocity(i, j) + C1 * Rand.NextDouble() * Acceleration(i, j) + C2 * Rand.NextDouble() * (gBest(j) - Current_position(i, j))
                Next
            Next

            'Positions UPDATE :

            '%Equation (10) 
            For i = 0 To N
                For j = 0 To D
                    Current_position(i, j) = Current_position(i, j) + Velocity(i, j)
                Next
            Next

        End Sub

        Public Sub Space_Bound(X As Double(,))
            'from matlab site :
            'https://www.mathworks.com/matlabcentral/answers/311735-hi-i-try-to-convert-this-matlab-code-to-vb-net-or-c-codes-help-me-please
            'outofrange = X(i, : ) > up | X(i, :) < low;
            'X(i, outofrange) = rand(1, sum(outofrange)) * (up - low) + low;

            'or-----
            ' Function X = space_bound(X, up, low)
            '   outofrange = X > up | X < low
            '   X(outofrange) = rand(1, sum(outofrange)) * (up - low) + low;
            ' End
            Dim write As Boolean = False

            'Dim rand As New Random()

            Dim Tp(D) As Int32
            Dim Tm(D) As Int32
            Dim TpTildeTm(D) As Int32
            Dim value As Integer = 0I
            Dim TmpArray(D) As Double
            Dim randiDimm(D) As Double


            For i As Integer = 0 To Me.N

                For j As Integer = 0 To Me.D
                    If X(i, j) > Me.Intervalles.Item(j).Max_Value Then
                        Tp(j) = 1I
                        'Debug.Print(String.Format("{0}, Iter = {1}", Me.X(i, j).ToString(), CurrentIteration))
                        'write = True
                        'Show_X(X, "X , > UP : Before.....>")

                    Else
                        Tp(j) = 0I
                    End If

                    If X(i, j) < Me.Intervalles.Item(j).Min_Value Then
                        Tm(j) = 1I

                        'write = True
                        'Debug.Print(String.Format("{0}, Iter = {1}", Me.X(i, j).ToString(), CurrentIteration))
                        ' Show_X(X, "X , < Down : Before.....>")
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
                For j As Integer = 0 To Me.D
                    TmpArray(j) = X(i, j) * TpTildeTm(j)
                Next
                '-----------------------------------
                For t = 0 To Me.D
                    randiDimm(t) = (Rand.NextDouble() * (Me.Intervalles.Item(t).Max_Value - Me.Intervalles.Item(t).Min_Value) + Me.Intervalles.Item(t).Min_Value) * (Tp(t) + Tm(t))

                Next

                For t = 0 To Me.D
                    X(i, t) = TmpArray(t) + randiDimm(t)
                Next


            Next

        End Sub

        Public Sub LuanchComputation() Implements IEvolutionaryAlgo.LuanchComputation
            For Iteration = 0 To MaxIterations
                RunEpoch()
            Next
        End Sub

        Private Shared Rand As Random = New Random()
#Region "Common of Interface: IEvolutionaryAlgo"

        Dim dimensionD As Integer
        Public Property Dimensions_D As Integer Implements IEvolutionaryAlgo.Dimensions_D
            Get
                Return dimensionD
            End Get
            Set(value As Integer)
                dimensionD = Math.Max(0, value)
                Me.D = dimensionD - 1
            End Set
        End Property

        Dim mAgents_N As Integer
        Public Property Agents_N As Integer Implements IEvolutionaryAlgo.Agents_N
            Get
                Return mAgents_N
            End Get
            Set(value As Integer)
                mAgents_N = Math.Max(value, 0)
                Me.N = mAgents_N - 1
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

        Public ReadOnly Property BestSolution As Double() Implements IEvolutionaryAlgo.BestSolution
            Get
                Return gBest
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

        Dim mCurrentBestFitness As Double = Double.NaN
        Public ReadOnly Property CurrentBestFitness As Double Implements IEvolutionaryAlgo.CurrentBestFitness
            Get
                Return mCurrentBestFitness
            End Get
        End Property

#End Region

        Private D, N As Integer
        Private Iteration As Integer = 0I

        Private Current_fitness() As Double
        Private Fitness As Double

        Private gBest() As Double ' The best solution
        Private gBestScore As Double 'The best fitness
        Private pBestScore() As Double
        Private pBest(,) As Double
        Dim best As Double
        Dim worst As Double
        'Dim bestIndex As Integer

        Dim G As Double = 0R
        Private Current_position(,) As Double ' X in Standard GSA
        Private Positions() As Double 'Positions of one agent in all dimensions D.
        Private Mass() As Double
        Private Force(,) As Double
        '---------------GSA params---------------
        Public Property Alpha As Double = 23.0R
        Public Property G0 As Double = 1.0R
        Private Const Eps As Double = 0.00000000000000022204
        Private Acceleration As Double(,)

        '-------------PSO Variables ------------
        Private Velocity(,) As Double
        Public Property C1 As Double = 0.5R 'C1 in Equation (9)
        Public Property C2 As Double = 1.5R 'C2 in Equation (9)



    End Class
End Namespace

