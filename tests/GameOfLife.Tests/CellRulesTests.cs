using System.Linq;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellRulesTests
    {
        [Theory]
        [InlineData(Cell.ALIVE, 0, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 1, Cell.DEAD)]
        [InlineData(Cell.ALIVE, 2, Cell.ALIVE)]
        [InlineData(Cell.ALIVE, 3, Cell.ALIVE)]
        [InlineData(Cell.ALIVE, 4, Cell.DEAD)]
        public void GetNextCellGeneration_GivenCurrentGenerationCellAndAliveNeighbors_ReturnsExpectedNextCellGeneration
            (Cell currentGenerationCell, int aliveNeighborCount, Cell expectedNextGenerationCell)
        {
            var aliveNeighbors = Enumerable
                .Repeat(Cell.ALIVE, aliveNeighborCount)
                .ToList();

            var result = CellRules.GetNextCellGeneration(currentGenerationCell, aliveNeighbors);

            result.Should().Be(expectedNextGenerationCell);
        }
    }
}
