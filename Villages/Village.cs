using System;
using System.Collections.Generic;
using MyStupidPupidGame.Character;
using MyStupidPupidGame.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.DiceService;

namespace MyStupidPupidGame.Villages
{
    public class Village : IVillage
    {
        private readonly IDiceService _diceService;
        private readonly IDictionary<EFighterClass, Func<string, Qualification, ICharacter>> _charactersMap = new Dictionary<EFighterClass, Func<string, Qualification, ICharacter>>()
        {
            {EFighterClass.Warrior, (string name, Qualification qualification)=> new Warrior(name, qualification)}
        };

        public Village(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public ICharacter GetFighter(EFighterClass fighterClass)
        {
            return _charactersMap[fighterClass](
                _diceService.RollDice(EDices.Dice100).ToString(),
                new Qualification() { 
                    Agility = _diceService.RollDice(EDices.Dice24), 
                    Endurance = _diceService.RollDice(EDices.Dice100), 
                    Strength = _diceService.RollDice(EDices.Dice24)});        //TODO: map quals
        }
    }
}
