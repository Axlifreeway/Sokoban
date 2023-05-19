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
        public Image Model { get; protected set; }
        public PlayerFrames PlayerFrames { get; protected set; }
        public EntitySounds PlayerSounds { get; protected set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int DirX { get; set; }
        public int DirY { get; set; }

        public Direction Direction
        {
            get
            {
                if (DirX == 0 && DirY == 1)
                    return Direction.Down;
                else if (DirX == 0 && DirY == -1)
                    return Direction.Up;
                else if (DirX == 1 && DirY == 0)
                    return Direction.Right;
                else if (DirX == -1 && DirY == 0)
                    return Direction.Left;
                else return Direction.Down;
            }
        }

        public abstract bool IsDead { get; }
    }
}
