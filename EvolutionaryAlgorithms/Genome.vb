Option Strict On
Imports System.ComponentModel

Namespace GeneticAlgorithm
    Public Class Genome
        Implements IComparable
        <Description("Lenght of Genome.")>
        Public Length As Int32

        <Description("The point of crossover operation in Genome.")>
        Public CrossoverPoint As Integer

        Public MutationIndex As Integer

        Public CurrentFitness As Double = 0.0R

        <Description("Genome vector (Arrayof values).")>
        Public TheArray As New List(Of Double)

        '----------------SDS- Section must modified----
        Public Shared TheSeed As Random = New Random()

        Public Property Intervalles As List(Of Intervalle)

        Public Sub New()

        End Sub

        '<Description("[Min, Max]")> Public Property Min_Value As Double
        '    Get
        '        Return TheMin
        '    End Get
        '    Set(value As Double)
        '        TheMin = value
        '    End Set
        'End Property

        '<Description("[Min, Max]")> Public Property Max_Value As Double
        '    Get
        '        Return TheMax
        '    End Get
        '    Set(value As Double)
        '        TheMax = value
        '    End Set
        'End Property

        'Private TheMin As Double = 0
        'Private TheMax As Double = 100

        Private StrBuilder As Text.StringBuilder
        '----------------------------------------------

        Public Function CompareTo(a As Object) As Integer Implements IComparable.CompareTo
            Dim Gene1 As Genome = Me
            Dim Gene2 As Genome = CType(a, Genome)
            Return Math.Sign((Gene2.CurrentFitness - Gene1.CurrentFitness))
        End Function

        Public Sub New(ByVal lengh As Integer, ByVal min As Double, ByVal max As Double)
            Me.Length = lengh
            Dim nextValue As Double
            For i As Integer = 0 To (lengh - 1)
                nextValue = GenerateGeneValue(min, max)

                TheArray.Add(nextValue)
            Next
        End Sub

        Public Sub New(ByRef intervales As List(Of Intervalle))
            Me.Length = intervales.Count
            Me.Intervalles = intervales

            Dim nextValue As Double
            For i As Integer = 0 To (Me.Length - 1)
                nextValue = GenerateGeneValue(intervales(i).Min_Value, intervales(i).Max_Value)
                TheArray.Add(nextValue)
            Next
        End Sub

        Public Sub Initialize()
        End Sub

        Public Function CanDie(fitnessLimit As Double) As Boolean

            'If CurrentFitness <= (fitnessLimit * 100) Then
            If CurrentFitness <= fitnessLimit Then
                Return True
            End If
            Return False

        End Function

        <Description("Determine if Genome can reproduce randomly"), Obsolete("Update this...")>
        Public Function CanReproduce(fitnessLimit As Double) As Boolean
            'If TheSeed.Next(100) >= (fitnessLimit * 100) Then
            If TheSeed.Next(100) >= fitnessLimit Then
                Return True
            End If
            Return False
        End Function

        '<Description("Original version")> Public Function GenerateGeneValue0(min As Object, max As Object) As Integer
        '    Return TheSeed.Next(CInt(min), CInt(max))
        'End Function

        '<Obsolete("For negative values")> Public Function GenerateGeneValue1(min As Object, max As Object) As Double
        '    Dim value As Double = 0R
        '    Dim signe As Integer = 0

        '    value = (TheMax - TheMin) + TheMin
        '    While signe = 0
        '        signe = TheSeed.Next(-1, 2)
        '    End While
        '    value = (value * signe * TheSeed.NextDouble())
        '    Return value

        'End Function

        Public Function GenerateGeneValue(min As Double, max As Double) As Double
            'Dim value As Double = 0R
            'value = (max - min) + min
            'value = (value * TheSeed.NextDouble())
            'value = (value * TheSeed.NextDouble())
            'Return value
            Return (((max - min) * TheSeed.NextDouble()) + min)
        End Function

        <Description("Mutate randomly one element in Genome array.")>
        Public Sub Mutate()
            MutationIndex = TheSeed.Next(Length)
            Dim val As Double = GenerateGeneValue(Me.Intervalles(MutationIndex).Min_Value, Me.Intervalles(MutationIndex).Max_Value)
            TheArray(MutationIndex) = val
        End Sub

        'This fitness function calculates the closest product sum
        '<Obsolete("Here put custom ObjFunt")> Private Function CalculateClosestProductSum() As Double
        'Dim sum As Double = 0R
        '    Dim product As Double = 1.0R
        '    For i As Integer = 0 To (Length - 1)
        '        sum += CInt(TheArray(i))
        '        product *= CInt(TheArray(i))
        '    Next

        '    If product = sum Then
        '        CurrentFitness = 1.0R
        '    Else
        '        CurrentFitness = Math.Abs(Math.Abs(1.0 / (product - sum)) - 0.02)
        '    End If

        '    Return CurrentFitness

        'End Function

        'This fitness function calculates the closest product sum

        <Obsolete("Here put custom ObjFunt")> Private Function CalculateClosestProductSum_SDS() As Double
            Dim sum As Double = 0R
            For i As Integer = 0 To (Length - 1)
                sum += TheArray(i)
            Next

            If sum = 0 Then
                CurrentFitness = 0
            Else
                'CurrentFitness = Math.Abs((1 / sum))
                CurrentFitness = Math.Abs(sum)
            End If

            Return CurrentFitness

        End Function

        Public Sub CopyGeneInfo(dest As Genome)
            Dim theGenome As Genome = dest
            With theGenome
                .Length = Length
                '.TheMin = TheMin
                '.TheMax = TheMax
                .Intervalles = Intervalles
            End With
        End Sub


        <Obsolete("Must Verified at g.CopyGeneInfo(aGene1) / g.CopyGeneInfo(aGene2)")>
        Public Function Crossover(g As Genome) As Genome
            Dim aGene1 As New Genome()
            Dim aGene2 As New Genome()

            g.CopyGeneInfo(aGene1)
            g.CopyGeneInfo(aGene2)

            CrossoverPoint = TheSeed.Next(Me.Length)

            Dim CrossingGene As Genome = g
            For i As Integer = 0 To (CrossoverPoint - 1)
                aGene1.TheArray.Add(CrossingGene.TheArray(i))
                aGene2.TheArray.Add(Me.TheArray(i))
            Next
            '      
            For j As Int32 = CrossoverPoint To (Length - 1)
                aGene1.TheArray.Add(Me.TheArray(j))
                aGene2.TheArray.Add(CrossingGene.TheArray(j))
            Next

            '50/50 chance of returning gene1 Or gene2
            Dim aGene As Genome = Nothing
            If TheSeed.Next(2) = 1 Then
                aGene = aGene1
            Else
                aGene = aGene2
            End If

            Return aGene

        End Function

        Public Overrides Function ToString() As String
            If IsNothing(StrBuilder) Then
                StrBuilder = New Text.StringBuilder()
            Else
                StrBuilder.Clear()
            End If

            For i As Integer = 0 To (Length - 1)
                StrBuilder.Append(Math.Round(TheArray(i), 2).ToString()).Append(" ")
            Next
            StrBuilder.Append(": Fitness = ").Append(CurrentFitness.ToString())
            Return StrBuilder.ToString()
        End Function

    End Class

End Namespace



