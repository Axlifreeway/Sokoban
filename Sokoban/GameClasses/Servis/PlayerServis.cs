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
            bool isMoved = false;
            if (player.X + moveX > 0 && player.X + moveX < map.Size.Width
                && player.Y + moveY > 0 && player.Y + moveY < map.Size.Height
                && map[moveX + player.X, moveY + player.Y].Type != CellType.Wall)
            {
                foreach (var box in map.Boxes)
                {
                    if (player.X + moveX == box.X && player.Y + moveY == box.Y
                        && (map[moveX + box.X, moveY + box.Y].Type == CellType.Wall
                        ||  map[moveX + box.X, moveY + box.Y].Type == CellType.Box))
                        return isMoved;
                }
                map[player.X, player.Y].Type = CellType.Classic;
                player.X += moveX;
                player.Y += moveY;
                map[player.X, player.Y].Type = CellType.Player;
                isMoved = true;
            }
            return isMoved;
        }

        public static void BoxMove(Map map, Box box)
        {
            int moveX = Levels.Size * map.Player.DirX;
            int moveY = Levels.Size * map.Player.DirY;
            if (moveX + box.X < map.Size.Width && moveX + box.X > 0
                && moveY + box.Y < map.Size.Height && moveY + box.Y > 0
                && map[moveX + box.X, moveY + box.Y].Type != CellType.Wall
                && map[moveX + box.X, moveY + box.Y].Type != CellType.Box)
            {
                if (map[moveX + box.X, moveY + box.Y].Type == CellType.Win)
                    box.Win = true;
                box.X += moveX;
                box.Y += moveY;
                map[box.X, box.Y].Type = CellType.Box;
            }
            map.CheckOnWin();
        }

        public static void damage(Map map)
        {

        }
    }
}
