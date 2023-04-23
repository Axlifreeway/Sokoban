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
        public MenuForm()
        {
            InitializeComponent();
            GameMusic.GetMenuMusic();
        }

        private void gameStartButton_Click(object sender, EventArgs e)
        {
            var game = new GameForm();
            GameMusic.StopMusic();
            game.Show();
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
