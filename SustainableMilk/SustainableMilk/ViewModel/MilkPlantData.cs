using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustainableMilk
{
    public class MilkPlantData : INotifyPropertyChanged
    {
        public List<MilkPlantModel> Data { get; set; }

        private string plantImage = "";
        public string PlantImage
        {
            get { return plantImage; }
            set
            {
                if (plantImage != value)
                {
                    plantImage = value;
                    OnPropertyChanged(nameof(PlantImage));
                }
            }
        }

        private string emissionText = "";
        public string EmissionText
        {
            get { return emissionText; }
            set
            {
                if (emissionText != value)
                {
                    emissionText = value;
                    OnPropertyChanged(nameof(EmissionText));
                }
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                UpdateCountryAndCount();
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public MilkPlantData()
        {
            Data = new List<MilkPlantModel>
            {
                new MilkPlantModel("Cow", 628, 3.2),
                new MilkPlantModel("Almond", 371, 0.7),
                new MilkPlantModel("Rice", 270, 1.2),
                new MilkPlantModel("Oat", 48, 0.9),
                new MilkPlantModel("Soy", 28, 1.0),
            };

            SelectedIndex = 1;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void UpdateCountryAndCount()
        {
            if (SelectedIndex >= 0 && SelectedIndex < Data?.Count)
            {
                PlantImage = Data[SelectedIndex].Plant.ToLower() + ".png";
                EmissionText = Data[SelectedIndex].CO2Emission.ToString();
            }
        }
    }
}