using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FC.Core.Extension.Test.DummyModel
{
    public class DummyDataExport
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public decimal Money { get; set; }
        public double CurrencyValue { get; set; }
        public DateTime ProcessedDate { get; set; }
        public long IDNumber { get; set; }
        public bool Active { get; set; }

    }
    public class DummyData
    {
        [DisplayName("# ID")]
        public string ID { get; set; }

        [DisplayName("Full Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
    }
}
