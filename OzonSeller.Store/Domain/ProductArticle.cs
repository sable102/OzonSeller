using System.ComponentModel.DataAnnotations;

namespace OzonSeller.Store.Domain
{
	public class ProductArticle
	{
		[Key]
		public int ProductArticleId { get; private set; }

		[Required]
		public int ProductId { get; private set; }

		[Required]
		public string Article { get; private set; }

		public ProductArticle(int productId, string article)
		{
			ProductId = productId;
			Article = article;
		}
	}
}
