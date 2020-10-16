Option Strict On
Imports System.ComponentModel

Namespace GreyWolfOptimizer
    Public Class GWOptimizer0
        Implements IEvolutionaryAlgorithm

#Region "Properties"
        Private Shared Rndm As New Random(0)

        Private dimension_D As Integer = 12
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

        Dim minPosition As Double = 0
        Dim maxPosition As Double = 10

        Public Property Intervalles As List(Of Intervalle) Implements IEvolutionaryAlgorithm.Intervalles

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

        Public Property GWOVersion As GWOVersionEnum = GWOVersionEnum.StandardGWO

#Region "Optimization_Parameters"
        ''' <summary>
        ''' u parameter.
        ''' </summary>
        ''' <returns></returns>
        Public Property IGWO_uParameter As Double = 1.1

        Private Iterations As Integer = 1

        Public Property MaxIterations As Integer Implements IEvolutionaryAlgorithm.MaxIterations
            Get
                Return Iterations
            End Get
            Set(value As Integer)
                Iterations = Math.Max(value, 0)
            End Set
        End Property

        Dim mOptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Maximization
        Private Property OptimizationType As OptimizationTypeEnum Implements IEvolutionaryAlgorithm.OptimizationType
            Get
                Return mOptimizationType
            End Get
            Set(value As OptimizationTypeEnum)
                mOptimizationType = value
            End Set
        End Property

        Dim Best_Chart As List(Of Double)
        Private ReadOnly Property BestChart As List(Of Double) Implements IEvolutionaryAlgorithm.BestChart
            Get
                Return Best_Chart
            End Get
        End Property

        Dim Worst_Chart As List(Of Double)
        Private ReadOnly Property WorstChart As List(Of Double) Implements IEvolutionaryAlgorithm.WorstChart
            Get
                Return Worst_Chart
            End Get
        End Property

        Dim Mean_Chart As List(Of Double)
        Private ReadOnly Property IEvolutionaryAlgorithm_MeanChart As List(Of Double) Implements IEvolutionaryAlgorithm.MeanChart
            Get
                Return Mean_Chart
            End Get
        End Property

        Dim SolutionFitness As Dictionary(Of String, Double)
        Public ReadOnly Property Solution_Fitness As Dictionary(Of String, Double) Implements IEvolutionaryAlgorithm.Solution_Fitness
            Get
                Return SolutionFitness
            End Get
        End Property

#End Region
#End Region

