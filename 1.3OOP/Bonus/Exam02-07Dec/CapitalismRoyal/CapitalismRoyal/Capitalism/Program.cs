using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitalism.Core;
using Capitalism.Core.Commands;
using Capitalism.Core.Engines;
using Capitalism.Core.Engines.Interfaces;
using Capitalism.Interfaces;

namespace Capitalism
{
    class Program
    {
        static void Main()
        {
            IDatabase db = new Database();
            IEngine engine = new ConsoleCapitalismEngine(db);
            engine.Run();
        }
    }
}
