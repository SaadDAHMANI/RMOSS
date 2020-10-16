'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:33
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Imports System.Text
Imports RmosEngine.Components
Imports RmosEngine.MarkovChains
Imports RmosEngine.HydComponents

Namespace SDynamicProgramming
    <Description("The new version of the Algorithm.")>
    Public Class SDPAlgorithm

#Region "Constructurs"
        Public Sub New()
        End Sub

        Public Sub New(ByRef theReservoir As Reservoir, ByRef inQSeries As InflowsQSeries, ByRef beneficeB As DataSerie2D)
            Me.mBeneficeSerie = beneficeB
            Me.TheReservoir = theReservoir
            Me.InflowsQ = inQSeries
        End Sub
#End Region

#Region "Properties"
        Dim mOptimizationType As OptimizationTypeEnum = OptimizationTypeEnum.Minimization

        <DescriptionAttribute("Optimization Type : Maximisation or Minimisation."), DisplayNameAttribute("Optimization Type")>
        Public Property OptimizationType As OptimizationTypeEnum
            Get
                Return mOptimizationType
            End Get
            Set(ByVal value As OptimizationTypeEnum)
                mOptimizationType = value
            End Set
        End Property

        Dim mBeneficeSerie As DataSerie2D
        ''' <summary>
        ''' Indicate Benefice B = F(Release R).
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayNameAttribute("Benefice Serie")>
        Public Property BeneficeSerie As DataSerie2D
            Get
                Return mBeneficeSerie
            End Get
            Set(ByVal value As DataSerie2D)
                mBeneficeSerie = value
            End Set
        End Property

        <DisplayNameAttribute("Reservoir"), Category("Data")>
        Public Property TheReservoir As Reservoir

        <DisplayNameAttribute("Inflows [Qi]"), Category("Data")>
        Public Property InflowsQ As InflowsQSeries

        Private Smin As Double = 0.0R
        <DisplayNameAttribute("Min Storage (Smin)"), Category("Constrained")>
        Public ReadOnly Property MinStorage As Double
            Get
                Return Smin
            End Get
        End Property

        Private Smax As Double = 0.0R
        <DisplayNameAttribute("Max Storage (Smax)"), Category("Constrained")>
        Public ReadOnly Property MaxStorage As Double
            Get
                Return Smax
            End Get
        End Property

        Private mYearsDuration As Integer = 2I
        Public Property YearsDuration As Integer
            Get
                Return mYearsDuration
            End Get
            Set(value As Integer)
                If value >= 1 Then
                    mYearsDuration = value
                Else
                    value = 1
                End If
            End Set
        End Property

        Private Rmin As Double = 0.0R
        <DisplayNameAttribute("Min Release (Rmin)"), Category("Constrained")>
        Public ReadOnly Property MinRelease As Double
            Get
                Return Rmin
            End Get
        End Property

        Private Rmax As Double = 0.0R
        <DisplayNameAttribute("Max Release (Rmax)"), Category("Constrained")>
        Public ReadOnly Property MaxRelease As Double
            Get
                Return Rmax
            End Get
        End Property

        Private DeltaS As Double = 0.0R
        <DisplayNameAttribute("Delta Storage (DS)"), Category("Data")>
        Private Property DeltaStorage As Double
            Get
                Return DeltaS
            End Get
            Set(ByVal value As Double)
                DeltaS = value
            End Set
        End Property

        Dim mStorage_S() As Double = Nothing
        Public ReadOnly Property Storage_S() As Double()
            Get
                Return mStorage_S
            End Get
        End Property

        Dim mRef_Inflow_Q() As Double = Nothing
        <DisplayNameAttribute("Inflow [Qi]")>
        Public Property Ref_Inflow_Q As Double()
            Get
                Return mRef_Inflow_Q
            End Get
            Set(ByVal value As Double())
                mRef_Inflow_Q = value
            End Set
        End Property

        Dim mKMaxValue As Integer = 1
        <Category("Results")>
        Public ReadOnly Property KMaxValue As Integer
            Get
                Return mKMaxValue
            End Get
        End Property

        Dim mKILRB_List As List(Of DataSerie5D) = Nothing
        ''' <summary>
        ''' Return Values of K, I, L, Release, Benefice.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property KILRB_List As List(Of DataSerie5D)
            Get
                Return mKILRB_List
            End Get
        End Property

        Dim mTPM_List As List(Of TPMatrix)
        <DisplayNameAttribute("Trans_Matrix List"), DescriptionAttribute("Transition Matrix List (Markov chains).")>
        Public Property TPM_List As List(Of TPMatrix)
            Get
                Return mTPM_List
            End Get
            Set(ByVal value As List(Of TPMatrix))
                mTPM_List = value
            End Set
        End Property

        Dim mProbabilityMatrix As ProbabilityMatrix
        Public Property ProbabilityMatrix As ProbabilityMatrix
            Get
                Return mProbabilityMatrix
            End Get
            Set(ByVal value As ProbabilityMatrix)
                mProbabilityMatrix = value
            End Set
        End Property

        Dim mStageCount As Integer = 2
        ''' <summary>
        ''' Number of stages for SDP Algo.
        ''' </summary>
        <Category("Data")> Public Property StageCount As Integer
            Get
                mStageCount = (mYearsDuration * 12)
                Return mStageCount
            End Get
            Set(ByVal value As Integer)
                mStageCount = value
            End Set
        End Property

        Dim mAnalyseTimeSpan As Long = 0
        ''' <summary>
        ''' The duration of Analyse.
        ''' </summary>
        <DisplayNameAttribute("Analyse Duration (S)"), Category("Results")>
        Public ReadOnly Property AnalyseTimeSpan As Double
            Get
                Return (mAnalyseTimeSpan / 1000)
            End Get
        End Property

        Dim mReportText As System.Text.StringBuilder
        <Browsable(False), Category("Results")> Public ReadOnly Property ReportText As StringBuilder
            Get
                Return mReportText
            End Get
        End Property

        Dim mInfiltrationSerie As DataSerie1D = Nothing
        <Category("Data"), DisplayName("Infiltration")> Public ReadOnly Property InfiltrationSerie As DataSerie1D
            Get
                Return mInfiltrationSerie
            End Get
        End Property

        Dim mEvaporationSerie As DataSerie1D = Nothing
        <Category("Data"), DisplayName("Evaporation")> Public ReadOnly Property EvaporationSerie As DataSerie1D
            Get
                Return mEvaporationSerie
            End Get

        End Property

