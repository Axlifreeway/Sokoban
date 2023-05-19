﻿using Sokoban.GameClasses;
using Sokoban.GameClasses.Servis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public class Map
    {
        public Cell[,] EntityMap { get; set; }
        public Cell[,] Cells { get; set; }
        public Player Player { get; set; }
        public List<Box> Boxes { get; set; }
        public Mob Mob { get; set; }

        public List<Cell> Win { get; set; }
        public Size Size { get;}

        public Map(int[,] map)
        {
            Size = new Size(map.GetLength(0) * Levels.Size, map.GetLength(1) * Levels.Size);
            Boxes = new List<Box>();
            Win = new List<Cell>();
            Init(map);
        }

        public Cell this[int x, int y]
        {
            get
            {
                return EntityMap[x/Levels.Size, y/Levels.Size];
            }
            set
            {
                EntityMap[x / Levels.Size, y / Levels.Size] = value;
            }
        }

        public void Init(int[,] map)
        {
            Cells = new Cell[map.GetLength(0), map.GetLength(1)];
            EntityMap = new Cell[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2) Player = new Player(i * Levels.Size, j * Levels.Size);
                    if (map[i, j] == 3) Boxes.Add(new Box(i * Levels.Size, j * Levels.Size));
                    if (map[i, j] == 6) Mob = new Mob(i * Levels.Size, j * Levels.Size, MobType.Strong);
                    Cells[i, j] = new Cell(i * Levels.Size, j * Levels.Size);
                    EntityMap[i, j] = new Cell(i * Levels.Size, j * Levels.Size);
                    Cells[i, j].Type = (CellType)map[i, j];
                    EntityMap[i, j].Type = (CellType)map[i, j];
                    if (Cells[i, j].Type == CellType.Win) Win.Add(Cells[i, j]);
                }
            }
        }  
        
        public void CheckOnWin()
        {
            int count = 0;
            foreach (var box in Boxes) 
                if(box.Win) count++;

            if (count == Boxes.Count)
            {
                if (Levels.currentLevel != Levels.LevelsCount)
                {
                    MessageBox.Show("Победа");
                    GameForm.GameInitialisation(++Levels.currentLevel);
                }
                else
                {
                    MessageBox.Show("Поздравляем, вы прошли игру!");
                    Application.Exit();
                }
            }
        }
    }
}
