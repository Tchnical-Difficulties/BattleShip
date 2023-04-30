using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class UIGamePlay : IUserInterface
    {
        private Board _board;
        public UIGamePlay(Board Board)
        {
            _board= Board;
        }
        public void UpdateDisplay()
        {
            PrintBoard(_board);
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
                    if (BoardGrid[i, j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    characterChar = possibleCharacters[i];

                    Console.Write($"{characterChar}{j} ");
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                Console.Write("\n");
            }
        }

        public void GetUserInput(int size)
        {

        }
    }
}
