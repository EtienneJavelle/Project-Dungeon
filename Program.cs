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

            Player player = new Player();
            player.Position = new Vector2Int(2, 0);

            Dungeon dungeon = new Dungeon(DungeonFloors);

            ConsoleKeyInfo input;

            do
            {
                Console.Clear();
                dungeon.DrawMap(player.Position);
                Console.WriteLine("Floor " + dungeon.Floor);

                input = Inputs(player, dungeon);

            } while (input.Key != ConsoleKey.Escape);
        }

        private static ConsoleKeyInfo Inputs(Player player, Dungeon dungeon)
        {
            ConsoleKeyInfo input = Console.ReadKey();
            Vector2Int dir = Vector2Int.zero;
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow) dir = Vector2Int.right;
            else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow) dir = Vector2Int.left;
            else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow) dir = Vector2Int.down;
            else if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow) dir = Vector2Int.up;
            else if (input.Key == ConsoleKey.E) dungeon.Floor++;
            else if (input.Key == ConsoleKey.Q) dungeon.Floor--;

            player.Move(dir);

            player.Position.x = Math.Clamp(player.Position.x, 0, 4);
            player.Position.y = Math.Clamp(player.Position.y, 0, 4);
            dungeon.Floor = Math.Clamp(dungeon.Floor, 0, 1);
            return input;
        }
    }
}
