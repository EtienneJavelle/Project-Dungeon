using System;
using System.Collections.Generic;
using System.Text;

namespace P_Dungeon
{
    class Personnage
    {
        #region Variables

        public Personnage (int Vie, int Force)
        {
            this.Vie = Vie;
            this.Force = Force;
            this.Armure = 0;
            this.Arme = 0;
            this.Inventaire = new List<Item>;
            
        }

        int x;
        int y;

        #endregion

        #region Construct

        public int Vie { get; }
        public int Force { get; }
        public int Armure { get; }
        public int Arme { get; }
        public List<Item> Inventaire { get; set; }
        

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
