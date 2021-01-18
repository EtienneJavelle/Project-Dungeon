using System;
using System.Collections.Generic;
using System.Text;

namespace P_Dungeon
{
    class Ennemi: Personnage
    {
        public int EXP { get; }
        public Ennemi(string nom) : base(nom)
        {
        }

        public void GainEXP()
        {
            Joueur.EXP += 10;
        }

    }
}