#Region "Subs & Functions"

        Public Sub LuanchComputation() Implements IEvolutionaryAlgorithm.LuanchComputation

            Best_Chart = New List(Of Double)
            Worst_Chart = New List(Of Double)
            Mean_Chart = New List(Of Double)

            Chronos = New Stopwatch()
            Chronos.Start()
            Select Case mOptimizationType
                Case OptimizationTypeEnum.Maximization
                    BestPositions = GWO_Maximization(dimension_D, Iterations, WolfCount_N)
                Case Else
                    BestPositions = GWO_Minimization(dimension_D, Iterations, WolfCount_N)
            End Select

            Chronos.Stop()
        End Sub

        Private Function GWO_Maximization(ByVal dimensionD As Integer, ByVal iterationsMax As Integer, ByVal wolfCountN As Integer) As Double()

            'PosisiTerbaik : La meilleure position
            Dim bestPositions(dimensionD - 1) As Double

            'nilaiFungsiTerbaik : la valeur de la fonction est la meilleure
            Dim bestObjectiveFunct As Double = Double.MinValue

            'daftarPosisi : Liste des positions
            Dim positionsList(wolfCountN - 1)() As Double

            'nilaiFungsi : la valeur de la fonction
            Dim objectiveFunctValues(wolfCountN - 1) As Double

            '*L'initialisation du loup gris qui a utilisé autant que le nombre de paramètres du Loup
            'Console.WriteLine("l'initialisation des Loup gris sur de la position aléatoire")

            'indeksPosisiTerbaik : le meilleur indice de position
            Dim bestPositionIndex As Integer = -1

            '1. faire des bouclages autant que le nombre de loup (points 1a - 1b).
            For i As Integer = 0 To (wolfCountN - 1)
                'daftarPosisi : Liste des positions
                positionsList(i) = New Double(dimensionD - 1) {}

                '1 a. donner des positions aléatoires sur chacun des loups gris,
                ' autant que le nombre de dimensions
                'Calculer ensuite la valeur de la fonction à cette position
                'Description plus de détails sur cette fonction peut être vu
                ' dans l'explication du script ci-dessous.

                For j As Integer = 0 To (dimensionD - 1)

                    positionsList(i)(j) = (Intervalles(j).Max_Value - Intervalles(j).Min_Value) * Rndm.NextDouble() + Intervalles(j).Min_Value
                Next j

                objectiveFunctValues(i) = ObjectiveFunction(positionsList(i))

                REM------------------------------------------------------------------------------------------
                'Console.Write("Grey Wolf " & (i + 1).ToString.PadRight(2) & ", ")
                'Console.Write("Position de la : [")

                'For j As Integer = 0 To positionsList(i).Length - 1
                '    Console.Write(positionsList(i)(j).ToString("F4").PadLeft(7) & " ")
                'Next j

                'Console.Write("], ")
                'Console.WriteLine("la valeur de la fonction = " & objectiveFunctValues(i).ToString("F2"))
                REM------------------------------------------------------------------------------------------

                '1 b. Si la valeur d'une position aléatoire est meilleure que la meilleure,
                ' la valeur de fonction 
                'alors, prenez cette position comme la meilleure position tout en
                If objectiveFunctValues(i) > bestObjectiveFunct Then
                    bestObjectiveFunct = objectiveFunctValues(i)
                    Array.Copy(positionsList(i), bestPositions, dimensionD)
                    bestPositionIndex = i
                End If
            Next i

            REM------------------------------------------------------------------------------------------
            'Console.WriteLine("")
            'Console.WriteLine("La meilleure position")
            'Console.WriteLine("Grey Wolf " & bestPositionIndex & " la valeur de la fonction = " & bestObjectiveFunct.ToString("F2"))
            'Console.WriteLine("")
            REM------------------------------------------------------------------------------------------

            '* Effectuer le processus de recherche la meilleure position
            'Console.WriteLine("Démarrez le processus de recherche la meilleure position")

            Dim Positions_Alpha(dimensionD - 1) As Double
            Dim value_Alpha As Double = Double.MinValue 'la valeur de loup Alpha.

            Dim Positions_Beta(dimensionD - 1) As Double
            Dim value_Beta As Double = Double.MinValue 'la valeur de loup Beta.

            Dim Positions_Delta(dimensionD - 1) As Double
            Dim value_Delta As Double = Double.MinValue 'la valeur de loup Delta.

            '2. le processus de calcul autant que le nombre d'itérations (point 2a - 2c)»
            Dim iteration As Integer = 0

            '---------------------------------- Variables -------------------------------
            Dim newObjectiveFunctValue As Double = 0R
            Dim tmpa As Double = 0R
            Dim a As Double = 0R
            Dim r1 As Double = 0R
            Dim r2 As Double = 0R

            Dim A_Alpha As Double = 0
            Dim C_Alpha As Double = 0
            Dim D_Alpha As Double = 0
            Dim X_Alpha As Double = 0

            Dim A_Beta As Double = 0
            Dim C_Beta As Double = 0
            Dim D_Beta As Double = 0
            Dim X_Beta As Double = 0

            Dim A_Delta As Double = 0
            Dim C_Delta As Double = 0
            Dim D_Delta As Double = 0
            Dim X_Delta As Double = 0
            '----------------------------------------------------------------------------

            Do While iteration < iterationsMax
                iteration += 1

                '2a. a fait le calcul sur chaque loup gris (points 2a1 - 2a6))»
                For i As Integer = 0 To (positionsList.Length - 1)

                    '2a1. Faire le calcul sur les positions respectives du loup gris
                    'Si une position sur le calcul précédent s'est avérée être en dehors
                    ' des limites de la position qui sont autorisés,
                    ' puis la valeur de retour afin de s'adapter à la limite
                    For j As Integer = 0 To positionsList(i).Length - 1
                        If positionsList(i)(j) < Intervalles(j).Min_Value Then

                            positionsList(i)(j) = Intervalles(j).Min_Value

                        ElseIf positionsList(i)(j) > Intervalles(j).Max_Value Then

                            positionsList(i)(j) = Intervalles(j).Max_Value

                        End If
                    Next j

                    '2a2. Calculer la valeur de la fonction à cette position
                    'nilaiFungsiBaru : la valeur des nouvelles fonctions
                    'Dim newObjectiveFunctValue As Double = ObjectiveFunction(positionsList(i))

                    newObjectiveFunctValue = ObjectiveFunction(positionsList(i))

                    '2a3. Si la valeur de la nouvelle fonction est meilleure que la valeur alpha,
                    ' alors prenez la position comme position alpha de la meilleure

                    If newObjectiveFunctValue > value_Alpha Then

                        value_Alpha = newObjectiveFunctValue

                        Positions_Alpha = positionsList(i)

                    End If

                    '2a4. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha,
                    ' mais il est mieux que la valeur bêta, puis prendre cette position que la position 
                    ' de la meilleure Beta.
                    If newObjectiveFunctValue < value_Alpha AndAlso newObjectiveFunctValue > value_Beta Then

                        value_Beta = newObjectiveFunctValue

                        Positions_Beta = positionsList(i)

                    End If

                    '2a5. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha et bêta, 
                    ' mais mieux que la valeur Delta, puis prendre cette position comme la meilleure position 
                    ' Delta.
                    If newObjectiveFunctValue < value_Alpha AndAlso newObjectiveFunctValue < value_Beta AndAlso newObjectiveFunctValue > value_Delta Then

                        value_Delta = newObjectiveFunctValue

                        Positions_Delta = positionsList(i)

                    End If

                    'Si la valeur alpha alors qu'il s'avère mieux que les valeurs de fonction en général,
                    ' puis prendre la position alpha comme la meilleure position
                    If value_Alpha > bestObjectiveFunct Then

                        Array.Copy(Positions_Alpha, bestPositions, dimensionD)

                        bestObjectiveFunct = value_Alpha

                        'Console.Write("Iteraion  = " & iteration.ToString.PadRight(2) & ", ")
                        'Console.Write("Grey Wolf = " & (i + 1).ToString.PadRight(2) & ", ")
                        'Console.Write("La meilleure position : [")

                        'For j As Integer = 0 To bestPositions.Length - 1
                        '    Console.Write(bestPositions(j).ToString("F4").PadLeft(7) & " ")
                        'Next j

                        'Console.Write("], ")
                        'Console.WriteLine("La valeur de la fonction = " & value_Alpha.ToString("F6"))

                    End If

                Next i

                '2b. Spécifiez la valeur d'un
                'Un a aura des valeurs initiales 2 et diminuera graduellement vers le 0 autant 
                ' de fois que le nombre d'itérations

                If GWOVersion = GWOVersionEnum.StandardGWO Then

                    a = 2 * (1 - (iteration / iterationsMax)) '2 - (iteration * (2 / iterationsMax))

                ElseIf GWOVersion = GWOVersionEnum.mGWO Then
                    tmpa = Math.Pow(iteration, 2) / Math.Pow(iterationsMax, 2)
                    a = 2 * (1 - tmpa)

                ElseIf GWOVersion = GWOVersionEnum.IGWO Then

                    tmpa = (iteration / iterationsMax) * IGWO_uParameter
                    tmpa = (1 - tmpa)
                    a = (1 - (iteration / iterationsMax)) / tmpa

                End If

                '2c. Faire le calcul à chaque position du loup gris qui existe (poin 2c1 - 2c4)
                For i As Integer = 0 To (positionsList.Length - 1)
                    For j As Integer = 0 To (positionsList(i).Length - 1)

                        '2c1. Faire le calcul pour calculer la valeur de la X_Alpha (poin 2c1a - 2c1e)

                        '2c1a. Spécifiez une valeur aléatoire de 2 à utiliser dans le calcul de
                        'Dim r1 As Double = rnd.NextDouble
                        'Dim r2 As Double = rnd.NextDouble

                        r1 = Rndm.NextDouble()
                        r2 = Rndm.NextDouble()

                        '2c1b. Calculer la valeur d'un alpha avec la formule : A1=2*a*r1-a
                        'Dim A_Alpha As Double = 2 * a * r1 - a

                        A_Alpha = (2 * a * r1) - a

                        '2c1c. Calculer la valeur de l'alpha C avec la formule : C1=2*r2
                        'Dim C_Alpha As Double = 2 * r2
                        C_Alpha = 2 * r2

                        '2c1d. Calculer la valeur de D, alpha avec la formule : D_alpha=abs(C1*posisiAlpha(j)-daftarPosisi(i,j))
                        'Dim D_Alpha As Double = Math.Abs(C_Alpha * Positions_Alpha(j) - positionsList(i)(j))
                        D_Alpha = Math.Abs(C_Alpha * Positions_Alpha(j) - positionsList(i)(j))

                        '2c1e. Calculer la valeur de X alpha avec la formule : X1=posisiAlpha(j)-A1*D_alpha;
                        'Dim X_Alpha As Double = Positions_Alpha(j) - A_Alpha * D_Alpha
                        X_Alpha = Positions_Alpha(j) - (A_Alpha * D_Alpha)

                        '2c2. Faire le même calcul (2c1 points) pour calculer la valeur de X Beta
                        r1 = Rndm.NextDouble()
                        r2 = Rndm.NextDouble()

                        A_Beta = 2 * a * r1 - a
                        C_Beta = 2 * r2
                        D_Beta = Math.Abs(((C_Beta * Positions_Beta(j)) - positionsList(i)(j)))
                        X_Beta = Positions_Beta(j) - (A_Beta * D_Beta)

                        '2c3. Faire le même calcul (point 2c1) pour calculer la valeur de Delta X
                        r1 = Rndm.NextDouble()
                        r2 = Rndm.NextDouble()

                        A_Delta = (2 * a * r1) - a
                        C_Delta = (2 * r2)
                        D_Delta = Math.Abs(C_Delta * Positions_Delta(j) - positionsList(i)(j))
                        X_Delta = Positions_Delta(j) - (A_Delta * D_Delta)

                        '2c4. Calculez la nouvelle valeur de position avec la formule : daftarPosisi(i,j)=(X1+X2+X3)/3
                        positionsList(i)(j) = (X_Alpha + X_Beta + X_Delta) / 3
                        '
                    Next j
                Next i
                '-----------------Best Chart : Best fitness evolution----------------
                Me.BestChart.Add(value_Alpha)


            Loop

            Return bestPositions

        End Function

        Private Function GWO_Minimization(ByVal dimensionD As Integer, ByVal iterationsMax As Integer, ByVal wolfCountN As Integer) As Double()
            Try

                'PosisiTerbaik : La meilleure position
                Dim bestPositions(dimensionD - 1) As Double

                'nilaiFungsiTerbaik : la valeur de la fonction est la meilleure
                Dim bestObjectiveFunct As Double = Double.MaxValue

                'daftarPosisi : Liste des positions
                Dim positionsList(wolfCountN - 1)() As Double

                'nilaiFungsi : la valeur de la fonction
                Dim objectiveFunctValues(wolfCountN - 1) As Double

                '*L'initialisation du loup gris qui a utilisé autant que le nombre de paramètres du Loup
                'Console.WriteLine("l'initialisation des Loup gris sur de la position aléatoire")

                'indeksPosisiTerbaik : le meilleur indice de position
                Dim bestPositionIndex As Integer = -1

                '1. faire des bouclages autant que le nombre de loup (points 1a - 1b).
                For i As Integer = 0 To (wolfCountN - 1)
                    'daftarPosisi : Liste des positions
                    positionsList(i) = New Double(dimensionD - 1) {}

                    '1 a. donner des positions aléatoires sur chacun des loups gris,
                    ' autant que le nombre de dimensions
                    'Calculer ensuite la valeur de la fonction à cette position
                    'Description plus de détails sur cette fonction peut être vu
                    ' dans l'explication du script ci-dessous.

                    For j As Integer = 0 To (dimensionD - 1)
                        positionsList(i)(j) = (Intervalles(j).Max_Value - Intervalles(j).Min_Value) * Rndm.NextDouble() + Intervalles(j).Min_Value
                    Next j

                    objectiveFunctValues(i) = ObjectiveFunction(positionsList(i))

                    '-------------------------------------------------------------------------------------

                    '1 b. Si la valeur d'une position aléatoire est meilleure que la meilleure,
                    ' la valeur de fonction 
                    'alors, prenez cette position comme la meilleure position tout en
                    If objectiveFunctValues(i) < bestObjectiveFunct Then
                        bestObjectiveFunct = objectiveFunctValues(i)
                        Array.Copy(positionsList(i), bestPositions, dimensionD)
                        bestPositionIndex = i
                    End If
                Next i

                REM------------------------------------------------------------------------------------------

                '* Effectuer le processus de recherche la meilleure position
                'Console.WriteLine("Démarrez le processus de recherche la meilleure position")

                Dim Positions_Alpha(dimensionD - 1) As Double
                Dim value_Alpha As Double = Double.MaxValue 'la valeur de loup Alpha.

                Dim Positions_Beta(dimensionD - 1) As Double
                Dim value_Beta As Double = Double.MaxValue 'la valeur de loup Beta.

                Dim Positions_Delta(dimensionD - 1) As Double
                Dim value_Delta As Double = Double.MaxValue 'la valeur de loup Delta.

                '2. le processus de calcul autant que le nombre d'itérations (point 2a - 2c)»
                Dim iteration As Integer = 0

                '---------------------------------- Variables -------------------------------
                Dim newObjectiveFunctValue As Double = 0R
                Dim tmpa As Double = 0R
                Dim a As Double = 0R
                Dim r1 As Double = 0R
                Dim r2 As Double = 0R

                Dim A_Alpha As Double = 0
                Dim C_Alpha As Double = 0
                Dim D_Alpha As Double = 0
                Dim X_Alpha As Double = 0

                Dim A_Beta As Double = 0
                Dim C_Beta As Double = 0
                Dim D_Beta As Double = 0
                Dim X_Beta As Double = 0

                Dim A_Delta As Double = 0
                Dim C_Delta As Double = 0
                Dim D_Delta As Double = 0
                Dim X_Delta As Double = 0
                '----------------------------------------------------------------------------
                Dim worstFitness As Double = 0R
                Dim meanFitness As Double = 0R
                '----------------------------------------------------------------------------

                Do While iteration < iterationsMax
                    iteration += 1

                    '---------------------------------
                    worstFitness = Double.MinValue
                    meanFitness = 0R
                    '---------------------------------

                    '2a. a fait le calcul sur chaque loup gris (points 2a1 - 2a6))»
                    For i As Integer = 0 To (positionsList.Length - 1)

                        '2a1. Faire le calcul sur les positions respectives du loup gris
                        'Si une position sur le calcul précédent s'est avérée être en dehors
                        ' des limites de la position qui sont autorisés,
                        ' puis la valeur de retour afin de s'adapter à la limite
                        For j As Integer = 0 To positionsList(i).Length - 1
                            If positionsList(i)(j) < Intervalles(j).Min_Value Then
                                'positionsList(i)(j) = (Intervalles(j).Max_Value - Intervalles(j).Min_Value) * Rndm.NextDouble() + Intervalles(j).Min_Value
                                positionsList(i)(j) = Intervalles(j).Min_Value

                            ElseIf positionsList(i)(j) > Intervalles(j).Max_Value Then
                                'positionsList(i)(j) = (Intervalles(j).Max_Value - Intervalles(j).Min_Value) * Rndm.NextDouble() + Intervalles(j).Min_Value
                                positionsList(i)(j) = Intervalles(j).Max_Value

                            End If
                        Next j

                        '2a2. Calculer la valeur de la fonction à cette position
                        'nilaiFungsiBaru : la valeur des nouvelles fonctions
                        'Dim newObjectiveFunctValue As Double = ObjectiveFunction(positionsList(i))

                        newObjectiveFunctValue = ObjectiveFunction(positionsList(i))
                        'Debug.Print("It={0}, W={1}, Fit = {2} ", iteration, i, newObjectiveFunctValue.ToString())

                        '2a3. Si la valeur de la nouvelle fonction est meilleure que la valeur alpha,
                        ' alors prenez la position comme position alpha de la meilleure

                        If newObjectiveFunctValue < value_Alpha Then

                            value_Alpha = newObjectiveFunctValue

                            Positions_Alpha = positionsList(i)

                        End If

                        '2a4. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha,
                        ' mais il est mieux que la valeur bêta, puis prendre cette position que la position 
                        ' de la meilleure Beta.
                        If newObjectiveFunctValue > value_Alpha AndAlso newObjectiveFunctValue < value_Beta Then

                            value_Beta = newObjectiveFunctValue

                            Positions_Beta = positionsList(i)

                        End If

                        '2a5. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha et bêta, 
                        ' mais mieux que la valeur Delta, puis prendre cette position comme la meilleure position 
                        ' Delta.
                        If newObjectiveFunctValue > value_Alpha AndAlso newObjectiveFunctValue > value_Beta AndAlso newObjectiveFunctValue < value_Delta Then

                            value_Delta = newObjectiveFunctValue

                            Positions_Delta = positionsList(i)

                        End If

                        'Si la valeur alpha alors qu'il s'avère mieux que les valeurs de fonction en général,
                        ' puis prendre la position alpha comme la meilleure position
                        If value_Alpha < bestObjectiveFunct Then

                            Array.Copy(Positions_Alpha, bestPositions, dimensionD)

                            bestObjectiveFunct = value_Alpha

                        End If

                        '-------------Me-----------
                        If worstFitness < newObjectiveFunctValue Then
                            worstFitness = newObjectiveFunctValue
                        End If

                        meanFitness += newObjectiveFunctValue
                        '--------------------------


                    Next i

                    '-----------------------------
                    'Debug.Print()
                    '-----------------------------

                    '2b. Spécifiez la valeur d'un
                    'Un a aura des valeurs initiales 2 et diminuera graduellement vers le 0 autant 
                    ' de fois que le nombre d'itérations

                    If GWOVersion = GWOVersionEnum.StandardGWO Then

                        a = 2 * (1 - (iteration / iterationsMax))
                        '2 - (iteration * (2 / iterationsMax))

                    ElseIf GWOVersion = GWOVersionEnum.mGWO Then

                        tmpa = Math.Pow(iteration, 2) / Math.Pow(iterationsMax, 2)
                        a = 2 * (1 - tmpa)

                    ElseIf GWOVersion = GWOVersionEnum.IGWO Then

                        tmpa = (iteration / iterationsMax) * IGWO_uParameter
                        tmpa = (1 - tmpa)
                        a = (1 - (iteration / iterationsMax)) / tmpa

                    End If

                    '2c. Faire le calcul à chaque position du loup gris qui existe (poin 2c1 - 2c4)
                    For i As Integer = 0 To (positionsList.Length - 1)

                        For j As Integer = 0 To (positionsList(i).Length - 1)

                            '2c1. Faire le calcul pour calculer la valeur de la X_Alpha (poin 2c1a - 2c1e)

                            '2c1a. Spécifiez une valeur aléatoire de 2 à utiliser dans le calcul de

                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()

                            '2c1b. Calculer la valeur d'un alpha avec la formule : A1=2*a*r1-a
                            'Dim A_Alpha As Double = 2 * a * r1 - a

                            A_Alpha = (2 * a * r1) - a

                            '2c1c. Calculer la valeur de l'alpha C avec la formule : C1=2*r2
                            'Dim C_Alpha As Double = 2 * r2
                            C_Alpha = (2 * r2)

                            '2c1d. Calculer la valeur de D, alpha avec la formule : D_alpha=abs(C1*posisiAlpha(j)-daftarPosisi(i,j))
                            'Dim D_Alpha As Double = Math.Abs(C_Alpha * Positions_Alpha(j) - positionsList(i)(j))
                            D_Alpha = Math.Abs(((C_Alpha * Positions_Alpha(j)) - positionsList(i)(j)))

                            '2c1e. Calculer la valeur de X alpha avec la formule : X1=posisiAlpha(j)-A1*D_alpha;
                            'Dim X_Alpha As Double = Positions_Alpha(j) - A_Alpha * D_Alpha
                            X_Alpha = Positions_Alpha(j) - (A_Alpha * D_Alpha)

                            '2c2. Faire le même calcul (2c1 points) pour calculer la valeur de X Beta
                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()

                            A_Beta = (2 * a * r1) - a
                            C_Beta = (2 * r2)
                            D_Beta = Math.Abs(((C_Beta * Positions_Beta(j)) - positionsList(i)(j)))
                            X_Beta = Positions_Beta(j) - (A_Beta * D_Beta)

                            '2c3. Faire le même calcul (point 2c1) pour calculer la valeur de Delta X
                            r1 = Rndm.NextDouble()
                            r2 = Rndm.NextDouble()

                            A_Delta = (2 * a * r1) - a
                            C_Delta = (2 * r2)
                            D_Delta = Math.Abs(((C_Delta * Positions_Delta(j)) - positionsList(i)(j)))
                            X_Delta = Positions_Delta(j) - (A_Delta * D_Delta)

                            '2c4. Calculez la nouvelle valeur de position avec la formule : daftarPosisi(i,j)=(X1+X2+X3)/3

                            'positionsList(i)(j) = (X_Alpha + X_Beta + X_Delta) / 3
                            positionsList(i)(j) = ((1 * X_Alpha) + (1 * X_Beta) + (1 * X_Delta)) / 3

                        Next j
                    Next i

                    '-----------------Best Chart : Best fitness evolution----------------
                    Best_Chart.Add(value_Alpha)
                    Worst_Chart.Add(worstFitness)
                    Mean_Chart.Add((meanFitness / wolfCountN))
                Loop

                Return bestPositions

            Catch ex As Exception
                Throw ex
            End Try
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

        Public Sub RunEpoch() Implements IEvolutionaryAlgorithm.RunEpoch
            Throw New NotImplementedException()
        End Sub


