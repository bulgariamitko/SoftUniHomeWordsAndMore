using Capitalism.Core;
using Capitalism.Core.Interfaces;

namespace Capitalism
{
    class Program
    {
        public static void Main()
        {
            IEngine engine = new CapitalismEngine();
            engine.Run();
        }
    }
}
