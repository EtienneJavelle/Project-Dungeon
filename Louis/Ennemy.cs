using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Ennemy: Character
    {
        public int EXP { get; }
        public Ennemy(string nom) : base(nom)
        {
            this.EXP = 10;
        }

       
    }
}
