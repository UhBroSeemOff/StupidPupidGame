using MyStupidPupidGame.Character;
using System;
using System.Collections.Generic;
using System.Linq;

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

            fightersList.ForEach(fighter=>fighter.LookAround(fightersList));

            while(FightersList.Count(fighter => fighter.IsAlive) > 1)
            {
                fightersList.ForEach(fighter => fighter.Attack());
                Console.WriteLine("===============================");
                Console.WriteLine("-------------------------------");
                fightersList.Where(fighter=> fighter.IsAlive).ToList().ForEach(fighter=> Console.WriteLine($"{fighter.Name} - {fighter.Condition}"));
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"It's {fightersList.Count(fighter=>fighter.IsAlive)} warriors last");
            }

            Console.WriteLine($"{fightersList.FirstOrDefault(fighter => fighter.IsAlive)?.Name} wins!");
        }

        #endregion
    }
}
