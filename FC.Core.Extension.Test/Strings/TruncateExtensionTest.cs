using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Xunit.Abstractions;
using FC.Core.Extension.Test.DummyModel;
using FC.Core.Extension.StringHandlers;

namespace FC.Core.Extension.Test.Strings
{
    public class TruncateExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public TruncateExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Theory]
        [InlineData("This was the value to be truncted", 5)]
        [InlineData("Truncated output", 10)]

        public void TruncateTest_Test(string value, int length)
        {
            string output = value.Truncate(length);            
            _output.WriteLine(output);
            output.ShouldNotBeEmpty();
        }
    }
}
