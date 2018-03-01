using System;
using System.Collections.Generic;
using System.Linq;

namespace EPR.CLI.Core.Commands
{
    internal class CommandHandlerRegistry : ICommandHandlerRegistry
    {
        public CommandHandlerRegistry(Type[] handlerTypes)
        {
            this.HandlerTypes = handlerTypes;
        }

        private IEnumerable<Type> HandlerTypes { get; }

        public Type GetByCommand(ICommand commandType)
            => this.HandlerTypes
                   .SingleOrDefault(x =>
                        x.GetInterfaces()
                         .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
                         .GetGenericArguments()[0] == commandType?.GetType()
                    );
    }
}
