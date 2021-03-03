using System.Linq;
using MyStupidPupidGame.CharacterProperties;
using MyStupidPupidGame.Services.RulesService.Rules;

namespace MyStupidPupidGame.Character
{
    public class Warrior : Character
    {

        #region Constructors

        public Warrior(string name, Qualification qualification, IRules rules) : base(name, qualification, rules)
        {
        }

        #endregion

        #region Methods
        
        protected override void FindTarget()
        {
            _target = _enemiesList.OrderBy(target=> target.Condition).FirstOrDefault(target=>target.IsAlive);
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