#End Region

#Region "Events"
        Public Event ObjectiveFunctionComputation(ByRef positions() As Double, ByRef fitnessValue As Double)

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
            Dim message As String = "Best Solution : "
            If IsNothing(BestPositions) = False Then
                For i As Integer = 0 To (BestPositions.Count - 1)
                    message += BestPositions(i).ToString(format) & "   "
                Next
                message += String.Format("| Fitness value : {0}", ObjectiveFunction(BestPositions).ToString(format))
            End If

            Return message
        End Function
#End Region

#Region "Minimization_Maximization_OldVersion"
        Private Function GWO_Minimization_Old(ByVal dimensionD As Integer, ByVal minPosition As Double, ByVal maxPosition As Double, ByVal iterationsMax As Integer, ByVal wolfCountN As Integer) As Double()
            Dim rnd As New Random(0)

            'PosisiTerbaik : La meilleure position
            Dim bestPositions(dimensionD - 1) As Double

            'nilaiFungsiTerbaik : la valeur de la fonction est la meilleure
            Dim bestObjectiveFunct As Double = Double.MaxValue

            'daftarPosisi : Liste des positions
            Dim positionsList(wolfCountN - 1)() As Double

            'nilaiFungsi : la valeur de la fonction
            Dim objectiveFunctValues(wolfCountN - 1) As Double

            '*L'initialisation du loup gris qui a utilisé autant que le nombre de paramètres du Loup
            'Console.WriteLine("l'initialisation des Loup gris sur de la position aléatoire")

            'indeksPosisiTerbaik : le meilleur indice de position
            Dim bestPositionIndex As Integer = -1

            '1. faire des bouclages autant que le nombre de loup (points 1a - 1b).
            For i As Integer = 0 To (wolfCountN - 1)
                'daftarPosisi : Liste des positions
                positionsList(i) = New Double(dimensionD - 1) {}

                '1 a. donner des positions aléatoires sur chacun des loups gris,
                ' autant que le nombre de dimensions
                'Calculer ensuite la valeur de la fonction à cette position
                'Description plus de détails sur cette fonction peut être vu
                ' dans l'explication du script ci-dessous.

                For j As Integer = 0 To (dimensionD - 1)

                    positionsList(i)(j) = (maxPosition - minPosition) * rnd.NextDouble() + minPosition
                Next j

                objectiveFunctValues(i) = ObjectiveFunction(positionsList(i))

                '-------------------------------------------------------------------------------------

                '1 b. Si la valeur d'une position aléatoire est meilleure que la meilleure,
                ' la valeur de fonction 
                'alors, prenez cette position comme la meilleure position tout en
                If objectiveFunctValues(i) < bestObjectiveFunct Then
                    bestObjectiveFunct = objectiveFunctValues(i)
                    Array.Copy(positionsList(i), bestPositions, dimensionD)
                    bestPositionIndex = i
                End If
            Next i

            REM------------------------------------------------------------------------------------------

            '* Effectuer le processus de recherche la meilleure position
            'Console.WriteLine("Démarrez le processus de recherche la meilleure position")

            Dim Positions_Alpha(dimensionD - 1) As Double
            Dim value_Alpha As Double = Double.MaxValue 'la valeur de loup Alpha.

            Dim Positions_Beta(dimensionD - 1) As Double
            Dim value_Beta As Double = Double.MaxValue 'la valeur de loup Beta.

            Dim Positions_Delta(dimensionD - 1) As Double
            Dim value_Delta As Double = Double.MaxValue 'la valeur de loup Delta.

            '2. le processus de calcul autant que le nombre d'itérations (point 2a - 2c)»
            Dim iteration As Integer = 0

            '---------------------------------- Variables -------------------------------
            Dim newObjectiveFunctValue As Double = 0R
            Dim a As Double = 0R
            Dim r1 As Double = 0R
            Dim r2 As Double = 0R

            Dim A_Alpha As Double = 0
            Dim C_Alpha As Double = 0
            Dim D_Alpha As Double = 0
            Dim X_Alpha As Double = 0

            Dim A_Beta As Double = 0
            Dim C_Beta As Double = 0
            Dim D_Beta As Double = 0
            Dim X_Beta As Double = 0

            Dim A_Delta As Double = 0
            Dim C_Delta As Double = 0
            Dim D_Delta As Double = 0
            Dim X_Delta As Double = 0
            '----------------------------------------------------------------------------

            Do While iteration < iterationsMax
                iteration += 1

                '2a. a fait le calcul sur chaque loup gris (points 2a1 - 2a6))»
                For i As Integer = 0 To (positionsList.Length - 1)

                    '2a1. Faire le calcul sur les positions respectives du loup gris
                    'Si une position sur le calcul précédent s'est avérée être en dehors
                    ' des limites de la position qui sont autorisés,
                    ' puis la valeur de retour afin de s'adapter à la limite
                    For j As Integer = 0 To positionsList(i).Length - 1
                        If positionsList(i)(j) < minPosition Then

                            positionsList(i)(j) = minPosition

                        ElseIf positionsList(i)(j) > maxPosition Then

                            positionsList(i)(j) = maxPosition

                        End If
                    Next j

                    '2a2. Calculer la valeur de la fonction à cette position
                    'nilaiFungsiBaru : la valeur des nouvelles fonctions
                    'Dim newObjectiveFunctValue As Double = ObjectiveFunction(positionsList(i))

                    newObjectiveFunctValue = ObjectiveFunction(positionsList(i))

                    '2a3. Si la valeur de la nouvelle fonction est meilleure que la valeur alpha,
                    ' alors prenez la position comme position alpha de la meilleure

                    If newObjectiveFunctValue < value_Alpha Then

                        value_Alpha = newObjectiveFunctValue

                        Positions_Alpha = positionsList(i)

                    End If

                    '2a4. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha,
                    ' mais il est mieux que la valeur bêta, puis prendre cette position que la position 
                    ' de la meilleure Beta.
                    If newObjectiveFunctValue > value_Alpha AndAlso newObjectiveFunctValue < value_Beta Then

                        value_Beta = newObjectiveFunctValue

                        Positions_Beta = positionsList(i)

                    End If

                    '2a5. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha et bêta, 
                    ' mais mieux que la valeur Delta, puis prendre cette position comme la meilleure position 
                    ' Delta.
                    If newObjectiveFunctValue > value_Alpha AndAlso newObjectiveFunctValue > value_Beta AndAlso newObjectiveFunctValue < value_Delta Then

                        value_Delta = newObjectiveFunctValue

                        Positions_Delta = positionsList(i)

                    End If

                    'Si la valeur alpha alors qu'il s'avère mieux que les valeurs de fonction en général,
                    ' puis prendre la position alpha comme la meilleure position
                    If value_Alpha < bestObjectiveFunct Then

                        Array.Copy(Positions_Alpha, bestPositions, dimensionD)

                        bestObjectiveFunct = value_Alpha

                    End If

                Next i

                '2b. Spécifiez la valeur d'un
                'Un a aura des valeurs initiales 2 et diminuera graduellement vers le 0 autant 
                ' de fois que le nombre d'itérations

                If GWOVersion = GWOVersionEnum.StandardGWO Then

                    a = 2 * (1 - (iteration / iterationsMax)) '2 - (iteration * (2 / iterationsMax))

                ElseIf GWOVersion = GWOVersionEnum.mGWO Then

                    a = 2 * (1 - (Math.Pow(iteration, 2) / Math.Pow(iterationsMax, 2)))

                ElseIf GWOVersion = GWOVersionEnum.IGWO Then

                    a = 1 - ((iteration / iterationsMax) * IGWO_uParameter)
                    a = (1 - (iteration / iterationsMax)) / a

                End If


                'Debug.Print("a:= {0}", a)

                '2c. Faire le calcul à chaque position du loup gris qui existe (poin 2c1 - 2c4)
                For i As Integer = 0 To (positionsList.Length - 1)
                    For j As Integer = 0 To (positionsList(i).Length - 1)

                        '2c1. Faire le calcul pour calculer la valeur de la X_Alpha (poin 2c1a - 2c1e)

                        '2c1a. Spécifiez une valeur aléatoire de 2 à utiliser dans le calcul de

                        r1 = rnd.NextDouble()
                        r2 = rnd.NextDouble()

                        '2c1b. Calculer la valeur d'un alpha avec la formule : A1=2*a*r1-a
                        'Dim A_Alpha As Double = 2 * a * r1 - a

                        A_Alpha = (2 * a * r1) - a

                        '2c1c. Calculer la valeur de l'alpha C avec la formule : C1=2*r2
                        'Dim C_Alpha As Double = 2 * r2
                        C_Alpha = (2 * r2)

                        '2c1d. Calculer la valeur de D, alpha avec la formule : D_alpha=abs(C1*posisiAlpha(j)-daftarPosisi(i,j))
                        'Dim D_Alpha As Double = Math.Abs(C_Alpha * Positions_Alpha(j) - positionsList(i)(j))
                        D_Alpha = Math.Abs(((C_Alpha * Positions_Alpha(j)) - positionsList(i)(j)))

                        '2c1e. Calculer la valeur de X alpha avec la formule : X1=posisiAlpha(j)-A1*D_alpha;
                        'Dim X_Alpha As Double = Positions_Alpha(j) - A_Alpha * D_Alpha
                        X_Alpha = Positions_Alpha(j) - (A_Alpha * D_Alpha)

                        '2c2. Faire le même calcul (2c1 points) pour calculer la valeur de X Beta
                        r1 = rnd.NextDouble()
                        r2 = rnd.NextDouble()

                        A_Beta = (2 * a * r1) - a
                        C_Beta = (2 * r2)
                        D_Beta = Math.Abs(((C_Beta * Positions_Beta(j)) - positionsList(i)(j)))
                        X_Beta = Positions_Beta(j) - (A_Beta * D_Beta)

                        '2c3. Faire le même calcul (point 2c1) pour calculer la valeur de Delta X
                        r1 = rnd.NextDouble()
                        r2 = rnd.NextDouble()

                        A_Delta = (2 * a * r1) - a
                        C_Delta = (2 * r2)
                        D_Delta = Math.Abs(((C_Delta * Positions_Delta(j)) - positionsList(i)(j)))
                        X_Delta = Positions_Delta(j) - (A_Delta * D_Delta)

                        '2c4. Calculez la nouvelle valeur de position avec la formule : daftarPosisi(i,j)=(X1+X2+X3)/3
                        positionsList(i)(j) = (X_Alpha + X_Beta + X_Delta) / 3

                    Next j
                Next i

                '-----------------Best Chart : Best fitness evolution----------------
                Me.BestChart.Add(value_Alpha)

            Loop

            Return bestPositions

        End Function

        Private Function GWO_Maximization_Old(ByVal dimensionD As Integer, ByVal minPosition As Double, ByVal maxPosition As Double, ByVal iterationsMax As Integer, ByVal wolfCountN As Integer) As Double()
            Dim rnd As New Random(0)


            'PosisiTerbaik : La meilleure position
            Dim bestPositions(dimensionD - 1) As Double

            'nilaiFungsiTerbaik : la valeur de la fonction est la meilleure
            Dim bestObjectiveFunct As Double = Double.MinValue

            'daftarPosisi : Liste des positions
            Dim positionsList(wolfCountN - 1)() As Double

            'nilaiFungsi : la valeur de la fonction
            Dim objectiveFunctValues(wolfCountN - 1) As Double

            '*L'initialisation du loup gris qui a utilisé autant que le nombre de paramètres du Loup
            'Console.WriteLine("l'initialisation des Loup gris sur de la position aléatoire")

            'indeksPosisiTerbaik : le meilleur indice de position
            Dim bestPositionIndex As Integer = -1

            '1. faire des bouclages autant que le nombre de loup (points 1a - 1b).
            For i As Integer = 0 To (wolfCountN - 1)
                'daftarPosisi : Liste des positions
                positionsList(i) = New Double(dimensionD - 1) {}

                '1 a. donner des positions aléatoires sur chacun des loups gris,
                ' autant que le nombre de dimensions
                'Calculer ensuite la valeur de la fonction à cette position
                'Description plus de détails sur cette fonction peut être vu
                ' dans l'explication du script ci-dessous.

                For j As Integer = 0 To (dimensionD - 1)

                    positionsList(i)(j) = (maxPosition - minPosition) * rnd.NextDouble() + minPosition
                Next j

                objectiveFunctValues(i) = ObjectiveFunction(positionsList(i))

                REM------------------------------------------------------------------------------------------
                'Console.Write("Grey Wolf " & (i + 1).ToString.PadRight(2) & ", ")
                'Console.Write("Position de la : [")

                'For j As Integer = 0 To positionsList(i).Length - 1
                '    Console.Write(positionsList(i)(j).ToString("F4").PadLeft(7) & " ")
                'Next j

                'Console.Write("], ")
                'Console.WriteLine("la valeur de la fonction = " & objectiveFunctValues(i).ToString("F2"))
                REM------------------------------------------------------------------------------------------

                '1 b. Si la valeur d'une position aléatoire est meilleure que la meilleure,
                ' la valeur de fonction 
                'alors, prenez cette position comme la meilleure position tout en
                If objectiveFunctValues(i) > bestObjectiveFunct Then
                    bestObjectiveFunct = objectiveFunctValues(i)
                    Array.Copy(positionsList(i), bestPositions, dimensionD)
                    bestPositionIndex = i
                End If
            Next i

            REM------------------------------------------------------------------------------------------
            'Console.WriteLine("")
            'Console.WriteLine("La meilleure position")
            'Console.WriteLine("Grey Wolf " & bestPositionIndex & " la valeur de la fonction = " & bestObjectiveFunct.ToString("F2"))
            'Console.WriteLine("")
            REM------------------------------------------------------------------------------------------

            '* Effectuer le processus de recherche la meilleure position
            'Console.WriteLine("Démarrez le processus de recherche la meilleure position")

            Dim Positions_Alpha(dimensionD - 1) As Double
            Dim value_Alpha As Double = Double.MinValue 'la valeur de loup Alpha.

            Dim Positions_Beta(dimensionD - 1) As Double
            Dim value_Beta As Double = Double.MinValue 'la valeur de loup Beta.

            Dim Positions_Delta(dimensionD - 1) As Double
            Dim value_Delta As Double = Double.MinValue 'la valeur de loup Delta.

            '2. le processus de calcul autant que le nombre d'itérations (point 2a - 2c)»
            Dim iteration As Integer = 0

            '---------------------------------- Variables -------------------------------
            Dim newObjectiveFunctValue As Double = 0R
            Dim a As Double = 0R
            Dim r1 As Double = 0R
            Dim r2 As Double = 0R

            Dim A_Alpha As Double = 0
            Dim C_Alpha As Double = 0
            Dim D_Alpha As Double = 0
            Dim X_Alpha As Double = 0

            Dim A_Beta As Double = 0
            Dim C_Beta As Double = 0
            Dim D_Beta As Double = 0
            Dim X_Beta As Double = 0

            Dim A_Delta As Double = 0
            Dim C_Delta As Double = 0
            Dim D_Delta As Double = 0
            Dim X_Delta As Double = 0
            '----------------------------------------------------------------------------

            Do While iteration < iterationsMax
                iteration += 1

                '2a. a fait le calcul sur chaque loup gris (points 2a1 - 2a6))»
                For i As Integer = 0 To (positionsList.Length - 1)

                    '2a1. Faire le calcul sur les positions respectives du loup gris
                    'Si une position sur le calcul précédent s'est avérée être en dehors
                    ' des limites de la position qui sont autorisés,
                    ' puis la valeur de retour afin de s'adapter à la limite
                    For j As Integer = 0 To positionsList(i).Length - 1
                        If positionsList(i)(j) < minPosition Then

                            positionsList(i)(j) = minPosition

                        ElseIf positionsList(i)(j) > maxPosition Then

                            positionsList(i)(j) = maxPosition

                        End If
                    Next j

                    '2a2. Calculer la valeur de la fonction à cette position
                    'nilaiFungsiBaru : la valeur des nouvelles fonctions
                    'Dim newObjectiveFunctValue As Double = ObjectiveFunction(positionsList(i))

                    newObjectiveFunctValue = ObjectiveFunction(positionsList(i))

                    '2a3. Si la valeur de la nouvelle fonction est meilleure que la valeur alpha,
                    ' alors prenez la position comme position alpha de la meilleure

                    If newObjectiveFunctValue > value_Alpha Then

                        value_Alpha = newObjectiveFunctValue

                        Positions_Alpha = positionsList(i)


                    End If

                    '2a4. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha,
                    ' mais il est mieux que la valeur bêta, puis prendre cette position que la position 
                    ' de la meilleure Beta.
                    If newObjectiveFunctValue < value_Alpha AndAlso newObjectiveFunctValue > value_Beta Then

                        value_Beta = newObjectiveFunctValue

                        Positions_Beta = positionsList(i)

                    End If

                    '2a5. Si la valeur de la nouvelle fonction est inférieure à la valeur de l'alpha et bêta, 
                    ' mais mieux que la valeur Delta, puis prendre cette position comme la meilleure position 
                    ' Delta.
                    If newObjectiveFunctValue < value_Alpha AndAlso newObjectiveFunctValue < value_Beta AndAlso newObjectiveFunctValue > value_Delta Then

                        value_Delta = newObjectiveFunctValue

                        Positions_Delta = positionsList(i)

                    End If

                    'Si la valeur alpha alors qu'il s'avère mieux que les valeurs de fonction en général,
                    ' puis prendre la position alpha comme la meilleure position
                    If value_Alpha > bestObjectiveFunct Then

                        Array.Copy(Positions_Alpha, bestPositions, dimensionD)

                        bestObjectiveFunct = value_Alpha

                        'Console.Write("Iteraion  = " & iteration.ToString.PadRight(2) & ", ")
                        'Console.Write("Grey Wolf = " & (i + 1).ToString.PadRight(2) & ", ")
                        'Console.Write("La meilleure position : [")

                        'For j As Integer = 0 To bestPositions.Length - 1
                        '    Console.Write(bestPositions(j).ToString("F4").PadLeft(7) & " ")
                        'Next j

                        'Console.Write("], ")
                        'Console.WriteLine("La valeur de la fonction = " & value_Alpha.ToString("F6"))

                    End If

                Next i

                '2b. Spécifiez la valeur d'un
                'Un a aura des valeurs initiales 2 et diminuera graduellement vers le 0 autant 
                ' de fois que le nombre d'itérations

                If GWOVersion = GWOVersionEnum.StandardGWO Then

                    a = 2 * (1 - (iteration / iterationsMax))
                    '2 - (iteration * (2 / iterationsMax))

                ElseIf GWOVersion = GWOVersionEnum.mGWO Then

                    a = 2 * (1 - (Math.Pow(iteration, 2) / Math.Pow(iterationsMax, 2)))

                ElseIf GWOVersion = GWOVersionEnum.IGWO Then

                    a = 1 - ((iteration / iterationsMax) * IGWO_uParameter)
                    a = (1 - (iteration / iterationsMax)) / a

                ElseIf GWOVersion = GWOVersionEnum.AdaptiveGWO Then
                    'a = 2 * (1 - (iteration / iterationsMax))
                    a = (4 * (1 - (iteration / iterationsMax))) - (2 * (1 - (Math.Pow(iteration, 2) / Math.Pow(iterationsMax, 2))))
                End If

                '2c. Faire le calcul à chaque position du loup gris qui existe (poin 2c1 - 2c4)
                For i As Integer = 0 To (positionsList.Length - 1)
                    For j As Integer = 0 To (positionsList(i).Length - 1)

                        '2c1. Faire le calcul pour calculer la valeur de la X_Alpha (poin 2c1a - 2c1e)

                        '2c1a. Spécifiez une valeur aléatoire de 2 à utiliser dans le calcul de
                        'Dim r1 As Double = rnd.NextDouble
                        'Dim r2 As Double = rnd.NextDouble

                        r1 = rnd.NextDouble()
                        r2 = rnd.NextDouble()

                        '2c1b. Calculer la valeur d'un alpha avec la formule : A1=2*a*r1-a
                        'Dim A_Alpha As Double = 2 * a * r1 - a

                        A_Alpha = (2 * a * r1) - a

                        '2c1c. Calculer la valeur de l'alpha C avec la formule : C1=2*r2
                        'Dim C_Alpha As Double = 2 * r2
                        C_Alpha = 2 * r2

                        '2c1d. Calculer la valeur de D, alpha avec la formule : D_alpha=abs(C1*posisiAlpha(j)-daftarPosisi(i,j))
                        'Dim D_Alpha As Double = Math.Abs(C_Alpha * Positions_Alpha(j) - positionsList(i)(j))
                        D_Alpha = Math.Abs(C_Alpha * Positions_Alpha(j) - positionsList(i)(j))

                        '2c1e. Calculer la valeur de X alpha avec la formule : X1=posisiAlpha(j)-A1*D_alpha;
                        'Dim X_Alpha As Double = Positions_Alpha(j) - A_Alpha * D_Alpha
                        X_Alpha = Positions_Alpha(j) - (A_Alpha * D_Alpha)

                        '2c2. Faire le même calcul (2c1 points) pour calculer la valeur de X Beta
                        r1 = rnd.NextDouble()
                        r2 = rnd.NextDouble()

                        A_Beta = 2 * a * r1 - a
                        C_Beta = 2 * r2
                        D_Beta = Math.Abs(((C_Beta * Positions_Beta(j)) - positionsList(i)(j)))
                        X_Beta = Positions_Beta(j) - (A_Beta * D_Beta)

                        '2c3. Faire le même calcul (point 2c1) pour calculer la valeur de Delta X
                        r1 = rnd.NextDouble()
                        r2 = rnd.NextDouble()

                        A_Delta = (2 * a * r1) - a
                        C_Delta = (2 * r2)
                        D_Delta = Math.Abs(C_Delta * Positions_Delta(j) - positionsList(i)(j))
                        X_Delta = Positions_Delta(j) - (A_Delta * D_Delta)

                        '2c4. Calculez la nouvelle valeur de position avec la formule : daftarPosisi(i,j)=(X1+X2+X3)/3
                        positionsList(i)(j) = (X_Alpha + X_Beta + X_Delta) / 3

                    Next j
                Next i

                Me.BestChart.Add(value_Alpha)
            Loop

            Return bestPositions

        End Function


#End Region
    End Class

End Namespace
