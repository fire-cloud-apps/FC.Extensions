using Xunit;
using Shouldly;
using Xunit.Abstractions;
using FC.Core.Strings.Extension;

namespace FC.Core.Extension.Test.Strings
{
    public class PasswordExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public PasswordExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        #region Password Hash Test
        [Fact]
        public void PasswordHashNoParam_Test()
        {
            string password = "SR Ganesh Ram Ravi";
            PasswordHashInfo pInfo = password.ToPasswordHash();
            pInfo.ShouldNotBeNull();
            pInfo.PasswordHash.ShouldNotBeSameAs(password);
            _output.WriteLine(pInfo.ToJSON<PasswordHashInfo>());
        }

        [Fact]
        public void PasswordHashWithParamAsByte_Test()
        {
            string password = "SR Ganesh Ram Ravi";
            byte[] salt = ToPasswordHashExtension.GetSaltAsByte();
            salt.ShouldNotBeNull();
            PasswordHashInfo pInfo = password.ToPasswordHash(salt);
            pInfo.ShouldNotBeNull();
            pInfo.PasswordHash.ShouldNotBeSameAs(password);
            _output.WriteLine(pInfo.ToJSON<PasswordHashInfo>());
        }

        [Fact]
        public void PasswordHashWithParamAsString_Test()
        {
            string password = "SR Ganesh Ram Ravi";
            string salt = ToPasswordHashExtension.GetSaltAsString();
            salt.ShouldNotBeNull();
            PasswordHashInfo pInfo = password.ToPasswordHash(salt);
            pInfo.ShouldNotBeNull();
            pInfo.PasswordHash.ShouldNotBeSameAs(password);
            _output.WriteLine(pInfo.ToJSON<PasswordHashInfo>(true));
        }
        #endregion
    }
}
