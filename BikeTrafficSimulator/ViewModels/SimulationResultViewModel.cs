using BikeTrafficSimulator.Models;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace BikeTrafficSimulator.ViewModels
{
    public class SimulationResultViewModel : ViewModelBase
    {
        private string title;
        private ObservableCollection<Simulation> simulationRuns;
        private Simulation simulationCurrent;
        private int iterationCurrent;
        private int maxIteration;

        public SimulationResultViewModel()
        {
            Title = "Simulation Results";
            IterationCurrent = 0;
            ViewModelLocator locator = new ViewModelLocator();
            var simulationCurrentRun = locator.SimulationViewModel.SimulationConfiguration;

            simulationRuns = new ObservableCollection<Simulation>();
            do
            {
                simulationRuns.Add(simulationCurrentRun.DeepCopy());
            } while (!simulationCurrentRun.UpdateSimulation());

            // Store the number of iterations the simulation needed to finish
            maxIteration = simulationRuns.Count-1;

            SimulationCurrent = simulationRuns[IterationCurrent];
        }

        public string Title { get => title; set => Set(() => Title, ref title, value); }
        public Simulation SimulationCurrent { get => simulationCurrent; set => Set(() => SimulationCurrent, ref simulationCurrent, value); }
        public int IterationCurrent
        {
            get => iterationCurrent;
            set
            {
                Set(() => IterationCurrent, ref iterationCurrent, value);
                if (simulationRuns != null)
                    SimulationCurrent = simulationRuns[IterationCurrent];
            }
        }
        public int MaxIteration { get => maxIteration; }
    }
}
