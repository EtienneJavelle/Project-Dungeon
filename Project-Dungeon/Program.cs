using System;

namespace Project_Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] Level1 = new char[5, 5]
            {
                {'-','M','I','-','B' },
                {'-','I','-','M','-' },
                {'S','M','B','M','I' },
                {'I','-','M','E','M' },
                {'I','-','M','-','B' }
            };

            int[,]playerPos = new int[1, 2] { { 2, 0 } };

            Dungeon dungeon = new Dungeon(Level1);

            string input;
            do
            {
                dungeon.DungeonMap[playerPos[0, 0], playerPos[0, 1]] = 'P';
                Console.Write(dungeon);
                input = Console.ReadLine().ToLower();
                if(input == "d") playerPos[0,1]++;
                if(input == "a") playerPos[0,1]--;
                if(input == "s") playerPos[0,0]++;
                if(input == "w") playerPos[0,0]--;

                Console.Clear();
            } while (input != "quit");
        }
    }
}
