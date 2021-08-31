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

            //TODO: Extract fighter and arena choice to method

            Console.WriteLine("****Choose Your arena****");
            Console.WriteLine("Forest, Ocean, Grassland, Swamp, or Mountain:  \n");
            string arenaType = Console.ReadLine();

            arena = new Arena(arenaType.ToLower());

            //TODO: Do checks for null or incorrect arena and combatant types
         

            Console.WriteLine("****Choose Your fighter****");
            Console.WriteLine("Shark or Human:  \n");
            string combatantType = Console.ReadLine();
            player = fighterFactory.makeCombatant(combatantType.ToLower(), arena);



            //TODO: Randomly choose opponent
            ICombat opponent = new Shark(arena);



            //TODO: Fix shark attacking after it has died
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
