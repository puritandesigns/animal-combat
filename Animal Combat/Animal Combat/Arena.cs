using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    class Arena
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
            grasslands,
            swamp,
            mountain
        }

        public void ChooseArenaType(string arenaType)
        {
            CurrentArena = (ArenaType)Enum.Parse(typeof(ArenaType), arenaType);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welcome to the {CurrentArena}.\n\n");
            Console.ResetColor();
        }
    }
}
