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

            Console.WriteLine("Hello. Test for Github!");



            Console.BackgroundColor = ConsoleColor.Blue;

            //Test placing a BattleShip
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


            #region Coordinate Printing
            // Iterates through each cell of a board and prints the coordinates
            string possibleCharacters = "ABCDEFGHIJ";
            int characterDigit = 0;
            char characterChar = ' ';

            StringBuilder RowToPrint = new StringBuilder();
            
            for (int i = 0;i < 10; i++)
            {
                RowToPrint.Clear();
                
                for (int j=0;j < 10;j++)
                {
                    if (a._cells[i, j].isOccupied)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    characterChar = possibleCharacters[i];

                    Console.Write($"{characterChar}{a._cells[i, j].Column} ");
                    //RowToPrint.Append($"{characterChar}{a._cells[i, j].Column} ");

                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                //RowToPrint.Append('\n');
                Console.Write("\n");
            }
            #endregion


            Console.ReadLine();
        }
    }
}
