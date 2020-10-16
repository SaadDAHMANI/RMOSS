'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:32
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Imports IOOperations.Components
'Imports RmosEngine.MarkovChains

Namespace HydComponents
    Public Class Reservoir
    	
    	Dim mName As String = "Reservoir - 1"
        ''' <summary>
        ''' The name of reservoir.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value

            End Set
        End Property

        Dim mDescription As String = "/"
        ''' <summary>
        ''' The description of the reservoir.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Description As String
            Get
                Return mDescription
            End Get
            Set(ByVal value As String)
                mDescription = value
            End Set
        End Property

        ''' <summary>
        ''' The full file path (path+name).
        ''' </summary>
        ''' <remarks></remarks>
        Public FilePath As String

        Dim mMinCapacity As Double = 0.0R
        ''' <summary>
        ''' The minimum capacity of reservoir Smin.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MinCapacity As Double
            Get
                Return mMinCapacity
            End Get
            Set(ByVal value As Double)
                Dim oldValue As Double = mMinCapacity

                If value >= 0 Then
                    If value >= mMaxCapacity Then
                        'Throw New Exception("Reservoir Min Capacity can not be > Reservoir Max Capacity.")

                        mMinCapacity = mMaxCapacity
                        RaiseEvent MinCapacityChanged(Me, New ReserverEventArgs(oldValue))

                    Else
                        mMinCapacity = value
                        RaiseEvent MinCapacityChanged(Me, New ReserverEventArgs(oldValue))
                    End If
                Else
                    mMinCapacity = 0
                    RaiseEvent MinCapacityChanged(Me, New ReserverEventArgs(oldValue))
                End If

            End Set
        End Property

        Dim mMaxCapacity As Double = 10.0R
        ''' <summary>
        ''' The maximum capacity of reservoir Smax.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MaxCapacity As Double
            Get
                Return mMaxCapacity
            End Get
            Set(ByVal value As Double)
                If value >= 0 Then
                    Dim eValue As New ReserverEventArgs(mMaxCapacity)
                    mMaxCapacity = value
                    RaiseEvent MaxCapacityChanged(Me, eValue)
                Else
                    Throw New Exception ("Max Reservoir Capacity must be >0.")
            	End If
            End Set
        End Property

        Private mMinRelease As Double = 0.0R
        ''' <summary>
        ''' The minimum release for the reservoir Rmin.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MinRelease As Double
            Get
                Return mMinRelease
            End Get
            Set(value As Double)
                mMinRelease = value
            End Set
        End Property

        Private mMaxRelease As Double = 0.0R
        ''' <summary>
        ''' The maximum release for the reservoir Rmax.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MaxRelease As Double
            Get
                Return mMaxRelease
            End Get
            Set(value As Double)
                mMaxRelease = value
            End Set
        End Property

        Private mDeltaStorage As Double = 1.0R
        ''' <summary>
        ''' The descritisation DS of storage. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DeltaStorage As Double
            Get
                Return mDeltaStorage
            End Get
            Set(ByVal value As Double)
                If value > 0 Then
                    Dim eValue As New ReserverEventArgs(mDeltaStorage)
                    mDeltaStorage = value
                    RaiseEvent DeltaStorageChanged(Me, eValue)
                Else
                    mDeltaStorage = 1.0R
                    Throw New Exception("Delta (DS) must be >0.")
                End If
            End Set
        End Property

        Public ReadOnly Property LevelsCount As Integer
            Get
                Dim lCount As Integer = CInt(mMaxCapacity / mDeltaStorage)
                Return lCount
            End Get

        End Property


        Dim mElevationVolume_Curve As DataSerie2D = Nothing
        ''' <summary>
        ''' The (H-V) Curve (X = H m); (Y = V m3).
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("The H-V curve of reservoir")> _
        Public Property ElevationVolume_Curve As DataSerie2D
            Get
                Return mElevationVolume_Curve
            End Get
            Set(value As DataSerie2D)
                mElevationVolume_Curve = value
            End Set
        End Property

        Dim mElevationArea_Curve As DataSerie2D = Nothing
        ''' <summary>
        ''' The (H-V) Curve (X = H m); (Y = S m2).
        ''' </summary>
        ''' <returns></returns>
        Public Property ElevationArea_Curve As DataSerie2D
            Get
                Return mElevationArea_Curve
            End Get
            Set(value As DataSerie2D)
                mElevationArea_Curve = value
            End Set
        End Property

        Dim mInfiltrationRates As DataSerie2D = Nothing
        <Category("Data"), DisplayName("Infiltration")> Public Property InfiltrationRates As DataSerie2D
            Get
                Return mInfiltrationRates
            End Get
            Set(value As DataSerie2D)
                mInfiltrationRates = value
            End Set
        End Property

        Dim mEvaporationRates As DataSerie2D = Nothing
        <Category("Data"), DisplayName("Evaporation")> Public Property EvaporationRates As DataSerie2D
            Get
                Return mEvaporationRates
            End Get
            Set(value As DataSerie2D)
                mEvaporationRates = value
            End Set
        End Property

        Public Function GetVolumeOf(ByVal areaT As Double, ByVal areaTp1 As Double, ByVal monthIndx As Integer) As Double
            Dim resultV As Double = 0

            Return resultV
        End Function

