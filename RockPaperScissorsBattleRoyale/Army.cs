using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    class Army
    {
        private int armySize;
        private Random rand = new Random();

        public Army(int initialArmySize)
        {
            armySize = initialArmySize;
        }

        public MovementCollision Move()
        {
            MovementCollision direction = (MovementCollision)rand.Next(0, 6);
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
