using Microsoft.AspNetCore.Mvc;
using OzonSeller.Store.Application;
using OzonSeller.Store.Domain;
using OzonSeller.Store.Domain.Interfaces;

namespace OzonSeller.Store.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly ProductService _productService;
		private readonly IProductRepository _productRepository;
		private readonly ProductArticleService _productArticleService;

		public ProductsController(ProductService productService, IProductRepository productRepository, ProductArticleService productArticleService)
		{
			_productService = productService;
			_productRepository = productRepository;
			_productArticleService = productArticleService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
		{
			var products = await _productRepository.GetAllAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] ProductDto productDto)
		{
			await _productService.AddProductAsync(productDto.Name, productDto.Description, productDto.Quantity);
			return CreatedAtAction(nameof(GetProductById), new { id = productDto.ProductId }, productDto);
		}

		[HttpPost("{id}/transactions")]
		public async Task<ActionResult> AddTransaction(int id, [FromBody] TransactionDto transactionDto)
		{
			await _productService.AddTransactionAsync(id, transactionDto.Type, transactionDto.Quantity);
			return Ok();
		}

		[HttpPost("{id}/articles")]
		public async Task<ActionResult> AddProductArticle(int id, [FromBody] ProductArticleDto productArticleDto)
		{
			await _productArticleService.AddProductArticleAsync(id, productArticleDto.Article);
			return Ok();
		}

		[HttpGet("{id}/articles")]
		public async Task<ActionResult<IEnumerable<ProductArticle>>> GetProductArticles(int id)
		{
			var articles = await _productArticleService.GetProductArticlesByProductIdAsync(id);
			return Ok(articles);
		}
	}

	public class ProductDto
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
	}

	public class TransactionDto
	{
		public TransactionType Type { get; set; }
		public int Quantity { get; set; }
	}

	public class ProductArticleDto
	{
		public string Article { get; set; }
	}
}
