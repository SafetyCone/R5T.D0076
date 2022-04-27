using System;
using System.Diagnostics;
using System.Threading.Tasks;

using R5T.D0074;
using R5T.T0064;

using IBaseCommandLineOperator = R5T.D0075.ICommandLineOperator;


namespace R5T.D0076
{
    [ServiceImplementationMarker]
    public class CommandLineOperator : ICommandLineOperator, IServiceImplementation
    {
        private IBaseCommandLineOperator BaseCommandLineOperator { get; }
        private ITaskQueueConstructor TaskQueueConstructor { get; }


        public CommandLineOperator(
            IBaseCommandLineOperator baseCommandLineOperator,
            ITaskQueueConstructor taskQueueConstructor)
        {
            this.BaseCommandLineOperator = baseCommandLineOperator;
            this.TaskQueueConstructor = taskQueueConstructor;
        }

        public async Task<int> Run(string command, string arguments, Func<string, Task> receiveOutputData, Func<string, Task> receiveErrorData)
        {
            using var taskQueue = await this.TaskQueueConstructor.GetNewTaskQueue();

            void ReceiveOutputData(object sender, DataReceivedEventArgs e)
            {
                var receiveOutputTask = receiveOutputData(e.Data);

                taskQueue.Enqueue(receiveOutputTask);
            }

            void ReceiveErrorData(object sender, DataReceivedEventArgs e)
            {
                var receiveErrorTask = receiveErrorData(e.Data);

                taskQueue.Enqueue(receiveErrorTask);
            }

            var exitCode = await this.BaseCommandLineOperator.Run(command, arguments, ReceiveOutputData, ReceiveErrorData);
            return exitCode;
        }
    }
}
