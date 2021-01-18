using System;

namespace Project_Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Maps
            DungeonFloor[] DungeonFloors = new DungeonFloor[]
            {
                new DungeonFloor(new char[,]
                {
                    {'-','M','I','-','B' },
                    {'-','I','-','M','-' },
                    {'S','M','B','M','I' },
                    {'I','-','M','E','M' },
                    {'I','-','M','-','B' }
                }),
                new DungeonFloor(new char[,]
                {
                    {'-','-','-','-','-' },
                    {'-','-','-','-','-' },
                    {'-','-','-','-','-' },
                    {'-','-','-','-','-' },
                    {'-','-','-','-','-' }
                })
            };
            #endregion

            int[] playerPos = new int[2] { 2, 0 };
            int[] lastPlayerPos = new int[2] { 2, 0 };

            Dungeon dungeon = new Dungeon(DungeonFloors);

            ConsoleKeyInfo input;

            do
            {
                Console.Clear();
                dungeon.DrawMap(playerPos[0], playerPos[1]);
                Console.WriteLine("Floor " + dungeon.Floor);

                input = Inputs(playerPos, dungeon);

            } while (input.Key != ConsoleKey.Escape);
        }

        private static ConsoleKeyInfo Inputs(int[] playerPos, Dungeon dungeon)
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow) playerPos[1]++;
            else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow) playerPos[1]--;
            else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow) playerPos[0]++;
            else if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow) playerPos[0]--;
            else if (input.Key == ConsoleKey.E) dungeon.Floor++;
            else if (input.Key == ConsoleKey.Q) dungeon.Floor--;

            playerPos[0] = Math.Clamp(playerPos[0], 0, 4);
            playerPos[1] = Math.Clamp(playerPos[1], 0, 4);
            dungeon.Floor = Math.Clamp(dungeon.Floor, 0, 1);
            return input;
        }

        static void Move(int[] playerPos, int x, int y, int[] lastPlayerPos)
        {
            lastPlayerPos = playerPos;
            playerPos[0] += x;
            playerPos[1] += y;
        }
    }
}
