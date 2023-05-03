using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class AIPlayer : Player
    {
        Random rand = new Random();
        public AIPlayer()
        {

        }

        public override void PlaceAllShips()
        {
            PlaceShip(new Ship(Ship.ShipType.Carrier));
            //PlaceShip(new Ship(Ship.ShipType.BattleShip));
            //PlaceShip(new Ship(Ship.ShipType.Submarine));
            //PlaceShip(new Ship(Ship.ShipType.Cruiser));
            //PlaceShip(new Ship(Ship.ShipType.Destroyer));
        }
        /// <summary>
        /// Selects a set of coordinates for a new ship by selecting a random origin cell, then
        /// adding more cells in a random direction from the origin cell. If the ship goes out of bounds
        /// or runs into a another ship, the entire process is repeated until a suitable set of cells is found
        /// </summary>
        /// <param name="ship"></param>
        public override void PlaceShip(Ship ship)
        {
            var BoardGrid = Board._cells;
            var size = ship.Size;
            bool ShipIsVertical = false;
            bool AddOrSubtract = false; // Determines which way ship is built from starting cell

            Cell[] PossibleLocation = new Cell[size];

            do
            {
                PossibleLocation[0] = new Cell(rand.Next(0, 9), rand.Next(0, 9));
                ShipIsVertical = rand.Next(0, 99) % 2 == 0;
                AddOrSubtract = rand.Next(0, 99) % 2 == 0;
                if (ShipIsVertical && AddOrSubtract)
                {
                    for(int i=1; i<size; i++)
                    {
                        PossibleLocation[i] = new Cell(PossibleLocation[i - 1].Row + 1, PossibleLocation[i - 1].Column);
                    }
                }
                else if(ShipIsVertical && !AddOrSubtract)
                {
                    for (int i = 1; i < size; i++)
                    {
                        PossibleLocation[i] = new Cell(PossibleLocation[i - 1].Row - 1, PossibleLocation[i - 1].Column);
                    }
                }
                if(!ShipIsVertical && AddOrSubtract)
                {
                    for (int i = 1; i < size; i++)
                    {
                        PossibleLocation[i] = new Cell(PossibleLocation[i - 1].Row, PossibleLocation[i - 1].Column + 1);
                    }
                }
                else if(!ShipIsVertical && !AddOrSubtract)
                {
                    for (int i = 1; i < size; i++)
                    {
                        PossibleLocation[i] = new Cell(PossibleLocation[i - 1].Row, PossibleLocation[i - 1].Column - 1);
                    }
                }
                
            } while (Board.IsCollision(PossibleLocation) || !Board.IsInBounds(PossibleLocation));

            Board.AddShip(ship, PossibleLocation);
            ship.isVertical = ShipIsVertical;
            ShipsRemaining++;

        }
        /// <summary>
        /// Selects a random cell to fire a shot. The caller will keep calling until a suitable
        /// cell is returned
        /// </summary>
        /// <param name="ui"></param>
        /// <returns>A cell with random coordinates 0-9</returns>
        public override Cell MakeMove(UIGamePlay ui)
        {
            return new Cell(rand.Next(0, 9), rand.Next(0, 9));
        }
    }
}
