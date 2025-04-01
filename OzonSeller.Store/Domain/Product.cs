using System;
using System.Collections.Generic;

namespace OzonSeller.Store.Domain
{

	public class Product
	{
		public int ProductId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public int Quantity { get; private set; }
		public string ImagePath { get; private set; }
		public List<Transaction> Transactions { get; private set; }

		public Product(string name, string description, int quantity, string imagePath)
		{
			Name = name;
			Description = description;
			Quantity = quantity;
			ImagePath = imagePath;
			Transactions = new List<Transaction>();
		}

		public void AddTransaction(Transaction transaction)
		{
			Transactions.Add(transaction);
			if (transaction.Type == TransactionType.Income)
			{
				Quantity += transaction.Quantity;
			}
			else if (transaction.Type == TransactionType.Expense)
			{
				Quantity -= transaction.Quantity;
			}
		}
	}



	public class Transaction
	{
		public int TransactionId { get; private set; }
		public int ProductId { get; private set; }
		public TransactionType Type { get; private set; }
		public int Quantity { get; private set; }
		public DateTime Date { get; private set; }

		public Transaction(int productId, TransactionType type, int quantity, DateTime date)
		{
			ProductId = productId;
			Type = type;
			Quantity = quantity;
			Date = date;
		}
	}
}
