using System;
using System.Linq;
using System.Reflection;
using Empires.Interfaces;

namespace Empires.Core.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            // Reflection
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.ToLowerInvariant() == buildingType);
            if (type == null)
            {
                throw new AggregateException("Unknow building type");
            }
            var building = (IBuilding)Activator.CreateInstance(type, unitFactory, resourceFactory);

            return building;
        }
    }
}