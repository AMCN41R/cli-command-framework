using EPR.CLI.Core.Commands;
using Xunit;

namespace EPR.CLI.Core.Tests.Commands
{
    public class CommandValidationResultTests
    {
        [Fact]
        public void CommandValidationResult_ContructWithNoParams_SetsExpectedPropertyValues()
        {
            // Arrange / Act
            var sut = new CommandValidationResult();

            // Assert
            Assert.True(sut.IsValid);
            Assert.Null(sut.Reason);
        }

        [Fact]
        public void CommandValidationResult_ContructWithReason_SetsExpectedPropertyValues()
        {
            // Arrange / Act
            var sut = new CommandValidationResult("reason");

            // Assert
            Assert.False(sut.IsValid);
            Assert.Equal("reason", sut.Reason);
        }
    }
}
