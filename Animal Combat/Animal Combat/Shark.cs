using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    class Shark : Combatant
    {
        protected override int Health { get; set; } = 30;
        protected override int Strength { get; } = 6;
        protected override int Defense { get; } = 2;
        protected override int Speed { get; } = 8;
        protected override int MaxDamage { get; set; }

        protected override AttackType[] AttacksAllowed { get; } = { AttackType.Bite};
    }
}
