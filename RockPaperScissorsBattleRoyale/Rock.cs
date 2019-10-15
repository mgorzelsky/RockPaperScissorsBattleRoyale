using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    class Rock : Entity
    {
        private readonly EntityIdentity identity = EntityIdentity.Rock;
        public override EntityIdentity GetIdentity()
        {
            return identity;
        }
    }
}
