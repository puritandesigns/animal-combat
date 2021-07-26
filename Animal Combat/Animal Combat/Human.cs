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
            typeOfMove = MovementType.walk;
        }

        //Is There a better way to do this??
        public override void SetSpeed(Arena arena)
        {
            switch (arena.CurrentArena)
            {
                case Arena.ArenaType.forest:
                    Speed += 2;
                    break;
                case Arena.ArenaType.ocean:
                    Speed -= 3;
                    break;
                case Arena.ArenaType.grasslands:
                    Speed += 2;
                    break;
                case Arena.ArenaType.swamp:
                    Speed -= 2;
                    break;
                case Arena.ArenaType.mountain:
                    Speed += 1;
                    break;
            }
        }
    }
}
