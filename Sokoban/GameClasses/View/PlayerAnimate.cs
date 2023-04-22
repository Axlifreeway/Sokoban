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
        private Bitmap[] downFrames;
        private Bitmap[] upFrames;
        private Bitmap[] leftFrames;
        private Bitmap[] rightFrames;

        public PlayerFrames(Bitmap sourse, int dx, int dy, int countFrames)
        {
            var resulution = new Rectangle(new Point(0, 0), new Size(Levels.Width, Levels.Height));
            var frames = Painter.getFrames(sourse, resulution, countFrames, dx, dy);
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
                if (i < 0 || i >= countFrames)
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
    }
}
