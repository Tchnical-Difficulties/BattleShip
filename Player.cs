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
        public Board Board { get; set; }
        public Player()
        {
            Board = new Board();
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
