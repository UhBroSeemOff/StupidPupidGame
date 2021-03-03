using System.Collections.Generic;
using System;
using MyStupidPupidGame.Commands;
using MyStupidPupidGame.Enums;

namespace MyStupidPupidGame.Character
{
    public interface ICharacter
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool IsAlive { get; }
        public EWounds Condition { get; }

        public void Move();
        public void Attack();
        public void LookAround(IEnumerable<ICharacter> targetsList);
        public void Income(ICommand command);
    }
}
