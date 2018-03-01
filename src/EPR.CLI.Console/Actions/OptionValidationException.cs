using System;
using PowerArgs;

namespace EPR.CLI.Console.Actions
{
    public class OptionValidationException : ArgException
    {
        public OptionValidationException(string msg) : base(msg)
        {
        }

        public OptionValidationException(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}