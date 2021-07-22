using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    class Arena
    {
        public ArenaType CurrentArena;

        public Arena()
        {
            ChooseArenaType();
        }

        public enum ArenaType
        {
            Forest,
            Ocean,
            Grasslands,
            Swamp,
            Mountain
        }

        public void ChooseArenaType()
        {
            CurrentArena = (ArenaType)Random.RandomNumber(0, 4);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welcome to the {CurrentArena}.\n\n");
            Console.ResetColor();
        }
    }
}
