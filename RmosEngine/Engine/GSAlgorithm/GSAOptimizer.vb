Option Strict On
Imports System.ComponentModel
Imports RmosEngine
Imports RmosEngine.GravitationalSearchAlgorithm

Namespace GravitationalSearchAlgorithm

    Public Class GSAOptimizer

#Region "Public Var"
        Public Property OptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Minimization

        Dim mN_Agents As Integer = 3
        Public Property N_Agents As Integer
            Get
                Return mN_Agents
            End Get
            Set(value As Integer)
                If value > 0 Then
                    mN_Agents = value
                    Me.N = mN_Agents - 1
                Else
                    mN_Agents = 3
                    Me.N = mN_Agents - 1
                End If
            End Set
        End Property

        Dim mD_Dimensions As Integer = 4
        Public Property D_Dimensions As Integer
            Get
                Return mD_Dimensions
            End Get
            Set(value As Integer)
                If value > 0 Then
                    mD_Dimensions = value
                    Me.D = mD_Dimensions - 1
                Else
                    mD_Dimensions = 4
                    Me.D = mD_Dimensions - 1
                End If
            End Set
        End Property

        Dim mMaxIterations As Integer = 5I
        Public Property MaxIterations As Integer
            Get
                Return mMaxIterations
            End Get
            Set(value As Integer)
                If value > 1 Then
                    mMaxIterations = value
                End If
            End Set
        End Property

        'Public Property Min_Intervalle As Double
        '    Get
        '        Return Down
        '    End Get
        '    Set(value As Double)
        '        Down = value
        '    End Set
        'End Property

        'Public Property Max_Intervalle As Double
        '    Get
        '        Return Up
        '    End Get
        '    Set(value As Double)
        '        Up = value
        '    End Set
        'End Property

        Public Property Intervalles As List(Of Intervalle)

        Public Property MeanChart As List(Of Double)
        Public Property WorstChart As List(Of Double)

        ''' <summary>
        ''' Best solution
        ''' </summary>
        ''' <returns></returns>
        Public Property BestLine As Double() = Nothing

        Public Property Alpha As Double = 20.0R
        Public Property G0 As Double = 100.0R

        Public Property X As Double(,)
        Public Fitness() As Double = Nothing

        ''' <summary>
        ''' ElitistCheck: If ElitistCheck=1, algorithm runs with eq.21 and if =0, runs with eq.9.
        ''' </summary>
        ''' <returns></returns>
        Public Property ElitistCheck As ElitistCheckEnum = ElitistCheckEnum.Equation21

        Public Property BestChart As List(Of Double)

#End Region

#Region "Private Var"

        Private Const Eps As Double = 0.00000000000000022204
        Private N As Integer
        Private D As Integer
        Private Rnorme As Integer = 2I
        Private Rpower As Integer = 1I

        'Private Up As Double = 500
        'Private Down As Double = 0.1

        Private CurrentIteration As Integer = 0I
        Private Rand As Random
        Private eArg As AsyncOptimEventArgs

