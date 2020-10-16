
Public Interface IOptimizationEngine
    Property Name As String

    Overloads Property Agents_N As Integer
    Overloads Property YearCount As Integer
    Property Max_Iteration As Integer
    Overloads ReadOnly Property ComputationTime As Long

    REM---------------------------------------------------------------
    Overloads Property Intervalles As List(Of Intervalle)
    Overloads Property OptimizationType As OptimizationTypeEnum
    REM --------------------------------------------------------------
    Overloads Property InflowSerie As IOOperations.Components.DataSerie1D
    Overloads Property Demands As IOOperations.Components.DataSerie1D
    Overloads Property Evaporation As IOOperations.Components.DataSerie1D
    Overloads Property Infiltration As IOOperations.Components.DataSerie1D
    REM---------------------------------------------------------------
    Overloads ReadOnly Property Release As IOOperations.Components.DataSerie1D
    Overloads ReadOnly Property Storage As IOOperations.Components.DataSerie1D
    Overloads ReadOnly Property OverFlow As IOOperations.Components.DataSerie1D

    Overloads ReadOnly Property Best_Solutions As List(Of IOOperations.Components.DataSerie1D)
    Overloads ReadOnly Property Best_Charts As List(Of IOOperations.Components.DataSerie1D)
    Overloads ReadOnly Property Performance As List(Of IOOperations.Components.DataSerie3D)

    REM----------------------------------------------------------------
    Overloads Property Initial_Storage As Double
    Overloads Property Min_Storage As Double
    Overloads Property Max_Storage As Double
    Overloads Property Min_Release As Double
    Overloads Property Max_Release As Double

    REM-----------------------------------------------------------------
    Overloads Sub FitnessObjectiveFunction()
    Overloads Sub Luanch_Optimization()
    Overloads Sub Luanch_Optimisation(syncMode As OptimizationSyncModeEnum)

End Interface
