using System;
using Empires.Buildings.Units;
using Empires.Interfaces;

namespace Empires.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return new Swordsman();
                default:
                    throw new ArgumentException("Unknow unit type");
            }
        }
    }
}