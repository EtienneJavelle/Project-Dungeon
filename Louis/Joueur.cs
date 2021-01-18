using System;
using System.Collections.Generic;
using System.Text;

namespace P_Dungeon
{
    class Joueur: Personnage
    {
        public int Or { get; set; }
        public int EXP { get; set; }
        public int LVL { get; set; }

        public Joueur(string nom) : base(nom)
        {
            this.EXP = 0;
        }

        public void LevelUP()
        {
            this.LVL++;
        }

    }
}
