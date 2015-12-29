using System;
using Exam.Interfaces;

namespace Exam.Models
{
    public class Blob : IBlob
    {
        private string name;

        public Blob(string name, int health, int attackDamage)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name cannot be null or empty space only");
                }
                name = value;
            }
        }

        public int Health { get; set; }
        public int AttackDamage { get; set; }

        public void PutridFart(IBlob blobToAttack)
        {
            int damage = AttackDamage * 2;
            blobToAttack.Health -= damage;
        }

        public void Blobplode(IBlob blobToAttack)
        {
            Health /= 2;
            if (Health < 1)
            {
                Health = 1;
            }
            blobToAttack.Health -= AttackDamage*2;
        }

        public void Update()
        {
            //TODO: to be implemented...
        }

        public override string ToString()
        {
            return String.Format("Blob {0}: {1} HP, {2} Damage", Name, Health, AttackDamage);
        }

        
    }
}