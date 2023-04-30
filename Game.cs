using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Game
    {
        List<Player> players = new List<Player>();

        public Game() { }

        public void RunGame()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            players.Add(new Player());
            players.Add(new Player());

            foreach (var player in players)
            {
                player.PlaceAllShips();
            }
        }

        private void GameLoop()
        {

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
