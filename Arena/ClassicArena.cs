using MyStupidPupidGame.Character;
using System.Collections.Generic;

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
