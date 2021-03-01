using MyStupidPupidGame.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyStupidPupidGame.Arena
{
    public abstract class Arena : IArena
    {
        #region Properties

        public IEnumerable<ICharacter> FightersList { get; private set; }

        #endregion

        #region Constructors

        protected Arena(IEnumerable<ICharacter> fightersList)
        {
            FightersList = fightersList;
        }

        #endregion

        #region Methods

        public void StartFight()
        {
            Console.WriteLine("Here are heroes!");
            var fightersList = FightersList.ToList();
            fightersList.OrderBy(fighter=> fighter.Name).ToList().ForEach(fighter=> Console.WriteLine(fighter.Name));

            while(FightersList.Count(fighter => fighter.IsAlive) > 1)
            {
                fightersList.ForEach(fighter =>
                {
                    fighter.FindTarget(fightersList.Where(character => character.Id != fighter.Id));
                    fighter.Attack();
                });

                Thread.Sleep(1500);
            }

            Console.WriteLine($"{fightersList.FirstOrDefault()?.Name} wins!");
        }

        #endregion
    }
}
