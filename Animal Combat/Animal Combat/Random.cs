using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    static class Random
    {
        private static System.Random _random = new System.Random();

        public static int RandomNumber(int num)
        {
            int rInt = _random.Next(0, num);
            return rInt;
        }
    }
}
