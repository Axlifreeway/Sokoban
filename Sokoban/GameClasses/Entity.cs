using Sokoban.GameClasses.View;
using System;

namespace Sokoban.GameClasses
{
    public abstract class Entity
    {
        public Entity(int x, int y)
        {
            X = x; Y = y;
        }
      
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
            set
            {
                switch(value) 
                {
                    case Direction.Down:
                        DirX = 0; DirY = 1;
                        break;
                    case Direction.Up:
                        DirX = 0; DirY = -1;
                        break;
                    case Direction.Right:
                        DirX = 1;  DirY = 0;
                        break;
                    case Direction.Left:
                        DirX = -1; DirY = 0;
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        public abstract bool IsDead { get; }
    }
}
