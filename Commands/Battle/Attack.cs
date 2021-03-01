using MyStupidPupidGame.Character;

namespace MyStupidPupidGame.Commands.Battle
{
    public class Attack : ICommand
    {
        #region Fields

        private readonly ICharacter _target;

        #endregion

        #region Properties

        public int Damage { get; private set; }

        #endregion

        #region Constructors

        public Attack(ICharacter target, int damage)
        {
            _target = target;
            Damage = damage;
        }

        #endregion

        #region Methods

        public void Execute()
        {
            _target?.Income(this);
        }

        #endregion
    }
}
