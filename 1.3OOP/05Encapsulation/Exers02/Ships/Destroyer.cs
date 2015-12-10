using System;
using Exers02.Interfaces;

namespace Exers02.Ships
{
    public class Destroyer : Battleship, IAttack
    {
        private int numberOfAmmunition;

        public Destroyer(string name, double lengthInMeters, double volume, int numberOfAmmunition) : base(name, lengthInMeters, volume)
        {
            this.NumberOfAmmunition = numberOfAmmunition;
        }

        public int NumberOfAmmunition
        {
            get
            {
                return this.numberOfAmmunition;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The number of ammunition in a destroyer cannot be negative.");
                }

                this.numberOfAmmunition = value;
            }
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "They didn't see us coming!";
        }
    }
}