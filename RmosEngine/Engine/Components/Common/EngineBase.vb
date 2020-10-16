Imports IOOperations.Components
Imports System.ComponentModel
Imports RmosEngine

Public Class OptimizationEngineBase
    Implements IOptimizationEngine

    Protected Friend BackThread As BackgroundWorker

    Public Sub New()
        BackThread = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
        'AddHandler BackThread.DoWork, AddressOf Async_DoWork
        AddHandler BackThread.ProgressChanged, AddressOf Async_ProgressChanged
        AddHandler BackThread.RunWorkerCompleted, AddressOf Async_RunWorkerCompleted
    End Sub

    Public Sub New(ByRef theReservoir As HydComponents.Reservoir)
        Me.New()
        Me.Reservoir = theReservoir
    End Sub

    Dim mAgents_N As Integer = 20
    <Category("Parameters")>
    Public Overridable Property Agents_N As Integer Implements IOptimizationEngine.Agents_N
        Get
            Return mAgents_N
        End Get
        Set(value As Integer)
            mAgents_N = value
        End Set
    End Property

    Dim mComputationTime As Long = 0
    <Category("Results")>
    Public Overridable ReadOnly Property ComputationTime As Long Implements IOptimizationEngine.ComputationTime
        Get
            Return mComputationTime
        End Get
    End Property

    ''' <summary>
    ''' The Reservoir to Optimize.
    ''' </summary>
    ''' <returns></returns>
    Public Property Reservoir As HydComponents.Reservoir = Nothing

    Dim mDemands As DataSerie1D
    <Category("Data Sereies")>
    Public Overridable Property Demands As DataSerie1D Implements IOptimizationEngine.Demands
        Get
            Return mDemands
        End Get
        Set(value As DataSerie1D)
            mDemands = value
        End Set
    End Property

    Dim mEvaporation As DataSerie1D
    <Category("Data Sereies")>
    Public Overridable Property Evaporation As DataSerie1D Implements IOptimizationEngine.Evaporation
        Get
            Return mEvaporation
        End Get
        Set(value As DataSerie1D)
            mEvaporation = value
        End Set
    End Property

    Dim mInfiltration As DataSerie1D
    <Category("Data Sereies")>
    Public Overridable Property Infiltration As DataSerie1D Implements IOptimizationEngine.Infiltration
        Get
            Return mInfiltration
        End Get
        Set(value As DataSerie1D)
            mInfiltration = value
        End Set
    End Property

    Dim mInflowSerie As DataSerie1D
    <Category("Data Sereies")>
    Public Overridable Property InflowSerie As DataSerie1D Implements IOptimizationEngine.InflowSerie
        Get
            Return mInflowSerie
        End Get
        Set(value As DataSerie1D)
            mInflowSerie = value
        End Set
    End Property

    Dim mInitial_Storage As Double = 118.0R
    <Category("Data")>
    Public Overridable Property Initial_Storage As Double Implements IOptimizationEngine.Initial_Storage
        Get
            Return mInitial_Storage
        End Get
        Set(value As Double)
            mInitial_Storage = value
        End Set
    End Property

    'Dim mIntervalle As RmosEngine.Intervalle
    '<Category("Data"), Browsable(False)>
    'Public Overridable Property Intervalle As RmosEngine.Intervalle Implements IOptimizationEngine.Intervalle
    '    Get
    '        Return mIntervalle
    '    End Get
    '    Set(value As RmosEngine.Intervalle)
    '        mIntervalle = value
    '    End Set
    'End Property

    Dim mMax_Iteration As Integer = 100I
    <Category("Parameters")>
    Public Overridable Property Max_Iteration As Integer Implements IOptimizationEngine.Max_Iteration
        Get
            Return mMax_Iteration
        End Get
        Set(value As Integer)
            If value > 0 Then
                mMax_Iteration = value
            End If
        End Set
    End Property

    Dim mMax_Release As Double = 10.0R
    <Category("Data")>
    Public Overridable Property Max_Release As Double Implements IOptimizationEngine.Max_Release
        Get
            Return mMax_Release
        End Get
        Set(value As Double)
            If value >= 0 Then
                mMax_Release = value
            End If
        End Set
    End Property

    Dim mMax_Storage As Double = 170.0R
    <Category("Data")>
    Public Overridable Property Max_Storage As Double Implements IOptimizationEngine.Max_Storage
        Get
            Return mMax_Storage
        End Get
        Set(value As Double)
            If value >= 0 Then
                mMax_Storage = value
            End If
        End Set
    End Property

    Dim mMin_Release As Double = 0R
    <Category("Data")>
    Public Overridable Property Min_Release As Double Implements IOptimizationEngine.Min_Release
        Get
            Return mMin_Release
        End Get
        Set(value As Double)
            If value >= 0 Then
                mMin_Release = value
            End If
        End Set
    End Property

    Dim mMin_Storage As Double = 23.0R
    <Category("Data")>
    Public Overridable Property Min_Storage As Double Implements IOptimizationEngine.Min_Storage
        Get
            Return mMin_Storage
        End Get
        Set(value As Double)
            If value >= 0 Then
                mMin_Storage = value
            End If
        End Set
    End Property

    Dim mOptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Minimization
    <Category("Parameters")>
    Public Overridable Property OptimizationType As OptimizationTypeEnum Implements IOptimizationEngine.OptimizationType
        Get
            Return mOptimizationType
        End Get
        Set(value As OptimizationTypeEnum)
            mOptimizationType = value
        End Set
    End Property

    <Category("Results")>
    Public Overridable ReadOnly Property OverFlow As DataSerie1D Implements IOptimizationEngine.OverFlow
        Get
            Return Nothing
        End Get
    End Property

    <Category("Results")>
    Public Overridable ReadOnly Property Release As DataSerie1D Implements IOptimizationEngine.Release
        Get
            Return Nothing
        End Get
    End Property

    <Category("Results")>
    Public Overridable ReadOnly Property Storage As DataSerie1D Implements IOptimizationEngine.Storage
        Get
            Return Nothing
        End Get
    End Property

    Dim mYearCount As Integer = 1
    <Category("Data")>
    Public Overridable Property YearCount As Integer Implements IOptimizationEngine.YearCount
        Get
            Return mYearCount
        End Get
        Set(value As Integer)
            If mYearCount > 0 Then
                mYearCount = value
            End If
        End Set
    End Property

    Dim mTotalTimePeriod As Integer = 1
    <Category("Data"), DisplayName("Total Time Period")> Public Overridable Property TotalTimePeriod As Integer
        Get
            Return mTotalTimePeriod
        End Get
        Set(value As Integer)
            If value > 0 Then
                mTotalTimePeriod = value
            End If
        End Set
    End Property

    Public Overridable ReadOnly Property Best_Solutions As List(Of DataSerie1D) Implements IOptimizationEngine.Best_Solutions
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property Best_Charts As List(Of DataSerie1D) Implements IOptimizationEngine.Best_Charts
        Get
            Return Nothing
        End Get
    End Property

    Dim mName As String = "EngineBase"

    Public Overridable Property Name As String Implements IOptimizationEngine.Name
        Get
            Return "EngineBase"
        End Get
        Set(value As String)
            mName = value
        End Set
    End Property

    Dim mIntervalles As List(Of Intervalle) = Nothing
    Public Overridable Property Intervalles As List(Of Intervalle) Implements IOptimizationEngine.Intervalles
        Get
            Return mIntervalles
        End Get
        Set(value As List(Of Intervalle))
            mIntervalles = value
        End Set
    End Property

    Public Overridable ReadOnly Property Performance As List(Of DataSerie3D) Implements IOptimizationEngine.Performance
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable Sub Luanch_Optimization() Implements IOptimizationEngine.Luanch_Optimization
        Throw New NotImplementedException()
    End Sub

    Public Overridable Sub FitnessObjectiveFunction() Implements IOptimizationEngine.FitnessObjectiveFunction
        Throw New NotImplementedException()
    End Sub

    Public Overridable Sub Reset()
        Me.Demands = Nothing
        Me.Evaporation = Nothing
        Me.Infiltration = Nothing
        Me.InflowSerie = Nothing
        Me.Intervalles = Nothing
        Me.Reservoir = Nothing
    End Sub

#Region "Events"

    Public Event ProgressionChanged(sender As Object, e As AsyncOptimEventArgs)
    Public Event ProcessFinished(sender As Object, e As AsyncOptimEventArgs)
#End Region

#Region "Threading"
    Private CurrentBestSolution() As Double = Nothing
    Protected Friend eArg As New AsyncOptimEventArgs()

    Public Property AsynchronState As AsynchStateEnum

    Private Sub Async_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        eArg.CurrentSate = CurrentBestSolution
        eArg.ProgressPercentage = e.ProgressPercentage
        RaiseEvent ProgressionChanged(Me, eArg)
    End Sub

    Private Sub Async_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        If e.Cancelled Then
            AsynchronState = AsynchStateEnum.Cancelled
        Else
            AsynchronState = AsynchStateEnum.Finiched
        End If
        RaiseEvent ProcessFinished(Me, eArg)
    End Sub

    Public Overridable Sub Luanch_Optimisation(syncMode As OptimizationSyncModeEnum) Implements IOptimizationEngine.Luanch_Optimisation
        Throw New NotImplementedException()
    End Sub

#End Region
End Class
