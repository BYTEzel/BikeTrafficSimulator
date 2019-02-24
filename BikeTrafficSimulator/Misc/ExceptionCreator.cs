using System;

namespace BikeTrafficSimulator.Misc
{
    class ExceptionCreator
    {
        public static ArgumentOutOfRangeException GetValueAboveZeroException(string variableName)
        {
            return new ArgumentOutOfRangeException(variableName, variableName + " must be greater than 0.");
        }

        public static ArgumentOutOfRangeException GetValueBelowException(string variableName, int maxValue)
        {
            return new ArgumentOutOfRangeException(variableName, variableName + " must be smaller than " + maxValue);
        }
    }
}
