using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    static class Random
    {
        private static System.Random _random = new System.Random();

        public static int RandomNumber(int num1, int num2)
        {
            int rInt = _random.Next(num1, num2);
            return rInt;
        }
    }
}
