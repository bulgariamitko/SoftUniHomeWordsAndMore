namespace BigMani.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Controllers;
    using Data;
    using Exceptions;
    using Interfaces;
    using Models;

    public class Engine
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        private LineExecuting inputting;

        public Engine(IInputReader reader, IOutputWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.inputting = new LineExecuting(line);
                    this.CommandExecuter();
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.Print(ex.Message);
                }
            }
        }

        public void CommandExecuter()
        {
            var commands = this.inputting;
            try
            {
                switch (commands.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(commands, 4);
                        this.RegisterStationaryAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1],
                            commands.Parameters[2],
                            int.Parse(commands.Parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(commands, 3);
                        this.RegisterCarAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1],
                            int.Parse(commands.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(commands, 4);
                        this.RegisterPlaneAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1],
                            int.Parse(commands.Parameters[2]),
                            commands.Parameters[3]);
                        break;
                    case "TestAirConditioner":
                        this.ValidateParametersCount(commands, 2);
                        this.TestAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.ValidateParametersCount(commands, 2);
                        this.FindAirConditioner(
                            commands.Parameters[1],
                            commands.Parameters[0]);
                        break;
                    case "FindReport":
                        this.ValidateParametersCount(commands, 2);
                        this.FindReport(
                            commands.Parameters[0],
                            commands.Parameters[1]);
                        break;
                    case "Status":
                        this.ValidateParametersCount(commands, 0);
                        this.Status();
                        break;
                    case "FindAllReportsByManufacturer":
                        this.ValidateParametersCount(commands, 1);
                        this.FindAllReportsByManufacturer(commands.Parameters[0]);
                        break;
                    default:
                        throw new ArgumentException("Invalid command");
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException("Invalid command", ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException("Invalid command", ex.InnerException);
            }
        }

        public void RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {

            if (energyEfficiencyRating != "A" && energyEfficiencyRating != "B" && energyEfficiencyRating != "C"
                && energyEfficiencyRating != "D" && energyEfficiencyRating != "E")
            {
                throw new ArgumentException("Energy efficiency rating must be between \"A\" and \"E\".");
            }

            if (powerUsage <= 0)
            {
                throw new ArgumentException("Power Usage must be a positive integer.");
            }

            CheckIfModelAlreadyExists(manufacturer, model);

            AirConditioner airConditioner = new AirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            Data.AirConditioners.Add(airConditioner);
            this.writer.Print(
                string.Format(
                    "Air Conditioner model {0} from {1} registered successfully.",
                    airConditioner.Model,
                    airConditioner.Manufacturer));
        }

        public void RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            if (volumeCoverage <= 0)
            {
                throw new ArgumentException("Volume Covered must be a positive integer.");
            }

            CheckIfModelAlreadyExists(manufacturer, model);

            AirConditioner airConditioner = new AirConditioner(manufacturer, model, volumeCoverage);
            Data.AirConditioners.Add(airConditioner);
            this.writer.Print(string.Format("Air Conditioner model {0} from {1} registered successfully.", airConditioner.Model, airConditioner.Manufacturer));
        }

        /// <summary>
        /// Registering a new plane air conditioner
        /// </summary>
        /// <param name="manufacturer"> The name of the manufacture.</param>
        /// <param name="model"> The model of the air conditioner.</param>
        /// <param name="volumeCoverage"> Volume coverage of the air conditioner.</param>
        /// <param name="electricityUsed"> Electricity used of the air conditioner.</param>
        /// <returns>
        /// If success execution it returns a string with the manufacture and model name
        /// </returns>
        /// <seealso cref="ArgumentException(string)">
        /// Notice that the method return ArgumentException if the volume coverage or electricity used is less then 1
        /// </seealso>
        public void RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            if (volumeCoverage <= 0)
            {
                throw new ArgumentException("Volume Covered must be a positive integer.");
            }
            if (Convert.ToInt32(electricityUsed) <= 0)
            {
                throw new ArgumentException("Electricity Used must be a positive integer.");
            }
            CheckIfModelAlreadyExists(manufacturer, model);

            AirConditioner airConditioner = new AirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            Data.AirConditioners.Add(airConditioner);
            this.writer.Print(string.Format("Air Conditioner model {0} from {1} registered successfully.", airConditioner.Model, airConditioner.Manufacturer));
        }

        public void TestAirConditioner(string manufacturer, string model)
        {
            var airConditionerAlreadyExists = Data.GetAirConditioner(manufacturer, model);
            if (airConditionerAlreadyExists == null)
            {
                throw new NonExistantEntryException("The specified entry does not exist.");
            }
            var checkIfReportExist = Data.GetReport(manufacturer, model);
            if (checkIfReportExist != null)
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            AirConditioner airConditioner = Data.GetAirConditioner(manufacturer, model);
            airConditioner.EnergyRating += 5;
            var mark = airConditioner.Test();
            Data.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            this.writer.Print(string.Format("Air Conditioner model {0} from {1} tested successfully.", model, manufacturer));
        }

        /// <summary>
        /// Finds an air conditioner
        /// </summary>
        /// <param name="manufacturer"> The name of the manufacture.</param>
        /// <param name="model"> The model of the air conditioner.</param>
        /// <returns>
        /// If success execution it returns air conditioner
        /// </returns>
        /// <seealso cref="NonExistantEntryException(string)">
        /// Notice that the method return NonExistantEntryException if there is no air conditioner with such name
        /// </seealso>
        public void FindAirConditioner(string manufacturer, string model)
        {
            var airConditionerAlreadyExists = Data.GetAirConditioner(manufacturer, model);
            if (airConditionerAlreadyExists == null)
            {
                throw new NonExistantEntryException("The specified entry does not exist.");
            }

            AirConditioner airConditioner = Data.GetAirConditioner(manufacturer, model);
            this.writer.Print(airConditioner.ToString());
        }

        public void FindReport(string manufacturer, string model)
        {
            var checkIfReportExist = Data.GetReport(manufacturer, model);
            if (checkIfReportExist == null)
            {
                throw new NonExistantEntryException("The specified entry does not exist.");
            }
            Report report = Data.GetReport(manufacturer, model);
            this.writer.Print(report.ToString());
        }

        public void FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = Data.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                this.writer.Print("No reports.");
                return;
            }

            reports = reports.OrderBy(x => x.Model).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            this.writer.Print(reportsPrint.ToString());
        }

        /// <summary>
        /// Displays a number status of all tested air conditioners by % 
        /// </summary>
        /// <param name=""> The method dont have any params</param>
        /// <returns>
        /// If success execution it returns the status fixed to 2 places after the decimal number
        /// </returns>
        public void Status()
        {
            int reports = Data.GetReportsCount();
            double airConditioners = Data.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            this.writer.Print(string.Format("Jobs complete: {0:F2}%", percent));
        }

        public void ValidateParametersCount(LineExecuting command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException("Invalid command");
            }
        }

        private static void CheckIfModelAlreadyExists(string manufacturer, string model)
        {
            var airConditionerAlreadyExists = Data.GetAirConditioner(manufacturer, model);
            if (airConditionerAlreadyExists != null)
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }
        }
    }
}
