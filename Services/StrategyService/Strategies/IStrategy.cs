using System.Collections.Generic;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.Character.CharacterProperties;

namespace MyStupidPupidGame.Services.StrategyService.Strategies
{
    public interface IStrategy
    {
        void MakeMove(IEnumerable<ICharacter> enemiesList, Statistic stats);
    }
}
