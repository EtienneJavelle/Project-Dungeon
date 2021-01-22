using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    abstract class Item
    {

        #region Variables

        public string Name { get; set; }
        public int Amount { get; set; }

        #endregion


        #region Construct

        public Item(string name, int amount)
        {
            this.Name = name;
            this.Amount = amount;
            Console.WriteLine(this.Name+" obtenu.");
            Console.ReadKey();
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.Name;
        }
        #endregion

        #region Methods



        public virtual void effet(Player player)
        {
            Console.WriteLine(this.Name + " a été utilisé.");
            Console.ReadKey();
        }

        #endregion
    }
}
