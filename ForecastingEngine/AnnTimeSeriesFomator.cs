using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOOperations.Components;

namespace ForecastingEngine
{
public class AnnTimeSeriesFomator
    {

        public AnnTimeSeriesFomator()
        {
            //SpecificInputModel = new DataSerie1D();
            SpecificInputModel.Add("In-1", 1);
            SpecificInputModel.Add("In-2", 2);
            SpecificInputModel.Add("In-3", 6);
        }
        public DataSerie1D Data;
        double TrainingRate = 70;
        public double  Training_Rate
        { get { return TrainingRate; }
         set { TrainingRate = Math.Max(value,0); }
        }
        
       int TrainingCount = 0;
        public int Training_Count
        { get { return TrainingCount; } }

        int TestingCount = 0;
        public int Testing_Count
        { get { return TestingCount; } }

        int mAnnInputLayerCount = 3;
        public int AnnInputLayerCount
        {
            get { return mAnnInputLayerCount;}
            set {
                mAnnInputLayerCount = Math.Max(1, value);
               // mAnnInputLayerCount = Math.Min(mAnnInputLayerCount, TrainingCount);
            }
        }

        public AnnTimeSeriesFomatEnum Format { get; set; } = AnnTimeSeriesFomatEnum.SequentielInputs;

        DataSerieTD mTrainingInputs;
        public DataSerieTD Training_Inputs
        { get { return mTrainingInputs;} }
        
        DataSerie1D mTrainingOutputs;
        public DataSerie1D Training_Outputs
        { get { return mTrainingOutputs; } }
                
        DataSerieTD mTestingInputs;
        public DataSerieTD Testing_Inputs
        { get {return mTestingInputs;} }

        DataSerie1D mTestingOutputs;
        public DataSerie1D Testing_Outputs
        { get { return mTestingOutputs; } }

        public DataSerie1D SpecificInputModel { get; set; } = new DataSerie1D();
        public void Formate()
         { 
                    switch(Format)
            {
                case AnnTimeSeriesFomatEnum.SequentielInputs:
                    FormateDefault();
                    break;
                case AnnTimeSeriesFomatEnum.SequentielInputsWithTimeindex:
                    Formate(true, 9);
                    break;
                case AnnTimeSeriesFomatEnum.SpecificInputModel:
                    Formate(SpecificInputModel);
                    break;
                default:
                    FormateDefault();
                    break;
            }

        }

