namespace Exers02.Characters
{
    public class Priest : Character, Interfaces.IHeal
    {
        public Priest() : base(125, 200, 100)
        {

        }

        public override void Attack(Character target)
        {
            Mana -= 100;
            target.Health -= Damage;
            Health += Damage/10;
        }

        public void Heal(Character target)
        {
            Mana -= 100;
            target.Health += 150;
        }
    }
}
