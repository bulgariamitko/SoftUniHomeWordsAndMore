using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using _03GameEngine.Interfaces;

namespace _03GameEngine.Characters
{
    public class Warrior : Character, IAttack
    {
        private const int Health = 200;
        private const int Defense = 100;
        private const int Attack = 150;
        private const int Range = 2;

        public Warrior(string id, int x, int y, Team team) : base(id, x, y, Health, Defense, team, Range)
        {
            this.AttackPoints = Attack;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(x => x.IsAlive && x != this).FirstOrDefault(x => x.Team != this.Team);
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

        protected override void ApplyItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
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