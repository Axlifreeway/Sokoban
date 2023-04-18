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

namespace Sokoban.GameClasses.View
{
    internal class Painter
    {

        public static void Paint(object sender, PaintEventArgs e, Map map)
        {
            Graphics graphicsMap = e.Graphics;
            Graphics graphicsPlayer = e.Graphics;
            Graphics graphicsBox = e.Graphics;
            for (int i = 0; i < map.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < map.Cells.GetLength(1); j++)
                {
                    graphicsMap.DrawImage(map.Cells[i, j].GetModel(), Levels.Width * i, Levels.Height * j);
                }
            }
            graphicsPlayer.DrawImage(map.Player.Model, map.Player.X, map.Player.Y);
            graphicsBox.DrawImage(map.Box.Model, map.Box.X, map.Box.Y);
        }
    }
}
