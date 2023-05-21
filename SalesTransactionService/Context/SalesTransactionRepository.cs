using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesTransactionService.Context
{
    public class SalesTransactionRepository : ISalesTransactionRepository
    {
        private readonly SalesTransactionDbContext _salesTransactionDbContext;
        public SalesTransactionRepository(SalesTransactionDbContext salesTransactionDbContext)
        { 
            _salesTransactionDbContext = salesTransactionDbContext;
        }


        public async Task<SalesTransaction> AddSalesTransactionAsync(SalesTransaction salesTransaction)
        {
            var result =   await _salesTransactionDbContext.SalesTransactions.AddAsync(salesTransaction);
            await _salesTransactionDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SalesTransaction> DeleteSalesTransactionAsync(int Id)
        {
            var result = await _salesTransactionDbContext.SalesTransactions
                    .FirstOrDefaultAsync(e => e.ProductId == Id);
            if (result != null)
            {
                _salesTransactionDbContext.SalesTransactions.Remove(result);
                await _salesTransactionDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<SalesTransaction> GetSalesTransactionByIdAsync(int Id)
        {
            return await _salesTransactionDbContext.SalesTransactions
                  .FirstOrDefaultAsync(e => e.ProductId == Id);
        }

        public async Task<IEnumerable<SalesTransaction>> GetSalesTransactionListAsync()
        {
            return await _salesTransactionDbContext.SalesTransactions.ToListAsync();
        }

        public async Task<SalesTransaction> UpdateSalesTransactionAsync(SalesTransaction salesTransaction)
        {
            var result = await _salesTransactionDbContext.SalesTransactions
                .FirstOrDefaultAsync(e => e.ProductId == salesTransaction.SalesTransactionId);

            if (result != null)
            {
                result.ProductId = salesTransaction.ProductId;
                result.CustomerId = salesTransaction.CustomerId;
                result.Quantity = salesTransaction.Quantity;
                result.IsInvoiced = salesTransaction.IsInvoiced;

                await _salesTransactionDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}

