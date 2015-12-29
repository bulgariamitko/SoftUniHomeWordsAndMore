using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using Capitalism.Core.Interfaces;
using Capitalism.Core.Interfaces.UserInterfaces;
using Capitalism.Departments;
using Capitalism.Interfaces;
using Capitalism.Models;
using Capitalism.Salaries;

namespace Capitalism.Core
{
    public class CapitalismCommandExecutor : ICommandExecutor
    {
        private const string BaseModelNamespace = "Capitalism.Models.";
        private IDatabase database;
        private SalaryManager salaryManager;

        public CapitalismCommandExecutor()
        {
            this.database = new CapitalismDatabase();
            this.salaryManager = new SalaryManager();
        }

        public string ExecuteCommand(ICommand command)
        {
            string commandResult = null;
            //TODO: switch casing...
            switch (command.Name)
            {
                case "create-company":
                    commandResult = ExecuteCreateCompanyCommand(command);
                    break;
                case "create-employee":
                    commandResult = ExecuteCreateEmployeeCommand(command);
                    break;
                case "create-department":
                    commandResult = ExecuteCreateDepartmentCommand(command);
                    break;
                case "pay-salaries":
                    commandResult = ExecutePaySalariesCommand(command);
                    break;
                case "show-employees":
                    commandResult = ExecuteShowEmployiesCommand(command);
                    break;
                case "end":
                    break;
                default:
                    throw new InvalidOperationException("The command name is invalid!");
            }
            return commandResult;
        }

        private string ExecuteCreateEmployeeCommand(ICommand command)
        {
            string firstName = command.Parameters[0];
            string lastName = command.Parameters[1];
            string companyName = command.Parameters[3];
            var company = database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return String.Format("Company {0} does not exists!", companyName);
            }
            if (company.Employees.Any(e => e.FirstName == firstName && e.LastName == lastName))
            {
                return String.Format("Empoyee {0} {1} already exists in {2} (no department)", firstName, lastName, company.Name);
            }
            var firstConflictingEmpoyee =
                company.Departments.SelectMany(d => d.Employees)
                    .FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);
            if (firstConflictingEmpoyee != null)
            {
                return String.Format("Empoyee {0} {1} already exists in {2} (no department {3})", firstName, lastName, company.Name, firstConflictingEmpoyee.Department.Name);
            }

