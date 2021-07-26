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
        protected int Speed { get; set; }
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
            //TODO: Set speed with static method in CombCalcs
        }

        public void Attack(ICombat combatant)
        {
            ChooseAttackType();
            MaxDamage = CombCalcs.SetMaxDamage(CurrentAttack.ToString());
            criticalStrike = CombCalcs.CriticalStrike();
            Console.Write($"{this.GetType().Name} attacks with {CurrentAttack}");
            printDotAnimation();

            combatant.TakeDamage(MaxDamage + criticalStrike);
        }

        public abstract void SetSpeed(Arena arena);

        //Randomly choosing from allowed attacks
        public void ChooseAttackType()
        {
            CurrentAttack = AttacksAllowed[Random.RandomNumber(0, AttacksAllowed.Length)];
        }

        public void TakeDamage(int damage)
        {
            if (CombCalcs.Dodge(Speed, this.GetType().Name.ToString()))
            {
                return;
            }

            totalDamage = CombCalcs.AttackEffectiveness(Defense, damage, Speed);

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
