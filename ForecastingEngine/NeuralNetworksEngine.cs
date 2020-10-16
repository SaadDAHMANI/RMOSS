using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using IOOperations.Components;
using EvolutionaryAlgorithms.GreyWolfOptimizer;
using Accord.Neuro;
using Accord.Neuro.Learning;
using ForecastingEngine.Evolutionary_Learning_Algo;

namespace ForecastingEngine
{
	namespace NeuralNetworks
	{
        [Serializable]
        public class NeuralNetworksEngine
    {

            LearningAlgorithmEnum mLearningAlgorithm = LearningAlgorithmEnum.LevenbergMarquardtLearning;
            public LearningAlgorithmEnum LearningAlgorithm
            {
                get { return mLearningAlgorithm; }
                set { mLearningAlgorithm = value; }
            }

            int mLearningAlgorithmParam = 1;
            /// <summary>
            /// The additional parameter of Learning Algorithm.
            /// </summary>
            public int LearningAlgorithmParam
            {
                get { return mLearningAlgorithmParam; }
                set { mLearningAlgorithmParam = value; }
            }

            ActivationFunctionEnum mActivationFunction;
			public ActivationFunctionEnum ActivationFunction
			{
				get { return mActivationFunction; }
				set { mActivationFunction = value ; }
			}

            double mActiveFunction_Alpha = 2;
            /// <summary>
            /// Alpha parameter for activation function (Sigmoid, Bipolar sigmoid, ...etc.)
            /// </summary>
            public double ActiveFunction_Alpha
            {
                get { return mActiveFunction_Alpha; }
                set { mActiveFunction_Alpha = value; }
            }
            
            int IterationCounter = 0;
			public int Iterations
			{
				get { return IterationCounter; }
			}

			int MaxIteration = 2000;
			public int MaxIterationCount
			{
			get { return MaxIteration; }
			set { MaxIteration = value; }
			}

			double FinalTeachingErr=double.NaN ;
			public double FinalTeachingError
			{
				get { return FinalTeachingErr; }
			}
			 
			double mTeachingError = 0.01;
			public double TeachingError
			{
				get { return mTeachingError; }
				set { mTeachingError = value; }
			}

			int mInputsCount = 0;
			public int InputsCount
			{
				get { return mInputsCount; }
				
			}

			int mOuputsCount = 1;
			public int OuputsCount
			{
				get { return mOuputsCount; }
				set
				{
					if (value <1) { mOuputsCount = 1; }
					else { mOuputsCount = value;}
						
				}

			}

			int mSecondLayerNeuronsCount = 1;
			public int SecondLayerNeuronsCount
			{
				get { return mSecondLayerNeuronsCount; }
				set { mSecondLayerNeuronsCount = value; }
			}

			double[][] mTraining_Inputs;
			double [][] Training_Inputs
			{
				get { return mTraining_Inputs; }
				set { mTraining_Inputs = value; }
			}

			double[][] mTraining_Outputs;
			double[][] Training_Outputs
			{
				get { return mTraining_Outputs; }
				set { mTraining_Outputs = value; }
			}

			DataSerieTD mTrainingInputs;
			public DataSerieTD TrainingInputs
			{
				get { return mTrainingInputs; }
				set { mTrainingInputs = value; }
			}
			
			DataSerie1D mTrainingOutputs_DS1;
			public DataSerie1D TrainingOutputs_DS1
			{
				get { return mTrainingOutputs_DS1; }
				set { mTrainingOutputs_DS1 = value; }
			}

			DataSerie1D mLayersStruct = null;
			public DataSerie1D LayersStruct
			{
				get { return mLayersStruct; }
				set { mLayersStruct = value; }
			}

            public string  NetworkStructure
            { get
                {
                    string result = "N/a";
                    if (Equals(LayersStruct, null)) { return result; }
                    if (Equals(LayersStruct, null)) { return result; }

                    int[] networkStruct = GetLayersStruct(LayersStruct);
                    
                    result = mInputsCount.ToString ()+  "-";
                    
                    for (int i=0;  i < LayersStruct.Count; i++)
                    {
                        result += networkStruct[i].ToString() + "-"; 
                    }
                    result += mOuputsCount.ToString();
                    
                    return result ;
                } }
           
