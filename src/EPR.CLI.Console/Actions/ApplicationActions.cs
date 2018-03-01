using EPR.CLI.Console.Actions.Options;
using PowerArgs;

namespace EPR.CLI.Console.Actions
{
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    internal class ApplicationActions
    {
        [HelpHook]
        [ArgShortcut("-h")]
        [ArgShortcut("--help")]
        [ArgDescription("Shows help about the available commands.")]
        public bool HelpProvider { get; set; }

        [ArgActionMethod]
        [ArgDescription("An example cli action.")]
        public void Example(ExampleOption args)
        {
        }
    }
}