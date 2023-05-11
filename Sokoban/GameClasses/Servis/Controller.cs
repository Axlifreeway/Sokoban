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
            bool move;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    player.DirY = -1;
                    player.DirX = 0;
                    move = PlayerServis.Move(0, 128, map, player);
                    break;
                case Keys.Down:
                    player.DirY = 1;
                    player.DirX = 0;
                    move = PlayerServis.Move(0, 128, map, player);
                    break;
                case Keys.Left:
                    player.DirY = 0;
                    player.DirX = -1;
                    move = PlayerServis.Move(128, 0, map, player);
                    break;
                case Keys.Right:
                    player.DirY = 0;
                    player.DirX = 1;
                    move = PlayerServis.Move(128, 0, map, player);
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
    }
}
