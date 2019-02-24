using GalaSoft.MvvmLight;
using BikeTrafficSimulator.Misc;


namespace BikeTrafficSimulator.Models
{
    public class Biker : ObservableObject
    {
        private enum State { Driving, Stopped }
        private string name;
        private decimal acceleration;
        private decimal maximumSpeed;
        private int recklessness;
        private decimal position;
        private decimal currentSpeed;
        private State currentState;

        public Biker()
        {
            name = "Biker";
            acceleration = 0.1m;
            maximumSpeed = 1m;
            recklessness = 0;
            position = 0;
            currentSpeed = 0;
            currentState = State.Stopped;
        }

        /// <summary>
        /// The name of this specific biker.
        /// </summary>
        public string Name { get => name; set => Set(() => Name, ref name, value); }

        /// <summary>
        /// The acceleration of the biker given in km/h.
        /// </summary>
        public decimal Acceleration
        {
            get => acceleration;
            set
            {
                if (value > 0)
                {
                    Set(() => Acceleration, ref acceleration, value);
                }
                else
                {
                    throw ExceptionCreator.GetValueAboveZeroException("Acceleration");
                }
            }
        }

        /// <summary>
        /// The maximum speed of the biker given in km/h.
        /// </summary>
        public decimal MaximumSpeed
        {
            get => maximumSpeed;
            set
            {
                if (value > 0)
                {
                    Set(() => MaximumSpeed, ref maximumSpeed, value);
                }
                else
                {
                    throw ExceptionCreator.GetValueAboveZeroException("Maximum speed");
                }
            }
        }

        /// <summary>
        /// Recklessness is a factor between [0,100] which gives a per cent estimation how likely it
        /// is for the biker to ignore red traffic lights.
        /// </summary>
        public int Recklessness
        {
            get => recklessness;
            set
            {
                if (value >= 0)
                {
                    if (value <= 100)
                    {
                        Set(() => Recklessness, ref recklessness, value);
                    }
                    else
                    {
                        throw ExceptionCreator.GetValueBelowException("Recklessness", 100);
                    }
                }
                else
                {
                    throw ExceptionCreator.GetValueAboveZeroException("Recklessness");
                }
            }
        }

        public decimal Position { get => position; set => Set(() => Position, ref position, value); }
        public decimal CurrentSpeed { get => currentSpeed; set => Set(() => CurrentSpeed, ref currentSpeed, value); }
        private State CurrentState { get => currentState; set => Set(() => CurrentState, ref currentState, value); }

        public void UpdatePosition(decimal timeStepMin)
        {

        }
    }
}
