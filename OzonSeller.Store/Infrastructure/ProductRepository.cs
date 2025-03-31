using Microsoft.EntityFrameworkCore;
using OzonSeller.Store.Domain;
using OzonSeller.Store.Domain.Interfaces;

namespace OzonSeller.Store.Infrastructure
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;

		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Product> GetByIdAsync(int productId)
		{
			return await _context.Products.Include(p => p.Transactions).FirstOrDefaultAsync(p => p.ProductId == productId);
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await _context.Products.Include(p => p.Transactions).ToListAsync();
		}

		public async Task AddAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}
	}
}
