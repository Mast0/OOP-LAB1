using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    class User
    {
        private string UserName { get; }
        private int CurrentRating { get; set; }
        private int GameCount { get; set; }

        public User(string userName) {
            UserName = userName;
            CurrentRating = 0;
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
            if (CurrentRating-- < 0)
            {
                throw new InvalidOperationException("The raiting cannot be negative");
            }
            CurrentRating--;
            GameCount++;
        }
    }
}
