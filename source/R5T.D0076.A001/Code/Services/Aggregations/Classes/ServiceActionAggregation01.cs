using System;

using R5T.D0074;
using R5T.T0063;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076.A001
{
    public class ServiceActionAggregation01 : IServiceActionAggregation01
    {
        public IServiceAction<ITaskQueue> TaskQueueAction { get; set; }
        public IServiceAction<ITaskQueueConstructor> TaskQueueConstructorAction { get; set; }
        public IServiceAction<IBaseCommandLineOperator> BaseCommandLineOperatorAction { get; set; }
        public IServiceAction<ICommandLineOperator> CommandLineOperatorAction { get; set; }
    }
}
