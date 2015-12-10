using System;
using Exers02.Interfaces;

namespace Exers02.Ships
{
    public class AircraftCarrier : Battleship, IAttack
    {
        private int fighterCapacity;

        public int FighterCapacity
        {
            get
            {
                return this.fighterCapacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The fighter capacity of an aircraft carrier cannot be negative.");
                }

                this.fighterCapacity = value;
            }
        }

        public AircraftCarrier(string name, double lengthInMeters, double volume, int fighterCapacity) : base(name, lengthInMeters, volume)
        {
            this.FighterCapacity = fighterCapacity;
        }

        public override string Attack(Ship target)
        {
            this.DestroyTarget(target);
            return "We bombed them from the sky!";
        }
    }
}