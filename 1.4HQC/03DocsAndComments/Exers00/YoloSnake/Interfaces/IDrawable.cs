// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDrawable.cs" company="SoftUni">
//   SoftUni Copyright
// </copyright>
// <summary>
//   The Drawable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YoloSnake.Interfaces
{
    /// <summary>
    /// Implementations of this interface should draw using a certain drawer
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draws on a canvas using implementation of drawer
        /// </summary>
        /// <param name="drawer">
        /// Implementation of drawer to draw point
        /// </param>
        void Draw(IDrawer drawer);
    }
}