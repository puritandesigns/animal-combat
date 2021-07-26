using System;

namespace Animal_Combat
{
    class Program
    {
        static void Main(string[] args)
        {

            CombatantFactory fighterFactory = new CombatantFactory();
            ICombat player = null;
            Arena arena = null;

            Console.WriteLine("****Choose Your arena****");
            Console.WriteLine("Forest, Ocean, Grass, Swamp, or Mountain:  \n");
            string arenaType = Console.ReadLine();

            arena = new Arena(arenaType.ToLower());

            //TODO: Do checks for null or incorrect arena types
         

            Console.WriteLine("****Choose Your fighter****");
            Console.WriteLine("Shark or Human:  \n");
            string combatantType = Console.ReadLine();
            player = fighterFactory.makeCombatant(combatantType.ToLower(), arena);

            //TODO: Do checks for null or incorrect combatant types


            //TODO: Randomly choose opponent
            ICombat opponent = new Shark(arena);


            if(player != null && opponent != null)
            {
                while(!player.IsDead && !opponent.IsDead)
                {
                    player.Attack(opponent);
                    opponent.Attack(player);
                }
            }
            else
            {
                Console.WriteLine("No player selected.");
            }
        }
    }
}
