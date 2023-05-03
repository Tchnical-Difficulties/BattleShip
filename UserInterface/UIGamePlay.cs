using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class UIGamePlay : IUserInterface
    {

        public List<Player> Players = new List<Player>();
        private Board Player1Board;
        private Board Player2Board;
        
        private Cell _currentChoice = new Cell(0, 0);
        public UIGamePlay(Player player1, Player player2)
        {
            Players.Add(player1);
            Players.Add(player2);
            Player1Board = player1.Board;
            Player2Board = player2.Board;
        }
        /// <summary>
        /// Clears the screen and shows all relevant gameplay information
        /// </summary>
        public void UpdateDisplay()
        {
            Console.Clear();
            Console.WriteLine("           Enemy Field");
            PrintOpponentBoard(Player2Board);
            Console.Write("-------------------------------------------------------------\n");

            Console.WriteLine("           Your Field");
            PrintBoard(Player1Board);
            Console.WriteLine("Choose your shot location with the Arrow keys and press Spacebar to fire.");
            Console.Write("\n");
        }

        /// <summary>
        /// Prints the player's board. Misses are white, hits are red, ships are green.
        /// </summary>
        /// <param name="Board">Player's board</param>
        private void PrintBoard(Board Board)
        {
            var BoardGrid = Board._cells;
            string possibleCharacters = "ABCDEFGHIJ";

            Console.WriteLine("   1  2  3  4  5  6  7  8  9  10");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{possibleCharacters[i]} ");
                for (int j = 0; j < 10; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;

                    if (BoardGrid[i, j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    if (BoardGrid[i, j].Status == "Hit")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (BoardGrid[i, j].Status == "Missed")
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write($"[ ]");

                }

                Console.BackgroundColor = ConsoleColor.Black;
                PrintExtraInfo(i, Players[0]);
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Prints opponent's board. White cells are a miss, red cells are a hit
        /// </summary>
        /// <param name="Board">Opponent's board</param>
        private void PrintOpponentBoard(Board Board)
        {
            var BoardGrid = Board._cells;
            string possibleCharacters = "ABCDEFGHIJ";
            bool CellIsTargeted = false;

            Console.WriteLine("   1  2  3  4  5  6  7  8  9  10");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{possibleCharacters[i]} ");
                for (int j = 0; j < 10; j++)
                {
                    // Used for display purposes. The selected cell will be turned white
                    CellIsTargeted = false;

                    //Default color for the map
                    Console.BackgroundColor = ConsoleColor.Blue;

                    /*
                    if (BoardGrid[i, j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    */

                    if (BoardGrid[i, j].Status == "Hit")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (BoardGrid[i, j].Status == "Missed")
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    if (BoardGrid[i, j] == _currentChoice)
                    {
                        CellIsTargeted= true;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor= ConsoleColor.Black;
                    }

                    if (CellIsTargeted)
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write($"[ ]");
                    }
                    
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.BackgroundColor = ConsoleColor.Black;
                PrintExtraInfo(i, Players[1]);
                Console.Write("\n");
                
            }
        }

        /// <summary>
        /// Displays ships remaining for each player
        /// </summary>
        /// <param name="row"></param>
        /// <param name="player"></param>
        private void PrintExtraInfo(int row, Player player)
        {
            var SunkenShips = player.Board.SunkShips;
            switch (row)
            {
                case 1:
                    Console.Write("         Ships Remaining");
                    break;
                case 2:
                    Console.Write("    -------------------------");
                    break;
                case 3:
                    Console.Write("    Destroyer  |");
                    if(SunkenShips.Exists(s => s.Type == Ship.ShipType.Destroyer))
                    {
                        Console.BackgroundColor= ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    for (int i = 0; i < (int)Ship.ShipType.Destroyer; i++)
                    {
                        Console.Write("[]");
                    }
                    break;
                case 4:
                    Console.Write("    Cruiser    |");
                    if (SunkenShips.Exists(s => s.Type == Ship.ShipType.Cruiser))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    for (int i = 0; i < (int)Ship.ShipType.Cruiser; i++)
                    {
                        Console.Write("[]");
                    }
                    break;
                case 5:
                    Console.Write("    Submarine  |");
                    if (SunkenShips.Exists(s => s.Type == Ship.ShipType.Submarine))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    for (int i = 0; i < (int)Ship.ShipType.Submarine; i++)
                    {
                        Console.Write("[]");
                    }
                    break;
                case 6:
                    Console.Write("    Battleship |");
                    if (SunkenShips.Exists(s => s.Type == Ship.ShipType.BattleShip))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    for (int i = 0; i < (int)Ship.ShipType.BattleShip; i++)
                    {
                        Console.Write("[]");
                    }
                    break;
                case 7:
                    Console.Write("    Carrier    |");
                    if (SunkenShips.Exists(s => s.Type == Ship.ShipType.Carrier))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    for (int i = 0; i < (int)Ship.ShipType.Carrier; i++)
                    {
                        Console.Write("[]");
                    }
                    break;

            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Returns the instance of a cell from the opponent's board with
        /// matching coordinates to the incoming cell
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Cell OpponentShotReference(Cell coordinate)
        {
            foreach (Cell c in Player1Board._cells)
            {
                if (coordinate == c)
                {
                    coordinate = c;
                }
            }

            return coordinate;
        }
        /// <summary>
        /// Returns an instance of a cell from the player's board that matches
        /// the coordinates of the incoming cell
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Cell PlayerShotReference(Cell coordinate)
        {
            foreach (Cell c in Player2Board._cells)
            {
                if (coordinate == c)
                {
                    coordinate = c;
                }
            }

            return coordinate;
        }

        /// <summary>
        /// Allows the user to use arrow keys and space/enter to select a cell to fire at
        /// </summary>
        /// <returns>The cell that the user selects</returns>
        public Cell HandleUserInput()
        {
            // Declare grid and two Cell arrays to move user's choice for ship placement
            _currentChoice = new Cell(4, 4);
            var AttemptedCell = new Cell(4, 4);

            ConsoleKeyInfo keyInfo;

            while (true)
            {

                UpdateDisplay();
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {

                    case ConsoleKey.UpArrow:
                        AttemptedCell = new Cell(_currentChoice.Row - 1, _currentChoice.Column);
                        break;

                    case ConsoleKey.DownArrow:
                        AttemptedCell = new Cell(_currentChoice.Row + 1, _currentChoice.Column);
                        break;

                    case ConsoleKey.LeftArrow:
                        AttemptedCell = new Cell(_currentChoice.Row, _currentChoice.Column - 1);
                        break;

                    case ConsoleKey.RightArrow:
                        AttemptedCell = new Cell(_currentChoice.Row, _currentChoice.Column + 1);
                        break;

                    case ConsoleKey.Spacebar:
                        var row = AttemptedCell.Row;
                        var col = AttemptedCell.Column;
                        AttemptedCell = Player2Board._cells[row, col];
                        return AttemptedCell;


                }

                // Check to make sure choice is in bounds

                if (Board.IsInBounds(AttemptedCell))
                {
                    _currentChoice = new Cell(AttemptedCell.Row, AttemptedCell.Column);
                }


                //CurrentCoordinate = CopyCells(AttemptedCoordinate);

            }
        }

        /// <summary>
        /// Resets _currectChoice so the display doesn't keep showing a white cell
        /// </summary>
        public void ClearShot()
        {
            _currentChoice = new Cell(-1, -1);
        }

        public void SuccessfulShot(Cell coord)
        {
            Console.WriteLine($"{coord.CoordinatesToString()} is a hit.");

        }
        public void MissedShot(Cell coord)
        {
            Console.WriteLine($"{coord.CoordinatesToString()} is a miss.");

        }
        public void RepeatedShot(Cell coord)
        {
            Console.WriteLine($"You have already fired a shot at {coord.CoordinatesToString()}.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void SunkAShip(Ship ship)
        {
            Console.WriteLine($"You sunk a {ship.Type}.");
        }

        public void EnemySunkAShip(Ship ship)
        {
            Console.WriteLine($"The enemy sunk your {ship.Type}");
        }

        public void EnemyHit(Cell coord)
        {
            Console.WriteLine($"Enemy hit your ship at {coord.CoordinatesToString()}.");
        }

        public void EnemyMiss(Cell coord)
        {
            Console.WriteLine($"Enemy fired a missed shot at {coord.CoordinatesToString()}.");
        }
    }
}