#End Region

#Region "Public sub/Function"

        Public Sub LuanchAnalyse()
            '1-Verification :

            Dim result As Boolean = Me.Check_Data()

            If result = False Then
                Throw New Exception("Calculation Data incomplete...!")
            End If
            '2-Attribution / Initialisation :

            RaiseEvent InitializationStarted(Me, New EventArgs)
            Me.Rmax = Me.TheReservoir.MaxRelease
            Me.Rmin = Me.TheReservoir.MinRelease
            Me.Smax = Me.TheReservoir.MaxCapacity
            Me.Smin = Me.TheReservoir.MinCapacity
            Me.DeltaS = Me.TheReservoir.DeltaStorage

            If IsNothing(Me.mReportText) Then mReportText = New StringBuilder()

            Me.mTPM_List = Me.InflowsQ.TranstionProbMatrixs

            Initialize()

            RaiseEvent InitializationCompleted(Me, New EventArgs)

            'Analyse time span :
            Dim chrono As New Stopwatch()
            '3-Calculation :
            If mOptimizationType = OptimizationTypeEnum.Maximization Then
                RaiseEvent CalculationStarted(Me, New EventArgs)
                chrono.Start()
                AnalyseForMaximization()
                chrono.Stop()
                mAnalyseTimeSpan = chrono.ElapsedMilliseconds
                RaiseEvent CalculationCompleted(Me, New EventArgs)
            Else
                RaiseEvent CalculationStarted(Me, New EventArgs)
                chrono.Start()
                AnalyseForMinimization()
                chrono.Stop()
                mAnalyseTimeSpan = chrono.ElapsedMilliseconds
                RaiseEvent CalculationCompleted(Me, New EventArgs)
            End If
            chrono = Nothing
        End Sub
#End Region

