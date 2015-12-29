using System;
using MVCPattern.Core.Interfaces;
using MVCPattern.Core.Interfaces.Generic;
using MVCPattern.ViewModels;

namespace MVCPattern.Views.Home
{
    public class Index : IRenderable
    {

        public void Render()
        {
            Console.WriteLine("MY FIRST VIEW!");
        }

//        public IndexViewModel Model { get; set; }
    }
}