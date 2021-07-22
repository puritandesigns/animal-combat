using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Animal_Combat
{
    abstract class Combatant
    {
        protected abstract int Health { get; set; }
        protected abstract int Strength { get; }
        protected abstract int Defense { get; }
        protected abstract int Speed { get; }
        protected abstract int MaxDamage { get; set; }
        public bool IsDead => Health <= 0;
        public AttackType CurrentAttack { get; set; }
        protected abstract AttackType[] AttacksAllowed { get; }
        private int criticalStrike;


        public void Attack(Combatant combatant)
        {
            ChooseAttackType();
            SetMaxDamage();
            Console.Write($"{this.GetType().Name} attacks with {CurrentAttack}");
            printDotAnimation();
            combatant.LoseHealth(MaxDamage + CriticalStrike());
        }


        //Set max damage based on attack type
        public void SetMaxDamage()
        {
            switch (CurrentAttack)
            {
                case AttackType.Fist:
                    MaxDamage = 8;
                    break;
                case AttackType.Claw:
                    MaxDamage = 10;
                    break;
                case AttackType.Bite:
                    MaxDamage = 10;
                    break;
                case AttackType.Kick:
                    MaxDamage = 6;
                    break;
                case AttackType.Grab:
                    MaxDamage = 5;
                    break;
            }
        }

        //Randomly choosing from allowed attacks
        public void ChooseAttackType()
        {
            CurrentAttack = AttacksAllowed[Random.RandomNumber(AttacksAllowed.Length)];
        }


        //TODO: set dodge based on speed
        public void Dodge()
        {

        }

        //TODO: set defend based on defense
        public void Defend()
        {

        }

        public void LoseHealth(int damage)
        {
            int totalDamage = Random.RandomNumber(damage) - Defense;
            if(totalDamage < 0)
            {
                totalDamage = 0;
            }

            Health = Health - totalDamage;
            Console.WriteLine($"{this.GetType().Name} lost {totalDamage} health.\n");

            if(IsDead)
            {
                Die();
            }
        }

        public void Die()
        {
            Console.WriteLine($"{this.GetType().Name} has died.");
        }

        //Roll for critical strike
        public int CriticalStrike()
        {
            criticalStrike = Random.RandomNumber(10);

            if (criticalStrike > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Critical strike!");
                Console.ResetColor();
                return criticalStrike;
            }
            else return 0;
        }

        public enum AttackType
        {
            Fist,
            Claw,
            Bite,
            Kick,
            Grab
        }

        public void printDotAnimation(int timer = 10)
        {
            for (var x = 0; x < timer; x++)
            {
                System.Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
    }
}
