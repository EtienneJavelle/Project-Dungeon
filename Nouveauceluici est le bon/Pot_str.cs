
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Pot_str : Item
    {
        #region Constructor
        public Pot_str(string name, int amount) : base(name, amount)
        {
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "Bonus de force obtenu  +" + this.Amount;
        }

        public override void effet(Player player)
        {
            player.Strength += this.Amount;
            base.effet(player);

        }

        #endregion
    }
}
