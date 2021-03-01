using System;
using System.Collections.Generic;
using System.Text;

namespace MyStupidPupidGame.Structures
{
    public struct Statistic
    {
        public int Health;
        public int Damage;
        public int Defense;

        public void Update(int health, int damage, int defense)
        {
            Health = health;
            Damage = damage;
            Defense = defense;
        }
    }
}
