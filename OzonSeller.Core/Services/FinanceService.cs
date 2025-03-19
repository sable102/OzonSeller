using OzonSeller.Core.ApiClient;
using OzonSeller.Core.Services.Models;

namespace OzonSeller.Core.Services
{
	public class FinanceService : IFinanceService
	{
		private readonly IOzonApiClient _ozonApiClient;

		public FinanceService(IOzonApiClient ozonApiClient)
		{
			_ozonApiClient = ozonApiClient;
		}

		public async Task<FinanceTransactionResponse> GetFinanceTransaction(int month, int year)
		{
			var endpoint = "/v3/finance/transaction/list";

			var monthYear = new DateTime(year, month, 01);

			var requestData = new FinanceTransactionRequest
			{
				Filter = new Filter
				{
					Date = new DateFilter
					{
						From = monthYear,
						To = monthYear.AddMonths(1).AddTicks(-1)
					},
					TransactionType = "all",
					PostingNumber = string.Empty,
					OperationType = []
				},
				Page = 1,
				PageSize = 100
			};


			var responseData = await _ozonApiClient.PostAsync<FinanceTransactionResponse>(endpoint, requestData);

			return responseData;
		}
	}
}
