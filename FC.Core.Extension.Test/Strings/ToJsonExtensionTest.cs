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
    public class ToJsonExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public ToJsonExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        #region ToJSON Test

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ToJSON_Test(bool indent)
        {
            DummyData dummy = new DummyData()
            {
                Address = "Chennai",
                Age = "36",
                ID = "12",
                Name = "SRG"
            };
            string json = dummy.ToJSON<DummyData>(indent);
            _output.WriteLine(json);
            json.ShouldNotBeEmpty();
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ToJSON_List_Test(bool indent)
        {
            DummyData dummy = new DummyData()
            {
                Address = "Chennai",
                Age = "36",
                ID = "12",
                Name = "SRG"
            };
            IList<DummyData> list = new List<DummyData>();
            list.Add(dummy);
            DummyData dummy2 = new DummyData()
            {
                Address = "Kumbakonam",
                Age = "35",
                ID = "123",
                Name = "Ram"
            };
            list.Add(dummy2);
            string json = list.ToJSON<IList<DummyData>>(indent);
            _output.WriteLine(json);
            json.ShouldNotBeEmpty();
        }

        #endregion


    }
}
