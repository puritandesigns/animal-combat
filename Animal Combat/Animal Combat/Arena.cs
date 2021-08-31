using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    public class Arena
    {
        public ArenaType CurrentArena;

        public Arena(string arenaType)
        {
            ChooseArenaType(arenaType);
        }

        public enum ArenaType
        {
            forest,
            ocean,
            grassland,
            swamp,
            mountain
        }

        public void ChooseArenaType(string arenaType)
        {
            //TODO: Validate arenaType
            CurrentArena = (ArenaType)Enum.Parse(typeof(ArenaType), arenaType);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welcome to the {CurrentArena}.\n\n");
            Console.ResetColor();

        }
    }
}
