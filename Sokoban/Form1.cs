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

namespace Sokoban
{
    public partial class Form1 : Form
    {
        public Timer timer1 = new Timer();
        public Map map;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);

            GameInitialisation();
        }

        public void GameInitialisation()
        {
            map = new Map(Levels.level_1);
            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            Invalidate();
            if (map.player.X == map.Box.X && map.player.Y == map.Box.Y) map.BoxMove();
        }

        private void CheckOnPush(object sender, EventArgs e)
        {
            
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            map.PlayerMove(e);           
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphicsMap = e.Graphics;
            Graphics graphicsPlayer = e.Graphics;
            Graphics graphicsBox = e.Graphics;
            for (int i = 0; i < map.cells.GetLength(0); i++)
            {
                for (int j = 0; j < map.cells.GetLength(1); j++)
                {
                    graphicsMap.DrawImage(map.cells[i, j].GetModel(), Levels.Width * i, Levels.Height * j);
                }
            }
            graphicsPlayer.DrawImage(map.player.Model, map.player.X, map.player.Y);
            graphicsBox.DrawImage(map.Box.Model, map.Box.X, map.Box.Y);
        }
    }
}
