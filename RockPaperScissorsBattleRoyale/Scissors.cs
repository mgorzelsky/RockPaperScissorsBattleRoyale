using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    class Scissors : Entity
    {
        private readonly EntityIdentity identity = EntityIdentity.Scissors;
        public override EntityIdentity GetIdentity()
        {
            return identity;
        }
    }
}
