using MyStupidPupidGame.Commands;
using MyStupidPupidGame.Commands.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using MyStupidPupidGame.CharacterProperties;
using MyStupidPupidGame.Enums;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Character
{
    public abstract class Character : ICharacter
    {
        #region Fields
        protected ICharacter _target;
        protected Qualification _qualification;
        protected Statistic _stats = new Statistic();
        protected event EventHandler<int> HealthChanged;
        protected IEnumerable<ICharacter> _enemiesList;
        protected IRules _rules;
        private readonly IDictionary<int, EWounds> _conditionMap;
        #endregion

        #region Properties

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public bool IsAlive { get; private set; } = true;
        public EWounds Condition { get; private set; }

        #endregion

        #region Constructors

        protected Character(string name, Qualification qualification, IRules rules)
        {
            Name = name;
            _qualification = qualification;
            _rules = rules;

            // ReSharper disable once VirtualMemberCallInConstructor
            ComputeStats();

            Id = Guid.NewGuid();

            HealthChanged += OnHealthChanged;

            _conditionMap = new Dictionary<int, EWounds>
            {
                {0, EWounds.Dead},
                {(int) (0.1*_stats.Health),  EWounds.Faint},
                {(int) (0.2*_stats.Health), EWounds.ReallyBad},
                {(int) (0.3*_stats.Health), EWounds.Badly},
                {(int) (0.5*_stats.Health), EWounds.Injured},
                {(int) (0.7*_stats.Health), EWounds.SlightlyInjured},
                {(int) (0.9*_stats.Health), EWounds.Scratched},
                {_stats.Health, EWounds.Healthy}
            };
        }

        #endregion

        #region Methods

        public void Attack()
        {
            FindTarget();

            if (_target == null || !IsAlive)
                return;

            var checkResults = _rules.Check(_stats.Penetration);

            if (!checkResults.IsPassed)
                return;

            var attackCommand = new Attack(_target, _rules.ComputeDamage(_stats.Damage));
            attackCommand.Execute();
        }

        public void Move()
        {
            Console.WriteLine($"{GetType()} moves!");
        }

        protected abstract void FindTarget();

        public void LookAround(IEnumerable<ICharacter> targetsList)
        {
            _enemiesList = new List<ICharacter>(targetsList.Where(target=> target.Id != Id));
        }

        public void Income(ICommand command)
        {
            if (command is Attack attack)
            {
                if (TryAvoidDamage())
                    return;
                
                var damage = TryReduceDamage(attack.Damage);
                ApplyDamage(damage);
            }
        }

        private void OnHealthChanged(object sender, int healthChanging)
        {
            _stats.Health += healthChanging;

            SetCondition();

            IsAlive = Condition != EWounds.Dead;
        }

        private void SetCondition()
        {
            var key = FindClosestEdge(_stats.Health);
            Condition = _conditionMap[key];
        }

        private int FindClosestEdge(int value)
        {
            var edges = _conditionMap.Keys;
            var result = edges.LastOrDefault(edge => edge <= value);
            return result;
        }

        private bool TryAvoidDamage()
        {
            var checkResults = _rules.Check(_stats.Evasion);
            return checkResults.IsPassed;
        }

        private int TryReduceDamage(int damage)
        {
            var result = damage - _stats.Defense;
            return result > 0 ? result : 0;
        }

        private void ApplyDamage(int damage)
        {
            HealthChanged?.Invoke(this, damage * (-1));
        }

        protected abstract void ComputeStats();

        #endregion
    }
}