            var employeeTypeName = command.Parameters[2];
            var employeeType = Assembly.GetExecutingAssembly().GetType(BaseModelNamespace + employeeTypeName);
            var employee = Activator.CreateInstance(employeeType, new object[] {firstName, lastName}) as IEmployee;
            if (command.Parameters.Count == 4)
            {
                company.Employees.Add(employee);
                company.Ceo.SubordinateEmployees.Add(employee);
            }
            else
            {
                string departmentName = command.Parameters[4];
                var department = company.Departments.FirstOrDefault(d => d.Name == command.Parameters[4]);
                if (department == null)
                {
                    department =
                    company.Departments.SelectMany(d => d.SubDepartments)
                        .FirstOrDefault(sd => sd.Name == departmentName);
                }
                if (department == null)
                {
                    return String.Format("Department {0} does not exist in compant {1}", departmentName, companyName);
                }
                department.Employees.Add(employee);
                department.Manager.SubordinateEmployees.Add(employee);
                employee.Department = department;
            }
            // cal the salary
            decimal salary = salaryManager.GetSalary(employee, company);
            employee.Salary = salary;
            database.TotalSalaries[employee] = 0m;
            return null;
        }

        private string ExecutePaySalariesCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return String.Format("Company {0} does not exist!", companyName);
            }
            var output = new StringBuilder();
            database.TotalSalaries[company.Ceo] += company.Ceo.Salary;
            decimal totalMoneyPaid = company.Ceo.Salary;
            foreach (var employee in company.Employees)
            {
                database.TotalSalaries[employee] += employee.Salary;
                totalMoneyPaid += employee.Salary;
            }
            foreach (var department in company.Departments)
            {
                totalMoneyPaid += PaySalariesToDepartment(department, output, 1);
            }
            output.AppendFormat("{0} ({1:F2})", company.Name, totalMoneyPaid).AppendLine();
            return string.Join(Environment.NewLine, output.ToString().Split(new [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Reverse());
        }

        private string ExecuteShowEmployiesCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return String.Format("Company {0} does not exist!", companyName);
            }
            var output = new StringBuilder();
            output.AppendFormat("({0})", companyName).AppendLine();
            output.AppendFormat("{0} {1} ({2:F2})", company.Ceo.FirstName, company.Ceo.LastName, database.TotalSalaries[company.Ceo]).AppendLine();
            foreach (var employee in company.Employees)
            {
                output.AppendFormat("{0} {1} ({2:F2})", employee.FirstName, employee.LastName, database.TotalSalaries[employee]).AppendLine();
            }
            foreach (var department in company.Departments)
            {
                DisplayDepartment(department, output, 1);
            }
            return output.ToString();
        }

        private void DisplayDepartment(Department department, StringBuilder output, int departmentLevel)
        {
            output.AppendFormat("{0}({1})",new string(' ', departmentLevel * 4), department.Name).AppendLine();
            foreach (var employee in department.Employees)
            {
                output.AppendFormat("{0}{1} {2} ({3:F2})",new string(' ', 4 * departmentLevel), employee.FirstName, employee.LastName, database.TotalSalaries[employee]).AppendLine();
            }
            foreach (var subDepartment in department.SubDepartments)
            {
                DisplayDepartment(subDepartment, output, departmentLevel + 1);
            }
        }

        private decimal PaySalariesToDepartment(Department department, StringBuilder output, int departmentLevel)
        {
            decimal totalMoneyPerDepartment = 0m;
            foreach (var employee in department.Employees)
            {
                database.TotalSalaries[employee] += employee.Salary;
                totalMoneyPerDepartment += employee.Salary;
            }
            foreach (var subDepartment in department.SubDepartments)
            {
                totalMoneyPerDepartment += PaySalariesToDepartment(subDepartment, output, departmentLevel + 1);
            }
            output.AppendFormat("{0}{1} ({2:F2})", new string(' ', 4 * departmentLevel), department.Name, totalMoneyPerDepartment).AppendLine();
            return totalMoneyPerDepartment;
        }

        private string ExecuteCreateCompanyCommand(ICommand command)
        {
            var ceo = new Ceo(command.Parameters[1], command.Parameters[2], decimal.Parse(command.Parameters[3]));
            database.TotalSalaries[ceo] = 0m;
            var company = new Company(command.Parameters[0], ceo);
            if (database.Companies.Any(c => c.Name == company.Name))
            {
                return string.Format("Company {0} already exists", company.Name);
            }
            this.database.Companies.Add(company);
            return null;
        }

        private string ExecuteCreateDepartmentCommand(ICommand command)
        {
            var companyName = command.Parameters[0];
            var company = database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return string.Format("Company {0} does not exist!", companyName);
            }
            if (command.Parameters.Count == 4)
            {
                return ExecuteCreateDepartmentInCompanyComand(command, company);
            }
            return ExecuteCreateSubDepartmentInCompanyComand(command, company);
        }

        private string ExecuteCreateSubDepartmentInCompanyComand(ICommand command, Company company)
        {
            var mainDepartment = company.Departments.FirstOrDefault(d => d.Name == command.Parameters[4]);
            if (mainDepartment == null)
            {
                return String.Format("There is no department {0} in company {1}", command.Parameters[4], company.Name);
            }
            var manager = GetEmployeeByName(mainDepartment, command.Parameters[2], command.Parameters[3]);
            if (manager == null)
            {
                return String.Format("There is no employee called {0} {1} in department {3}", command.Parameters[2], command.Parameters[3], mainDepartment.Name);
            }
            try
            {
                CheckEmployeeIsManager(manager);
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
            if (mainDepartment.SubDepartments.Any(sd => sd.Name == command.Parameters[1]))
            {
                return String.Format("Departament {0} already exists in {2}", command.Parameters[1], mainDepartment.Name);
            }
            // if (mainDepartment.Employees.Where(e => e is Manager).Cast<Manager>().Any(m => company.Departments.Select(d => d.Manager).Contains(m)))
            if (company.Departments.Any(d => command.Parameters[1] == d.Name))
            {
                return String.Format("Departament {0} already exists in {2}", command.Parameters[1], company.Name);
            }
            var department = new Department(command.Parameters[1], manager as Manager);
            mainDepartment.SubDepartments.Add(department);
//            company.Departments.Add(department);
            return null;
        }

        private string ExecuteCreateDepartmentInCompanyComand(ICommand command, Company company)
        {
            var manager = GetEmployeeByName(company, command.Parameters[2], command.Parameters[3]);
            if (manager == null)
            {
                return string.Format("There is no employee called {0} {1} in {3}", command.Parameters[2], command.Parameters[3], company.Name);
            }
            try
            {
                CheckEmployeeIsManager(manager);
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }

            if (company.Departments.Any(d => d.Name == command.Parameters[1]))
            {
                return String.Format("Departament {0} already exists in {2}", command.Parameters[1], company.Name);
            }
            var department = new Department(command.Parameters[1], manager as Manager);
            company.Departments.Add(department);
            return null;
        }

        private static void CheckEmployeeIsManager(IEmployee employToCheck)
        {
            if (!(employToCheck is Manager))
            {
                string position = employToCheck.GetType().Name;
                string realPosition = position[0].ToString();
                for (int i = 1; i < position.Length; i++)
                {
                    if (realPosition[i].ToString().ToUpper() == realPosition[i].ToString())
                    {
                        realPosition = " " + position[i];
                    }
                    else
                    {
                        realPosition += position[i];
                    }
                }
                throw new ArgumentException(String.Format("{0} {1} is not a manager (real position: {2})", employToCheck.FirstName, employToCheck.LastName, realPosition));
            }
        }

        private static IEmployee GetEmployeeByName(ICompanyStructure structure, string firstName, string lastName)
        {
            return
                structure.Employees.FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);
        }
    }
}