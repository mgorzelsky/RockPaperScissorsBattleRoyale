using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    class Paper
    {
        private int armySize;
        private Random rand = new Random();

        public Paper(int initialArmySize)
        {
            armySize = initialArmySize;
        }

        public MovementCollision Move()
        {
            MovementCollision direction = (MovementCollision)rand.Next(0, 4);
            return direction;
        }

        public void AddSoldier()
        {
            if (armySize > 0)
            {
                armySize++;
            }
        }

        public void RemoveSoldier()
        {
            if (armySize > 0)
            {
                armySize--;
            }
        }

        public int GetArmySize()
        {
            return armySize;
        }
    }
}
