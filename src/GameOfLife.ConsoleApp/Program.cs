using System;
using GameOfLife.ConsoleApp.Util;

namespace GameOfLife.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new App(new GameOfLifeConsole())
                .Run();
        }
    }
}
