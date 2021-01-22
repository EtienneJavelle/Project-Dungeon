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
            this.ExpToWin = enemy.exp;
            do {
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
                this.player.GainExp(this.ExpToWin);
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
                        tmp = rand.Next(1, 10);
                        this.enemy.LooseHealth((this.player.Strength - this.enemy.Armor) * tmp);
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
        /*
            if (choice == 1)
            {
                //enemy.pv = enemy.pv -(personnage.Force + personnage.Arme − enemy.Armure) ∗ temp;


                // a deplacer 
                //if (enemy.pv <=0 )
                //{
                //Room.Inventaire = enemy.Inventaire; 
                //Player.exp += enemy.exp
                // }
            }
            else
            {
                // personnage.Bourse = personnage.Bourse / 2;
            }
        */
        }

        public void EnemyTurn()
        {
            Console.WriteLine("EnemyTour");

            var rand = new Random();
            int tmp = rand.Next(1, 10);
            this.player.LooseHealth((this.enemy.Strength - this.player.Armor) * tmp);

            //player.pv = player.pv -(enemy.Force + enemy.Arme − player.Armure) ∗ temp;


            // a jouter dans la classe prncipale 
            //while (i < 10)
            //{
            //    Combat.TurnCounter();
            //    i += 1;
            //}
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