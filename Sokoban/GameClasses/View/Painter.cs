using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Sokoban.GameClasses.View
{
    public class Painter
    {
        public static Point start;        
        public static Point startM;
        public static void Paint(object sender, PaintEventArgs e, Map map)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(map.BackGround, 0, 0);
            for (int i = 0; i < map.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < map.Cells.GetLength(1); j++)
                {
                    graphics.DrawImage(map.Cells[i, j].GetModel(), Levels.Size * i, Levels.Size * j);
                }
            }

            if(map.Mob != null)
                graphics.DrawImage(map.Mob.Model, map.Mob.X, map.Mob.Y);

            foreach (var box in map.Boxes)
            {
                graphics.DrawImage(box.Model, box.X, box.Y);
            }

            AnimatePlayer(map, graphics);
            AnimateMob(map, graphics);
            graphics.DrawImage(map.Player.HP[0].HealthBack, 0, 8);
            for (int i = 0; i < map.Player.HP.Count; i++)
                graphics.DrawImage(map.Player.HP[i].Model, 50 * i, 10);
        }

        public static void AnimatePlayer(Map map, Graphics g)
        {
            var p = map.Player;
            var idCurrentFrame = p.PlayerFrames.CurrentFrame;
            start.X += 21 * idCurrentFrame * map.Player.DirX;
            start.Y += 21 * idCurrentFrame * map.Player.DirY;
            g.DrawImage(p.PlayerFrames[p.Direction, idCurrentFrame], start);         
        }

        public static void AnimateMob(Map map, Graphics g)
        {
            var m = map.Mob;
            if (m == null)
                return;
             var idCurrentFrame = m.PlayerFrames.CurrentFrame;
            start.X += 21 * idCurrentFrame * map.Mob.DirX;
            start.Y += 21 * idCurrentFrame * map.Mob.DirY;
            g.DrawImage(m.PlayerFrames[m.Direction, idCurrentFrame], startM);
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
