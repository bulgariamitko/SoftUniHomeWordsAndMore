using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Interfaces;
using Company.Types;

namespace Company
{
    public class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> projects = new List<Project>();

        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public void AddProject(Project project)
        {
            Projects.Add(project);
        }

        public Developer(int id, string firstName, string lastName, double salary, Department department, params Project[] projects) : base(id, firstName, lastName, salary, department)
        {
            Projects = projects.ToList();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Developer: {0} {1}, Department {2}, Salary: {3}, Projects\r\n", FirstName,
                LastName, Department, Salary));
            foreach (var project in Projects)
            {
                output.Append(project);
            }
            return output.ToString();
        }
    }
}