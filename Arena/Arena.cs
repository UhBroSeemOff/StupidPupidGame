using MyStupidPupidGame.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var fightersList = FightersList.ToList();
            while(FightersList.Count(fighter => fighter.IsAlive) > 1)
            {
                fightersList.ForEach(fighter =>
                {
                    fighter.FindTarget(fightersList.Where(character => character.Id != fighter.Id));
                    fighter.Attack();
                });
            }

            Console.WriteLine($"{fightersList.FirstOrDefault()?.Name} wins!");
        }

        #endregion
    }
}
