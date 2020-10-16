using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOOperations.Components
{
 public class IOReservoir
    {
        public string Name;
        public string Description;

        public double MinCapacity;
        public double MaxCapacity;

        public double MinRelease;
        public double MaxRelease;

        public DataSerie2D Elevation_Area;
        public DataSerie2D Elevation_Volume;

        public DataSerie1D Inflow;
        public DataSerie1D Downstream;
        public DataSerie2D Evaporation;
        public DataSerie2D Infiltration;
        
    }
}
