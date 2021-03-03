﻿using MyStupidPupidGame.Arena;
using MyStupidPupidGame.Character;
using System.Collections.Generic;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;
using MyStupidPupidGame.Services.RulesService;
using MyStupidPupidGame.Villages;

namespace MyStupidPupidGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IDiceService diceService = new DiceService();
            IRulesService rulesService = new RulesService(diceService);
            IVillage village = new Village(diceService, rulesService.GetRules(ERules.Percentage));
            IList<ICharacter> fighters = new List<ICharacter>();

            for (int i = 0; i < 200; i++)
            {
                var character = village.GetFighter(EFighterClass.Warrior);
                fighters.Add(character);
            }

            for (int i = 0; i < 10; i++)
            {
                var character = village.GetFighter(EFighterClass.Ranger);
                fighters.Add(character);
            }

            IArena arena = new ClassicArena(fighters);
            arena.StartFight();
        }
    }
}
