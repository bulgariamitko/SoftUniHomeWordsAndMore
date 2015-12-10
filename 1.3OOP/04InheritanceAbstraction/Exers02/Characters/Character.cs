using Exers02.Interfaces;

namespace Exers02.Characters
{
    public abstract class Character : IAttack
    {
        private int health;
        private int mana;
        private int damage;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        protected Character(int health, int mana, int damage)
        {
            this.health = health;
            this.mana = mana;
            this.damage = damage;
        }

        public abstract void Attack(Character target);

        public override string ToString()
        {
            return string.Format("{0}:\r\n-Health: {1}\r\n-Mana: {2}\r\n", this.GetType().Name, Health, Mana);
        }
    }
}