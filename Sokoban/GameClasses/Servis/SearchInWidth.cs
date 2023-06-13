using System.Collections.Generic;
using System.Drawing;

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
                var point = new Point(partOfPath.Last.Value.X, partOfPath.Last.Value.Y);
                if (!map.IsCorrectCell(point)) continue;
                if (map.PointIsBoxOrWall(point)) continue;
                if (visited.Contains(map[point])) continue;

                if (map[point].Type == CellType.Player)
                {
                    path = partOfPath;
                    break;
                }
                visited.Add(map[point]);

                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0 || dx == 0 && dy == 0) continue;
                        else
                        {
                            var cell = new Cell(point.X + dx, point.Y + dy);
                            var newPath = CopyLinkedList(partOfPath);
                            newPath.AddLast(cell);
                            queue.Enqueue(newPath);
                        }
            }
            return path;
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
