﻿using System.Linq;
using MyStupidPupidGame.Character.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.RulesService.Rules;
using MyStupidPupidGame.Services.StrategyService;
using MyStupidPupidGame.Services.StrategyService.Strategies;

namespace MyStupidPupidGame.Character
{
    public class Warrior : Character
    {

        #region Constructors

        public Warrior(string name, Qualification qualification, IStrategyService strategyService) : base(name, qualification, strategyService)
        {
        }

        #endregion

        #region Methods

        protected override void MakeStrategyMove()
        {
            var strategy = _strategyService.GetStrategy(EStrategies.Aggressive);
            strategy.MakeMove(_enemiesList, _stats);
        }

        protected override void ComputeStats()
        {
            _stats.Penetration = 40;
            _stats.Damage = _qualification.Strength/5;
            _stats.Defense = _qualification.Strength /10;
            _stats.Health = _qualification.Endurance;
            _stats.Evasion = 10;
        }

        #endregion
    }
}
