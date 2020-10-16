Imports System.Text
Imports RmosEngine.Components
Imports RmosEngine.SDynamicProgramming
Namespace MarkovChains
    Public Class ProbabilityMatrix

        Public Sub New(ByVal dimensionN As Integer)
            If dimensionN > 0 Then
                mDimension = dimensionN - 1
                Dim theMatrix(mDimension, 11) As Double
                mMatrix = theMatrix
            End If
        End Sub

        Public Sub New()
        End Sub

        Public Property Name As String

        Public Index As Integer = 0I

        Dim mMatrix(,) As Double = Nothing
        Public Property Matrix As Double(,)
            Get
                Return mMatrix
            End Get
            Set(ByVal value As Double(,))
                mMatrix = value
            End Set
        End Property

        Dim mDimension As Integer = 0I
        Public ReadOnly Property Dimension As Integer
            Get
                Return mDimension
            End Get
        End Property

        Public Function Get_ProbabilityMatrix(ByRef qSeries As InflowsQSeries, ByRef refQSerie As DataSerie3D) As Double(,)
            Try
                If IsNothing(qSeries) Then Return Nothing
                If IsNothing(qSeries.QSereies) Then Return Nothing
                If (qSeries.QSereies.Count = 0) Then Return Nothing

                If IsNothing(refQSerie) Then Return Nothing
                If IsNothing(refQSerie.Data) Then Return Nothing
                If (refQSerie.Data.Count = 0) Then Return Nothing

                mDimension = (refQSerie.Data.Count - 1)
                Dim theMatrix(mDimension, 11) As Double

                Dim sCount As Int32 = qSeries.QSereies.Count
                Dim vCount As Int32 = 0I

                Dim i As Integer = 0I
                Dim j As Integer = 0I


                For j = 0 To 11
                    i = 0I

                    For Each qc In refQSerie.Data
                        For Each seri In qSeries.QSereies
                            If seri.QSerie(j).Y_value = qc.Z_value Then
                                vCount += 1
                            End If
                        Next
                        theMatrix(i, j) = (vCount / sCount)
                        vCount = 0I
                        i += 1I
                    Next
                Next
                mMatrix = theMatrix
            Catch ex As Exception
                Throw ex
            End Try
            Return mMatrix

        End Function
#Region "Analyser"

#End Region
        Public Overrides Function ToString() As String
            Dim strb As New StringBuilder()

            For i As Integer = 0 To mMatrix.GetLength(0) - 1
                For j As Integer = 0 To mMatrix.GetLength(1) - 1
                    strb.Append(mMatrix(i, j).ToString()).Append("   ")
                Next
                strb.AppendLine()
            Next
            Return strb.ToString()
        End Function
    End Class
End Namespace