			ActivationNetwork Network =null;

            private List<double> BestChart;
            public List<double> Best_Chart
            { get { return BestChart; } }

            private double[] BestWeights;
            public double[] Best_Weights
            { get { return BestWeights; } }

            public void LuanchLearning()
			{
				try
				{
					if (Equals(mTrainingInputs,null)) { return; }
					if (Equals(mTrainingInputs.Data, null)) { return; }

					if (Equals(mTrainingOutputs_DS1, null)) { return; }
					if (Equals(mTrainingOutputs_DS1.Data , null)) { return; }

					//StandardizeData(TrainingInputs,mActivationFunction);
					//StandardizeData(TrainingOutputs_DS1, mActivationFunction);

                    StandardizeData(TrainingInputs);
                    StandardizeData(TrainingOutputs_DS1);

                    mTraining_Inputs = Convert(mTrainingInputs);
					mTraining_Outputs = Convert(mTrainingOutputs_DS1);

					mInputsCount = mTrainingInputs.Data[0].List.Count();

					int[] networkStruct = GetLayersStruct(LayersStruct); 
					if (Equals(networkStruct,null)) { return; }

                    // create neural network
                    // Network = new ActivationNetwork(new SigmoidFunction(1),mInputsCount, networkStruct);
                   //Network = new ActivationNetwork(new BipolarSigmoidFunction(2), mInputsCount, networkStruct);
                    //2  :  two inputs in the network
                    // 2  : two neurons in the first layer
                    // 1  : one neuron in the second layer

                   switch (mActivationFunction)
                    {
                        case ActivationFunctionEnum.SigmoidFunction:
                            Network = new ActivationNetwork(new SigmoidFunction(ActiveFunction_Alpha),  mInputsCount, networkStruct);
                            break;
                        case ActivationFunctionEnum.BipolarSigmoidFunction:
                            Network = new ActivationNetwork(new BipolarSigmoidFunction(ActiveFunction_Alpha), mInputsCount, networkStruct);
                            break;

                        case ActivationFunctionEnum.RectifiedLinearFunction:
                            Network = new ActivationNetwork(new RectifiedLinearFunction(), mInputsCount, networkStruct);
                            break;
                        default:
                            Network = new ActivationNetwork(new SigmoidFunction(ActiveFunction_Alpha), mInputsCount, networkStruct);
                            break;

                    }

                    // create teacher
                    ISupervisedLearning teacher = null;

                    //LevenbergMarquardtLearning teacher = new LevenbergMarquardtLearning(Network);
                    //BackPropagationLearning teacher = new BackPropagationLearning(Network);
                    // EvolutionaryLearning teacher = new EvolutionaryLearning(Network, 25);

                    switch (mLearningAlgorithm)
                    {
                        case LearningAlgorithmEnum.BackPropagationLearning:
                            teacher = new BackPropagationLearning(Network);
                            break;

                        case LearningAlgorithmEnum.LevenbergMarquardtLearning:
                            teacher = new LevenbergMarquardtLearning(Network);
                            break;

                        case LearningAlgorithmEnum.EvolutionaryLearningGA:
                            teacher = new EvolutionaryLearning(Network, EOA_PopulationSize);

                            break;
                        case LearningAlgorithmEnum.RGA_Learning:
                            teacher = new RGA_Learning(Network, EOA_PopulationSize, RGA_MutationPhrequency);
                            break;
                        case LearningAlgorithmEnum.GSA_Learning:
                            teacher = new GSA_Learning(Network, EOA_PopulationSize, MaxIteration, GSA_Go, GSA_Alpha);
                            break;
                        case LearningAlgorithmEnum.GWO_Learning:
                            teacher = new GWO_Learning(Network, EOA_PopulationSize, MaxIteration, GWO_Version, IGWO_uParameter);
                            break;

                        case LearningAlgorithmEnum.HPSOGWO_Learning:
                            teacher = new HPSOGWO_Learning(Network, EOA_PopulationSize, MaxIteration, HPSOGWO_C1, HPSOGWO_C2, HPSOGWO_C3);
                            break;

                        case LearningAlgorithmEnum.mHPSOGWO_Learning:
                            teacher = new HPSOGWO_Learning(Network, EOA_PopulationSize, MaxIteration, HPSOGWO_C1, HPSOGWO_C2, HPSOGWO_C3);
                            break;
                        case LearningAlgorithmEnum.PSOGSA_Learning:
                            teacher = new PSOGSA_Learning(Network, EOA_PopulationSize, MaxIteration, PSOGSA_Go, PSOGSA_Alpha, PSOGSA_C1, PSOGSA_C2);
                            break;

                    }

                    bool needToStop = false;
					IterationCounter = 0;
					double error=double .NaN;
					
					// loop
					while (!needToStop)
					{
						// run epoch of learning procedure
						error  = teacher.RunEpoch(mTraining_Inputs, mTraining_Outputs);

						IterationCounter += 1;
						
						// check error value to see if we need to stop
						// ...
						//Console.WriteLine(error);
						
						if (error <= mTeachingError)
						{
							needToStop = true;
						}

						if (IterationCounter>=MaxIteration ) { needToStop = true; }
					}

					FinalTeachingErr = error;
                    //----------------------------------
                    switch (LearningAlgorithm)
                    {
                        case LearningAlgorithmEnum.GSA_Learning:
                            GSA_Learning gsaL = (GSA_Learning)teacher;
                            this.BestChart = gsaL.Best_Chart;
                            this.BestWeights = gsaL.BestSolution;

                            //Set best weights parameters to the network:
                            SetBestWeightsToTheNetwork();
                            break;

                        case LearningAlgorithmEnum.HPSOGWO_Learning:
                            HPSOGWO_Learning hpgwoL = (HPSOGWO_Learning)teacher;
                            this.BestChart = hpgwoL.Best_Chart;
                            this.BestWeights = hpgwoL.BestSolution;

                            //Set best weights parameters to the network:
                            SetBestWeightsToTheNetwork();
                            break;

                        case LearningAlgorithmEnum.mHPSOGWO_Learning:
                            HPSOGWO_Learning hpsgwoL = (HPSOGWO_Learning)teacher;
                            this.BestChart = hpsgwoL.Best_Chart;
                            this.BestWeights = hpsgwoL.BestSolution;

                            //Set best weights parameters to the network:
                            SetBestWeightsToTheNetwork();
                            break;

                        case LearningAlgorithmEnum.GWO_Learning:
                            GWO_Learning gwoL = (GWO_Learning)teacher;
                            this.BestChart = gwoL.Best_Chart;
                            this.BestWeights = gwoL.BestSolution;

                            //Set best weights parameters to the network:
                            SetBestWeightsToTheNetwork();
                            break;

                        case LearningAlgorithmEnum.RGA_Learning:
                            RGA_Learning rgaL = (RGA_Learning)teacher;
                            this.BestChart = rgaL.Best_Chart;
                            this.BestWeights = rgaL.BestSolution;

                            //Set best weights parameters to the network: 
                            SetBestWeightsToTheNetwork();
                            break;

                        case LearningAlgorithmEnum.PSOGSA_Learning:
                            PSOGSA_Learning psogsaL = (PSOGSA_Learning)teacher;
                            BestChart = psogsaL.Best_Chart;
                            BestWeights = psogsaL.BestSolution;

                            //Set best weights parameters to the network: 
                            SetBestWeightsToTheNetwork();
                            break;
                    }
                }
				catch (Exception ex)
				{ throw ex; }

			}
            /// <summary>
            /// Set the best solution (weights) to the network.
            /// </summary>
            private void SetBestWeightsToTheNetwork()
            {
                if (Equals(Network, null)) { return; }
                if (Equals(BestWeights, null)) { return; }

                //Copy the weights to the network: 
                double[] chromosomeGenes = BestWeights;
                // put best chromosome's value into neural network's weights
                int v = 0;

                for (int i = 0; i < Network.Layers.Length; i++)
                {
                    Layer layer = Network.Layers[i];

                    for (int j = 0; j < layer.Neurons.Length; j++)
                    {
                        ActivationNeuron neuron = layer.Neurons[j] as ActivationNeuron;

                        for (int k = 0; k < neuron.Weights.Length; k++)
                        {
                            neuron.Weights[k] = chromosomeGenes[v++];
                        }
                        neuron.Threshold = chromosomeGenes[v++];
                    }
                }


            }


