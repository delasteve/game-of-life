using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class CellRules
    {
        public static Cell GetNextCellGeneration(Cell cell, IEnumerable<Cell> neighbors)
        {
            var aliveNeighbors = neighbors.Count(neighbor => neighbor == Cell.ALIVE);

            if (IsAliveCellAndShouldStayAlive(cell, aliveNeighbors))
            {
                return Cell.ALIVE;
            } else if (cell == Cell.DEAD && aliveNeighbors == 3) {
                return Cell.ALIVE;
            }

            return Cell.DEAD;
        }

        private static bool IsAliveCellAndShouldStayAlive(Cell cell, int aliveNeighbors)
        {
            return cell == Cell.ALIVE
                && (aliveNeighbors == 2 || aliveNeighbors == 3);
        }
    }
}
