using Sokoban.GameClasses;
using Sokoban.GameClasses.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public class Map
    {
        public int[,] map;
        public Cell[,] Cells { get; set; }
        public Player Player { get; set; }
        public List<Box> Boxes { get; set; }
        public Mob Mob { get; set; }

        public List<Cell> Win { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(int[,] map)
        {
            this.map = map;
            Width = map.GetLength(0) * Levels.Width;
            Height = map.GetLength(1) * Levels.Height;
            Boxes = new List<Box>();
            Win = new List<Cell>();
            Init(map);
        }

        public int this[int x, int y]
        {
            get
            {
                return map[x, y];
            }
            set
            {
                map[x, y] = value;
            }
        }

        public void Init(int[,] map)
        {
            Cells = new Cell[map.GetLength(0), map.GetLength(1)];
            DynamicMap = new Cell[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 3) Player = new Player(i * Levels.Width, j * Levels.Height);
                    if (map[i, j] == 2) Boxes.Add(new Box(i * Levels.Width, j * Levels.Height));
                    if (map[i, j] == 6) Mob = new Mob(i * Levels.Width, j * Levels.Height, MobType.Strong);
                    Cells[i, j] = new Cell(i * Levels.Width, j * Levels.Height);

                    Cells[i, j].Type = (CellType)map[i, j];
                    if (Cells[i, j].Type == CellType.Win) Win.Add(Cells[i, j]);
                }
            }
        }  
        
        public void CheckOnWin()
        {
            int count = 0;
            foreach (var box in Boxes)
            {
                foreach(var cell in Win)
                {
                    if(box.X == cell.X && box.Y == cell.Y)
                        count++;
                }
            }
            if (count == Boxes.Count)
            {
                if (Levels.currentLevel != 4)
                {
                    MessageBox.Show("Победа");
                    GameForm.GameInitialisation(++Levels.currentLevel);
                }
                else
                {
                    MessageBox.Show("Поздравляем, вы прошли игру!");
                    Application.Exit();
                }
            }
        }
    }
}
