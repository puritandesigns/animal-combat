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

        }

        //Is There a better way to do this??
        public override void SetSpeed(Arena arena)
        {
            switch(arena.CurrentArena)
            {
                case Arena.ArenaType.Forest:
                    Speed -= 2;
                    break;
                case Arena.ArenaType.Ocean:
                    Speed += 3;
                    break;
                case Arena.ArenaType.Grasslands:
                    break;
                case Arena.ArenaType.Swamp:
                    Speed += 1;
                    break;
                case Arena.ArenaType.Mountain:
                    Speed -= 3;
                    break;
            }
        }
    }
}
