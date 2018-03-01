namespace EPR.CLI.Console.Output
{
    internal interface IConsoleWriter<in T>
    {
        void Write(T item);
    }
}