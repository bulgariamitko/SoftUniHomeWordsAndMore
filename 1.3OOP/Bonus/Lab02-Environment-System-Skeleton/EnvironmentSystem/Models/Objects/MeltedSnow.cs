using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class MeltedSnow : EnvironmentObject
    {
        public MeltedSnow(int x, int y) : base(x, y, 1, 1)
        {

        }

        public MeltedSnow(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            throw new System.NotImplementedException();
        }
    }
}