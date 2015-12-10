using System;
using Exers02.Interfaces;

namespace Exers02.Ships
{
    public class Warship : Battleship
    {
        public Warship(string name, double lengthInMeters, double volume) : base(name, lengthInMeters, volume)
        {

        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "Victory is our!";
        }
    }
}