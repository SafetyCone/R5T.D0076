using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0074;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076.Default
{
    public static partial class IServicesCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CommandLineOperator"/> implementation of <see cref="ICommandLineOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCommandLineOperator_Old(this IServiceCollection services,
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
        public static IServiceAction<ICommandLineOperator> AddCommandLineOperatorAction_Old(this IServiceCollection services,
            IServiceAction<IBaseCommandLineOperator> baseCommandLineOperatorAction,
            IServiceAction<ITaskQueueConstructor> taskQueueConstructorAction)
        {
            var serviceAction = ServiceAction.New<ICommandLineOperator>(() => services.AddCommandLineOperator_Old(
                baseCommandLineOperatorAction,
                taskQueueConstructorAction));

            return serviceAction;
        }
    }
}
