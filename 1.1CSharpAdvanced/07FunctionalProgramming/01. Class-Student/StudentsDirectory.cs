using System.Collections.Generic;

namespace Students_Directory
{
    public class StudentsDirectory
    {
        // creating the required List<Student> 
        public List<Student> Students = CreateStudentsDirectory();

        public static List<Student> CreateStudentsDirectory()
        {
            var students = new List<Student>()
            {
                new Student("Dimo", "Padalski", 50, 801231, "02 6123456", "tt@yahoo.com",
                    new List<int>() {4, 2, 6, 5, 3}, 1),
                new Student("Niki", "Kanchev", 42, 801242, "0896123454", "mm@abv.bg",
                    new List<int>() {6, 4, 6, 5, 6}, 2),
                new Student("Vladi", "Vargala", 15, 801253, "+3592612342", "ss@gmail.com",
                    new List<int>() {2, 2, 6, 5, 3}, 1),
                new Student("Kiril", "Hristov", 18, 801214, "+359 2 6123450", "ii@outlook.com",
                    new List<int>() {4, 2, 3, 5, 3}, 2),
                new Student("Bate", "Encho", 22, 801275, "0896123448", "kk@gmail.com",
                    new List<int>() {2, 2, 3, 5, 3}, 3),
                new Student("Lord", "Gandalf", 50, 801214, "0896123446", "ee@abv.bg",
                    new List<int>() {4, 4, 4, 5, 3}, 4)
            };

            return students;
        }
    }
}
