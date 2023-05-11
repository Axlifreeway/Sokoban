using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Box
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

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
