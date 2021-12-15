using System;

using R5T.D0076.A001;


namespace System
{
    public static class IServiceActionAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceActionAggregation01 other)
            where T : IServiceActionAggregation01
        {
            (aggregation as R5T.D0074.A001.IServiceActionAggregation01).FillFrom(other);

            (aggregation as IServiceActionAggregation01Increment).FillFrom(other);

            return aggregation;
        }
    }
}
