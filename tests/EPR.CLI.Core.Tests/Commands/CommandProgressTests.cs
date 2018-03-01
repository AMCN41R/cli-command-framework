using EPR.CLI.Core.Commands;
using Xunit;

namespace EPR.CLI.Core.Tests.Commands
{
    public class CommandProgressTests
    {
        [Fact]
        public void CommandProgress_ConstructWithMessage_SetsExpectedPropertyValues()
        {
            // Arrange / Act
            var sut = new CommandProgress("message");

            // Assert
            Assert.False(sut.HasKey);
            Assert.Null(sut.Key);
            Assert.Null(sut.Value);
            Assert.Equal("message", sut.Message);
        }

        [Fact]
        public void CommandProgress_ConstructWithKeyAndValue_SetsExpectedPropertyValues()
        {
            // Arrange / Act
            var sut = new CommandProgress("key", "value");

            // Assert
            Assert.True(sut.HasKey);
            Assert.Equal("key", sut.Key);
            Assert.Equal("value", sut.Value);
            Assert.Equal("key: value", sut.Message);
        }
    }
}
