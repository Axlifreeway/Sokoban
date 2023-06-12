using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses.Servis
{
    static class SearchInWidth
    {
        public static LinkedList<Cell> Search(Map map, Mob mob)
        {
            var queue = new Queue<LinkedList<Cell>>();
            var visited = new List<Cell>();
            LinkedList<Cell> path = new LinkedList<Cell>();

            path.AddLast(new Cell(mob.X, mob.Y));

            queue.Enqueue(path);
            while (queue.Count != 0)
            {
                var partOfPath = queue.Dequeue();
                var x = partOfPath.Last.Value.X;
                var y = partOfPath.Last.Value.Y;
                if (!PointInRangeMap(map, x, y)) continue;
                if (!mob.PointInRangeSearch(map, x, y)) continue;
                if (PointIsBoxOrWall(map, x, y)) continue;
                if (visited.Contains(map[x, y])) continue;

                if (map[x, y].Type == CellType.Player)
                {
                    path = partOfPath;
                    break;
                }
                visited.Add(map[x, y]);

                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0 || dx == 0 && dy == 0) continue;
                        else
                        {
                            var cell = new Cell(x + dx * Levels.Size, y + dy * Levels.Size);

                            var newPath = CopyLinkedList(partOfPath);
                            newPath.AddLast(cell);
                            queue.Enqueue(newPath);
                        }
            }

            return path;
        }

        static bool PointInRangeMap(Map map, int x, int y)
        {
            return x >= 0 && x < map.Size.Width && y >= 0 && y < map.Size.Height;
        }

        static bool PointIsBoxOrWall(Map map, int x, int y)
        {
            return map[x, y].Type == CellType.Wall
                       || map[x, y].Type == CellType.Box;
        }

        static LinkedList<Cell> CopyLinkedList(LinkedList<Cell> original)
        {
            var clone = new LinkedList<Cell>();

            foreach (var item in original)
            {
                clone.AddLast(item);
            }
            return clone;
        }
    }
}
