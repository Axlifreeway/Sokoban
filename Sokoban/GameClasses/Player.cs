using System.Drawing;
using System.IO;
using Sokoban.GameClasses;
using Sokoban.GameClasses.View;

namespace Sokoban
{
    public class Player:Entity
    {
        public Player(int x, int y):base(x, y)
        {            
            Model = new Bitmap(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\MainHero.png"));
            var source = new Bitmap(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\PlayerPicture.png"));
            PlayerFrames = new PlayerFrames(source, 1, 168, 4);

            var footStepSound = new FileInfo(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\Sounds\\PlayerSounds\\footsteps.wav"));
            PlayerSounds = new EntitySounds(footStepSound);
        }

        public static float HP { get; set; }

        public override bool IsDead { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
