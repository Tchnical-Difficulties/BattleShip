using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Player
    {
        public Board Board { get; set; }
        public Player()
        {
            Board = new Board();
        }

        public void PlaceAllShips()
        {
            List<Ship> ships = new List<Ship>()
            {
                new CarrierShip(),
                new CarrierShip(),
                new CarrierShip(),
                new CarrierShip(),
                new CarrierShip()
            };

            foreach (Ship ship in ships)
            {
                PlaceSingleShip(ship);
            }


        }
        public bool PlaceSingleShip(Ship ship)
        {
            Cell[] Location = FindEmptyCellsForShip(ship.Size);

            ship.OccupiedCells = Location;

            foreach (Cell cell in Location)
            {
                cell.isOccupied = true;
            }
            return true;
        }

        private Cell[] FindEmptyCellsForShip(int size)
        {
            Cell[] cells = new Cell[size];
            for(int i=0; i < cells.Length; i++)
            {
                cells[i] = new Cell(0,0);
            }

            //Iterates through entire grid to see if a vertical space exists for the ship
            //i is the vertical starting point, j is the horizontal starting point, and k is the ship length
            for (int i = 0; i < 10; i++)
            {
                for (int j = i; j < 10; j++)
                {
                    bool isValidSpot = true;

                    for (int k = 0; k < size; k++)
                    {
                        if (Board._cells[k, j].isOccupied)
                        {
                            isValidSpot = false;
                            break;
                        }

                        cells[k] = Board._cells[k, j];
                    }

                    if (isValidSpot)
                    {
                        return cells;
                    }
                }
            }
            return null;
        }
    }
}
