using System;
using System.Collections.Generic;
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

        public static async Task<CommandLineExecutionResult> RunGetResult(this ICommandLineOperator commandLineOperator, string command, string arguments = Strings.Empty)
        {
            var outputLines = new List<string>();

            Task WriteToOutput(string line)
            {
                outputLines.Add(line);

                return Task.CompletedTask;
            }

            var errorLines = new List<string>();

            Task WriteToError(string line)
            {
                errorLines.Add(line);

                return Task.CompletedTask;
            }

            var exitCode = await commandLineOperator.Run(command, arguments, WriteToOutput, WriteToError);

            var output = new CommandLineExecutionResult
            {
                ErrorLines = errorLines.ToArray(),
                ExitCode = exitCode,
                OutputLines = outputLines.ToArray(),
            };

            return output;
        }
    }
}
