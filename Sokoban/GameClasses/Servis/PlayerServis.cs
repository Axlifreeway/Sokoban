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
        public static bool Move(Map map, Player player)
        {
            int moveX = Levels.Size * player.DirX;
            int moveY = Levels.Size * player.DirY;
            bool IsMove = false;
            if (player.X + moveX > 0 && player.X + moveX < map.Width
                && player.Y + moveY > 0 && player.Y + moveY < map.Height
                && map[player.DirX + player.X / Levels.Size, player.DirY + player.Y / Levels.Size].Type != CellType.Wall)
            {
                foreach (var box in map.Boxes)
                {
                    if (player.X + moveX == box.X && player.Y + moveY == box.Y
                        && (map[player.DirX + box.X / Levels.Size, player.DirY + box.Y / Levels.Size].Type == CellType.Wall
                        || map[player.DirX + box.X / Levels.Size, player.DirY + box.Y / Levels.Size].Type == CellType.Box))
                        return false;
                }
                map[player.X / Levels.Size, player.Y / Levels.Size].Type = CellType.Classic;
                player.X += moveX;
                player.Y += moveY;
                map[player.X / Levels.Size, player.Y / Levels.Size].Type = CellType.Player;
                IsMove = true;
            }
            return IsMove;
        }

        public static void BoxMove(Map map, Box box)
        {
            int moveX = Levels.Size * map.Player.DirX;
            int moveY = Levels.Size * map.Player.DirY;
            if (moveX + box.X < map.Width && moveX + box.X > 0
                && moveY + box.Y < map.Height && moveY + box.Y > 0
                && map[map.Player.DirX + box.X / Levels.Size, map.Player.DirY + box.Y / Levels.Size].Type != CellType.Wall
                && map[map.Player.DirX + box.X / Levels.Size, map.Player.DirY + box.Y / Levels.Size].Type != CellType.Box)
            {
                map[box.X / Levels.Size, box.Y / Levels.Size].Type = CellType.Player;
                box.X += moveX;
                box.Y += moveY;
                map[box.X / Levels.Size, box.Y / Levels.Size].Type = CellType.Box;
            }
            map.CheckOnWin();
        }
    }
}
