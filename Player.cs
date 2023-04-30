using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Player
    {
        public List<Ship> Ships= new List<Ship>();
        public Board Board { get; set; }
        public Player()
        {
            Board = new Board();
        }

        public void PlaceAllShips()
        {
            PlaceShip(new Ship(Ship.ShipType.Carrier));
            PlaceShip(new Ship(Ship.ShipType.BattleShip));
            PlaceShip(new Ship(Ship.ShipType.Submarine));
            PlaceShip(new Ship(Ship.ShipType.Cruiser));
            PlaceShip(new Ship(Ship.ShipType.Destroyer));
        }
        public void PlaceShip(Ship ship)
        {
            var BoardGrid = Board._cells;
            Cell[] PossibleLocation= new Cell[ship.Size];
            ConsoleKeyInfo keyInfo;
            //var UI = new UIGamePlay(Board);

            var ui = new UIPlacingShips(Board, ship);
            PossibleLocation = ui.HandleUserInput();

            while (Board.IsCollision(PossibleLocation))
            {
                PossibleLocation = ui.HandleUserInput();
            }

            Board.AddShip(ship, PossibleLocation);


            /*
            for (int i = 0; i < PossibleLocation.Length; i++)
            {
                PossibleLocation[i] = new Cell(0, i);
            }

            
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                bool userWantsToExit = false;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("Up arrow pressed");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("Down arrow pressed");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("Left arrow pressed");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("Right arrow pressed");
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine("enter");
                        userWantsToExit= true;
                        break;
                }

                if (userWantsToExit)
                {
                    break;
                }
            }*/

            

            /*
            Cell[] Location = FindEmptyCellsForShip(ship.Size);

            ship.OccupiedCells = Location;

            foreach (Cell cell in Location)
            {
                cell.isOccupied = true;
            }
            return true;*/
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
