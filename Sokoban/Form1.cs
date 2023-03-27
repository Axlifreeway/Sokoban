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
        public Image PlayerModel;
        public Timer timer1 = new Timer();
        public Map map;
        public Box box;

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
            int[,] Intmap = new int[,]
            {
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 1, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
            };
            PlayerModel = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\MainHero.png"));
            MainHero.X = 256;
            MainHero.Y = 0;
            MainHero.Model = PlayerModel;
            map = new Map(Intmap);
            box = new Box(128, 128);
            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            Invalidate();
            if (MainHero.X == box.X && MainHero.Y == box.Y) box.Move();
        }

        private void CheckOnPush(object sender, EventArgs e)
        {
            
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MainHero.DirY = -1;
                    MainHero.DirX = 0;
                    MainHero.Move(0, 128);
                    break;
                case Keys.Down:
                    MainHero.DirY = 1;
                    MainHero.DirX = 0;
                    MainHero.Move(0, 128);
                    break;
                case Keys.Left:
                    MainHero.DirX = -1;
                    MainHero.DirY = 0;
                    MainHero.Move(128, 0);
                    break;
                case Keys.Right:
                    MainHero.DirX = 1;
                    MainHero.DirY = 0;
                    MainHero.Move(128, 0);
                    break;
                default:
                    break;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphicsMap = e.Graphics;
            Graphics graphicsPlayer = e.Graphics;
            Graphics graphicsBox = e.Graphics;
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    graphicsMap.DrawImage(map.cells[i, j], 128 * i, 128 * j);
                }
            }
            graphicsPlayer.DrawImage(MainHero.Model, MainHero.X, MainHero.Y);
            graphicsBox.DrawImage(box.Model, box.X, box.Y);
        }
    }
}
