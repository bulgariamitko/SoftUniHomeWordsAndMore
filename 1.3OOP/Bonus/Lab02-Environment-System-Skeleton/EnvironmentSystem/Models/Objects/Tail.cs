using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Tail : EnvironmentObject
    {
        private int lifeTime;

        public Tail(int x, int y, int lifeTime = 1) : base(x, y, 1, 1)
        {
            this.lifeTime = lifeTime;
            ImageProfile = new char[,] { {'*'} };
        }

        public Tail(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            lifeTime--;
            if (lifeTime <= 0)
            {
                Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}