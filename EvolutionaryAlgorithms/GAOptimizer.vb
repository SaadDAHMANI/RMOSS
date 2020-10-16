Option Strict On
Imports System.Threading
Imports System.ComponentModel
Imports System.Text

Namespace GeneticAlgorithm

    <Obsolete("Rest optimization for minimization")>
    Public Class GAOptimizer
        Implements IEvolutionaryAlgo

        Private kLength As Int32 = 5

        Private kInitialPopulation As Integer = 4
        Private kPopulationLimit As Integer = 4

        Private StrBouilder As New StringBuilder()

        Private kMutationFrequency As Single = 10.0F
        <Description("Probability of mutation (Default 10%)"), DefaultValue(10)>
        Public Property MutationFrequency As Single
            Get
                Return kMutationFrequency
            End Get
            Set(value As Single)
                If value >= 0 Then
                    kMutationFrequency = value
                Else
                    kMutationFrequency = 10.0F
                End If
            End Set
        End Property

        Private kDeathFitness As Single = Single.MinValue
        Private kReproductionFitness As Single = 0.00F

        Private Genomes As New List(Of Genome)
        Private GenomeReproducers As New List(Of Genome)
        Private GenomeResults As New List(Of Genome)
        Private GenomeFamily As New List(Of Genome)

        Dim CurrentPopulation As Int32 = 4
        Dim Generation As Integer = 1
        Dim Best2 As Boolean = True
        Private HasInitialized As Boolean = False


#Region "Properties"

        <Description("Genomes count.")> Public Property InitialPopulation As Integer Implements IEvolutionaryAlgo.Agents_N
            Get
                Return kInitialPopulation
            End Get
            Set(value As Integer)
                If value > 2 Then
                    kInitialPopulation = value
                Else
                    kInitialPopulation = 4
                End If
            End Set
        End Property

        <Description("Genomes count limit in iterations.")> Public Property PopulationLimit As Integer
            Get
                Return kPopulationLimit
            End Get
            Set(value As Integer)
                If value > 2 Then
                    kPopulationLimit = value
                Else
                    kPopulationLimit = kInitialPopulation
                End If
            End Set
        End Property

        <Description("The best solution (Genome with index 0).")> Public ReadOnly Property Best_Genome As Genome
            Get
                If IsNothing(Genomes) = False Then
                    If Genomes.Count > 0 Then
                        Return Genomes(0)
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property GenomesPopulation As List(Of Genome)
            Get
                Return Genomes
            End Get
        End Property

        <Description("Length of Genomes.")> Public Property GenomesLenght As Integer
            Get
                Return kLength
            End Get
            Set(value As Integer)
                If value > 2 Then
                    kLength = value
                Else
                    kLength = 4
                End If
            End Set
        End Property

        Public Property ReproductionFitness As Single
            Get
                Return kReproductionFitness
            End Get
            Set(value As Single)
                kReproductionFitness = value
            End Set
        End Property

        Public Property DeathFitnessLimit As Single
            Get
                Return kDeathFitness
            End Get
            Set(value As Single)
                kDeathFitness = value
            End Set
        End Property

        <Description("If [True], add (save) top fitness genes after crossover operation."), DefaultValue(True)>
        Public Property Save_2_BestCrossover As Boolean
            Get
                Return Best2
            End Get
            Set(value As Boolean)
                Best2 = value
            End Set

        End Property

        Private mIntervalles As List(Of Intervalle)
        Public Property Intervalles As List(Of Intervalle) Implements IEvolutionaryAlgo.Intervalles
            Get
                Return mIntervalles
            End Get
            Set(value As List(Of Intervalle))
                mIntervalles = value
            End Set
        End Property

        Dim mMaxIterations As Integer = 1
        Private Property MaxIterations As Integer Implements IEvolutionaryAlgo.MaxIterations
            Get
                Return mMaxIterations
            End Get
            Set(value As Integer)
                mMaxIterations = Math.Max(value, 0)
            End Set
        End Property

        Private Best_Chart As List(Of Double)
        Public ReadOnly Property BestChart As List(Of Double) Implements IEvolutionaryAlgo.BestChart
            Get
                Return Best_Chart
            End Get
        End Property

        Private Worst_Chart As List(Of Double)
        Public ReadOnly Property WorstChart As List(Of Double) Implements IEvolutionaryAlgo.WorstChart
            Get
                Return Worst_Chart
            End Get
        End Property


        Private Mean_Chart As List(Of Double)
        Public ReadOnly Property MeanChart As List(Of Double) Implements IEvolutionaryAlgo.MeanChart
            Get
                Return Mean_Chart
            End Get
        End Property

        Private Couple_Solution_Fitness As Dictionary(Of String, Double)
        Public ReadOnly Property Solution_Fitness As Dictionary(Of String, Double) Implements IEvolutionaryAlgo.Solution_Fitness
            Get
                Return Couple_Solution_Fitness
            End Get
        End Property

        Property mOptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Minimization
        Public Property OptimizationType As OptimizationTypeEnum Implements IEvolutionaryAlgo.OptimizationType
            Get
                Return mOptimizationType
            End Get
            Set(value As OptimizationTypeEnum)
                mOptimizationType = value
            End Set
        End Property

        Public ReadOnly Property BestSolution As Double() Implements IEvolutionaryAlgo.BestSolution
            Get
                Return Best_Genome.TheArray.ToArray()
            End Get
        End Property

        Public Property Dimensions_D As Integer Implements IEvolutionaryAlgo.Dimensions_D
            Get
                Return GenomesLenght
            End Get
            Set(value As Integer)
                GenomesLenght = Math.Max(value, 0)
            End Set
        End Property

        Public ReadOnly Property ComputationTime As Long Implements IEvolutionaryAlgo.ComputationTime
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property CurrentBestFitness As Double Implements IEvolutionaryAlgo.CurrentBestFitness
            Get
                Return Genomes.First.CurrentFitness
            End Get
        End Property

        Private eArg As AsyncOptimEventArgs
