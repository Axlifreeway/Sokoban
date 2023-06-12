using Microsoft.DirectX.AudioVideoPlayback;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.DirectX.AudioVideoPlayback.Audio; 


namespace Sokoban.GameClasses.View
{
    public class GameMusic
    {
        List<FileInfo> gameMediaList = new List<FileInfo>();
        List<FileInfo> menuMediaList = new List<FileInfo>();
        public List<Audio> menu =  new List<Audio>();
        public List<Audio> game = new List<Audio>();
        public List<Audio> currentPlaylist = new List<Audio>();

        public Audio PlayerStep { get; private set; }
        int musicVolume = 0;
        public int MusicVolume
        {
            get
            {
                return musicVolume;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException();
                musicVolume = -100 * (100 - value);
            }
        }
        int soundsVolume = 0;
        public int SoundsVolume
        {
            get
            {
                return soundsVolume;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException();
                soundsVolume = -100 * (100 - value);
            }
        }


        public GameMusic(MusicSettings settings)
        {
            menuMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\menumusicpiano.wav")));

            gameMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\415805__sunsai__menu-background-musicRobin Heijn.wav")));

            foreach (FileInfo file in menuMediaList)
            {
                menu.Add(new Audio(file.FullName));
            }
            foreach (FileInfo file in gameMediaList)
            {
                game.Add(new Audio(file.FullName));
            }
            SoundsVolume = settings.SoundsVolume;
            MusicVolume = settings.MusicVolume;
        }

        public GameMusic()
        {
            menuMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\menumusicpiano.wav")));

            gameMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\415805__sunsai__menu-background-musicRobin Heijn.wav")));

            foreach (FileInfo file in menuMediaList)
            {
                menu.Add(new Audio(file.FullName));
            }
            foreach (FileInfo file in gameMediaList)
            {
                game.Add(new Audio(file.FullName));
            }
        }

        public void PlaySound(string fn)
        {  
            var sound = new Audio(fn);
            sound.Open(fn);
            sound.Volume = SoundsVolume;
            sound.Play();
        }

        public void PlaySound(string fn, int volume)
        {
            var sound = new Audio(fn);
            sound.Open(fn);
            sound.Volume = -100 * (100 - volume);
            sound.Play();
        }

        public void PlayPlaylist()
        {
            foreach (var sound in currentPlaylist)
            {
                sound.Volume = MusicVolume;
                sound.Play();
            }
        }

        public void StopMusic() 
        {
            foreach (var sound in currentPlaylist)
            {
                if (sound.State == StateFlags.Running)
                {
                    sound.Stop();
                }
            }
        }
    }
}
