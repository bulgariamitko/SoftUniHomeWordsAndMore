using Exers02.Interfaces;

namespace Exers02.Ships
{
    public abstract class Battleship : Ship, IAttack
    {
        protected Battleship(string name, double lengthInMeters, double volume) : base(name, lengthInMeters, volume)
        {

        }

        protected void DestroyTarget(Ship target)
        {
            target.IsDestroyed = true;
        }

        public abstract string Attack(Ship targetShip);
    }
}