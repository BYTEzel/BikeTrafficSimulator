using BikeTrafficSimulator.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace BikeTrafficSimulator.ViewModels
{
    public class SimulationViewModel : ViewModelBase
    {
        private string title;
        private Simulation simulationConfiguration;
        private TrafficLight currentTrafficLight;
        private Biker currentBiker;

        public ICommand AddTrafficLightCommand { get; private set; }
        public ICommand DeleteTrafficLightCommand { get; private set; }
        public ICommand AddBikerCommand { get; private set; }
        public ICommand DeleteBikerCommand { get; private set; }

        public SimulationViewModel()
        {
            Title = "Simulation Configuration";
            SimulationConfiguration = new Simulation();

            AddBikerCommand           = new RelayCommand(AddBiker);
            DeleteBikerCommand        = new RelayCommand(DeleteBiker);
            AddTrafficLightCommand    = new RelayCommand(AddTrafficLight);
            DeleteTrafficLightCommand = new RelayCommand(DeleteTrafficLight);
        }

        private void DeleteTrafficLight()
        {
            SimulationConfiguration.TrafficLights.Remove(CurrentTrafficLight);
        }

        private void AddTrafficLight()
        {
            SimulationConfiguration.TrafficLights.Add(new TrafficLight() { TimeGreenMin = 10m, TimeRedMin = 2m });
        }

        private void DeleteBiker()
        {
            SimulationConfiguration.Bikers.Remove(CurrentBiker);
        }

        private void AddBiker()
        {
            SimulationConfiguration.Bikers.Add(new Biker() { Name = "Nameless Biker" });
        }

        public string Title { get => title; set => Set(() => Title, ref title, value); }
        public Simulation SimulationConfiguration { get => simulationConfiguration; set => Set(() => SimulationConfiguration, ref simulationConfiguration, value); }
        public TrafficLight CurrentTrafficLight { get => currentTrafficLight; set => Set(() => CurrentTrafficLight, ref currentTrafficLight, value); }
        public Biker CurrentBiker { get => currentBiker; set => Set(() => CurrentBiker, ref currentBiker, value); }


    }
}
