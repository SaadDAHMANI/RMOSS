'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:13
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
	Public Class DataSerie2D
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

        Dim m_Name As String = "DS2"
        Public Overridable Property Name As String Implements IDataSerie2D.Name
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Private m_Description As String = "n/a"
        Public Overridable Property Description As String Implements IDataSerie2D.Description
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property

        Private m_Title As String = "DS2"
        Public Overridable Property Title As String Implements IDataSerie2D.Title
            Get
                Return m_Title
            End Get
            Set(value As String)
                m_Title = value
            End Set
        End Property


        Dim mData As List(Of IDataItem2D)
        Public Overridable Property Data As System.Collections.Generic.List(Of IDataItem2D) Implements IDataSerie2D.Data
            Get
                Return mData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of IDataItem2D))
                mData = value
            End Set
        End Property

        Dim mX_Title As String = "X"
        Public Overridable Property X_Title As String Implements IDataSerie2D.X_Title
            Get
                Return mX_Title
            End Get
            Set(ByVal value As String)
                mX_Title = value
            End Set
        End Property

        Dim mY_Title As String = "Y"
        Public Overridable Property Y_Title As String Implements IDataSerie2D.Y_Title
            Get
                Return mY_Title
            End Get
            Set(ByVal value As String)
                mY_Title = value
            End Set
        End Property

        Public Overridable Sub Add(ByVal title As String, ByVal x As Double, ByVal y As Double) Implements IDataSerie2D.Add
            If IsNothing(mData) Then
                mData = New List(Of IDataItem2D)
            End If
            mData.Add(New DataItem2D(title, x, y))
        End Sub

        Public Overridable Sub Add(ByVal x As Double, ByVal y As Double)
            If IsNothing(mData) Then
                mData = New List(Of IDataItem2D)
            End If
            mData.Add(New DataItem2D(x, y))
        End Sub

#Region "Shared fucnctions"
        Public Shared Function ConvertFrom(ByRef ds2Io As IOOperations.Components.DataSerie2D) As DataSerie2D
            Dim ds2 As DataSerie2D = Nothing
            Try
                If IsNothing(ds2Io) Then Return Nothing
                ds2 = New DataSerie2D()
                With ds2
                    .Name = ds2Io.Name
                    .Description = ds2Io.Description
                    .Title = ds2Io.Title
                    .X_Title = ds2Io.X_Title
                    .Y_Title = ds2Io.Y_Title
                End With
                If IsNothing(ds2Io.Data) = False Then
                    If ds2Io.Data.Count > 0 Then
                        ds2.mData = New List(Of IDataItem2D)
                        For Each itm As IOOperations.Components.DataItem2D In ds2Io.Data
                            ds2.mData.Add(New DataItem2D(itm.Title, itm.X_Value, itm.Y_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds2
        End Function
        Public Shared Function ConvertToDs2Io(ByRef ds2 As IDataSerie2D) As IOOperations.Components.DataSerie2D
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
        Public Shared Function ConvertToDs2Io(ByRef ds2 As DataSerie2D) As IOOperations.Components.DataSerie2D
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
#End Region

        Public Overridable Sub Clear() Implements IDataSerie2D.Clear
            If IsNothing(mData) Then Return
            mData.Clear()
        End Sub
        Public Overridable Property FileName As String Implements IDataSerieBase.FileName

        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
    End Class
End Namespace


