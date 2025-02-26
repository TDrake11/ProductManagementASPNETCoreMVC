using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PRN222.Lab1.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN222.Lab1.Repositories.Data
{
	public class MyStoreDbContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options)
		: base(options) // Gọi base constructor
		{
		}
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<AccountMember> AccountMember { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>(entity =>
			{
				entity.HasKey(e => e.CategoryId);
				entity.Property(e => e.CategoryName).HasMaxLength(15);
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.ProductId);
				entity.Property(e => e.ProductName).HasMaxLength(40);
				entity.HasOne(d => d.Category)
					.WithMany(p => p.Products)
					.HasForeignKey(d => d.CategoryId)
					.HasConstraintName("FK_Product_Category");
			});

			modelBuilder.Entity<AccountMember>(entity =>
			{
				entity.HasKey(e => e.MemberId);
				entity.Property(e => e.FullName).HasMaxLength(50);
				entity.Property(e => e.MemberPassword).HasMaxLength(50);
			});
		}
	}
}
