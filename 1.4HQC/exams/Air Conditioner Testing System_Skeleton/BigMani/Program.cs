namespace BigMani
{
    using BigMani.Core;
    using BigMani.IO;

    public class Program
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
