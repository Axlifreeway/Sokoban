using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses
{
    public class Mob : Entity
    {
        public Mob(int x, int y, MobType type) : base(x, y)
        {
            Type = type;
            if (Type == MobType.Strong)
            {
                RadiusSearch = 3;
                Model = new Bitmap(
                    Path.Combine(
                        new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                        "Models\\StrongMob.png"));

            }
            else if (Type == MobType.Weak)
            {
                RadiusSearch = 0;
                Model = new Bitmap(
                    Path.Combine(
                        new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                        "Models\\WeakMob.png"));
            }
            else
            {
                RadiusSearch = 3; //3?
                Model = new Bitmap(
                    Path.Combine(
                        new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                        "Models\\Boss.png"));
            }
        }
        private readonly MobType Type;
        private readonly int RadiusSearch;
        public override bool IsDead { get => throw new NotImplementedException(); }

        public static void Behavior(Map map)
        {
            var mob = map.Mob;
            if (mob == null) return;
            if (mob.PlayerFound(map))
            {
                var path = mob.GetPathToPlayer(map);
                mob.MoveToPlayer(map, path);
            }
            else mob.RandomMove(map);
        }

        public bool PlayerFound(Map map)
        {
            for (int i = -RadiusSearch; i <= RadiusSearch; i++)
                for (int j = -RadiusSearch; j <= RadiusSearch; j++)
                {
                    var currentCellX = X + Levels.Size * i;
                    var currentCellY = Y + Levels.Size * j;
                    if (map.Size.Width <= currentCellX || currentCellX < 0) break;
                    if (map.Size.Height <= currentCellY || currentCellY < 0) continue;
                    if (map[currentCellX, currentCellY].Type == CellType.Player)
                        return true;
                }

            return false;
        }

        public Queue<Direction> GetPathToPlayer(Map map)
        {
            var directions = new Queue<Direction>();
            var path = SearchInWidth(map);
            var currentX = this.X;
            var currentY = this.Y;

            while (path.Count != 0)
            {

                Cell cell = path.First.Value;
                path.RemoveFirst();

                if (cell.X > currentX) directions.Enqueue(Direction.Right);
                else if (cell.X < currentX) directions.Enqueue(Direction.Left);
                else if (cell.Y > currentY) directions.Enqueue(Direction.Down);
                else if (cell.Y < currentY) directions.Enqueue(Direction.Up);

                currentX = cell.X;
                currentY = cell.Y;
            }

            return directions;
        }

        public LinkedList<Cell> SearchInWidth(Map map)
        {
            var queue = new Queue<LinkedList<Cell>>();
            var visited = new List<Cell>();
            LinkedList<Cell> path = new LinkedList<Cell>();

            path.AddLast(new Cell(this.X, this.Y));

            queue.Enqueue(path);
            while (queue.Count != 0)
            {
                var partOfPath = queue.Dequeue();
                if (partOfPath.Last.Value.X < 0 || partOfPath.Last.Value.X >= map.Size.Width
                    || partOfPath.Last.Value.Y < 0 || partOfPath.Last.Value.Y >= map.Size.Height) continue;
                if (partOfPath.Last.Value.X > RadiusSearch * Levels.Size + this.X
                    || partOfPath.Last.Value.X < -RadiusSearch * Levels.Size - this.X
                    || partOfPath.Last.Value.Y > RadiusSearch * Levels.Size + this.Y
                    || partOfPath.Last.Value.Y < -RadiusSearch * Levels.Size - this.Y) continue;
                if (map[partOfPath.Last.Value.X, partOfPath.Last.Value.Y].Type == CellType.Wall
                    || map[partOfPath.Last.Value.X, partOfPath.Last.Value.Y].Type == CellType.Box) continue;
                if (visited.Contains(map[partOfPath.Last.Value.X, partOfPath.Last.Value.Y])) continue;

                if (map[partOfPath.Last.Value.X, partOfPath.Last.Value.Y].Type == CellType.Player)
                {
                    path = partOfPath;
                    break;
                }
                visited.Add(map[partOfPath.Last.Value.X, partOfPath.Last.Value.Y]);

                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0 || dx == 0 && dy == 0) continue;
                        else
                        {
                            var cell = new Cell(partOfPath.Last.Value.X + dx * Levels.Size, partOfPath.Last.Value.Y + dy * Levels.Size);

                            var newPath = CopyLinkedList(partOfPath);
                            newPath.AddLast(cell);
                            queue.Enqueue(newPath);
                        }
            }

            return path;
        }

        public LinkedList<Cell> CopyLinkedList(LinkedList<Cell> original)
        {
            var clone = new LinkedList<Cell>();

            foreach (var item in original)
            {
                clone.AddLast(item);
            }/*
            for (int i =0; i < original.Count; i++)
            {
                clone.AddLast(original.First);
                original.RemoveFirst();
            }*/

            return clone;
        }

        public void MoveToPlayer(Map map, Queue<Direction> path)
        {
            if (path.Count == 0) return;

            var dir = path.Dequeue();
            int DirY;
            int DirX;
            switch (dir)
            {
                case Direction.Up:
                    DirY = -Levels.Size;
                    DirX = 0;
                    break;
                case Direction.Down:
                    DirY = Levels.Size;
                    DirX = 0;
                    break;
                case Direction.Left:
                    DirY = 0;
                    DirX = -Levels.Size;
                    break;
                case Direction.Right:
                    DirY = 0;
                    DirX = Levels.Size;
                    break;
                default:
                    return;
            }

            Move(DirX, DirY, map);
        }

        public void Default(Queue<Direction> patrol)
        {
            //Патрулирование вынести в свойство как массив ячеек?
        }

        private void RandomMove(Map map)
        {
            var rnd = new Random();
            var dir = rnd.Next(0, 5);
            int x = 0;
            int y = 0;
            if (dir == 1) x = Levels.Size;
            else if (dir == 2) x = -Levels.Size;
            else if (dir == 3) y = Levels.Size;
            else y = -Levels.Size;

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
