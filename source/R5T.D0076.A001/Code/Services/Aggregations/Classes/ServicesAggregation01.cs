using System;

using R5T.Dacia;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076.A001
{
    public class ServicesAggregation01 : D0074.A001.ServicesAggregation01, IServicesAggregation01
    {
        public IServiceAction<IBaseCommandLineOperator> BaseCommandLineOperatorAction { get; set; }
        public IServiceAction<ICommandLineOperator> CommandLineOperatorAction { get; set; }
    }
}