#End Region

        Public Sub Luanch()
            '-Initialization : --------------------------------------------------------------
            For Each interval In Me.Intervalles
                If interval.Max_Value < interval.Min_Value Then
                    Throw New Exception("interval.Max_Value must be > interval.Min_Value ")
                End If
            Next
            Rand = New Random()
            Me.BestChart = New List(Of Double)
            Me.MeanChart = New List(Of Double)
            Me.WorstChart = New List(Of Double)
            ReDim BestLine((Me.D_Dimensions - 1))
            '-------------------------------------------
            Dim bestSolution((Me.D_Dimensions - 1)) As Double

            eArg = New AsyncOptimEventArgs()
            With eArg
                .ProgressPercentage = 0
                .CurrentSate = bestSolution
            End With
            '-------------------------------------------
            '--------------------------------------------------------------------------------
            Initialize_X()
            Computation()
        End Sub

        Private Sub Computation()
            Dim best As Double = Double.NaN
            Dim best_X As Integer = 0I
            Dim Fbest As Double = Double.NaN

            Dim Lbest(D) As Double 'Best line (solution)
            Dim meanValue As Double = Double.NaN
            Dim worstValue As Double = Double.NaN
            '---------------------------------
            Dim M(N) As Double
            Dim Ms(N) As Double
            Dim Ds(N) As Integer
            '---------------------------------
            Dim Gvalue As Double = Double.NaN
            Dim accelerations(N, D) As Double
            Dim E(N, D) As Double
            Dim V(N, D) As Double

            '---------------------------------

            For iteration As Integer = 1 To MaxIterations
                Me.CurrentIteration = iteration

                '0: Checking allowable range :
                Space_Bound()

                '1: Fitness Evaluation :
                'Dim fitness As Double() = EvaluateF()
                EvaluateFitness(Me.Fitness)
                '-----------------------
                'Show_X_D(fitness, "----------------->Fitness<----------------")

                '-----------------------
                If OptimizationType = OptimizationTypeEnum.Minimization Then
                    best = Fitness.Min
                    best_X = Array.IndexOf(Fitness, best)
                Else
                    best = Fitness.Max
                    best_X = Array.IndexOf(Fitness, best)
                End If

                If iteration = 1 Then
                    Fbest = best
                    GetBestLine(X, Lbest, best_X)
                End If

                If OptimizationType = OptimizationTypeEnum.Minimization Then
                    '%minimization.
                    If best < Fbest Then
                        Fbest = best
                        GetBestLine(X, Lbest, best_X)

                    End If

                Else
                    '%maximization
                    If best > Fbest Then
                        Fbest = best
                        GetBestLine(X, Lbest, best_X)
                    End If

                End If

                Me.BestChart.Add(Fbest)

                meanValue = Get_MeanValue(Fitness)
                worstValue = Get_WorstValue(Fitness)

                Me.MeanChart.Add(meanValue)
                Me.WorstChart.Add(worstValue)

                ''***************************************************
                'If iteration > 5 Then
                '    If Math.Abs(BestChart.Item((iteration - 1)) - BestChart.Item((iteration - 2))) < (10 ^ -15) Then
                '        Debug.Print("Iteration = {0} ", iteration)
                '        Exit For
                '    End If
                'End If
                ''***************************************************

                '2: Calculation of M. eq.14-20 :
                Mass_Calculation(M, Fitness)

                'Show_X(M, "Masses :")

                '3 : Calculation of Gravitational constant. eq.13 :
                Gvalue = Gconstant(iteration, MaxIterations)

                ' Console.WriteLine(Gvalue.ToString())

                '4: Calculation of accelaration in gravitational field. eq.7-10,21 :
                Gfield(iteration, M, Ms, Ds, E, accelerations, Gvalue)

                '5: Agent movement. eq.11-12
                Move(X, accelerations, V)

                'Show_X(V, "V := ")
                'Show_X(X, "X := ")

                '--------------Event---------------------------------------------------------
                For t = 0 To (Lbest.Count - 1)
                    eArg.CurrentSate(t) = Lbest(t)
                Next
                eArg.ProgressPercentage = iteration
                RaiseEvent ProgressChanged(Me, eArg)
                '-----------------------------------------------------------------------------
                '---------------------------------------------------------
            Next
            BestLine = Lbest
        End Sub

        Private Sub Initialize_X()

            ReDim X(N, D)
            ''----------------------Temporary-----------------
            'X(0, 0) = -93.9022
            'X(0, 1) = -80.1689
            'X(0, 2) = 62.264
            'X(0, 3) = -81.5386

            'X(1, 0) = 17.7301
            'X(1, 1) = -30.4961
            'X(1, 2) = -13.6806
            'X(1, 3) = 1.7411

            'X(2, 0) = -58.1888
            'X(2, 1) = 37.1762
            'X(2, 2) = -53.1688
            'X(2, 3) = 50.3397
            '----------------------Temporary-----------------

            Try
                'Initialization :

                If IsNothing(Fitness) Then
                    Dim fitnessArray(N) As Double
                    Me.Fitness = fitnessArray
                End If

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
            'Show_X(X, "X starting ......")
            'Stop
        End Sub

        Public Sub Space_Bound()
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

            'For i As Integer = 0 To Me.N

            '    For j As Integer = 0 To Me.D
            '        If Me.X(i, j) > Up Then
            '            Tp(j) = 1I
            '            'Debug.Print(String.Format("{0}, Iter = {1}", Me.X(i, j).ToString(), CurrentIteration))
            '            'write = True
            '            'Show_X(X, "X , > UP : Before.....>")

            '        Else
            '            Tp(j) = 0I
            '        End If

            '        If Me.X(i, j) < Me.Down Then
            '            Tm(j) = 1I

            '            'write = True
            '            'Debug.Print(String.Format("{0}, Iter = {1}", Me.X(i, j).ToString(), CurrentIteration))
            '            'Show_X(X, "X , < Down : Before.....>")
            '        Else
            '            Tm(j) = 0I
            '        End If

            '        value = Tp(j) + Tm(j)

            '        If value = 0 Then
            '            TpTildeTm(j) = 1I
            '        Else
            '            TpTildeTm(j) = 0I
            '        End If
            '    Next

            '    '------------------------------------
            '    For j As Integer = 0 To Me.D
            '        TmpArray(j) = Me.X(i, j) * TpTildeTm(j)
            '    Next
            '    '-----------------------------------
            '    For t = 0 To Me.D
            '        randiDimm(t) = (Rand.NextDouble() * (Me.Up - Me.Down) + Me.Down) * (Tp(t) + Tm(t))

            '    Next

            '    For t = 0 To Me.D
            '        Me.X(i, t) = TmpArray(t) + randiDimm(t)
            '    Next

            '    'If write Then
            '    '    Show_X(X, "X : After.....>")
            '    'End If
            'Next
            '----------------------------------------------------------------

            For i As Integer = 0 To Me.N

                For j As Integer = 0 To Me.D
                    If Me.X(i, j) > Me.Intervalles.Item(j).Max_Value Then
                        Tp(j) = 1I
                        'Debug.Print(String.Format("{0}, Iter = {1}", Me.X(i, j).ToString(), CurrentIteration))
                        'write = True
                        'Show_X(X, "X , > UP : Before.....>")

                    Else
                        Tp(j) = 0I
                    End If

                    If Me.X(i, j) < Me.Intervalles.Item(j).Min_Value Then
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
                    TmpArray(j) = Me.X(i, j) * TpTildeTm(j)
                Next
                '-----------------------------------
                For t = 0 To Me.D
                    randiDimm(t) = (Rand.NextDouble() * (Me.Intervalles.Item(t).Max_Value - Me.Intervalles.Item(t).Min_Value) + Me.Intervalles.Item(t).Min_Value) * (Tp(t) + Tm(t))

                Next

                For t = 0 To Me.D
                    Me.X(i, t) = TmpArray(t) + randiDimm(t)
                Next

                'If write Then
                '    Show_X(X, "X : After.....>")
                '    Stop
                'End If
            Next

        End Sub


        '<Obsolete("Old version of function")> Private Function EvaluateF() As Double()
        '    Dim fitness() As Double = Nothing
        '    Try
        '        Dim fIndex As Integer = 6I

        '        fitness = Test_Function(fIndex)

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        '    Return fitness
        'End Function

        Private Sub EvaluateFitness(ByRef fitnessArray() As Double)
            Try

                RaiseEvent ObjectiveFunction(Me)

                'Dim fIndex As Integer = 6I
                'Fitness = Test_Function(fIndex)

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' The objectif Funcntion details. 
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        Private Function Test_Function(Optional index As Integer = 0) As Double()

            'Dim fitness(N) As Double

            Try
                Select Case index
                    Case 0
                        'Sum (x^2), [-min, max] :
                        Dim sum As Double = 0R
                        For i As Integer = 0 To Me.N
                            sum = 0.0R
                            For j As Int32 = 0 To Me.D
                                sum += Math.Pow(X(i, j), 2)
                            Next
                            Fitness(i) = sum
                        Next
                    '-----------------------------------------------------------------------
                    Case 1
                        ' max(|xi|, 1<= i <=n, [min, max]:
                        Dim maxAbs As Double

                        For i As Integer = 0 To N

                            maxAbs = Double.MinValue

                            For j As Int32 = 0 To Me.D
                                If maxAbs < Math.Abs(X(i, j)) Then
                                    maxAbs = Math.Abs(X(i, j))
                                End If
                            Next
                            Fitness(i) = maxAbs
                        Next
                    '--------------------------------------------------------------------------
                    Case 2
                        ' min(|xi|+ xi , 1<= i <=n, [min, max]:
                        Dim minAbs As Double
                        Dim tmpValue As Double

                        For i As Integer = 0 To N
                            minAbs = Double.MaxValue

                            For j As Int32 = 0 To Me.D

                                'The function :
                                tmpValue = Math.Abs(X(i, j)) + 2 * X(i, j) + 8

                                If minAbs > tmpValue Then
                                    minAbs = tmpValue
                                End If
                            Next
                            Fitness(i) = minAbs
                        Next
                      '--------------------------------------------------------------------------
                    Case 3
                        'Min(s= x+y+z+t), [-min, max] :
                        Dim sum As Double = 0R
                        For i As Integer = 0 To Me.N
                            sum = 0.0R
                            For j As Int32 = 0 To Me.D
                                sum += X(i, j)
                            Next
                            Fitness(i) = sum
                        Next

                    Case 4
                        'Min(s= x+y+z+t), [-min, max] :
                        Dim dValue As Double = 20.0R

                        Dim sum As Double = 0R
                        For i As Integer = 0 To Me.N
                            sum = 0.0R
                            For j As Int32 = 0 To Me.D
                                sum += Math.Abs((X(i, j) - dValue))
                            Next
                            Fitness(i) = sum
                        Next

                    '----------Reservoir model---------------------------------------:
                    Case 5

                        RaiseEvent ObjectiveFunction(Me)
                    '-----------------------------------------------------------------
                    Case 6

                        'fitness = GSAOptimizer.Objective_Function(X, N, D)
                        RaiseEvent ObjectiveFunction(Me)
                End Select

            Catch ex As Exception
                Throw ex
            End Try

            Return Fitness
        End Function

