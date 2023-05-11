using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Sokoban.GameClasses.View
{
    public class GameMusic
    {
        public static WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        static List<FileInfo> gameMediaList = new List<FileInfo>();
        static List<FileInfo> menuMediaList = new List<FileInfo>();

        public int Volume
        {
            get { return mediaPlayer.settings.volume; }
            set { mediaPlayer.settings.volume = value; }
        }

        static GameMusic()
        {
            menuMediaList.Add(new FileInfo(
                Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Music\\415805__sunsai__menu-background-musicRobin Heijn.wav")));
            mediaPlayer.settings.volume = 100;
            //gameMediaList.Add(new FileInfo("3.wav"));
            //gameMediaList.Add(new FileInfo("4.mp3"));
        }

        public void GetGameMusic()
        {
            WMPLib.IWMPPlaylist playlist = mediaPlayer.playlistCollection.newPlaylist("myplaylist");
            foreach (var music in gameMediaList)
            {
                var media = mediaPlayer.newMedia(music.FullName);
                playlist.appendItem(media);
            }
            mediaPlayer.currentPlaylist = playlist;
            mediaPlayer.settings.setMode("loop", true);
            mediaPlayer.controls.play();
        }

        public static void PlaySound(FileInfo sound)
        {
            WMPLib.IWMPPlaylist playlist = mediaPlayer.playlistCollection.newPlaylist("lol");
            var media = mediaPlayer.newMedia(sound.FullName);
            playlist.appendItem(media);
            mediaPlayer.currentPlaylist = playlist;
            mediaPlayer.controls.play();
        }

        public static void GetMenuMusic()
        {
            WMPLib.IWMPPlaylist playlist = mediaPlayer.playlistCollection.newPlaylist("myplaylist");
            foreach (var music in menuMediaList)
            {
                var media = mediaPlayer.newMedia(music.FullName);
                playlist.appendItem(media);
            }
            mediaPlayer.currentPlaylist = playlist;
            mediaPlayer.settings.setMode("loop", true);
            mediaPlayer.controls.play();
        }

        public static void StopMusic() 
        {
            mediaPlayer.controls.pause();
        }
    }
}
