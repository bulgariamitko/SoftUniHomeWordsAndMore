using Empires.Enums;
using Empires.Interfaces;

namespace Empires.Models.Buildings
{
    public class Barracks : Building
    {
        private const string BarracksUnitType = "Swordsman";
        private const int BarracksUnitCycleLength = 4;
        private const ResourceType BarracksResourceType = ResourceType.Steel;
        private const int BarracksRecourceCycleLength = 3;
        private const int BarracksRecourseQuantity = 10;

        public Barracks(IUnitFactory unitFactory, IResourceFactory resourceFactory)
            : base(BarracksUnitType, BarracksUnitCycleLength, BarracksResourceType, BarracksRecourceCycleLength, BarracksRecourseQuantity, unitFactory, resourceFactory)
        {
        }
    }
}