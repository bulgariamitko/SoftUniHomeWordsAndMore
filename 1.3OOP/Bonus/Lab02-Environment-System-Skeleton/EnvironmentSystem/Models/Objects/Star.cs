using System;
using System.Collections.Generic;
using System.ComponentModel;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Star : EnvironmentObject
    {
        private const char DefaultStarImageCharacter = 'O';
        private const int StarImageUpdateFrequency = 10;

        private int updateCount = 0;
        private static readonly Random randomizer = new Random();
        private static char[] starImageProfiles = new char[] {'O', '@', '0'};

        public Star(int x, int y) : base(x, y, 1, 1)
        {
            ImageProfile = new char[,] { {DefaultStarImageCharacter} };
        }

        public Star(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            if (updateCount == StarImageUpdateFrequency)
            {
                int index = randomizer.Next(0, starImageProfiles.Length);
                ImageProfile = new char[,] { {starImageProfiles[index]} };
                updateCount = 0;
            }
            updateCount++;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObejct = collisionInfo.HitObject;
            if (hitObejct is Explosion)
            {
                Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}