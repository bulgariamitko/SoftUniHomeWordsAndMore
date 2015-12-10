using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer indiv1 = new Individuals("Ivan Ivanov", 9786478787874);
            Customer indiv2 = new Individuals("Georgi Georgiev", 394854398348);
            Customer comp = new Companies("IBM", 3984573498);

            Deposit acc1 = new Deposit(indiv1, 980, 0.05m);
            Account acc2 = new Loan(comp, 15000, 0.25m);
            Account acc3 = new Mortgage(indiv2, 65000, 0.15m);

            Console.WriteLine(acc1.CalInterest(6));
            acc1.DepositMoney(550);
            acc1.Withdraw(111);

            Console.WriteLine(acc1.CalInterest(16));
            Console.WriteLine(acc2.CalInterest(44));
            Console.WriteLine(acc3.CalInterest(24));
        }
    }
}
