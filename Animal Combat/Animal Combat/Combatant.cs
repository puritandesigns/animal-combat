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
        protected abstract int MaxDamage { get; }
        protected abstract AttackType attackType { get; set; }

        public void Attack(Combatant combatant)
        {
            Console.WriteLine($"{this} attacks with {attackType}.");
            CriticalStrike();
            combatant.LoseHealth(MaxDamage);
        }

        //Roll for critical strike
        private void CriticalStrike()
        {
            throw new NotImplementedException();
        }

        //TODO: set max damage based on attack type
        public void SetMaxDamage()
        {
            switch (attackType)
            {
                case AttackType.Fist:
                    break;
                case AttackType.Claw:
                    break;
                case AttackType.Bite:
                    break;
                case AttackType.Kick:
                    break;
                case AttackType.Grab:
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
            Console.WriteLine($"{this} lost {totalDamage} health.");
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
