using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Combat
    {
        #region Variables
        static public int turn { get; set; }
        //static public bool turnIs { get; set; }

        #endregion


        #region Methods

        static public void TurnCounter()
        {
            if (turn % 2 == 0)
            {
                Console.WriteLine("playerTour");
                //turnIs = true;
                PlayerTrun();
            }

            if (turn % 2 != 0)
            {
                Console.WriteLine("EnemyTour");
                // turnIs = false;
                EnemyTurn();
            }
            turn = turn + 1;

        }

        static public void PlayerTrun() // PlayerTrun(personnage perso ; personnage enemy)
        {
            var rand = new Random();

            Console.WriteLine("1 : Attaquer 2: Fuir");
            string strchoice = Console.ReadLine();
            int choice = int.Parse(strchoice);

            if (choice == 1)
            {  
                int temp  = rand.Next(1, 10);
               
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
                int temp = rand.Next(1, 2);
                
                if (temp == 1) ;// return previous room
               // personnage.Bourse = personnage.Bourse / 2;
            }
        }

        static public void EnemyTurn()
        {
            var rand = new Random();
            int temp = rand.Next(1, 10);

            //player.pv = player.pv -(enemy.Force + enemy.Arme − player.Armure) ∗ temp;


            // a jouter dans la classe prncipale 
            //while (i < 10)
            //{
            //    Combat.TurnCounter();
            //    i += 1;
            //}
        }

        #endregion
    }
}
