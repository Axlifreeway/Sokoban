using System.Drawing;

namespace Sokoban.GameClasses.Servis
{
    internal class PlayerServis
    {
        public bool Move(Map map, Player player)
        {
            var direction = new Point(player.DirX, player.DirY);
            var newPosition = new Point(player.DirX + player.X, player.DirY + player.Y);            
            if (map.IsAccessCell(newPosition, direction))
            {
                map[player.X, player.Y].Type = CellType.Classic;
                map[player.X, player.Y].EntityNow = null;
                player.X += direction.X;
                player.Y += direction.Y;
                map[player.X, player.Y].Type = CellType.Player;
                map[player.X, player.Y].EntityNow = player;
            }
            return map.IsAccessCell(newPosition, direction);
        }

        public void BoxMove(Map map, Box box)
        {
            var direction = new Point(map.Player.DirX, map.Player.DirY);
            var newPosition = new Point(box.X + direction.X, box.Y + direction.Y);
            if (map.IsAccessCell(newPosition, direction))
            {
                box.X += direction.X;
                box.Y += direction.Y;
                map[box.X, box.Y].Type = CellType.Box;
                map[box.X, box.Y].EntityNow = box;
            }
            map.CheckOnWin();
        }
    }
}
