using System;
using GameClasses;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            GameAccount user = new GameAccount("Mast");
            GameAccount gamer = new GameAccount("Deremion");
            user.StartGame(gamer);
            gamer.StartGame(user);
            user.GetStats();
        }
    }
}