#Region "Evaporation loss"
        Dim sds As Integer = 0
        Dim S0, S1, S2, Sx, A1, A2, Ax, H1, H2, Hx, Ev, Qin, Qout, DeltaQ As Double
        Const Err As Double = (10 ^ -2)

        Public Function GetEvaporationOf(ByVal month As MonthsEnum, ByVal St As Double, ByVal Qt As Double, ByVal ParamArray outQ() As Double) As Double
            If IsNothing(mEvaporationRates) Then Return 0R

            Ev = 0
            Qin = St + Qt

            Qout = 0
            For j = 0 To (outQ.Count() - 1)
                Qout += outQ(j)
            Next
            '---------------------------------------------------
            DeltaQ = Err + 10
            S0 = Qin - Qout

            A1 = GetAreaOf(GetElevationOf(St))
            sds = 0
            While (DeltaQ > Err)

                Ax = GetAreaOf(GetElevationOf(S0))

                Ev = 0.00005 * mEvaporationRates.Data(month).Y_Value * (A1 + Ax)

                Sx = (Qin - Qout) - Ev

                DeltaQ = Math.Abs((S0 - Sx))
                S0 = Sx
                sds += 1I
            End While

            Return Ev

        End Function

        Public Function GetElevationOf(ByVal Sx As Double) As Double
            If Sx >= mElevationVolume_Curve.Max_Y Then Return mElevationVolume_Curve.Max_X
            If Sx <= mElevationVolume_Curve.Min_Y Then Return mElevationVolume_Curve.Min_X

            For i As Integer = 0 To (mElevationVolume_Curve.Data.Count - 1)
                If mElevationVolume_Curve.Data(i).Y_Value >= Sx Then
                    S1 = mElevationVolume_Curve.Data(i - 1).Y_Value
                    S2 = mElevationVolume_Curve.Data(i).Y_Value
                    H1 = mElevationVolume_Curve.Data(i - 1).X_Value
                    H2 = mElevationVolume_Curve.Data(i).X_Value
                    Exit For
                End If
            Next
            '-----------------------------------------------------
            Hx = (((H2 - H1) / (S2 - S1)) * (Sx - S1)) + H1
            Return Hx
        End Function

        Public Function GetAreaOf(ByVal Hx As Double) As Double
            If Hx >= mElevationArea_Curve.Max_X Then Return mElevationArea_Curve.Max_Y
            If Hx <= mElevationArea_Curve.Min_X Then Return mElevationArea_Curve.Min_Y

            For i = 0 To (mElevationArea_Curve.Data.Count - 1)
                If mElevationArea_Curve.Data(i).X_Value >= Hx Then
                    H1 = mElevationArea_Curve.Data((i - 1)).X_Value
                    H2 = mElevationArea_Curve.Data(i).X_Value
                    A1 = mElevationArea_Curve.Data((i - 1)).Y_Value
                    A2 = mElevationArea_Curve.Data(i).Y_Value
                    Exit For
                End If
            Next
            Ax = (((A2 - A1) / (H2 - H1)) * (Hx - H1)) + A1
            Return Ax

        End Function

#End Region

