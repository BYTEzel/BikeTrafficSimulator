using BikeTrafficSimulator.Misc;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;

namespace BikeTrafficSimulator.Models
{
    public class Simulation : ObservableObject
    {
        private ObservableCollection<Biker> bikers;
        private ObservableCollection<TrafficLight> trafficLights;
        private Track track;
        private decimal timeStepMin;

        public ObservableCollection<Biker> Bikers { get => bikers; set => Set(() => Bikers, ref bikers, value); }
        public ObservableCollection<TrafficLight> TrafficLights { get => trafficLights; set => Set(() => TrafficLights, ref trafficLights, value); }
        public Track Track { get => track; set => Set(() => Track, ref track, value); }
        public decimal TimeStepMin
        {
            get => timeStepMin;
            set
            {
                if (value > 0)
                    Set(() => TimeStepMin, ref timeStepMin, value);
                else
                    throw ExceptionCreator.GetValueAboveZeroException("TimeStepMin");
            }
        }

        public Simulation()
        {
            Bikers = new ObservableCollection<Biker>();
            TrafficLights = new ObservableCollection<TrafficLight>();
            Track = new Track(5);
            TimeStepMin = 1;
        }

        /// <summary>
        /// Updates the next iteration of the simulation.
        /// </summary>
        /// <returns>Returns if the simulation has finished (all bikers reached their target).</returns>
        public bool UpdateSimulation()
        {
            // Update all traffic lights
            foreach(TrafficLight t in TrafficLights)
            {
                t.UpdateStatus(timeStepMin);
            }

            // Store the state of all bikers before and after the iteration to check for traffic lights in between the iteration.
            ObservableCollection<Biker> bikersOld = Bikers;
            for (int i = 0; i < Bikers.Count; i++)
            {
                Bikers[i].UpdatePosition(TimeStepMin);
                for (int j = 0; j < TrafficLights.Count; j++)
                {
                    // Check if the bike crossed a traffic light during the last iteration
                    if ((bikersOld[i].Position < TrafficLights[j].Position) && (Bikers[i].Position > TrafficLights[j].Position))
                    {
                        if (TrafficLight.State.Green == TrafficLights[j].CurrentState)
                        {
                            Bikers[i].Start();
                        }
                        else // Traffic light is red
                        {
                            // This operation is only valid, if the driver is recklessness
                            if (Bikers[i].Recklessness < (new Random()).Next(1, 100))
                            {
                                Bikers[i].Stop(TrafficLights[j].Position);
                            }
                        }
                    }
                }
            }

            // Check, if the simulation is finished
            foreach (Biker b in Bikers)
            {
                if (b.Position < track.LengthKm)
                {
                    return false;
                }
            }
            return true;            
        }

        public Simulation DeepCopy()
        {
            Simulation sim = new Simulation();

            // Clone each self-defined object type
            sim.Track = Track.DeepCopy();

            // Clone all bikers
            for (int i=0;i<Bikers.Count;i++)
            {
                sim.Bikers.Add(Bikers[i].DeepCopy());
            }

            // Clone all traffic lights
            foreach (TrafficLight tl in TrafficLights)
            {
                sim.TrafficLights.Add(tl.DeepCopy());
            }

            return sim;
        }
    }
}
