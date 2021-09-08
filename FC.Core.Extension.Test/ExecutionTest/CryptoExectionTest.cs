using FC.Core.Extension.StringHandlers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using CliFx.Infrastructure;
using FC.Extension.ExecutionSample.Strings;
using static FC.Extension.ExecutionSample.Strings.EncryptExtension_Command;
using System.Threading.Tasks;

namespace FC.Core.Extension.Test.ExecutionTest
{
    public class CryptoExectionTest
    {
        private readonly ITestOutputHelper _output;
        public CryptoExectionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        #region Encrypt or Decrypt Test
        [Fact]
        public async Task EncryptExecution_Test()
        {            
            string stdOut = await ExecuteConsole(CryptoOption.Encrypt);
            _output.WriteLine($"Cipher Text {stdOut}");
            stdOut.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task DecryptionExecution_Test()
        {
            string stdOut = await ExecuteConsole(CryptoOption.Decrypt);
            _output.WriteLine($"Plain Text {stdOut}");
            stdOut.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task HashExecution_Test()
        {
            string stdOut = await ExecuteConsole(CryptoOption.GenerateHash);
            _output.WriteLine($"Generated Hash {stdOut}");
            stdOut.ShouldNotBeNullOrEmpty();
        }


        #endregion

        #region Generic Execution
        public async Task<string> ExecuteConsole(CryptoOption option)
        {
            // Arrange
            using var console = new FakeInMemoryConsole();
            var command = new EncryptExtension_Command
            {
                Crypto = option
            };
            // Act
            await command.ExecuteAsync(console);
            var stdOut = console.ReadOutputString();
            return stdOut;
        }

        #endregion
    }
}
