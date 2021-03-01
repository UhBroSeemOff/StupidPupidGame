using System;
using System.Collections.Generic;
using System.Text;

namespace MyStupidPupidGame.Services.DiceService.Dices
{
    public class Dice100 : Dice
    {
        public Dice100()
        {
            _minimumValue = 1;
            _maximumValue = 101;
        }
    }
}
