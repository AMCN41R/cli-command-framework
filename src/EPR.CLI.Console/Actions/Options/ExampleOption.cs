using EPR.CLI.Core.Commands;
using EPR.CLI.Core.Commands.Example;
using PowerArgs;

namespace EPR.CLI.Console.Actions.Options
{
    public class ExampleOption : IOptionConverter
    {
        [ArgPosition(1)]
        [ArgRequired]
        [ArgDescription("An example message.")]
        public string Message { get; set; }

        public ICommand Convert()
        {
            return new ExampleCommand(this.Message);
        }
    }
}
