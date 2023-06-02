using Sokoban.GameClasses.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class MenuForm : Form
    {
        GameMusic music;
        public MenuForm()
        {
            InitializeComponent();
            music = new GameMusic();
            music.PlaySoundLooping(music.PlayerMenuSounds, music.menuMediaList.First());
        }

        private void gameStartButton_Click(object sender, EventArgs e)
        {
            var game = new GameForm();
            music.StopMusic(music.PlayerMenuSounds);
            game.ShowDialog();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }

        private void authorsButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
