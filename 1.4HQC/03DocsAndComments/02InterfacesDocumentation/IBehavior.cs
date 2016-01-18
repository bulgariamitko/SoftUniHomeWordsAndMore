// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBehavior.cs" company="SoftUni">
//   SoftUni
// </copyright>
// <summary>
//   Defines the IBehavior type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _02InterfacesDocumentation
{
    /// <summary>
    /// The Behavior interface.
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Gets the health of the Blob.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Gets the attack damage.
        /// </summary>
        int AttackDemage { get; }
    }
}