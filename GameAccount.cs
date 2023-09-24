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

        public void AddStatistic(Game stats)
        {
            games.Add(stats);
        }

        public void GetStats()
        {
            Console.WriteLine("\t\tGames statistic:\n");
            for (int i = 0; i < this.games.Count(); i++)
            {
                games[i].GetStatistic();
                Console.WriteLine();
            }
        }
    }

    class Game
    {
        private int IdentificationNumber { get; set; }
        GameAccount User1 { get; set; }
        GameAccount User2 { get; set; }
        private string GameStatistic { get; set; }



        public Game(GameAccount user1, GameAccount user2)
        {
            if (user1 == user2)
            {
                throw new InvalidDataException("You can't play with yourself!");
            }
            User1 = user1;
            User2 = user2;

            var rand = new Random();
            IdentificationNumber = rand.Next(1000, 10000);
            GameStatistic = "-";
        }

        public string StartGame()
        {
            string winner = "";
            var rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                User1.WinGame();
                User2.LoseGame();
                winner = User1.GetUserName();

                GameStatistic = $"\t Game Identification Number: {IdentificationNumber}\n\t Winner: {User1.GetUserName()}\t\t Loser: {User2.GetUserName()}" +
                $"\n\t {User1.GetUserName()} current raiting: {User1.GetCurentRaiting()}\t\t {User2.GetUserName()} current raiting: {User2.GetCurentRaiting()}";
            }
            else
            {
                User1.LoseGame();
                User2.WinGame();
                winner = User2.GetUserName();

                GameStatistic = $"\t Game Identification Number: {IdentificationNumber}\n\t Winner: {User2.GetUserName()}\t\t Loser: {User1.GetUserName()}" +
                $"\n\t {User2.GetUserName()} current raiting: {User2.GetCurentRaiting()}\t\t {User1.GetUserName()} current raiting: {User1.GetCurentRaiting()}";
                
            }
            User1.AddStatistic(this);
            User2.AddStatistic(this);

            return winner;
        }

        public void GetStatistic() 
        {
            Console.WriteLine(GameStatistic);
        }
    }
}
