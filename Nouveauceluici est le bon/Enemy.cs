using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Enemy : Character
    {
        int exp = 10;

        public Enemy(int HealthPoint, int Strength) : base(HealthPoint, Strength)
        {
        }


        public override string ToString()
        {
            return "Le Monstre a " + this.HealthPoint + " points de vie, Force " + this.Strength + " et Armure " + this.Armor + ".";
        }
    }
}
