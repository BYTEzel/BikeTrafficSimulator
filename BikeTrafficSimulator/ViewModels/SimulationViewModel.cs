using BikeTrafficSimulator.Models;
using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace BikeTrafficSimulator.ViewModels
{
    public class SimulationViewModel : ViewModelBase
    {
        private string title;
        private Simulation simulationConfiguration;
        private TrafficLight currentTrafficLight;
        private Biker currentBiker;
        private Track currentTrack;

        public ICommand AddTrafficLight { get; private set; }
        public ICommand DeleteTrafficLight { get; private set; }
        public ICommand AddBiker { get; private set; }
        public ICommand DeleteBiker { get; private set; }
        public ICommand AddTrack { get; private set; }
        public ICommand DelteTrack { get; private set; }

        public SimulationViewModel()
        {
            Title = "Simulation Configuration";
            
        }


        public string Title { get => title; set => Set(() => Title, ref title, value); }
        public Simulation SimulationConfiguration { get => simulationConfiguration; set => Set(() => SimulationConfiguration, ref simulationConfiguration, value); }
        public TrafficLight CurrentTrafficLight { get => currentTrafficLight; set => currentTrafficLight = value; }
        public Biker CurrentBiker { get => currentBiker; set => currentBiker = value; }
        public Track CurrentTrack { get => currentTrack; set => currentTrack = value; }
    }
}
