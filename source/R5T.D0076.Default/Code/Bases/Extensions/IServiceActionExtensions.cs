using System;

using R5T.D0074;
using R5T.T0062;
using R5T.T0063;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076.Default
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CommandLineOperator"/> implementation of <see cref="ICommandLineOperator"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICommandLineOperator> AddCommandLineOperatorAction(this IServiceAction _,
            IServiceAction<IBaseCommandLineOperator> baseCommandLineOperatorAction,
            IServiceAction<ITaskQueueConstructor> taskQueueConstructorAction)
        {
            var serviceAction = _.New<ICommandLineOperator>(services => services.AddCommandLineOperator(
                baseCommandLineOperatorAction,
                taskQueueConstructorAction));

            return serviceAction;
        }
    }
}
