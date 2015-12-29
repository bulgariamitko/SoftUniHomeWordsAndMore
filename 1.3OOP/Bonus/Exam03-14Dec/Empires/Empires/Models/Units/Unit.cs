﻿using Empires.Interfaces;

namespace Empires.Buildings.Units
{
    public abstract class Unit : IUnit
    {
        protected Unit(int attackDamage, int health)
        {
            AttackDamage = attackDamage;
            Health = health;
        }

        public int AttackDamage { get; }
        public int Health { get; }
    }
}