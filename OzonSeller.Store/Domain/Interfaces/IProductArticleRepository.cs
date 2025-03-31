using OzonSeller.Store.Domain;

namespace OzonSeller.Store.Domain.Interfaces
{
	public interface IProductArticleRepository
	{
		Task<ProductArticle> GetByIdAsync(int productArticleId);
		Task<IEnumerable<ProductArticle>> GetAllAsync();
		Task<IEnumerable<ProductArticle>> GetByProductIdAsync(int productId);
		Task AddAsync(ProductArticle productArticle);
		Task UpdateAsync(ProductArticle productArticle);
		Task DeleteAsync(int productArticleId);
	}
}
