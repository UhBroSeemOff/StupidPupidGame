using MyStupidPupidGame.Commands;
using MyStupidPupidGame.Commands.Battle;
using System;
using System.Collections.Generic;
using System.Text;
using MyStupidPupidGame.Structures;

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

        public Statistic Stats { get; private set; }

        public bool IsAlive { get; private set; } = true;

        #endregion

        #region Constructors

        protected Character( string name, Qualification qualification)
        {
            Name = name;
            _qualification = qualification;

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
            if (command is Attack atack)
                HealthChanged?.Invoke(this, atack.Damage * (-1));

        }

        private void OnHealthChanged(object sender, int healthChanging)
        {
            var health = Stats.Health + healthChanging;
            Stats.Update(health, Stats.Damage, Stats.Defense);

            IsAlive = Stats.Health > 0;

            if (IsAlive)
                Console.WriteLine($"Ouch! {Name} damaged, {Stats.Health} health remained!");
            else
                Console.WriteLine($"{Name} dead...");
        }

        #endregion
    }
}