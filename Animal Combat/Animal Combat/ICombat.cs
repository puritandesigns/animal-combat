using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    interface ICombat
    {
        bool IsDead { get;}

        void Attack(ICombat combatant);
        void TakeDamage(int damage);
    }
}
