namespace Exam.Models
{
    public class InflatedBehavior : Behavior
    {
        //•	Inflated Behavior - The blob gains 50 health.Each consecutive turns the blob loses 10 health.
        public InflatedBehavior(int health, int attackDamage) : base(health, attackDamage)
        {

        }
    }
}