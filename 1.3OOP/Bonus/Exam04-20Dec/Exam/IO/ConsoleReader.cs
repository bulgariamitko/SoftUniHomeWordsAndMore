﻿using System;
using Exam.Interfaces;

namespace Exam.IO
{
    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}