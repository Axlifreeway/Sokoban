using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses.View
{
    public class PlayerFrames
    {
        private int countFrames;
        private int currentFrame;
        private Bitmap[] downFrames;
        private Bitmap[] upFrames;
        private Bitmap[] leftFrames;
        private Bitmap[] rightFrames;

        public bool IsEndAnimate { get; private set; }

        public int CurrentFrame 
        {
            get { return currentFrame; }
            set
            {
                if (value < 0 || value > countFrames)
                    throw new ArgumentOutOfRangeException("value");
                if (value != countFrames)
                {
                    currentFrame = value;
                    IsEndAnimate = false;                    
                }
                else
                {
                    currentFrame = 0;
                    IsEndAnimate = true;
                }
            }
        }

        public PlayerFrames(Bitmap sourse, int dx, int dy, int countFrames)
        {
            var resulution = new Rectangle(new Point(0, 0), new Size(Levels.Size, Levels.Size));
            var frames = GetFrames(sourse, resulution, countFrames, dx, dy);
            this[Direction.Down] = frames[0];
            this[Direction.Up] = frames[1];
            this[Direction.Left] = frames[2];
            this[Direction.Right] = frames[3];
            this.countFrames = countFrames;
        }

        public Bitmap this[Direction dir, int i]
        {
            get
            {
                if ((i  < 0 || i >= countFrames))
                    throw new NotImplementedException();

                switch (dir)
                {
                    case Direction.Left:
                        return leftFrames[i];
                    case Direction.Right:
                        return rightFrames[i];
                    case Direction.Down:
                        return downFrames[i];
                    case Direction.Up:
                        return upFrames[i];
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public Bitmap[] this[Direction dir]
        {
            get
            {
                switch (dir)
                {
                    case Direction.Left:
                        return leftFrames;
                    case Direction.Right:
                        return rightFrames;
                    case Direction.Down:
                        return downFrames;
                    case Direction.Up:
                        return upFrames;
                    default:
                        throw new NotImplementedException();
                }
            }
            private set
            {
                switch (dir)
                {
                    case Direction.Left:
                        leftFrames = value;
                        break;
                    case Direction.Right:
                        rightFrames = value;
                        break;
                    case Direction.Down:
                        downFrames = value;
                        break;
                    case Direction.Up:
                        upFrames = value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }



        public  List<Bitmap[]> GetFrames(Bitmap bmp, Rectangle selection, int countFrames, int dx, int dy)
        {
            var frames = new Bitmap[countFrames];
            var listFrames = new List<Bitmap[]>();
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < countFrames; j++)
                {
                    var leftPoint = new Point(selection.X + (selection.Width + dx) * j, dy * i);
                    var newSelection = new Rectangle(leftPoint, selection.Size);
                    Bitmap frame = bmp.Clone(newSelection, bmp.PixelFormat);
                    frames[j] = frame;
                }
                listFrames.Add(frames.ToArray());
            }
            bmp.Dispose();
            return listFrames;

        }
    }
}
