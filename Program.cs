using MyStupidPupidGame.Arena;
using MyStupidPupidGame.Character;
using System.Collections.Generic;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;
using MyStupidPupidGame.Villages;

namespace MyStupidPupidGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IDiceService diceService = new DiceService();
            IVillage village = new Village(diceService);
            IList<ICharacter> fighters = new List<ICharacter>();

            for (int i = 0; i < 20; i++)
            {
                var character = village.GetFighter(EFighterClass.Warrior);
                fighters.Add(character);
            }


            IArena arena = new ClassicArena(fighters);
            arena.StartFight();
        }
    }
}
