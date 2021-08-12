using FC.Core.Extension.NumericHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static FC.Extension.ExecutionSample.Strings.EncryptExtension_Command;
using FC.Core.Extension.DateHandlers;


namespace FC.Core.Extension.Test.Dates
{
    public class DateHandlersTest
    {
        private readonly ITestOutputHelper _output;
        public DateHandlersTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public async Task Age_Test()
        {
            DateTime dtAge = new DateTime(2016, 02, 25);
            int age = dtAge.Age();           
            _output.WriteLine($"Age of person born at {dtAge.ToLongDateString()} is '{age}'");
            age.ShouldBePositive();

            dtAge = new DateTime(1984, 06, 14);
            age = dtAge.Age();
            _output.WriteLine($"Age of person born at {dtAge.ToLongDateString()} is '{age}'");
            age.ShouldBePositive();
        }

        [Fact]
        public async Task AgeInMonth_Test()
        {
            DateTime dtAge = new DateTime(2016, 02, 25);
            int age = dtAge.Age();
            double month = dtAge.AgeInMonth();
            _output.WriteLine($"Age of person born at {dtAge.ToLongDateString()} is '{age}' Month {month}");
            age.ShouldBePositive();

            dtAge = new DateTime(1984, 06, 14);
            age = dtAge.Age();
            month = dtAge.AgeInMonth();
            _output.WriteLine($"Age of person born at {dtAge.ToLongDateString()} is '{age}' Month {month}");
            age.ShouldBePositive();
        }
    }
}
