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
        protected override AttackType[] AttacksAllowed { get; } = { AttackType.Bite};


        public Shark(Arena _arena) : base(_arena)
        {
            typeOfMove = MovementType.swim;
        }

        //Is There a better way to do this??
        public override void SetSpeed(Arena arena)
        {
            switch(arena.CurrentArena)
            {
                case Arena.ArenaType.forest:
                    Speed -= 2;
                    break;
                case Arena.ArenaType.ocean:
                    Speed += 3;
                    break;
                case Arena.ArenaType.grasslands:
                    break;
                case Arena.ArenaType.swamp:
                    Speed += 1;
                    break;
                case Arena.ArenaType.mountain:
                    Speed -= 3;
                    break;
            }
        }
    }
}
