﻿using Sokoban.GameClasses.Servis;
using Sokoban.GameClasses.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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
                         "Models\\StrongMob.png"));
            }


            var source = new Bitmap(Path.Combine(new DirectoryInfo(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\205efad5a534bd9.png"));
            PlayerFrames = new PlayerFrames(source, 38, 133, 4);
        }
        private readonly MobType Type;
        public Queue<Direction> PathToPlayer;
        public readonly int RadiusSearch;
        public override bool IsDead { get => throw new NotImplementedException(); }
        public static readonly int SecondsNeededForDamage = 50;

        public static bool Behavior(Map map, int currentSecond)
        {
            var mob = map.Mob;
            bool move = false;

            if (mob == null) return move;
            

            if (mob.IsPlayerFound(map))
            {
                if(mob.Type == MobType.Strong || mob.Type == MobType.Boss)
                {
                    mob.GetPathToPlayer(map);
                    move = Controller.MobMoveToPlayer(map);
                    if (mob.Type == MobType.Boss)
                    {
                        if (currentSecond == SecondsNeededForDamage)
                            Damage(map);
                    }
                }
            }

            return move;
        }

        public bool IsPlayerFound(Map map)
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

        public void GetPathToPlayer(Map map)
        {
            var directions = new Queue<Direction>();
            var path = SearchInWidth.Search(map, this);
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

            PathToPlayer = directions;
        }

        public static void Damage(Map map)
        {
            map.Player.HP.RemoveAt(0);
        }

        public static bool PointInRangeSearch(Map map, int x, int y)
        {
            return x <= map.Mob.RadiusSearch * Levels.Size + map.Mob.X
                       && x >= -map.Mob.RadiusSearch * Levels.Size - map.Mob.X
                       && y <= map.Mob.RadiusSearch * Levels.Size + map.Mob.Y
                       && y >= -map.Mob.RadiusSearch * Levels.Size - map.Mob.Y;
        }
    }
}
