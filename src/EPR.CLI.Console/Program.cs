using System;
using System.IO;
using Autofac;
using EPR.CLI.Console.Output;
using Microsoft.Extensions.Configuration;

namespace EPR.CLI.Console
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                // ReSharper disable once ArrangeStaticMemberQualifier
                var result =
                    Program
                        .BuildConfig()
                        .Bootstrap()
                        .StartApplication(args);

                return result;

            }
            catch (PowerArgs.ArgException ex)
            {
                new ArgExceptionWriter().Write(ex);
                return 1;
            }
            catch (Exception ex)
            {
                new ExceptionWriter().Write(ex);
                return 1;
            }
            finally
            {
#if DEBUG
                System.Console.ReadKey();
#endif
            }
        }

        private static IConfiguration BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static IContainer Bootstrap(this IConfiguration config)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder
                .Register(x => config)
                .As<IConfiguration>();

            // Internal Modules
            containerBuilder.RegisterModule<Output.Module>();

            // External Modules
            containerBuilder.RegisterModule<Core.Module>();

            return containerBuilder.Build();
        }

        private static int StartApplication(this IContainer container, string[] args)
        {
            return new Application(container).Run(args);
        }
    }
}
