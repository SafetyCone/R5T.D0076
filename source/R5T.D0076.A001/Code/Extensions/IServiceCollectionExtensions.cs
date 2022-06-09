using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar.Extensions;

using R5T.D0074.A001;
using R5T.D0075.Default;
using R5T.D0076.Default;


namespace R5T.D0076.A001
{
    public static class IServiceCollectionExtensions
    {
        public static ServicesAggregation01 AddCommandLineOperatorServices(this IServiceCollection services)
        {
            // Level 0.
            var taskQueueServices = services.AddTaskQueueServices();
            var baseCommandLineOperatorAction = services.AddCommandLineOperatorAction_Old();

            // Level 1.
            var commandLineOperatorAction = services.AddCommandLineOperatorAction_Old(
                baseCommandLineOperatorAction,
                taskQueueServices.TaskQueueConstructorAction);

            return new ServicesAggregation01()
                .ModifyAs<ServicesAggregation01, IServicesAggregation01Increment>(increment =>
                {
                    increment.BaseCommandLineOperatorAction = baseCommandLineOperatorAction;
                    increment.CommandLineOperatorAction = commandLineOperatorAction;
                })
                .FillFrom(taskQueueServices);
        }
    }
}
