using System;
using System.Collections.Generic;
using MyStupidPupidGame.Character;

namespace MyStupidPupidGame.Arena
{
    public interface IArena
    {
        public IEnumerable<ICharacter> FightersList { get; }

        public void StartFight();
    }
}
