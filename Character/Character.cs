using MyStupidPupidGame.Commands;
using MyStupidPupidGame.Commands.Battle;
using System;
using System.Collections.Generic;
using MyStupidPupidGame.CharacterProperties;

namespace MyStupidPupidGame.Character
{
    public abstract class Character : ICharacter
    {
        #region Fields

        protected ICharacter _target;
        protected Qualification _qualification;
        protected event EventHandler<int> HealthChanged;

        #endregion

        #region Properties

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Statistic Stats { get; private set; } = new Statistic();

        public bool IsAlive { get; private set; } = true;

        #endregion

        #region Constructors

        protected Character(string name, Qualification qualification)
        {
            Name = name;
            _qualification = qualification;
            Stats.Damage = _qualification.Strength;
            Stats.Defense = _qualification.Strength;
            Stats.Health = _qualification.Endurance;

            Id = Guid.NewGuid();

            HealthChanged += OnHealthChanged;
        }

        #endregion

        #region Methods

        public void Attack()
        {
            if (_target == null || !IsAlive)
                return;

            var attackCommand = new Attack(_target, Stats.Damage);

            attackCommand.Execute();
        }

        public void Move()
        {
            Console.WriteLine($"{GetType()} moves!");
        }

        public abstract void FindTarget(IEnumerable<ICharacter> targetsList);

        public void Income(ICommand command)
        {
            if (command is Attack attack)
                HealthChanged?.Invoke(this, attack.Damage * (-1));

        }

        private void OnHealthChanged(object sender, int healthChanging)
        {
            if (!(sender is Character character))
                return;

            if (character.Id != Id)
                return;

            Stats.Health += healthChanging;

            IsAlive = Stats.Health > 0;

            Console.WriteLine(IsAlive ? $"Ouch! {Name} damaged, {Stats.Health} health remained!" : $"{Name} dead...");
        }

        #endregion
    }
}