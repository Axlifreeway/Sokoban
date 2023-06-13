using System.Drawing;
using System.Windows.Forms;

namespace Sokoban.GameClasses.View
{
    public class Painter
    {
        public Point start;        
        public Point startM;
        public void Paint(object sender, PaintEventArgs e, Map map)
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

            if (map.Mob != null)
                AnimateMob(map, graphics);

            foreach (var box in map.Boxes)
            {
                graphics.DrawImage(box.Model, Levels.Size * box.X, Levels.Size * box.Y);
            }

            AnimatePlayer(map, graphics);

            graphics.DrawImage(HealthPoints.HealthBack, 0, 8);
            for (int i = 0; i < map.Player.HP.Count; i++)
                graphics.DrawImage(map.Player.HP[i].Model, 50 * i, 10);
        }

        public void AnimatePlayer(Map map, Graphics g)
        {
            var p = map.Player;
            var idCurrentFrame = p.PlayerFrames.CurrentFrame;
            start.X += 21 * idCurrentFrame * map.Player.DirX;
            start.Y += 21 * idCurrentFrame * map.Player.DirY;
            g.DrawImage(p.PlayerFrames[p.Direction, idCurrentFrame], start);         
        }

        public void AnimateMob(Map map, Graphics g)
        {
            var m = map.Mob;
            var idCurrentFrame = m.PlayerFrames.CurrentFrame;
            startM.X += 21 * idCurrentFrame * map.Mob.DirX;
            startM.Y += 21 * idCurrentFrame * map.Mob.DirY;
            g.DrawImage(m.PlayerFrames[m.Direction, idCurrentFrame], startM);
        }
    }
}
