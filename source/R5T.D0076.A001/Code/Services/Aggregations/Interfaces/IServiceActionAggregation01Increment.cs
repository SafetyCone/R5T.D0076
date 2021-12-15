using System;

using R5T.T0063;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076.A001
{
    public interface IServiceActionAggregation01Increment
    {
        IServiceAction<IBaseCommandLineOperator> BaseCommandLineOperatorAction { get; set; }
        IServiceAction<ICommandLineOperator> CommandLineOperatorAction { get; set; }
    }
}
