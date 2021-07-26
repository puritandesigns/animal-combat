using System;

namespace Animal_Combat
{
    class Program
    {
        static void Main(string[] args)
        {

            CombatantFactory fighterFactory = new CombatantFactory();
            ICombat player = null;

            Console.WriteLine("****Choose Your arena****");
            Console.WriteLine("Forest, Ocean, Grass, Swamp, or Mountain:  \n");
            string arenaType = Console.ReadLine();

            Arena arena = new Arena(arenaType.ToLower());

            Console.WriteLine("Choose Your fighter!");
            string combatantType = Console.ReadLine();
            player = fighterFactory.makeCombatant(combatantType.ToLower(), arena);


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
