using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Player: Character
    {
        public int Gold { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }

        public int x;
        public int y;

        public Player(string nom) : base(nom)
        {
            this.Experience = 0;
            this.Level = 1;
        }

        public void GainLevel()
        {
            this.Level++;
            this.HealthPoint += this.HealthPoint*(new Random().Next(1, 11)/100);
            this.Strength += this.Strength * (new Random().Next(1, 11) / 100);
        }

        private int ExpMax()
        {
            if (Experience >= 100)
            {
                this.Level++;
                Experience = 0;
            }
        }
    }
}
