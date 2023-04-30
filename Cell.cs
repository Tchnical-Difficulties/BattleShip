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
        public bool isOccupied { get; private set; }
        public Ship OccupyingShip { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
            isOccupied = false;
        }

        public Cell(bool isOccupied, Ship occupyingShip, int row, int column)
        {
            this.isOccupied = isOccupied;
            OccupyingShip = occupyingShip;
            Row = row;
            Column = column;
        }

        public void OccupyCell(Ship ship)
        {
            isOccupied= true;
            OccupyingShip= ship;
        }

        public static bool operator ==(Cell cell1, Cell cell2)
        {
            if(cell1.Row == cell2.Row && cell1.Column == cell2.Column)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Cell cell1, Cell cell2)
        {
            if (cell1.Row == cell2.Row && cell1.Column == cell2.Column)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
