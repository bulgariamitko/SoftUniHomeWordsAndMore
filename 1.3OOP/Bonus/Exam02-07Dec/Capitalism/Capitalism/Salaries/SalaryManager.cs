using System;
using System.Linq;
using Capitalism.Core.Interfaces;
using Capitalism.Interfaces;
using Capitalism.Models;

namespace Capitalism.Salaries
{
    public class SalaryManager
    {

        public decimal GetSalary(IEmployee employee, Company company)
        {
            return GetSalaryPercentage(employee, company) * company.Ceo.Salary * employee.SalaryFactor;
        }

        private decimal GetSalaryPercentage(IEmployee employee, Company company)
        {
            decimal salaryPrecentage = 0.15m;
            if (employee.Department == null)
            {
                return salaryPrecentage;
            }
            salaryPrecentage = GetSalaryPercentage(employee.Department.Manager, company) - 0.01m;
            return salaryPrecentage;
        }
    }
}