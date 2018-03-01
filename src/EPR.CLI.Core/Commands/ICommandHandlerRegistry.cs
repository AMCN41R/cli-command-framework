using System;

namespace EPR.CLI.Core.Commands
{
    public interface ICommandHandlerRegistry
    {
        Type GetByCommand(ICommand commandType);
    }
}