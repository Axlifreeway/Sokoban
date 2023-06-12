using Sokoban.GameClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.Menu
{
    public partial class SettingsForm : Form
    {
        public int volume1 { get; private set; }
        public int volume2 { get; private set; }
        public SettingsForm()
        {
            InitializeComponent();
            volume1 = 100;
            volume2 = 100;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            volume1 = (int)numericUpDown1.Value;
            volume2 = (int)numericUpDown2.Value;
        }

        public MusicSettings GetSettings()
        {
            var set = new MusicSettings();
            set.MusicVolume = volume1;
            set.SoundsVolume = volume2;
            return set;
        }
    }
}
