using MyStupidPupidGame.Character;
using MyStupidPupidGame.Enums;

namespace MyStupidPupidGame.Villages
{
    public interface IVillage
    {
        ICharacter GetFighter(EFighterClass fighterClass);
    }
}
