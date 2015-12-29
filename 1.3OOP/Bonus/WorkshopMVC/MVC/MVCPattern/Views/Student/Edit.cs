using System;
using MVCPattern.Core.Interfaces.Generic;
using MVCPattern.ViewModels;

namespace MVCPattern.Views.Student
{
    public class Edit : IRenderable<StudentViewModel>
    {
        public void Render()
        {
            Console.WriteLine("AZ SAM EDIT VIEW NA STUDENT");
            Console.WriteLine("MOLQ FULL NAME E: {0}", Model.FullName);
        }

        public StudentViewModel Model { get; set; }
    }
}