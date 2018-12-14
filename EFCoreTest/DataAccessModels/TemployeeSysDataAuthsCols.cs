using System;
using System.Collections.Generic;

namespace EFCoreTest.Models2
{
    public partial class TemployeeSysDataAuthsCols
    {
        public int Id { get; set; }
        public int SysDataAuthsColsId { get; set; }
        public string EmployeeId { get; set; }
        public int OwnUserId { get; set; }
        public string Remark { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int EnterpriseId { get; set; }
        public int UserId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
    }
}
