using System;

namespace EPR.CLI.Console.Output
{
    internal class ExceptionWriter : IConsoleWriter<Exception>
    {
        public void Write(Exception item)
        {
            this.WriteTitle();

            this.WriteDetail("Type", item.GetType().Name);
            this.WriteDetail("Message", item.Message);

            this.WriteStackTrace(item);

            System.Console.ResetColor();
            System.Console.WriteLine();
        }

        private void WriteTitle()
        {
            var initialBackgroundColor = System.Console.BackgroundColor;

            System.Console.BackgroundColor = ConsoleColor.DarkRed;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("  An exception was thrown  ");
            System.Console.BackgroundColor = initialBackgroundColor;
            System.Console.WriteLine();
        }

        private void WriteDetail(string key, string value)
        {
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.Write($"{INDENT}{key}: ");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write($"{value}");
            System.Console.WriteLine();
        }

        private void WriteStackTrace(Exception item)
        {
            var trace = new System.Diagnostics.StackTrace(item, true);
            var frames = trace.GetFrames();

            this.WriteDetail("Stack Trace", "");
            for (var i = 0; i < trace.FrameCount; i++)
            {
                this.WriteDetail($"{INDENT}[{i}]", $"{frames[i]}".Trim());
            }
        }

        // ReSharper disable once InconsistentNaming
        private static string INDENT => "  ";
    }
}