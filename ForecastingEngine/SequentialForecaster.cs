using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOOperations.Components;

namespace ForecastingEngine
{
	public class SequentialForecaster
	{
		public SequentialForecaster(NeuralNetworks.NeuralNetworksEngine aNNEngine)
		{
			NeuralNetEngine = aNNEngine;
		}

		private NeuralNetworks.NeuralNetworksEngine NeuralNetEngine= null;

		public NeuralNetworks.NeuralNetworksEngine NeuralNetsEngine
		{ get { return NeuralNetEngine; } } 

		private int mFutureHorizon = 12;
		public int FutureHorizon
		{
			get { return mFutureHorizon; }
			set
			{
				if (value <1) { mFutureHorizon = 1; }
				else { mFutureHorizon = value;}
				
			}
		}

		public DataSerie1D Forecast(DataSerie1D initialSerie, int futureCount)
		{
			DataSerie1D result = new DataSerie1D();
			int neuralDimension = NeuralNetEngine.InputsCount;
			int dataDimension = initialSerie.Count;
			try
			{
				if (neuralDimension != dataDimension) { throw new Exception("Err in input data."); }

				double[] inputs = new double[neuralDimension];
				double resultvalue = 0;

				for (int k=0; k<neuralDimension;k++)
				{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value); }

				for (int i=0;i<futureCount;i++)
				{
					for(int j=0; j<neuralDimension;j++)
					{ inputs[j] = result.Data[(j+i)].X_Value; }

					resultvalue = NeuralNetEngine.Compute(inputs)[0];
					result.Add(i.ToString (),resultvalue);
				}


			}
			catch (Exception ex)
			{ throw ex; }
						
			return result;
		}

		public DataSerie1D Forecast(DataSerie1D initialSerie)
		{
			int futureCount = FutureHorizon;
			DataSerie1D result = new DataSerie1D();
			int neuralDimension = NeuralNetEngine.InputsCount;
			int dataDimension = initialSerie.Count;
			try
			{
				if (neuralDimension != dataDimension) { throw new Exception("Err in input data."); }

				double[] inputs = new double[neuralDimension];
				double resultvalue = 0;

				for (int k = 0; k < neuralDimension; k++)
				{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value); }

				for (int i = 0; i < futureCount; i++)
				{
					for (int j = 0; j < neuralDimension; j++)
					{ inputs[j] = result.Data[(j + i)].X_Value; }

					resultvalue = NeuralNetEngine.Compute(inputs)[0];
					result.Add(i.ToString(), resultvalue);
				}


			}
			catch (Exception ex)
			{ throw ex; }

