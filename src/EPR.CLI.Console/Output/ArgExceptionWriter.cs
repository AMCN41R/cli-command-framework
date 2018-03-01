using System;
using EPR.CLI.Console.Actions;
using PowerArgs;

namespace EPR.CLI.Console.Output
{
    internal class ArgExceptionWriter : IConsoleWriter<ArgException>
    {
        public void Write(ArgException item)
        {
            System.Console.BackgroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(item.Message);
            System.Console.WriteLine();

            System.Console.ResetColor();

            ConsoleProvider.Current.WriteLine(
                ArgUsage.GenerateUsageFromTemplate<ApplicationActions>()
            );
        }
    }
}