using Empires.Enums;
using Empires.Interfaces;
using Empires.Models.EventArgs;

public delegate void UnitProducedEventHandler(object sender, UnitProducedEventArgs e);

public delegate void ResourceProducedEventHandler(object sender, ResourceProducedEventArgs e);

namespace Empires.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        
        private const int ProductionDelay = 1;
        private int cyclesCount = 0;
        private string unitType;
        private int unitCycleLength;
        private ResourceType resourceType;
        private int resourceCycleLength;
        private int resourceQuantity;
        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;

        protected Building(string unitType, int unitCycleLength, ResourceType resourceType, int resourceCycleLength, int resourceQuantity, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.unitCycleLength = unitCycleLength;
            this.resourceType = resourceType;
            this.resourceCycleLength = resourceCycleLength;
            this.resourceQuantity = resourceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        private bool CanProduceResource
        {
            get
            {
                bool canProduceResource = cyclesCount > ProductionDelay && (cyclesCount - ProductionDelay) % resourceCycleLength == 0;
                return canProduceResource;
            }
        }

        private bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = cyclesCount > ProductionDelay && (cyclesCount - ProductionDelay)%unitCycleLength == 0;
                return canProduceUnit;
            }
        }

        public IResource ProduceResource()
        {
            var resource = this.resourceFactory.CreateResource(this.resourceType, resourceQuantity);
            return resource;
        }
        
        public IUnit ProduceUnit()
        {
            var unit = this.unitFactory.CreateUnit(this.unitType);
            return unit;
        }
        
        public void Update()
        {
            cyclesCount++;
            if (CanProduceResource)
            {
                if (OnResourceProduced != null)
                {
                    var resource = resourceFactory.CreateResource(resourceType, resourceQuantity);
                    OnResourceProduced(this, new ResourceProducedEventArgs { Resource = resource });
                }
            }
            if (CanProduceUnit)
            {
                if (OnUnitProduced != null)
                {
                    var unit = unitFactory.CreateUnit(unitType);
                    OnUnitProduced(this, new UnitProducedEventArgs {Unit = unit});
                }
            }
        }

        public override string ToString()
        {
            int turnsUntilUnit = unitCycleLength - (cyclesCount - ProductionDelay) % unitCycleLength;
            int turnsUntilResources = resourceCycleLength - (cyclesCount - ProductionDelay) % resourceCycleLength;
            var result = string.Format("--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})",
                GetType().Name, cyclesCount - ProductionDelay, turnsUntilUnit, unitType, turnsUntilResources, resourceType);
            return result;
        }

        public event UnitProducedEventHandler OnUnitProduced;
        public event ResourceProducedEventHandler OnResourceProduced;
    }
}