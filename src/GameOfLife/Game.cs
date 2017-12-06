using System;
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

        public void SpawnNextGeneration()
        {
            var clonedGrid = CreateShallowCopyOfGrid();

            _grid = clonedGrid;

            for (var y = 0; y < _grid.Count; y++)
            {
                for (var x = 0; x < _grid[y].Count; x++)
                {
                    _grid[y][x] = CellRules.GetNextCellGeneration(_grid[x][y], GetNeighbors(x, y));
                }
            }
        }

        private IEnumerable<Cell> GetNeighbors(int x, int y)
        {
            var neighbors = new List<Cell>();

            for (int row = -1; row < 2; row++)
            {
                for (int col = -1; col < 2; col++)
                {
                    if (row == 0 && col == 0) { continue; }

                    try
                    {
                        neighbors.Add(_grid[y + row][x + col]);
                    }
                    catch (Exception) { }
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
