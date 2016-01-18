// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKeyboardHandler.cs" company="SoftUni">
//   SoftUni Rights
// </copyright>
// <summary>
//   Defines the IKeyboardHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YoloSnake.Interfaces
{
    using System;

    /// <summary>
    /// Handing input from the keyboard.
    /// </summary>
    public interface IKeyboardHandler
    {
        /// <summary>
        /// Gets the last pressed key.
        /// </summary>
        ConsoleKey PressedKey { get; }

        /// <summary>
        /// Gets a value indicating whether is key pressed.
        /// </summary>
        bool IsKeyAvailable { get; }
    }
}