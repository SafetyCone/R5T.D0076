using System;

using R5T.D0076.A001;


namespace System
{
    public static class IServicesAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServicesAggregation01 other)
            where T : IServicesAggregation01
        {
            (aggregation as R5T.D0074.A001.IServicesAggregation01).FillFrom(other);

            (aggregation as IServicesAggregation01Increment).FillFrom(other);

            return aggregation;
        }
    }
}
