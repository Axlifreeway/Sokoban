using Sokoban.GameClasses;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sokoban
{
    public class Map
    {
        public Cell[,] EntityMap { get; set; }
        public Cell[,] Cells { get; set; }
        public Player Player { get; set; }
        public HashSet<Box> Boxes { get; set; }
        public Mob Mob { get; set; }

        public HashSet<Cell> Win { get; set; }
        public Size Size { get;}

        public Image BackGround { get; set; }
        

        public GameForm Form { get; set; }

        public Map(int[,] map, GameForm form)
        {
            Size = new Size(map.GetLength(0), map.GetLength(1));
            Boxes = new HashSet<Box>();
            Win = new HashSet<Cell>();
            Form = form;
            BackGround = new Bitmap(
                    Path.Combine(
                        new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                        "Models\\background.png"));
            Init(map);
        }

        public Map(int[,] map)
        {
            Size = new Size(map.GetLength(0), map.GetLength(1));
            Boxes = new HashSet<Box>();
            Win = new HashSet<Cell>();
            BackGround = new Bitmap(
                    Path.Combine(
                        new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                        "Models\\background.png"));
            Init(map);
        }


        public Cell this[int x, int y]
        {
            get
            {
                return EntityMap[x, y];
            }
            set
            {
                EntityMap[x, y] = value;
            }
        }

        public Cell this[Point point]
        {
            get
            {
                return EntityMap[point.X, point.Y];
            }
            set
            {
                EntityMap[point.X, point.Y] = value;
            }
        }

        public void Init(int[,] map)
        {
            Cells = new Cell[map.GetLength(0), map.GetLength(1)];
            EntityMap = new Cell[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Cells[i, j] = new Cell(i, j);
                    EntityMap[i, j] = new Cell(i, j);
                    Cells[i, j].Type = (CellType)map[i, j];
                    EntityMap[i, j].Type = (CellType)map[i, j];
                    if (Cells[i, j].Type == CellType.Win) Win.Add(Cells[i, j]);

                    if (map[i, j] == 2)
                    {
                        Player = new Player(i, j);
                        EntityMap[i, j].EntityNow = Player;
                    }
                    if (map[i, j] == 3)
                    {
                        var box = new Box(i, j);
                        Boxes.Add(box);
                        EntityMap[i, j].EntityNow = box;
                    }
                    if (map[i, j] == 6)
                    {
                        Mob = new Mob(i, j, MobType.Strong);
                        EntityMap[i, j].EntityNow = Mob;
                    }
                    if (map[i, j] == 8)
                    {
                        Mob = new Mob(i, j, MobType.Boss);
                        EntityMap[i, j].EntityNow = Mob;
                    }
                }
            }
        }

        public Size GetWindowSize()
        {
            return new Size(Size.Width * Levels.Size, Size.Height * Levels.Size);   
        }

        public bool IsAccessCell(Point newPosition, Point direction)
        {
            if (!IsCorrectCell(newPosition)) return false; 
            bool noWall = this[newPosition].Type != CellType.Wall;
            bool canMove = true;
            if (this[newPosition].Type == CellType.Box)
            {
                if (!IsCorrectCell(new Point(newPosition.X + direction.X, newPosition.Y + direction.Y)))
                    return false;
                else
                {
                    canMove = this[newPosition.X + direction.X, newPosition.Y + direction.Y].Type != CellType.Wall
                            && this[newPosition.X + direction.X, newPosition.Y + direction.Y].Type != CellType.Box;
                }
            }
            return noWall && canMove;
        }

        public void ChangeEntityCells(Point position, CellType c1, Point position2, CellType c2)
        {
            this[position].Type = c1;
            this[position2].Type = c2;
        }


        public bool IsCorrectCell(Point point)
        {
            return (point.X < Size.Width && point.Y < Size.Height) && (point.X >= 0 && point.Y >= 0);
        }

        public bool PointIsBoxOrWall(Point p)
        {
            return this[p].Type == CellType.Wall
                       || this[p].Type == CellType.Box;
        }

        public void CheckOnWin()
        {
            int count = 0;
            foreach (var box in Boxes)
                foreach (var cell in Win)
                    if (box.X == cell.X && box.Y == cell.Y) count++;
            if (count == Boxes.Count)
            {
                if (Levels.currentLevel <= Levels.LevelsCount)
                {
                    MessageBox.Show("Победа");
                    Form.GameInitialisation(++Levels.currentLevel);
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
