﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class CarrierShip : Ship
    {

        public CarrierShip(Cell[] occupiedCells)
        {
            OccupiedCells= occupiedCells;
            MaxHealth = 5;
        }
    }
}