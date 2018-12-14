using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tprodfearelat
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public string SysAreaSytemId { get; set; }
        public string PermissionSytemId { get; set; }

        public virtual Tproducts Products { get; set; }
    }
}