            public void LuanchLearningOptim()
            {
                try
                {
                    //if (Equals(mTrainingInputs, null)) { return; }
                    //if (Equals(mTrainingInputs.Data, null)) { return; }

                    //if (Equals(mTrainingOutputs_DS1, null)) { return; }
                    //if (Equals(mTrainingOutputs_DS1.Data, null)) { return; }

                    //StandardizeData(TrainingInputs, mActivationFunction);
                    //StandardizeData(TrainingOutputs_DS1, mActivationFunction);

                    //mTraining_Inputs = Convert(mTrainingInputs);
                    //mTraining_Outputs = Convert(mTrainingOutputs_DS1);

                    mInputsCount = mTrainingInputs.Data[0].List.Count();

                    int[] networkStruct = GetLayersStruct(LayersStruct);
                    if (Equals(networkStruct, null)) { return; }

                    // create neural network
                    // Network = new ActivationNetwork(new SigmoidFunction(1),mInputsCount, networkStruct);
                    //Network = new ActivationNetwork(new BipolarSigmoidFunction(2), mInputsCount, networkStruct);
                    //2  :  two inputs in the network
                    // 2  : two neurons in the first layer
                    // 1  : one neuron in the second layer

                    switch (mActivationFunction)
                    {
                        case ActivationFunctionEnum.SigmoidFunction:
                            Network = new ActivationNetwork(new SigmoidFunction(ActiveFunction_Alpha), mInputsCount, networkStruct);
                            break;
                        case ActivationFunctionEnum.BipolarSigmoidFunction:
                            Network = new ActivationNetwork(new BipolarSigmoidFunction(ActiveFunction_Alpha), mInputsCount, networkStruct);
                            break;

                        case ActivationFunctionEnum.LinearFunction:
                            Network = new ActivationNetwork(new RectifiedLinearFunction(), mInputsCount, networkStruct);
                            break;
                        default:
                            Network = new ActivationNetwork(new SigmoidFunction(ActiveFunction_Alpha), mInputsCount, networkStruct);
                            break;

                    }

                    // create teacher
                    LevenbergMarquardtLearning teacher = new LevenbergMarquardtLearning(Network);
                    //BackPropagationLearning teacher = new BackPropagationLearning(Network);
                    // EvolutionaryLearning teacher = new EvolutionaryLearning(Network, 25);


                    bool needToStop = false;
                    IterationCounter = 0;
                    double error = double.NaN;

                    // loop
                    while (!needToStop)
                    {
                        // run epoch of learning procedure
                        error = teacher.RunEpoch(mTraining_Inputs, mTraining_Outputs);

                        IterationCounter += 1;

                        // check error value to see if we need to stop
                        // ...
                        //Console.WriteLine(error);

                        if (error <= mTeachingError)
                        {
                            needToStop = true;
                        }

                        if (IterationCounter >= MaxIteration) { needToStop = true; }
                    }

                    FinalTeachingErr = error;
                }
                catch (Exception ex)
                { throw ex; }

            }
            
