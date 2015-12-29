using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace EnvironmentSystem.Models.Objects
{
    public class UnstableStar : FallingStar
    {
        private int lifeTime;

        public UnstableStar(int x, int y, Point direction, int lifeTime = 8) : base(x, y, direction)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            lifeTime--;
            if (lifeTime <= 0)
            {
                Exists = false;
            }
            base.Update();
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (Exists)
            {
                return base.ProduceObjects();
            }
            else
            {
                List<EnvironmentObject> explosion = new List<EnvironmentObject>();
                for (int y = Bounds.TopLeft.Y - 2; y <= Bounds.TopLeft.Y + 2; y++)
                {
                    for (int x = Bounds.TopLeft.X - 2; x <= Bounds.TopLeft.X + 2; x++)
                    {
                        if (!(x == Bounds.TopLeft.X && y == Bounds.TopLeft.Y))
                        {
                            explosion.Add(new Explosion(x, y));
                        }
                    }
                }
                return explosion;
            }
        }
    }
}