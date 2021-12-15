using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar;

using R5T.D0074.A001;
using R5T.D0075.Default;
using R5T.D0076.Default;
using R5T.T0062;


namespace R5T.D0076.A001
{
    public static class IServicActionExtensions
    {
        public static ServiceActionAggregation01 AddCommandLineOperatorServiceActions(this IServiceAction _)
        {
            // Level 0.
            var taskQueueServices = _.AddTaskQueueServiceActions();
            var baseCommandLineOperatorAction = _.AddCommandLineOperatorAction();

            // Level 1.
            var commandLineOperatorAction = _.AddCommandLineOperatorAction(
                baseCommandLineOperatorAction,
                taskQueueServices.TaskQueueConstructorAction);

            return new ServiceActionAggregation01()
                .As<ServiceActionAggregation01, IServiceActionAggregation01Increment>(increment =>
                {
                    increment.BaseCommandLineOperatorAction = baseCommandLineOperatorAction;
                    increment.CommandLineOperatorAction = commandLineOperatorAction;
                })
                .FillFrom(taskQueueServices);
        }
    }
}
