using System.Linq;
using System.Text;

namespace GameOfLife.ConsoleApp.Util.Formatters
{
    public class ConsoleFormatter
    {
        public static string Format(Game game)
        {
            if (game.Grid.ElementAt(0).ElementAt(0) == Cell.ALIVE)
            {
                return "X";
            }

            return "·";
        }
    }
}
