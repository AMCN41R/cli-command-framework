using EPR.CLI.Core.Commands;

namespace EPR.CLI.Console.Actions
{
    internal interface IOptionConverter
    {
        ICommand Convert();
    }
}