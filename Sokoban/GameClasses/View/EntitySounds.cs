using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses.View
{
    public class EntitySounds
    {
        public EntitySounds(FileInfo fs, FileInfo ds, FileInfo gd)
        {
            DeadSound = ds;
            FootStepSound = fs;
            GetDamage = gd;
        }
        private FileInfo deadSound;
        public FileInfo DeadSound 
        {
            get { return deadSound; }
            private set
            {
                if (value== null)
                    throw new ArgumentNullException("value");
                deadSound = value;
            }
        }
        private FileInfo footStepSound;
        public FileInfo FootStepSound
        {
            get { return footStepSound; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                footStepSound = value;
            }
        }

        private FileInfo getDamage;
        public FileInfo GetDamage
        {
            get { return getDamage; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                getDamage = value;
            }
        }
    }
}
