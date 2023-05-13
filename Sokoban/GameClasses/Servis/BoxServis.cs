using Sokoban.GameClasses.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses.Servis
{
    internal class BoxServis : IObservable<Box>
    {
        public event Action<EventData<Box>> Notify;

        public static void BoxMove(Map map, Box box)
        {
            int moveX = Levels.Size * map.Player.DirX;
            int moveY = Levels.Size * map.Player.DirY;
            if (moveX + box.X < map.Width && moveX + box.X > 0
                && moveY + box.Y < map.Height && moveY + box.Y > 0
                && map[map.Player.DirX + box.X / Levels.Size, map.Player.DirY + box.Y / Levels.Size].Type != CellType.Wall
                && map[map.Player.DirX + box.X / Levels.Size, map.Player.DirY + box.Y / Levels.Size].Type != CellType.Box)
            {
                map[box.X / Levels.Size, box.Y / Levels.Size].Type = CellType.Player;
                box.X += moveX;
                box.Y += moveY;
                map[box.X / Levels.Size, box.Y / Levels.Size].Type = CellType.Box;
            }
            map.CheckOnWin();
        }

        public void AddObserver(View.IObserver<Box> observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(View.IObserver<Box> observer)
        {
            throw new NotImplementedException();
        }
    }
}
