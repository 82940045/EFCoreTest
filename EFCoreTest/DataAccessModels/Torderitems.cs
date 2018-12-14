using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Torderitems
    {
        public Torderitems()
        {
            Torderfearelat = new HashSet<Torderfearelat>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductSysId { get; set; }
        public string ProductName { get; set; }
        public string PictureFileId { get; set; }
        public string ValidityDateStr { get; set; }
        public int ValidityDate { get; set; }
        public string ValidityDateType { get; set; }
        public DateTime DeadlineUtc { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyUnit { get; set; }
        public int OrderItemPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string DetailUrl { get; set; }
        public string TproductGroupsSystemId { get; set; }
        public string ProductGroupsTitle { get; set; }
        public string ProductsDescription { get; set; }
        public string Remark { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public decimal SalePrice { get; set; }

        public virtual Torders Order { get; set; }
        public virtual ICollection<Torderfearelat> Torderfearelat { get; set; }
    }
}
