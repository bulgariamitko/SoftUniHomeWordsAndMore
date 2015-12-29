using System;
using System.Collections.Generic;
using System.Linq;
using Capitalism.Core.Interfaces;

namespace Capitalism.Core
{
    public class Command : ICommand
    {
        public Command(string commandString)
        {
            string[] commandParts = commandString.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);
            Name = commandParts[0];
            if (commandParts.Length > 1)
            {
                Parameters = commandParts.Skip(1).ToArray();
            }
        }

        public string Name { get; set; }
        public IList<string> Parameters { get; set; }
        
    }
}