#End Region
        Public Sub New()
            HasInitialized = False
        End Sub

        Public Sub New(ByVal initialPopulation As Integer, ByVal geneLength As Integer, ByVal CrossoverIndx As Integer, ByVal min As Double, ByVal max As Double)

            kInitialPopulation = initialPopulation
            kLength = geneLength
            'kCrossover = CrossoverIndx
            Dim aGenome As Genome
            For i As Integer = 0 To (kInitialPopulation - 1)
                aGenome = New Genome(Me.Intervalles)
                ' aGenome.SetCrossoverPoint(kCrossover)
                'aGenome.CalculateFitness()
                'CalculateFitness(aGenome)
                Genomes.Add(aGenome)
            Next

            HasInitialized = True
        End Sub

        Private Sub Initialize()

            'Create new bestfitness chart
            Couple_Solution_Fitness = New Dictionary(Of String, Double)
            Best_Chart = New List(Of Double)
            Worst_Chart = New List(Of Double)
            Mean_Chart = New List(Of Double)

            Dim aGenome As Genome
            For i As Integer = 0 To (kInitialPopulation - 1)
                aGenome = New Genome(Me.Intervalles)
                'aGenome = New Genome(Me.GenomesLenght, -1, 1)
                'aGenome.SetCrossoverPoint(kCrossover)

                'aGenome.CalculateFitness()
                'CalculateFitness(aGenome)
                'RaiseEvent CalculateFitnessValue(aGenome)

                Genomes.Add(aGenome)
            Next
            CurrentPopulation = kInitialPopulation

            '-------------------------------------------
            Dim bestSolution((Me.GenomesLenght - 1)) As Double

            eArg = New AsyncOptimEventArgs()
            With eArg
                .ProgressPercentage = 0
                .CurrentSate = bestSolution
            End With
            '-------------------------------------------
            HasInitialized = True
        End Sub

        Private Sub Mutate(aGene As Genome)
            If Genome.TheSeed.Next(100) <= kMutationFrequency Then
                aGene.Mutate()
            End If
        End Sub

        Public Sub LuanchComputation() Implements IEvolutionaryAlgo.LuanchComputation

            If HasInitialized = False Then Initialize()

            For iteration As Integer = 1 To MaxIterations

                ''increment the generation;
                Generation += 1

                'check who can die
                For i As Integer = 0 To (Genomes.Count - 1)
                    If Genomes(i).CanDie(kDeathFitness) Then
                        'Debug.Print("Genome : {0} . is dead.", Genomes(i).ToString())
                        Genomes.RemoveAt(i)
                        i -= 1
                    End If
                Next
                'determine who can reproduce
                GenomeReproducers.Clear()
                GenomeResults.Clear()

                For i As Integer = 0 To (Genomes.Count - 1)
                    If Genomes(i).CanReproduce(kReproductionFitness) Then
                        GenomeReproducers.Add(Genomes(i))
                    End If
                Next

                'do the crossover of the genes and add them to the population
                DoCrossover(GenomeReproducers)

                Clone_Genomes(GenomeResults)

                '// mutate a few genes in the New population
                For i As Integer = 0 To (Genomes.Count - 1)
                    Mutate(Genomes(i))
                Next

                ' // calculate fitness of all the genes

                For i As Integer = 0 To (Genomes.Count - 1)
                    'Genomes(i).CalculateFitness()
                    'CalculateFitness(Genomes(i))

                    'Calculate custome fitness values 
                    RaiseEvent CalculateFitnessValue(Genomes(i))
                Next

                Genomes.Sort()

                ' // kill all the genes above the population limit

                If (Genomes.Count > kPopulationLimit) Then
                    Genomes.RemoveRange(kPopulationLimit, (Genomes.Count - kPopulationLimit))
                End If

                'Best chart :
                BestChart.Add((1 / Genomes.First.CurrentFitness))

                '------------Storage of (Solution - Fitness) history----------------------------------:  
                StrBouilder.Clear()

                StrBouilder.Append(iteration.ToString()).Append(": ")
                For ss = 0 To (Me.GenomesLenght - 1)
                    StrBouilder.Append(Math.Round(Genomes.First.TheArray(ss))).Append("; ")
                Next

                Couple_Solution_Fitness.Add(StrBouilder.ToString(), (1 / Genomes.First.CurrentFitness))
                '--------------------------------------------------------------------------------------
                'Worst chart :
                WorstChart.Add((1 / Genomes.Last.CurrentFitness))

                'Mean chart :
                MeanChart.Add(Get_MeanFitness(Genomes))

                CurrentPopulation = Genomes.Count

                '--------------Event---------------------------------------------------------
                For t = 0 To (GenomesLenght - 1)
                    eArg.CurrentSate(t) = Genomes.First.TheArray(t)
                Next
                eArg.ProgressPercentage = iteration
                RaiseEvent ProgressChanged(Me, eArg)
                '-----------------------------------------------------------------------------
            Next iteration
        End Sub

        ''' <summary>
        ''' Run one epoch "one generation" for MINIMIZATION optimization.
        ''' </summary>
        Public Sub RunEpoch() Implements IEvolutionaryAlgo.RunEpoch
            Try

                If HasInitialized = False Then Initialize()

                '-----For iteration As Integer = 1 To 1

                ''increment the generation;
                Generation += 1

                'check who can die
                For i As Integer = 0 To (Genomes.Count - 1)
                    If Genomes(i).CanDie(kDeathFitness) Then
                        'Debug.Print("Genome : {0} . is dead.", Genomes(i).ToString())
                        Genomes.RemoveAt(i)
                        i -= 1
                    End If
                Next

                'determine who can reproduce
                GenomeReproducers.Clear()

                GenomeResults.Clear()

                For i As Integer = 0 To (Genomes.Count - 1)
                    If Genomes(i).CanReproduce(kReproductionFitness) Then
                        GenomeReproducers.Add(Genomes(i))
                    End If
                Next

                'do the crossover of the genes and add them to the population
                DoCrossover(GenomeReproducers)

                Clone_Genomes(GenomeResults)

                '// mutate a few genes in the New population
                For i As Integer = 0 To (Genomes.Count - 1)
                    Mutate(Genomes(i))
                Next

                ' // calculate fitness of all the genes
                'Calculate custome fitness values 

                RaiseEvent CalculateFitnessValues(Genomes)

                Genomes.Sort()

                ' // kill all the genes above the population limit

                If (Genomes.Count > kPopulationLimit) Then
                    Genomes.RemoveRange(kPopulationLimit, (Genomes.Count - kPopulationLimit))
                End If

                'Best chart :
                BestChart.Add(Genomes.First.CurrentFitness)

                '------------Storage of (Solution - Fitness) history----------------------------------:  
                'StrBouilder.Clear()

                'StrBouilder.Append(Generation.ToString()).Append(": ")
                'For ss = 0 To (Me.GenomesLenght - 1)
                '    StrBouilder.Append(Math.Round(Genomes.First.TheArray(ss))).Append("; ")
                'Next

                'Couple_Solution_Fitness.Add(StrBouilder.ToString(), (1 / Genomes.First.CurrentFitness))
                '--------------------------------------------------------------------------------------
                'Worst chart :
                'WorstChart.Add((1 / Genomes.Last.CurrentFitness))

                'Mean chart :
                'MeanChart.Add(Get_MeanFitness(Genomes))

                CurrentPopulation = Genomes.Count

            Catch ex As Exception
                Throw ex
            End Try

            '--------------Event---------------------------------------------------------
            '    For t = 0 To (GenomesLenght - 1)
            '        eArg.CurrentSate(t) = Genomes.First.TheArray(t)
            '    Next
            'eArg.ProgressPercentage = Generation
            'RaiseEvent ProgressChanged(Me, eArg)
            '-----------------------------------------------------------------------------
            'Next iteration

        End Sub

        Dim sumFitness As Double = 0R
        Private Function Get_MeanFitness(ByRef genes As List(Of Genome)) As Double

            sumFitness = 0R
            For Each gen In genes
                sumFitness += (1 / gen.CurrentFitness)
            Next
            Return (sumFitness / genes.Count)

        End Function

        Private Sub CalculateFitnessForAll(genes As List(Of Genome))
            For Each ig As Genome In genes
                'ig.CalculateFitness()
                'CalculateFitness(ig)

                'Calculate custome fitness values 
                RaiseEvent CalculateFitnessValue(ig)
            Next
        End Sub

        <Obsolete("Here, you can change crossover probability"), Description("Crossover")>
        Private Sub DoCrossover(genes As List(Of Genome))
            Dim GeneMoms As New List(Of Genome)
            Dim GeneDads As New List(Of Genome)

            For i As Integer = 0 To (genes.Count - 1)
                '// randomly pick the moms And dad's
                If (Genome.TheSeed.Next(100) Mod 2) > 0 Then
                    GeneMoms.Add(genes(i))
                Else
                    GeneDads.Add(genes(i))
                End If
            Next

            ' //  now make them equal
            If (GeneMoms.Count > GeneDads.Count) Then
                While (GeneMoms.Count > GeneDads.Count)
                    GeneDads.Add(GeneMoms((GeneMoms.Count - 1)))
                    GeneMoms.RemoveAt((GeneMoms.Count - 1))
                End While

                If (GeneDads.Count > GeneMoms.Count) Then
                    GeneDads.RemoveAt((GeneDads.Count - 1)) '; // make sure they are equal
                End If

            Else
                While (GeneDads.Count > GeneMoms.Count)
                    GeneMoms.Add(GeneDads(GeneDads.Count - 1))
                    GeneDads.RemoveAt((GeneDads.Count - 1))
                End While
                If (GeneMoms.Count > GeneDads.Count) Then
                    '// make sure they are equal
                    GeneMoms.RemoveAt((GeneMoms.Count - 1))
                End If
            End If

            '// now cross them over and add them according to fitness
            For i As Integer = 0 To (GeneDads.Count - 1)
                '	// pick best 2 from parent And children
                Dim babyGene1 As Genome = GeneDads(i).Crossover(GeneMoms(i))
                Dim babyGene2 As Genome = GeneMoms(i).Crossover(GeneDads(i))

                GenomeFamily.Clear()
                GenomeFamily.Add(GeneDads(i))
                GenomeFamily.Add(GeneMoms(i))
                GenomeFamily.Add(babyGene1)
                GenomeFamily.Add(babyGene2)
                CalculateFitnessForAll(GenomeFamily)
                GenomeFamily.Sort()

                If Best2 = True Then
                    '// if Best2 Is true, add top fitness genes
                    GenomeResults.Add(GenomeFamily(0))
                    GenomeResults.Add(GenomeFamily(1))
                Else
                    GenomeResults.Add(babyGene1)
                    GenomeResults.Add(babyGene2)
                End If
            Next

        End Sub

        'Private Sub CalculateFitness(ByRef gene As Genome)
        '    gene.CurrentFitness = CalculateClosestProductSum_SDS(gene)
        'End Sub

        <Obsolete("Here put custom ObjFunt")> Private Function CalculateClosestProductSum_SDS(ByRef gene As Genome) As Double
            Dim sum As Double = 0R
            'For i As Integer = 0 To (gene.Length - 1)
            '    sum += gene.TheArray(i)
            'Next

            sum = (gene.TheArray(0) + gene.TheArray(1)) - (gene.TheArray(2) + gene.TheArray(3))

            If sum = 0 Then
                Return 0
            Else
                'Return Math.Abs((1 / sum))
                Return Math.Abs(sum)
            End If

        End Function

        Public Function WriteNextGeneration() As String
            Dim strb As New System.Text.StringBuilder()

            If Genomes.Count = 0 Then
                Initialize()
            End If

            strb.AppendLine(String.Format("Generation {0}", Generation))
            For i As Integer = 0 To (CurrentPopulation - 1)
                strb.AppendLine(Genomes(i).ToString())
            Next

            Return strb.ToString()
        End Function

        Private Sub Clone_Genomes(ByRef genes As List(Of Genome))
            Genomes.Clear()
            For Each gen In genes
                Genomes.Add(gen)
            Next
        End Sub


#Region "Events"
        Public Event CalculateFitnessValues(ByRef genomes As List(Of Genome))
        Public Event CalculateFitnessValue(ByRef gene As Genome)
        Public Event ProgressChanged(sender As Object, e As AsyncOptimEventArgs)
        Public Event ObjectiveFunctionComputation(ByRef positions() As Double, ByRef fitnessValue As Double) Implements IEvolutionaryAlgo.ObjectiveFunctionComputation
#End Region

    End Class



    Public Class AsyncOptimEventArgs
        Inherits EventArgs

        Public Sub New()
        End Sub

        Public Sub New(ByVal progresPercentage As Integer)
            Me.ProgressPercentage = progresPercentage
        End Sub

        Public Sub New(progresPercentage As Integer, currentState() As Double)
            Me.ProgressPercentage = progresPercentage
        End Sub

        Public ProgressPercentage As Int32
        Public CurrentSate() As Double

    End Class

End Namespace

