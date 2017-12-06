using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private readonly int _height;
        private readonly int _width;
        private List<List<Cell>> _grid;

        public Game(int height, int width)
        {
            _height = height;
            _width = width;

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

        public void SpawnNextGeneration()
        {
            var clonedGrid = CreateShallowCopyOfGrid();
            var oldGrid = _grid;
            _grid = clonedGrid;

            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _grid[y][x] = CellRules.GetNextCellGeneration(oldGrid[y][x], GetNeighbors(oldGrid, x, y));
                }
            }
        }

        private IEnumerable<Cell> GetNeighbors(List<List<Cell>> grid, int x, int y)
        {
            var neighbors = new List<Cell>();

            for (int row = -1; row < 2; row++)
            {
                for (int col = -1; col < 2; col++)
                {
                    if (row == 0 && col == 0) { continue; }

                    var neighborX = x + col;
                    var neighborY = y + row;

                    if (neighborX < 0 || neighborX >= _width) { continue; }
                    if (neighborY < 0 || neighborY >= _height) { continue; }

                    neighbors.Add(grid[neighborY][neighborX]);
                }
            }

            return neighbors;
        }

        private List<List<Cell>> CreateShallowCopyOfGrid()
        {
            return _grid.Select(y => y.ToList()).ToList();
        }
    }
}
