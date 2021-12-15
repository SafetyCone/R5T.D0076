using System;

using R5T.D0076.A001;


namespace System
{
    public static class IServiceActionAggregation01IncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceActionAggregation01Increment other)
            where T : IServiceActionAggregation01Increment
        {
            aggregation.BaseCommandLineOperatorAction = other.BaseCommandLineOperatorAction;
            aggregation.CommandLineOperatorAction = other.CommandLineOperatorAction;

            return aggregation;
        }
    }
}
