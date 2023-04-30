using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Ship
    {
        public bool isSunk = false;
        public Cell[] OccupiedCells;
        public bool isVertical = true;
        public int Size { get; private set; }
        public int CurrentHealth { get; set; }
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
        }

        public void UpdatePosition(Cell[] cells)
        {
            OccupiedCells= cells;
        }
    }
}
