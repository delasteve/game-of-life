using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void ToggleState_GivenAZeroBasedXandYCoordinateAndADeadCell_UpdatesCellToBeAlive()
        {
            var game = new Game(2, 2);

            game.ToggleState(0, 0);

            game.Grid.ElementAt(0).ElementAt(0).Should().Be(Cell.ALIVE);
        }

        [Fact]
        public void ToggleState_GivenAZeroBasedXandYCoordinateAndAnAliveCell_UpdatesCellToBeDead()
        {
            var game = new Game(2, 2);

            game.ToggleState(0, 0);

            game.Grid.ElementAt(0).ElementAt(0).Should().Be(Cell.ALIVE);

            game.ToggleState(0, 0);

            game.Grid.ElementAt(0).ElementAt(0).Should().Be(Cell.DEAD);
        }

        [Fact]
        public void SpawnNextGeneration_GivenAValidGameGrid_ReplacesGridWithCopy()
        {
            var game = new Game(2, 2);
            var oldGrid = game.Grid;

            game.SpawnNextGeneration();

            oldGrid.Should().NotBeSameAs(game.Grid);
        }
    }
}
