using System;
using System.Linq;
using System.Text;
using Empires.Interfaces;
using Empires.Models.Buildings;
using Empires.Models.EventArgs;

namespace Empires.Core.Engine
{
    public class Engine : IRunnable
    {
        private IBuildingFactory buildingFactory;
        private IResourceFactory resourceFactory;
        private IUnitFactory unitFactory;
        private IEmpiresData data;
        private IInputReader reader;
        private IOutputWriter writer;

        public Engine(IBuildingFactory buildingFactory, IResourceFactory resourceFactory, IUnitFactory unitFactory, IEmpiresData data, IInputReader reader, IOutputWriter writer)
        {
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
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
                UpdateBuildings();
            }
        }

        private void UpdateBuildings()
        {
            foreach (IBuilding building in data.Buildings)
            {
                building.Update();
            }
        }


        private void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "empire-status":
                    ExecuteStatusCommand();
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                case "skip":
                    break;
                case "build":
                    ExecuteBuildCommand(inputParams[1]);
                    break;
                default:
                    throw new ArgumentException("Unknow command");
            }
        }

        private void AddResource(object sender, ResourceProducedEventArgs e)
        {
            var resource = e.Resource;
            data.Resources[resource.ResourceType] += resource.Quantity;
        }

        private void AddUnit(object sender, UnitProducedEventArgs e)
        {
            var unit = e.Unit;
            data.AddUnit(unit);
        }

        private void ExecuteBuildCommand(string buildingType)
        {
            IBuilding building = this.buildingFactory.CreateBuilding(buildingType, unitFactory, resourceFactory);
            building.OnResourceProduced += AddResource;
            building.OnUnitProduced += AddUnit;
            data.AddBuilding(building);
        }

        private void ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();

            AppendTreasuryInfo(output);
            AppendBuildingInfo(output);
            AppendUnitsInfo(output);

            writer.Print(output.ToString().Trim());
        }

        private void AppendUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");
            if (data.Units.Any())
            {
                foreach (var unit in data.Units)
                {
                    output.AppendFormat("--{0}: {1}{2}", unit.Key, unit.Value, Environment.NewLine);
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendBuildingInfo(StringBuilder output)
        {
            output.AppendLine("Buildings:");
            if (data.Buildings.Any())
            {
                foreach (IBuilding building in data.Buildings)
                {
                    output.AppendLine(building.ToString());
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendTreasuryInfo(StringBuilder output)
        {
            output.AppendLine("Treasury:");
            foreach (var resource in data.Resources)
            {
                output.AppendFormat("--{0}: {1}{2}", resource.Key, resource.Value, Environment.NewLine);
            }
        }
    }
}