using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Sokoban.GameClasses;
using Sokoban.GameClasses.Servis;
using Sokoban.GameClasses.View;
using System.Diagnostics.Eventing.Reader;

namespace Sokoban
{
    public partial class GameForm : Form
    {
        public static Timer timer1 = new Timer();
        public static Map map;

        public GameForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);

            GameInitialisation(Levels.currentLevel);
        }

        public static void GameInitialisation(int level)
        {
            map = new Map(Levels.GetLevel(level));
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (IsKeyPress)
            {
                map.Player.PlayerFrames.CurrentFrame += 1;
                IsKeyPress = !map.Player.PlayerFrames.IsEndAnimate;
                if (map.Player.PlayerFrames.CurrentFrame == 2)
                    GameMusic.PlaySound(map.Player.PlayerSounds.FootStepSound);
                GameMusic.StopMusic();
            }
            else
            {
                Painter.start = new Point(map.Player.X, map.Player.Y);
            }

            if (++TickCount == 10)
            {
                Mob.Behavior(map);
                TickCount = 0;
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
            Painter.Paint(sender, e, map);
        }
    }
}