			return result;
		}

        public DataSerie1D Forecast2(DataSerie1D initialSerie)
        {
            int futureCount = FutureHorizon;
            DataSerie1D result = new DataSerie1D();
            int neuralDimension = NeuralNetEngine.InputsCount;
            int dataDimension = 1;
            int dataCount =initialSerie .Count;
            try
            {
                if (neuralDimension != dataDimension) { throw new Exception("Err in input data."); }

                double[] inputs = new double[neuralDimension];
                double resultvalue = 0;

                //for (int k = 0; k < neuralDimension; k++)
                //{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value, -100); }

                for (int i = 0; i < futureCount; i++)
                {
                    for (int j = 0; j < neuralDimension; j++)
                    { inputs[j] = initialSerie.Data[i].X_Value; }

                    resultvalue = NeuralNetEngine.Compute(inputs)[0];
                    result.Add (initialSerie.Data[i].Title , resultvalue);
                }
                
            }
            catch (Exception ex)
            { throw ex; }

            return result;
        }


    }

	public class SequentialForecasterEO
	{
		public SequentialForecasterEO(NeuralNetworks.NeuralNetworksEngineEO aNNEngine)
		{
			NeuralNetEngine = aNNEngine;
		}

		private NeuralNetworks.NeuralNetworksEngineEO NeuralNetEngine = null;

		public NeuralNetworks.NeuralNetworksEngineEO NeuralNetsEngine
		{ get { return NeuralNetEngine; }
		  set { NeuralNetEngine = value;}
		}

		private int mFutureHorizon = 12;
		public int FutureHorizon
		{
			get { return mFutureHorizon; }
			set
			{
				if (value < 1) { mFutureHorizon = 1; }
				else { mFutureHorizon = value; }

			}
		}

		public DataSerie1D Forecast(DataSerie1D initialSerie, int futureCount)
		{
			DataSerie1D result = new DataSerie1D();
			if (Equals(NeuralNetEngine, null)) { return null; }
			int neuralDimension = NeuralNetEngine.InputsCount;
			int dataDimension = initialSerie.Count;
			try
			{
				if (neuralDimension != dataDimension) { throw new Exception("Err in input data."); }

				double[] inputs = new double[neuralDimension];
				double resultvalue = 0;

				for (int k = 0; k < neuralDimension; k++)
				{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value); }

				for (int i = 0; i < futureCount; i++)
				{
					for (int j = 0; j < neuralDimension; j++)
					{ inputs[j] = result.Data[(j + i)].X_Value; }

					resultvalue = NeuralNetEngine.Compute(inputs)[0];
					result.Add(i.ToString(), resultvalue);
				}


			}
			catch (Exception ex)
			{ throw ex; }

			return result;
		}

		public DataSerie1D Forecast(DataSerie1D initialSerie)
		{
			int futureCount = FutureHorizon;
			DataSerie1D result = new DataSerie1D();
			if (Equals(NeuralNetEngine, null)) { return null;}
			int neuralDimension = NeuralNetEngine.InputsCount;
			int dataDimension = initialSerie.Count;
			try
			{
				if (neuralDimension > dataDimension) { throw new Exception("Err in input data."); }

				for (int k = (dataDimension-neuralDimension); k < dataDimension; k++)
				{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value); }

				double[] inputs = new double[neuralDimension];
				double resultvalue = 0;

				
				for (int i = 0; i < futureCount; i++)
				{
					for (int j = 0; j < neuralDimension; j++)
					{ inputs[j] = result.Data[(j + i)].X_Value; }

					resultvalue = NeuralNetEngine.Compute(inputs)[0];
					result.Add(i.ToString(), resultvalue);
				}


			}
			catch (Exception ex)
			{ throw ex; }

			return result;
		}

		public DataSerie1D Forecast(DataSerie1D initialSerie, bool addMonths, int startingMonth)
		{

			int futureCount = FutureHorizon;
			DataSerie1D result = new DataSerie1D();
			if (Equals(NeuralNetEngine, null)) { return null; }
			int neuralDimension = NeuralNetEngine.InputsCount-1;
			int dataDimension = initialSerie.Count;

			if (addMonths)
			{ 			
				try
			{
				if (neuralDimension > dataDimension) { throw new Exception("Err in input data."); }

				for (int k = (dataDimension - neuralDimension); k < dataDimension; k++)
				{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value); }

				//------------------------------------
				int monthIndex = startingMonth + neuralDimension;
				double monthStand;								
				//------------------------------------

				double[] inputs = new double[neuralDimension+1];
				double resultvalue = 0;
				
				for (int i = 0; i < futureCount; i++)
				{
					for (int j = 0; j < neuralDimension; j++)
					{inputs[j] = result.Data[(j + i)].X_Value; }
					//------------------------------------------------
					monthStand = (GetMonthIndex(monthIndex) * 0.9) / 12;
					inputs[neuralDimension] = monthStand;
					monthIndex += 1;
					//------------------------------------------------
					resultvalue = NeuralNetEngine.Compute(inputs)[0];
					result.Add(i.ToString(), resultvalue);
				}
			}
			catch (Exception ex)
			{ throw ex; }
			}
			else
			{ result = Forecast(initialSerie); }
			return result;
		}

		private int GetMonthIndex(int value)
		{
			int monthIndex = 0;
			int xx = Math.DivRem(value, 12, out monthIndex);
			if (monthIndex == 0) { monthIndex = 12; }
			return monthIndex;
		}

		public DataSerie1D Forecast2(DataSerie1D initialSerie)
		{
			int futureCount = FutureHorizon;
			DataSerie1D result = new DataSerie1D();
			if (Equals(NeuralNetEngine, null)) {return null;}
			int neuralDimension = NeuralNetEngine.InputsCount;
			int dataDimension = initialSerie.Count;
			try
			{
				if (neuralDimension != dataDimension) { throw new Exception("Err in input data."); }

				double[] inputs = new double[neuralDimension];
				double resultvalue = 0;

				//for (int k = 0; k < neuralDimension; k++)
				//{ result.Add(initialSerie.Data[k].Title, initialSerie.Data[k].X_Value, -100); }

				for (int i = 0; i < futureCount; i++)
				{
					for (int j = 0; j < neuralDimension; j++)
					{ inputs[j] = initialSerie.Data[(i+j)].X_Value; }

					resultvalue = NeuralNetEngine.Compute(inputs)[0];
					result.Add(initialSerie.Data[i].Title, resultvalue);
				}

			}
			catch (Exception ex)
			{ throw ex; }

			return result;
		}


	}
}
