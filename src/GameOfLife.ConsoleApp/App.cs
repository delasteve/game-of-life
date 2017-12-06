using GameOfLife.ConsoleApp.Util;

namespace GameOfLife.ConsoleApp
{
    public class App
    {
        private readonly IConsole _console;

        public App(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            _console.Clear();
        }
    }
}
