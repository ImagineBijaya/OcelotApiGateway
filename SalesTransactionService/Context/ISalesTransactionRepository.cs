namespace SalesTransactionService.Context
{
    public interface ISalesTransactionRepository
    {
        public Task<IEnumerable<SalesTransaction>> GetSalesTransactionListAsync();
        public Task<SalesTransaction> GetSalesTransactionByIdAsync(int Id);
        public Task<SalesTransaction> AddSalesTransactionAsync(SalesTransaction salesTransaction);
        public Task<SalesTransaction> UpdateSalesTransactionAsync(SalesTransaction salesTransaction);
        public Task<SalesTransaction> DeleteSalesTransactionAsync(int Id);
    }
}
