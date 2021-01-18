using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Sac_or : Item
    {
        #region Variables
        
        public int Quantite { get; private set; }
       

        #endregion

        #region Construct

        public Sac_or(string name, int quantite) : base(name)
        {
            this.Name = name;
            this.Quantite = quantite;

        }

        #endregion


        #region Overrides

        public override string ToString()
        {
            return base.ToString() + "Or :" + Quantite;
        }

        public override void effet(Personnage personnage)
        {
            personnage.Bourse += this.Quantite;
           
        }

        #endregion

    }
}
