using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Accord;
using Accord.Neuro;
using Accord.Genetic;
using Accord.Math.Random;
using Accord.Neuro.Learning;
using Accord.Statistics.Distributions.Univariate;
using EvolutionaryAlgorithms;
using EvolutionaryAlgorithms.GreyWolfOptimizer;


namespace ForecastingEngine.Evolutionary_Learning_Algo
{

    public class HPSOGWO_Learning : ISupervisedLearning
    {
        // designed network for training which have to matach inputs and outputs
        private ActivationNetwork network;
        // number of weight in the network to train
        private int numberOfNetworksWeights;

        // size of population
        private int PopulationSize;

        double[][] Inputs;
        double[][] Outputs;

        int MaxIteration = 3;
        public int MaxIterationCount
        {
            get { return MaxIteration; }
            set { MaxIteration = Math.Max(value, 0); }
        }

        public List<double> Best_Chart
        {
            get
            {
                if (Equals(Optimizer, null) == false)
                { return Optimizer.BestChart; }
                else { return null; }
            }
        }

        public double[] BestSolution
        {
            get
            {
                if (Equals(Optimizer, null) == false)
                { return Optimizer.BestSolution; }
                else { return null; }
            }
        }

        private HPSOGWOptimizer Optimizer;

        public HPSOGWO_Learning(ActivationNetwork activationNetwork, int populationSize, int maxIterations, double c1, double c2, double c3)
        {
            MaxIteration = maxIterations;
            this.PopulationSize = populationSize;
            // Check of assumptions during debugging only
            Debug.Assert(activationNetwork != null);
            Debug.Assert(populationSize > 0);

            // networks's parameters
            this.network = activationNetwork;
            this.numberOfNetworksWeights = CalculateNetworkSize(activationNetwork);

            // population parameters
            Optimizer = new HPSOGWOptimizer(numberOfNetworksWeights, populationSize, maxIterations);
            Optimizer.C_1 = c1;
            Optimizer.C_2 = c2;
            Optimizer.C_3 = c3;

            Optimizer.OptimizationType = OptimizationTypeEnum.Minimization;

            // The objective function
            Optimizer.ObjectiveFunctionComputation += Optimizer_ObjectiveFunctionComputation; ;

            // Setting intervalles in [-1,1] 
            List<Intervalle> intervales = new List<Intervalle>();
            for (int i = 0; i < numberOfNetworksWeights; i++)
            {
                intervales.Add(new Intervalle(string.Format("Weight{0}", i), -1, 1));
            }
            this.Optimizer.Intervalles = intervales;
        }

        // Create and initialize genetic population
        private int CalculateNetworkSize(ActivationNetwork activationNetwork)
        {
            // caclculate total amount of weight in neural network
            int networkSize = 0;

            for (int i = 0; i < network.Layers.Length; i++)
            {
                Layer layer = network.Layers[i];

                for (int j = 0; j < layer.Neurons.Length; j++)
                {
                    // sum all weights and threshold
                    networkSize += layer.Neurons[j].Weights.Length + 1;
                }
            }

            return networkSize;
        }

        private void Optimizer_ObjectiveFunctionComputation(ref double[] positions, ref double fitnessValue)
        {
            // The sum of error
            double SumErr = 0;
            double[] outpts;
            //Evaluation of each chromosome error 
            double[] chromosomeGenes = positions;
            // put best chromosome's value into neural network's weights
            int v = 0;

            for (int i = 0; i < network.Layers.Length; i++)
            {
                Layer layer = network.Layers[i];

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

            //Evaluation of error for each tarining data : sum(e)= sum[(Yi-Si)^2]:

            for (int k = 0; k < this.Inputs.GetLength(0); k++)
            {
                outpts = this.network.Compute(this.Inputs[k]);

                for (int l = 0; l < outpts.Length; l++)
                {
                    SumErr += Math.Pow((Outputs[k][l] - outpts[l]), 2);
                }
            }

            fitnessValue = SumErr;
        }

        public double Run(double[] input, double[] output)
        {
            throw new NotImplementedException();
        }

        public double RunEpoch(double[][] input, double[][] output)
        {
            this.Inputs = input;
            this.Outputs = output;

            try
            {
                Optimizer.RunEpoch();

                return Optimizer.CurrentBestFitness;
            }
            catch (Exception ex) { throw ex; }
        }
    }

}
