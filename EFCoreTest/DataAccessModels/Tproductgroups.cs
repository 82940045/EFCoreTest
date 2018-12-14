using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tproductgroups
    {
        public Tproductgroups()
        {
            Tproductgrouppublish = new HashSet<Tproductgrouppublish>();
            Tproducts = new HashSet<Tproducts>();
        }

        public int Id { get; set; }
        public string SystemId { get; set; }
        public string Title { get; set; }
        public string PictureFileId { get; set; }
        public string Description { get; set; }
        public string DetailUrl { get; set; }
        public string Remark { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }

        public virtual ICollection<Tproductgrouppublish> Tproductgrouppublish { get; set; }
        public virtual ICollection<Tproducts> Tproducts { get; set; }
    }
}
