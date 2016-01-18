// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttacker.cs" company="SoftUni">
//   SoftUni
// </copyright>
// <summary>
//   Defines the IAttacker type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _02InterfacesDocumentation
{
    /// <summary>
    /// The Attacker interface.
    /// </summary>
    public interface IAttacker
    {
        /// <summary>
        /// Gets the amount of the attack damage.
        /// </summary>
        int AttackDamage { get; }
    }
}