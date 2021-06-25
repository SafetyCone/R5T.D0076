using System;

using R5T.D0076.A001;


namespace System
{
    public static class IServicesAggregation01IncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServicesAggregation01Increment other)
            where T : IServicesAggregation01Increment
        {
            aggregation.BaseCommandLineOperatorAction = other.BaseCommandLineOperatorAction;
            aggregation.CommandLineOperatorAction = other.CommandLineOperatorAction;

            return aggregation;
        }
    }
}
