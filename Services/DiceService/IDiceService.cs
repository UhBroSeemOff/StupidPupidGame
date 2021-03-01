using MyStupidPupidGame.Services.DiceService.Dices;

namespace MyStupidPupidGame.Services.DiceService
{
    public interface IDiceService
    {
        int RollDice(EDices diceType);
    }
}
