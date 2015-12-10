using System.IO;
using Novacode;

namespace _05WordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DocX doc = DocX.Create(@"../../NewWordDoc.docx"))
            {
                //Image img = doc.AddImage(@"../../rpg-game.png");
                string text = File.ReadAllText(@"../../text.txt");
                doc.InsertParagraph(text);
                doc.AddImage(@"../../rpg-game.png");
                doc.Save();
            }
        }
    }
}
