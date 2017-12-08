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

            output.Should().Be("·");
        }
    }
}
