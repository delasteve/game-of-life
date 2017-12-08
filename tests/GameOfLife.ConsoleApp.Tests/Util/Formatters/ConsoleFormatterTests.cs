using System;
using FluentAssertions;
using GameOfLife.ConsoleApp.Util.Formatters;
using Xunit;

namespace GameOfLife.ConsoleApp.Tests.Util.Formatters
{
    public class ConsoleFormatterTests
    {
        [Fact]
        public void Format_GivenAGridWithASingleDeadCell_WillPrintACenteredDot()
        {
            var game = new Game(1, 1);

            var output = ConsoleFormatter.Format(game);

            output.Should().Be($"·{Environment.NewLine}");
        }

        [Fact]
        public void Format_GivenAGridWithASingleAliveCell_WillPrintACapitalX()
        {
            var game = new Game(1, 1);
            game.ToggleState(0, 0);

            var output = ConsoleFormatter.Format(game);

            output.Should().Be($"X{Environment.NewLine}");
        }

        [Fact]
        public void Format_GivenAGridWithTwoRowsAndDeadCells_WillReturnAMultilineString()
        {
            var expectedOutput = string.Join(
                Environment.NewLine,
                "·",
                "·"
            );
            expectedOutput += Environment.NewLine;

            var game = new Game(1, 2);

            var output = ConsoleFormatter.Format(game);

            output.Should().Be(expectedOutput);
        }
    }
}
