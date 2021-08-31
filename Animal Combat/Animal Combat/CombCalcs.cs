using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    public static class CombCalcs
    {
        public static int SetMaxDamage(string AttackType)
        {
            switch (AttackType)
            {
                case "Fist":
                    return 11;
                case "Claw":
                    return 13;
                case "Bite":
                    return 13;
                case "Kick":
                    return 9;
                case "Grab":
                    return 8;
                default:
                    Console.WriteLine("No attack type set.");
                    return 0;
            }
        }

        public static int SetSpeed(Arena arena, string baseMoveType)
        {
            if(baseMoveType == "walk")
            {
                switch (arena.CurrentArena)
                {
                    case Arena.ArenaType.forest:
                        return 2;
                    case Arena.ArenaType.ocean:
                        return -3;
                    case Arena.ArenaType.grassland:
                        return 2;
                    case Arena.ArenaType.swamp:
                        return -2;
                    case Arena.ArenaType.mountain:
                        return 1;
                    default:
                        return 0;
                }
            }
            else if(baseMoveType == "swim")
            {
                switch (arena.CurrentArena)
                {
                    case Arena.ArenaType.forest:
                        return -2;
                    case Arena.ArenaType.ocean:
                        return 3;
                    case Arena.ArenaType.grassland:
                        return -3;
                    case Arena.ArenaType.swamp:
                        return 1;
                    case Arena.ArenaType.mountain:
                        return -3;
                    default:
                        return 0;
                }
            }

            //TODO: Add fly base move type

            else
            {
                return 0;
            }
        }

        public static bool CheckDodge(int speed, string fighterName)
        {
            //TODO: Remove hardcoded chance-to-dodge value
            if (Random.RandomNumber(0, speed) > 2)
            {
                Console.WriteLine($"{fighterName} dodged attack!\n");
                return true;
            }
            return false;
        }

        public static int CheckDefend(int defense, int speed)
        {
            //TODO: Fix calculations
            return Random.RandomNumber(defense - speed, defense);
        }


        public static int CheckAttackEffectiveness(int defense, int damage, int speed)
        {        
            //TODO: Fix calculations
            return Random.RandomNumber(speed, damage) - CheckDefend(defense, speed);
        }


        public static int CheckCriticalStrike()
        {
            int criticalStrike = Random.RandomNumber(0, 10);

            if (criticalStrike > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Critical strike!");
                Console.ResetColor();
                return criticalStrike;
            }
            else return 0;
        }
    }
}
