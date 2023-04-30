using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal interface IPlayer
    {
        void PlaceAllShips();
        void PlaceShip(Ship ship);
        Cell MakeMove(UIGamePlay ui);
    }
}
