using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Character
    {
        #region Variables

        public int Vie { get; }
        public int Force { get; }
        public int Armure { get; }
        public int Arme { get; }
        public List<Item> Inventaire { get; set; }
        

        #endregion

        #region Construct
        public Character (int Vie, int Force)
        {
            this.Vie = Vie;
            this.Force = Force;
            this.Armure = 0;
            this.Arme = 0;
            this.Inventaire = new List<Item>;
            
        }


        #endregion

        #region Overrides
        #endregion

        #region Methods

        public void AjouterItem(Item item)
        {
            this.Inventaire.Add(item);
        }
        public void SupprimerItem(Item item)
        {
            this.Inventaire.Remove(item);
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
