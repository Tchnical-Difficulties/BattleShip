using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Cell
    {
        public bool isOccupied = false;
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Cell(int x, int y)
        {
            Row = x;
            Column = y;
        }

        
    }
}
