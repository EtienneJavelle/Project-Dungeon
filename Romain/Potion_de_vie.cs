﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Potion_de_vie : Item
    {
        #region Variables

        public int Vie { get; private set; }

        #endregion

        #region Construct

        public Potion_de_vie(string name , int vie ) : base(name) 
        {
            this.Name = name;
            this.Vie = vie;

        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString() + "vie obtenue  :" + this.Vie ;
        }

        public override void effet(Personnage personnage)
        {
            personnage.Vie += this.Vie;
            
        }

        #endregion
    }
}