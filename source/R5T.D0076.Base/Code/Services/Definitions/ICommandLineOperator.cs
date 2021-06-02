using System;
using System.Threading.Tasks;


namespace R5T.E0024.D003
{
    public interface ICommandLineOperator
    {
        Task<int> Run(string command, string arguments, Func<string, Task> receiveOutputData, Func<string, Task> receiveErrorData);
    }
}
