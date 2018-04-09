using ProjectManager.Core;
using ProjectManager.Core.Contracts;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            IEngine engine = new Engine(null, null, null, null);

            engine.Start();
        }
    }
}
