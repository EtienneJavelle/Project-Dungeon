
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Weapon : Item
    {
        #region Constructor
        public Weapon(string name, int amount) : base(name, amount)
        {
            this.isEquipment = true;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return "Arme obtenu  +" + this.Amount + " d'attaque";
        }

        public override void effet(Player player)
        {
            player.Weapon = this.Amount;
            base.effet(player);
        }

        #endregion
    }
}
