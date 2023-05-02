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
            InitializeGame();
            GameLoop();
        }

        private void InitializeGame()
        {
            Players.Add(new HumanPlayer());
            PlayerBoards.Add(Players[0].Board);

            Players.Add(new AIPlayer());
            PlayerBoards.Add(Players[1].Board);

            Players[0].PlaceAllShips();
            Players[1].PlaceAllShips();


        }

        private void GameLoop()
        {
            var ui = new UIGamePlay(Players[0], Players[1]);
            bool GameHasEnded = false;
            Cell shot = new Cell(0, 0);
            int PlayerTurn = 0;
            int Opponent = 1;

            while (!GameHasEnded)
            {
                
                // User's Turn
                shot = Players[0].MakeMove(ui);
                shot = ui.PlayerShotReference(shot);

                while (!Players[1].Board.ValidateShot(shot))
                {
                    ui.RepeatedShot(shot);
                    
                    shot = Players[0].MakeMove(ui);
                    shot = ui.PlayerShotReference(shot);
                }
                if (Players[1].Board.IsAHit(shot))
                {
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

        private void PostGame()
        {

        }

        private bool CheckForWin()
        {
            if (Players.Exists(x => x.ShipsRemaining == 0))
            {
                foreach (Player p in Players)
                {
                    if (p.ShipsRemaining == 0)
                    {
                        p.WinStatus = "Win";
                        Console.WriteLine("Somebody won the game.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();

                    }
                    else
                    {
                        p.WinStatus = "Lose";
                    }
                }
                return true;
            }
            return false;
        }

        
    }
}
