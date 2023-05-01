using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Player
    {
        public Player(int x, int y)
        {
            X = x; Y = y;
            Model = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\MainHero.png")); 
        }
        public Image Model { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int DirX { get; set; }
        public int DirY { get; set; }
    }
}
