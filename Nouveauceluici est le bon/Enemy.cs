using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Enemy : Character
    {
        public int exp { get; }

        public Enemy(int HealthPoint, int Strength) : base(HealthPoint, Strength)
        {
            this.exp = 20;
            this.Name = "Monstre ";
        }


        public override string ToString()
        {
            return this.Name+ "a " + this.HealthPoint + " points de vie, Force " + this.Strength + " et Armure " + this.Armor + ".";
        }
    }
}
