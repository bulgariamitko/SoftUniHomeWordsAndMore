using Empires.Enums;
using Empires.Interfaces;

namespace Empires.Models.Buildings
{
    public class Archery : Building
    {
        private const string ArcheryUnitType = "Archer";
        private const int ArcheryUnitCycleLength = 3;
        private const ResourceType ArcheryResourceType = ResourceType.Gold;
        private const int ArcheryResourceCycleLength = 2;
        private const int ArcheryRecourseQuantity = 5;

        public Archery(IUnitFactory unitFactory, IResourceFactory resourceFactory)
            : base(ArcheryUnitType, ArcheryUnitCycleLength, ArcheryResourceType, ArcheryResourceCycleLength, ArcheryRecourseQuantity, unitFactory, resourceFactory)
        {

        }
    }
}