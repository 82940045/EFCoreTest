using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tproductgrouppublish
    {
        public int Id { get; set; }
        public string AreaSystemId { get; set; }
        public int ProductGroupId { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }

        public virtual Tproductgroups ProductGroup { get; set; }
    }
}
