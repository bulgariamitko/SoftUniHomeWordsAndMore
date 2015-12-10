namespace _01CustomLINQ
{
    public class Student
    {
        string name;
        int grade;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }
}