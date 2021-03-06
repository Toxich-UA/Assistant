﻿using Assistant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace Assistant.Models
{
    public partial class AssistantContext : DbContext
    {
	    public AssistantContext(DbContextOptions<AssistantContext> options ) : base(options)
	    {
	    }

	    public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<OrderGoods> OrderGoods { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Formats> Formars { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(45);

                entity.Property(e => e.ImgSrc)
					.HasColumnName("imgSrc");
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

				entity.Property(e => e.Type)
					.HasColumnName("type")
					.HasMaxLength(20);

				entity.Property(e => e.Price)
					.HasColumnName("price");
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
			//Order Table
            modelBuilder.Entity<Orders>(entity =>
            {
	            entity.Property(e => e.Id)
		            .HasColumnName("id")
		            .ValueGeneratedOnAdd()
		            .HasColumnType("int(11)");

				entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Invoice)
                    .HasColumnName("invoice")
                    .HasMaxLength(45);

                entity.Property(e => e.OrderPrice)
                    .HasColumnName("orderPrice")
                    .HasMaxLength(45);

				entity.HasIndex(e => e.CustomerId)
					.HasName("customerId_idx");

	            entity.HasOne(d => d.Customers)
		            .WithMany(p => p.Orders)
		            .HasForeignKey(d => d.Id)
		            .HasConstraintName("customerId");
            });
			//Customer Table
			modelBuilder.Entity<Customers>(entity =>
			{
				entity.Property(e => e.Id)
					.HasColumnName("id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int(11)");

				entity.Property(e => e.FirstName)
					.HasColumnName("firstName")
					.HasMaxLength(20);

				entity.Property(e => e.LastName)
					.HasColumnName("lastName")
					.HasMaxLength(20);

				entity.Property(e => e.Address)
					.HasColumnName("adress")
					.HasMaxLength(100);

				entity.Property(e => e.PhoneNumber)
					.HasColumnName("phoneNumber")
					.HasMaxLength(20);

				entity.Property(e => e.Email)
					.HasColumnName("Email")
					.HasMaxLength(20);
			});
		}
    }
}