        /// <summary>
        /// Formate Training and Testing (inputs-outputs) by specific time series indexes. 
        /// </summary>
        /// <param name="annInputModel"> The ANN input model </param>
        private void Formate(DataSerie1D annInputModel)
        { 
        try
            {
                if (object.Equals(Data, null)) { return; }
                if (object.Equals(Data.Data, null)) { return; }
                int dataCount = Data.Count;
                if (dataCount < 1) { return; }

                if (object.Equals(annInputModel, null)) { throw new Exception("No time series indexes pattern are found."); }
                if (object.Equals(annInputModel.Data, null)) { throw new Exception("No time series indexes pattern are found."); }
                if (annInputModel.Count<1) { throw new Exception("No input model is specified."); }
               
                if (annInputModel.Max > dataCount) { throw new Exception("Index great then data serie count."); }

                TrainingCount = (int)((TrainingRate * dataCount) / 100);
                TestingCount = (dataCount - TrainingCount);

                mTrainingInputs = new DataSerieTD() { Name = "Training inputs" };
                mTrainingOutputs = new DataSerie1D() { Name = "Training outputs" };

                int annInputCount = annInputModel.Count;

               int[] indexes = new int[annInputCount]; 

                for (int i=0; i < annInputCount; i++)
                {
                    if (annInputModel.Data[i].X_Value>TrainingCount || annInputModel.Data[i].X_Value > TestingCount) 
                    { throw new Exception("ANN Input indexes must be lower than Training and Testing data serie lenght."); }
                    indexes[i] = (int)(annInputModel.Data[i].X_Value - 1);
                }

                int indexMax = (indexes.Max() - 1);

                for (int i = 0; i < (TrainingCount - indexMax); i++)
                {
                    double[] qj = new double[annInputCount];

                    for (int j = 0; j < annInputCount; j++)
                    {
                        qj[j] = Data.Data[(i + indexes[j])].X_Value;
                    }
                    mTrainingInputs.Add(i.ToString(), qj);
                    mTrainingOutputs.Add(i.ToString(), Data.Data[(i + indexMax)].X_Value);
                }

                mTestingInputs = new DataSerieTD() { Name = "Testing inputs" };
                mTestingOutputs = new DataSerie1D() { Name = "Testing outputs" };
                int k = TrainingCount;

                for (int i = 0; i < (TestingCount - indexMax); i++)
                {
                    double[] qj = new double[annInputCount];
                    for (int j = 0; j < annInputCount; j++)
                    {
                        qj[j] = Data.Data[(k + i + indexes[j])].X_Value;
                    }
                    mTestingInputs.Add((i + k).ToString(), qj);
                    mTestingOutputs.Add((i + k).ToString(), Data.Data[(k + i + indexMax)].X_Value);
                }

            }
            catch (Exception ex) { throw ex; }
        } 
        public void FormateDefault()
        {
            if (object.Equals(Data, null)) { return ; }
            if (object.Equals(Data.Data, null)) { return ; }
            int dataCount = Data.Count;
            if (dataCount < 1) { return; }

            TrainingCount = (int)((TrainingRate * dataCount) / 100);
            TestingCount = (dataCount - TrainingCount);

            mTrainingInputs = new DataSerieTD() { Name ="Training inputs" };
            mTrainingOutputs = new DataSerie1D() { Name = "Training outputs" };
            

            for (int i = 0; i < (TrainingCount - mAnnInputLayerCount ); i++)
            {
                double[] qj = new double[mAnnInputLayerCount];

                for (int j = 0; j < mAnnInputLayerCount; j++)
                {
                    qj[j] = Data.Data[(i + j)].X_Value;
                }
                mTrainingInputs.Add(i.ToString(), qj);
                mTrainingOutputs.Add(i.ToString(), Data.Data[(i + mAnnInputLayerCount)].X_Value);
            }

            mTestingInputs = new DataSerieTD() { Name = "Testing inputs" }; 
            mTestingOutputs = new DataSerie1D() { Name = "Testing outputs" };
            int k = TrainingCount;

            for (int i = 0; i < (TestingCount - mAnnInputLayerCount); i++)
            {
                double[] qj = new double[mAnnInputLayerCount];
                for (int j = 0; j < mAnnInputLayerCount; j++)
                {
                    qj[j] = Data.Data[(k+ i + j)].X_Value;
                }
                mTestingInputs.Add((i + k).ToString(), qj);
                mTestingOutputs.Add((i + k).ToString(), Data.Data[(k+i + mAnnInputLayerCount)].X_Value);
            }
         
            }

        
        public void Formate(bool includeMonths, int startingMonth)
        {

           if (includeMonths==false)
            {
                Formate();
            }
            else
            {
                if (object.Equals(Data, null)) { return; }
                if (object.Equals(Data.Data, null)) { return; }
                int dataCount = Data.Count;
                if (dataCount < 1) { return; }

                TrainingCount = (int)((TrainingRate * dataCount) / 100);
                TestingCount = (dataCount - TrainingCount);

                mTrainingInputs = new DataSerieTD() { Name = "Training inputs" };
                mTrainingOutputs = new DataSerie1D() { Name = "Training outputs" };

                int monthIndex = startingMonth+ mAnnInputLayerCount;

                double monthStand = 0;

                for (int i = 0; i < (TrainingCount - mAnnInputLayerCount); i++)
                {
                    double[] qj = new double[mAnnInputLayerCount+1];

                    for (int j = 0; j < mAnnInputLayerCount; j++)
                    {
                        qj[j] = Data.Data[(i + j)].X_Value;
                    }

                    //------------------------------------
                    monthStand = (GetMonthIndex(monthIndex) * 0.9) / 12;
                    qj[mAnnInputLayerCount] = monthStand;
                    monthIndex += 1;
                    //------------------------------------
                    mTrainingInputs.Add(i.ToString(), qj);
                    mTrainingOutputs.Add(i.ToString(), Data.Data[(i + mAnnInputLayerCount)].X_Value);
                }

                mTestingInputs = new DataSerieTD() { Name = "Testing inputs" };
                
                mTestingOutputs = new DataSerie1D() { Name = "Testing outputs" };

                int k = TrainingCount;

                for (int i = 0; i < (TestingCount - mAnnInputLayerCount); i++)
                {
                    double[] qj = new double[mAnnInputLayerCount+1];

                    for (int j = 0; j < mAnnInputLayerCount; j++)
                    {
                        qj[j] = Data.Data[(k + i + j)].X_Value;
                    }
                    //------------------------------------
                    monthStand = (GetMonthIndex(monthIndex) * 0.9) / 12;
                    qj[mAnnInputLayerCount] = monthStand;
                    monthIndex += 1;
                    //------------------------------------

                    mTestingInputs.Add((i + k).ToString(), qj);
                    mTestingOutputs.Add((i + k).ToString(), Data.Data[(k + i + mAnnInputLayerCount)].X_Value);
                }
            }


        }

        private int GetMonthIndex(int value)
        {
            int monthIndex = 0;
            int xx = Math.DivRem(value, 12, out monthIndex);
            if (monthIndex == 0) { monthIndex = 12;}
            return monthIndex;
        }
    
        public double [][] Training_In
        { 
            get { 
                if(object.Equals(mTrainingInputs , null)) { Formate(); }
                return Convert(this.mTrainingInputs);
            } 
        }
        public double[][] Training_Out
        {
            get
            {
                if (object.Equals(mTrainingOutputs, null)) { Formate(); }
                return Convert(mTrainingOutputs);
            }
        }

        public double [][] Testing_In
        {
            get
            {
                if (object.Equals(mTestingInputs , null)) { Formate(); }
                return Convert(mTestingInputs);
            }
        }
        public double[][] Testing_Out
        {
            get
            {
                if (object.Equals(mTestingOutputs, null)) { Formate(); }
                return Convert(mTestingOutputs);
            }
        }

        private double[][] Convert(DataSerie1D ds1)
        {
            if (object.Equals(ds1, null)) { return null; }
            if (object.Equals(ds1.Data, null)) { return null; }

            int iCount = ds1.Data.Count;

            double[][] result = new double[iCount][];

            for (int i = 0; i < iCount; i++)
            {
                result[i] = new double[] { ds1.Data[i].X_Value };
            }

            return result;
        }
        private double[][] Convert(DataSerieTD ds)
        {
            if (object.Equals(ds, null)) { return null; }
            if (object.Equals(ds.Data, null)) { return null; }
         
            int iCount = ds.Data.Count;
            if (iCount < 1) { return null; }

            int itmCount = ds.Data[0].List.Count();

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
            catch (Exception ex) { throw ex; }

            return result;
        }
    
    }

    public enum AnnTimeSeriesFomatEnum
    {
        SequentielInputs=0,
        SequentielInputsWithTimeindex = 1,
        SpecificInputModel=2
    }

}
