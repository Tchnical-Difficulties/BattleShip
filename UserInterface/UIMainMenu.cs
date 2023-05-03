using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class UIMainMenu : IUserInterface
    {
        private int _currentChoice;
        public UIMainMenu()
        {
            _currentChoice= 0;
        }

        public void UpdateDisplay()
        {
            Console.Clear();
            Console.WriteLine("Welcome to BattleShip");
            Console.WriteLine("---------------------");
            Console.WriteLine("User the arrow keys and Spacebar/Enter to make a selection.");
            Console.WriteLine("----------------------------------------------------------");
            Console.Write("Start Game");
            if(_currentChoice == 0)
            {
                Console.Write(" <--");
            }
            Console.Write("\n");

            Console.Write("Exit");
            if (_currentChoice == 1)
            {
                Console.Write("       <--");
            }
            Console.Write("\n");
        }
        /// <summary>
        /// Allows user to select between starting a game or exiting the game
        /// </summary>
        /// <returns>1: exit
        /// 2: start game</returns>
        public int HandleUserInput()
        {
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                UpdateDisplay();
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _currentChoice = (_currentChoice + 1) % 2;

                        break;
                    case ConsoleKey.DownArrow:
                        _currentChoice = (_currentChoice + 1) % 2;
                        break;
                    case ConsoleKey.Spacebar:
                        return _currentChoice;
                    case ConsoleKey.Enter:
                        return _currentChoice;
                }
            }
        }
    }
}
