using FC.Core.Extension.StringHandlers;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FC.Core.Extension.Test.Strings
{
    public class SecureHashExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public SecureHashExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }
        #region Secure Has Test Methods
        [Fact]
        public void SecureHash_Test()
        {
            string plainText = "ganesh ram ravi";
            string encryptedText = plainText.Encrypt("pritish");
            _output.WriteLine($"PlainText {plainText} Cipher Text {encryptedText}");
            encryptedText.ShouldNotBe(plainText);
        }
        #endregion
    }
}
