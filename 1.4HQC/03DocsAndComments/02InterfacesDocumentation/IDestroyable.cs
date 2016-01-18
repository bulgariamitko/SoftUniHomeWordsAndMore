// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDestroyable.cs" company="SoftUni">
//   SoftUni
// </copyright>
// <summary>
//   Defines the IDestroyable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _02InterfacesDocumentation
{
    /// <summary>
    /// The Destroyable interface.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        /// Gets or sets the health of the Blob
        /// </summary>
        int Health { get; set; }
    }
}