using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses
{
    public class Mob:Entity
    {
        public Mob(int x, int y, MobType type):base(x, y)
        {
            Type = type;
            if (Type == MobType.Strong)
                Model = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\StrongMob.png"));
            else if (Type == MobType.Weak)
                Model = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\WeakMob.png"));
            else
                Model = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\Boss.png"));
        }
        public MobType Type { get; }
        public override bool IsDead { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static void Behavior(Map map)
        {
            var mob = map.Mob;
            var player = map.Player;
            if (mob == null) return;
            if (mob.PlayerFound(map, player))
            {
                var path = mob.GetPathToPlayer(map, player);
                mob.MoveToPlayer(map, player, path);
            }
            else mob.RandomMove(map);
        }

        public bool PlayerFound(Map map, Player player)
        {
            var radiusSearch = 3;
            for (int i = -radiusSearch; i <= radiusSearch; i++)
                for (int j = -radiusSearch; j <= radiusSearch; j++)
                {
                    var currentCellX = X + 128 * i;
                    var currentCellY = Y + 128 * j;
                    if (map.Size.Width <= currentCellX || currentCellX < 0) break;
                    if (map.Size.Height <= currentCellY || currentCellY < 0) continue;
                    if (currentCellX == player.X && currentCellY == player.Y)
                        return true;
                }

            return false;
        }

        public Queue<char> GetPathToPlayer(Map map, Player player)
        {//Алгоритм
            var path = new Queue<char>(new char[] { 'r', 'l', 'r', 'l' });

            return path;
        }

        public void MoveToPlayer(Map map, Player player, Queue<char> path)
        {
            if (path.Count == 0) return;

            var dir = path.Dequeue();
            int DirY;
            int DirX;
            switch (dir)
            {
                case 'u':
                    DirY = -128;
                    DirX = 0;
                    break;
                case 'd':
                    DirY = 128;
                    DirX = 0;
                    break;
                case 'l':
                    DirY = 0;
                    DirX = -128;
                    break;
                case 'r':
                    DirY = 0;
                    DirX = 128;
                    break;
                default:
                    return;
            }

            Move(DirX, DirY, map);
        }

        private void RandomMove(Map map)
        {
            var rnd = new Random();
            var dir = rnd.Next(0, 5);
            int x = 0;
            int y = 0;
            if (dir == 1) x = 128;
            else if (dir == 2) x = -128;
            else if (dir == 3) y = 128;
            else y = -128;

            Move(x, y, map);
        }

        public void Move(int moveX, int moveY, Map map)
        {
            if (X + moveX >= 0 && X + moveX < map.Size.Width)
                X += moveX;
            if (Y + moveY >= 0 && Y + moveY < map.Size.Height)
                Y += moveY;
        }
    }
}
