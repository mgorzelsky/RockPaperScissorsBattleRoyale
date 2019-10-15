using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    class Paper : Entity
    {
        private readonly EntityIdentity identity = EntityIdentity.Paper;
        public override EntityIdentity GetIdentity()
        {
            return identity;
        }
    }
}
