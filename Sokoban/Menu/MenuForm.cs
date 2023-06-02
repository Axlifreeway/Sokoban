using Sokoban.GameClasses.Servis;
using Sokoban.GameClasses;
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
using static System.Windows.Forms.AxHost;

namespace Sokoban
{
    public partial class MenuForm : Form
    {
        GameMusic music;
        Timer timer = new Timer();
        Mob mob = new Mob(150, 150, MobType.Strong);
        Player player = new Player(500, 150);
        Map map;
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
            music.PlaySoundLooping(music.PlayerMenuSounds, music.menuMediaList.First());
            Paint += OnPaint;
            timer.Interval = 200;
            timer.Tick += Update; 
            timer.Start();
            map = new Map(menu);
        }

        private void gameStartButton_Click(object sender, EventArgs e)
        {
            var game = new GameForm();
            music.StopMusic(music.PlayerMenuSounds);
            timer.Stop();
            game.ShowDialog();
            timer.Start();
            music.PlaySoundLooping(music.PlayerMenuSounds, music.menuMediaList.First());
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            
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
