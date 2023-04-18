using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Sokoban
{
    public class Player
    {
        public Player(int x, int y) { X = x; Y = y; Model = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\MainHero.png")); }
        public Image Model { get; }
        public float X { get; set; }
        public float Y { get; set; }
        public int DirX {get; set;}
        public int DirY { get; set;}
        public void Move(int x, int y, Map map)
        {
            float moveX = x * DirX;
            float moveY = y * DirY;
            if (X + moveX >= 0 && X + moveX < map.Width)
                X += moveX;
            if (Y + moveY >= 0 && Y + moveY < map.Height)
                Y += y * DirY;
        }
    }

    public class Cells
    {
        public Cells(){ }
        public float X { get; set; }
        public float Y { get; set; }
        public CellType Type { get; set; }
        public enum CellType
        {          
            Classic,
            Win,
            Player,
            Box,
            Wall
        }
        public Image GetModel()
        {
            if(Type == CellType.Win) return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\WinCell.png"));
            else if (Type == CellType.Wall) return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Wall.png"));
            else return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Classic.png"));
        }
    }

    public class Map
    {
        public Cells[,] cells { get; set; }
        public Player player { get; set; }
        public Box Box { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public static int CurrentLevel { get; set; }

        public Map(int[,] map)
        {           
            Width = map.GetLength(0) * Levels.Width;
            Height = map.GetLength(1) * Levels.Height;
            Init(map);
        }

        public void Init(int[,] map)
        {
            cells = new Cells[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == 3) player = new Player(i * Levels.Width, j * Levels.Height);
                    if (map[i, j] == 2) Box = new Box(i * Levels.Width, j * Levels.Height);
                    cells[i, j] = new Cells();
                    cells[i, j].Type = (Cells.CellType)map[i, j];
                }
            }
        }

        public void PlayerMove(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    player.DirY = -1;
                    player.DirX = 0;
                    player.Move(0, 128, this);
                    break;
                case Keys.Down:
                    player.DirY = 1;
                    player.DirX = 0;
                    player.Move(0, 128, this);
                    break;
                case Keys.Left:
                    player.DirY = 0;
                    player.DirX = -1;
                    player.Move(128, 0, this);
                    break;
                case Keys.Right:
                    player.DirY = 0;
                    player.DirX = 1;
                    player.Move(128, 0, this);
                    break;
                default:
                    break;
            }
        }

        public void BoxMove()
        {
            Random rnd = new Random();
            if(player.DirX * Levels.Width + Box.X < Width && player.DirX * Levels.Width + Box.X > 0 
                && cells[player.DirX + Box.X / Levels.Width, Box.Y / Levels.Height].Type != Cells.CellType.Wall)
                Box.X += player.DirX * Levels.Width;

            if (player.DirY * Levels.Height + Box.Y < Height && player.DirY * Levels.Height + Box.Y > 0 
                && cells[Box.X / Levels.Width, Box.Y / Levels.Height + player.DirY].Type != Cells.CellType.Wall)
                Box.Y += player.DirY * Levels.Height;

            if (cells[Box.X / Levels.Width, Box.Y / Levels.Height].Type == Cells.CellType.Win)
            {
                Box.X = Levels.Width * rnd.Next(1, 6);
                Box.Y = Levels.Height * rnd.Next(1, 6);
                player.X = 0;
                player.Y = 0;
                MessageBox.Show("Ты победил!");
            }
        }
    }

    public class Box
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Image Model { get; }
        public Box(int x, int y)
        {
            X = x;
            Y = y;
            Model = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Box.png"));
        }        
    }
}
