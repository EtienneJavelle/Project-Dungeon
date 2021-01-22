
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Gold : Item
    {
        #region Constructor
        public Gold(string name, int amount) : base(name, amount)
        {
            this.isEquipment = false;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "Or obtenu  +" + this.Amount;
        }

        public override void effet(Player player)
        {
            player.TotalGold += this.Amount;
            base.effet(player);

        }

        #endregion
    }
}
