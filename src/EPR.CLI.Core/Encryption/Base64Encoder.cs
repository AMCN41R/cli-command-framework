using System;
using System.Text;

namespace EPR.CLI.Core.Encryption
{
    public interface IBase64Encoder
    {
        string Encode(string value);

        string Decode(string value);
    }

    internal class Base64Encoder : IBase64Encoder
    {
        public string Encode(string plainText)
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(plainText), plainText);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        public string Decode(string encryptedText)
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(encryptedText), encryptedText);

            return Encoding.UTF8.GetString(Convert.FromBase64String(encryptedText));
        }
    }
}
