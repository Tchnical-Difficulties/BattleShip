using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class UIPlacingShips : IUserInterface
    {
        private Board _incomingBoard;
        private int _shipSize;
        private Ship _temporaryShip;
        private Ship _incomingShip;
        public UIPlacingShips(Board Board, Ship ship)
        {
            _incomingBoard = Board;
            _shipSize = ship.Size;
            _incomingShip = ship;
        }

        public Cell[] HandleUserInput()
        {
            // Declare grid and two Cell arrays to move user's choice for ship placement
            var BoardGrid = _incomingBoard._cells;
            Cell[] CurrentCoordinate = new Cell[_shipSize];
            Cell[] AttemptedCoordinate = new Cell[_shipSize];

            // Initialize cell array to top left corner
            for (int i = 0; i < CurrentCoordinate.Length; i++)
            {
                CurrentCoordinate[i] = new Cell(i, 0);
                AttemptedCoordinate[i] = new Cell(i, 0);
            }

            // Initialize temporary ship for display purposes
            _temporaryShip = new Ship(_incomingShip.Type);
            _temporaryShip.UpdatePosition(CurrentCoordinate);

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                UpdateDisplay();
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    
                    case ConsoleKey.UpArrow:
                        for (int i = 0; i < CurrentCoordinate.Length; i++)
                        {
                            AttemptedCoordinate[i] = new Cell(CurrentCoordinate[i].Row - 1, CurrentCoordinate[i].Column);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        for(int i = 0; i < CurrentCoordinate.Length; i++)
                        {
                            AttemptedCoordinate[i] = new Cell(CurrentCoordinate[i].Row + 1, CurrentCoordinate[i].Column);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        for (int i = 0; i < CurrentCoordinate.Length; i++)
                        {
                            AttemptedCoordinate[i] = new Cell(CurrentCoordinate[i].Row, CurrentCoordinate[i].Column - 1);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        for (int i = 0; i < CurrentCoordinate.Length; i++)
                        {
                            AttemptedCoordinate[i] = new Cell(CurrentCoordinate[i].Row, CurrentCoordinate[i].Column + 1);
                        }
                        break;

                    case ConsoleKey.R:

                        if (_temporaryShip.isVertical)
                        {
                            _temporaryShip.isVertical = false;

                            for (int i = 0; i < CurrentCoordinate.Length; i++)
                            {
                                CurrentCoordinate[i] = new Cell(0, i);
                                AttemptedCoordinate[i] = new Cell(0, i);
                            }
                        }
                        else
                        {
                            _temporaryShip.isVertical = false;

                            for (int i = 0; i < CurrentCoordinate.Length; i++)
                            {
                                CurrentCoordinate[i] = new Cell(i, 0);
                                AttemptedCoordinate[i] = new Cell(i, 0);
                            }
                        }
                        Console.WriteLine("You pressed R");
                        
                        break;

                    case ConsoleKey.Enter:
                        return AttemptedCoordinate;
                       

                }

                // Check to make sure choice is in bounds

                if (Board.IsInBounds(AttemptedCoordinate))
                {
                    Cell[] tempCell = new Cell[CurrentCoordinate.Length];
                    AttemptedCoordinate.CopyTo(tempCell, 0);

                    _temporaryShip.UpdatePosition(tempCell);
                    AttemptedCoordinate.CopyTo(CurrentCoordinate, 0);
                }

                
                //CurrentCoordinate = CopyCells(AttemptedCoordinate);
                

            }
        }

        public void UpdateDisplay()
        {
            Console.Clear();
            PrintBoard(_incomingBoard);
        }
        private void PrintBoard(Board Board)
        {
            var BoardGrid = Board._cells;
            string possibleCharacters = "ABCDEFGHIJ";
            int characterDigit = 0;
            char characterChar = ' ';

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    bool cellContainsTempShip = false;
                    foreach (Cell c in _temporaryShip.OccupiedCells)
                    {
                        if(c.Row == BoardGrid[i, j].Row && c.Column == BoardGrid[i, j].Column)
                        {
                            cellContainsTempShip = true;
                        }
                    }

                    // Default background color, water
                    Console.BackgroundColor = ConsoleColor.Blue;

                    if (cellContainsTempShip)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    }
                    else if (BoardGrid[i, j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    characterChar = possibleCharacters[i];

                    Console.Write($"{characterChar}{j} ");


                }
                Console.Write("\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        private Cell[] CopyCells(Cell[] cells)
        {
            Cell[] CopiedCells = new Cell[cells.Length];
            for(int i=0; i<cells.Length; i++)
            {
                CopiedCells[i] = new Cell(cells[i].isOccupied,cells[i].OccupyingShip, cells[i].Row, cells[i].Column);
            }

            return CopiedCells;
        }
    }
}
