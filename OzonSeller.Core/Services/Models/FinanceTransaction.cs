using System.Text.Json.Serialization;

namespace OzonSeller.Core.Services.Models
{

	public class Filter
	{
		[JsonPropertyName("date")]
		public DateFilter Date { get; set; }

		[JsonPropertyName("operation_type")]
		public List<string> OperationType { get; set; }

		[JsonPropertyName("posting_number")]
		public string PostingNumber { get; set; }

		[JsonPropertyName("transaction_type")]
		public string TransactionType { get; set; }
	}

	public class DateFilter
	{
		[JsonPropertyName("from")]
		public DateTime From { get; set; }

		[JsonPropertyName("to")]
		public DateTime To { get; set; }
	}

	public class FinanceTransactionRequest
	{
		[JsonPropertyName("filter")]
		public Filter Filter { get; set; }

		[JsonPropertyName("page")]
		public int Page { get; set; }

		[JsonPropertyName("page_size")]
		public int PageSize { get; set; }
	}


	public class Posting
	{
		[JsonPropertyName("delivery_schema")]
		public string DeliverySchema { get; set; }

		[JsonPropertyName("order_date")]
		public string OrderDate { get; set; }

		[JsonPropertyName("posting_number")]
		public string PostingNumber { get; set; }

		[JsonPropertyName("warehouse_id")]
		public long WarehouseId { get; set; }
	}

	public class Operation
	{
		[JsonPropertyName("operation_id")]
		public long OperationId { get; set; }

		[JsonPropertyName("operation_type")]
		public string OperationType { get; set; }

		[JsonPropertyName("operation_date")]
		public string OperationDate { get; set; }

		[JsonPropertyName("operation_type_name")]
		public string OperationTypeName { get; set; }

		[JsonPropertyName("delivery_charge")]
		public double DeliveryCharge { get; set; }

		[JsonPropertyName("return_delivery_charge")]
		public double ReturnDeliveryCharge { get; set; }

		[JsonPropertyName("accruals_for_sale")]
		public double AccrualsForSale { get; set; }

		[JsonPropertyName("sale_commission")]
		public double SaleCommission { get; set; }

		[JsonPropertyName("amount")]
		public double Amount { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("posting")]
		public Posting Posting { get; set; }

		[JsonPropertyName("items")]
		public List<object> Items { get; set; }

		[JsonPropertyName("services")]
		public List<object> Services { get; set; }
	}

	public class Result
	{
		[JsonPropertyName("operations")]
		public List<Operation> Operations { get; set; }

		[JsonPropertyName("page_count")]
		public int PageCount { get; set; }

		[JsonPropertyName("row_count")]
		public int RowCount { get; set; }
	}

	public class FinanceTransactionResponse
	{
		[JsonPropertyName("result")]
		public Result Result { get; set; }
	}

}
