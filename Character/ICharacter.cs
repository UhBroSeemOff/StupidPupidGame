using System.Collections.Generic;
using System;
using MyStupidPupidGame.Commands;
using MyStupidPupidGame.Structures;

namespace MyStupidPupidGame.Character
{
    public interface ICharacter
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool IsAlive { get; }

        public void Move();
        public void Attack();
        public void FindTarget(IEnumerable<ICharacter> targetsList);
        public void Income(ICommand command);
    }
}
