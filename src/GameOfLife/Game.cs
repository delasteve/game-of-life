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
                    var neighbors = new List<Cell>();

                    try {
                        neighbors.Add(_grid[y-1][x-1]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y-1][x]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y-1][x+1]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y][x-1]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y][x+1]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y+1][x-1]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y+1][x]);
                    } catch (Exception) { }

                    try {
                        neighbors.Add(_grid[y+1][x+1]);
                    } catch (Exception) { }

                    _grid[y][x] = CellRules.GetNextCellGeneration(_grid[x][y], neighbors);
                }
            }
        }

        private List<List<Cell>> CreateShallowCopyOfGrid()
        {
            return _grid.Select(y => y.ToList()).ToList();
        }
    }
}
