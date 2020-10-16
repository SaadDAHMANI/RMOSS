'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:21
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
	Public Class InflowQSerie
        Implements IDataSerie2D

        Dim mIsNew As Boolean = True
        Public Property IsNew As Boolean Implements IDataSerie2D.IsNew
            Get
                Return mIsNew
            End Get
            Set(value As Boolean)
                mIsNew = value
            End Set
        End Property

        Dim m_Name As String
        Public Property Name As String Implements IDataSerie2D.Name
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Private m_Description As String
        Public Property Description As String Implements IDataSerie2D.Description
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property

        Private m_Title As String
        Public Property Title As String Implements IDataSerie2D.Title
            Get
                Return m_Title
            End Get
            Set(ByVal value As String)
                m_Title = value
            End Set
        End Property


        Dim mQSerie As List(Of IDataItem2D)
        Public Overridable Property QSerie As List(Of IDataItem2D) Implements IDataSerie2D.Data
            Get
                Return mQSerie
            End Get
            Set(ByVal value As List(Of IDataItem2D))
                mQSerie = value
            End Set
        End Property

        Dim mQ_Title As String = "Q"
        Public Overridable Property Q_Title As String Implements IDataSerie2D.X_Title
            Get
                Return mQ_Title
            End Get
            Set(ByVal value As String)
                mQ_Title = value
            End Set
        End Property

        Dim mQc_Title As String = "Qc"
        Public Overridable Property Qc_Title As String Implements IDataSerie2D.Y_Title
            Get
                Return mQc_Title
            End Get
            Set(ByVal value As String)
                mQc_Title = value
            End Set
        End Property

        Public Sub Add(ByVal title As String, ByVal xValue As Double, ByVal yValue As Double) Implements IDataSerie2D.Add
            If mQSerie Is Nothing Then
                mQSerie = New List(Of IDataItem2D)
            End If
            mQSerie.Add(New InflowQItem(title, xValue, yValue))
        End Sub

        Public Sub Add(ByVal xValue As Double, ByVal yValue As Double)
            If mQSerie Is Nothing Then
                mQSerie = New List(Of IDataItem2D)
            End If
            mQSerie.Add(New InflowQItem(String.Empty, xValue, yValue))
        End Sub

        Public Sub Clear() Implements IDataSerie2D.Clear
            If IsNothing(mQSerie) Then Return
            mQSerie.Clear()
        End Sub

#Region "Shared fucnctions"

        Public Shared Function ConvertFrom(ByRef ds2Io As IOOperations.Components.DataSerie2D) As InflowQSerie
            Dim ds2 As InflowQSerie = Nothing
            Try
                If IsNothing(ds2Io) Then Return Nothing
                ds2 = New InflowQSerie
                With ds2
                    .Name = ds2Io.Name
                    .Description = ds2Io.Description
                    .Title = ds2Io.Title
                    .Q_Title = ds2Io.X_Title
                    .Qc_Title = ds2Io.Y_Title
                End With
                If IsNothing(ds2Io.Data) = False Then
                    If ds2Io.Data.Count > 0 Then
                        ds2.mQSerie = New List(Of IDataItem2D)
                        For Each itm As IOOperations.Components.DataItem2D In ds2Io.Data
                            ds2.mQSerie.Add(New InflowQItem(itm.Title, itm.X_Value, itm.Y_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds2
        End Function

        Public Shared Function ConvertToDs2Io(ByVal ds2 As IDataSerie2D) As IOOperations.Components.DataSerie2D
            Dim ds2Io As IOOperations.Components.DataSerie2D = Nothing
            Try
                If IsNothing(ds2) Then Return Nothing
                ds2Io = New IOOperations.Components.DataSerie2D()
                With ds2Io
                    .Name = ds2.Name
                    .Description = ds2.Description
                    .Title = ds2.Title
                    .X_Title = ds2.X_Title
                    .Y_Title = ds2.Y_Title
                End With
                If IsNothing(ds2.Data) = False Then
                    If ds2.Data.Count > 0 Then
                        ds2Io.Data = New List(Of IOOperations.Components.DataItem2D)
                        For Each itm As IDataItem2D In ds2.Data
                            ds2Io.Data.Add(New IOOperations.Components.DataItem2D(itm.Title, itm.X_value, itm.Y_value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds2Io
        End Function

        Public Shared Function ConvertToDs1Io(ByVal ds2 As IDataSerie2D) As IOOperations.Components.DataSerie1D
            Dim ds1Io As IOOperations.Components.DataSerie1D = Nothing
            Try
                If IsNothing(ds2) Then Return Nothing
                ds1Io = New IOOperations.Components.DataSerie1D()
                With ds1Io
                    .Name = ds2.Name
                    .Description = ds2.Description
                    .Title = ds2.Title
                    .X_Title = ds2.X_Title
                End With
                If IsNothing(ds2.Data) = False Then
                    If ds2.Data.Count > 0 Then
                        ds1Io.Data = New List(Of IOOperations.Components.DataItem1D)
                        For Each itm In ds2.Data
                            ds1Io.Data.Add(New IOOperations.Components.DataItem1D(itm.Title, itm.X_value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds1Io
        End Function
#End Region

        Public Property FileName As String Implements IDataSerieBase.FileName

        Public ReadOnly Property XAverage As Double
            Get
                If IsNothing(mQSerie) Then Return Double.NaN
                If mQSerie.Count = 0 Then Return Double.NaN
                Dim value As Double = 0
                Dim sum As Double = 0
                For Each itm In mQSerie
                    sum += itm.X_value
                Next
                value = (sum / mQSerie.Count)
                Return Math.Round(value, 3)
            End Get
        End Property

        Public ReadOnly Property YAverage As Double
            Get
                If IsNothing(mQSerie) Then Return Double.NaN
                If mQSerie.Count = 0 Then Return Double.NaN
                Dim value As Double = 0
                Dim sum As Double = 0
                For Each itm In mQSerie
                    sum += itm.Y_value
                Next
                value = (sum / mQSerie.Count)
                Return Math.Round(value, 3)
            End Get
        End Property

    End Class
End Namespace

