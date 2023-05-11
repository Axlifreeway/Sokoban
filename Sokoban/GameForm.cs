using System;
using System.Collections.Generic;
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
        public static bool IsKeyPress;
        public Map map;

        public GameForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timer1.Interval = 150;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);
            GameInitialisation();           
        }

        public void GameInitialisation()
        {
            map = new Map(Levels.level_1);
            Painter.start = new Point(map.Player.X, map.Player.Y);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {           
            if (IsKeyPress)
            {
                Painter.idCurrentFrame += 1;                    
                if (Painter.idCurrentFrame == 4)
                {
                    Painter.idCurrentFrame = 0;
                    IsKeyPress = false;
                }
            }
            else
            {
                Painter.start = new Point(map.Player.X, map.Player.Y);
            }
            Invalidate();            
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            if (!IsKeyPress)
            {
                Painter.start = new Point(map.Player.X, map.Player.Y);
                IsKeyPress = Controller.PlayerMove(e, map);
            }                   
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Painter.Paint(sender, e, map);
        }
    }
}