#Region "Private sub/Function"

        <Obsolete("Change the line code :  B += Get_BeneficeB_For(i, l, n, n)")>
        Private Sub AnalyseForMaximization()

            mReportText.Clear()

            Dim Nmax As Integer = 2
            '----------Calculaton progression EventArgs:
            Dim eSdpOptim As New SdpOptimEventArgs()
            eSdpOptim.StepsCount = Nmax
            '-------------------------------------------
            mReportText.Append("Steps count : ").AppendLine(Nmax.ToString())

            Dim KILRB_Mtx As New DataSerie5D With {.Index = 0, .Name = "Final Stage"}
            Me.mKILRB_List = New List(Of DataSerie5D)

            Dim Bmin As Double = Get_Bmin_value()
            Dim n, t As Integer

            Dim Kmax As Integer = Get_Kmax_value()
            Dim Imax As Integer = Get_Imax_value()

            Dim k, i, l As Integer
            Dim R As Double = 0.0R
            Dim B As Double = 0.0R
            Dim Bstar As Double = 0.0R
            Dim dItem5D As DataItem5D
            Dim Kstar As Integer = 0I
            Dim Istar As Integer = 0I
            Dim Lstar As Integer = 0I
            Dim Rstar As Double = -1.0R
            '--------------Verification-------------
            'Step repeated..
            'If Me.Check_Data = False Then Return
            '------------End verification-----------

            '-----------Stage n=1, t=T -----------
            n = 1I

            mReportText.Append("Step : ").AppendLine(n.ToString())

            ''For each possible level of storage (Sk): 
            For k = 0 To Kmax
                ''For each possible Inflow (Qi):
                For i = 0 To Imax
                    ''For each possible level of storage (Sk+1)
                    B = Bmin
                    Bstar = Bmin
                    For l = 0 To Kmax
                        R = mStorage_S(k) + mRef_Inflow_Q(i) - mStorage_S(l)
                        If R >= 0 Then
                            B = Get_BeneficeB_For(R)
                            If (B > Bstar) Then
                                Kstar = k
                                Istar = i
                                Bstar = B
                                Lstar = l
                                Rstar = R
                            End If
                        End If
                    Next

                    dItem5D = New DataItem5D(mStorage_S(Kstar), mRef_Inflow_Q(Istar), mStorage_S(Lstar), Rstar, Bstar)
                    KILRB_Mtx.Data.Add(dItem5D)

                    'mReportText.AppendLine(dItem5D.ToString())
                    'Debug.Print(dItem5D.ToString())
                Next
            Next

            mKILRB_List.Add(KILRB_Mtx)
            ''
            mReportText.AppendLine(KILRB_Mtx.ToString())
            '---------------
            eSdpOptim.CalculationStep = 1
            RaiseEvent CalculationProgress(Me, eSdpOptim)

            '-----------Stage n=2 to n=(N-1), t=(T-1) to 2 -----------
            For n = 2 To Nmax

                ''
                mReportText.Append("Step : ").AppendLine(n.ToString())

                KILRB_Mtx = New DataSerie5D With {.Index = (n - 1), .Name = String.Format("Satge N°: {0}.", n)}

                ''For each possible level of storage (Sk): 
                For k = 0 To Kmax
                    ''For each possible Inflow (Qi):
                    For i = 0 To Imax
                        B = Bmin
                        Bstar = Bmin

                        ''For each possible level of storage (Sk+1)
                        For l = 0 To Kmax
                            R = mStorage_S(k) + mRef_Inflow_Q(i) - mStorage_S(l)
                            If R >= 0 Then
                                'Benefice for the current stage (k)
                                B = Get_BeneficeB_For(R)
                                B += Get_BeneficeB_For(i, l, n, n)
                                If (B > Bstar) Then
                                    Kstar = k
                                    Istar = i
                                    Bstar = B
                                    Lstar = l
                                    Rstar = R
                                End If
                            End If
                        Next
                        dItem5D = New DataItem5D(mStorage_S(Kstar), mRef_Inflow_Q(Istar), mStorage_S(Lstar), Rstar, Bstar)
                        KILRB_Mtx.Data.Add(dItem5D)

                        ''
                        'mReportText.AppendLine(dItem5D.ToString())
                    Next
                Next

                mKILRB_List.Add(KILRB_Mtx)

                ''
                mReportText.AppendLine(KILRB_Mtx.ToString())

                Debug.Print(mReportText.ToString())

                eSdpOptim.CalculationStep = n

                RaiseEvent CalculationProgress(Me, eSdpOptim)
            Next

        End Sub

        <Obsolete("Revoir les fonction de minimisation")>
        Private Sub AnalyseForMinimization()

            mReportText.Clear()
            '----------Calculaton progression EventArgs:
            Dim eSdpOptim As New SdpOptimEventArgs()
            '-------------------------------------------

            'Year & month conters :
            Dim monthCounter As Integer = 0I
            Dim yearCounter As Integer = (mYearsDuration - 1)

            'Calcuate the loop counter = nbr Years * 12 :
            Dim Nmax As Integer = 12 * (yearCounter + 1)
            eSdpOptim.StepsCount = Nmax
            Me.StageCount = Nmax
            '---------------------------------------------
            mReportText.Append("Steps count : ").AppendLine(Nmax.ToString())
            '-----------------------
            Dim KILRB_Mtx As New DataSerie5D With {.Index = 0, .Name = String.Format("Final Stage : Y_{0}_M_{1}", (yearCounter + 1), (monthCounter + 1))}

            Me.mKILRB_List = New List(Of DataSerie5D)

            Dim Bmax As Double = Get_Bmax_value()
            Dim n As Integer
            Dim B_RealValue As Double = 0R

            Dim Kmax As Integer = Get_Kmax_value()
            Dim Imax As Integer = Get_Imax_value()

            Dim k, i, l As Integer
            Dim R As Double = 0.0R
            Dim B As Double = 0.0R
            Dim kStar As Integer = 0I
            Dim iStar As Integer = 0I
            Dim Bstar As Double = 0.0R
            Dim Lstar As Integer = 0I
            Dim Rstar As Double = -1.0R

            Dim dItem5D As DataItem5D
            '--------------Verification-------------
            If Me.Check_Data = False Then Return
            '------------End verification-----------

            '-----------Stage n=1, t=T -----------
            n = 1I
            '-----Step & Month & year :
            monthCounter = 11I
            mReportText.Append("* Step : ").AppendLine(n.ToString())
            mReportText.Append("** Year : ").AppendLine((yearCounter + 1).ToString())
            mReportText.Append("*** Month : ").AppendLine((monthCounter + 1).ToString())
            '******************************************************************************
            ''For each possible level of storage (Sk): 
            For k = 0 To Kmax
                ''For each possible Inflow (Qi):
                For i = 0 To Imax
                    ''For each possible level of storage (Sk+1)
                    B = Bmax
                    Bstar = Bmax
                    For l = 0 To Kmax
                        'Add Evaporation & infiltration :
                        R = (mStorage_S(k) + mRef_Inflow_Q(i)) - (mStorage_S(l) + Me.mEvaporationSerie.Data(monthCounter).X_value + Me.mInfiltrationSerie.Data(monthCounter).X_value)
                        If R >= 0 Then
                            'Minimisation:
                            B = Get_MinBeneficeB_For(R, yearCounter, monthCounter)
                            'B = Get_MinBeneficeB_For(R, yearCounter, monthCounter, B_RealValue)
                            If (Math.Abs(B) < Bstar) Then
                                Bstar = B
                                Lstar = l
                                Rstar = R
                                kStar = k
                                iStar = i

                            End If
                        End If
                    Next
                    'If R >= 0 Then
                    dItem5D = New DataItem5D(mStorage_S(kStar), mRef_Inflow_Q(iStar), mStorage_S(Lstar), Rstar, Bstar)
                        KILRB_Mtx.Data.Add(dItem5D)
                    'Else
                    '    'A revoir Cette partie ...
                    '    dItem5D = New DataItem5D(mStorage_S(kStar), mRef_Inflow_Q(iStar), (mStorage_S(kStar) + mRef_Inflow_Q(iStar)), 0, -1)
                    '    KILRB_Mtx.Data.Add(dItem5D)
                    'End If

                    'Debug.Print(dItem5D.ToString())
                Next
            Next
            mKILRB_List.Add(KILRB_Mtx)

            'Reduce the last month :
            monthCounter -= 1I
            '********************************:
            mReportText.AppendLine(KILRB_Mtx.ToString())
            eSdpOptim.CalculationStep = 1
            '-------------------------------------------
            '-----------Stage n=2 to n=(N-1), t=(T-1) to 2 -----------
            For n = 2 To Nmax

                '---------Reporting :
                mReportText.Append("* Step : ").AppendLine(n.ToString())
                mReportText.Append("** Year : ").AppendLine((yearCounter + 1).ToString())
                mReportText.Append("*** Month : ").AppendLine((monthCounter + 1).ToString())
                '----------------------------------------------------------------
                KILRB_Mtx = New DataSerie5D With {.Index = (n - 1), .Name = String.Format("Satge N°: {0} Y_{1}_M_{2}", n, (yearCounter + 1), (monthCounter + 1))}

                ''For each possible level of storage (Sk): 
                For k = 0 To Kmax
                    ''For each possible Inflow (Qi):
                    For i = 0 To Imax
                        B = Bmax
                        Bstar = Bmax

                        ''For each possible level of storage (Sk+1)
                        For l = 0 To Kmax
                            R = (mStorage_S(k) + mRef_Inflow_Q(i)) - (mStorage_S(l) + Me.mEvaporationSerie.Data(monthCounter).X_value + Me.mInfiltrationSerie.Data(monthCounter).X_value)

                            If R >= 0 Then

                                'Benefice for the current stage (k), Minimisation:
                                B = Get_MinBeneficeB_For(R, yearCounter, monthCounter)
                                B += Get_BeneficeB_For(i, l, n, monthCounter)

                                If (Math.Abs(B) < Bstar) Then
                                    Bstar = B
                                    Lstar = l
                                    Rstar = R
                                    kStar = k
                                    iStar = i

                                End If
                            End If
                        Next

                        'If R >= 0 Then
                        dItem5D = New DataItem5D(mStorage_S(kStar), mRef_Inflow_Q(iStar), mStorage_S(Lstar), Rstar, Bstar)
                        KILRB_Mtx.Data.Add(dItem5D)
                        'Else
                        ''A revoir Cette partie ... Sds.
                        'dItem5D = New DataItem5D(mStorage_S(kStar), mRef_Inflow_Q(iStar), (mStorage_S(kStar) + mRef_Inflow_Q(iStar)), 0, -1)
                        'KILRB_Mtx.Data.Add(dItem5D)
                        'End If
                    Next
                Next
                mKILRB_List.Add(KILRB_Mtx)

                'Reporting :
                mReportText.AppendLine(KILRB_Mtx.ToString())

                'Refresh the month counter & year counter :
                monthCounter -= 1I
                If monthCounter = -1 Then
                    monthCounter = 11
                    yearCounter -= 1
                End If

                '--------------------------------
                eSdpOptim.CalculationStep = n
                RaiseEvent CalculationProgress(Me, eSdpOptim)
                '--------------------------------
            Next

        End Sub

        Private Sub Initialize()
            'Storage levels :
            Dim kmax As Integer = Get_Kmax_value()
            Dim sLevels(kmax) As Double
            For k As Integer = 0 To kmax
                sLevels(k) = k * DeltaS
            Next
            Me.mStorage_S = sLevels

            'Inflows Q:
            kmax = Me.InflowsQ.ReferenceSerie.Data.Count - 1
            ReDim mRef_Inflow_Q(kmax)
            For i As Integer = 0 To kmax
                mRef_Inflow_Q(i) = Me.InflowsQ.ReferenceSerie.Data(i).Z_value
            Next
            'Demands computation :
            Demands = Get_Demands()

            'Evaporation set:
            mEvaporationSerie = New DataSerie1D() With {.Name = "Evaporations"}
            With mEvaporationSerie
                .Add("Jan", 0.049)
                .Add("Feb", 0.074)
                .Add("Mar", 0.08)
                .Add("Apr", 0.093)
                .Add("Mai", 0.145)
                .Add("Juin", 0.173)
                .Add("Juil", 0.2)
                .Add("Aout", 0.212)
                .Add("Sep", 0.14)
                .Add("Oct", 0.095)
                .Add("Nov", 0.062)
                .Add("Dec", 0.05)
            End With
            'Infiltration :
            Me.mInfiltrationSerie = New DataSerie1D() With {.Name = "Infiltrations"}

            With mInfiltrationSerie
                .Add("Jan", 0.00558)
                .Add("Feb", 0.008)
                .Add("Mar", 0.00658)
                .Add("Apr", 0.00575)
                .Add("Mai", 0.006)
                .Add("Juin", 0.004)
                .Add("Juil", 0.00358)
                .Add("Aout", 0.0035)
                .Add("Sep", 0.0075)
                .Add("Oct", 0.0085)
                .Add("Nov", 0.00583)
                .Add("Dec", 0.006)
            End With
        End Sub

        Private Function Check_Data() As Boolean

            Dim resul As Boolean = True
            'If IsNothing(Me.mBeneficeSerie) Then
            '    Throw New ArgumentNullException("BeneficeSerie")
            '    Return False
            'End If

            'If IsNothing(mBeneficeSerie.Data) Then
            '    Throw New ArgumentNullException("BeneficeSerie.Data")
            '    Return False
            'End If

            'If mBeneficeSerie.Data.Count = 0 Then
            '    Throw New ArgumentNullException("BeneficeSerie.Data")
            '    Return False
            'End If
            If IsNothing(Me.TheReservoir) Then
                Throw New ArgumentNullException("Resevoir is nothing.")
                Return False
            End If

            If IsNothing(InflowsQ) Then
                Throw New ArgumentNullException("Inflows is nothing.")
                Return False
            End If

            'If IsNothing(InflowsQ.TranstionProbMatrixs) Then
            '    Throw New ArgumentNullException("TPMs is nothing.")
            '    Return False
            'End If

            'For Each mtx In InflowsQ.TranstionProbMatrixs
            '    If IsNothing(mtx) Then
            '        Throw New ArgumentNullException("TPMs is nothing.")
            '        Return False
            '    End If
            '    If IsNothing(mtx.Matrix) Then
            '        Throw New ArgumentNullException("TPMs is nothing.")
            '        Return False
            '    End If
            '    If mtx.Dimension < 1 Then
            '        Throw New ArgumentNullException("TPMs is nothing.")
            '        Return False
            '    End If
            'Next

            If IsNothing(InflowsQ.ReferenceSerie) Then
                Throw New ArgumentNullException("ReferenceSerie is nothing.")
                Return False
            End If

            If IsNothing(InflowsQ.ReferenceSerie.Data) Then
                Throw New ArgumentNullException("ReferenceSerie Data is nothing.")
                Return False
            End If

            If InflowsQ.ReferenceSerie.Data.Count < 1 Then
                Throw New ArgumentNullException("No ReferenceSerie data.")
                Return False
            End If

            Return resul
        End Function

        ''' <summary>
        ''' Return the minimum of Benefice value in the benfice serie.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get_Bmin_value() As Double
            Dim result As Double = 0.0R

            For Each itm In Me.mBeneficeSerie.Data
                If itm.Y_value < result Then
                    result = itm.Y_value
                End If
            Next
            result -= 10
            Return result
        End Function

        Private Function Get_Bmax_value() As Double
            'Dim result As Double = Double.MaxValue
            ''For Each itm In Me.mBeneficeSerie.Data
            ''    If itm.Y_value > result Then
            ''        result = itm.Y_value
            ''    End If
            ''Next
            ''result += 10

            'Return th max double value possible :
            Return Double.MaxValue
        End Function

        <Obsolete("Revoir le resultat")> Private Function Get_Kmax_value() As Integer

            If DeltaS < 0 Then
                DeltaS = Math.Abs(DeltaS)
            End If

            Dim result As Double
            result = (Me.Smax - Me.Smin) / Me.DeltaS
            result = Math.Truncate(result)

            Me.mKMaxValue = CInt(result)
            Return Me.mKMaxValue

        End Function

        <Obsolete("Revoir le resultat")> Private Function Get_Imax_value() As Integer
            If IsNothing(mRef_Inflow_Q) Then
                Return -1
            Else
                Return (Me.mRef_Inflow_Q.Length - 1)
            End If
        End Function

