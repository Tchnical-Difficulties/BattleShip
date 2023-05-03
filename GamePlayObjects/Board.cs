using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Board
    {
        // All ships on the board
        public List<Ship> Ships = new List<Ship>();

        // Ships that have been sunk
        public List<Ship> SunkShips= new List<Ship>();
        
        // The cells that make up the game grid
        public Cell[,] _cells= new Cell[10,10];

        public Board()
        {
            // Cells are initialized so they have the correct coordinates
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }

        /// <summary>
        /// Ensures a set of coordinates is on the board
        /// </summary>
        /// <param name="cells"></param>
        /// <returns>True if in bounds, false if out of bounds</returns>
        public static bool IsInBounds(Cell[] cells)
        {
            foreach (Cell cell in cells)
            {
                if (cell.Row < 0 || cell.Row > 9 || cell.Column < 0 || cell.Column > 9)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Ensures a cell is on the board
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>True if in bounds, false if out of bounds</returns>
        public static bool IsInBounds(Cell cell)
        {
            if (cell.Row < 0 || cell.Row > 9 || cell.Column < 0 || cell.Column > 9)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Adds a ship to the board, updates ship's and cell's information
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="coordinates"></param>
        public void AddShip(Ship ship, Cell[] coordinates)
        {
            for(int i=0; i<coordinates.Length; i++)
            {
                foreach(Cell cell2 in _cells)
                {
                    if (coordinates[i] == cell2)
                    {
                        coordinates[i] = cell2;
                        coordinates[i].OccupyCell(ship);
                    }
                }
            }
            Ships.Add(ship);
            ship.UpdatePosition(coordinates);          
        }
        /// <summary>
        /// Determines if a ship can be placed on a set of coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>True if cells are occupied, false if cells are free</returns>
        public bool IsCollision(Cell[] coordinates)
        {
            var Grid = _cells;

            foreach(Cell cell1 in coordinates)
            {
                foreach (Cell cell2 in Grid)
                {
                    if(cell1 == cell2 && cell2.isOccupied)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Ensures a cell has not already been fired upon
        /// </summary>
        /// <param name="shot"></param>
        /// <returns>True if cell is untouched, false if cell is hit or missed</returns>
        public bool ValidateShot(Cell shot)
        {
            var ShotLocation = new Cell(0, 0);
            foreach (Cell cell in _cells)
            {
                if (shot == cell)
                {
                    ShotLocation = cell;
                }
            }

            if (shot.Status != "Untouched")
            {             
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if a shot will hit a shiop
        /// </summary>
        /// <param name="shot"></param>
        /// <returns>True if ship is hit, false if no ship is on the cell</returns>
        public bool IsAHit(Cell shot)
        {
            var ShotLocation = new Cell(0, 0);
            foreach (Cell cell in _cells)
            {
                if (shot == cell)
                {
                    ShotLocation = cell;
                }
            }
            
            if (ShotLocation.isOccupied)
            { 
                ShotLocation.RegisterHit();
                return true;
            }

            else
            {
                ShotLocation.RegisterMiss();
                return false;
            }
        }     
    }
}
