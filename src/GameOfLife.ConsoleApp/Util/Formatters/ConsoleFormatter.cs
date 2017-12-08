using System;
using System.Linq;
using System.Text;

namespace GameOfLife.ConsoleApp.Util.Formatters
{
    public class ConsoleFormatter
    {
        public static string Format(Game game)
        {
            var stringBuilder = new StringBuilder();

            foreach (var row in game.Grid)
            {
                if (row.ElementAt(0) == Cell.ALIVE)
                {
                    stringBuilder.Append("X");
                } else {
                    stringBuilder.Append("·");
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}
