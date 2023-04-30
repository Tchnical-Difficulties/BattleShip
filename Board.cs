using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Board
    {
        public List<Ship> Ships = new List<Ship>();
        
        public Cell[,] _cells= new Cell[10,10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }

        /*public bool CellsAreEmpty(int row, int col)
        {
            foreach(Cell cell in cellsToCheck)
            {
                if(cell.isOccupied)
                {
                    return false;
                }
            }
            return true;
        }*/

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

        public static bool IsInBounds(Cell cell)
        {
            if (cell.Row < 0 || cell.Row > 9 || cell.Column < 0 || cell.Column > 9)
            {
                return false;
            }
            return true;
        }

        public void AddShip(Ship ship, Cell[] coordinates)
        {
            Ships.Add(ship);
            ship.UpdatePosition(coordinates);
            foreach(Cell cell in ship.OccupiedCells)
            {
                foreach (Cell c in _cells)
                {
                    if(cell == c)
                    {
                        c.OccupyCell(ship);
                    }
                }
            }
        }

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

        public bool ValidateShot(Cell shot)
        {
            //var ShotLocation = new Cell(0, 0);
            //foreach (Cell cell in _cells)
            //{
            //    if (shot == cell)
            //    {
            //        ShotLocation = cell;
            //    }
            //}

            if (shot.Status != "Untouched")
            {
                Console.WriteLine($"You have already fired a shot here! {shot.CoordinatesToString()}");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool IsAHit(Cell shot)
        {
            var ShotLocation = new Cell(0, 0);
            foreach (Cell cell in _cells)
            {
                if(shot == cell)
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
