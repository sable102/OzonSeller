using OzonSeller.Store.Domain;
using OzonSeller.Store.Domain.Interfaces;

namespace OzonSeller.Store.Application
{
	public class ProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly ITransactionRepository _transactionRepository;

		public ProductService(IProductRepository productRepository, ITransactionRepository transactionRepository)
		{
			_productRepository = productRepository;
			_transactionRepository = transactionRepository;
		}

		public async Task AddProductAsync(string name, string description, int quantity)
		{
			var product = new Product(name, description, quantity);
			await _productRepository.AddAsync(product);
		}

		public async Task AddTransactionAsync(int productId, TransactionType type, int quantity)
		{
			var product = await _productRepository.GetByIdAsync(productId);
			if (product != null)
			{
				var transaction = new Transaction(productId, type, quantity, DateTime.Now);
				product.AddTransaction(transaction);
				await _transactionRepository.AddAsync(transaction);
				await _productRepository.UpdateAsync(product);
			}
		}
	}
}
