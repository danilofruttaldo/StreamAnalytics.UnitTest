using System;

namespace SA.Utils.Data
{
    public static class GenericConstants
    {
        public static readonly int PacketsNumber = 10;
    }

    public static class TemperatureConstants
    {
        public const double Indoor = 20.2;
        public const double Outdoor = 20.7;

        public const double Increment = 1;
    }

    public static class TemperatureAnalysisConstants
    {
        public static readonly double Difference = Math.Abs(TemperatureConstants.Indoor - TemperatureConstants.Outdoor);

        public const double Increment = 1;
    }

    public static class TestCategories
    {
        public const string ConstantValues = "ConstantValues"; //Tests that provide same inputs value for each packet sent
        public const string VariableValues = "VariableValues"; //Tests that provide different inputs value for each packet sent
        public const string NullValues = "NullValues"; //Tests that provide null inputs value for each packet sent
    }
}