
Public Interface IEvolutionaryAlgorithm
    Sub RunEpoch()
    Sub LuanchComputation()

    Property Intervalles As List(Of Intervalle)
    Property MaxIterations As Integer
    Property OptimizationType As OptimizationTypeEnum

    ReadOnly Property BestChart As List(Of Double)
    ReadOnly Property WorstChart As List(Of Double)
    ReadOnly Property MeanChart As List(Of Double)
    ReadOnly Property Solution_Fitness As Dictionary(Of String, Double)
End Interface
