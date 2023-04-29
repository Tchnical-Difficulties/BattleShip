using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Board();

            //Console.WriteLine("Hello. Test for Github!");


            

            var player1 = new Player();
            player1.PlaceAllShips();
            #region Test placing a BattleShip
            /*
            var cells = a._cells;
            Cell[] TestLocation = new Cell[5]
            {
                cells[0, 0],
                cells[1, 0],
                cells[2, 0],
                cells[3, 0],
                cells[4, 0]
            };

            foreach (Cell c in TestLocation)
            {
                c.isOccupied= true;
            }
            var Carrier = new CarrierShip(TestLocation);
            */
            #endregion
            #region Coordinate Printing

            // Iterates through each cell of a board and prints the coordinates
            string possibleCharacters = "ABCDEFGHIJ";
            int characterDigit = 0;
            char characterChar = ' ';

            Console.WriteLine("Player One's Board");
            Console.BackgroundColor = ConsoleColor.Blue;

            var testBoard = player1.Board._cells;
            for (int i = 0;i < 10; i++)
            {
                for (int j=0;j < 10;j++)
                {
                    if (testBoard[i,j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    characterChar = possibleCharacters[i];

                    Console.Write($"{characterChar}{j} ");
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                Console.Write("\n");
            }
            #endregion


            Console.ReadLine();
        }
    }
}
