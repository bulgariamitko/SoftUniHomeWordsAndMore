using System;
using System.Collections.Generic;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public class Mage : IUnit,ICombatHandler
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; }
        public int Range { get; }
        public int AttackPoints { get; set; }
        public int HealthPoints { get; set; }
        public int DefensePoints { get; set; }
        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; }

        public IUnit Unit { get; set; }

        public Mage(int x, int y, string name, int range, int attackPoints, int healthPoints, int defensePoints, int energyPoints, ICombatHandler combatHandler)
        {
            AttackPoints = 80;
            DefensePoints = 40;
            X = x;
            Y = y;
            Name = name;
            Range = 2;
            HealthPoints = 80;
            EnergyPoints = 120;
            CombatHandler = combatHandler;
        }

        public int FireBreath(IUnit target)
        {
            return target.HealthPoints -= this.AttackPoints;
        }

        public int Blizzard(IUnit target)
        {
            return target.HealthPoints -= this.AttackPoints * 2;
        }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            throw new NotImplementedException();
        }

        public ISpell GenerateAttack()
        {
            throw new NotImplementedException();
        }
    }
}