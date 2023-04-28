using Sokoban.GameClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Cell
    {
        public Cell() { }
        public float X { get; set; }
        public float Y { get; set; }
        public CellType Type { get; set; }
        
        public Image GetModel()
        {
            if (Type == CellType.Win) return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\WinCell.png"));
            else if (Type == CellType.Wall) return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Wall.png"));
            else return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Classic.png"));
        }
    }
}
