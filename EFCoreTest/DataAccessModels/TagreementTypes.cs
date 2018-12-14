using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class TagreementTypes
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public string Remark { get; set; }
        public string UserPoolTypeSystemId { get; set; }
    }
}
