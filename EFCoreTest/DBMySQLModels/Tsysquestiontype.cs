using System;
using System.Collections.Generic;

namespace EFCoreTest.DBMySQLModels
{
    public partial class Tsysquestiontype
    {
        public int Id { get; set; }
        public string SystemId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public string Remark { get; set; }
    }
}
