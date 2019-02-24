﻿using GalaSoft.MvvmLight;
using BikeTrafficSimulator.Misc;


namespace BikeTrafficSimulator.Models
{
    public class Biker : ObservableObject
    {
        private enum State { Driving, Stopped }
        private string name;
        private decimal acceleration;
        private decimal velocityMax;
        private int recklessness;
        private decimal position;
        private decimal velocityCurrent;
        private State stateCurrent;

        public Biker()
        {
            name = "Biker";
            acceleration = 0.1m;
            velocityMax = 1m;
            recklessness = 0;
            position = 0;
            velocityCurrent = 0;
            stateCurrent = State.Stopped;
        }

        /// <summary>
        /// The name of this specific biker.
        /// </summary>
        public string Name { get => name; set => Set(() => Name, ref name, value); }

        /// <summary>
        /// The acceleration of the biker given in m/s².
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
        /// The maximum velocity of the biker given in km/h.
        /// </summary>
        public decimal VelocityMax
        {
            get => velocityMax;
            set
            {
                if (value > 0)
                {
                    Set(() => VelocityMax, ref velocityMax, value);
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
        public decimal VelocityCurrent { get => velocityCurrent; set => Set(() => VelocityCurrent, ref velocityCurrent, value); }
        private State StateCurrent { get => stateCurrent; set => Set(() => StateCurrent, ref stateCurrent, value); }

        public void UpdatePosition(decimal timeStepMin)
        {
            // Check, if the biker is currently allowed to move at all.
            if (State.Driving == StateCurrent)
            {
                // First, update the current speed
                // For this, store the old speed
                var VelocityOld = VelocityCurrent;
                // Calculate the new velocity in case the maximum speed is not yet reached
                if (VelocityCurrent != VelocityMax)
                {
                    // v1 = v0 + a*t    (including the conversion to km/h)
                    VelocityCurrent += (Acceleration * timeStepMin * 3600) / 1000;
                    // Check, if the current velocity is larger than the maximum one
                    VelocityCurrent = (VelocityCurrent > VelocityMax) ? VelocityMax : VelocityMax;
                }

                // Update the position (s = ((v0+v1)*t) / 2)
                Position += ((VelocityCurrent + VelocityOld) * timeStepMin) / 2;
            }
        }

        public void Stop(decimal position)
        {
            Position = position;
            StateCurrent = State.Stopped;
            VelocityCurrent = 0;
        }

        public void Start()
        {
            StateCurrent = State.Driving;
        }
    }
}
