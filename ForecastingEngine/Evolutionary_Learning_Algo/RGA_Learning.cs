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
using EvolutionaryAlgorithms.GeneticAlgorithm;

namespace ForecastingEngine.Evolutionary_Learning_Algo
{
    public class RGA_Learning : Accord.Neuro.Learning.ISupervisedLearning
    {
        // designed network for training which have to matach inputs and outputs
        private ActivationNetwork network;
        // number of weight in the network to train
        private int numberOfNetworksWeights;

        public List<double> Best_Chart
        {
            get
            {
                if (Equals(RgaOptimizer, null) == false)
                { return RgaOptimizer.BestChart; }
                else { return null; }
            }
        }
        public double[] BestSolution
        {
            get
            {
                if (Equals(RgaOptimizer, null) == false)
                { return RgaOptimizer.BestSolution; }
                else { return null; }
            }
        }

        // genetic population
        private Population population;
        // size of population
        private int populationSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvolutionaryLearning"/> class.
        /// </summary>
        /// 
        /// <param name="activationNetwork">Activation network to be trained.</param>
        /// <param name="populationSize">Size of genetic population.</param>
        /// 
        /// <remarks><para>This version of constructor is used to create genetic population
        /// for searching optimal neural network's weight using default set of parameters, which are:
        /// <list type="bullet">
        /// <item>Selection method - elite;</item>
        /// <item>Crossover rate - 0.75;</item>
        /// <item>Mutation rate - 0.25;</item>
        /// <item>Rate of injection of random chromosomes during selection - 0.20;</item>
        /// <item>Random numbers generator for initializing new chromosome -
        /// <c>UniformGenerator( new Range( -1, 1 ) )</c>;</item>
        /// <item>Random numbers generator used during mutation for genes' multiplication -
        /// <c>ExponentialGenerator( 1 )</c>;</item>
        /// <item>Random numbers generator used during mutation for adding random value to genes -
        /// <c>UniformGenerator( new Range( -0.5f, 0.5f ) )</c>.</item>
        /// </list></para>
        /// 
        /// <para>In order to have full control over the above default parameters, it is possible to
        /// used extended version of constructor, which allows to specify all of the parameters.</para>
        /// </remarks>
        ///
        public RGA_Learning(ActivationNetwork activationNetwork, int populationSize, float mutationFrquency)
        {
            // Check of assumptions during debugging only
            Debug.Assert(activationNetwork != null);
            Debug.Assert(populationSize > 0);

            // networks's parameters
            this.network = activationNetwork;
            this.numberOfNetworksWeights = CalculateNetworkSize(activationNetwork);

            RgaOptimizer = new GAOptimizer();
            // population parameters
            this.populationSize = populationSize;
            //this.chromosomeGenerator = new UniformContinuousDistribution(new Range(-1, 1));
            //this.mutationMultiplierGenerator = new ExponentialDistribution(1);
            //this.mutationAdditionGenerator = new UniformContinuousDistribution(new Range(-0.5f, 0.5f));
            //this.selectionMethod = new EliteSelection();
            //this.crossOverRate = 0.75;
            //this.mutationRate = 0.25;
            //this.randomSelectionRate = 0.2;
            this.RgaOptimizer.InitialPopulation = populationSize;
            this.RgaOptimizer.PopulationLimit = populationSize;
            this.RgaOptimizer.GenomesLenght = numberOfNetworksWeights;
            this.RgaOptimizer.MutationFrequency = mutationFrquency;
            this.RgaOptimizer.CalculateFitnessValues += RgaOptimizer_CalculateFitnessValues;

            List<Intervalle> intervales = new List<Intervalle>();
            for (int i = 0; i < numberOfNetworksWeights; i++)
            {
                intervales.Add(new Intervalle(string.Format("Weight{0}", i), -1, 1));
            }
            this.RgaOptimizer.Intervalles = intervales;
        }

        double[][] Inputs;
        double[][] Outputs;

        private void RgaOptimizer_CalculateFitnessValues(ref List<Genome> genomes)
        {
            // The sum of error
            double SumErr = 0;
            double[] outpts;
            //Evaluation of each chromosome error 
            foreach (Genome chromosome in genomes)
            {
                double[] chromosomeGenes = chromosome.TheArray.ToArray();
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

                //Evaluation of error for each tarining data:
                SumErr = 0;

                for (int k = 0; k < this.Inputs.GetLength(0); k++)
                {
                    outpts = this.network.Compute(this.Inputs[k]);

                    for (int l = 0; l < outpts.Length; l++)
                    {
                        SumErr += Math.Pow((Outputs[k][l] - outpts[l]), 2);
                    }

                }
                chromosome.CurrentFitness = (1 / SumErr);

            }
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


        double ISupervisedLearning.Run(double[] input, double[] output)
        {
            throw new NotImplementedException();
        }

        private GAOptimizer RgaOptimizer;

        double ISupervisedLearning.RunEpoch(double[][] input, double[][] output)
        {

            this.Inputs = input;
            this.Outputs = output;

            //Debug.Assert(input.Length > 0);
            //Debug.Assert(output.Length > 0);
            //Debug.Assert(input.Length == output.Length);
            //Debug.Assert(network.InputsCount == input.Length);

            //// get best chromosome of the population
            //DoubleArrayChromosome chromosome = (DoubleArrayChromosome)population.BestChromosome;
            //double[] chromosomeGenes = chromosome.Value;

            //// put best chromosome's value into neural network's weights
            //int v = 0;

            //for (int i = 0; i < network.Layers.Length; i++)
            //{
            //    Layer layer = network.Layers[i];

            //    for (int j = 0; j < layer.Neurons.Length; j++)
            //    {
            //        ActivationNeuron neuron = layer.Neurons[j] as ActivationNeuron;

            //        for (int k = 0; k < neuron.Weights.Length; k++)
            //        {
            //            neuron.Weights[k] = chromosomeGenes[v++];
            //        }
            //        neuron.Threshold = chromosomeGenes[v++];
            //    }
            //}

            //Debug.Assert(v == numberOfNetworksWeights);

            //return 1.0 / chromosome.Fitness;

            try
            {
                RgaOptimizer.RunEpoch();

                return (1 / RgaOptimizer.Best_Genome.CurrentFitness);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
