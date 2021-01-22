using System;

namespace Project_Dungeon
{
    class Program
    {
        #region Items
        public static string[] Items = new string[]
        {
            "Pot_str",
            "Pot_hp",
            "Pot_hpmax"
        };
        #endregion
        static void Main(string[] args)
        {
            #region Maps
            DungeonFloor[] DungeonFloors = new DungeonFloor[]
            {
                new DungeonFloor(new char[,]
                {
                    {'H','M','I','-','B' },
                    {'-','I','O','M','-' },
                    {'-','M','B','H','I' },
                    {'I','-','M','E','M' },
                    {'I','-','M','-','B' }
                }),
                new DungeonFloor(new char[,]
                {
                    {'H','O','-','-','-' },
                    {'-','O','-','-','-' },
                    {'-','O','O','H','-' },
                    {'-','O','-','-','-' },
                    {'-','-','-','O','-' }
                })
            };
            #endregion


            Player player = new Player(15, 7)
            {
                Position = new Vector2Int(2, 0)
            };
            Dungeon dungeon = new Dungeon(DungeonFloors);

            ConsoleKeyInfo input;

            do{
                Console.Clear();
                Console.WriteLine(player);
                Console.WriteLine("Etage " + dungeon.Floor);
                Console.WriteLine("Appuyex sur \"I\" pour ouvrir l\'inventaire");
                dungeon.DrawMap(player.Position);

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

            else if (input.Key == ConsoleKey.E)
            {
                if (dungeon.DungeonMaps[dungeon.Floor].ResetMap[player.Position.x, player.Position.y] == 'H') dungeon.ChangeFloor(+1);
            }
            else if (input.Key == ConsoleKey.Q)
            {
                if (dungeon.DungeonMaps[dungeon.Floor].ResetMap[player.Position.x, player.Position.y] == 'H') dungeon.ChangeFloor(-1);
            }

            else if (input.Key == ConsoleKey.I) player.ShowInventory();

            if (player.Move(dir, dungeon)) CheckRoom(player, dungeon);

            return input;
        }

        private static void CheckRoom(Player player, Dungeon dungeon)
        {
            char pos = dungeon.DungeonMaps[dungeon.Floor].ResetMap[player.Position.x, player.Position.y];
            switch (pos)
            {
                case 'M':
                    if (new Fight(player, new Enemy(new Random().Next(1, 15), new Random().Next(1, 5))))
                        dungeon.KillMonster(player.Position);
                    else GameLost();
                    break;
                case 'I':
                    switch (new Random().Next(0,Items.Length))
                    {
                        case 0:
                            player.AddItem(new Pot_str("Potion de Force", 5));
                            break;
                        case 1:
                            player.AddItem(new Pot_hp("Potion de Soin", 5));
                            break;
                        case 2: 
                            player.AddItem(new Pot_hpmax("Potion de Vie", 5));
                            break;
                        default:
                            break;
                    }
                    dungeon.TakeItem(player.Position);
                    break;
                case 'B':
                    player.Sleep();
                    break;
                case 'E':
                    GameExit();
                    break;
                default:
                    break;
            }
        }

        private static void GameExit()
        {
            Console.Clear();
            Console.WriteLine("Won");
            Leave();
        }

        private static void GameLost()
        {
            Console.Clear();
            Console.WriteLine("Lost");
            Leave();
        }
        static void Leave()
        {
            Console.WriteLine("\"quit\" to leave");
            do if (Console.ReadLine().ToLower().Contains("quit")) Environment.Exit(0);
            while (true);

        }
    }
}
