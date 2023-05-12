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
        public static bool Move(int x, int y, Map map, Player player)
        {
            int moveX = x * player.DirX;
            int moveY = y * player.DirY;
            var px = player.X;
            var py = player.Y;
            if (player.X + moveX > 0 && player.X + moveX < map.Width
                && map[player.DirX + player.X / Levels.Width, player.Y / Levels.Height] != 4)
            {
                foreach (var box in map.Boxes)
                {
                    if (player.X + moveX == box.X && player.Y  == box.Y
                        && (map[player.DirX + box.X / Levels.Width, box.Y / Levels.Height] == 4
                        || map[player.DirX + box.X / Levels.Width, box.Y / Levels.Height] == 2))
                        return false;
                }
                map[player.X / Levels.Width, player.Y / Levels.Height] = 0;
                player.X += moveX;
                map[player.X / Levels.Width, player.Y / Levels.Height] = 3;
            }

            if (player.Y + moveY > 0 && player.Y + moveY < map.Height
                && map[player.X / Levels.Width, player.Y / Levels.Height + player.DirY] != 4)
            {
                foreach (var box in map.Boxes)
                {
                    if (player.X == box.X && player.Y + moveY == box.Y 
                    && (map[box.X / Levels.Width, box.Y / Levels.Height + player.DirY] == 4
                    || map[box.X / Levels.Width, box.Y / Levels.Height + player.DirY] == 2))
                        return false;
                }
                map[player.X / Levels.Width, player.Y / Levels.Height] = 0;
                player.Y += y * player.DirY;
                map[player.X / Levels.Width, player.Y / Levels.Height] = 3;
            }

            return false;
        }

        public static void BoxMove(Map map, Box box)
        {
            if (map.Player.DirX * Levels.Width + box.X < map.Width && map.Player.DirX * Levels.Width + box.X > 0
                && map[map.Player.DirX + box.X / Levels.Width, box.Y / Levels.Height] != 4
                && map[map.Player.DirX + box.X / Levels.Width, box.Y / Levels.Height] != 2)
            {
                map[box.X / Levels.Width, box.Y / Levels.Height] = 3;
                box.X += map.Player.DirX * Levels.Width;
                map[box.X / Levels.Width, box.Y / Levels.Height] = 2;
            }


            if (map.Player.DirY * Levels.Height + box.Y < map.Height && map.Player.DirY * Levels.Height + box.Y > 0
                && map[box.X / Levels.Width, box.Y / Levels.Height + map.Player.DirY] != 4
                && map[box.X / Levels.Width, box.Y / Levels.Height + map.Player.DirY] != 2)
            {
                map[box.X / Levels.Width, box.Y / Levels.Height] = 3;
                box.Y += map.Player.DirY * Levels.Height;
                map[box.X / Levels.Width, box.Y / Levels.Height] = 2;
            }

            map.CheckOnWin();
        }
    }
}
