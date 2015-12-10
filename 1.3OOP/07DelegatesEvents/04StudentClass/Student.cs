namespace _04StudentClass
{
    public delegate void EventHandler(Student student, Changed changed);

    public class Student
    {
        private string name;
        private int age;

        public event EventHandler PropertyHandlerChanged;

        public string Name
        {
            get { return name; }
            set
            {
                if (this.PropertyHandlerChanged != null)
                {
                    this.PropertyHandlerChanged(this, new Changed("Name", name, value));
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (this.PropertyHandlerChanged != null)
                {
                    this.PropertyHandlerChanged(this, new Changed("Age", age, value));
                }
                age = value;
            }
        }

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}