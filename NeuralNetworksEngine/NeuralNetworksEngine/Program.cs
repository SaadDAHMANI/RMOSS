using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Neuro;
using Accord.Neuro.ActivationFunctions;
using Accord.Neuro.Layers;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using Accord.Neuro.Neurons;
using Accord.Neuro.Visualization;

namespace NeuralNetworksApp
{
	class Program
	{
		static void Main(string[] args)
		{
			
			TestAnn();
			Console.ReadKey();
		}

		static void TestAnn()
		{
			// initialize input and output values
			double[][] input = {
			new double[] { 0.5, 0 }, new double[] { 0.2, 0.1 }, new double[] { 0.4, 0.5 }, new double[] { 0.3, 0.7 },
			new double[] { 0.75, 0.25 }, new double[] { 0.3, 0.1 }, new double[] { 0.2, 0.5 }, new double[] { 0.2, 0.6 }};

			double[][] output = { new double[] { 0.5 }, new double[] { 0.3 }, new double[] { 0.9 }, new double[] { 1 },
			new double[] { 1 }, new double[] { 0.4 }, new double[] { 0.7 }, new double[] { 0.8 } };

			int[] numbers = new int[] { 3, 3, 2, 1 };

			// create neural network
			ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(1),2,numbers);
			//2  :  two inputs in the network
			// 2  : two neurons in the first layer
			// 1  : one neuron in the second layer

			
			// create teacher
			LevenbergMarquardtLearning teacher = new LevenbergMarquardtLearning(network);

			bool needToStop = false;

			// loop
			while (!needToStop)
			{
				// run epoch of learning procedure
				double error = teacher.RunEpoch(input, output);

				// check error value to see if we need to stop
				// ...
				//Console.WriteLine(error);
				if (error <= 0.001)
				{
					needToStop = true;
				}
			}

			Write(network.Output, "network.Output");
			int index = 0;
			foreach (Layer layr in network.Layers )
			{
				index += 1;
				Write(layr.Output, string.Format("network.Layers> [{0}] <.Output",index ));
			}
				

			//Write(network.Layers[1].Output, "network.Layers[1].Output");
			//Write(network.Layers[1].Neurons[0].Weights, "network.Layers[1].Neurons[0].Weights");

			double[] testData = { 0.25, 0.25 };

			Write(network.Compute(testData), "testData");

			Console.WriteLine("-------------------------------------");

			double[][] inputtest = { new double[] { 0.1, 0 }, new double[] { 0.1, 0.1 }, new double[] { 0.1, 0.2 }, new double[] { 0.2, 0.2}};

			for (int j =0; j<4; j++)
			{
				Write(network.Compute(inputtest[j]), "result of inputtest");
			}

		}

		static void TestAnn2()
		{
			// Here we will be creating a neural network to process 3-valued input
			// vectors and classify them into 4-possible classes. We will be using
			// a single hidden layer with 5 hidden neurons to accomplish this task.
			// 
			int numberOfInputs = 3;
			int numberOfClasses = 4;
			int hiddenNeurons = 5;

			// Those are the input vectors and their expected class labels
			// that we expect our network to learn.
			// 
			double[][] input =	{
	new double[] { -1, -1, -1 }, // 0
    new double[] { -1,  1, -1 }, // 1
    new double[] {  1, -1, -1 }, // 1
    new double[] {  1,  1, -1 }, // 0
    new double[] { -1, -1,  1 }, // 2
    new double[] { -1,  1,  1 }, // 3
    new double[] {  1, -1,  1 }, // 3
    new double[] {  1,  1,  1 }  // 2
 };

			int[] labels = {0,1,1,0,2,3,3,2};

			// In order to perform multi-class classification, we have to select a 
			// decision strategy in order to be able to interpret neural network 
			// outputs as labels. For this, we will be expanding our 4 possible class
			// labels into 4-dimensional output vectors where one single dimension 
			// corresponding to a label will contain the value +1 and -1 otherwise.

			double[][] outputs = Accord.Statistics.Tools.Expand(labels, numberOfClasses, -1, 1);

			// Next we can proceed to create our network
			var function = new BipolarSigmoidFunction(2);
			var network = new ActivationNetwork(function, numberOfInputs, hiddenNeurons,numberOfClasses);

			// Heuristically randomize the network
			new NguyenWidrow(network).Randomize();

			// Create the learning algorithm
			var teacher = new LevenbergMarquardtLearning(network);

			// Teach the network for 10 iterations:
			double error = Double.PositiveInfinity;
			for (int i = 0; i < 10; i++) error = teacher.RunEpoch(input, outputs);

			// At this point, the network should be able to 
			// perfectly classify the training input points.

			for (int i = 0; i < input.Length; i++)
			{
				int answer;
				double[] output = network.Compute(input[i]);
				//double response = output.Max(out answer);

				int expected = labels[i];

				// at this point, the variables 'answer' and
				// 'expected' should contain the same value.

			}


		}

		static void Write(double[] data, string name)
		{
			Console.WriteLine(string.Format ("Data of : {0}",name) );

			int iCount = data.Count();
			for (int i =0; i<iCount;i++)
			{
				Console.WriteLine(data[i].ToString());
			}

			Console.WriteLine();
		}
	}
}
