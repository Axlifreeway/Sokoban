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
    public static class MainHero
    {
        static MainHero() { }
        public static Image Model { get; set; }
        public static float X { get; set; }
        public static float Y { get; set; }
        public static int DirX {get; set;}
        public static int DirY { get; set;}
        public static void Move(int x, int y)
        {
            X += x * DirX;
            Y += y * DirY;
        }
    }

    public class Cells
    {
        public Cells(){ }
        public enum CellType
        {
            Classic,
            Win
        }
        public Image GetModel(CellType type)
        {
            if(type == CellType.Classic) return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Classic.png"));
            else return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\WinCell.png"));
        }
    }

    public class Map
    {
        public Image[,] cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Map(int[,] map)
        {           
            Width = map.GetLength(0);
            Height = map.GetLength(1);
            cells = Transform(map);
        }

        public Image[,] Transform(int[,] map)
        {
            Cells cell = new Cells();
            Image[,] cellMap = new Image[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    cellMap[i, j] = cell.GetModel((Cells.CellType)map[i,j]);
                }
            }
            return cellMap;
        }
    }

    public class Box
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Image Model { get; }
        public Box(int x, int y)
        {
            X = x;
            Y = y;
            Model = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Box.png"));
        }
        public void Move()
        {
            X += MainHero.DirX * 128;
            Y += MainHero.DirY * 128;
            if (X == 384 && Y == 384)
            {
                X = 256;
                Y = 256;
                MainHero.X = 0;
                MainHero.Y = 0;
                MessageBox.Show("Ты победил!");
            }
        }
    }
}
