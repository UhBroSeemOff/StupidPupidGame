using MyStupidPupidGame.Enums;

namespace MyStupidPupidGame.Services.DiceService
{
    public interface IDiceService
    {
        int RollDice(EDices diceType);
        int RollDice(EDices diceType, int diceNumber);
    }
}
