using Exam.Interfaces;

namespace Exam.Models
{
    public class AggressiveBehavior : Behavior
    {
        //•	Aggressive Behavior - doubles the blob's damage. Each consecutive turn the blob loses 5 damage. The unit's damage cannot fall below its initial value(the damage before the behavior was toggled). 
        public AggressiveBehavior(int health, int attackDamage) : base(health, attackDamage)
        {
            attackDamage = attackDamage*2;
        }
    }
}