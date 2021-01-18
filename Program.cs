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

            //int[] playerPos = new int[2] { 2, 0 };
            Vector2 playerPos = new Vector2(2, 0);
            Vector2 lastPlayerPos = new Vector2( 2, 0 );

            Dungeon dungeon = new Dungeon(DungeonFloors);

            ConsoleKeyInfo input;

            do
            {
                Console.Clear();
                dungeon.DrawMap(playerPos);
                Console.WriteLine("Floor " + dungeon.Floor);

                input = Inputs(playerPos, dungeon);

            } while (input.Key != ConsoleKey.Escape);
        }

        private static ConsoleKeyInfo Inputs(Vector2 playerPos, Dungeon dungeon)
        {
            ConsoleKeyInfo input = Console.ReadKey();
            Vector2 dir = Vector2.zero;
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow) dir=Vector2.right;
            else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow) dir=Vector2.left;
            else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow) dir=Vector2.down;
            else if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow) dir =Vector2.up;
            else if (input.Key == ConsoleKey.E) dungeon.Floor++;
            else if (input.Key == ConsoleKey.Q) dungeon.Floor--;

            Move(playerPos, dir, Vector2.right);

            playerPos.x = Math.Clamp(playerPos.x, 0, 4);
            playerPos.y = Math.Clamp(playerPos.y, 0, 4);
            dungeon.Floor = Math.Clamp(dungeon.Floor, 0, 1);
            return input;
        }

        static void Move(Vector2 playerPos, Vector2 dir, Vector2 lastPlayerPos)
        {
            lastPlayerPos = playerPos;
            playerPos += dir;
            playerPos += Vector2.right;
        }
    }
}
