using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers01
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Book title is empty!");
                }
                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Author name is empty!");
                }
                author = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cant be negative!");
                }
                price = value;
            }
        }

        public Book(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("-Type: {0}{1}", GetType().Name, Environment.NewLine);
            output.AppendFormat("-Title: {0}{1}", title, Environment.NewLine);
            output.AppendFormat("-Author: {0}{1}", author, Environment.NewLine);
            output.AppendFormat("-Price: {0}{1}", price, Environment.NewLine);

            return output.ToString();
        }
    }
}
