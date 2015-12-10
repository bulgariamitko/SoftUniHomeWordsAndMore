using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05HTMLDispatcher
{
    public class HTMLDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder img = new ElementBuilder("img");
            img.AddAtributes("src", imageSource);
            img.AddAtributes("alt", alt);
            img.AddAtributes("title", title);

            return img.ToString();
        }

        public static string CreateURL(string url2, string title, string text)
        {
            ElementBuilder url = new ElementBuilder("a");
            url.AddAtributes("href", url2);
            url.AddAtributes("title", title);
            url.AddContent(text);

            return url.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAtributes("type", type);
            input.AddAtributes("name", name);
            input.AddAtributes("value", value);

            return input.ToString();
        }
    }
}
