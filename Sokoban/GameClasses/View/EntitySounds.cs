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
        public EntitySounds(FileInfo fs)
        {
            //DeadSound = ds;
            FootStepSound = new FileInfo(fs.FullName);
        }

        public FileInfo DeadSound 
        {
            get { return DeadSound; }
            private set
            {
                if (value== null)
                    throw new ArgumentNullException("value");
                DeadSound = value;
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
    }
}
