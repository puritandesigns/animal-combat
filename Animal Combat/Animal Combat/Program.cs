using System;

namespace Animal_Combat
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            ICombat human = new Human(arena);
            ICombat shark = new Shark(arena);

            while(!human.IsDead && !shark.IsDead)
            {
                human.Attack(shark);
                shark.Attack(human);
            }


        }
    }
}