#Region "Events"
        'Public Event Objective_Function(ByRef resultFitness() As Double, ByRef X(,) As Double, N As Integer, D As Integer)

        Public Event ObjectiveFunction(ByRef GsaAlgo As GSAOptimizer)
        Public Event ProgressChanged(sender As Object, e As AsyncOptimEventArgs)

#End Region

        Private Sub GetBestLine(ByRef Xx As Double(,), lbest() As Double, ByVal best_x As Integer)
            Try
                For i As Integer = 0 To Me.D
                    lbest(i) = Xx(best_x, i)
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Function Get_MeanValue(ByRef fitness As Double()) As Double

            Dim meanValue As Double = Double.NaN
            Dim dimI As Integer = fitness.GetLength(0)
            Dim sum As Double = fitness.Sum
            meanValue = (sum / dimI)
            Return meanValue

        End Function

        Private Function Get_WorstValue(ByRef fitness As Double()) As Double

            Dim worstValue As Double = Double.NaN

            If Me.OptimizationType = OptimizationTypeEnum.Minimization Then
                worstValue = Double.MinValue
                For i As Integer = 0 To (fitness.GetLength(0) - 1)
                    If worstValue < fitness(i) Then
                        worstValue = fitness(i)
                    End If
                Next
            Else
                worstValue = Double.MaxValue
                For i As Integer = 0 To (fitness.GetLength(0) - 1)
                    If worstValue > fitness(i) Then
                        worstValue = fitness(i)
                    End If
                Next
            End If

            Return worstValue

        End Function

        Private Sub Mass_Calculation(ByRef massM() As Double, ByRef fitnes() As Double)
            If IsNothing(massM) Then Return
            If IsNothing(fitnes) Then Return

            Dim fmax As Double = fitnes.Max
            Dim fmin As Double = fitnes.Min

            If fmin = fmax Then
                For i As Int32 = 0 To Me.N
                    massM(i) = 1.0R
                Next

            Else
                Dim best, worst As Double

                If OptimizationType = OptimizationTypeEnum.Minimization Then
                    best = fmin
                    worst = fmax
                Else
                    best = fmax
                    worst = fmin
                End If

                Dim denominator As Double = (best - worst)

                For i As Integer = 0 To Me.N
                    massM(i) = (fitnes(i) - worst) / denominator
                Next

                Dim sumMi As Double = massM.Sum

                For i As Integer = 0 To Me.N
                    massM(i) = massM(i) / sumMi
                Next

            End If

        End Sub

        Private Function Gconstant(ByVal iteration As Integer, ByVal max_it As Integer) As Double
            Dim gValue As Double = 0R
            Dim expose As Double = (-1 * Me.Alpha * iteration) / max_it
            gValue = G0 * Math.Exp(expose)
            Return gValue
        End Function

        Private Sub Gfield(ByVal iteration As Integer, ByRef M() As Double, ByRef Ms() As Double, ByRef Ds() As Integer, ByRef E(,) As Double, ByRef accelerations(,) As Double, ByRef Gval As Double)

            Dim final_per = 2
            Dim kbestDbl As Double
            Dim kbest As Integer

            'total force calculation :

            If Me.ElitistCheck = ElitistCheckEnum.Equation9 Then

                kbest = N

            ElseIf Me.ElitistCheck = ElitistCheckEnum.Equation21 Then

                kbestDbl = final_per + ((1 - (iteration / MaxIterations)) * (100 - final_per))
                kbestDbl = (N * kbestDbl) / 100
                kbest = Convert.ToInt32(Math.Round(kbestDbl))
            End If

            'Descend
            Sort(M, Ms, Ds)
            '----------------------------------------------------------
            Dim j As Integer = 0I
            Dim R As Double = 0R

            For i As Integer = 0 To N
                'Initialisation :
                For t As Integer = 0 To D
                    E(i, t) = 0R
                Next

                For ii As Integer = 0 To (kbest - 1)
                    j = Ds(ii)

                    If i <> j Then
                        R = Norm(X, i, j)
                        R = (R ^ Rpower) + Eps

                        For k = 0 To Me.D
                            ' E(i, k) = E(i, k) + (0.5 * (M(j) * ((X(j, k) - X(i, k)) / R)))
                            E(i, k) = E(i, k) + (Rand.NextDouble() * (M(j) * ((X(j, k) - X(i, k)) / R)))
                        Next

                    End If
                Next
            Next
            'Acceleration
            'a = E.* G; %note that Mp(i)/Mi(i)=1
            For s As Integer = 0 To N
                For t As Integer = 0 To D
                    accelerations(s, t) = Gval * E(s, t)
                Next
            Next

            'Show_X(E, "E := ")
            'Show_X(accelerations, "Accelerations := ")

        End Sub

        Private Sub Sort(ByRef M() As Double, ByRef Ms() As Double, ByRef Ds() As Integer)

            If IsNothing(M) Then Return
            If IsNothing(Ms) Then Return
            If IsNothing(Ds) Then Return

            Dim tmpM(Me.N) As Double

            For i As Integer = 0 To Me.N
                Ds(i) = i
                tmpM(i) = M(i)
            Next

            Dim minValue As Double = (tmpM.Min() - 10)
            Dim maxValue As Double = (tmpM.Max)

            For i As Integer = 0 To Me.N

                For j = 0 To Me.N

                    maxValue = tmpM.Max
                    If tmpM(j) = maxValue Then
                        Ms(i) = maxValue
                        Ds(i) = j
                        tmpM(j) = minValue
                        Exit For
                    End If
                Next
            Next

        End Sub

        Function Norm(ByRef Xij As Double(,), ByRef iIndex As Integer, ByRef jIndex As Integer, Optional norme As Integer = 2) As Double
            Dim result As Double = 0R
            If IsNothing(Xij) Then Return Nothing
            Try
                Dim summ As Double = 0R
                Dim jCount As Integer = (Xij.GetLength(1) - 1)
                Dim tmpValue As Double = 0R

                For j As Integer = 0 To jCount

                    tmpValue = (Xij(iIndex, j) - Xij(jIndex, j))
                    summ += tmpValue ^ norme
                Next

                result = Math.Sqrt(summ)

            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Private Sub Move(ByRef Xx(,) As Double, ByRef accelerations(,) As Double, ByRef V(,) As Double)

            For i As Integer = 0 To N
                For j As Integer = 0 To D
                    V(i, j) = ((Rand.NextDouble() * V(i, j))) + accelerations(i, j)
                    'V(i, j) = (0.5 * V(i, j)) + accelerations(i, j)
                Next
            Next
            For r As Integer = 0 To Me.N
                For s As Integer = 0 To Me.D
                    Xx(r, s) = Xx(r, s) + V(r, s)
                Next
            Next

        End Sub

    End Class
End Namespace


