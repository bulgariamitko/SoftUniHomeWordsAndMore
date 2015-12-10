using System;

namespace Answer02
{
    class CompanyInformation
    {
        static void Main()
        {
            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Enter company phone number: ");
            int companyPhone = int.Parse(Console.ReadLine());

            Console.Write("Enter company fax number: ");
            int companyFax = int.Parse(Console.ReadLine());

            Console.Write("Enter manager first name: ");
            string mFirstName = Console.ReadLine();

            Console.Write("Enter manager last name: ");
            string mLastName = Console.ReadLine();

            Console.Write("Enter manager age: ");
            byte managerAge = byte.Parse(Console.ReadLine());

            Console.Write("Enter manager phone number: ");
            int managerPhone = int.Parse(Console.ReadLine());

            Console.WriteLine(" Company name: {0}\n Company phone: {1}\n Company fax: {2}\n Manager first name: {3}\n Manager last name: {4}\n Manager age {5}\n Manager phone number: {6}", companyName, companyPhone, companyFax, mFirstName, mLastName, managerAge, managerPhone);
        }
    }
}
