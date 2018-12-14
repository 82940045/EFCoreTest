using System;
using EFCoreTest.DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreTest.Models2
{
    public partial class saasoamanagerContext : DbContext
    {
        public saasoamanagerContext()
        {
        }

        public saasoamanagerContext(DbContextOptions<saasoamanagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TagreementTypes> TagreementTypes { get; set; }
        public virtual DbSet<Tbills> Tbills { get; set; }
        public virtual DbSet<Tcurrencytype> Tcurrencytype { get; set; }
        public virtual DbSet<Tdomains> Tdomains { get; set; }
        public virtual DbSet<TemployeeSysDataAuthsCols> TemployeeSysDataAuthsCols { get; set; }
        public virtual DbSet<TemployeeSysDataAuthsRows> TemployeeSysDataAuthsRows { get; set; }
        public virtual DbSet<Torderfearelat> Torderfearelat { get; set; }
        public virtual DbSet<Torderitems> Torderitems { get; set; }
        public virtual DbSet<Torders> Torders { get; set; }
        public virtual DbSet<Tprodfearelat> Tprodfearelat { get; set; }
        public virtual DbSet<Tproductgrouppublish> Tproductgrouppublish { get; set; }
        public virtual DbSet<Tproductgroups> Tproductgroups { get; set; }
        public virtual DbSet<Tproducts> Tproducts { get; set; }
        public virtual DbSet<TsysUserPoolType> TsysUserPoolType { get; set; }
        public virtual DbSet<Tsysquestion> Tsysquestion { get; set; }
        public virtual DbSet<Tsysquestiondescriptionpicture> Tsysquestiondescriptionpicture { get; set; }
        public virtual DbSet<Tsysquestiondetail> Tsysquestiondetail { get; set; }
        public virtual DbSet<Tsysquestionstatus> Tsysquestionstatus { get; set; }
        public virtual DbSet<Tsysquestiontype> Tsysquestiontype { get; set; }

        // Unable to generate entity type for table 'dbo.TSysUsers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TSysAreas'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IT-14097\\MSSQL2014;database=saasoa-manager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TagreementTypes>(entity =>
            {
                entity.ToTable("TAgreementTypes");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserPoolTypeSystemId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tbills>(entity =>
            {
                entity.ToTable("tbills", "test");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AttFileId).HasMaxLength(100);

                entity.Property(e => e.BillNum).HasMaxLength(200);

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.BillingTel)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.BillingUser)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.CompanyTel)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreateEnterpriseName).HasMaxLength(600);

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DepositBank).HasMaxLength(800);

                entity.Property(e => e.DepositBankName).HasMaxLength(800);

                entity.Property(e => e.InvoiceTitle)
                    .IsRequired()
                    .HasMaxLength(800);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Remark).HasMaxLength(1000);

                entity.Property(e => e.Taxpayer)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Tcurrencytype>(entity =>
            {
                entity.ToTable("tcurrencytype", "test");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Tdomains>(entity =>
            {
                entity.ToTable("TDomains");

                entity.Property(e => e.Agreement)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TemployeeSysDataAuthsCols>(entity =>
            {
                entity.ToTable("TEmployeeSysDataAuthsCols");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UtcCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UtcUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<TemployeeSysDataAuthsRows>(entity =>
            {
                entity.ToTable("TEmployeeSysDataAuthsRows");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DataAuthsRowData)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UtcCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UtcUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Torderfearelat>(entity =>
            {
                entity.ToTable("torderfearelat", "test");

                entity.HasIndex(e => e.OrderItemsId)
                    .HasName("torderfearelat_ibfk_1");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PermissionSystemId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysAreaSystemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.OrderItems)
                    .WithMany(p => p.Torderfearelat)
                    .HasForeignKey(d => d.OrderItemsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("torderfearelat_ibfk_1");
            });

            modelBuilder.Entity<Torderitems>(entity =>
            {
                entity.ToTable("torderitems", "test");

                entity.HasIndex(e => e.OrderId)
                    .HasName("torderitems_ibfk_1");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.CurrencyUnit)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.DeadlineUtc)
                    .HasColumnName("DeadlineUTC")
                    .HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DetailUrl).HasMaxLength(500);

                entity.Property(e => e.PictureFileId).HasMaxLength(100);

                entity.Property(e => e.ProductGroupsTitle)
                    .IsRequired()
                    .HasMaxLength(600);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ProductSysId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ProductsDescription).HasMaxLength(1000);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TproductGroupsSystemId)
                    .IsRequired()
                    .HasColumnName("TProductGroupsSystemId")
                    .HasMaxLength(40);

                entity.Property(e => e.ValidityDateStr)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ValidityDateType)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Torderitems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("torderitems_ibfk_1");
            });

            modelBuilder.Entity<Torders>(entity =>
            {
                entity.ToTable("torders", "test");

                entity.HasIndex(e => e.BillId)
                    .HasName("torders_ibfk_1");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BillStatus).HasMaxLength(10);

                entity.Property(e => e.CreateEnterpriseName).HasMaxLength(600);

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrderNum)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.OrderSysAreaSystemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PushStatus).HasMaxLength(10);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Torders)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("torders_ibfk_1");
            });

            modelBuilder.Entity<Tprodfearelat>(entity =>
            {
                entity.ToTable("tprodfearelat", "test");

                entity.HasIndex(e => e.ProductsId)
                    .HasName("FK_TProdFeaRelat_TProducts");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PermissionSytemId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysAreaSytemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Tprodfearelat)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TProdFeaRelat_TProducts");
            });

            modelBuilder.Entity<Tproductgrouppublish>(entity =>
            {
                entity.ToTable("tproductgrouppublish", "test");

                entity.HasIndex(e => e.ProductGroupId)
                    .HasName("FK_TProductGroupPublish_TProductGroups");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AreaSystemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Tproductgrouppublish)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TProductGroupPublish_TProductGroups");
            });

            modelBuilder.Entity<Tproductgroups>(entity =>
            {
                entity.ToTable("tproductgroups", "test");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.DetailUrl).HasMaxLength(500);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PictureFileId).HasMaxLength(100);

                entity.Property(e => e.Remark).HasMaxLength(600);

                entity.Property(e => e.SystemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(600);
            });

            modelBuilder.Entity<Tproducts>(entity =>
            {
                entity.ToTable("tproducts", "test");

                entity.HasIndex(e => e.CurrencyTypeId)
                    .HasName("FK_TProducts_TCurrencyType");

                entity.HasIndex(e => e.ProductGroupId)
                    .HasName("FK_TProducts_TProductGroups");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DetailUrl).HasMaxLength(500);

                entity.Property(e => e.DiscountPrice).HasColumnType("decimal(11, 4)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PictureFileId).HasMaxLength(100);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(11, 4)");

                entity.Property(e => e.SystemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ValidityDate).HasColumnType("decimal(11, 4)");

                entity.Property(e => e.ValidityDateStr)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ValidityDateType)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.Tproducts)
                    .HasForeignKey(d => d.CurrencyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TProducts_TCurrencyType");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Tproducts)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TProducts_TProductGroups");
            });

            modelBuilder.Entity<TsysUserPoolType>(entity =>
            {
                entity.ToTable("TSysUserPoolType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SystemId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UtcUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tsysquestion>(entity =>
            {
                entity.ToTable("tsysquestion", "test");

                entity.HasIndex(e => e.QuestionTypeId)
                    .HasName("FK_TSysQuestion_TSysQuestionType");

                entity.HasIndex(e => e.StatusId)
                    .HasName("FK_TSysQuestion_TSysQuestionStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AreaSystemId)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ControllerSystemId).HasMaxLength(40);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.WorkOrderNo)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Tsysquestion)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSysQuestion_TSysQuestionType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tsysquestion)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSysQuestion_TSysQuestionStatus");
            });

            modelBuilder.Entity<Tsysquestiondescriptionpicture>(entity =>
            {
                entity.ToTable("tsysquestiondescriptionpicture", "test");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("FK_TSysQuestionDescriptionPicture_TSysQuestion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PictureFileId).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Tsysquestiondescriptionpicture)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSysQuestionDescriptionPicture_TSysQuestion");
            });

            modelBuilder.Entity<Tsysquestiondetail>(entity =>
            {
                entity.ToTable("tsysquestiondetail", "test");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("FK_TSysQuestionDetail_TSysQuestion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Tsysquestiondetail)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSysQuestionDetail_TSysQuestion");
            });

            modelBuilder.Entity<Tsysquestionstatus>(entity =>
            {
                entity.ToTable("tsysquestionstatus", "test");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);
            });

            modelBuilder.Entity<Tsysquestiontype>(entity =>
            {
                entity.ToTable("tsysquestiontype", "test");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.SystemId)
                    .IsRequired()
                    .HasMaxLength(40);
            });
        }
    }
}
