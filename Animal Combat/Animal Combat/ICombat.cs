using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    interface ICombat
    {
        bool IsDead { get;}

        void Attack(ICombat combatant);

        //Not sure why this had to be included in the interface
        void TakeDamage(int damage);
    }
}
