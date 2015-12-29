using System;
using Exam.Core;
using Exam.Core.Factories;
using Exam.IO;
using Exam.Models;

namespace Exam
{
    class Program
    {
        static void Main()
        {
            // the project is NOT working. still to be implemented and possible errors are marked with a command for easy review. 
            // only the 'create' and the 'status' commands are working...
            // thanks for reviewing my project! Wish you a nice day! :)

            var blob = new CreateBlobFactory();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var data = new EngineData();

            var engine = new Engine(blob, data, reader, writer);
            engine.Run();
            //ps: i never got how to apply the behavior... 
        }
    }
}
