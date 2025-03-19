using OzonSeller.Core.Services.Models;

namespace OzonSeller.Core.Services
{
	public interface IFinanceService
	{
		Task<FinanceTransactionResponse> GetFinanceTransaction(int month, int year);
	}
}