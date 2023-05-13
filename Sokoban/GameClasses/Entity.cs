using Sokoban.GameClasses.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses
{
    public abstract class Entity
    {
        public Entity(int x, int y)
        {
            X = x; Y = y;
        }
        public Image Model { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract bool IsDead { get; set; }
    }
}
