using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Torderfearelat
    {
        public int Id { get; set; }
        public int OrderItemsId { get; set; }
        public string SysAreaSystemId { get; set; }
        public string PermissionSystemId { get; set; }

        public virtual Torderitems OrderItems { get; set; }
    }
}
