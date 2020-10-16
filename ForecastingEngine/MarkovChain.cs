using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using IOOperations.Components;

namespace ForecastingEngine
{
   public class MarkovChain
    {

        [Category("Input Data")] public DataSerie1D InputDataSerie { get; set; }
        [Category("Input Data")] public double Step { get; set; } = 1;
        [Category("Input Data")] public double MaxValue { get; set; } = 105.18;

        [Category("Outputs")] public DataSerie2D ClassifiedDataSerie { get; set; }

        public void Compute()
        {
            ClassifiedDataSerie = GetClassifiedSerie(InputDataSerie);
        }
       
        public DataSerie2D GetClassifiedSerie (DataSerie1D dsIn)
        {
            if(Equals(dsIn, null)) { return null; }
            if (Equals(dsIn, null)) { return null; }

            DataSerie2D dsOut = new DataSerie2D();

            try
            {
                int classe = 0;
                double devision = 0;
                foreach (DataItem1D itm in dsIn.Data)
                {
                    devision = Math.Floor(((itm.X_Value* MaxValue) / Step));
                    classe = (int)devision;
                    dsOut.Add(itm.Title, (itm.X_Value * MaxValue), (classe+1));
                }
            }
            catch (Exception ex) { throw ex; }
            return dsOut;
        }

    }
}
