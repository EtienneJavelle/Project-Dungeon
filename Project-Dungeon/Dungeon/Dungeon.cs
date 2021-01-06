using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Dungeon
    {
        #region Variables
        public char[,] DungeonMap = new char[5, 5]
            {
                {'-','M','I','-','B' },
                {'-','I','-','M','-' },
                {'S','M','B','M','I' },
                {'I','-','M','E','M' },
                {'I','-','M','-','B' }
            };
        #endregion

        #region Construct
        public Dungeon(char[,] dungeonMap)
        {
            DungeonMap = dungeonMap;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            string tmp = "";
            for (int x = 0; x < DungeonMap.GetLength(0); x++)
            {
                for (int y = 0; y < DungeonMap.GetLength(1); y++)
                {
                    tmp += DungeonMap[x, y];
                }
                tmp += "\n";
            }
            return tmp;
        }
        #endregion
        
        #region Methods
        #endregion

        #region Fields
        #endregion
    }
}
