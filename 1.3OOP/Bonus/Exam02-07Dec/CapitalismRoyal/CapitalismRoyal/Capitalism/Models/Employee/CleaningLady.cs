﻿using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class CleaningLady : Employee
    {
        private const decimal SalaryFactorDefault = -0.02m;

        public CleaningLady(string firstName, string lastName, IOrganizationalUnit inUnit) : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}