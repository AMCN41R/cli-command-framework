namespace EPR.CLI.Core.Commands.Example
{
    public class ExampleCommand : ICommand
    {
        public ExampleCommand(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
