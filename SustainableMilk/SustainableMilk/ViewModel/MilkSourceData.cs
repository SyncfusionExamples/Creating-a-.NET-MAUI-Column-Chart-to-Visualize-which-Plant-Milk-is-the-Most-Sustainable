using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustainableMilk
{
    public class MilkSourceData : INotifyPropertyChanged
    {
        public List<MilkSourceModel> Data { get; set; }

        private string sourceImage = "";
        public string SourceImage
        {
            get { return sourceImage; }
            set
            {
                if (sourceImage != value)
                {
                    sourceImage = value;
                    OnPropertyChanged(nameof(sourceImage));
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

        public MilkSourceData()
        {
            Data = new List<MilkSourceModel>
            {
                new MilkSourceModel("Cow", 628, 3.2),
                new MilkSourceModel("Almond", 371, 0.7),
                new MilkSourceModel("Rice", 270, 1.2),
                new MilkSourceModel("Oat", 48, 0.9),
                new MilkSourceModel("Soy", 28, 1.0),
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
                SourceImage = Data[SelectedIndex].Source.ToLower() + ".png";
                EmissionText = Data[SelectedIndex].CO2Emission.ToString();
            }
        }
    }
}