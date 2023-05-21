using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Migrations;

namespace CustomerService.Context
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;   
        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            this._customerDbContext = customerDbContext;
        }


        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var result= await  _customerDbContext.Customers.AddAsync(customer);
                await _customerDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var result = await _customerDbContext.Customers
                    .FirstOrDefaultAsync(e => e.CustomerId == id);
            if (result != null)
            {
                _customerDbContext.Customers.Remove(result);
                await _customerDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerDbContext.Customers
                  .FirstOrDefaultAsync(e => e.CustomerId == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomerListAsync()
        {
            return await _customerDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var result = await _customerDbContext.Customers
                .FirstOrDefaultAsync(e => e.CustomerId == customer.CustomerId);

            if (result != null)
            {
                result.CustomerName = customer.CustomerName;
                result.CustomerEmail = customer.CustomerEmail;
                result.CustomerPhone = customer.CustomerPhone;
                result.CustomerCity = customer.CustomerCity;
         

                await _customerDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
