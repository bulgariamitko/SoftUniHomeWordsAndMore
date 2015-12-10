using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers01
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
        {

        }

        public override decimal Price
        {
            get { return Price * 1.3M; }
        }
    }
}
