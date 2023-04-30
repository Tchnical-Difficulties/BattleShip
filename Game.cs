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

        }

        private void GameLoop()
        {
            var ui = new UIGamePlay(Players[0], Players[1]);
            bool GameHasEnded = false;
            Cell shot = new Cell(0, 0);

            while (!GameHasEnded)
            {
                shot = Players[0].MakeMove(ui);

                while (!Players[0].Board.ValidateShot(shot))
                {
                    shot = Players[0].MakeMove(ui);
                }
                if (Players[0].Board.IsAHit(shot))
                {
                    
                    Console.WriteLine("Nice shot");
                    if (shot.OccupyingShip.RegisterHit())
                    {
                        Console.WriteLine($"You sunk a {shot.OccupyingShip.Type}\n");
                    }
                    Console.ReadKey();
                }

                else{
                    Console.WriteLine("That shot was a miss! try again!");
                    Console.ReadKey();
                }

                GameHasEnded = CheckForWin();
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
