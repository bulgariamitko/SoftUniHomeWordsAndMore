using System;
using System.Collections.Generic;
using System.Linq;
using _03GameEngine.Interfaces;

namespace _03GameEngine.Characters
{
    public class Mage : Character, IAttack
    {
        private const int Health = 150;
        private const int Defense = 50;
        private const int Attack = 300;
        private const int Range = 5;

        public Mage(string id, int x, int y, Team team) : base(id, x, y, Health, Defense, team, Range)
        {
            this.AttackPoints = Attack;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(x => x.IsAlive && x != this).LastOrDefault(x => x.Team != this.Team);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
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

        public int AttackPoints { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Attack: {0}", this.AttackPoints);
        }
    }
}