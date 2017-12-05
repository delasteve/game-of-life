using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        public Game(int height, int width)
        {
            Grid = Enumerable
                .Range(0, height)
                .Select(x => Enumerable
                    .Repeat(Cell.DEAD, width)
                    .ToList())
                .ToList();
        }

        public IEnumerable<IEnumerable<Cell>> Grid { get; private set; }
    }
}
