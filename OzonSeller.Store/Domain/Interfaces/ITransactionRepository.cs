namespace OzonSeller.Store.Domain.Interfaces
{
	public interface ITransactionRepository
	{
		Task<Transaction> GetByIdAsync(int transactionId);
		Task<IEnumerable<Transaction>> GetAllAsync();
		Task AddAsync(Transaction transaction);
		Task UpdateAsync(Transaction transaction);
		Task DeleteAsync(int transactionId);
	}
}
