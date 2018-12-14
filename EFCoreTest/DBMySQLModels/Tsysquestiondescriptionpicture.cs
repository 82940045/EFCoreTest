using System;
using System.Collections.Generic;

namespace EFCoreTest.DBMySQLModels
{
    public partial class Tsysquestiondescriptionpicture
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string PictureFileId { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public string IsEnabled { get; set; }
        public string IsDeleted { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime UtcUpdatedDate { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }

        public virtual Tsysquestion Question { get; set; }
    }
}
