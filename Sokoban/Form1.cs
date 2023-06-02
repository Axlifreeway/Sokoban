﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.GameClasses;
using Sokoban.GameClasses.Servis;
using Sokoban.GameClasses.View;
namespace Sokoban
{
    public partial class GameForm : Form
    {
        public Timer timer1;
        public bool IsKeyPress;
        public bool IsWalk = false;
        public Map map;
        public int TickCount = 0;
        int TickForMoveMob = 10;
        public GameMusic music;
        public Painter painter = new Painter();

        public GameForm()
        {
            InitializeComponent();
            timer1 = new Timer();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);
            music = new GameMusic();
            
            GameInitialisation(Levels.currentLevel);
        }

        public void GameInitialisation(int level)
        {
            map = new Map(Levels.GetLevel(level), this);
            
            this.Size = map.Size;

            painter.start = new Point(map.Player.X, map.Player.Y);
            if (map.Mob != null)
            {
                painter.startM = new Point(map.Mob.X, map.Mob.Y);
            }
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (map.Player.IsDead)
            {
                map.Form.GameInitialisation(Levels.currentLevel);
                MessageBox.Show("Вы умерли");
            }

            if (IsKeyPress)
            {
                map.Player.PlayerFrames.CurrentFrame += 1;
                IsKeyPress = !map.Player.PlayerFrames.IsEndAnimate;
                if (map.Player.PlayerFrames.CurrentFrame == 2)
                    music.PlaySound(map.Player.PlayerSounds.FootStepSound);
            }
            else
            {
                painter.start = new Point(map.Player.X, map.Player.Y); 
            }
            TickCount += 1;
            if(TickCount == TickForMoveMob && !IsWalk)
            {
                IsWalk = Mob.Behavior(map);
                TickCount = 0;
            }

            if (IsWalk)
            {
                if (map.Mob != null)
                {
                    map.Mob.PlayerFrames.CurrentFrame += 1;
                    IsWalk = !map.Mob.PlayerFrames.IsEndAnimate;
                }      
            }
            else
            {
                if (map.Mob != null)
                    painter.startM = new Point(map.Mob.X, map.Mob.Y);
            }
            Invalidate();            
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            if (!IsKeyPress)
                IsKeyPress = Controller.PlayerMove(e, map);                  
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            painter.Paint(sender, e, map);
        }

        private void GameForm_Leave(object sender, EventArgs e)
        {
        }
    }
}
