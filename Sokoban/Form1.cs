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
    public partial class Form1 : Form
    {
        public static Timer timer1 = new Timer();
        public Map map;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timer1.Interval = 150;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);
            GameInitialisation();
            Painter.currentFrames = Painter.GetDirectionFrames(map);
            Painter.start = new Point(map.Player.X, map.Player.Y);            
            timer1.Start();
        }

        public void GameInitialisation()
        {
            map = new Map(Levels.level_1);           
        }

        public void Update(object sender, EventArgs e)
        {          
            Invalidate();         
            if(Painter.IsKeyPress)
            {
                Painter.idCurrentFrame += 1;
                if (Painter.idCurrentFrame == 3)
                {
                    Painter.idCurrentFrame = 0;                    
                    Painter.IsKeyPress = false;
                }
                Painter.currentFrames = Painter.GetDirectionFrames(map);
            }
            else
            {
                Painter.start = new Point(map.Player.X, map.Player.Y);
            }               
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            Painter.start = new Point(map.Player.X, map.Player.Y);
            Painter.IsKeyPress = Controller.PlayerMove(e, map);           
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Painter.Paint(sender, e, map);
        }
    }
}
