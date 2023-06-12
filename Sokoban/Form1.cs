using System;
using System.Drawing;
using System.Windows.Forms;
using Sokoban.GameClasses;
using Sokoban.GameClasses.Servis;
using Sokoban.GameClasses.View;
namespace Sokoban
{
    public partial class GameForm : Form
    {
        Timer timerAnimate;
        bool IsKeyMovePress;
        bool IsWalk = false;
        Map map;
        int TickCount = 0;
        int TickForMoveMob = 10;
        GameMusic music;
        Painter painter;
        Controller controller;


        public GameForm(Controller controller, Painter painter, GameMusic musicPlayer)
        {
            InitializeComponent();
            this.music = musicPlayer;
            this.painter = painter;
            this.controller = controller;          
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timerAnimate = new Timer();
            timerAnimate.Interval = 100;
            timerAnimate.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);           
            music.currentPlaylist = music.game;
            music.PlayPlaylist();
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
            timerAnimate.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (map.Player.IsDead)
            {
                map.Form.GameInitialisation(Levels.currentLevel);
                music.PlaySound(map.Player.PlayerSounds.DeadSound.FullName, 100);
                MessageBox.Show("Вы умерли");
            }

            if (IsKeyMovePress)
            {
                map.Player.PlayerFrames.CurrentFrame += 1;
                IsKeyMovePress = !map.Player.PlayerFrames.IsEndAnimate;
                if (map.Player.PlayerFrames.CurrentFrame == 2)
                {
                    music.PlaySound(map.Player.PlayerSounds.FootStepSound.FullName);
                }
            }
            else
            {
                painter.start = new Point(map.Player.X, map.Player.Y); 
            }
            TickCount += 1;
            if(TickCount % TickForMoveMob == 0 && !IsWalk)
            {
                var mob = map.Mob;
                IsWalk = controller.MobMoveToPlayer(map, TickCount);
                if (TickCount == Mob.SecondsNeededForDamage)
                    TickCount = 0;
            }

            if (IsWalk)
            {
                if (map.Mob != null)
                {
                    map.Mob.PlayerFrames.CurrentFrame += 1;
                    IsWalk = !map.Mob.PlayerFrames.IsEndAnimate;
                    if (map.Mob.PlayerFrames.CurrentFrame == 2)
                    {
                        music.PlaySound(map.Player.PlayerSounds.FootStepSound.FullName);
                    }
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
            if (!IsKeyMovePress)
                IsKeyMovePress = controller.PlayerMove(e, map);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            painter.Paint(sender, e, map);
        }

        private void GameForm_Leave(object sender, EventArgs e)
        {
            
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            music.StopMusic();
        }
    }
}
