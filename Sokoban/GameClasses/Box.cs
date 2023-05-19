using Sokoban.GameClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Box:Entity
    {
        public bool Win { get; set; }

        public override bool IsDead { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Box(int x, int y):base(x, y)
        {
            Model = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Box.png"));
        }
    }
}
