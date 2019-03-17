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
        private decimal currentTime;
        public Simulation SimulationConfiguration;

        public SimulationResultViewModel()
        {
            Title = "Simulation Results";
            IterationCurrent = 0;            
        }

        public void computeSimulationResults()
        {
            IterationCurrent = 0;
            var simulationCurrentRun = SimulationConfiguration.DeepCopy();

            simulationRuns = new ObservableCollection<Simulation>();
            do
            {
                simulationRuns.Add(simulationCurrentRun.DeepCopy());
            } while (!simulationCurrentRun.UpdateSimulation());

            // Store the number of iterations the simulation needed to finish
            maxIteration = simulationRuns.Count - 1;

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
                {
                    SimulationCurrent = simulationRuns[value];
                    CurrentTime = value * simulationRuns[0].TimeStepMin;
                }
            }
        }

        public int MaxIteration { get => maxIteration; }
        public decimal CurrentTime { get => currentTime; set => Set(() => CurrentTime, ref currentTime, value); }
    }
}
