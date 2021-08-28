using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar;

using R5T.D0074.A001;
using R5T.D0075;
using R5T.D0076.Default;


namespace R5T.D0076.A001
{
    public static class IServiceCollectionExtensions
    {
        public static ServicesAggregation01 AddCommandLineOperatorServices(this IServiceCollection services)
        {
            // Level 0.
            var taskQueueServices = services.AddTaskQueueServices();
            var baseCommandLineOperatorAction = services.AddCommandLineOperatorAction();

            // Level 1.
            var commandLineOperatorAction = services.AddCommandLineOperatorAction(
                baseCommandLineOperatorAction,
                taskQueueServices.TaskQueueConstructorAction);

            return new ServicesAggregation01()
                .As<ServicesAggregation01, IServicesAggregation01Increment>(increment =>
                {
                    increment.BaseCommandLineOperatorAction = baseCommandLineOperatorAction;
                    increment.CommandLineOperatorAction = commandLineOperatorAction;
                })
                .FillFrom(taskQueueServices);
        }
    }
}
