using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0076
{
    [ServiceDefinitionMarker]
    public interface ICommandLineOperator : IServiceDefinition
    {
        Task<int> Run(string command, string arguments, Func<string, Task> receiveOutputData, Func<string, Task> receiveErrorData);
    }
}
