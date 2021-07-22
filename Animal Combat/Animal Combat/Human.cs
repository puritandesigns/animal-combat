using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    class Human : Combatant
    {
        protected override int Health { get; set; } = 15;
        protected override int Strength { get; } = 5;
        protected override int Defense { get; } = 3;
        protected override int Speed { get; } = 4;
        protected override int MaxDamage { get; set;  }
        protected override AttackType[] AttacksAllowed { get;} = { AttackType.Kick, AttackType.Fist};
    }
}
