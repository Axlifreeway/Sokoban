﻿using System;
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

namespace Sokoban
{
    public partial class Form1 : Form
    {
        public static Timer timer1 = new Timer();
        public static Map map;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
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
            Invalidate();
        }

        private void CheckOnPush(object sender, EventArgs e)
        {
            
        }
        private void OnPress(object sender, KeyEventArgs e)
        {
            Controller.PlayerMove(e, map);           
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Painter.Paint(sender, e, map);
        }
    }
}
