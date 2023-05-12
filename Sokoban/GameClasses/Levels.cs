using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public static class Levels
    {
        public static int LevelsCount = 4;
        public static int currentLevel = 1;
        public static int Size = 128;

        public static int[,] level_1 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 0, 0, 1, 0, 4 },
            {4, 0, 2, 0, 0, 0, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 0, 0, 0, 0, 6, 4 },
            {4, 3, 0, 0, 0, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_2 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 3, 2, 0, 2, 0, 4 },
            {4, 0, 0, 1, 0, 1, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_3 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 4, 0, 0, 0, 0, 4 },
            {4, 3, 2, 0, 4, 2, 0 },
            {4, 4, 4, 0, 1, 0, 0 },
            {4, 4, 4, 0, 4, 4, 4 },
            {4, 4, 4, 1, 4, 4, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_4 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 4, 0, 0, 0, 4 },
            {4, 3, 4, 0, 4, 0, 4 },
            {4, 0, 4, 0, 4, 0, 4 },
            {4, 0, 4, 0, 4, 2, 4 },
            {4, 0, 0, 0, 4, 1, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };
        public static int[,] GetLevel(int i)
        {
            switch (i)
            {
                case 1: return level_1;
                case 2: return level_2;
                case 3: return level_3;
                case 4: return level_4;
                default:
                    return null;
            }
        }
    }
}
