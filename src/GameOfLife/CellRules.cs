using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class CellRules
    {
        public static Cell GetNextCellGeneration(Cell cell, IEnumerable<Cell> neighbors)
        {
            var aliveNeighbors = neighbors.Count(neighbor => neighbor == Cell.ALIVE);

            if (cell == Cell.ALIVE && aliveNeighbors == 2) {
                return Cell.ALIVE;
            } else if (cell == Cell.ALIVE && aliveNeighbors == 3) {
                return Cell.ALIVE;
            }

            return Cell.DEAD;
        }
    }
}
