using System;
using MVC_CarMarket.Controllers;

namespace MVC_CarMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller cnt = new Controller();
            cnt.Start();

            Console.ReadLine();
        }
    }
}
