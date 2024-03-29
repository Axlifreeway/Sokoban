﻿using Sokoban.GameClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Cell:Entity
    {
        public Cell(int x, int y) : base(x, y) { }
        public CellType Type { get; set; }
        public override bool IsDead { get => throw new NotImplementedException(); }

        public Image GetModel()
        {
            if (Type == CellType.Win) 
                return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\environment_07.png"));

            else if (Type == CellType.Wall) 
                return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\block_06.png"));

            else 
                return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Models\\ground_04.png"));
        }
    }
}
