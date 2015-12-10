using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public class OnsiteStudent : CurrentStudent
    {
        private int numOfVisits;

        public int NumOfVisits
        {
            get { return numOfVisits; }
            set { numOfVisits = value; }
        }

        public OnsiteStudent(string firstName, string lastName, int age, int studentNum, double averageGrade, string currentCourse, int numOfVisits) : base(firstName, lastName, age, studentNum, averageGrade, currentCourse)
        {
            this.numOfVisits = numOfVisits;
        }
    }
}
