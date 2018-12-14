using System;
using System.Collections.Generic;

namespace EFCoreTest.DBMySQLModels
{
    public partial class Tests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? Class { get; set; }
        public DateTime? Dt { get; set; }
        public DateTime Dt2 { get; set; }
    }
}
