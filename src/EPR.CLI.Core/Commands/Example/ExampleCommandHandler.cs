using System.Collections.Generic;
using System.Threading;

namespace EPR.CLI.Core.Commands.Example
{
    internal class ExampleCommandHandler : ICommandHandler<ExampleCommand>
    {
        public CommandValidationResult Validate(ExampleCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Message))
            {
                return new CommandValidationResult("A message must be specified");
            }

            
            return new CommandValidationResult();
        }

        public IEnumerable<CommandProgress> Execute(ExampleCommand command)
        {
            yield return new CommandProgress("Starting...");
            Thread.Sleep(500);

            yield return new CommandProgress($"Message: {command.Message}");
            Thread.Sleep(500);

            yield return new CommandProgress("Done");
            Thread.Sleep(500);
        }
    }
}