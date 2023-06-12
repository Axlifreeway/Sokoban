using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses
{
    public class MusicSettings
    {
        int musicVolume;
        public int MusicVolume
        {
            get
            {
                return musicVolume;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException();
                musicVolume = value;
            }
        }
        int soundsVolume;
        public int SoundsVolume
        {
            get
            {
                return soundsVolume;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException();
                soundsVolume = value;
            }
        }
    }
}
