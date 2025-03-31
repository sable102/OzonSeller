using Microsoft.EntityFrameworkCore;
using OzonSeller.Store.Domain;
using OzonSeller.Store.Domain.Interfaces;
using System;

namespace OzonSeller.Store.Infrastructure
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly AppDbContext _context;

		public TransactionRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Transaction> GetByIdAsync(int transactionId)
		{
			return await _context.Transactions.FindAsync(transactionId);
		}

		public async Task<IEnumerable<Transaction>> GetAllAsync()
		{
			return await _context.Transactions.ToListAsync();
		}

		public async Task AddAsync(Transaction transaction)
		{
			await _context.Transactions.AddAsync(transaction);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Transaction transaction)
		{
			_context.Transactions.Update(transaction);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int transactionId)
		{
			var transaction = await _context.Transactions.FindAsync(transactionId);
			if (transaction != null)
			{
				_context.Transactions.Remove(transaction);
				await _context.SaveChangesAsync();
			}
		}
	}
}
