using System;
using System.Collections.Generic;

namespace EFCoreTest.DBMySQLModels
{
    public partial class Tsysquestion
    {
        public Tsysquestion()
        {
            Tsysquestiondescriptionpicture = new HashSet<Tsysquestiondescriptionpicture>();
            Tsysquestiondetail = new HashSet<Tsysquestiondetail>();
        }

        public int Id { get; set; }
        public string WorkOrderNo { get; set; }
        public int QuestionTypeId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AreaSystemId { get; set; }
        public string ControllerSystemId { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }

        public virtual Tsysquestionstatus Status { get; set; }
        public virtual ICollection<Tsysquestiondescriptionpicture> Tsysquestiondescriptionpicture { get; set; }
        public virtual ICollection<Tsysquestiondetail> Tsysquestiondetail { get; set; }
    }
}
