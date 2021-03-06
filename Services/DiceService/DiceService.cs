﻿using System.Collections.Generic;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService.Dices;

namespace MyStupidPupidGame.Services.DiceService
{
    public class DiceService : IDiceService
    {
        private readonly IDictionary<EDices, IDice> _diceMap = new Dictionary<EDices, IDice>()
        {
            {EDices.Dice2, new Dice2()},
            {EDices.Dice4, new Dice4()},
            {EDices.Dice6, new Dice6()},
            {EDices.Dice8, new Dice8()},
            {EDices.Dice10, new Dice10()},
            {EDices.Dice12, new Dice12()},
            {EDices.Dice20, new Dice20()},
            {EDices.Dice100, new Dice100()}
        };

        public int RollDice(EDices diceType)
        {
            return _diceMap[diceType].Roll();
        }

        public int RollDice(EDices diceType, int diceNumber)
        {
            var result = 0;

            for (var iteration = 0; iteration < diceNumber; iteration++)
                result += RollDice(diceType);
            
            return result;
        }
    }
}
