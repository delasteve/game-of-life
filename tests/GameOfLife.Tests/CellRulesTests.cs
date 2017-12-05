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

        [Fact]
        public void GetNextCellGeneration_GivenAliveCellWithOneAliveNeighbor_ReturnsDeadCell()
        {
            var result = CellRules.GetNextCellGeneration(Cell.ALIVE, new List<Cell> {
                Cell.ALIVE
            });

            result.Should().Be(Cell.DEAD);
        }

        [Fact]
        public void GetNextCellGeneration_GivenAliveCellWithTwoAliveNeighbors_ReturnsAliveCell()
        {
            var result = CellRules.GetNextCellGeneration(Cell.ALIVE, new List<Cell> {
                Cell.ALIVE,
                Cell.ALIVE
            });

            result.Should().Be(Cell.ALIVE);
        }

        [Fact]
        public void GetNextCellGeneration_GivenAliveCellWithThreeAliveNeighbors_ReturnsAliveCell()
        {
            var result = CellRules.GetNextCellGeneration(Cell.ALIVE, new List<Cell> {
                Cell.ALIVE,
                Cell.ALIVE,
                Cell.ALIVE
            });

            result.Should().Be(Cell.ALIVE);
        }

        [Fact]
        public void GetNextCellGeneration_GivenAliveCellWithFourAliveNeighbors_ReturnsDeadCell()
        {
            var result = CellRules.GetNextCellGeneration(Cell.ALIVE, new List<Cell> {
                Cell.ALIVE,
                Cell.ALIVE,
                Cell.ALIVE,
                Cell.ALIVE
            });

            result.Should().Be(Cell.DEAD);
        }
    }
}
