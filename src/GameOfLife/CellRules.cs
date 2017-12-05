using System.Collections.Generic;

namespace GameOfLife
{
    public class CellRules
    {
        public static Cell GetNextCellGeneration(Cell cell, IEnumerable<Cell> neighbors)
        {
            return Cell.DEAD;
        }
    }
}
