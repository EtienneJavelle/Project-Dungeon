using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class DungeonFloor
    {
        #region Variables
        public char[,] Map { get; private set; }
        public char[,] ResetMap { get; private set; }
        #endregion

        #region Construct
        public DungeonFloor(char[,] Map)
        {
            this.Map = Map;
            this.ResetMap = (char[,])Map.Clone();
        }
        #endregion
    }
    
    class Dungeon
    {
        #region Variables
        public DungeonFloor[] DungeonMaps { get; private set; }
        public Vector2Int MaxFloorSize { get; private set; }
        public int MaxFloor { get; private set; }
        #endregion

        #region Construct
        public Dungeon(DungeonFloor[] DungeonMaps, int Floor = 0)
        {
            this.DungeonMaps = DungeonMaps;
            this.Floor = Floor;
            this.MaxFloorSize = new Vector2Int(DungeonMaps[0].ResetMap.GetLength(0)-1, DungeonMaps[0].ResetMap.GetLength(1)-1);
            this.MaxFloor = DungeonMaps.Length-1;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            string tmp = "";
            for (int x = 0; x < this.DungeonMaps[Floor].Map.GetLength(0); x++)
            {
                for (int y = 0; y < this.DungeonMaps[Floor].Map.GetLength(1); y++)
                {
                    tmp += this.DungeonMaps[Floor].Map[x, y];
                }
                tmp += "\n";
            }
            return tmp;
        }
        #endregion

        #region Methods
        public void DrawMap(Vector2Int pos)
        {
            this.ResetMap();
            /*
            string[] map = this.ToString().Split('P');
            Console.Write(map[0]);
            Console.Write("P", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
            Console.ResetColor();
            Console.Write(map[1]);
            */
            this.DungeonMaps[Floor].Map[pos.x, pos.y] = 'P';
            string map = this.ToString();
            foreach (char ch in map)
            {
                ConsoleColor Fcolor = ConsoleColor.White;
                ConsoleColor Bcolor = ConsoleColor.Black;

                switch (ch)
                {
                    case '-':
                        Fcolor = ConsoleColor.DarkGray;
                        Bcolor = ConsoleColor.DarkGray;
                        break;
                    case 'M':
                        Fcolor = ConsoleColor.Red;
                        Bcolor = ConsoleColor.DarkRed;
                        break;
                    case 'H':
                        Fcolor = ConsoleColor.Yellow;
                        Bcolor = ConsoleColor.DarkGray;
                        break;
                    case 'I':
                        Fcolor = ConsoleColor.Green;
                        Bcolor = ConsoleColor.DarkGray;
                        break;
                    case 'B':
                        Fcolor = ConsoleColor.Black;
                        Bcolor = ConsoleColor.Gray;
                        break;
                    case 'O':
                        Fcolor = ConsoleColor.Black;
                        Bcolor = ConsoleColor.Black;
                        break;
                    case 'E':
                        Fcolor = ConsoleColor.Green;
                        Bcolor = ConsoleColor.Green;
                        break;
                    case 'P':
                        Fcolor = ConsoleColor.Black;
                        Bcolor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }

                Console.Write( ch.ToString(), Console.ForegroundColor = Fcolor, Console.BackgroundColor = Bcolor );
            }
        }
        void ResetMap()
        {
            for (int x = 0; x < this.DungeonMaps[Floor].Map.GetLength(0); x++)
            {
                for (int y = 0; y < this.DungeonMaps[Floor].Map.GetLength(1); y++)
                {
                    this.DungeonMaps[Floor].Map[x, y] = this.DungeonMaps[Floor].ResetMap[x, y];
                }
            }
        }

        internal void TakeItem(Vector2Int position)
        {
            this.DungeonMaps[this.Floor].ResetMap[position.x, position.y] = '-';
        }

        public void ChangeFloor(int value)
        {
            this.Floor = Math.Clamp(this.Floor + value, 0, this.MaxFloor);
        }
        public void KillMonster(Vector2Int position)
        {
            this.DungeonMaps[this.Floor].ResetMap[position.x, position.y] = '-';
        }
        #endregion

        #region Fields
        public int Floor;

        #endregion
    }
}
