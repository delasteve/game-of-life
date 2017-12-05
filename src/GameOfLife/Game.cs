using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private List<List<Cell>> _grid;

        public Game(int height, int width)
        {
            _grid = Enumerable
                .Range(0, height)
                .Select(x => Enumerable
                    .Repeat(Cell.DEAD, width)
                    .ToList())
                .ToList();
        }

        public IEnumerable<IEnumerable<Cell>> Grid { get { return _grid; } }

        public void ToggleState(int x, int y)
        {
            if (_grid[y][x] == Cell.ALIVE)
            {
                _grid[y][x] = Cell.DEAD;
            }
            else
            {
                _grid[y][x] = Cell.ALIVE;
            }
        }
    }
}
