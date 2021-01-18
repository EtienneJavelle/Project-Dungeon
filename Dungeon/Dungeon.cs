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
        #endregion

        #region Construct
        public Dungeon(DungeonFloor[] DungeonMaps, int Floor = 0)
        {
            this.DungeonMaps = DungeonMaps;
            this.Floor = Floor;
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
        public void DrawMap(Vector2 pos)
        {
            this.ResetMap();
            this.DungeonMaps[Floor].Map[pos.x, pos.y] = 'P';
            string[] map = this.ToString().Split('P');
            Console.Write(map[0]);
            Console.Write("P", Console.ForegroundColor = ConsoleColor.Black, Console.BackgroundColor = ConsoleColor.White);
            Console.ResetColor();
            Console.Write(map[1]);
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
        #endregion

        #region Fields
        public int Floor;
        #endregion
    }
}
