using Microsoft.EntityFrameworkCore;
using OzonSeller.Store.Domain;

namespace OzonSeller.Store.Infrastructure
{
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<ProductArticle> ProductArticles { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=D:\OzonSeller\app.db");
		}
	}
}
