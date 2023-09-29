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
        private string username;
        private int raiting;
        public string UserName { get { return username; } }
        public int CurrentRating { 
            get { return raiting; } set {
				if (value > 1)
				{
					raiting = value;
				}
			} }
        public int GameCount { get { return games.Count; } }
        private List<Game> games = new List<Game>();

        public GameAccount(string userName) {
            username = userName;
            raiting = 1;
        }

        public void WinGame()
        {
            CurrentRating++;
        }

        public void LoseGame()
        {
            CurrentRating--;
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
        private int Index;
        public static int IdentificationNumber;
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
            IdentificationNumber++;
            Index = IdentificationNumber;

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
                winner = User1.UserName;

                GameStatistic = $"\t Game Identification Number: {Index}\n\t Winner: {User1.UserName}\t\t Loser: {User2.UserName}" +
                $"\n\t {User1.UserName} current raiting: {User1.CurrentRating}\t\t {User2.UserName} current raiting: {User2.CurrentRating}";
            }
            else
            {
                User1.LoseGame();
                User2.WinGame();
                winner = User2.UserName;

                GameStatistic = $"\t Game Identification Number: {Index}\n\t Winner: {User2.UserName}\t\t Loser: {User1.UserName}" +
                $"\n\t {User2.UserName} current raiting: {User2.CurrentRating}\t\t {User1.UserName} current raiting: {User1.CurrentRating}";
                
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
