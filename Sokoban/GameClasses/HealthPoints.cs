using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses
{
    public class HealthPoints
    {
        public HealthPoints() {
            Model = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\heartshealth.png"));

            HealthBack = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\bc.png"));
        }
        public Image Model { get; }

        public Image HealthBack { get; set; }
    }
}
