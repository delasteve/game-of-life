using GameOfLife.ConsoleApp.Util;
using Moq;
using Xunit;

namespace GameOfLife.ConsoleApp.Tests
{
    public class AppIntegrationTests
    {
        [Fact]
        public void Run_AppWillClearConsole()
        {
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(x => x.Clear());

            var app = new App(mockConsole.Object);

            app.Run();

            mockConsole.Verify(x => x.Clear(), Times.Once());
        }
    }
}
