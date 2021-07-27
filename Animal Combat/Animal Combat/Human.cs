using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    class Human : Combatant
    {
        protected override int Health { get; set; } = 25;
        protected override int Strength { get; } = 5;
        protected override int Defense { get; } = 3;
        protected override AttackType[] AttacksAllowed { get;} = { AttackType.Kick, AttackType.Fist};

        public Human(Arena _arena) : base(_arena)
        {
            typeOfMove = BaseMovementType.walk;
        }
    }
}
