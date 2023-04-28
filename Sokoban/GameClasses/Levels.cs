using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public static class Levels
    {
        public static int Width = 128;
        public static int Height = 128;

        public static int[,] level_1 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 0, 0, 1, 0, 4 },
            {4, 0, 2, 0, 0, 0, 4 },
            {4, 0, 0, 0, 1, 0, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 3, 0, 0, 0, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[,] level_2 = new int[,]
        {
            {4, 4, 4, 4, 4, 4, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 0, 2, 0, 0, 2, 4 },
            {4, 0, 0, 1, 0, 1, 4 },
            {4, 0, 0, 0, 0, 0, 4 },
            {4, 3, 0, 0, 0, 0, 4 },
            {4, 4, 4, 4, 4, 4, 4 },
        };
    }
}
