using FC.Core.Extension.StringHandlers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FC.Core.Extension.Test.Strings;
public class IdentifyPersonalDetailsTests
{
    private readonly ITestOutputHelper _output;
    public IdentifyPersonalDetailsTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Fact]
    public void Identify_PhoneNumber_Test()
    {
        /// (XXX) XXX-XXXX
        string sensitiveString = "(525) 785-7842";
        string non_sensitiveString = sensitiveString.IdentifyAndRemove();
       
        _output.WriteLine($"Sensitive String {sensitiveString} No Sensitive Text {non_sensitiveString}");
        sensitiveString.ShouldNotBe(non_sensitiveString);
    }
}

