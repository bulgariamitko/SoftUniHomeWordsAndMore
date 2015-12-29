using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Snow : EnvironmentObject
    {
        private const char SnowImageCharacter = '.';

        public Snow(int x, int y) : base(x, y, 1, 1)
        {
            ImageProfile = new char[,] { { SnowImageCharacter } };
        }

        public Snow(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return  new List<EnvironmentObject>();
        }
    }
}