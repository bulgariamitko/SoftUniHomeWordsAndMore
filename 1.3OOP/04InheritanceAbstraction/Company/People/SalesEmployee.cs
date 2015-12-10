using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Interfaces;
using Company.Types;

namespace Company
{
    public class SalesEmployee : Employee, ISalesEmployee
    {
        private List<Sale> sales = new List<Sale>();

        public List<Sale> Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public SalesEmployee(int id, string firstName, string lastName, double salary, Department department, params Sale[] sales) : base(id, firstName, lastName, salary, department)
        {
            Sales = sales.ToList();
        }

        public void AddSale(Sale sale)
        {
            sales.Add(sale);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Seller: {0} {1}, Department: {2}, Salary: {3}, Sales:\r\n", FirstName, LastName,
                Department, Salary));
            foreach (var sale in Sales)
            {
                output.Append(sale);
            }
            return output.ToString();
        }
    }
}