            public double[] Compute(double[] input)
			{
				double[] result = null;
				if (object.Equals(Network,null)==false )
				{
					result = Network.Compute(input);

				}
				return result;
			}

			public DataSerie1D Compute( DataSerieTD inputsDs)
			{
				if (Equals(inputsDs,null)) { return null; }
				if (Equals(inputsDs.Data,null)) { return null; }
				if (inputsDs.Data.Count<1) { return null; }

				if (Equals (Network,null)) { return null; }

				StandardizeData(inputsDs, this.mActivationFunction);

				DataSerie1D resultDs = new DataSerie1D();
				
				double[] result = null;

				int jCount =inputsDs.Data[0].List.Count();
				if (jCount < 1) { return null; }

				double[] input = new double[jCount];

				foreach (DataItemTD dItem in inputsDs.Data)
				{
					for(int j=0;j<jCount;j++)
					{
						input[j] = dItem.List[j];
					}

					result = Network.Compute(input);

					resultDs.Add(dItem.Title, result[0]);
				}

			return resultDs;
			}

			#region "Converion"
			private int[] GetLayersStruct(DataSerie1D ds1)
			{
				int iCount = 2;
				int[] result = null;

				if ((object.Equals(ds1, null)) || (object.Equals(ds1.Data,null)))
				{
					result = new int[iCount];
					result[0] = this.InputsCount;
					result[1] = this.OuputsCount;
				}
				else
				{
					iCount = ds1.Data.Count + 1;

					 result = new int[iCount];

					for (int i = 0; i < (iCount-1); i++)
					{
						result[i] =(Int32) Math.Round(ds1.Data[i].X_Value,0);
					}

					result[(iCount - 1)] = OuputsCount;

				}
				return result;
			}

