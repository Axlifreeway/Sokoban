using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban;
namespace Sokoban.GameClasses.Servis
{
    internal class PlayerServis
    {
        public static void Move(int x, int y, Map map, Player player)
        {
            float moveX = x * player.DirX;
            float moveY = y * player.DirY;
            if (player.X + moveX >= 0 && player.X + moveX < map.Width)
                player.X += moveX;
            if (player.Y + moveY >= 0 && player.Y + moveY < map.Height)
                player.Y += y * player.DirY;
        }
        public static void BoxMove(Map map)
        {
            if (map.Player.DirX * Levels.Width + map.Box.X < map.Width && map.Player.DirX * Levels.Width + map.Box.X > 0
                && map.Cells[map.Player.DirX + map.Box.X / Levels.Width, map.Box.Y / Levels.Height].Type != CellType.Wall)
            {
                map.Box.X += map.Player.DirX * Levels.Width;
            }
                

            if (map.Player.DirY * Levels.Height + map.Box.Y < map.Height && map.Player.DirY * Levels.Height + map.Box.Y > 0
                && map.Cells[map.Box.X / Levels.Width, map.Box.Y / Levels.Height + map.Player.DirY].Type != CellType.Wall)
            {
                map.Box.Y += map.Player.DirY * Levels.Height;
            }
        }
    }
}
