using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tproducts
    {
        public Tproducts()
        {
            Tprodfearelat = new HashSet<Tprodfearelat>();
        }

        public int Id { get; set; }
        public string SystemId { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductName { get; set; }
        public string PictureFileId { get; set; }
        public string ValidityDateStr { get; set; }
        public decimal ValidityDate { get; set; }
        public string ValidityDateType { get; set; }
        public int CurrencyTypeId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int StoreQuantity { get; set; }
        public string Description { get; set; }
        public string DetailUrl { get; set; }
        public string Remark { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }

        public virtual Tcurrencytype CurrencyType { get; set; }
        public virtual Tproductgroups ProductGroup { get; set; }
        public virtual ICollection<Tprodfearelat> Tprodfearelat { get; set; }
    }
}
