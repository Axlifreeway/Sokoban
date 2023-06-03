using Sokoban.GameClasses;
using Sokoban.GameClasses.View;
using Sokoban.Menu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class MenuForm : Form
    {
        GameMusic music;
        Timer timer = new Timer();
        Mob mob = new Mob(150, 150, MobType.Strong);
        Player player = new Player(500, 150);
        Map map;
        Settings settings = new Settings();
        public int[,] menu = new int[,]
        {
            {4, 0, 0, 0, 0, 0},
            {4, 0, 0, 0, 0, 0},
            {4, 0, 0, 0, 0, 0},
            {4, 0, 0, 0, 0, 0},
            {4, 0, 0, 0, 0, 0},
            {4, 0, 0, 0, 0, 0},
            {4, 0, 0, 0, 0, 0},
        };


        public MenuForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            music = new GameMusic();
            Paint += OnPaint;
            timer.Interval = 200;
            timer.Tick += Update; 
            timer.Start();
            settings.MusicVolume = 100;
            settings.SoundsVolume = 100;    
            map = new Map(menu);
            music.MusicVolume = 100;
            music.currentPlaylist = music.menu;
            music.PlayPlaylist();
        }

        private void gameStartButton_Click(object sender, EventArgs e)
        {
            var game = new GameForm(settings);
            music.StopMusic();
            timer.Stop();
            game.ShowDialog();
            timer.Start();
            music.PlayPlaylist();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var game = new SettingsForm();
            music.StopMusic();
            timer.Stop();
            game.ShowDialog();
            music.MusicVolume = game.volume1;
            music.SoundsVolume = game.volume2;
            settings = game.GetSettings();
            timer.Start();
            music.PlayPlaylist();
        }

        private void authorsButton_Click(object sender, EventArgs e)
        {
            var game = new AuthorsForm();
            timer.Stop();
            game.ShowDialog();
            timer.Start();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Update(object sender, EventArgs e)
        {
            player.PlayerFrames.CurrentFrame += 1;
            mob.PlayerFrames.CurrentFrame += 1;
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(map.BackGround, 0, 0);
            for (int i = 0; i < map.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < map.Cells.GetLength(1); j++)
                {
                    g.DrawImage(map.Cells[i, j].GetModel(), Levels.Size * i, Levels.Size * j);
                }
            }
            var p = player;
            var idCurrentFrame = p.PlayerFrames.CurrentFrame;
            g.DrawImage(p.PlayerFrames[Direction.Right, idCurrentFrame], new Point(p.X, p.Y));

            var m = mob;
            var idCurrentFrame2 = m.PlayerFrames.CurrentFrame;
            g.DrawImage(m.PlayerFrames[Direction.Right, idCurrentFrame2], new Point(m.X, m.Y));
        }
    }
}
