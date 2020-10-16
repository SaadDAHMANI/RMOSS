'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:14
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
	Public Class DataSerie3D
        Implements IDataSerie3D

        Dim mIsNew As Boolean = True
        Public Property IsNew As Boolean Implements IDataSerie3D.IsNew
            Get
                Return mIsNew
            End Get
            Set(value As Boolean)
                mIsNew = value
            End Set
        End Property

        Dim m_Name As String = "New Data Serie "
        Public Property Name As String Implements IDataSerie3D.Name
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Private m_Description As String = "//"
        Public Property Description As String Implements IDataSerie3D.Description
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property

        Private m_Title As String = "//"
        Public Property Title As String Implements IDataSerie3D.Title
            Get
                Return m_Title
            End Get
            Set(value As String)
                m_Title = value
            End Set
        End Property

        Dim mData As List(Of IDataItem3D)
        Public Property Data As List(Of IDataItem3D) Implements IDataSerie3D.Data
            Get
                Return mData
            End Get
            Set(ByVal value As List(Of IDataItem3D))
                mData = value
            End Set
        End Property

        Dim mXTitle As String = "X"
        Public Property X_Title As String Implements IDataSerie3D.X_Title
            Get
                Return mXTitle
            End Get
            Set(ByVal value As String)
                mXTitle = value
            End Set
        End Property

        Dim mYTitle As String = "Y"
        Public Property Y_Title As String Implements IDataSerie3D.Y_Title
            Get
                Return mYTitle
            End Get
            Set(ByVal value As String)
                mYTitle = value
            End Set
        End Property

        Dim mZTitle As String = "Z"
        Public Property Z_Title As String Implements IDataSerie3D.Z_Title
            Get
                Return mZTitle
            End Get
            Set(ByVal value As String)
                mZTitle = value
            End Set
        End Property

        Public Sub Add(ByVal x As Double, ByVal y As Double, ByVal z As Double)
            If Me.mData Is Nothing Then
                mData = New List(Of IDataItem3D)
            End If
            mData.Add(New DataItem3D(x, y, z))
        End Sub

        Public Sub Add(ByVal title As String, ByVal x As Double, ByVal y As Double, ByVal z As Double) Implements IDataSerie3D.Add
            If Me.mData Is Nothing Then
                mData = New List(Of IDataItem3D)
            End If
            mData.Add(New DataItem3D(title, x, y, z))
        End Sub

        Public Sub Clear() Implements IDataSerie3D.Clear
            If IsNothing(mData) Then Return
            mData.Clear()
        End Sub
#Region "Shared fucnctions"

        Public Shared Function ConvertFrom(ByRef ds3Io As IOOperations.Components.DataSerie3D) As DataSerie3D
            Dim ds3 As DataSerie3D = Nothing
            Try
                If IsNothing(ds3Io) Then Return Nothing
                ds3 = New DataSerie3D()
                With ds3
                    .m_Name = ds3Io.Name
                    .m_Description = ds3Io.Description
                    .m_Title = ds3Io.Title
                    .X_Title = ds3Io.X_Title
                    .Y_Title = ds3Io.Y_Title
                    .Z_Title = ds3Io.Z_Title
                End With
                If IsNothing(ds3Io.Data) = False Then
                    If ds3Io.Data.Count > 0 Then
                        ds3.mData = New List(Of IDataItem3D)
                        For Each itm As IOOperations.Components.DataItem3D In ds3Io.Data
                            ds3.mData.Add(New DataItem3D(itm.Title, itm.X_Value, itm.Y_Value, itm.Z_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds3
        End Function

        Public Shared Function ConvertToDs3Io(ByRef ds3 As IDataSerie3D) As IOOperations.Components.DataSerie3D
            Dim ds3Io As IOOperations.Components.DataSerie3D = Nothing
            Try
                If IsNothing(ds3) Then Return Nothing
                ds3Io = New IOOperations.Components.DataSerie3D()
                With ds3Io
                    .Name = ds3.Name
                    .Description = ds3.Description
                    .Title = ds3.Title
                    .X_Title = ds3.X_Title
                    .Y_Title = ds3.Y_Title
                    .Z_Title = ds3.Z_Title
                End With
                If IsNothing(ds3.Data) = False Then
                    If ds3.Data.Count > 0 Then
                        ds3Io.Data = New List(Of IOOperations.Components.DataItem3D)
                        For Each itm As IDataItem3D In ds3.Data
                            ds3Io.Data.Add(New IOOperations.Components.DataItem3D(itm.Title, itm.X_value, itm.Y_value, itm.Z_value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds3Io
        End Function

        Public Shared Function ConvertToDs3Io(ByRef ds3 As DataSerie3D) As IOOperations.Components.DataSerie3D
            Dim ds3Io As IOOperations.Components.DataSerie3D = Nothing
            Try
                If IsNothing(ds3) Then Return Nothing
                ds3Io = New IOOperations.Components.DataSerie3D()
                With ds3Io
                    .Name = ds3.Name
                    .Description = ds3.Description
                    .Title = ds3.Title
                    .X_Title = ds3.X_Title
                    .Y_Title = ds3.Y_Title
                    .Z_Title = ds3.Z_Title
                End With
                If IsNothing(ds3.Data) = False Then
                    If ds3.Data.Count > 0 Then
                        ds3Io.Data = New List(Of IOOperations.Components.DataItem3D)
                        For Each itm In ds3.Data
                            ds3Io.Data.Add(New IOOperations.Components.DataItem3D(itm.Title, itm.X_value, itm.Y_value, itm.Z_value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds3Io
        End Function
#End Region



        Public Property FileName As String Implements IDataSerieBase.FileName
    End Class
End Namespace
