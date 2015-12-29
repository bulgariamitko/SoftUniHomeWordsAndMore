using System;
using Exam.Interfaces;
using Exam.Models;

namespace Exam.Core
{
    public class Engine : IRunnable
    {
        private readonly ICreateBlobFactory createBlob;
        private readonly IBlobData data;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(ICreateBlobFactory blob, IBlobData data, IInputReader reader, IOutputWriter writer)
        {
            this.createBlob = blob;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                ExecuteCommand(input);
            }
        }

        private void ExecuteCommand(string[] inputParams)
        {
            

            switch (inputParams[0])
            {
                case "create":
                    string name = inputParams[1];
                    int health = int.Parse(inputParams[2]);
                    int attackDamage = int.Parse(inputParams[3]);
                    string behavior = inputParams[4];
                    string attackMethod = inputParams[5];
                    ExecuteCreateCommand(name, health, attackDamage, behavior, attackMethod);
                    break;
                case "attack":
                    string attacker = inputParams[1];
                    string attacked = inputParams[2];
                    ExecuteAttackCommand(attacker, attacked);
                    break;
                case "status":
                    ExecuteStatusCommand();
                    break;
                case "pass":
                    ExecutePassCommand();
                    break;
                case "report-events":
                    //TODO: to be implemented...
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
            }
        }

        private void ExecuteCreateCommand(string name, int health, int attackDamage, string behavior, string attackMethod)
        {
            // probably this code is wrong...
            IBlob blob = createBlob.CreateBlob(name, health, attackDamage);
            data.AddBlob(blob);
        }

        private void ExecuteAttackCommand(string attacker, string attacked)
        {
            foreach (IBlob blob in data.Blobs)
            {
                if (blob.Name != attacker)
                {
                    throw new ArgumentException(String.Format("There is no attacker blob with the name {0}", attacker));
                }
                if (blob.Name != attacked)
                {
                    throw new ArgumentException(String.Format("There is no blob to be attacked with the name {0}", attacked));
                }

            }
            //TODO: the rest of the method...
            
        }

        private void ExecuteStatusCommand()
        {
            foreach (IBlob blob in data.Blobs)
            {
                writer.Print(blob.ToString());
            }
        }

        private void ExecutePassCommand()
        {
            throw new NotImplementedException();
        }
    }
}