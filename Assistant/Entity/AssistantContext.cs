using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices.Internal;
using Microsoft.Extensions.Logging.Console;
using Microsoft.IdentityModel.Protocols;


namespace Assistant.Models
{
    public partial class AssistantContext : DbContext
    {
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<OrderGoods> OrderGoods { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server = localhost; User Id = root; Password = 4952; Database = Assistant");
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
            modelBuilder.Entity<Goods>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.ToTable("goods");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(45);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RetailPrice).HasColumnName("retailPrice");

                entity.Property(e => e.WholesalePrice).HasColumnName("wholesalePrice");
            });

            modelBuilder.Entity<OrderGoods>(entity =>
            {
	            entity.Property(e => e.Id)
		            .HasColumnName("id")
		            .ValueGeneratedOnAdd()
		            .HasColumnType("int(11)");
					

				entity.HasKey(e => e.Id);

                entity.ToTable("Order-Goods");

                entity.HasIndex(e => e.GoodsId)
                    .HasName("goodsId_idx");

				entity.HasIndex(e => e.OrderId)
                    .HasName("orderId_idx");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goodsId")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.OrderGoods)
                    .HasForeignKey(d => d.GoodsId)
                    .HasConstraintName("goodsId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderGoods)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("orderId");
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
