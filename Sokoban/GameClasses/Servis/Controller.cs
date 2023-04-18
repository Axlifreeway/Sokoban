using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.GameClasses.Servis
{
    public class Controller
    {
        
        public static void PlayerMove(KeyEventArgs e, Map map)
        {
            Player player = map.Player;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    player.DirY = -1;
                    player.DirX = 0;
                    PlayerServis.Move(0, 128, map, player);
                    break;
                case Keys.Down:
                    player.DirY = 1;
                    player.DirX = 0;
                    PlayerServis.Move(0, 128, map, player);
                    break;
                case Keys.Left:
                    player.DirY = 0;
                    player.DirX = -1;
                    PlayerServis.Move(128, 0, map, player);
                    break;
                case Keys.Right:
                    player.DirY = 0;
                    player.DirX = 1;
                    PlayerServis.Move(128, 0, map, player);
                    break;
                default:
                    break;
            }
            if (map.Player.X == map.Box.X && map.Player.Y == map.Box.Y)
                PlayerServis.BoxMove(map);
        }
    }
}
