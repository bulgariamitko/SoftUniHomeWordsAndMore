namespace Exam.Models
{
    public abstract class Behavior
    {
        protected Behavior(int health, int attackDamage)
        {
            Health = health;
            AttackDemage = attackDamage;
        }

        public int Health { get; }
        public int AttackDemage { get; }
    }
}