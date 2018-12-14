using EFCoreTest.DataAccessModels;
using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tcurrencytype
    {
        public Tcurrencytype()
        {
            Tproducts = new HashSet<Tproducts>();
        }

        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }

        public virtual ICollection<Tproducts> Tproducts { get; set; }
    }
}
