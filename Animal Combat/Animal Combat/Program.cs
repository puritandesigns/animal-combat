using System;

namespace Animal_Combat
{
    class Program
    {
        static void Main(string[] args)
        {
            Combatant human = new Human();
            Combatant shark = new Shark();

            while(!human.IsDead && !shark.IsDead)
            {
                human.Attack(shark);
                shark.Attack(human);
            }


        }
    }
}
