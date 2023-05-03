using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Game
    {
        public List<Player> Players = new List<Player>();
        public List<Board> PlayerBoards = new List<Board>();

        public Game() { }

        public void RunGame()
        {
            int UserChoice = 0;

            // MainMenuLoop will prompt user for decision to start game or exit program
            UserChoice = MainMenuLoop();

            // Loop initializes a game and keeps prompting user to play until they choose to exit
            while(UserChoice == 0)
            {
                InitializeGame();
                GameLoop();
                UserChoice = MainMenuLoop();
            }

            Exit();
            return;
        }

        /// <summary>
        /// Initializes two player objects and their ships are placed on the map
        /// </summary>
        private void InitializeGame()
        {
            Players.Add(new HumanPlayer());
            PlayerBoards.Add(Players[0].Board);

            Players.Add(new AIPlayer());
            PlayerBoards.Add(Players[1].Board);
   
            Players[0].PlaceAllShips();
            Players[1].PlaceAllShips();
        }
        /// <summary>
        /// Displays an exit message for the user
        /// </summary>
        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!\nPress any key to exit.");
            Console.ReadKey();
        }
        /// <summary>
        /// Displays user's choices and returns their selection
        /// </summary>
        /// <returns></returns>
        private int MainMenuLoop()
        {
            var ui = new UIMainMenu();
            if (ui.HandleUserInput() == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// Players take turns making shots and the outcome is checked
        /// The game checks for a winner after every player's turn
        /// </summary>
        private void GameLoop()
        {
            var ui = new UIGamePlay(Players[0], Players[1]);
            bool GameHasEnded = false;
            Cell shot = new Cell(0, 0);

            while (!GameHasEnded)
            {
                
                // User's Turn
                shot = Players[0].MakeMove(ui);
                // PlayerShotReference makes the shot object reference the actual
                // cell on the opponents board so it can be updated
                shot = ui.PlayerShotReference(shot);

                while (!Players[1].Board.ValidateShot(shot))
                {
                    ui.RepeatedShot(shot);
                    
                    shot = Players[0].MakeMove(ui);
                    shot = ui.PlayerShotReference(shot);
                }

                if (Players[1].Board.IsAHit(shot))
                {
                    // Clearshot is for display purposes, otherwise the cell remains white
                    ui.ClearShot();
                    ui.UpdateDisplay();
                    ui.SuccessfulShot(shot);
                    if (shot.OccupyingShip.RegisterHit())
                    {
                        ui.SunkAShip(shot.OccupyingShip);
                        Players[1].Board.SunkShips.Add(shot.OccupyingShip);
                        Players[1].ShipsRemaining--;
                    }
                }

                else{
                    ui.MissedShot(shot);
                }

                if (CheckForWin())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(); // Gives user time to read results
                }

                // Computer's Turn
                shot = Players[1].MakeMove(ui);
                shot = ui.OpponentShotReference(shot);

                while (!Players[0].Board.ValidateShot(shot))
                {
                    shot = Players[1].MakeMove(ui);
                    shot = ui.OpponentShotReference(shot);
                }
                if (Players[0].Board.IsAHit(shot))
                {
                    ui.UpdateDisplay();
                    ui.EnemyHit(shot);

                    if (shot.OccupyingShip.RegisterHit())
                    {
                        ui.EnemySunkAShip(shot.OccupyingShip);
                    }
                }

                else
                {
                    ui.UpdateDisplay();
                    ui.EnemyMiss(shot);
                }
                GameHasEnded = CheckForWin();

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

        }

        private bool CheckForWin()
        {
            if (Players[0].ShipsRemaining == 0)
            {
                Console.WriteLine("The enemy won the game!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return true;
            }
            else if (Players[1].ShipsRemaining == 0)
            {
                Console.WriteLine("You won the game!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return true;
            }
            else
            {
                return false;
            }
        }      
    }
}
