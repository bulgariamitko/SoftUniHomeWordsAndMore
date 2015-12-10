namespace _02Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private char gender;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        protected Animal(string name, int age, char gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

    }
}