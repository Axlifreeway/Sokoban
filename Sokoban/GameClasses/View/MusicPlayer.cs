using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses.View
{
    public class GameMusic
    {
        public SoundPlayer PlayerGameSounds = new SoundPlayer();
        public SoundPlayer PlayerMenuSounds = new SoundPlayer();
        public SoundPlayer PlayerGamePhoneSounds = new SoundPlayer();

        public List<FileInfo> gameMediaList = new List<FileInfo>();
        public List<FileInfo> menuMediaList = new List<FileInfo>();

        public GameMusic()
        {
            menuMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\menumusicpiano.wav")));

            gameMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\415805__sunsai__menu-background-musicRobin Heijn.wav")));
        }

        public void PlaySound(FileInfo sound)
        {
            PlayerGameSounds.SoundLocation = sound.FullName;
            PlayerGameSounds.Play();
        }

        public void PlaySoundLooping(SoundPlayer player, FileInfo sound)
        {
            player.SoundLocation = sound.FullName;
            player.PlayLooping();
        }

        public void StopMusic(SoundPlayer player) 
        {
            player.Stop();
            player.Dispose();
        }
    }
}
