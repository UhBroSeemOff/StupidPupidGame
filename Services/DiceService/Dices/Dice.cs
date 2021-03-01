using System.Security.Cryptography;

namespace MyStupidPupidGame.Services.DiceService.Dices
{
    public abstract class Dice :IDice
    {
        protected int _minimumValue;
        protected int _maximumValue;

        public int Roll()
        {
            var result = RandomNumberGenerator.GetInt32(_minimumValue, _maximumValue);

            return result;
        }
    }
}
