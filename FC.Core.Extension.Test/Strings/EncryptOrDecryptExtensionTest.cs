using FC.Core.Extension.StringHandlers;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FC.Core.Extension.Test.Strings
{
    public class EncryptOrDecryptExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public EncryptOrDecryptExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        #region Encrypt or Decrypt Test
        [Fact]
        public void Encrypt_Test()
        {
            string plainText = "ganesh ram ravi";
            string encryptedText = plainText.Encrypt("pritish");
            _output.WriteLine($"PlainText {plainText} Cipher Text {encryptedText}");
            encryptedText.ShouldNotBe(plainText);
        }

        [Fact]
        public void Decrypt_Test()
        {
            string plainText = "ganesh ram ravi";
            string key = "pritish";
            string encryptedText = plainText.Encrypt("pritish");
            string outString = encryptedText.Decrypt(key);
            _output.WriteLine($"Cipher Text {encryptedText} Decrypted Text {outString} ");
            outString.ShouldBe(plainText);
        }
        #endregion
    }
}
