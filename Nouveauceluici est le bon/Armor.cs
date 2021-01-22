
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Armor : Item
    {
        #region Constructor
        public Armor(string name, int amount) : base(name, amount)
        {
            this.isEquipment = true;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "Armur obtenu  +" + this.Amount + " de défence";
        }

        public override void effet(Player player)
        {
            player.Armor = this.Amount;
            base.effet(player);
        }

        #endregion
    }
}
