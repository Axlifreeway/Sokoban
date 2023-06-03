using System.Collections.Generic;
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
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\Sounds\\PlayerSounds\\footsteps2.wav"));

            var deadSound = new FileInfo(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\Sounds\\PlayerSounds\\death.wav"));

            var gd = new FileInfo(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\Sounds\\PlayerSounds\\getDamage.mp3"));

            PlayerSounds = new EntitySounds(footStepSound, deadSound, gd);
            
            HP = new List<HealthPoints>();
            for (int i = 0; i < 5; i++)
                HP.Add(new HealthPoints());
        }

        public List<HealthPoints> HP { get; set; }

        public override bool IsDead { get => HP.Count == 0; }
    }
}
