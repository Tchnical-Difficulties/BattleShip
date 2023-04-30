using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Ship
    {
        public bool IsSunk { get; private set; }
        public Cell[] OccupiedCells;
        public bool isVertical = true;
        public int Size { get; private set; }
        public int HitsRemaining { get; set; }
        public ShipType Type { get; set; }

        public enum ShipType
        {
            Carrier = 5,
            BattleShip = 4,
            Submarine = 3,
            Cruiser = 3,
            Destroyer = 2
        }
        public Ship(ShipType type)
        {
            Size = (int)type;
            Type= type;
            HitsRemaining = Size;
            IsSunk = false;
            OccupiedCells= new Cell[Size];
        }

        public void UpdatePosition(Cell[] cells)
        {
            cells.CopyTo(OccupiedCells, 0);
        }

        /// <summary>
        /// Subtracts 1 from HitsRemaining. Returns true if a ship was sunk with this shot.
        /// </summary>
        /// <returns></returns>
        public bool RegisterHit()
        {
            HitsRemaining--;
            if(HitsRemaining <= 0)
            {
                IsSunk = true;
                return true;
            }
            return false;
        }


    }
}
