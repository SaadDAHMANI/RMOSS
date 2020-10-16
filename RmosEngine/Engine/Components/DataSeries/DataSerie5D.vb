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
	Public Class DataSerie5D
        Implements IDataSerie5D

        Dim mIsNew As Boolean = True
        Public Property IsNew As Boolean Implements IDataSerie5D.IsNew
            Get
                Return mIsNew
            End Get
            Set(value As Boolean)
                mIsNew = value
            End Set
        End Property
        Public Index As Integer = 0I

        Dim m_Name As String
        Public Property Name As String Implements IDataSerie5D.Name
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Private m_Description As String
        Public Property Description As String Implements IDataSerie5D.Description
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property

        Private m_Title As String
        Public Property Title As String Implements IDataSerie5D.Title
            Get
                Return m_Title
            End Get
            Set(ByVal value As String)
                m_Title = value
            End Set
        End Property

        Public Shared Function ConvertToDs5Io(ByRef ds5 As IDataSerie1D) As IOOperations.Components.DataSerie5D
            Dim dsIo As IOOperations.Components.DataSerie5D = Nothing
            Try
                If IsNothing(ds5) Then Return Nothing
                dsIo = New IOOperations.Components.DataSerie5D()
                With dsIo
                    .Name = ds5.Name
                    .Description = ds5.Description
                    .Title = ds5.Title

                End With
                If IsNothing(ds5.Data) = False Then
                    If ds5.Data.Count > 0 Then
                        dsIo.Data = New List(Of IOOperations.Components.DataItem5D)
                        For Each itm As IDataItem5D In ds5.Data
                            dsIo.Data.Add(New IOOperations.Components.DataItem5D(itm.Title, itm.K_Value, itm.I_Value, itm.L_Value, itm.R_Value, itm.B_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return dsIo
        End Function

        Public Overrides Function ToString() As String
            Dim strb As New System.Text.StringBuilder()
            With strb
                .AppendLine(Me.m_Name)
                For Each itm In mData
                    .AppendLine(itm.ToString())
                Next
            End With
            Return strb.ToString
        End Function

#Region "Shared fucnctions"

        Public Shared Function ConvertFrom(ByRef ds5Io As IOOperations.Components.DataSerie5D) As DataSerie5D
            Dim ds5 As DataSerie5D = Nothing
            Try
                If IsNothing(ds5Io) Then Return Nothing
                ds5 = New DataSerie5D()
                With ds5
                    .Name = ds5Io.Name
                    .Description = ds5Io.Description
                    .Title = ds5Io.Title
                    .A_Title = ds5Io.A_Title
                    .B_Title = ds5Io.B_Title
                    .C_Title = ds5Io.C_Title
                    .D_Title = ds5Io.D_Title
                    .E_Title = ds5Io.E_Title
                End With
                If IsNothing(ds5Io.Data) = False Then
                    If ds5Io.Data.Count > 0 Then
                        ds5.mData = New List(Of IDataItem5D)
                        For Each itm As IOOperations.Components.DataItem5D In ds5Io.Data
                            ds5.mData.Add(New DataItem5D(itm.Title, itm.A_Value, itm.B_Value, itm.C_Value, itm.D_Value, itm.E_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds5
        End Function
        Public Shared Function ConvertToDs5Io(ByRef ds5 As IDataSerie5D) As IOOperations.Components.DataSerie5D
            Dim dsIo As IOOperations.Components.DataSerie5D = Nothing
            Try
                If IsNothing(ds5) Then Return Nothing
                dsIo = New IOOperations.Components.DataSerie5D()
                With dsIo
                    .Name = ds5.Name
                    .Description = ds5.Description
                    .Title = ds5.Title
                    .A_Title = ds5.A_Title
                    .B_Title = ds5.B_Title
                    .C_Title = ds5.C_Title
                    .D_Title = ds5.D_Title
                    .E_Title = ds5.E_Title
                End With
                If IsNothing(ds5.Data) = False Then
                    If ds5.Data.Count > 0 Then
                        dsIo.Data = New List(Of IOOperations.Components.DataItem5D)
                        For Each itm As IDataItem5D In ds5.Data
                            dsIo.Data.Add(New IOOperations.Components.DataItem5D(itm.Title, itm.K_Value, itm.I_Value, itm.L_Value, itm.R_Value, itm.B_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return dsIo
        End Function
        Public Shared Function ConvertToDs5Io(ByRef ds5 As DataSerie5D) As IOOperations.Components.DataSerie5D
            Dim dsIo As IOOperations.Components.DataSerie5D = Nothing
            Try
                If IsNothing(ds5) Then Return Nothing
                dsIo = New IOOperations.Components.DataSerie5D()
                With dsIo
                    .Name = ds5.Name
                    .Description = ds5.Description
                    .Title = ds5.Title
                    .A_Title = ds5.A_Title
                    .B_Title = ds5.B_Title
                    .C_Title = ds5.C_Title
                    .D_Title = ds5.D_Title
                    .E_Title = ds5.E_Title
                End With
                If IsNothing(ds5.Data) = False Then
                    If ds5.Data.Count > 0 Then
                        dsIo.Data = New List(Of IOOperations.Components.DataItem5D)
                        For Each itm As IDataItem5D In ds5.Data
                            dsIo.Data.Add(New IOOperations.Components.DataItem5D(itm.Title, itm.K_Value, itm.I_Value, itm.L_Value, itm.R_Value, itm.B_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return dsIo
        End Function

#End Region
        Dim mA_Title As String = "A"
        Public Property A_Title As String Implements IDataSerie5D.A_Title
            Get
                Return mA_Title
            End Get
            Set(ByVal value As String)
                mA_Title = value
            End Set
        End Property

        Public Sub Add(ByVal title As String, ByVal aa As Double, ByVal bb As Double, ByVal cc As Double, ByVal dd As Double, ByVal ee As Double) Implements IDataSerie5D.Add
            If IsNothing(mData) Then
                mData = New List(Of IDataItem5D)
            End If
            mData.Add(New DataItem5D(aa, bb, cc, dd, ee))
        End Sub

        Dim mB_Title As String
        Public Property B_Title As String Implements IDataSerie5D.B_Title
            Get
                Return mB_Title
            End Get
            Set(ByVal value As String)
                mB_Title = value
            End Set
        End Property

        Dim mC_Title As String
        Public Property C_Title As String Implements IDataSerie5D.C_Title
            Get
                Return mC_Title
            End Get
            Set(ByVal value As String)
                mC_Title = value
            End Set
        End Property

        Public Sub Clear() Implements IDataSerie5D.Clear
            If IsNothing(mData) Then Return
            mData.Clear()
        End Sub

        Dim mData As New List(Of IDataItem5D)
        Public Property Data As System.Collections.Generic.List(Of IDataItem5D) Implements IDataSerie5D.Data
            Get
                Return mData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of IDataItem5D))
                mData = value
            End Set
        End Property

        Dim mD_Title As String = "D"
        Public Property D_Title As String Implements IDataSerie5D.D_Title
            Get
                Return mD_Title
            End Get
            Set(ByVal value As String)
                mD_Title = value
            End Set
        End Property

        Dim mE_Title As String = "E"
        Public Property E_Title As String Implements IDataSerie5D.E_Title
            Get
                Return mE_Title
            End Get
            Set(ByVal value As String)
                mE_Title = value
            End Set
        End Property

        Public Property FileName As String Implements IDataSerieBase.FileName
    End Class
End Namespace

