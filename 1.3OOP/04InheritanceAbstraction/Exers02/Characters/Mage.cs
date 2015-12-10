namespace Exers02.Characters
{
    public class Mage : Character
    {
        public Mage() : base(100, 300, 75)
        {

        }

        public override void Attack(Character target)
        {
            Mana -= 100;
            target.Health -= 2*Damage;
        }
    }
}
