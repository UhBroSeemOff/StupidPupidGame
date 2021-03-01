using System.Linq;
using System.Collections.Generic;
using MyStupidPupidGame.Structures;

namespace MyStupidPupidGame.Character
{
    public class Warrior : Character
    {

        #region Constructors

        public Warrior(string name, Qualification qualification) : base(name, qualification)
        {
        }

        #endregion

        #region Methods
        
        public override void FindTarget(IEnumerable<ICharacter> targetsList)
        {
            _target = targetsList.OrderBy(target => target.Name).FirstOrDefault();
        }

        #endregion
    }
}
