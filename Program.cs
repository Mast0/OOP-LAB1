using System;
using GameClasses;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Mast");
            Console.WriteLine(user.GetUserName());
        }
    }
}
