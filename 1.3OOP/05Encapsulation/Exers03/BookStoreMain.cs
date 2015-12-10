using Exers03.Engine;
using Exers03.Interfaces;
using Exers03.UI;

namespace Exers03
{
    public class BookStoreMain
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            BookStoreEngine engine = new BookStoreEngine(renderer, inputHandler);

            engine.Run();
        }
    }
}
