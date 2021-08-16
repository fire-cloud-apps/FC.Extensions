using FC.Core.Extension.Test.DummyModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FC.Core.Extension.DataHandlers;
using Shouldly;

namespace FC.Core.Extension.Test.DataHandlers
{
    public class ToDataTableExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public ToDataTableExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }
        [Fact]
        public async Task ToDataTable_Test()
        {
            DummyData dummy1 = new DummyData()
            {
                Address = "Chennai",
                Age = "36",
                ID = "12",
                Name = "SRG"
            };
            DummyData dummy2 = new DummyData()
            {
                Address = "Chennai",
                Age = "16",
                ID = "11",
                Name = "SGP"
            };
            IList<DummyData> dummies = new List<DummyData>();
            dummies.Add(dummy1);
            dummies.Add(dummy2);

            var dtList = dummies.ToDataTable<DummyData>();
            dtList.Rows.Count.ShouldBeGreaterThan(1);
            _output.WriteLine($"Rows : {dtList.Rows.Count}");
        }
    }
}