#Region "Private Function"

        Private Demands(,) As Double = Nothing
        <Category("Data")>
        Public ReadOnly Property Demandes As Double(,)
            Get
                Return Demands
            End Get
        End Property
        <Obsolete("Revoir les fuites et l'evaporation ici.")>
        Private Function Get_Demands() As Double(,)
            'the year and month counters :
            Dim yCount As Integer = Me.mYearsDuration
            yCount -= 1I
            Dim mCount As Integer = 11

            Dim demands(yCount, mCount) As Double
            Try
                'Dotation :
                Const dot As Double = (0.15 * 365) * (10 ^ -6)
                'Populatin :
                Const pop As Double = 153619.0R
                'Taux d'acroissement :
                Const taux As Double = 1.03R
                'Volume for irrigation :
                Const vIrr As Double = 9.0R
                Const vInd As Double = 1.517R
                Const vAepOr As Double = 33.0R

                Dim pr1() As Double = {7.93, 7.93, 7.93, 7.93, 8.89, 8.89, 8.89, 8.89, 8.89, 7.93, 7.93, 7.93}
                Dim pr2() As Double = {0.11, 0.11, 0.33, 7.33, 13.33, 20.33, 24.44, 22.56, 10, 1.11, 0.22, 0.11}
                Dim d1, d3, dm1, dm2, dm3, dm4, sum As Double

                For i As Integer = 0 To yCount

                    d1 = dot * pop * Math.Pow(taux, i)
                    d3 = (((1.5 * i) / 100) + 1) * vInd

                    For j As Integer = 0 To mCount
                        dm1 = d1 * (pr1(j) * 0.01)
                        dm2 = vIrr * (pr2(j) * 0.01)
                        dm3 = (d3 / 12)
                        dm4 = vAepOr * (pr1(j) * 0.01)
                        sum = (dm1 + dm2 + dm3 + dm4)
                        demands(i, j) = Math.Round(sum, 6)
                    Next
                Next

            Catch ex As Exception
                Throw ex
            End Try
            Return demands
        End Function
