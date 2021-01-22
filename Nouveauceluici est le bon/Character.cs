using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    abstract class Character
    {
        #region Variables
        public int HealthPoint { get; set; }
        public int Strength { get; set; }
        public int Armor { get; set; }
        public int Arme { get; set; } //destroy 
        public bool Dead { get; protected set; }
        #endregion

        #region Construct
        public Character(int HealthPoint, int Strength)
        {
            this.HealthPoint = HealthPoint;
            this.Strength = Strength;
            this.Armor = 0;
            this.Dead = false;
        }
        #endregion

        #region Methods
        public void LooseHealth(int amount)
        {
            Console.WriteLine("Loose "+amount+" HP");
            this.HealthPoint -= amount;
            if (this.HealthPoint <= 0) this.Die();
        }

        void Die()
        {
            Console.WriteLine("Dead");
            this.Dead = true;
        }
        #endregion
    }
}
