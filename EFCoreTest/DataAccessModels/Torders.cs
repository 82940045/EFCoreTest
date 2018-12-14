using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Torders
    {
        public Torders()
        {
            Torderitems = new HashSet<Torderitems>();
        }

        public int Id { get; set; }
        public string OrderNum { get; set; }
        public string OrderSysAreaSystemId { get; set; }
        public int AmountPrice { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int? BillId { get; set; }
        public string BillStatus { get; set; }
        public string Remark { get; set; }
        public string CreateUserName { get; set; }
        public int CreateUserId { get; set; }
        public string CreateEnterpriseName { get; set; }
        public int CreateEnterpriseId { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public DateTime? UtcPayDate { get; set; }
        public string PushStatus { get; set; }
        public DateTime RowVersion { get; set; }

        public virtual Tbills Bill { get; set; }
        public virtual ICollection<Torderitems> Torderitems { get; set; }
    }
}
