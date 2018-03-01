using System;
using EPR.CLI.Core.Encryption;
using Xunit;

namespace EPR.CLI.Core.Tests.Encryption
{
    public class Base64EncoderTests
    {
        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(Guard.EmptyStringException))]
        [InlineData(" ", typeof(Guard.WhitespaceException))]
        public void Encode_NullEmptyOrWhitespaceString_ThrowsException(string value, Type exception)
        {
            Assert.Throws(
                exception,
                () => new Base64Encoder().Encode(value)
            );
        }

        [Fact]
        public void Encode_ValidString_ReturnsExpectedEncodedValue()
        {
            Assert.Equal("UEBzc3cwcmQ=", new Base64Encoder().Encode("P@ssw0rd"));
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(Guard.EmptyStringException))]
        [InlineData(" ", typeof(Guard.WhitespaceException))]
        public void Decode_NullEmptyOrWhitespaceString_ThrowsException(string value, Type exception)
        {
            Assert.Throws(
                exception,
                () => new Base64Encoder().Decode(value)
            );
        }

        [Fact]
        public void Decode_ValidString_ReturnsExpectedDecodedValue()
        {
            Assert.Equal("P@ssw0rd", new Base64Encoder().Decode("UEBzc3cwcmQ="));
        }
    }
}
