using Sokoban.GameClasses;
using Sokoban.GameClasses.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public class Map
    {
        public Cell[,] Cells { get; set; }
        public Player Player { get; set; }
        public Box Box { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(int[,] map)
        {
            Width = map.GetLength(0) * Levels.Width;
            Height = map.GetLength(1) * Levels.Height;
            Init(map);
        }

        public void Init(int[,] map)
        {
            Cells = new Cell[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 3) Player = new Player(i * Levels.Width, j * Levels.Height);
                    if (map[i, j] == 2) Box = new Box(i * Levels.Width, j * Levels.Height);
                    Cells[i, j] = new Cell();
                    Cells[i, j].Type = (CellType)map[i, j];
                }
            }
        }     
    }
}
