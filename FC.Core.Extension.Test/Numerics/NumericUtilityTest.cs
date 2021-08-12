using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static FC.Extension.ExecutionSample.Strings.EncryptExtension_Command;
using FC.Core.Extension.NumericHandlers;

namespace FC.Core.Extension.Test.Numerics
{
    public class NumericUtilityTest
    {
        private readonly ITestOutputHelper _output;
        public NumericUtilityTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public async Task PercentageOfInteger_Test()
        {
            int value = 120;
            int percentage = 20;
            var percentValue = value.PercentageOf(percentage);
            
            _output.WriteLine($"{percentage}% of {value} is {percentValue}");
            percentValue.ShouldBePositive();
        }
        [Fact]
        public async Task PercentageOfDouble_Test()
        {
            double value = 840;
            int percentage = 5;
            var percentValue = value.PercentageOf(percentage);

            _output.WriteLine($"{percentage}% of {value} is {percentValue}");
            percentValue.ShouldBePositive();
        }

    }
}
