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

        }

        //Is There a better way to do this??
        public override void SetSpeed(Arena arena)
        {
            switch (arena.CurrentArena)
            {
                case Arena.ArenaType.Forest:
                    Speed += 2;
                    break;
                case Arena.ArenaType.Ocean:
                    Speed -= 3;
                    break;
                case Arena.ArenaType.Grasslands:
                    Speed += 2;
                    break;
                case Arena.ArenaType.Swamp:
                    Speed -= 2;
                    break;
                case Arena.ArenaType.Mountain:
                    Speed += 1;
                    break;
            }
        }
    }
}
