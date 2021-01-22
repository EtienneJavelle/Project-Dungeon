using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Fight
    {
        #region Variables
        public bool Won { get; protected set; }
        #endregion

        #region Constructor
        public Fight(Player player, Enemy enemy)
        {
            Console.Clear();
            this.player = player;
            this.enemy = enemy;
            //this.ExpToWin = enemy.exp;
            do
            {
                Console.WriteLine(this.player);
                Console.WriteLine(this.enemy);
                Console.WriteLine();
            } while (this.Turn());
        }
        #endregion

        #region Methods

        public bool Turn()
        {
            if (this.player.Dead)
            {
                this.Won = false;
                return false;
            }
            else if (!PlayerTrun()) return false;

            if (this.enemy.Dead)
            {
                this.Won = true;
                //this.player.GainExp(this.ExpToWin);
                return false;
            }
            else EnemyTurn();

            return true;
        }

        public bool PlayerTrun()
        {
            Console.WriteLine("Votre tour");

            var rand = new Random();

            Console.WriteLine("1 : Attaquer 2: Fuir");

            int tmp;
            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        tmp = rand.Next(1, 11);
                        float value = ((float)tmp / 100);
                        this.enemy.LooseHealth((int)MathF.Ceiling((this.player.Strength + this.player.Weapon - this.enemy.Armor) * (1 + value)));
                        return true;
                    case ConsoleKey.D2:
                        tmp = rand.Next(0, 2);
                        if (tmp == 1)
                        {
                            player.Run();
                            this.Won = true;
                            Console.ReadKey();
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("Fuite ratee");
                            Console.ReadKey();
                            return true;
                        }
                    default:
                        break;
                }
            } while (true);

        }

        public void EnemyTurn()
        {
            Console.WriteLine("EnemyTour");

            var rand = new Random();
            int tmp = rand.Next(1, 11);
            float value = ((float)tmp / 100);
            this.player.LooseHealth((int)MathF.Ceiling((this.enemy.Strength + this.enemy.Weapon - this.player.Armor) * (1 + value)));

        }

        public static implicit operator bool(Fight fight)
        {
            return fight.Won;
        }
        #endregion

        #region Fields
        Player player;
        Enemy enemy;
        int ExpToWin;
        #endregion
    }
}