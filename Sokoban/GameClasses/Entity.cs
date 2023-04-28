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
        public Entity(int x, int y, Image model)
        {
            X = x; Y = y;
            Model = model;
        }
        public Image Model { get; }
        public float X { get; set; }
        public float Y { get; set; }
        public abstract bool IsDead { get; set; }
    }
}
