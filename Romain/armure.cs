using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class armure : Item
    {
        #region Variables

        public int Bonus { get; private set; }

        #endregion

        #region Construct

        public armure(string name, int bonus) : base(name)
        {
            this.Name = name;
            this.Bonus = bonus;

        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString() + "equipement obtenue  :" + this.Name;
        }

        public override void effet(Personnage personnage)
        {
            personnage.arme = this.Bonus;
        }

        #endregion
    }
}
