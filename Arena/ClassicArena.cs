using MyStupidPupidGame.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStupidPupidGame.Arena
{
    public class ClassicArena : Arena
    {

        #region Constructors

        public ClassicArena(IEnumerable<ICharacter> fightersList) : base(fightersList)
        {
        }

        #endregion
    }
}
