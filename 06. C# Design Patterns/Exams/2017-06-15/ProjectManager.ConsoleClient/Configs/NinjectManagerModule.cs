using System;
using System.Linq;

using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {
            // Engine and Database
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            // Providers
            this.Bind<IValidator>().To<Validator>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            
            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>().InSingletonScope();

            this.Bind<ILogger>().To<FileLogger>()
                .InSingletonScope().WithConstructorArgument(configurationProvider.LogFilePath);

            this.Bind<ICachingService>().To<CachingService>()
                .InSingletonScope().WithConstructorArgument(configurationProvider.CacheDurationInSeconds);

            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            // Models Factory
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();

            // Commands Factory
            this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommand>().ToMethod(context =>
            {
                string commandName = (string)context.Parameters.Single().GetValue(context, null);

                try
                {
                    return context.Kernel.Get<ICommand>(commandName);
                }
                catch (Exception)
                {
                    throw new UserValidationException("No such command!");
                }

            }).NamedLikeFactoryMethod((ICommandsFactory commandsFactory) => commandsFactory.GetCommandFromString(null));
        }
    }
}
