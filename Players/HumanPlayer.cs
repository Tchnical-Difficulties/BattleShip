using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer()
        {

        }

        public override void PlaceAllShips()
        {
            PlaceShip(new Ship(Ship.ShipType.Carrier));
            PlaceShip(new Ship(Ship.ShipType.BattleShip));
            PlaceShip(new Ship(Ship.ShipType.Submarine));
            PlaceShip(new Ship(Ship.ShipType.Cruiser));
            PlaceShip(new Ship(Ship.ShipType.Destroyer));
        }
        /// <summary>
        /// Allows user to place a ship. Ship is added to Board class
        /// and user's ShipsRemaining property is incremented by 1
        /// </summary>
        /// <param name="ship"></param>
        public override void PlaceShip(Ship ship)
        {
            var BoardGrid = Board._cells;
            Cell[] PossibleLocation = new Cell[ship.Size];

            var ui = new UIPlacingShips(Board, ship);
            PossibleLocation = ui.HandleUserInput();

            while (Board.IsCollision(PossibleLocation))
            {
                ui.InvalidLocation();
                PossibleLocation = ui.HandleUserInput();
            }

            Board.AddShip(ship, PossibleLocation);
            ShipsRemaining++;

        }

        /// <summary>
        /// Allows user to select a cell to fire at
        /// </summary>
        /// <param name="ui"></param>
        /// <returns>Cell to attempt a shot</returns>
        public override Cell MakeMove(UIGamePlay ui)
        {
            var Move = ui.HandleUserInput();

            while (!Board.IsInBounds(Move))
            {
                Move = ui.HandleUserInput();
            }

            return Move;
        }
    }
}
