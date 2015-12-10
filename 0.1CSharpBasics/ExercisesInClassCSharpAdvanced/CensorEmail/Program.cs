using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensorEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "dimitar.klaturov@gmail.com";
            string result = CensorEmail(email);
            Console.WriteLine(result);
        }

        static string CensorEmail(string email)
        {
            int indexOf = email.IndexOf("@");
            string censor = new string('*', indexOf);
            string rest = email.Remove(0, indexOf);
            string result = censor + rest;
            return result;
        }
    }
}
