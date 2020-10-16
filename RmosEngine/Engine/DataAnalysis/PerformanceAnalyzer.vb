Option Strict On
Imports System.ComponentModel
Imports IOOperations.Components

Namespace DataAnalysis
    Public Class PerformanceAnalyzer
        Public Property DS1 As DataSerie1D
        Public Property DS2 As DataSerie1D

        Public ReadOnly Property ReliabilityVolumetricIndex As Double
            Get
                If IsNothing(DS1) Then Return Double.NaN
                If IsNothing(DS1.Data) Then Return Double.NaN
                If IsNothing(DS2) Then Return Double.NaN
                If IsNothing(DS2.Data) Then Return Double.NaN

                Dim index As Double = Double.NaN
                Dim numerator, denominator As Double
                For Each itm In DS1.Data
                    numerator += itm.X_Value
                Next

                For Each itm In DS2.Data
                    denominator += itm.X_Value
                Next

                'Index computation :
                index = numerator / denominator

                Return index
            End Get
        End Property

        Public ReadOnly Property ReliabilityTimeBasedIndex As Double
            Get
                If IsNothing(DS1) Then Return Double.NaN
                If IsNothing(DS1.Data) Then Return Double.NaN
                If IsNothing(DS2) Then Return Double.NaN
                If IsNothing(DS2.Data) Then Return Double.NaN

                Dim index As Double = Double.NaN
                ff = 0
                TT = DS1.Data.Count

                If DS2.Data.Count <> TT Then Return Double.NaN

                For i As Integer = 0 To (TT - 1)
                    If DS1.Data(i).X_Value < (DS2.Data(i).X_Value - MaxDifference) Then
                        ff += 1
                    End If
                Next
                'Index computation :
                index = 1 - (ff / TT)
                Return index
            End Get
        End Property

        Public Property MaxDifference As Double = 0.001
        Dim TT As Integer = -1

        Public ReadOnly Property Tvalue As Integer
            Get
                Return TT
            End Get
        End Property

        Dim ff As Integer = -1
        Public ReadOnly Property Fvalue As Integer
            Get
                Return ff
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim result As String = "Performance Report :"
            result += vbNewLine
            result += String.Format("Time Based Reliability Index : at = {0}", ReliabilityTimeBasedIndex.ToString("F4"))
            result += vbNewLine
            result += String.Format("Volumetric Reliability Index : av = {0}", ReliabilityVolumetricIndex.ToString("F4"))
            result += vbNewLine
            result += String.Format("T = {0}", TT)
            result += vbNewLine
            result += String.Format("f = {0}", ff)
            Return result
        End Function
    End Class
End Namespace


