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

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderAdditionalService> OrderAdditionalServices { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Urgency> Urgencies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkLevel> WorkLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.OrderStatusId, "FK_orders_order_order_statuses");

                entity.HasIndex(e => e.ServiceId, "FK_orders_services");

                entity.HasIndex(e => e.UrgencyId, "FK_orders_urgencies");

                entity.HasIndex(e => e.CustomerId, "FK_orders_users_customer_id");

                entity.HasIndex(e => e.StaffId, "FK_orders_users_staff_id");

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
                    .HasColumnName("created_at");

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

                entity.Property(e => e.StaffId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("staff_id");

                entity.Property(e => e.StaffPaymentAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("staff_payment_amount");

                entity.Property(e => e.StaffPaymentPercentage)
                    .HasPrecision(10, 2)
                    .HasColumnName("staff_payment_percentage");

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

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.OrderStaffs)
                    .HasForeignKey(d => d.StaffId);

                entity.HasOne(d => d.Urgency)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UrgencyId)
                    .HasConstraintName("FK_orders_urgencies");

                entity.HasOne(d => d.WorkLevel)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WorkLevelId)
                    .HasConstraintName("FK_orders_work_levels");
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
                    .HasColumnName("created_at");

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
