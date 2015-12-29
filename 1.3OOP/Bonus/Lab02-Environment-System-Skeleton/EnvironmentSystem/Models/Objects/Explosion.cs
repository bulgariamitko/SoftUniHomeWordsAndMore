using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Explosion : Tail
    {
        public Explosion(int x, int y, int lifeTime = 2) : base(x, y, lifeTime)
        {
        }

        public Explosion(Rectangle bounds) : base(bounds)
        {
        }
    }
}