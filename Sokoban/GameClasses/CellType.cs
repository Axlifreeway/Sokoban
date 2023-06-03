using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.GameClasses
{
    public enum CellType
    {
        Classic,
        Win,
        Player,
        Box,
        Wall,
        StrongMob,
        WeakMob,
        Boss
    }
}
