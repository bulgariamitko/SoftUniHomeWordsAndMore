using System.Collections.Generic;
using Company.Types;

namespace Company.Interfaces
{
    public interface IDeveloper
    {
        List<Project> Projects { get; set; }
        void AddProject(Project project);
    }
}