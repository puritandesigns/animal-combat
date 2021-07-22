using System;
using System.Collections.Generic;
using System.Text;

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
        protected AttackType CurrentAttack { get; set; }
        protected abstract AttackType[] AttacksAllowed { get; }

        public void Attack(Combatant combatant)
        {
            ChooseAttackType();
            SetMaxDamage();
            Console.WriteLine($"{this.GetType().Name} attacks with {CurrentAttack}.");
            CriticalStrike();
            combatant.LoseHealth(MaxDamage);
        }

        //TODO: Roll for critical strike
        public void CriticalStrike()
        {
            
        }

        //Randomly choosing from allowed attacks
        public void ChooseAttackType()
        {
            CurrentAttack = AttacksAllowed[Random.RandomNumber(AttacksAllowed.Length)];
        }

        //Set max damage based on attack type
        public void SetMaxDamage()
        {
            switch (CurrentAttack)
            {
                case AttackType.Fist:
                    MaxDamage = 5;
                    break;
                case AttackType.Claw:
                    MaxDamage = 6;
                    break;
                case AttackType.Bite:
                    MaxDamage = 7;
                    break;
                case AttackType.Kick:
                    MaxDamage = 5;
                    break;
                case AttackType.Grab:
                    MaxDamage = 3;
                    break;
            }
        }

        //TODO: set movement based on speed
        public void Move()
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
        }

        public enum AttackType
        {
            Fist,
            Claw,
            Bite,
            Kick,
            Grab
        }
    }
}
