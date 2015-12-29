using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStar : MovingObject
    {
        private const char FallingStarImageCharacter = 'O';

        public FallingStar(int x, int y, Point direction) : base(x, y, 1, 1, direction)
        {
            ImageProfile = new char[,] { {FallingStarImageCharacter} };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObject = collisionInfo.HitObject;
            if (hitObject is Ground || hitObject is Explosion)
            {
                Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            List<EnvironmentObject> produceObjects = new List<EnvironmentObject>();
            produceObjects.Add(new Tail(Bounds.TopLeft.X - Direction.X, Bounds.TopLeft.Y - Direction.Y));
            produceObjects.Add(new Tail(Bounds.TopLeft.X - 2 * Direction.X, Bounds.TopLeft.Y - 2 * Direction.Y));
            produceObjects.Add(new Tail(Bounds.TopLeft.X - 3 * Direction.X, Bounds.TopLeft.Y - 3 * Direction.Y));
            return produceObjects;
        }
    }
}