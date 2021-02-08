using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<ApplicantStatus> ApplicantStatuses { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<OfflinePaymentMethod> OfflinePaymentMethods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderAdditionalService> OrderAdditionalServices { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<ReferralSource> ReferralSources { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceTagAdditionalService> ServiceTagAdditionalServices { get; set; }
        public virtual DbSet<SubmittedWork> SubmittedWorks { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Taggable> Taggables { get; set; }
        public virtual DbSet<Urgency> Urgencies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkLevel> WorkLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.ToTable("activity_log");

                entity.HasIndex(e => e.LogName, "activity_log_log_name_index")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

                entity.HasIndex(e => new { e.CauserId, e.CauserType }, "causer")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 255 });

                entity.HasIndex(e => new { e.SubjectId, e.SubjectType }, "subject")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 255 });

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CauserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("causer_id");

                entity.Property(e => e.CauserType)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("causer_type")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LogName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("log_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("subject_id");

                entity.Property(e => e.SubjectType)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("subject_type")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.ToTable("additional_services");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rate)
                    .HasPrecision(10, 2)
                    .HasColumnName("rate");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('fixed','percentage')")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'fixed'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.ToTable("applicants");

                entity.HasIndex(e => e.ApplicantStatusId, "FK_applicants_applicant_statuses");

                entity.HasIndex(e => e.CountryId, "FK_applicants_countries");

                entity.HasIndex(e => e.ReferralSourceId, "FK_applicants_referral_sources");

                entity.HasIndex(e => e.Email, "applicants_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.About)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("about")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApplicantStatusId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("applicant_status_id");

                entity.Property(e => e.Attachment)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("attachment")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("country_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("email")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("first_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("last_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("number")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReferralSourceId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("referral_source_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.ApplicantStatus)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.ApplicantStatusId)
                    .HasConstraintName("FK_applicants_applicant_statuses");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_applicants_countries");

                entity.HasOne(d => d.ReferralSource)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.ReferralSourceId)
                    .HasConstraintName("FK_applicants_referral_sources");
            });

            modelBuilder.Entity<ApplicantStatus>(entity =>
            {
                entity.ToTable("applicant_statuses");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("attachments");

                entity.HasIndex(e => e.OrderId, "FK_attachments_orders");

                entity.HasIndex(e => e.UserId, "FK_attachments_users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("display_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("order_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_attachments_orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_attachments_users");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.HasIndex(e => e.OrderId, "FK_comments_orders");

                entity.HasIndex(e => e.UserId, "FK_comments_users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("body")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("order_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_comments_orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_comments_users");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("code")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OfflinePaymentMethod>(entity =>
            {
                entity.ToTable("offline_payment_methods");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("description")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.Instruction)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("instruction")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Settings)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("settings")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("slug")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuccessMessage)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("success_message")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.OrderStatusId, "FK_orders_order_order_statuses");

                entity.HasIndex(e => e.ServiceId, "FK_orders_services");

                entity.HasIndex(e => e.UrgencyId, "FK_orders_urgencies");

                entity.HasIndex(e => e.CustomerId, "FK_orders_users_customer_id");

                entity.HasIndex(e => e.WriterId, "FK_orders_users_writer_id");

                entity.HasIndex(e => e.WorkLevelId, "FK_orders_work_levels");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.ArchivedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("archived_at");

                entity.Property(e => e.BasePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_price");

                entity.Property(e => e.Billed).HasColumnName("billed");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Deadline)
                    .HasColumnType("datetime")
                    .HasColumnName("deadline");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Discount)
                    .HasPrecision(10, 2)
                    .HasColumnName("discount");

                entity.Property(e => e.Instruction)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("instruction")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InvoicedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("invoiced_at");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("number")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderStatusId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("order_status_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("smallint(5)")
                    .HasColumnName("quantity");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("service_id");

                entity.Property(e => e.SpacingType)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("spacing_type")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubTotal)
                    .HasPrecision(10, 2)
                    .HasColumnName("sub_total");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("title")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Total)
                    .HasPrecision(10, 2)
                    .HasColumnName("total");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("unit_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("unit_price");

                entity.Property(e => e.UpdateViaSms).HasColumnName("update_via_sms");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UrgencyId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("urgency_id");

                entity.Property(e => e.UrgencyPercentage).HasColumnName("urgency_percentage");

                entity.Property(e => e.UrgencyPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("urgency_price");

                entity.Property(e => e.WorkLevelId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("work_level_id");

                entity.Property(e => e.WorkLevelPercentage).HasColumnName("work_level_percentage");

                entity.Property(e => e.WorkLevelPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("work_level_price");

                entity.Property(e => e.WriterId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("writer_id");

                entity.Property(e => e.WriterPaymentAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("writer_payment_amount");

                entity.Property(e => e.WriterPaymentPercentage)
                    .HasPrecision(10, 2)
                    .HasColumnName("writer_payment_percentage");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomers)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_orders_order_order_statuses");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_orders_services");

                entity.HasOne(d => d.Urgency)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UrgencyId)
                    .HasConstraintName("FK_orders_urgencies");

                entity.HasOne(d => d.WorkLevel)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WorkLevelId)
                    .HasConstraintName("FK_orders_work_levels");

                entity.HasOne(d => d.Writer)
                    .WithMany(p => p.OrderWriters)
                    .HasForeignKey(d => d.WriterId);
            });

            modelBuilder.Entity<OrderAdditionalService>(entity =>
            {
                entity.ToTable("order_additional_services");

                entity.HasIndex(e => e.OrderId, "FK_order_additional_services_orders");

                entity.HasIndex(e => e.ServiceId, "FK_order_additional_services_services");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("order_id");

                entity.Property(e => e.Rate)
                    .HasPrecision(10, 2)
                    .HasColumnName("rate");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("service_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("type")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderAdditionalServices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_additional_services_orders");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderAdditionalServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_order_additional_services_services");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_statuses");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Badge)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("badge")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PriceType>(entity =>
            {
                entity.ToTable("price_types");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("ratings");

                entity.HasIndex(e => e.OrderId, "FK_ratings_orders");

                entity.HasIndex(e => e.UserId, "FK_ratings_users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comment")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Number)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("number");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("order_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ratings_orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ratings_users");
            });

            modelBuilder.Entity<ReferralSource>(entity =>
            {
                entity.ToTable("referral_sources");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.DisplayOrder)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("display_order")
                    .HasDefaultValueSql("'250'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasIndex(e => e.PriceTypeId, "FK_services_price_types");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DoubleSpacingPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("double_spacing_price");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.MinimumOrderQuantity)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("minimum_order_quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.PriceTypeId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("price_type_id")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.SingleSpacingPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("single_spacing_price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.PriceType)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.PriceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_services_price_types");
            });

            modelBuilder.Entity<ServiceTagAdditionalService>(entity =>
            {
                entity.HasKey(e => new { e.ServiceId, e.AdditionalServiceId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("service_tag_additional_services");

                entity.HasIndex(e => e.AdditionalServiceId, "FK_service_tag_additional_services_additional_services");

                entity.HasIndex(e => e.ServiceId, "FK_service_tag_additional_services_services");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("service_id");

                entity.Property(e => e.AdditionalServiceId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("additional_service_id");

                entity.HasOne(d => d.AdditionalService)
                    .WithMany(p => p.ServiceTagAdditionalServices)
                    .HasForeignKey(d => d.AdditionalServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_tag_additional_services_additional_services");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceTagAdditionalServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_tag_additional_services_services");
            });

            modelBuilder.Entity<SubmittedWork>(entity =>
            {
                entity.ToTable("submitted_works");

                entity.HasIndex(e => e.OrderId, "FK_submitted_works_orders");

                entity.HasIndex(e => e.UserId, "FK_submitted_works_users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CustomerMessage)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("customer_message")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("display_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("message")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NeedsRevision).HasColumnName("needs_revision");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("order_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SubmittedWorks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_submitted_works_orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SubmittedWorks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_submitted_works_users");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Taggable>(entity =>
            {
                entity.ToTable("taggables");

                entity.HasIndex(e => e.TagId, "FK_taggables_tags");

                entity.HasIndex(e => new { e.TaggableType, e.TaggableId }, "taggables_taggable_type_taggable_id_index")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 255, 0 });

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.TagId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("tag_id");

                entity.Property(e => e.TaggableId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("taggable_id");

                entity.Property(e => e.TaggableType)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("taggable_type")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Taggables)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_taggables_tags");
            });

            modelBuilder.Entity<Urgency>(entity =>
            {
                entity.ToTable("urgencies");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.PercentageToAdd)
                    .HasColumnType("double(8,2)")
                    .HasColumnName("percentage_to_add")
                    .HasDefaultValueSql("'10.00'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("type")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Value)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("value")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("first_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.LastLoginAt)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_at");

                entity.Property(e => e.LastLoginIp)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("last_login_ip")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("last_name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NetAuthUserId)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("net_auth_user_id")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("photo")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("timezone")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<WorkLevel>(entity =>
            {
                entity.ToTable("work_levels");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PercentageToAdd)
                    .HasColumnType("double(8,2)")
                    .HasColumnName("percentage_to_add")
                    .HasDefaultValueSql("'10.00'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
