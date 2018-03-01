using System.Collections.Generic;

namespace EPR.CLI.Core.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandValidationResult Validate(TCommand command);

        IEnumerable<CommandProgress> Execute(TCommand command);
    }
}