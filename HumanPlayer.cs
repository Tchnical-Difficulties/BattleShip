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
        public override void PlaceShip(Ship ship)
        {
            var BoardGrid = Board._cells;
            Cell[] PossibleLocation = new Cell[ship.Size];
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
