using Autofac;
using EPR.CLI.Console.Actions;
using EPR.CLI.Console.Output;
using EPR.CLI.Core.Commands;
using PowerArgs;

namespace EPR.CLI.Console
{
    internal class Application
    {
        public Application(IContainer container)
        {
            this.Container = container;
        }

        private IContainer Container { get; }

        public int Run(string[] args)
        {
            var parsed = Args.InvokeAction<ApplicationActions>(args);

            if (parsed.ActionArgs is null)
            {
                if (parsed.HandledException != null)
                {
                    // additional custom exception handling
                }

                return 1;
            }

            if (parsed.Cancelled)
            {
                return 0;
            }

            return this.Execute(parsed.ActionArgs);
        }

        private int Execute(object arg)
        {
            var command = ((IOptionConverter)arg).Convert();

            var handlerType = this
                .Container
                .Resolve<ICommandHandlerRegistry>()
                .GetByCommand(command);

            var handler = this.Container.Resolve(handlerType);

            this.ExecuteCommand(handler, (dynamic)command);
            
            return 0;
        }

        private void ExecuteCommand<T>(dynamic commandHandler, T command) where T : ICommand
        {
            var handler = (ICommandHandler<T>)commandHandler;

            var result = handler.Validate(command);

            if (!result.IsValid)
            {
                throw new OptionValidationException(result.Reason);
            }

            foreach (var progress in handler.Execute(command))
            {
                this
                    .Container
                    .Resolve<IConsoleWriter<CommandProgress>>()
                    .Write(progress);
            }
        }
    }
}