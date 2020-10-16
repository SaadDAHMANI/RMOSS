'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:12
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
	Public Class DataSerie1D
        Implements IDataSerie1D

        Dim mIsNew As Boolean = True
        Public Property IsNew As Boolean Implements IDataSerie1D.IsNew
            Get
                Return mIsNew
            End Get
            Set(value As Boolean)
                mIsNew = value
            End Set
        End Property

        Dim m_Name As String
        Public Property Name As String Implements IDataSerie1D.Name
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Private m_Description As String
        Public Property Description As String Implements IDataSerie1D.Description
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property

        Private m_Title As String
        Public Property Title As String Implements IDataSerie1D.Title
            Get
                Return m_Title
            End Get
            Set(value As String)
                m_Title = value
            End Set
        End Property

        Dim mData As List(Of IDataItem1D)
        Public Property Data As System.Collections.Generic.List(Of IDataItem1D) Implements IDataSerie1D.Data
            Get
                Return mData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of IDataItem1D))
                mData = value
            End Set
        End Property

        Dim mX_Title As String = "X"
        Public Property X_Title As String Implements IDataSerie1D.X_Title
            Get
                Return mX_Title
            End Get
            Set(ByVal value As String)
                mX_Title = value
            End Set
        End Property

        Public Sub Add(ByVal title As String, ByVal x As Double) Implements IDataSerie1D.Add
            If IsNothing(mData) Then
                mData = New List(Of IDataItem1D)
            End If
            mData.Add(New DataItem1D(title, x))
        End Sub

        Public Sub Add(ByVal x As Double)
            If IsNothing(mData) Then
                mData = New List(Of IDataItem1D)
            End If
            mData.Add(New DataItem1D(x))
        End Sub

        Public Function ToArray() As Double()
            If IsNothing(mData) Then Return Nothing
            Dim iCount As Integer = mData.Count - 1
            If iCount = -1 Then Return Nothing

            Dim result(iCount) As Double
            For i As Integer = 0 To iCount
                result(i) = mData(i).X_value
            Next
            Return result
        End Function

        Public Sub Clear() Implements IDataSerie1D.Clear
            If IsNothing(mData) Then Return
            mData.Clear()
        End Sub

#Region "Shared fucnctions"
        Public Shared Function ConvertFrom(ByRef ds1Io As IOOperations.Components.DataSerie1D) As DataSerie1D
            Dim ds1 As DataSerie1D = Nothing
            Try
                If IsNothing(ds1Io) Then Return Nothing
                ds1 = New DataSerie1D()
                With ds1
                    .Name = ds1Io.Name
                    .Description = ds1Io.Description
                    .Title = ds1Io.Title
                    .X_Title = ds1Io.X_Title
                End With
                If IsNothing(ds1Io.Data) = False Then
                    If ds1Io.Data.Count > 0 Then
                        ds1.mData = New List(Of IDataItem1D)
                        For Each itm As IOOperations.Components.DataItem1D In ds1Io.Data
                            ds1.mData.Add(New DataItem1D(itm.Title, itm.X_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds1
        End Function
        Public Shared Function ConvertToDs1Io(ByRef ds1 As IDataSerie1D) As IOOperations.Components.DataSerie1D
            Dim dsIo As IOOperations.Components.DataSerie1D = Nothing
            Try
                If IsNothing(ds1) Then Return Nothing
                dsIo = New IOOperations.Components.DataSerie1D()
                With dsIo
                    .Name = ds1.Name
                    .Description = ds1.Description
                    .Title = ds1.Title
                    .X_Title = ds1.X_Title

                End With
                If IsNothing(ds1.Data) = False Then
                    If ds1.Data.Count > 0 Then
                        dsIo.Data = New List(Of IOOperations.Components.DataItem1D)
                        For Each itm As IDataItem1D In ds1.Data
                            dsIo.Data.Add(New IOOperations.Components.DataItem1D(itm.Title, itm.X_value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return dsIo
        End Function

#End Region

        Public Property FileName As String Implements IDataSerieBase.FileName
    End Class
End Namespace


