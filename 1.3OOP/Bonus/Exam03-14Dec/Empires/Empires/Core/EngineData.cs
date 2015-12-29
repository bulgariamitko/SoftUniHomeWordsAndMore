using System;
using System.Collections.Generic;
using Empires.Enums;
using Empires.Interfaces;

namespace Empires.Core.Engine
{
    public class EngineData : IEmpiresData
    {
        private readonly ICollection<IBuilding> buildings = new List<IBuilding>();

        public EngineData()
        {
            Resources = new Dictionary<ResourceType, int>();
            Units = new Dictionary<string, int>();
            this.InitResources();
        }

        private void InitResources()
        {
            var resourceTypes = Enum.GetValues(typeof (ResourceType));

            foreach (ResourceType resourceType in resourceTypes)
            {
                this.Resources.Add(resourceType, 0);
            }
        }

        public IEnumerable<IBuilding> Buildings => this.buildings;
        public IDictionary<string, int> Units { get; }
        public IDictionary<ResourceType, int> Resources { get; }

        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }
            this.buildings.Add(building);
        }

        public void AddUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            var unitType = unit.GetType().Name;
            if (!Units.ContainsKey(unitType))
            {
                Units.Add(unitType, 0);
            }
            Units[unitType]++;
        }
    }
}