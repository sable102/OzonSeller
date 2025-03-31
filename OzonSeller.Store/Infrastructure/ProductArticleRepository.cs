using Microsoft.EntityFrameworkCore;
using OzonSeller.Store.Domain;
using OzonSeller.Store.Domain.Interfaces;

namespace OzonSeller.Store.Infrastructure
{
	public class ProductArticleRepository : IProductArticleRepository
	{
		private readonly AppDbContext _context;

		public ProductArticleRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<ProductArticle> GetByIdAsync(int productArticleId)
		{
			return await _context.ProductArticles.FindAsync(productArticleId);
		}

		public async Task<IEnumerable<ProductArticle>> GetAllAsync()
		{
			return await _context.ProductArticles.ToListAsync();
		}

		public async Task<IEnumerable<ProductArticle>> GetByProductIdAsync(int productId)
		{
			return await _context.ProductArticles.Where(pa => pa.ProductId == productId).ToListAsync();
		}

		public async Task AddAsync(ProductArticle productArticle)
		{
			await _context.ProductArticles.AddAsync(productArticle);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(ProductArticle productArticle)
		{
			_context.ProductArticles.Update(productArticle);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int productArticleId)
		{
			var productArticle = await _context.ProductArticles.FindAsync(productArticleId);
			if (productArticle != null)
			{
				_context.ProductArticles.Remove(productArticle);
				await _context.SaveChangesAsync();
			}
		}
	}
}
