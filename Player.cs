using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal abstract class Player : IPlayer
    {
        public List<Ship> Ships= new List<Ship>();
        public int ShipsRemaining { get; set; }
        public Board Board { get; set; }
        public string WinStatus { get; set; }
        public Player()
        {
            Board = new Board();
            ShipsRemaining = 5;
        }

        public virtual void PlaceAllShips()
        {

        }

        public virtual void PlaceShip(Ship ship)
        {

        }

        public virtual Cell MakeMove(UIGamePlay ui)
        {
            return null;
        }

        
    }
}
