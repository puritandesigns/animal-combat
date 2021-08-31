using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Combat
{
    class CombatantFactory
    {
        public ICombat makeCombatant(string newCombatant, Arena arena)
        {
            //TODO: Change to switch statement
            if(newCombatant.ToLower().Equals("shark"))
            {
                return new Shark(arena);
            }
            else if(newCombatant.ToLower().Equals("human"))
            {
                return new Human(arena);
            }
            else
            {
                return null;
            }
        }
    }
}
