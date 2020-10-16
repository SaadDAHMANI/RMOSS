'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:26
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Option Strict On
Imports System.ComponentModel
Imports RmosEngine.Components
Namespace MarkovChains
    Public Class TPMatrixAnalyser

        Public Sub New(ByRef RefClassSerie As DataSerie3D)
            Me.ReferenceClassSerie = RefClassSerie
        End Sub

        Public Sub New(ByRef RefClassSerie As DataSerie3D, ByRef series As List(Of InflowQSerie))
            Me.ReferenceClassSerie = RefClassSerie
            Me.mSeries = series
        End Sub

        Public Property ReferenceClassSerie As DataSerie3D

        Dim mSeries As List(Of InflowQSerie)
        Public Property Series As List(Of InflowQSerie)
            Get
                Return mSeries
            End Get
            Set(ByVal value As List(Of InflowQSerie))
                mSeries = value
            End Set
        End Property

        Public Sub Analyse()
            Try
                If Object.Equals(mSeries, Nothing) Then
                    Throw New ArgumentNullException("Inflow Q Data Serie")
                    Return
                End If
                If Object.Equals(Me.ReferenceClassSerie, Nothing) Then
                    Throw New ArgumentNullException("Reference Q Serie")
                    Return
                End If

                Dim tpMtx As TPMatrix
                Dim sCount As Integer = mSeries.Count - 1
                If sCount > 0 Then
                    Me.SetClassValue(Me.ReferenceClassSerie)
                    Me.Matrixs = New List(Of TPMatrix)(sCount)
                    For i As Int32 = 0 To (sCount - 1)
                        tpMtx = TpMatrix(mSeries(i), mSeries((i + 1)))
                        tpMtx.Index = i
                        Me.Matrixs.Add(tpMtx)
                    Next
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Property Matrixs As List(Of TPMatrix) = Nothing

        Private Function TpMatrix(ByRef dSerie1 As InflowQSerie, ByRef dSerie2 As InflowQSerie) As TPMatrix
            Dim n As Integer = Me.ReferenceClassSerie.Data.Count
            Dim tpmtx As New TPMatrix(n)
            Try
                If IsNothing(dSerie1) Then Return Nothing
                If IsNothing(dSerie2) Then Return Nothing
                If IsNothing(dSerie1.QSerie) Then Return Nothing
                If IsNothing(dSerie2.QSerie) Then Return Nothing
                If dSerie1.QSerie.Count <> dSerie2.QSerie.Count Then Return Nothing
                Dim cValue1 As Double = 0.0R
                Dim count1 As Integer = 0I
                Dim count2 As Integer = 0I
                Dim i, j As Integer
                Dim probability As Double = 0.0R
                i = 0I
                j = 0I

                With tpmtx
                    .From_Serie = dSerie1.Name
                    .To_Serie = dSerie2.Name
                    .Name = String.Format("Transition Probability Matrix From : [{0}] To [{1}]", dSerie1.Name, dSerie2.Name)
                End With
                For Each cl1 In ReferenceClassSerie.Data
                    count1 = 0I
                    count2 = 0I
                    cValue1 = cl1.Z_value
                    count1 = Get_Count_Of(cValue1, dSerie1)
                    j = 0I
                    If count1 > 0 Then
                        For Each cl2 In ReferenceClassSerie.Data
                            count2 = Get_Count_Of(cValue1, dSerie1, cl2.Z_value, dSerie2)
                            probability = (count2 / count1)
                            tpmtx.Matrix(i, j) = probability
                            j += 1
                        Next
                        j = 0I
                    Else
                        probability = 1 / n
                        For j = 0 To (n - 1)
                            tpmtx.Matrix(i, j) = probability
                        Next
                    End If
                    i += 1
                Next

            Catch ex As Exception
                Throw ex
            End Try
            Return tpmtx
        End Function

        Private Function Get_Count_Of(ByRef cValue As Double, ByRef inSerie As InflowQSerie) As Integer
            Dim count As Integer = 0I
            For Each itm As InflowQItem In inSerie.QSerie
                If itm.Q_Class = cValue Then
                    count += 1
                End If
            Next
            Return count
        End Function

        Private Function Get_Count_Of(ByRef cValue1 As Double, ByRef inSerie1 As InflowQSerie, ByRef cValue2 As Double, ByRef inSerie2 As InflowQSerie) As Integer
            Dim count As Integer = 0I
            Dim i As Integer = 0I
            For Each itm As InflowQItem In inSerie1.QSerie
                If itm.Q_Class = cValue1 Then
                    'Y_Value = Qc
                    If inSerie2.QSerie(i).Y_Value = cValue2 Then
                        count += 1
                    End If
                End If
                i += 1
            Next
            Return count
        End Function

        Private Sub SetClassValue(ByRef reference As DataSerie3D)
            Try
                If Object.Equals(mSeries, Nothing) Then Return
                If Object.Equals(reference, Nothing) Then Return
                If mSeries.Count > 0 Then
                    For Each ds2 In mSeries
                        If Object.Equals(ds2.QSerie, Nothing) = False Then
                            If ds2.QSerie.Count > 0 Then
                                For Each dit2 As InflowQItem In ds2.QSerie
                                    For Each refItm In reference.Data
                                        If (dit2.Inflow_Q >= refItm.X_Value) AndAlso (dit2.Inflow_Q < refItm.Y_Value) Then
                                            dit2.Q_Class = refItm.Z_Value
                                        End If
                                    Next
                                Next
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Function GetClassNumber() As Integer
            Return 4
        End Function
        
        End Class
        
End Namespace