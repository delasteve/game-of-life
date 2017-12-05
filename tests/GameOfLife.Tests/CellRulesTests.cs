using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellRulesTests
    {
        [Fact]
        public void GetNextCellGeneration_GivenAliveCellWithZeroAliveNeighbors_ReturnsDeadCell()
        {
            var result = CellRules.GetNextCellGeneration(Cell.ALIVE, new List<Cell>());

            result.Should().Be(Cell.DEAD);
        }
    }
}
