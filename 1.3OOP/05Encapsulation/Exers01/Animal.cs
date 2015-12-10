namespace Exers01
{
    using System;

    public abstract class Animal
    {
        private const int MinAnimalAge = 0;
        private const int MaxAnimalAge = 15;

        private string name;
        protected int age;

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }

            private set
            {
                if (value < MinAnimalAge || value > MaxAnimalAge)
                {
                    throw new ArgumentOutOfRangeException("value", "Age cannot be negative.");
                }
                age = value;
            }
        }

        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public double ProductPerDay
        {
            get
            {
                return CalculateProductPerDay();
            }
        }

        public abstract Product ProduceProduct();

        public abstract double GetHumanAge();

        private double CalculateProductPerDay()
        {
            switch (age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
