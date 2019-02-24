using GalaSoft.MvvmLight;
using System;

namespace BikeTrafficSimulator.Models
{
    public class TrafficLight : ObservableObject
    {
        public enum State { Green, Red};
        private State currentState;
        private decimal timeGreenMin;
        private decimal timeRedMin;
        private decimal timeElapsed;
        private decimal position;

        /// <summary>
        /// Shows if the traffic light is currently green or red.
        /// </summary>
        public State CurrentState { get => currentState; set => Set(() => CurrentState, ref currentState, value); }
        /// <summary>
        /// This variable contains how long the traffic light remains green in Minutes.
        /// </summary>
        public decimal TimeGreenMin { get => timeGreenMin; set => Set(() => TimeGreenMin, ref timeGreenMin, value); }
        /// <summary>
        /// This variable contains how long the traffic light remains red in Minutes.
        /// </summary>
        public decimal TimeRedMin { get => timeRedMin; set => Set(() => TimeRedMin, ref timeRedMin, value); }
        /// <summary>
        /// This variable contains the position of the traffic light on the track.
        /// </summary>
        public decimal Position { get => position; set => Set(() => Position, ref position, value); }

        public TrafficLight()
        {
            // Start with a random state (red/green)
            Random rand = new Random();
            CurrentState = (rand.Next(0, 1) > 0) ? State.Green : State.Red;
        }

        /// <summary>
        /// Update the simulation for the traffic light. Based on the next increment, the traffic light is switched or remains the same.
        /// </summary>
        /// <param name="timeStepMin">The size of the next time step in minutes.</param>
        public void UpdateStatus(decimal timeStepMin)
        {
            // Update the relative time counter
            timeElapsed += timeStepMin;
            // Switch the traffic light if the time has come
            switch (CurrentState)
            {
                case State.Green:
                    CurrentState = (timeElapsed >= timeGreenMin) ? State.Red : State.Green;
                    timeElapsed = 0;
                    break;
                case State.Red:
                    CurrentState = (timeElapsed >= timeRedMin) ? State.Green : State.Red;
                    timeElapsed = 0;
                    break;
                default:
                    throw new NotImplementedException("Invalid traffic light state.");
            }
        }
    }
}
