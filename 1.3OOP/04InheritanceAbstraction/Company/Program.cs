using System;
using System.Collections.Generic;
using Company.Types;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Project project1 = new Project("Zaludo raboti", new DateTime(2014, 02, 12), "zaludo bez rabota ne stoj!", true);
            Project project2 = new Project("Prituri se planinata", new DateTime(2015, 01, 01), "...", true);
            Project project3 = new Project("Probiwame dupki wsqkakwi", new DateTime(2014, 11, 20), "...", true);
            Project project4 = new Project("Svobodata, Sancho!", new DateTime(2013, 05, 05), "Dulcinea", true);
            Project project5 = new Project("S curvuli po divia zapad", new DateTime(2015, 02, 19), "...", false);

            Sale sale1 = new Sale("Tic-Tac", new DateTime(2014, 07, 08), 2.50);
            Sale sale2 = new Sale("Oreo", new DateTime(2013, 05, 10), 15.0);
            Sale sale3 = new Sale("Perwoll", new DateTime(2015, 09, 26), 100.0);
            Sale sale4 = new Sale("Samsung Galaxy S6", new DateTime(2015, 05, 19), 1049.90);
            Sale sale5 = new Sale("LG G4", new DateTime(2015, 03, 05), 839.90);
            Sale sale6 = new Sale("ALCATEL ONETOUCH IDOL 3-4.7", new DateTime(2015, 04, 16), 199.90);
            Sale sale7 = new Sale("Huawei Ascend Y600", new DateTime(2015, 03, 15), 19.90);
            Sale sale8 = new Sale("Microsoft Lumia 435 Dual", new DateTime(2014, 12, 19), 4.90);

            Customer cust1 = new Customer(826551245, "Borislav", "Ananiev");
            Customer cust2 = new Customer(486538746, "Detelin", "Tsvetkov");
            Customer cust3 = new Customer(948765987, "Anton", "Dragichev");

            Developer dev1 = new Developer(23328582, "Georgi", "Georgiev", 1500, Department.Production);
            Developer dev2 = new Developer(2627535, "Tihomir", "Dimitrov", 1800, Department.Marketing, project1, project3, project4);
            Developer dev3 = new Developer(95869522, "Vasil", "Naydenov", 1650, Department.Accounting, project1, project4, project5);

            SalesEmployee salempl1 = new SalesEmployee(872822223, "Krasimir", "Yordanov", 1900, Department.Sales, sale1, sale2, sale3);
            SalesEmployee salempl2 = new SalesEmployee(288252565, "Ivan", "Popov", 2500, Department.Sales, sale4, sale5, sale6);
            SalesEmployee salempl3 = new SalesEmployee(288252565, "Mario", "Lyaskov", 1050, Department.Sales, sale7, sale8);

            Manager boss1 = new Manager(652341265, "Evgeni", "Manchev", 3000, Department.Accounting, dev3);
            Manager boss2 = new Manager(37426423, "Oleg", "Zapryanov", 3500, Department.Sales, salempl1, salempl2, salempl3);
            Manager boss3 = new Manager(92308748, "Radostina", "Koleva", 3250, Department.Marketing, dev1, dev2);

            dev1.AddProject(project1);
            project2.CloseProject();
            project5.CloseProject();

            cust1.AddPerchuse(25.44);
            cust2.AddPerchuse(454.00);
            cust3.AddPerchuse(4451.44);

            List<Person> persons = new List<Person>()
            {
                cust1,
                cust2,
                cust3,
                dev1,
                dev2,
                dev3,
                salempl1,
                salempl2,
                salempl3,
                boss1,
                boss2,
                boss3
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
