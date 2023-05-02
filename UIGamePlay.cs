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
        public void UpdateDisplay()
        {
            Console.Clear();
            PrintOpponentBoard(Player2Board);
            PrintBoard(Player1Board);
            Console.WriteLine();
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



                    characterChar = possibleCharacters[i];

                    Console.Write($"{characterChar}{j} ");

                }

                Console.Write("\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        private void PrintOpponentBoard(Board Board)
        {
            var BoardGrid = Board._cells;
            string possibleCharacters = "ABCDEFGHIJ";
            int characterDigit = 0;
            char characterChar = ' ';

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;


                    // temporary for testing purposed=s
                    if (BoardGrid[i, j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    //remove after



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
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    characterChar = possibleCharacters[i];

                    Console.Write($"{characterChar}{j} ");

                }

                Console.Write("\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

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

        public Cell HandleUserInput()
        {
            // Declare grid and two Cell arrays to move user's choice for ship placement
            _currentChoice = new Cell(0, 0);
            var AttemptedCell = new Cell(0, 0);

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

                    case ConsoleKey.Enter:
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

        public void SuccessfulShot(Cell coord)
        {
            Console.WriteLine($"{coord.CoordinatesToString()} is  hit.");

        }
        public void MissedShot(Cell coord)
        {
            Console.WriteLine($"{coord.CoordinatesToString()} is  miss.");

        }
        public void RepeatedShot(Cell coord)
        {
            Console.WriteLine($"You have already fired a shot at{coord.CoordinatesToString()}.");
        }

        public void SunkAShip(Ship ship)
        {
            Console.WriteLine($"You sunk a {ship.Type}.");

        }
    }
}
