using System;
using System.Threading.Tasks;

using R5T.D0076;


namespace System
{
    public static class ICommandLineOperatorExtensions
    {
        public static Task<int> Run(this ICommandLineOperator commandLineOperator, string command, string arguments = Strings.Empty)
        {
            static Task WriteToConsole(string line)
            {
                return Console.Out.WriteLineAsync(line);
            }

            return commandLineOperator.Run(command, arguments, WriteToConsole, WriteToConsole);
        }
    }
}
