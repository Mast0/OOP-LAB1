using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    class GameAccount
    {
        private string UserName { get; }
        private int CurrentRating { get; set; }
        private int GameCount { get; set; }
        private List<Game> games = new List<Game>();

        public GameAccount(string userName) {
            UserName = userName;
            CurrentRating = 1;
            GameCount = 0;
        }

        public string GetUserName()
        {
            return UserName;
        }

        public int GetCurentRaiting()
        {
            return CurrentRating;
        }

        public int GetGameCount()
        {
            return GameCount;
        }

        public void WinGame()
        {
            CurrentRating++;
            GameCount++;
        }

        public void LoseGame()
        {
            if (CurrentRating-1 >= 1)
            {
                CurrentRating--;
            }
            GameCount++;
        }

        public void StartGame(GameAccount other)
        {
            var rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                Game newGame = new Game(this, other);
                this.games.Add(newGame);
                other.games.Add(newGame);
            }
            else
            {
                Game newGame = new Game(other, this);
                this.games.Add(newGame);
                other.games.Add(newGame);
            }
        }

        public void GetStats()
        {
            for (int i = 0; i < this.games.Count(); i++)
            {
                games[i].GetStatistic();
                Console.WriteLine();
            }
        }
    }

    class Game
    {
        private static int IdentificationNumber { get; set; }
        GameAccount Winner { get; set; }
        GameAccount Loser { get; set; }



        public Game(GameAccount winner, GameAccount loser)
        {
            Winner = winner;
            Loser = loser;
            winner.WinGame();
            loser.LoseGame();
            IdentificationNumber = 1000;
            IdentificationNumber++;
        }

        public void GetStatistic() 
        {
            Console.WriteLine($"\t Game Identification Number: {IdentificationNumber}\n\t Winner: {Winner.GetUserName()}\t\t Loser: {Loser.GetUserName}" +
                $"\n\t {Winner.GetUserName()} current raiting: {Winner.GetCurentRaiting()}\t\t {Loser.GetUserName()} current raiting: {Loser.GetCurentRaiting()}");
        }
    }
}
