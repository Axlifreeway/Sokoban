using System.Drawing;
using System.IO;
using Sokoban.GameClasses;
using Sokoban.GameClasses.View;

namespace Sokoban
{
    public class Player
    {
        public Player(int x, int y)
        {
            X = x; Y = y;
            Model = new Bitmap(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\MainHero.png"));
            var source = new Bitmap(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\PlayerPicture.png"));
            PlayerFrames = new PlayerFrames(source, 1, 168, 4);

            var footStepSound = new FileInfo(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\Sounds\\PlayerSounds\\footsteps.wav"));
            PlayerSounds = new EntitySounds(footStepSound);
        }
        public Image Model { get; }
        
        public PlayerFrames PlayerFrames { get; set; }

        public EntitySounds PlayerSounds { get; }

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
    }
}
