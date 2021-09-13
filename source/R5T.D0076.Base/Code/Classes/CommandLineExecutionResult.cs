using System;


namespace R5T.D0076
{
    public class CommandLineExecutionResult
    {
        public int ExitCode { get; set; }
        public string[] OutputLines { get; set; }
        public string[] ErrorLines { get; set; }
    }
}
