using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustainableMilk
{
    public class MilkPlantModel
    {
        public string Plant { get; set; }
        public double WaterQuantity  { get; set; }
        public double CO2Emission  { get; set; }

        public MilkPlantModel(string plant, double waterQuantity, double cO2Emission)
        {
            Plant = plant;
            WaterQuantity = waterQuantity;
            CO2Emission = cO2Emission;
        }
    }
}