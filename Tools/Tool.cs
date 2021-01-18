using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    struct Vector2Int
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x + b.x, a.y + b.y);
        }

        /// <summary>
        /// Shorthand for writing Vector2(0,1).
        /// </summary>
        public static Vector2Int right { get { return new Vector2Int(0, 1); } }
        /// <summary>
        /// Shorthand for writing Vector2(0,-1).
        /// </summary>
        public static Vector2Int left { get { return new Vector2Int(0, -1); } }
        /// <summary>
        /// Shorthand for writing Vector2(1,0).
        /// </summary>
        public static Vector2Int down { get { return new Vector2Int(1, 0); } }
        /// <summary>
        /// Shorthand for writing Vector2(-1,0).
        /// </summary>
        public static Vector2Int up { get { return new Vector2Int(-1, 0); } }
        /// <summary>
        /// Shorthand for writing Vector2(0,0).
        /// </summary>
        public static Vector2Int zero { get { return new Vector2Int(0, 0); } }

    }

    static class Extentions
    {
        public static Vector2Int Clamp(this Vector2Int a, Vector2Int max)
        {
            Vector2Int tmp = Vector2Int.zero;
            if (a.x < max.x) tmp.x = a.x;
            else tmp.x = max.x;
            if (a.y < max.y) tmp.y = a.y;
            else tmp.y = max.y;
            return tmp;
        }
    }
}
