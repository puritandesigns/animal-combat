using System;

namespace Animal_Combat
{
    class Program
    {
        static void Main(string[] args)
        {
            Combatant human = new Human();
            Combatant shark = new Shark();

            human.Attack(shark);
            shark.Attack(human);

        }
    }
}
