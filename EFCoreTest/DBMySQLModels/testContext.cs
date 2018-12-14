using Microsoft.EntityFrameworkCore;

namespace EFCoreTest.DBMySQLModels
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Tsysquestion> Tsysquestion { get; set; }
        public virtual DbSet<Tsysquestiondescriptionpicture> Tsysquestiondescriptionpicture { get; set; }
        public virtual DbSet<Tsysquestiondetail> Tsysquestiondetail { get; set; }
        public virtual DbSet<Tsysquestionstatus> Tsysquestionstatus { get; set; }
        public virtual DbSet<Tsysquestiontype> Tsysquestiontype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Port=3366;Database=test; User=root;Password=root;");
            }

            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMyCat("server=127.0.0.1;port=8066;uid=root;pwd=123456;database=TESTDB")
            //.UseDataNode("127.0.0.1", "world", "root", "root")
            //.UseDataNode("127.0.0.1", "test", "root", "root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tests>(entity =>
            {
                entity.ToTable("tests");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Class).HasColumnType("datetime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Dt)
                    .HasColumnName("dt")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Dt2)
                    .HasColumnName("dt2")
                    .HasColumnType("timestamp(6)")
                    .HasDefaultValueSql("'0000-00-00 00:00:00.000000'");

                entity.Property(e => e.Name).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Tsysquestion>(entity =>
            {
                entity.ToTable("tsysquestion");

                entity.HasIndex(e => e.QuestionTypeId)
                    .HasName("FK_TSysQuestion_TSysQuestionType");

                entity.HasIndex(e => e.StatusId)
                    .HasName("FK_TSysQuestion_TSysQuestionStatus");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AreaSystemId)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.ControllerSystemId).HasColumnType("varchar(40)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(5000)");

                entity.Property(e => e.EnterpriseId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.QuestionTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Remark).HasColumnType("varchar(500)");

                entity.Property(e => e.StatusId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.UserName).HasColumnType("varchar(50)");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkOrderNo)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tsysquestion)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSysQuestion_TSysQuestionStatus");
            });

            modelBuilder.Entity<Tsysquestiondescriptionpicture>(entity =>
            {
                entity.ToTable("tsysquestiondescriptionpicture");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("FK_TSysQuestionDescriptionPicture_TSysQuestion");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EnterpriseId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.PictureFileId).HasColumnType("varchar(50)");

                entity.Property(e => e.QuestionId).HasColumnType("int(11)");

                entity.Property(e => e.Remark).HasColumnType("varchar(500)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.UserName).HasColumnType("varchar(50)");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Tsysquestiondescriptionpicture)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_TSysQuestionDescriptionPicture_TSysQuestion");
            });

            modelBuilder.Entity<Tsysquestiondetail>(entity =>
            {
                entity.ToTable("tsysquestiondetail");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("FK_TSysQuestionDetail_TSysQuestion");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(5000)");

                entity.Property(e => e.EnterpriseId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.QuestionId).HasColumnType("int(11)");

                entity.Property(e => e.Remark).HasColumnType("varchar(500)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.UserName).HasColumnType("varchar(50)");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Tsysquestiondetail)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_TSysQuestionDetail_TSysQuestion");
            });

            modelBuilder.Entity<Tsysquestionstatus>(entity =>
            {
                entity.ToTable("tsysquestionstatus");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EnterpriseId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Remark).HasColumnType("varchar(500)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tsysquestiontype>(entity =>
            {
                entity.ToTable("tsysquestiontype");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EnterpriseId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Remark).HasColumnType("varchar(500)");

                entity.Property(e => e.SystemId)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");
            });
        }
    }
}
