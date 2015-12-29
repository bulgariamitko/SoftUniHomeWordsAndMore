using System;
using Capitalism.Core.Commands;
using Capitalism.Core.Engines.Interfaces;
using Capitalism.Interfaces;

namespace Capitalism.Core.Engines
{
    public class ConsoleCapitalismEngine : IEngine
    {
        private readonly IDatabase db;

        public ConsoleCapitalismEngine(IDatabase db)
        {
            this.db = db;
        }

        public void Run()
        {
            IExecutable command = null;
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "create-company":
                        command = new CreateCompanyCommand(db, tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        break;
                    case "create-employee":
                        string departmentName = null;
                        if (tokens.Length > 5)
                        {
                            departmentName = tokens[5];
                        }
                        command = new CreateEmployeeCommand(db, tokens[1], tokens[2], tokens[3], tokens[4], departmentName);
                        break;
                    case "create-department":
                        string mainDepartment = null;
                        if (tokens.Length > 5)
                        {
                            mainDepartment = tokens[5];
                        }
                        command = new CreateDepartmentCommand(db, tokens[1], tokens[2], tokens[3], tokens[4], mainDepartment);
                        break;
                    case "pay-salaries":
                        command = new PaySalariesCommand(db, tokens[1]);
                        break;
                    case "show-employees":
                        command = new ShowEmployiesCommand(db, tokens[1]);
                        break;
                }

                try
                {
                    Console.Write(command.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    line = Console.ReadLine();
                }
            }
        }
    }
}