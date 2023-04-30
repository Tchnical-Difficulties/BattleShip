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

            var Game1 = new Game();
            Game1.RunGame();









            var a = new Board();

            //Console.WriteLine("Hello. Test for Github!");


            

            var player1 = new Player();
            player1.PlaceShip(new Ship(Ship.ShipType.Carrier));
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
            

            Console.WriteLine("Player One's Board");
            Console.BackgroundColor = ConsoleColor.Blue;

            var testBoard = player1.Board;

            var testUI = new UIGamePlay(testBoard);
            testUI.UpdateDisplay();
            #endregion


            Console.ReadLine();
        }
    }
}
