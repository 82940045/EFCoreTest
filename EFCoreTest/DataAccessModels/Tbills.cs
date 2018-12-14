using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tbills
    {
        public Tbills()
        {
            Torders = new HashSet<Torders>();
        }

        public int Id { get; set; }
        public string BillNum { get; set; }
        public string Type { get; set; }
        public DateTime? PubDate { get; set; }
        public int Amount { get; set; }
        public string ProductName { get; set; }
        public string InvoiceTitle { get; set; }
        public string Taxpayer { get; set; }
        public string DepositBankName { get; set; }
        public string DepositBank { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTel { get; set; }
        public string BillingUser { get; set; }
        public string BillingAddress { get; set; }
        public string BillingTel { get; set; }
        public string AttFileId { get; set; }
        public string Remark { get; set; }
        public string CreateUserName { get; set; }
        public string CreateEnterpriseName { get; set; }
        public int CreateUserId { get; set; }
        public int? CreateEnterpriseId { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }

        public virtual ICollection<Torders> Torders { get; set; }
    }
}
