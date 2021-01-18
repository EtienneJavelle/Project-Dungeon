using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Character
    {
        #region Variables

        public int HealthPoint { get; protected set; }
        public int Strength { get; protected set; }
        public int Armor { get; }
        public int Weapon { get; }
        public List<Item> Inventory { get; set; }
        

        #endregion

        #region Construct
        public Character (int Vie, int Force)
        {
            this.HealthPoint = Vie;
            this.Strength = Force;
            this.Armor = 0;
            this.Weapon = 0;
            this.Inventory = new List<Item>();
            
        }


        #endregion

        #region Overrides
        #endregion

        #region Methods

        public void AjouterItem(Item item)
        {
            this.Inventory.Add(item);
        }
        public void SupprimerItem(Item item)
        {
            this.Inventory.Remove(item);
        }
        
        public void Attaquer()
        {
            Console.WriteLine("Attaque !");
        }

        #endregion

        #region Fields
        #endregion

    }

   

}
