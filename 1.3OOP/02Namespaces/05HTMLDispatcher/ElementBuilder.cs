using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05HTMLDispatcher
{
    public class ElementBuilder
    {
        private string element;

        public ElementBuilder(string name)
        {
            this.element = string.Format("<{0}></{0}>", name);
        }

        public void AddAtributes(string attribute, string value)
        {
            int insertIndex = this.element.IndexOf('>');
            string insertAttr = string.Format(" {0}=\"{1}\"", attribute, value);
            this.element = this.element.Insert(insertIndex, insertAttr);
        }

        public void AddContent(string content)
        {
            int insertIndex = this.element.IndexOf('>') + 1;
            this.element = this.element.Insert(insertIndex, content);
        }

        public static string operator *(ElementBuilder element, int multiplyer)
        {
            string result = null;
            for (int i = 0; i < multiplyer; i++)
            {
                result += element.ToString();
            }
            return result;
        }

        public override string ToString()
        {
            return element;
        }
    }
}
