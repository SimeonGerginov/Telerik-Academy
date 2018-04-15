using System.Collections.Generic;
using Bytes2you.Validation;

using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private readonly ICachingService cachingService;

        public CacheableCommand(ICommand command, ICachingService cachingService)
        {
            Guard.WhenArgument(command, "Command").IsNull().Throw();
            Guard.WhenArgument(cachingService, "CachingService").IsNull().Throw();

            this.command = command;
            this.cachingService = cachingService;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "Parameters").IsNull().Throw();

            string className = this.command.GetType().Name;
            string methodName = "Execute";
            string result = null;

            if (this.cachingService.IsExpired)
            {
                result = this.command.Execute(parameters);

                this.cachingService.ResetCache();
                this.cachingService.AddCacheValue(className, methodName, result);
            }
            else
            {
                result = (string)this.cachingService.GetCacheValue(className, methodName);
            }

            return result;
        }
    }
}
