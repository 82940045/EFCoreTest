using System;
using System.Collections.Generic;

namespace EFCoreTest.DataAccessModels
{
    public partial class Tsysquestionstatus
    {
        public Tsysquestionstatus()
        {
            Tsysquestion = new HashSet<Tsysquestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<Tsysquestion> Tsysquestion { get; set; }
    }
}
