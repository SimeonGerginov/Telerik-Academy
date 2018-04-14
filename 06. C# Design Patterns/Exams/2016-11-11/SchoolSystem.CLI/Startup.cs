using Ninject;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new SchoolSystemModule());

            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}