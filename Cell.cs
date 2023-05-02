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

        public string Status { get; private set; }

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
            isOccupied = false;
            Status = "Untouched";
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

        public void RegisterHit()
        {
            Status = "Hit";
        }

        public void RegisterMiss()
        {
            Status = "Missed";
        }

        public string CoordinatesToString()
        {
            string possibleCharacters = "ABCDEFGHIJ";

            StringBuilder result = new StringBuilder();

            result.Append(possibleCharacters[Row]);
            result.Append((Column+1).ToString());
            return result.ToString();
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
