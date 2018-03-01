using System;
using EPR.CLI.Core.Commands;

namespace EPR.CLI.Console.Output
{
    internal class CommandProgressWriter : IConsoleWriter<CommandProgress>
    {
        public void Write(CommandProgress item)
        {
            if (item.HasKey)
            {
                System.Console.Write($"{item.Key}: ");
                System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.Write($"{item.Value}");
                System.Console.ResetColor();
                System.Console.WriteLine();
                return;
            }

            System.Console.WriteLine(item.Message);
        }
    }
}