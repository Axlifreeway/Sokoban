using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.GameClasses.View;
namespace Sokoban.GameClasses.Servis
{
    public class Controller
    {
        public static bool PlayerMove(KeyEventArgs e, Map map)
        {
            Player player = map.Player;
            bool move = false;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    player.DirY = -1;
                    player.DirX = 0;
                    move = PlayerServis.Move(map, player);
                    break;
                case Keys.Down:
                    player.DirY = 1;
                    player.DirX = 0;
                    move = PlayerServis.Move(map, player);
                    break;
                case Keys.Left:
                    player.DirY = 0;
                    player.DirX = -1;
                    move = PlayerServis.Move(map, player);
                    break;
                case Keys.Right:
                    player.DirY = 0;
                    player.DirX = 1;
                    move = PlayerServis.Move(map, player);
                    break;
                case Keys.R:
                    map.Form.GameInitialisation(Levels.currentLevel);
                    break;
                case Keys.Oem3:
                    map.Form.GameInitialisation(++Levels.currentLevel);
                    break;
                default:
                    return false;                   
            }
            foreach (var box in map.Boxes)
            {
                if (map.Player.X == box.X && map.Player.Y == box.Y)
                    PlayerServis.BoxMove(map, box);
            }
            return move;
        }

        public static void MobMoveToPlayer(Map map)
        {
            var path = map.Mob.PathToPlayer;
            if (path.Count == 0) return;

            var dir = path.Dequeue();
            int moveY;
            int moveX;
            switch (dir)
            {
                case Direction.Up:
                    moveY = -Levels.Size;
                    moveX = 0;
                    break;
                case Direction.Down:
                    moveY = Levels.Size;
                    moveX = 0;
                    break;
                case Direction.Left:
                    moveY = 0;
                    moveX = -Levels.Size;
                    break;
                case Direction.Right:
                    moveY = 0;
                    moveX = Levels.Size;
                    break;
                default:
                    return;
            }

            if (map.Mob.X + map.Mob.X >= 0 && map.Mob.X + moveX < map.Size.Width)
                map.Mob.X += moveX;
            if (map.Mob.Y + moveY >= 0 && map.Mob.Y + moveY < map.Size.Height)
                map.Mob.Y += moveY;

            if (map.Player.X == map.Mob.X && map.Player.Y == map.Mob.Y)
                Mob.Damage(map);
        }
    }
}
