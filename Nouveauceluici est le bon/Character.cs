using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    abstract class Character
    {
        #region Variables
        public int HealthPoint { get; set; }
        public bool Dead { get; protected set; }
        public int Level { get; protected set; }
        public int Experience { get; protected set; }
        public string Name { get; protected set; }
        public int Strength;
        public int Armor;
        public int Weapon { get; set; }

        #endregion

        #region Construct
        public Character(int HealthPoint, int Strength)
        {
            this.HealthPoint = HealthPoint;
            this.Strength = Strength;
            this.Armor = 0;
            this.Dead = false;
            this.Level = 1;
        }
        #endregion

        #region Methods
        public void LooseHealth(int amount)
        {
            amount = Math.Max(amount, 0);
            Console.WriteLine(this.Name + " => Loose " + amount + " HP");
            this.HealthPoint -= amount;

            if (this.HealthPoint <= 0) this.Die();
        }

        void Die()
        {
            Console.WriteLine(this.Name + "=> mort");
            this.Dead = true;
            Console.ReadKey();
        }
        #endregion
    }
}
