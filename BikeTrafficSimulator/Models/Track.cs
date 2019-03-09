using GalaSoft.MvvmLight;
using BikeTrafficSimulator.Misc;

namespace BikeTrafficSimulator.Models
{
    public class Track : ObservableObject
    {
        private decimal lengthKm;

        /// <summary>
        /// Gives the length of the track in kilometers.
        /// </summary>
        public decimal LengthKm { get => lengthKm; set => Set(() => LengthKm, ref lengthKm, value); }

        public Track(decimal lenghtKm)
        {
            if (lenghtKm > 0)
            {
                LengthKm = lenghtKm;
            }
            else
            {
                throw ExceptionCreator.GetValueAboveZeroException("Track length");
            }
        }

        public Track DeepCopy()
        {
            return (Track)MemberwiseClone();
        }
    }
}
