using Empires.Enums;
using Empires.Interfaces;

namespace Empires.Models.Buildings
{
    public class Stable : Building
    {
        public Stable(IUnitFactory unitFactory, IResourceFactory resourceFactory) : base("Archer", 2, ResourceType.Gold, 6, 11, unitFactory, resourceFactory)
        {

        }
    }
}