
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Pot_hp : Item
    {
        #region Constructor
        public Pot_hp(string name, int amount) : base(name, amount)
        {
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "Bonus de soin obtenu  +" + this.Amount;
        }

        public override void effet(Player player)
        {
            player.HealthPoint += this.Amount;
            base.effet(player);
        }

        #endregion
    }
}
