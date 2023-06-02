using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public static class Levels
    {
        public static int LevelsCount = 7;
        public static int currentLevel = 1;
        public static int Size = 128;

        public static int[,] level_1 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 0, 0, 1, 0, 4 },
            {4, 0, 3, 0, 0, 0, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 0, 0, 0, 0, 6, 4 },
            {4, 2, 0, 0, 0, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_2 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 2, 3, 0, 3, 0, 4 },
            {4, 0, 0, 1, 0, 1, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_3 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 4, 0, 0, 0, 0, 4 },
            {4, 2, 3, 0, 4, 3, 0 },
            {4, 4, 4, 0, 1, 0, 0 },
            {4, 4, 4, 0, 4, 4, 4 },
            {4, 4, 4, 1, 4, 4, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_4 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 4, 0, 0, 0, 4 },
            {4, 2, 4, 0, 4, 0, 4 },
            {4, 0, 4, 0, 4, 0, 4 },
            {4, 0, 4, 0, 4, 3, 4 },
            {4, 0, 0, 0, 4, 1, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };
        public static int[,] level_5 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 2, 4, 0, 0, 0, 4 },
            {4, 0, 3, 4, 0, 3, 0, 4 },
            {4, 4, 0, 1, 0, 3, 0, 4 },
            {4, 0, 0, 3, 0, 0, 0, 4 },
            {4, 1, 0, 1, 4, 1, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4, 4 },
        };
        public static int[,] level_6 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 4, 4, 0, 0, 0, 4 },
            {4, 0, 1, 1, 0, 0, 4 },
            {4, 0, 4, 1, 4, 2, 4 },
            {4, 0, 4, 3, 3, 0, 4 },
            {4, 0, 3, 0, 0, 4, 4 },
            {4, 4, 0, 0, 0, 4, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_7 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4, 4 },
            {4, 4, 4, 1, 4, 4, 4, 4 },
            {4, 4, 4, 0, 4, 4, 4, 4 },
            {4, 4, 4, 3, 0, 3, 1, 4 },
            {4, 1, 0, 3, 2, 4, 4, 4 },
            {4, 4, 4, 4, 3, 4, 4, 4 },
            {4, 4, 4, 4, 1, 4, 4, 4 },
            {4, 4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] test = new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 1, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 3, 2, 0, 0, 6, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0},
        };
        public static int[,] GetLevel(int i)
        {
            switch (i)
            {
                case 1: return level_1;
                case 2: return level_2;
                case 3: return level_3;
                case 4: return level_4;
                case 5: return level_5;
                case 6: return level_6;
                case 7: return level_7;
                default:
                    return level_7;
            }
        }
    }
}
