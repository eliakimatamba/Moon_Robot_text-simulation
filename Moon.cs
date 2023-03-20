using System;

namespace MoonRobotSimulation
{
    class Moon
    {
        private readonly bool[,] map;

        public Moon(int size)
        {
            if (size < 2 || size > 100 || size % 2 != 0)
            {
                throw new ArgumentException("Invalid map size.");
            }

            map = new bool[size, size];
        }

        public bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1);
        }

        public bool IsSafe(int x, int y)
        {
            return IsWithinBounds(x, y) && !map[x, y];
        }

        public void MarkAsUnsafe(int x, int y)
        {
            if (IsWithinBounds(x, y))
            {
                map[x, y] = true;
            }
        }
    }
}


