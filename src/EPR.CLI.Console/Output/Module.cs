using System;
using Autofac;
using EPR.CLI.Core.Commands;

namespace EPR.CLI.Console.Output
{
    internal class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CommandProgressWriter>()
                .As<IConsoleWriter<CommandProgress>>()
                .SingleInstance();

            builder
                .RegisterType<ArgExceptionWriter>()
                .As<IConsoleWriter<PowerArgs.ArgException>>()
                .SingleInstance();

            builder
                .RegisterType<ExceptionWriter>()
                .As<IConsoleWriter<Exception>>()
                .SingleInstance();
        }
    }
}
