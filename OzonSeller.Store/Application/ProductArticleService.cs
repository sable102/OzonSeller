using OzonSeller.Store.Domain;
using OzonSeller.Store.Domain.Interfaces;

namespace OzonSeller.Store.Application
{
	public class ProductArticleService
	{
		private readonly IProductArticleRepository _productArticleRepository;

		public ProductArticleService(IProductArticleRepository productArticleRepository)
		{
			_productArticleRepository = productArticleRepository;
		}

		public async Task AddProductArticleAsync(int productId, string article)
		{
			var productArticle = new ProductArticle(productId, article);
			await _productArticleRepository.AddAsync(productArticle);
		}

		public async Task<IEnumerable<ProductArticle>> GetProductArticlesByProductIdAsync(int productId)
		{
			return await _productArticleRepository.GetByProductIdAsync(productId);
		}
	}
}
