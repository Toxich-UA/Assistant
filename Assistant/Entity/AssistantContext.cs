using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace Assistant.Models
{
    public partial class AssistantContext : DbContext
    {
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<OrderGoods> OrderGoods { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Orders> Formars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server = localhost; User Id = root; Password = 4952; Database = Assistant; CharSet=utf8");
            }
			optionsBuilder.UseLoggerFactory(new LoggerFactory(new[]
			{
				new ConsoleLoggerProvider((category, level)
					=> category == DbLoggerCategory.Database.Command.Name
					   && level == LogLevel.Information, true)
			}));
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Goods Table
            modelBuilder.Entity<Goods>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.ToTable("Goods");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(45);

                entity.Property(e => e.Price)
					.HasColumnName("price");

                entity.Property(e => e.RetailPrice)
					.HasColumnName("retailPrice");

                entity.Property(e => e.WholesalePrice)
					.HasColumnName("wholesalePrice");
            });
			//Formats Table
			modelBuilder.Entity<Formats>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("Formats");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int(11)");

				entity.Property(e => e.Format)
					.HasColumnName("format")
					.HasMaxLength(20);
			});
			//OrderGoods Table
			modelBuilder.Entity<OrderGoods>(entity =>
            {
	            entity.Property(e => e.Id)
		            .HasColumnName("id")
		            .ValueGeneratedOnAdd()
		            .HasColumnType("int(11)");

				entity.Property(e => e.Count)
		            .HasColumnName("count")
		            .HasColumnType("int(11)");

				entity.HasKey(e => e.Id);

                entity.ToTable("OrderGoods");
				//Index
                entity.HasIndex(e => e.GoodsId)
                    .HasName("goodsId_idx");

				entity.HasIndex(e => e.OrderId)
                    .HasName("orderId_idx");

				entity.HasIndex(e => e.FormatId)
                    .HasName("formatType_idx");
				//////
				
	            entity.Property(e => e.OrderId)
		            .HasColumnName("orderId")
		            .HasColumnType("int(11)");

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goodsId")
                    .HasMaxLength(20);

				entity.Property(e => e.FormatId)
					.HasColumnName("formatId")
					.HasColumnType("int(11)");

				entity.HasOne(d => d.Goods)
		            .WithMany(p => p.OrderGoods)
		            .HasForeignKey(d => d.GoodsId)
		            .HasConstraintName("goodsId");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderGoods)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("orderId");

				entity.HasOne(d => d.Formats)
					.WithMany(p => p.OrderGoods)
					.HasForeignKey(d => d.FormatId)
					.HasConstraintName("formats");
			});

            modelBuilder.Entity<Orders>(entity =>
            {
	            entity.Property(e => e.Id)
		            .HasColumnName("id")
		            .ValueGeneratedOnAdd()
		            .HasColumnType("int(11)");

				entity.Property(e => e.Customer)
                    .HasColumnName("customer")
                    .HasMaxLength(45);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Invoice)
                    .HasColumnName("invoice")
                    .HasMaxLength(45);

                entity.Property(e => e.OrderPrice)
                    .HasColumnName("orderPrice")
                    .HasMaxLength(45);
            });
        }
    }
}
