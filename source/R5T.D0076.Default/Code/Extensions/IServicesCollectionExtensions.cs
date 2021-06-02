using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0074;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076.Default
{
    public static class IServicesCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CommandLineOperator"/> implementation of <see cref="ICommandLineOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCommandLineOperator(this IServiceCollection services,
            IServiceAction<IBaseCommandLineOperator> baseCommandLineOperatorAction,
            IServiceAction<ITaskQueueConstructor> taskQueueConstructorAction)
        {
            services.AddSingleton<ICommandLineOperator, CommandLineOperator>()
                .Run(baseCommandLineOperatorAction)
                .Run(taskQueueConstructorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CommandLineOperator"/> implementation of <see cref="ICommandLineOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICommandLineOperator> AddCommandLineOperatorAction(this IServiceCollection services,
            IServiceAction<IBaseCommandLineOperator> baseCommandLineOperatorAction,
            IServiceAction<ITaskQueueConstructor> taskQueueConstructorAction)
        {
            var serviceAction = ServiceAction.New<ICommandLineOperator>(() => services.AddCommandLineOperator(
                baseCommandLineOperatorAction,
                taskQueueConstructorAction));

            return serviceAction;
        }
    }
}
