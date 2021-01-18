using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Player: Character
    {
        public int Or { get; set; }
        public int EXP { get; set; }
        public int LVL { get; set; }

        public int x;
        public int y;

        public Player(string nom) : base(nom)
        {
            this.EXP = 0;
            this.LVL = 1;
        }

       

    }
}
