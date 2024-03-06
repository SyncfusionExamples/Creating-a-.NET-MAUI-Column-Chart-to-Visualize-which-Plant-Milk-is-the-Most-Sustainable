using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustainableMilk
{
    public class MilkSourceModel
    {
        public string Source { get; set; }
        public double WaterQuantity  { get; set; }
        public double CO2Emission  { get; set; }

        public MilkSourceModel(string source, double waterQuantity, double cO2Emission)
        {
            Source = source;
            WaterQuantity = waterQuantity;
            CO2Emission = cO2Emission;
        }
    }
}