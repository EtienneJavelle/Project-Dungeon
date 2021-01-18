using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Potion_de_force : Item
    {
        #region Variables

        public int Force { get; private set; }

        #endregion

        #region Construct

        public Potion_de_force(string name , int force ) : base(name) 
        {
            this.Name = name;
            this.Force = force;

        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString() + "bonsu de force obtenue  :" + this.Force ;
        }

        public override void effet(Personnage personnage)
        {
            personnage.force += this.Force;
            
        }

        #endregion
    }
}