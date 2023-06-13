using System.Windows.Forms;
namespace Sokoban.GameClasses.Servis
{
    public class Controller
    {
        PlayerServis playerServis;
        public Controller() { playerServis = new PlayerServis(); }

        public bool PlayerMove(KeyEventArgs e, Map map)
        {
            Player player = map.Player;
            Mob mob = map.Mob;
            bool move = false;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    player.Direction = Direction.Up;
                    break;
                case Keys.Down:
                    player.Direction = Direction.Down;
                    break;
                case Keys.Left:
                    player.Direction = Direction.Left;
                    break;
                case Keys.Right:
                    player.Direction = Direction.Right;
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
            move = playerServis.Move(map, player);

            if (map[player.X, player.Y].EntityPrevious is Box)
            {
                playerServis.BoxMove(map, (Box)map[player.X, player.Y].EntityPrevious);
            }   

            if (map.Mob != null)
            {
                if (map[mob.X, mob.Y].Type == CellType.Box)
                {
                    player.KillMob(map);
                }
                if (map.Player.X == mob.X && map.Player.Y == mob.Y)
                    mob.Damage(map);
            }
            return move;
        }

        public bool MobMoveToPlayer(Map map, int currentSecond)
        {
            var mob = map.Mob;
            if (mob == null) return false;
            var path = mob.Behavior(map, currentSecond);
            if (path.Count == 0) return false;
            var dir = path.Dequeue();
            bool move = false;
            mob.Direction = dir;

            if (mob.DirX + mob.X >= 0 && mob.X + mob.DirX < map.Size.Width
                && mob.Y + mob.DirY >= 0 && mob.Y + mob.DirY< map.Size.Height)
            {
                map[mob.X, mob.Y].Type = CellType.Classic;
                map[mob.X, mob.Y].EntityNow = null;
                mob.X += mob.DirX;
                mob.Y += mob.DirY;
                map[mob.X, mob.Y].Type = (CellType)6;
                map[mob.X, mob.Y].EntityNow = mob;
                move = true;
            }          
            
            if (map.Player.X == map.Mob.X && map.Player.Y == map.Mob.Y)
                mob.Damage(map);

            return move;
        }
    }
}