#End Region
        Private Function Get_BeneficeB_For(ByRef release_R As Double) As Double
            For Each itm In mBeneficeSerie.Data
                If itm.X_value = release_R Then
                    Return itm.Y_value
                End If
            Next

            'Interpolation lineaire :
            Dim result As Double = 0.0R
            Dim iCount As Integer = mBeneficeSerie.Data.Count - 2
            For i As Integer = 0 To iCount
                If release_R > mBeneficeSerie.Data(i).X_value Then
                    If release_R < mBeneficeSerie.Data((i + 1)).X_value Then
                        result = (release_R - mBeneficeSerie.Data(i).X_value) / (mBeneficeSerie.Data((i + 1)).X_value - mBeneficeSerie.Data(i).X_value)
                        result = result * (mBeneficeSerie.Data((i + 1)).Y_value - mBeneficeSerie.Data(i).Y_value)
                        result = result + mBeneficeSerie.Data(i).Y_value
                        Exit For
                    End If
                End If
            Next
            Return result
        End Function

        'Private Function Get_BeneficeB_For(ByRef release_R As Double) As Double
        '    Dim result As Double = 10 ^ 6.0R
        '    Try
        '        If IsNothing(Demands) Then Throw New Exception("No Demands series...")



        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        '    Return result
        'End Function

        <Obsolete("The new functio for Benefit calculation.")>
        Private Function Get_MinBeneficeB_For(ByRef release_R As Double, ByVal year As Integer, ByVal month As Integer) As Double
            Dim result As Double = -1
            Try
                If IsNothing(Demands) Then Throw New Exception("No Demands series...")
                Dim yCount As Integer = Me.Demands.GetLength(0) - 1
                Dim yIndex = yCount - year

                result = (release_R - Me.Demands(yIndex, month))
                'result *= result
                result = Math.Abs(result)

            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        <Obsolete("The new functio for Benefit calculation.")>
        Private Function Get_MinBeneficeB_For(ByRef release_R As Double, ByVal year As Integer, ByVal month As Integer, ByRef BrealValue As Double) As Double
            Dim result As Double = -1
            Try
                If IsNothing(Demands) Then Throw New Exception("No Demands series...")
                Dim yCount As Integer = Me.Demands.GetLength(0) - 1
                Dim yIndex = yCount - year

                result = (release_R - Me.Demands(yIndex, month))
                BrealValue = result

                ' Debug.Print("B Real value = {0}", BrealValue.ToString())

                result = Math.Abs(result)

            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        <Obsolete("Change this to fix probability...!!!!")>
        Private Function Get_BeneficeB_For(ByVal i As Integer, ByRef l As Integer, ByRef currentStage As Integer, ByRef month As Integer) As Double
            Dim resultB As Double = 0.0R
            Dim Bstar As Double = 0.0R
            Dim monthIndex As Integer = 0I

            Dim previous_kilrb As DataSerie5D = Me.mKILRB_List((currentStage - 2))
            Dim probaMatrix As ProbabilityMatrix = Me.ProbabilityMatrix  'Dim previous_TPM As TPMatrix = Me.mTPM_List((currentStage - 2))

            Dim imax As Integer = (probaMatrix.Matrix.GetLength(0) - 1)
            monthIndex = month - 1

            If monthIndex < 0 Then
                monthIndex = 11
            End If

            For j As Integer = 0 To imax
                For Each itm As DataItem5D In previous_kilrb.Data
                    If itm.K_Value = l Then
                        If itm.I_Value = j Then
                            Bstar = itm.B_Value
                            Exit For
                        End If
                    End If
                Next

                resultB += (probaMatrix.Matrix(j, monthIndex) * Bstar) '(previous_TPM.Matrix(i, j) * Bstar)
                'Debug.Print(String.Format("j={0} , monthIndex= {1}", i, monthIndex))
                'Debug.Print(ProbabilityMatrix.Matrix(j, monthIndex).ToString())
                'Debug.Print(Bstar.ToString())
                'Debug.Print("----------------------------------")
            Next

            'Dim jmax As Integer = (probaMatrix.Matrix.GetLength(0) - 1)
            ''Debug.Print("Jmax = {0}.", jmax)
            'For j As Integer = 0 To jmax
            '    For Each itm As DataItem5D In previous_kilrb.Data
            '        If itm.K_Value = l Then
            '            If itm.I_Value = j Then
            '                Bstar = itm.B_Value
            '                Exit For
            '            End If
            '        End If
            '    Next
            '    resultB += (previous_TPM.Matrix(i, j) * Bstar)
            'Next
            Return resultB
        End Function

        '<Obsolete("Change this to fix probability...!!!!")>
        'Private Function Get_BeneficeB_For(ByVal i As Integer, ByRef l As Integer, ByRef currentStage As Integer) As Double
        '    Dim resultB As Double = 0.0R
        '    Dim Bstar As Double = 0.0R

        '    Dim previous_kilrb As DataSerie5D = Me.mKILRB_List((currentStage - 2))
        '    Dim previous_TPM As TPMatrix = Me.mTPM_List((currentStage - 2))
        '    Dim jmax As Integer = previous_TPM.Dimension
        '    'Debug.Print("Jmax = {0}.", jmax)
        '    For j As Integer = 0 To jmax
        '        For Each itm As DataItem5D In previous_kilrb.Data
        '            If itm.K_Value = l Then
        '                If itm.I_Value = j Then
        '                    Bstar = itm.B_Value
        '                    Exit For
        '                End If
        '            End If
        '        Next
        '        resultB += (previous_TPM.Matrix(i, j) * Bstar)
        '    Next
        '    Return resultB
        'End Function

#End Region

#Region "Events"
        Public Event CalculationStarted(ByVal sender As Object, ByVal e As EventArgs)
        Public Event CalculationCompleted(ByVal sender As Object, ByVal e As EventArgs)
        Public Event CalculationProgress(ByVal sender As Object, ByVal e As SdpOptimEventArgs)
        Public Event InitializationStarted(ByVal sender As Object, ByVal e As EventArgs)
        Public Event InitializationCompleted(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Class
    Public Enum OptimizationTypeEnum
        Maximization = 0
        Minimization = 1
    End Enum
End Namespace