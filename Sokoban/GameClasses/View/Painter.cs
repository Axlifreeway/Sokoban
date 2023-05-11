using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Sokoban.GameClasses.View
{
    public class Painter
    {
        public static Point start;        

        public static void Paint(object sender, PaintEventArgs e, Map map)
        {
            Graphics graphics = e.Graphics;
            
            for (int i = 0; i < map.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < map.Cells.GetLength(1); j++)
                {
                    graphics.DrawImage(map.Cells[i, j].GetModel(), Levels.Width * i, Levels.Height * j);
                }
            }
            map.Boxes.ForEach(box => graphics.DrawImage(box.Model, box.X, box.Y));
            AnimatePlayer(map, graphics);
            graphics.DrawImage(map.Mob.Model, map.Mob.X, map.Mob.Y);
        }

        public static void AnimatePlayer(Map map, Graphics g)
        {
            var p = map.Player;
            var idCurrentFrame = p.PlayerFrames.CurrentFrame;
            start.X += 21 * idCurrentFrame * map.Player.DirX;
            start.Y += 21 * idCurrentFrame * map.Player.DirY;
            g.DrawImage(p.PlayerFrames[p.Direction, idCurrentFrame], start);         
        }

        public static List<Bitmap[]> GetFrames(Bitmap bmp, Rectangle selection, int countFrames, int dx, int dy)
        {
            var frames = new Bitmap[countFrames];
            var listFrames = new List<Bitmap[]>();
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < countFrames; j++)
                {
                    var leftPoint = new Point(selection.X + (selection.Width + dx) * j, dy * i);
                    var newSelection = new Rectangle(leftPoint, selection.Size);
                    Bitmap frame = bmp.Clone(newSelection, bmp.PixelFormat);
                    frames[j] = frame;
                }
                listFrames.Add(frames.ToArray());
            }
            bmp.Dispose();
            return listFrames;
            
        }
    }
}
