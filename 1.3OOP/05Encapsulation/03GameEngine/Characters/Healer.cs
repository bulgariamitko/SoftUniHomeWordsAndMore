using System.Collections.Generic;
using System.Linq;
using _03GameEngine.Interfaces;

namespace _03GameEngine.Characters
{
    public class Healer : Character, IHeal
    {
        private const int Health = 75;
        private const int Defense = 50;
        private const int Healing = 60;
        private const int Range = 6;

        public Healer(string id, int x, int y, Team team) : base(id, x, y, Health, Defense, team, Range)
        {
            this.HealingPoints = Healing;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(x => x.IsAlive && x != this).OrderBy(x => x.HealthPoints).FirstOrDefault(x => x.Team == this.Team);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public int HealingPoints { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}