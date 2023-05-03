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

        public Player()
        {
            Board = new Board();
            ShipsRemaining = 0;
        }

        /// <summary>
        /// Calls PlaceShip once for every ship that should be created
        /// </summary>
        public abstract void PlaceAllShips();
        /// <summary>
        /// Places a ship on a set of cells
        /// </summary>
        /// <param name="ship"></param>
        public abstract void PlaceShip(Ship ship);
        /// <summary>
        /// Selects a single cell to take a shot
        /// </summary>
        /// <param name="ui"></param>
        /// <returns>A cell where a shot will be fired</returns>
        public abstract Cell MakeMove(UIGamePlay ui);

        
    }
}