            public static int[] GetLayersStruct(DataSerie1D ds1, int inputCount, int outputCount)
            {
                int iCount = 2;
                int[] result = null;

                if ((object.Equals(ds1, null)) || (object.Equals(ds1.Data, null)))
                {
                    result = new int[iCount];
                    result[0] = inputCount;
                    result[1] = outputCount;
                }
                else
                {
                    iCount = ds1.Data.Count + 1;

                    result = new int[iCount];

                    for (int i = 0; i < (iCount - 1); i++)
                    {
                        result[i] = (Int32)Math.Round(ds1.Data[i].X_Value, 0);
                    }

                    result[(iCount - 1)] = outputCount;

                }
                return result;
            }

            private double[][] Convert(DataSerie1D ds1)
			{

				int iCount = ds1.Data.Count;

				double[][] result = new double[iCount][];

				for (int i = 0; i < iCount; i++)
				{
					result[i] = new double[] { ds1.Data[i].X_Value};
				}

				return result;
			}

			private double[][] Convert( DataSerieTD ds)
			{
				if (Equals(ds, null)){ return null; }

				int iCount = ds.Data.Count;
				if (iCount < 1) { return null; }

				int itmCount =ds.Data [0].List.Count ();

				double[][] result = new double[iCount][];
				try
				{
					for (int i = 0; i < iCount; i++)
					{
						double[] dblList = new double[itmCount];

						for (int j = 0; j < itmCount; j++)
						{
							dblList[j] = ds.Data[i].List[j];

						}
						result[i] = dblList;
					}
				}
				catch (Exception ex ){ throw ex; }

				return result;
			}

			public void StandardizeData(DataSerieTD dseries, ActivationFunctionEnum activeFunction)
			{
				if (Equals(dseries,null)) { return; }
				if (Equals(dseries.Data, null)) { return; }

				bool doStand = false;

				switch (activeFunction)
				{
					case ActivationFunctionEnum.SigmoidFunction:

						foreach (DataItemTD ditem in dseries.Data )
						{
							foreach (double value in ditem.List)
							{
								if ((value <0)||(value >1))
										{
									doStand = true;
									break;
										}
							}
							if (doStand ) { break; }
						}

						if (doStand)
						{
							double[] mins=dseries.Min ;
							double[] maxs = dseries.Max;

							int jCount = mins.Count();

							foreach (DataItemTD ditem in dseries.Data)
							{
								for (int j = 0; j < jCount; j++)
								{
									ditem.List[j] = (ditem.List[j] - mins[j]) / (maxs[j] - mins[j]);
								}
							}
						}

					break;
					case ActivationFunctionEnum.BipolarSigmoidFunction:
						break;
					case ActivationFunctionEnum.RectifiedLinearFunction:
						break;
				}
			}
            /// <summary>
            /// Standardize Data between [0, 1]. 
            /// </summary>
            /// <param name="dseries"></param>
            public void StandardizeData(DataSerie1D dseries)
            {
                if (Equals(dseries, null)) { return; }
                if (Equals(dseries.Data, null)) { return; }

                bool doStand = false;
                foreach (DataItem1D ditem in dseries.Data)
                {
                    if ((ditem.X_Value < 0) || (ditem.X_Value > 1))
                    {
                        doStand = true;
                        break;
                    }
                    if (doStand) { break; }
                }

                if (doStand)
                {
                    double mins = dseries.Min;
                    double maxs = dseries.Max - mins;

                    foreach (DataItem1D ditem in dseries.Data)
                    {
                        ditem.X_Value = (ditem.X_Value - mins) / maxs;
                    }
                }

            }

