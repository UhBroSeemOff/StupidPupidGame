using System.Linq;
using MyStupidPupidGame.CharacterProperties;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Character
{
    class Archer : Character
    {
        public Archer(string name, Qualification qualification, IRules rules) : base(name, qualification, rules)
        {
            
            _stats.Damage -= 6;
            _stats.Health -= 10;
        }

        protected override void FindTarget()
        {
            _target = _enemiesList.OrderByDescending(target => target.Condition).FirstOrDefault(target => target.IsAlive);
        }

        protected override void ComputeStats()
        {
            _stats.Penetration = 60;
            _stats.Damage = _qualification.Agility / 5;
            _stats.Defense = _qualification.Strength /20;
            _stats.Health = _qualification.Endurance /2;
            _stats.Evasion = _qualification.Agility/5;
        }
    }
}
