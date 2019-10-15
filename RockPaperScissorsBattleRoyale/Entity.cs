using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    //Base class to allow passing of an unkown type in methods
    public abstract class Entity
    {
        public abstract EntityIdentity GetIdentity();
    }
}
