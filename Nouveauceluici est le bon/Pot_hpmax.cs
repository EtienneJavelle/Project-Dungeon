
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Pot_hpmax : Item
    {
        #region Constructor
        public Pot_hpmax(string name, int amount) : base(name, amount)
        {
            this.isEquipment = false;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "Vie max augmentée +" + this.Amount;
        }

        public override void effet(Player player)
        {
            player.maxHP += this.Amount;
            base.effet(player);
        }

        #endregion
    }
}
