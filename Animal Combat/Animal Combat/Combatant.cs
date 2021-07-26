using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Animal_Combat
{
    abstract class Combatant : ICombat
    {
        protected abstract int Health { get; set; }
        protected abstract int Strength { get; }
        protected abstract int Defense { get; }
        protected virtual int Speed { get; set; } = 5;
        protected int MaxDamage { get; set; }
        public bool IsDead => Health <= 0;
        public AttackType CurrentAttack { get; set; }
        protected abstract AttackType[] AttacksAllowed { get; }
        protected MovementType typeOfMove;

        private static int criticalStrike;
        private static int totalDamage;

        protected Arena arena;

        public Combatant(Arena _arena)
        {
            arena = _arena;
        }

        public void Attack(ICombat combatant)
        {
            ChooseAttackType();
            SetMaxDamage();
            Console.Write($"{this.GetType().Name} attacks with {CurrentAttack}");
            printDotAnimation();

            combatant.TakeDamage(MaxDamage + CriticalStrike());
        }


        //Set max damage based on attack type
        public void SetMaxDamage()
        {
            switch (CurrentAttack)
            {
                case AttackType.Fist:
                    MaxDamage = 11;
                    break;
                case AttackType.Claw:
                    MaxDamage = 13;
                    break;
                case AttackType.Bite:
                    MaxDamage = 13;
                    break;
                case AttackType.Kick:
                    MaxDamage = 9;
                    break;
                case AttackType.Grab:
                    MaxDamage = 8;
                    break;
            }
        }

        public abstract void SetSpeed(Arena arena);

        //Randomly choosing from allowed attacks
        public void ChooseAttackType()
        {
            CurrentAttack = AttacksAllowed[Random.RandomNumber(0, AttacksAllowed.Length)];
        }


        //Set dodge based on speed
        public bool Dodge()
        {
            if(Random.RandomNumber(0, Speed) > 2)
            {
                Console.WriteLine($"{this.GetType().Name} dodged attack!\n");
                return true;
            }
            return false;
        }

        //Set defend based on defense
        public int Defend()
        {
            return Random.RandomNumber(Defense - Speed, Defense);
        }

        public void AttackEffectivenes(int damage)
        {
            totalDamage = Random.RandomNumber(Speed, damage) - Defend();
        }

        public void TakeDamage(int damage)
        {
            if (Dodge())
            {
                return;
            }

            AttackEffectivenes(damage);
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
            criticalStrike = Random.RandomNumber(0, 10);

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

        public enum MovementType
        {
            swim,
            walk,
            fly
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
