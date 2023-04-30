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
            Cell shot;

            while (true)
            {
                shot = Players[0].MakeMove(ui);
                if (Players[0].Board.IsAHit(shot))
                {
                    Console.WriteLine("Nice shot");
                    Console.ReadLine();
                }

                else{
                    Console.WriteLine("That shot was a miss! try again!");
                    Console.ReadLine();
                }
            }

        }

        private void PostGame()
        {

        }

        private bool CheckForWin()
        {
            return true;
        }

        
    }
}