#Region "Infiltration loss"
        Public Function GetInfiltrationOf(ByVal Sx As Double) As Double
            Return 0.033
            If Equals(mInfiltrationRates, Nothing) Then Return 0R

            If Sx >= mInfiltrationRates.Max_X Then Return mInfiltrationRates.Max_Y
            If Sx <= mInfiltrationRates.Min_X Then Return mInfiltrationRates.Min_Y

            For i As Integer = 0 To (mInfiltrationRates.Data.Count - 1)
                If mInfiltrationRates.Data(i).X_Value >= Sx Then
                    S1 = mInfiltrationRates.Data(i - 1).X_Value
                    S2 = mInfiltrationRates.Data(i).X_Value
                    H1 = mInfiltrationRates.Data(i - 1).Y_Value
                    H2 = mInfiltrationRates.Data(i).Y_Value
                    Exit For
                End If
            Next
            '-----------------------------------------------------
            Hx = (((H2 - H1) / (S2 - S1)) * (Sx - S1)) + H1
            Return Hx
        End Function
#End Region


#Region "Events"
        Public Event DeltaStorageChanged(ByVal sender As Object, ByVal e As ReserverEventArgs)
        Public Event MaxCapacityChanged(ByVal sender As Object, ByVal e As ReserverEventArgs)
        Public Event MinCapacityChanged(ByVal sender As Object, ByVal e As ReserverEventArgs)

#End Region

        Public Property Inflow As DataSerie1D
        Public Property Downstream As DataSerie1D

        Public Function ConvertToIOReservoir() As IOOperations.Components.IOReservoir
            Dim ioR As New IOOperations.Components.IOReservoir()
            Dim Qs As New IOOperations.Components.DataSerie1D()
            Dim Ds As New IOOperations.Components.DataSerie1D()
            Dim Evs As New IOOperations.Components.DataSerie2D()
            Dim Infilts As New IOOperations.Components.DataSerie2D()
            Dim HS As New IOOperations.Components.DataSerie2D()
            Dim HV As New IOOperations.Components.DataSerie2D()

            With ioR
                .Name = Name
                .Description = Description
                .MaxCapacity = MaxCapacity
                .MinCapacity = MinCapacity
                .MaxRelease = MaxRelease
                .MinCapacity = MinRelease
                .Downstream = Downstream
                .Elevation_Area = ElevationArea_Curve
                .Elevation_Volume = ElevationVolume_Curve
                .Evaporation = EvaporationRates
                .Infiltration = InfiltrationRates
                .Inflow = Inflow
            End With
            Return ioR
        End Function

        Public Shared Function ConvertFrom(ByRef IoReservoir As IOOperations.Components.IOReservoir) As Reservoir
            Dim oneRes As Reservoir = Nothing
            If IsNothing(IoReservoir) Then Return Nothing
            oneRes = New Reservoir()
            With oneRes
                .Name = IoReservoir.Name
                .Description = IoReservoir.Description
                .MinCapacity = IoReservoir.MinCapacity
                .MaxCapacity = IoReservoir.MaxCapacity
                .MinRelease = IoReservoir.MinRelease
                .MaxRelease = IoReservoir.MaxRelease
                .ElevationArea_Curve = IoReservoir.Elevation_Area
                .ElevationVolume_Curve = IoReservoir.Elevation_Volume
                .EvaporationRates = IoReservoir.Evaporation
                .InfiltrationRates = IoReservoir.Infiltration
                .Inflow = IoReservoir.Inflow
                .Downstream = IoReservoir.Downstream
            End With

            Return oneRes
        End Function
    End Class

    Public Class ReserverEventArgs
        Inherits EventArgs
        Public Sub New()
        End Sub

        Public Sub New(ByVal oldValue As Double)
            m_OldValue = oldValue
        End Sub

        Private m_OldValue As Double
        Public Property OldValue As Double
            Get
                Return m_OldValue
            End Get
            Set(value As Double)
                m_OldValue = value
            End Set
        End Property

    End Class


    Public Enum MonthsEnum
        Jan = 4
        Feb = 5
        Mar = 6
        Apr = 7
        Mai = 8
        Jun = 9
        Jul = 10
        Aug = 11
        Sep = 0
        Oct = 1
        Nov = 2
        Dec = 3
    End Enum

End Namespace
