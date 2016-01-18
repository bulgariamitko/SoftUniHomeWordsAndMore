// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMovable.cs" company="SoftUni">
//   SoftUni Company
// </copyright>
// <summary>
//   Defines the IMovable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YoloSnake.Interfaces
{
    using Enums;

    /// <summary>
    /// The Movable interface.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Gets the direction of the movement.
        /// </summary>
        Direction Direction { get; }

        /// <summary>
        /// The move.
        /// </summary>
        void Move();

        /// <summary>
        /// Changes the current direction to a given one.
        /// </summary>
        /// <param name="newDirection">
        /// The direction where we have to change to.
        /// </param>
        /// <see cref="YoloSnake.Enums.Direction"/>
        void ChangeDirection(Direction newDirection);
    }
}