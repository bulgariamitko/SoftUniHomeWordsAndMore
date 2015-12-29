using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02Customer
{
    public class Customer : IComparable<Customer>, ICloneable
    {
        public Customer(string firstName, string middleName, string lastName, long id, string permanentAddress, long mobilePhone, string email, CustomerType customerType, params Payment[] payments)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.CustomerType = customerType;
            this.Payments = new List<Payment>(payments);
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public long Id { get; set; }

        public string PermanentAddress { get; set; }

        public long MobilePhone { get; set; }

        public string Email { get; set; }

        public IList<Payment> Payments { get; set; }

        public CustomerType CustomerType { get; private set; }

        public object Clone()
        {
            string firstName = this.FirstName;
            string middleName = this.MiddleName;
            string lastName = this.LastName;
            long id = this.Id;
            string permanentAddress = this.PermanentAddress;
            long mobilePhone = this.MobilePhone;
            string email = this.Email;
            CustomerType cloningCustomerType = this.CustomerType;
            IList<Payment> cloningPayments = new List<Payment>(this.Payments);

            return new Customer(firstName, middleName, lastName, id, permanentAddress, mobilePhone, email, cloningCustomerType, cloningPayments.ToArray());
        }

        public int CompareTo(Customer otherCustomer)
        {
            string thisCustomerFullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string otherCustomerFullName = otherCustomer.FirstName + " " + otherCustomer.MiddleName + " " + otherCustomer.LastName;

            if (thisCustomerFullName != otherCustomerFullName)
            {
                return string.Compare(thisCustomerFullName, otherCustomerFullName, StringComparison.InvariantCulture);
            }

            return this.Id.CompareTo(otherCustomer.Id);
        }

        public override bool Equals(object obj)
        {
            Customer otherCustomer = obj as Customer;

            if (otherCustomer == null)
            {
                return false;
            }

            if (!Equals(this.Id, otherCustomer.Id))
            {
                return false;
            }

            if (!Equals(this.CustomerType, otherCustomer.CustomerType))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(Equals(customer1, customer2));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.Id.GetHashCode() ^ this.CustomerType.GetHashCode();
        }

        public override string ToString()
        {
            var customer = new StringBuilder();

            customer.AppendLine(string.Format(
                "Customer: {0} {1} {2} ID: {3}",
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id));

            customer.AppendLine(string.Format(
                "Contacts: mobile phone: {0}, email: {1}",
                this.MobilePhone,
                this.Email));

            return customer.ToString();
        }
    }
}