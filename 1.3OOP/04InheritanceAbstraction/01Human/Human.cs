namespace _01Human
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        protected Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}