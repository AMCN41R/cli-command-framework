using System.Linq;
using Autofac;
using EPR.CLI.Core.Commands;
using EPR.CLI.Core.Common;
using EPR.CLI.Core.Encryption;

namespace EPR.CLI.Core
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Handlers
            var handlerTypes = typeof(Module)
                .Assembly
                .GetTypes()
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                .ToArray();

            builder.RegisterTypes(handlerTypes);

            builder
                .Register(x => new CommandHandlerRegistry(handlerTypes))
                .As<ICommandHandlerRegistry>()
                .SingleInstance();


            // Common
            builder.RegisterType<RequestBuilder>().As<IRequestBuilder>();


            // Encryption
            builder.RegisterType<Base64Encoder>().As<IBase64Encoder>();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();
        }
    }
}
