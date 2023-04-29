using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal abstract class Ship
    {
        public bool isSunk = false;
        public Cell[] OccupiedCells;
        public string Orientation;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }


        public Ship()
        {

        }


    }
}
