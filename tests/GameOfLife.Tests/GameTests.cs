using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        public void Constructor_GivenAHeightAndWidth_Creates2dGridOfDeadCells()
        {
            var game = new Game(2, 2);
            var expectedGrid = new List<List<Cell>>
            {
                new List<Cell> { Cell.DEAD, Cell.DEAD },
                new List<Cell> { Cell.DEAD, Cell.DEAD }
            };

            game.Grid.ShouldBeEquivalentTo(expectedGrid);
        }
    }
}