            /// <summary>
            /// Standardize Data between [0, 1]. 
            /// </summary>
            /// <param name="dseries"></param>
            public void StandardizeData(DataSerieTD dseries)
            {
                if (Equals(dseries, null)) { return; }
                if (Equals(dseries.Data, null)) { return; }

                bool doStand = false;

                foreach (DataItemTD ditem in dseries.Data)
                {
                    foreach (double value in ditem.List)
                    {
                        if ((value < 0) || (value > 1))
                        {
                            doStand = true;
                            break;
                        }
                    }
                    if (doStand) { break; }
                }

                if (doStand)
                {
                    double[] mins = dseries.Min;
                    double[] maxs = dseries.Max;

                    int jCount = mins.Count();

                    foreach (DataItemTD ditem in dseries.Data)
                    {
                        for (int j = 0; j < jCount; j++)
                        {
                            ditem.List[j] = (ditem.List[j] - mins[j]) / (maxs[j] - mins[j]);
                        }
                    }
                }

            }


            public void StandardizeData(DataSerie1D dseries, ActivationFunctionEnum activeFunction)
			{
				if (Equals(dseries, null)) { return; }
				if (Equals(dseries.Data, null)) { return; }

				bool doStand = false;

				switch (activeFunction)
				{
					case ActivationFunctionEnum.SigmoidFunction:

						foreach (DataItem1D ditem in dseries.Data)
						{							
								if ((ditem.X_Value < 0) || (ditem.X_Value > 1))
								{
									doStand = true;
									break;
								}
							if (doStand) { break; }
						}

						if (doStand)
						{
							double mins = dseries.Min;
							double maxs = dseries.Max;

							foreach (DataItem1D ditem in dseries.Data)
							{
								ditem.X_Value = (ditem.X_Value - mins) / (maxs - mins);
							}
						}

						break;
					case ActivationFunctionEnum.BipolarSigmoidFunction:
						break;
					case ActivationFunctionEnum.RectifiedLinearFunction:
						break;
				}
			}
            #endregion

            public bool Save(string fileName)
            {
                bool result = false;
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    formatter.Serialize(stream, this);
                    stream.Close();
                    result = true;
                }
                catch (Exception ex) {throw ex; }
                return result;
            }

            public static NeuralNetworksEngine Load(string fileName)
            {
                NeuralNetworksEngine resultNet = null;
                try
                {
                    if (File.Exists(fileName))
                    {
                        FileStream fileStrem = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        IFormatter formatter = new BinaryFormatter();
                        resultNet = (NeuralNetworksEngine)formatter.Deserialize(fileStrem);
                    }

                }
                catch (Exception ex) { throw ex; }
                return resultNet;
            }
            
            [Category("EOAs Shared Parameters")] public int EOA_PopulationSize { get; set; } = 15;

            #region GSA_Params
            [Category("GSA_Parameters")] public double GSA_Alpha { get; set; } = 20;
            [Category("GSA_Parameters")] public double GSA_Go { get; set; } = 100;
            #endregion

            #region HPSOGWO_Params

            [Category("HPSOGWO_Parameters")] public double HPSOGWO_C1 { get; set; } = 0.5;
            [Category("HPSOGWO_Parameters")] public double HPSOGWO_C2 { get; set; } = 0.5;
            [Category("HPSOGWO_Parameters")] public double HPSOGWO_C3 { get; set; } = 0.5;

            #endregion

            #region RGA_Params
            [Category("RGA_Parameters")] public float RGA_MutationPhrequency { get; set; } = 0.05f;
            #endregion

            #region GWO_Params
            [Category("GWO_Parameters")] public GWOVersionEnum GWO_Version { get; set; } = GWOVersionEnum.StandardGWO;
            [Category("GWO_Parameters")] public double IGWO_uParameter { get; set; } = 1.1;
            #endregion

            #region PSOGSA_Params
            [Category("PSOGSA_Parameters")] public double PSOGSA_C1 { get; set; } = 0.5;
            [Category("PSOGSA_Parameters")] public double PSOGSA_C2 { get; set; } = 1.5;
            [Category("PSOGSA_Parameters")] public double PSOGSA_Alpha { get; set; } = 23;
            [Category("PSOGSA_Parameters")] public double PSOGSA_Go { get; set; } = 1;
            #endregion
        }


    }

	
}
